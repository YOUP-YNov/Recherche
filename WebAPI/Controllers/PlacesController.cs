using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using System.Web.Http;
using Newtonsoft.Json;

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



    public class placesController : ApiController
    {
        public void AddPlace(Place place)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(place);
        }

        public IEnumerable<Place> SimpleSearchPlaces()
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            //Search
            var searchResults = client.Search<Place>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, nvc["keyword"])
                )
            );
            
            return searchResults.Documents;


          /*  Assert.NotNull(result);
            Assert.True(result.Success);
            Assert.IsNotEmpty(result.Result);*/
        }

        public void AdvancedSearchPlace(string Keyword, string _Location)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();

            /* Solution 1 - Pas trop perf
            //Search per location
            var searchResults = client.Search<Place>(body => 
                body.Filter(filter =>
                    filter.Term(x => 
                        x.Location, _Location))
                    .Query(q => q
                        .Term(p => p.Name, Keyword)  
                        )
            .Take(100));*/

            //Solution 2 - Plus perf
            var searchResults = client.Search<Place>(body =>
                body.Query(query =>
                    query.ConstantScore(csq => 
                        csq.Filter(filter =>
                            filter.Term(x =>
                                x.Location, _Location))
                           .Query(q =>
                                q.Term(p => p.Name, Keyword))))
                .Take(20));

             /* Exemple utilisation en stockage
             **var PlacesInLocation = new CollectionDePlaces
             **{
                Name = Location
             **  Places = searchResults.Documents.ToList()};
             }*/
        }

        public void SearchPlacesAround(ElasticClient client) { }

    }
}
