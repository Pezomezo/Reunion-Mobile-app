using ReunionAppTest5.Models;
using ReunionAppTest5.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReunionAppTest5.ViewModels
{

	//The ViewModel of the MainPage
	class MainPageViewModel : BindableObject, INotifyPropertyChanged
	{

		private ObservableCollection<EventModel> _menuItems = new ObservableCollection<EventModel>();
		private INavigation navigationInst;
		public ICommand InitializeListCommand { get; private set; }
		public ICommand ItemSelectedCommand { get; private set; }

		public ObservableCollection<EventModel> MenuItems
		{
			get { return _menuItems; }
			set
			{
				_menuItems = value;
				this.OnPropertyChanged("MenuItems");
			}
		}

		public MainPageViewModel()
		{

		}

		public MainPageViewModel(ListView listView, INavigation navigation)
		{
			navigationInst = navigation;
			listView.RefreshCommand = new Command<ListView>(async func =>
			{
				await LoadEvents();
				listView.IsRefreshing = false;
			});
			ItemSelectedCommand = new Command<EventModel>(OpenSelectedEventPage);
			InitializeListCommand = new Command(async func => await LoadEvents());
		}

		private async Task LoadEvents()
		{
			try
			{
				Console.WriteLine("Try block");
				MenuItems = new ObservableCollection<EventModel>();
				List<EventAPIModel> eventListItem = await APIProcessor.LoadEventsFromDB();
				Console.WriteLine("event: " + eventListItem[0].Name);
		
				foreach (var attraction in eventListItem)
				{
					if (attraction.isAccepted == "true")
					{
						PlaceModel placeResults = await APIProcessor.LoadPlace(attraction.Placeid);

						MenuItems.Add(new EventModel
						{
							Place = placeResults.Place,
							Description = attraction.Description,
							Enddatetime = attraction.Enddatetime,
							Entrancefee = attraction.Entrancefee.ToString(),
							EventImage = attraction.EventImage,
							Name = attraction.Name,
							Startdatetime = attraction.Startdatetime.ToString()
						});
						Console.WriteLine("event added: " + eventListItem[0].Name);
					}
					
				}
				Console.Write("events list after foreach: " + MenuItems.Count);
			}
			catch (Exception ex)
			{

				Console.WriteLine("Catch block in the MainPageDetailView : " + ex);
			}

		}

		private async void OpenSelectedEventPage(EventModel selectedEvent)
		{
			await navigationInst.PushAsync(new EventItemDetailPage(selectedEvent));
		}

		//Overloadedd constructor to filter the get the filter options and
		//sort the main list according to the with the use of the FilterControls class
		public MainPageViewModel(string Age, string Location, string Price, DateTime Date)
		{
			//FilterControls = new FilterControls(Age, Location, Price, Date, MenuItems);
			//MenuItems = FilterControls.Sort();
		}

		#region INotifyPropertyChanged Implementation
		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
