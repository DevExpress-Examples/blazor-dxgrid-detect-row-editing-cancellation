namespace ShowConfirmationDialog.Data {
    public class WeatherForecastService {

        public IEnumerable<string> Summaries = new List<string>() {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
          };

        public Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate) {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries.OrderBy(s => rng.NextDouble()).First()
            }).ToList());
        }
    }
}