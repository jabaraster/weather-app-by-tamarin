using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using WeatherApp.Lib;

namespace WeatherApp.Ui
{
	public class WeatherPage : ContentPage
	{
		Editor zipCodeText = new Editor
		{
			Text = "860-0047",
			HorizontalOptions = LayoutOptions.FillAndExpand,
		};
		Button weatherGetter = new Button
		{
			Text = "検索",
			HorizontalOptions = LayoutOptions.Fill,
		};
		Editor jsonText = new Editor
		{
			TextColor = Color.Blue,
			HorizontalOptions = LayoutOptions.FillAndExpand,
			VerticalOptions = LayoutOptions.FillAndExpand,
		};
		ActivityIndicator indicator = new ActivityIndicator
		{ };

		public WeatherPage()
		{
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

			this.ToolbarItems.Add(new ToolbarItem
			{
				Text = "進む",
				Command = new Command(() => this.Navigation.PushAsync(new Page2())),
			});


			this.weatherGetter.Clicked += WeatherGetter_Clicked;
		}

		async void WeatherGetter_Clicked(object sender, EventArgs e)
		{
			try
			{
				this.indicator.IsRunning = true;
				var weather = await Core.GetWeather(this.zipCodeText.Text);
				if (weather == null) return;
				this.jsonText.Text = JsonConvert.SerializeObject(weather, Formatting.Indented);
			}
			finally
			{
				this.indicator.IsRunning = false;
			}
		}
	}
}

