using System;

namespace API_Tatuajes
{
    ///<Summary></Summary>
    public class WeatherForecast
    {
        ///<Summary></Summary>
        public DateTime Date { get; set; }
        ///<Summary></Summary>
        public int TemperatureC { get; set; }
        ///<Summary></Summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        ///<Summary></Summary>
        public string Summary { get; set; }
    }
}
