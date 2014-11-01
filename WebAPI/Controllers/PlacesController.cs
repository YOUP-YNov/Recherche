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

        public void Place(string _Id, string _Name, string _Location)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Location = _Location;
        }



    public class PlacesController : Controller
    {
        //
        // GET: /Places/

        public void AddPlace(ElasticClient client, Place place)
        {
            var index = client.Index(place);
        }

        public void SearchProfile(ElasticClient client, string Keyword)
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

        public ActionResult Index()
        {
            return View();
        }

    }
}
