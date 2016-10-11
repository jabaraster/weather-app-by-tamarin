using System;

using Xamarin.Forms;

namespace WeatherApp.Ui
{
	public class Page2 : ContentPage
	{
		public Page2()
		{
			this.Content = new StackLayout
			{
				Children = {
					new Label { Text = this.GetType().Name }
				},
			};

			this.ToolbarItems.Add(new ToolbarItem
			{
				Text = "進む",
				Command = new Command(() => this.Navigation.PushAsync(new Page2())),
			});
		}
	}
}
