using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TravelPlanner
{
    public  class GetWeatherData
    {



        WeatherForDay wfd = new WeatherForDay();

        // getlocations(string cityname) => dictionary of String-Citoies(Country) - key
        // getWeatherForCity(string cityname) => list of WetherForDay


        public  Dictionary<string, string> GetLocations(string cityname)
        {
            WebClient w = new WebClient();
            var locationsList = new Dictionary<String, String>();
            // var APIKEY = "h3Zqp9u0nCYAwzdKpAqLpEMdKACihESd";
            var APIKEY = ConfigurationManager.AppSettings["WEATHERAPIKEY"];
            
            var s = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={APIKEY}&q={cityname}");

            JArray o = JArray.Parse(s);
            //var key = o[0]["Key"].ToString();
            //var city = o[0]["LocalizedName"].ToString();
           // var country = o[0]["Country"]["LocalizedName"].ToString();
         
            for(int i=0; i< o.Count; i++)
             {
                var locationKey = o[i]["Key"].ToString();
                var city = o[i]["LocalizedName"].ToString();
                var country = o[i]["Country"]["LocalizedName"].ToString();

               string  location = city + " " +country;

                locationsList.Add(location, locationKey);
            }
           

            return locationsList;
        }


        /*  public  List<string> GetWeatherForDay(string location)
         {
             List<string> weatherForDay = new List<string>();
             var APIKEY = "h3Zqp9u0nCYAwzdKpAqLpEMdKACihESd";

             WebClient w = new WebClient();
             //   var key = getLocations(cityname);
          //   var locationkey = GetLocations(cityname).ContainsKey(location);

             var s = w.DownloadString($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{locationKey}?apikey={APIKEY}&metric=true");

             JObject o = JObject.Parse(s);

           int temp = o.SelectToken("DailyForecasts[0].")


             return weatherForDay;
         }


         /*   private void button1_Click(object sender, EventArgs e)
            {
                WebClient w = new WebClient();
                var APIKEY = "h3Zqp9u0nCYAwzdKpAqLpEMdKACihESd";
                var city = "vienna";

                var s = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={APIKEY}&q={city}");
                //   var test = s.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });
                JArray o = JArray.Parse(s);
                var key = o[0]["Key"].ToString();

                foreach (var bla in o)
                {
                    var we = new WeatherForDay();
                    we.Clouds = o[0]["Key"].ToString();
                }

            }
        }*/
    }
}
