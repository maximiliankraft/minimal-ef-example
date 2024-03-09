namespace CrudAppV6.Data;

public class WeatherForecastService
{
    private DataContext db;

    public WeatherForecastService()
    {
        db = new DataContext();
        db.Database.EnsureCreated();
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        var weatherData = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        });

        
        
        db.WeatherForecasts.AddRange(weatherData);
        db.SaveChanges();
        
        return Task.FromResult(db.WeatherForecasts.ToArray());
    }
}