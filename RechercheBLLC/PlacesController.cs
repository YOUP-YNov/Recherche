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

        public void RemovePlace(string id)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Place>(id);
        }

        public void UpdatePlace(Place newplace)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<Place, Place>(u => u
                .Index("youp")
                .Id(newplace.Id)
                .Doc(newplace)
             );
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
                q.QueryString(qs => qs
                .OnFields(p => p.Name, p => p.Town)
                .Query(keyword)
                )));
            
            return searchResults;
        }

        public ISearchResponse<Place> AdvancedSearchPlace(int from, int take, string keyword, string _Location)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();

          //  IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            var searchResults = client.Search<Place>(body =>
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Town, _Location))
                    .Query(q =>
                        q.QueryString(qs => qs
                        .OnFields(p => p.Name)
                        .Query(keyword)
                        ))
            .From(from)
            .Take(take));

            return searchResults;
        }

        public void SearchPlacesAround(ElasticClient client) { }

    }
}
