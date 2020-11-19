using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public static class WeatherForToday
    {
        public static DateTime Date;
        public static int IconNumber;
        public static double Temp;
        public static String Clouds;




        // getlocations(string cityname) => dictionary of String-Citoies(Country) - key
        // getWeatherForCity(string cityname) => list of WetherForDay


        public static Dictionary<string, string> GetLocations(string cityname)
        {
            WebClient w = new WebClient();
            var locationsList = new Dictionary<String, String>();
            var APIKEY = "h3Zqp9u0nCYAwzdKpAqLpEMdKACihESd";
            //cityname = "London";
            var s = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={APIKEY}&q={cityname}");

            JArray o = JArray.Parse(s);
            //var key = o[0]["Key"].ToString();
            //var city = o[0]["LocalizedName"].ToString();
           // var country = o[0]["Country"]["LocalizedName"].ToString();
           // string location; 

            // foreach (var bla in o)
            for(int i=0; i< o.Count; i++)
             {
                var key = o[i]["Key"].ToString();
                var city = o[i]["LocalizedName"].ToString();
                var country = o[i]["Country"]["LocalizedName"].ToString();

               string  location = city + " " +country;

                locationsList.Add(key, location);
            }
           

            return locationsList;
        }


        public static List<string> GetWeatherForDay(string cityname)
        {
            List<string> weatherForDay = new List<string>();

            WebClient w = new WebClient();
         //   var key = getLocations(cityname);

           //var s = w.DownloadString($"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{key}");

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
