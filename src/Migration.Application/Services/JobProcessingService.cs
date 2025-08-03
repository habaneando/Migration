namespace Migration.Application;

public class JobProcessingService : IJobProcessingService
{
    private readonly IJobRepository _jobRepository;

    private readonly IJobLogRepository _jobLogRepository;   

    private readonly IDataProcessingService _dataProcessingService;

    private readonly IUnitOfWork _unitOfWork;

    private readonly ILogger<JobProcessingService> _logger;

    public JobProcessingService(
        IJobRepository jobRepository,
        IJobLogRepository jobLogRepository,
        IDataProcessingService dataProcessingService,
        IUnitOfWork unitOfWork,
        ILogger<JobProcessingService> logger)
    {
        _jobRepository = jobRepository;
        _jobLogRepository = jobLogRepository;
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

        await ProcessJobItems(jobId, job, cancellationToken)
            .ConfigureAwait(false);

        _logger.LogInformation("Completed processing for job {JobId}",jobId);
    }

    private async Task ProcessJobItems(
        JobId jobId,
        Job job,
        CancellationToken cancellationToken = default)
    {
        var pendingItems = job.Data.Where(x => x.Status == JobItemStatus.Pending);

        foreach (var item in pendingItems)
        {
            try
            {
                _logger.LogDebug("Processing item {ItemId} for job {JobId}", item.Id, jobId);

                var jobLog = await _dataProcessingService
                    .ProcessItemAsync(item, cancellationToken)
                    .ConfigureAwait(false);

                await _jobLogRepository.UpdateAsync(jobLog)
                    .ConfigureAwait(false);

                await _unitOfWork.CommitAsync(cancellationToken)
                    .ConfigureAwait(false);

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

                await _jobLogRepository.UpdateAsync(jobLog)
                    .ConfigureAwait(false);

                await _unitOfWork.CommitAsync(cancellationToken)
                    .ConfigureAwait(false);

                if (job.Type == JobType.Batch)
                    break;
            }
        }
    }
}
