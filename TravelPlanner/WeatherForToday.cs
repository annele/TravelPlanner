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


        public static Dictionary<String, String> getLocations(string cityname)
        {
            WebClient w = new WebClient();
            var locationsList = new Dictionary<String, String>();
            var APIKEY = "h3Zqp9u0nCYAwzdKpAqLpEMdKACihESd";
            cityname = "London";
            var s = w.DownloadString($"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={APIKEY}&q={cityname}");

            JArray o = JArray.Parse(s);
            var key = o[0]["Key"].ToString();
            var city = o[0]["LocalizedName"].ToString();
            var country = o[1]["LocalizedName"].ToString();
            foreach (var bla in o)
            {
               // var we = new WeatherForDay();
                Clouds = o[0]["Key"].ToString();
            }
            Console.WriteLine(key, city, country);

            return locationsList;
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
