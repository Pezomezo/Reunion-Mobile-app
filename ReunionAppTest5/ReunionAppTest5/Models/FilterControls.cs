using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ReunionAppTest5.Models
{
    class FilterControls : INotifyPropertyChanged
    {
		//Insances of variables used
		private ObservableCollection<EventModel> events = null;
		private string Age = "";
		private string Location = "";
		private string Price = "";
		private DateTime Date;

		//Filter controls constructor
		public FilterControls(string Age, string Location, string Price, DateTime Date, ObservableCollection<EventModel> events)
		{
			this.Age = Age;
			this.Date = Date;
			this.Location = Location;
			this.Price = Price;
			this.events = events;
		}
		//This is where the srorting starts and goes through all the differen filters  
		//and returns the final sorted observableCollection
		public ObservableCollection<EventModel> Sort()
		{
			AgeGroupSort();
			return events;
		}

		#region Sorting by selected fields
		private void AgeGroupSort()
		{
			ObservableCollection<EventModel> ageSorted = new ObservableCollection<EventModel>();

			if (this.Age == "No age group selected")
			{
				LocationSort(ageSorted);
			}

			
			//for (int i = 0; i < events.Count; i++)
			//{
			//	ageSorted = (ObservableCollection<EventListItem>)(from s in events
			//													  where events.ElementAt(i).Category == this.Age
			//													  select s);
			//}
			LocationSort(ageSorted);
		}

		private void LocationSort(ObservableCollection<EventModel> ageSorted)
		{
			ObservableCollection<EventModel> LocationSorted = new ObservableCollection<EventModel>();
			//for (int i = 0; i < ageSorted.Count; i++)
			//{
			//	LocationSorted = (ObservableCollection<EventListItem>)from s in ageSorted
			//														  where ageSorted.ElementAt(i).Location == this.Location
			//														  select s;
			//}

			DateSort(LocationSorted);
		}

		private void DateSort(ObservableCollection<EventModel> LocationSorted)
		{
			ObservableCollection<EventModel> dateSorted = new ObservableCollection<EventModel>();
			for (int i = 0; i < LocationSorted.Count; i++)
			{
				dateSorted = (ObservableCollection<EventModel>) from s in LocationSorted
							 where LocationSorted[i].Startdatetime == this.Date.ToString()
							 select s;
			}

			PriceSort(dateSorted);
		}

		private void PriceSort(ObservableCollection<EventModel> DateSorted)
		{
			ObservableCollection<EventModel> priceSorted = new ObservableCollection<EventModel>();
			for (int i = 0; i < DateSorted.Count; i++)
			{
				priceSorted = (ObservableCollection<EventModel>) from s in DateSorted
							  where DateSorted[i].Entrancefee == "0"
							  select s;
			}
			events = priceSorted;
		}
		#endregion


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
