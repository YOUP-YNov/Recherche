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

        public ISearchResponse<Place> SimpleSearchPlace(string keyword, int from, int take)
        {
          //  IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Place>(s => s
            .From(from)
            .Take(take)
            .Query(q => 
                q.Term(p => p.Name, keyword)
                || q.Term(p => p.Town, keyword)
                )
            );
            
            return searchResults;
        }

        public ISearchResponse<Place> AdvancedSearchPlace(string from, string take, string keyword, string _Location)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();

            IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            var searchResults = client.Search<Place>(body =>
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Town, _Location))
                    .Query(q =>
                        q.Term(p => p.Name, keyword)
                        )
            .From(ParsRtesR.Intfrom)
            .Take(ParsRtesR.Inttake));

            return searchResults;
        }

        public void SearchPlacesAround(ElasticClient client) { }

    }
}
