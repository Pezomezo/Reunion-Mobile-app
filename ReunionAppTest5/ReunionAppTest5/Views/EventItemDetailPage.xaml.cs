using ReunionAppTest5.Models;
using ReunionAppTest5.ViewModels;
using System;
using System.Collections.Generic;
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
	public partial class EventItemDetailPage : ContentPage
	{
		//Setting the received variables to the ViewModel to be formatted and then binded to the veiw
		public EventItemDetailPage(EventModel item)
		{
			InitializeComponent();
			BindingContext = new EventItemDetailPageViewModel(item);
		}
	}
}