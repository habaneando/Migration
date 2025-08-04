namespace Migration.Application;

public interface IBackgroundJobScheduler
{
    /// <summary>
    /// Schedules a job to be processed in the background
    /// This is infrastructure - handles threading, queuing, etc.
    /// </summary>
    Task ScheduleJobAsync(JobId jobId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Schedules a job to be processed at a specific time
    /// </summary>
    Task ScheduleJobAsync(JobId jobId, DateTimeOffset scheduledTime, CancellationToken cancellationToken = default);

    /// <summary>
    /// Schedules a recurring job
    /// </summary>
    Task ScheduleRecurringJobAsync(JobId jobId, string cronExpression, CancellationToken cancellationToken = default);
}
