using ReunionAppTest5.Models;
using ReunionAppTest5.ViewModels;
using ReunionAppTest5.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ReunionAppTest5
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			//setting the MainPage to be Splash Image whic will present a loading image when the app starts
			MainPage = new NavigationPage(new SplassImage());
		}


		protected async override void OnStart()
		{
			// Initializes the api client at the start of the application
			ApiHelper.IitialializeClient();
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
