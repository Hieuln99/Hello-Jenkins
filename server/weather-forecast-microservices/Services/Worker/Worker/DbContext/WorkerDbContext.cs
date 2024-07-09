using Microsoft.EntityFrameworkCore;

public class WorkerDbContext : DbContext
{
    protected readonly IConfiguration _configuration;
    public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options)
    {
    }

    public DbSet<WeatherData> WeatherDatas { get; set; }
}
