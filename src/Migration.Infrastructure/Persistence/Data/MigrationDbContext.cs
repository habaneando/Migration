namespace Migration.Infrastructure;

public class MigrationDbContext : DbContext
{
    public DbSet<Job> Jobs { get; set; }

    public DbSet<JobLogs> JobLogs { get; set; }

    public DbSet<JobStatusItem> JobStatusItems { get; set; }

    public MigrationDbContext(DbContextOptions<MigrationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new JobConfiguration());

        modelBuilder.ApplyConfiguration(new JobLogsConfiguration());

        modelBuilder.ApplyConfiguration(new JobIStatusItemConfiguration());
    }
}
