using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ReunionAppTest5.Models
{
    public static class ApiHelper 
    {
		public static HttpClient apiClient = null;

		//This is a Singleton for the api client so we dont need to initialize it every time we make an API request.
		public static void IitialializeClient()
		{
			if (apiClient == null)
			{
				apiClient = new HttpClient();
				apiClient.BaseAddress = new Uri("http://genforeningen-server.herokuapp.com/");
				apiClient.DefaultRequestHeaders.Accept.Clear();
				apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			}
		}

	}
}
