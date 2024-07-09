namespace WeatherForecast.API.Model
{
	public class Sys
	{
		public int? Type { get; set; }
		public int? Id { get; set; }
		public string Country { get; set; }
		public float? Sunrise { get; set; }
		public float? Sunset { get; set; }
        public string Pod { get; set; }
    }
}

