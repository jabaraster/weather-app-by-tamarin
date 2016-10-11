using System;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace WeatherApp
{
	public partial class WeatherPage : ContentPage
	{
		private Editor zipCodeText = new Editor
		{
			Text = "860-0047",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};
		private Button weatherGetter = new Button
		{
			Text = "検索",
			HorizontalOptions = LayoutOptions.Fill,
		};
		private Editor jsonText = new Editor
		{
			TextColor = Color.Blue,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
		};
		private ActivityIndicator indicator = new ActivityIndicator();

		/// <summary>
		/// Initializes a new instance of the <see cref="T:WeatherApp.WeatherPage"/> class.
		/// </summary>
		public WeatherPage()
		{
			InitializeComponent();
			this.BackgroundColor = Color.FromRgb(250, 250, 210);

			this.Content = new StackLayout
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 10, 10), 10, 10),
				Spacing = 4, //各要素間のスペース
				Children = {
					this.zipCodeText,
					this.weatherGetter,
					this.indicator,
					this.jsonText,
				},
			};
			this.weatherGetter.Clicked += WeatherGetter_Clicked;

		}

		async void WeatherGetter_Clicked(object sender, EventArgs e)
		{
			try
			{
				this.indicator.IsRunning = true;
				var weather = await Core.GetWeather(this.zipCodeText.Text);
				if (weather == null) return;
				this.jsonText.Text = JsonConvert.SerializeObject(weather);
			}
			finally
			{
				this.indicator.IsRunning = false;
			}
		}
	}
}
