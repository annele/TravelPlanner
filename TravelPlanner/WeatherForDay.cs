using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
   public  class WeatherForDay
    {
        private DateTime date;
        private int iconNumberDay;
        private int iconNumberNight;
        private double tempDay;
        private double tempNight;
        private string clouds;
        private string headlineTexts;

        public string HeadlineText { get; set; }

        public DateTime Date { get; set; }

        public int IconNumbeNight { get; set; }

        public int IconNumberDay { get; set; }
        public  double TempDay { get; set; }

        public double TempNight { get; set; }

        public String Clouds { get; set; }

    }

}
