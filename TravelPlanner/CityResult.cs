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

        public CityResult (int id, string description)
        {
            this._id = id;
            this._description = description;
        }

        public override string ToString()
        {
            return this.Description;
        }

    }
}
