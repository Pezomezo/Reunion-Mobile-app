using ReunionAppTest5.Models;
using ReunionAppTest5.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReunionAppTest5.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
		//Binding to the corresponding view model
		public MainPageDetail()
        {
            InitializeComponent();
			BindingContext = new MainPageViewModel(EventsListView, Navigation);
        }

	}	
}