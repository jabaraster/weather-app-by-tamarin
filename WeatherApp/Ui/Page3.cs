using Xamarin.Forms;

namespace WeatherApp.Ui
{
	class Page3 : ContentPage
	{
		Button clicker = new Button
		{
			Text = "大幅に戻る"
		};

		Page previousPage;


		/// <summary>
		/// Initializes a new instance of the <see cref="T:WeatherApp.Ui.Page3"/> class.
		/// </summary>
		public Page3(Page pPreviousPage)
		{
			this.previousPage = pPreviousPage;

			this.Content = new StackLayout
			{
				Children = {
					new Label { Text = this.GetType().Name },
					this.clicker,
				},
			};

			this.clicker.Clicked += Clicker_Clicked;
		}

		async void Clicker_Clicked(object sender, System.EventArgs e)
		{
			this.Navigation.RemovePage(this.previousPage);
			await this.Navigation.PopAsync();
		}
	}
}