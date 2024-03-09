using CrudAppV6.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudAppV6.Data;

public class DataContext : DbContext
{
    private static string _dbPath = "data.db";

    // The following configures EF to create a Sqlite database file
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={_dbPath}");
    }

    
    // A DbSet is a collection that can store and retrieve data
    // from the Database
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    
}