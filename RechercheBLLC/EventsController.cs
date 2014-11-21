using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tools;
using RechercheDal;
using Nest;

namespace MvcApplication1.Controllers
{


    public class eventsController
    {
        //
        // GET: /Events/
        public void AddEvent(Event _event)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(_event);
            /*
            try
            {
                client.CreateIndex(s => s
                    .AddMapping<Event>(f => f
                        .MapFromAttributes()
                        .Properties(p => p
                            .GeoPoint(g => g.Name(n => n.location).IndexLatLon()))));
            }
            catch (Exception e) { }*/
        }

        public void RemoveEvent(string id)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Event>(id);
        }

        public void UpdateEvent(Event _newevent)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<Event, Event>(u => u
                .Index("youp")
                .Id(_newevent.Id)
                .Doc(_newevent)
             );
        }

        public ISearchResponse<Event> SimpleSearchEvent(string keyword, int from, int take)
        {
         //   IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Event>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.QueryString(qs => qs
                .OnFields(p => p.Name, p => p.Adresse)
                .Query(keyword)
                )))
            ;

            return searchResults;
        }

        public ISearchResponse<Event> AdvancedSearchEvent(int from, int take, string keyword, string type, string town, DateTime? date)
        {

           // IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

           // DateParsRTestR ParsRtesR2 = new DateParsRTestR(date);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Event>(body =>
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Date, date) //filtre date
                    && filter.Term(x =>
                        x.EPlace.Town, town) //filtre ville
                    && filter.Term(x =>
                        x.Type, type)) //filtre type
                    .Query(q =>
                        q.QueryString(qs => qs
                        .OnFields(p => p.Name, p => p.Adresse) //keyword pour name et adresse
                        .Query(keyword)
                        ))
            .From(from)
            .Take(take));

            return searchResults;
        }

        public ISearchResponse<Event> searchCloseEvents(double latitude, double longitude)
        {

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //search close events
            var searchResults = client.Search<Event>(s => s
                .Filter(f => f
                    .GeoDistance(c => c.location, d => d.Distance(20, GeoUnit.Kilometers).Location(latitude, longitude)))
                .Query(q => q
                    .MatchAll())
                .From(0)
                .Take(20));

            return searchResults;
        }
        
    }
}
