using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherApp
{
	public class DataService
	{
		public static async Task<JObject> getDataFromService(string url)
		{
			var response = await new HttpClient().GetAsync(url);
			if (response == null) return null;

			string json = response.Content.ReadAsStringAsync().Result;
			if (json == null) return null;

			return JsonConvert.DeserializeObject<JObject>(json);
		}
	}
}
