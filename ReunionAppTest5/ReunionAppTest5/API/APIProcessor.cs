using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReunionAppTest5.Models
{
	public static class APIProcessor
	{
		//Returns a list of Events from the DB with the help of the APIHelper calss. 
		//Its an asyncronous method which makes the application more responsive
		public static async Task<List<EventAPIModel>> LoadEventsFromDB()
		{
			using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync("events"))
			{
				if (response.IsSuccessStatusCode)
				{
					var events = await response.Content.ReadAsAsync<EventResultModel>();

					return events.events;
				}else
				{
					throw new Exception("The problem: " + response.ReasonPhrase);
				}
			}
		}

		//Loads the places from the db through the API helper class.
		public static async Task<PlaceModel> LoadPlace(string id)
		{
			using (HttpResponseMessage response = await ApiHelper.apiClient.GetAsync("places/" + id))
			{
				if (response.IsSuccessStatusCode)
				{
					var place = await response.Content.ReadAsAsync<PlaceModel>();
					return place;
				}
				else
				{
					Console.WriteLine(response.ReasonPhrase);
					throw new Exception("The problem: " + response.ReasonPhrase);
				}
			}
		}
	}
}
