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

        public void UpdateEvent(Event _oldevent, Event _newevent)
        {
            RemoveEvent(_oldevent);
            AddEvent(_newevent);
        }

        public ISearchResponse<Event> SimpleSearchEvent(string Keyword, int from, int take)
        {
         //   IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Event>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.Term(p => p.Name, Keyword)
                || q.Term(p => p.Adresse, Keyword)
                )
            );

            return searchResults;
        }

        public ISearchResponse<Event> AdvancedSearchEvent(string from, string take, string Keyword, string Type, string where, string Date)
        {

            IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            DateParsRTestR ParsRtesR2 = new DateParsRTestR(Date);



            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //advanced search all parameters
            var searchResults = client.Search<Event>(body =>
            body.Query(query =>
                query.ConstantScore(csq =>
                    csq.Filter(filter =>
                    filter.Term(x =>
                        x.EPlace.Name, where)
                    && filter.Term(x =>
                        x.Date, ParsRtesR2.StrDate))
                       .Query(q =>
                            q.Term(p => p.Name, Keyword))))
            .From(ParsRtesR.Intfrom)
            .Take(ParsRtesR.Inttake));

            return searchResults;
        }

    }
}
