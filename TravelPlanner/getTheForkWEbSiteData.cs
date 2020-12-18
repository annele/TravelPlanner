using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Utils;
using System.Collections.ObjectModel;

namespace TravelPlanner
{
   public  class getTheForkWEbSiteData
    {

      
        //CityResult cityResult = new CityResult();

        

        public string getUrl(CityResult cityResult)
        {
            string url = "";
            string baseUrl = "https://www.thefork.de/search/?coordinates=";

            string lat = cityResult.Latitude;
            string lon = cityResult.Longitude;

            url = baseUrl + lon + "," + lat;

            return url;
        }


        public ObservableCollection <CafeResult> GetCafeResult(CityResult cityResult)
        {
            var cafeResult = new ObservableCollection<CafeResult>();
            var testURL = getUrl(cityResult);

           // var testURL = getUrl(new CityResult() { Latitude = "48.220778", Longitude = "16.3100205" });
            var wc = new GZipWebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.60");
            wc.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            wc.Headers.Add("Accept-Encoding", "gzip");
            var test = wc.DownloadString(testURL);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(test);

            //   var name = htmlDoc.DocumentNode.Elements("a.css - e71x1w.ejesmtr0");
               var name = htmlDoc.DocumentNode.SelectSingleNode("//a[@class = 'css-1lxw1q9 ejesmtr0']").InnerText;
             var address = htmlDoc.DocumentNode.SelectSingleNode("//p[@class = 'css-axj1nn ejesmtr0']").InnerText;
            var type = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'enrzupw0 css-1ujxl3z ejesmtr0']").InnerText;
            var averagePrice = htmlDoc.DocumentNode.SelectSingleNode("//p[@class = 'css-a7e1wa ejesmtr0']/span[2]").InnerText;
            //var link = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'enrzupw0 css-1ujxl3z ejesmtr0']").InnerText;
            //var type = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'enrzupw0 css-1ujxl3z ejesmtr0']").InnerText;


            //       htmlDoc.DocumentNode.SelectNodes("");

            // Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);

            return cafeResult;
        }
       

        public async void getHttpPage(CityResult cityResul)
        {
            HtmlDocument pageDocument = new HtmlDocument();
            var url = getUrl(cityResul);

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var pageContents = await response.Content.ReadAsStringAsync();

            pageDocument.LoadHtml(pageContents);

            //return pageDocument;
        }
    }
}
