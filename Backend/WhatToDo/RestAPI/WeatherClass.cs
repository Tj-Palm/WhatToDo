using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using RestApi.Models.Weather;


namespace RestApi
{
    public class WeatherClass
    {
        private const string URL = "http://api.openweathermap.org/data/2.5/weather";
        private const string urlParameters = "?q=Roskilde,dk&APPID=622f66a99c7a179b5c667c2d504ac522";
        

        public WeatherObject GetWeatherObjectFromWeatherApi()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            //Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                //Parse the reponse body.
                WeatherObject weatherData = response.Content.ReadAsAsync<WeatherObject>().Result;
                return weatherData;
                //foreach (var d in dataObjects)
                //{
                //    Console.WriteLine("{0}", d.name);
                //}
            }
            else
            {
                return new WeatherObject();
                //Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            client.Dispose();
        }
    }
}
