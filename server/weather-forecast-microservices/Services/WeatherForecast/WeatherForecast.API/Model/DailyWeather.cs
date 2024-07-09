using Newtonsoft.Json;

namespace WeatherForecast.API.Model
{
    public class DailyWeather
    {
        public City City { get; set; }
        public string Cod { get; set; }
        public float? Message { get; set; }
        public int? Cnt { get; set; }
        public List<WeatherData> List { get; set; }

    }

    public class WeatherData
    {
        public string Dt { get; set; }
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public Cloud Clouds { get; set; }
        public Wind Wind { get; set; }
        public float? Visibility { get; set; }
        public float? Pop { get; set; }
        public Rain Rain { get; set; }
        public Sys Sys { get; set; }
        public string DtTxt { get; set; }
    }
    public class Rain
    {
        [JsonProperty("3h")]
        public float? Name { get; set; }
    }

}
