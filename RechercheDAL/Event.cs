using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class Event
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public long Type { get; set; }
        public DateTime? Date { get; set; }
        public Place EPlace { get; set; }
        public string Adresse { get; set; }
        public Location location { get; set; }


        public Event(string _Id, string _Name, long _Type, DateTime? _Date, Place _EPlace, string _Adresse)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Type = _Type;
            this.Adresse = _Adresse;
            this.Date = _Date;
            this.EPlace = _EPlace;
            try
            {

                this.location = new Location((double)this.EPlace.Latitude.GetValueOrDefault(), (double)10);
            }
            catch (Exception e) { }
        }

    }

}
