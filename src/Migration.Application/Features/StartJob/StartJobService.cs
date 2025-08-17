namespace Migration.Application;

public class StartJobService(
    IJobRepository _jobRepository,
    IJobLogRepository _jobLogRepository,
    IDataProcessingService _dataProcessingService,
    IUnitOfWork _unitOfWork,
    JobId.Factory _jobIdFactory,
    StartJobEntityMapper _entityMapper,
    ILogger<StartJobService> _logger)
    : IStartJobService
{
    public async Task<Result<StartJobResponse>> ProcessJobAsync(
        Guid guid,
        CancellationToken cancellationToken = default)
    {
        var jobId = _jobIdFactory.Create(guid);

        _logger.LogInformation("Processing job {JobId}", jobId);

        var job = await _jobRepository
            .GetByIdAsync(jobId, cancellationToken)
            .ConfigureAwait(false);

        if (job is null)
        {
            _logger.LogError("Job {JobId} not found", jobId);

            return Result<StartJobResponse>.Fail(ErrorItem.NotFound("Job id not found"));
        }

        await ProcessJobItems(jobId, job, cancellationToken)
            .ConfigureAwait(false);

        //ProcessJobItems method should return an StartJob 
        var startJob = new StartJob(guid, 6, DateTime.UtcNow);

        _logger.LogInformation("Completed processing for job {JobId}",jobId);

        return Result<StartJobResponse>.Ok(_entityMapper.ToResponse(startJob));
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
