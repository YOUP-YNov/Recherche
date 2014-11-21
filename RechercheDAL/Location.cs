using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class Location
    {
           public double slatitude;
           public double slongitude;

           public Location(double latitude, double longitude)
           {
               this.slatitude = latitude;
               this.slongitude = longitude;

           }
    }
}
