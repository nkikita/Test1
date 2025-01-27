using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Services
{
    public interface WeatherService
    {
         public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary);
    }
}