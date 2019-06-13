using ReunionAppTest5.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReunionAppTest5.Models
{
    class SplassImage : ContentPage
    {
		Image SplashImage = null;

		public SplassImage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			var sub = new AbsoluteLayout();
			SplashImage = new Image
			{
				Source = ImageSource.FromFile("sonderborgcommunelogo.jpg"),
				WidthRequest = 400,
				HeightRequest = 400
			};
			AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			sub.Children.Add(SplashImage);

			this.BackgroundColor = Color.White;
			this.Content = sub;
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			
			await SplashImage.ScaleTo(0.6, 1500, Easing.Linear);
			Application.Current.MainPage = new NavigationPage(new MainPage());			
		}

	}
}
