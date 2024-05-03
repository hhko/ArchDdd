//using ArchDdd.Adapters.Presentation.Abstractions.Controllers;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//namespace ArchDdd.Adapters.Presentation.Controllers;

////[ApiVersion("1.5", Deprecated = true)]
////public class WeatherForecastController(ISender sender) : ApiController(sender)
//public class WeatherForecastController : ApiController
//{
//    private static readonly string[] Summaries = new[]
//    {
//            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//    [HttpGet(Name = "GetWeatherForecast")]
//    public IEnumerable<WeatherForecast> Get()
//    {
//        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//        {
//            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//            TemperatureC = Random.Shared.Next(-20, 55),
//            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//        })
//        .ToArray();
//    }
//}

//public class WeatherForecast
//{
//    public DateOnly Date { get; set; }

//    public int TemperatureC { get; set; }

//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

//    public string? Summary { get; set; }
//}