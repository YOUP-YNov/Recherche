using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;

namespace MvcApplication1.Controllers
{
    public class Place
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Place(string _Id, string _Name, string _Location)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Location = _Location;
        }
    }



    public class PlacesController : Controller
    {
        //
        // GET: /Places/

        public void AddPlace(ElasticClient client, Place place)
        {
            var index = client.Index(place);
        }

        public void SimpleSearchPlace(ElasticClient client, string Keyword)
        {
            //Search
            var searchResults = client.Search<Place>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, Keyword)
                )
            );
        }

        public void AdvancedSearchPlace(ElasticClient client, string Keyword, string Location)
        {
            //Search
            var searchResults = client.Search<Place>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
                .Term(p => p.Name, Keyword)
                )
            .Query(qd => qd
                .Filtered(cs => cs
                    .Query(q => q.MatchAll())
                    .Filter(f => f.MatchAll())
                )
            )
            );
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
