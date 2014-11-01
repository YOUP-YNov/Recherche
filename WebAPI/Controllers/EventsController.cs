using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;

namespace MvcApplication1.Controllers
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public Place EPlace { get; set; }
        public string Adresse { get; set; }
        public string Timeslot { get; set; }

        public Event(string _Id, string _Name, string _Type, DateTime _Date, Place _EPlace, string _Adresse, string _Timeslot)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Type = _Type;
            this.Adresse = _Adresse;
            this.Date = _Date;
            this.EPlace = _EPlace;
            this.Timeslot = _Timeslot;
        }

    }

    public class EventsController : Controller
    {
        //
        // GET: /Events/
        public void AddPlace(ElasticClient client, Event _event)
        {
            var index = client.Index(_event);
        }

        public void SimpleSearchPlace(ElasticClient client, string Keyword)
        {
            //Search
            var searchResults = client.Search<Event>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, Keyword)
                )
            );
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
