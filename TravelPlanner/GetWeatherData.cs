using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Collections.ObjectModel;

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

        public ObservableCollection<CityResult> GetLocations(string cityname)
        {


            WebClient w = new WebClient();
            var locationsList = new ObservableCollection<CityResult>();

            var weatherApikey = getApiKey();
            if(weatherApikey == null)
            {
                
            }
            var locations = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={weatherApikey}&q={cityname}");

            JArray o = JArray.Parse(locations);

            for (int i = 0; i < o.Count; i++)
            {
                var locationKey = Convert.ToInt32( o[i]["Key"]);
                var city = o[i]["LocalizedName"].ToString();
                var country = o[i]["Country"]["LocalizedName"].ToString();
                var administrativeArea=o[i]["AdministrativeArea"]["LocalizedName"].ToString();
                var latidude = Convert.ToDouble( o[i]["GeoPosition"]["Latitude"]);
                var longitute = Convert.ToDouble(o[i]["GeoPosition"]["Longitude"]);


                string location = city + ", " + country + ", " + administrativeArea;

                locationsList.Add(new CityResult(locationKey, location, latidude, longitute));
            }


            return locationsList;
        }

        public WeatherForDay GetWeatherFor5Days(int locationkey)  // should just take in the location key 
        {

            WeatherForDay wfd = new WeatherForDay();

            //public WeatherForDay wfd;

            var weatherApikey = getApiKey();
            WebClient w = new WebClient();

            
             //locationkey = 335012;
            var weatherData = w.DownloadString($"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{locationkey}?apikey={weatherApikey}&metric=true");  //change to 15 days 

            JObject o = JObject.Parse(weatherData);
               


            for (int i = 0; i < o.Count; i++)
            {
                wfd.HeadlineText = o["Headline"]["Text"].ToString();
                wfd.TempDay = Convert.ToDouble( o["DailyForecasts"][i]["Temperature"]["Maximum"]["Value"]);
                wfd.TempNight = Convert.ToDouble(  o["DailyForecasts"][i]["Temperature"]["Minimum"]["Value"]);
                wfd.IconNumberDay = Convert.ToInt32(o["DailyForecasts"][i]["Day"]["Icon"]);
                wfd.IconNumbeNight = Convert.ToInt32(o["DailyForecasts"][i]["Night"]["Icon"]);

                //  wfd.Date = Convert.ToDateTime(o.SelectToken("DailyForecasts"+i+".Dai+te")); //hint: DateTime.Parse Funtion.

                // wfd.HeadlineText = (string)o.SelectToken("Headline"+i+".Text");
                //   wfd.IconNumberDay = Convert.ToInt32(o.SelectToken("DailyForecasts"+i+".Day.Icon"));

                //   wfd.IconNumbeNight = Convert.ToInt32(o.SelectToken("DailyForecasts"+i+".Night.Icon"));

            }


            return wfd;
        }



    }
}
