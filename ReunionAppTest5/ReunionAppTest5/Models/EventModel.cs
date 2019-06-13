using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ReunionAppTest5.Models
{
    public class EventModel
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public string Entrancefee { get; set; }
		public string Startdatetime { get; set; }
		public DateTime Enddatetime { get; set; }
		public string Place { get; set; }
		public string isAccepted { get; set; }
		public ImageSource EventImage { get; set; }

	}
}
