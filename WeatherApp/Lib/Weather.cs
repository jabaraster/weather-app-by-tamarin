using System;

namespace WeatherApp.Lib
{
	public class Weather
	{
		public string Title { get; set; }
		public string Temperature { get; set; }
		public string Wind { get; set; }
		public string Humidity { get; set; }
		public string Visibility { get; set; }
		public DateTime Sunrise { get; set; }
		public DateTime Sunset { get; set; }
	}
}
