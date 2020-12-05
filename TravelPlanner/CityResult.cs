using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner
{
    public class CityResult
    {

        private int _id;
        private string _description;

        private double _latitude;
        private double _longitude;

        public double Longitude { 
        
            get { return _longitude; }
            set { value = _latitude; }
        }

        public double Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }


        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public CityResult (int id, string description, double longitude, double latitude)
        {
            this._id = id;
            this._description = description;
            this._latitude = latitude;
            this._longitude = longitude;
        }
        public CityResult ()
        {

        }

        public override string ToString()
        {
            return this.Description;
        }

    }
}
