using System.Threading.Tasks;

namespace WeatherApp.Lib
{
	public class Core
	{
		public static async Task<Weather> GetWeather(string zipCode)
		{
			if (zipCode == null || zipCode.Trim().Length == 0) return null;

			var url = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",jp&units=imperial&appid=293fb240d3ccbfe47c78f3249a276da5";
			var json = await DataService.getJsonFromService(url);
			var ret = new Weather();
			ret.Title = (string)json["name"];
			ret.Temperature = json["main"]["temp"] + " F";
			ret.Wind = json["wind"]["speed"] + " mph";
			ret.Humidity = json["main"]["humidity"] + " %";
			ret.Visibility = (string)json["weather"][0]["main"];

			var time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
			var sunrise = time.AddSeconds((double)json["sys"]["sunrise"]);
			var sunset = time.AddSeconds((double)json["sys"]["sunset"]);
			ret.Sunrise = sunrise;
			ret.Sunset = sunset;

			return ret;
		}
	}
}
