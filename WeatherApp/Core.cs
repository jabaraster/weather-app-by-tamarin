using System.Threading.Tasks;

namespace WeatherApp
{
	public class Core
	{
		public static async Task<Weather> GetWeather(string zipCode)
		{
			var url = "http://api.openweathermap.org/data/2.5/weather?zip=" + zipCode + ",jp&units=imperial&appid=293fb240d3ccbfe47c78f3249a276da5";
			var json = await DataService.getDataFromService(url);
		}
	}
}
