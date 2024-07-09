namespace WeatherForecast.API.Model
{
	public class City
	{
		public int? Id { get; set; }
		public string Name { get; set; }
		public Coord Coord { get; set; }
		public string Country { get; set; }
		public float? Population { get; set; }
		public float? Timezone { get; set; }
		public float? Sunrise { get; set; }
		public float? Sunset { get; set; }
	}
}
