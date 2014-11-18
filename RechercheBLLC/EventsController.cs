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
        }

        public void RemoveEvent(Event _event)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Event>(_event.Id);
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

        public ISearchResponse<Event> AdvancedSearchEvent(string from, string take, string keyword, string type, string town, string date)
        {

            IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            DateParsRTestR ParsRtesR2 = new DateParsRTestR(date);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Event>(body =>
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Date, ParsRtesR2.StrDate) //filtre date
                    && filter.Term(x =>
                        x.EPlace.Town, town) //filtre ville
                    && filter.Term(x =>
                        x.Type, type)) //filtre type
                    .Query(q =>
                        q.QueryString(qs => qs
                        .OnFields(p => p.Name, p => p.Adresse) //keyword pour name et adresse
                        .Query(keyword)
                        ))
            .From(ParsRtesR.Intfrom)
            .Take(ParsRtesR.Inttake));

            return searchResults;
        }

    }
}
