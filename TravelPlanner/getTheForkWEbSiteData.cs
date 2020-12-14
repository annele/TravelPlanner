using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
   public  class getTheForkWEbSiteData
    {

      
        CityResult cityResult = new CityResult();

        

        public string getUrl()
        {
            string url = "";
            string baseUrl = "https://www.thefork.de/search/?coordinates=";

            string lat = cityResult.Latitude;
            string lon = cityResult.Longitude;

            url = baseUrl + lat + "," + lon;

            return url;
        }


        public async void getHttüPage(string url)
        {
            HtmlDocument pageDocument = new HtmlDocument();
            url = getUrl();

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var pageContents = await response.Content.ReadAsStringAsync();

            pageDocument.LoadHtml(pageContents);

            //return pageDocument;
        }
    }
}
