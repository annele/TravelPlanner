using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace TravelPlanner
{
    public class GetWeatherData
    {
        private String getApiKey()

        {
            string filePath = @"..\..\config.txt";
            string weatherApikey = "";

            if (File.Exists(filePath))
            {
                string configs = System.IO.File.ReadAllText(filePath);
                weatherApikey = configs.Split('=')[1];

            }
            else
            {
                return null;
            }
            return weatherApikey;
        }

        public Dictionary<string, string> GetLocations(string cityname)
        {


            WebClient w = new WebClient();
            var locationsList = new Dictionary<String, String>();

            var weatherApikey = getApiKey();
            if(weatherApikey == null)
            {
                //errormessage etc 
            }
            var locations = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={weatherApikey}&q={cityname}");

            JArray o = JArray.Parse(locations);

            for (int i = 0; i < o.Count; i++)
            {
                var locationKey = o[i]["Key"].ToString();
                var city = o[i]["LocalizedName"].ToString();
                var country = o[i]["Country"]["LocalizedName"].ToString();
                var administrativeArea=o[i]["AdministrativeArea"]["LocalizedName"].ToString();

                string location = city + ", " + country + ", " + administrativeArea;

                locationsList.Add(locationKey, location);
            }


            return locationsList;
        }

        public WeatherForDay GetWeatherForDay(string locationkey)  // should just take in the location key 
        {
            WeatherForDay wfd = new WeatherForDay();


            var weatherApikey = getApiKey();
            WebClient w = new WebClient();

            // var locationkey = GetLocations(cityname).ContainsKey(location);
            // locationkey = 335012;
            var weatherData = w.DownloadString($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationkey}?apikey={weatherApikey}&metric=true");

            JObject o = JObject.Parse(weatherData);

            wfd.TempDay = (double)o.SelectToken("DailyForecasts[0].Temperature.Maximum.Value");
            wfd.TempNight = (double)o.SelectToken("DailyForecasts[0].Temperature.Minimum.Value");

            wfd.Date = (DateTime)o.SelectToken("DailyForecasts[0].Date");

            wfd.HeadlineText = (string)o.SelectToken("Headline[0].Text");
            wfd.IconNumberDay = (int)o.SelectToken("DailyForecasts[0].Day.Icon");

            wfd.IconNumbeNight = (int)o.SelectToken("DailyForecasts[0].Night.Icon");


            return wfd;
        }



    }
}
