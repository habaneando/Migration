namespace Migration.Application;

public class JobProcessingService : IJobProcessingService
{
    private readonly IJobRepository _jobRepository;

    private readonly IDataProcessingService _dataProcessingService;

    private readonly IUnitOfWork _unitOfWork;

    private readonly ILogger<JobProcessingService> _logger;

    public JobProcessingService(
        IJobRepository jobRepository,
        IDataProcessingService dataProcessingService,
        IUnitOfWork unitOfWork,
        ILogger<JobProcessingService> logger)
    {
        _jobRepository = jobRepository;
        _dataProcessingService = dataProcessingService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task ProcessJobAsync(JobId jobId, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Processing job {JobId}", jobId);

        var job = await _jobRepository
            .GetByIdAsync(jobId, cancellationToken)
            .ConfigureAwait(false);

        if (job is null)
        {
            _logger.LogError("Job {JobId} not found", jobId);
            return;
        }

        var pendingItems = job.Data
            .Where(x => x.Status == JobItemStatus.Pending)
            .ToList();

        foreach (var item in pendingItems)
        {
            try
            {
                _logger.LogDebug("Processing item {ItemId} for job {JobId}", item.Id, jobId);

                var jobLog = await _dataProcessingService
                    .ProcessItemAsync(item, cancellationToken)
                    .ConfigureAwait(false);

                job.ProcessItem(jobLog);

                await _unitOfWork.CommitAsync(cancellationToken);

                if (jobLog.Status == JobLogStatus.Failure &&
                    job.Type == JobType.Batch)
                {
                    _logger.LogWarning("Stopping BATCH job {JobId} due to failed item {ItemId}", jobId, item.Id);
                    break;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing item {ItemId} for job {JobId}", item.Id, jobId);

                var jobLog = new JobLog(
                    item.Id,
                    JobLogStatus.Failure,
                    $"Processing error: {ex.Message}");

                job.ProcessItem(jobLog);

                await _unitOfWork.CommitAsync(cancellationToken);

                if (job.Type == JobType.Batch)
                    break;
            }
        }

        _logger.LogInformation("Completed processing for job {JobId}",jobId);
    }
}
