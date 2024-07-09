namespace WeatherForecast.API.Model
{
    public class CurrentWeather
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public float? Visibility { get; set; }
        public Wind Wind { get; set; }
        public Cloud Clouds { get; set; }
        public long? Dt { get; set; }
        public Sys Sys { get; set; }
        public float? Timezone { get; set; }
        public int? Id { get; set; }
        public string Name { get; set; }
        public float? Cod { get; set; }
    }
}
