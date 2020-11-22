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

        WeatherForDay wfd = new WeatherForDay();

        public String getApiKey()

        {
            string filePath = @"..\..\config.txt";
            string weatherApikey = "";
            
            if (File.Exists(filePath))
            {
                string configs = System.IO.File.ReadAllText(filePath);
                weatherApikey = configs.Split('=')[1];

            } else
            {
                throw new FileNotFoundException();
            }
            return weatherApikey;
        }

        public Dictionary<string, string> GetLocations(string cityname)
        {

     
            WebClient w = new WebClient();
            var locationsList = new Dictionary<String, String>();
            
            var weatherApikey = getApiKey();
            var s = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={weatherApikey}&q={cityname}");

            JArray o = JArray.Parse(s);
            //var key = o[0]["Key"].ToString();
            //var city = o[0]["LocalizedName"].ToString();
            // var country = o[0]["Country"]["LocalizedName"].ToString();

            for (int i = 0; i < o.Count; i++)
            {
                var locationKey = o[i]["Key"].ToString();
                var city = o[i]["LocalizedName"].ToString();
                var country = o[i]["Country"]["LocalizedName"].ToString();

                string location = city + " " + country;

                locationsList.Add(location, locationKey);
            }


            return locationsList;
        }

         public  List<string> GetWeatherForDay(string cityname, string location)
         {
             List<string> weatherForDay = new List<string>();
           
            var weatherApikey = getApiKey();

            WebClient w = new WebClient();
            //   var key = getLocations(cityname);
             var locationkey = GetLocations(cityname).ContainsKey(location);
            //var locationkey = 335012;
             var s = w.DownloadString($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationkey}?apikey={weatherApikey}&metric=true");

             JObject o = JObject.Parse(s);
           

             //var temp = o["DailyForecasts"].ToString();
            string temp = (string)o.SelectToken("DailyForecasts[0].Temperature.Value").ToString();

             return weatherForDay;
         }


        
    }
}
