using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class Weather
    {
        public DateOnly Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public Weather(DateOnly date, int temperatureC, string? summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }
    }
}