using ReunionAppTest5.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReunionAppTest5.Models
{
    public class EventAPIModel
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public int Entrancefee { get; set; }
		public DateTime Startdatetime { get; set; }
		public DateTime Enddatetime { get; set; }
		public string Placeid { get; set; }
		public string isAccepted { get; set; }
		public ImageSource EventImage { get; set; }

	}
}
