using ReunionAppTest5.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ReunionAppTest5.ViewModels
{
	public class EventItemDetailPageViewModel : BindableObject, INotifyPropertyChanged
	{
		//Creating an instance of the EventModel class
		private EventModel eventmodelInst;

		public EventModel EventModel
		{
			get { return eventmodelInst; }
			set { eventmodelInst = value; OnPropertyChanged("EventModel"); }
		}

		//even theough we are not using this empty constructor it is a must to have othervise the code will not compile
		public EventItemDetailPageViewModel()
		{

		}

		//This is the constructor we are using to take in the nessecary variables. 
		public EventItemDetailPageViewModel( EventModel item)
		{
			EventModel = item;
			item.Startdatetime = DateReformatter(item.Startdatetime, item.Enddatetime.ToString());
			
		}

		//Thís method returns a string that contains the startdate and time and the endtime
		//that gets created from the startdatetume and enddatetime variables
		private string DateReformatter(string startdatetime, string enddatetime)
		{
			string returnVal = "";
			returnVal = startdatetime.Substring(0, startdatetime.Length - 2);
			string[] endtimeList = enddatetime.Split();
			returnVal += " - " + endtimeList[1];
			return returnVal;
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
