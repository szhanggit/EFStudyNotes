using LoadConnStrDynamically.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadConnStrDynamically.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //D:\Study\GraphQLStudyNotes\TXC\GraphQLServices\ProductService\ProductService.csproj
            string connString = "Data Source=LAPTOP-LDKKTL6G\\STEVENZSERVER;Initial Catalog=txc_local_tenant_tw;User ID=steven;Password=steven;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connString);
            DataContext dc = (DataContext)Activator.CreateInstance(typeof(DataContext), optionsBuilder.Options);
            var product = dc.Products.AsNoTracking().Where(x => x.ProductId == 1)?.FirstOrDefault();



            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
