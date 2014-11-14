using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public Place(string _Id, string _Name, string _Town, decimal? _Latitude, decimal? _Longitude)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Town = _Town;
            this.Latitude = _Latitude;
            this.Longitude = _Longitude;
        }
    }
}
