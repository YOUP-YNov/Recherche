using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools;
using RechercheDal;
using Nest;

namespace MvcApplication1.Controllers
{


    public class placesController
    {
        public void AddPlace(Place place)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(place);
        }

        public void RemovePlace(Place place)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Place>(place.Id);
        }

        public void UpdatePlace(Place oldplace, Place newplace)
        {
            RemovePlace(oldplace);
            AddPlace(newplace);
        }

        public IEnumerable<Place> SimpleSearchPlaces(string keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Place>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, keyword)
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
                                x.Town, _Location))
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
