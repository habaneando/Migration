namespace Migration.Application;

public class BackgroundJobScheduler : IBackgroundJobScheduler
{
    Task IBackgroundJobScheduler.ScheduleJobAsync(JobId jobId, CancellationToken cancellationToken) =>
        Task.CompletedTask;

    Task IBackgroundJobScheduler.ScheduleJobAsync(JobId jobId, DateTimeOffset scheduledTime, CancellationToken cancellationToken) =>
        Task.CompletedTask;

    Task IBackgroundJobScheduler.ScheduleRecurringJobAsync(JobId jobId, string cronExpression, CancellationToken cancellationToken) =>
        Task.CompletedTask;
}
