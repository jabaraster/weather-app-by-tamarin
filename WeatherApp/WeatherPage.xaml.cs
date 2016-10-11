using System;

using Xamarin.Forms;

namespace WeatherApp
{
	public partial class WeatherPage : ContentPage
	{
		private Editor zipCodeText = new Editor
		{
			Text = "郵便番号を入力",
			TextColor = Color.Black,
			BackgroundColor = Color.Gray,
			VerticalOptions = LayoutOptions.CenterAndExpand,
			HorizontalOptions = LayoutOptions.CenterAndExpand,
		};
		private Button weatherGetter = new Button
		{
			Text = "検索",
		};

		public WeatherPage()
		{
			InitializeComponent();
			Content = new StackLayout
			{
				Spacing = 4,
				BackgroundColor = Color.FromRgb(25, 250, 210),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = {
					new Label
					{
						Text = "An Expand option allows o",
								VerticalOptions = LayoutOptions.CenterAndExpand,
								HorizontalOptions = LayoutOptions.End,
						BackgroundColor = Color.Gray,
					},
					this.zipCodeText,
					this.weatherGetter,
				},
			};
			Content = new Label
			{
				Text = "Hello, Forms!",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.FromRgb(250, 250, 210),
			};

			this.weatherGetter.Clicked += WeatherGetter_Clicked;
		}

		async void WeatherGetter_Clicked(object sender, EventArgs e)
		{
			var weather = await Core.GetWeather(this.zipCodeText.Text);
			this.weatherGetter.Text = weather.Title;
		}
	}
}
