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
            client.Delete(new DeleteRequest(_event.Id, "events", "1"));
        }

        public void UpdateEvent(Event _oldevent, Event _newevent)
        {
            RemoveEvent(_oldevent);
            AddEvent(_newevent);
        }

        public void SimpleSearchEvent(string Keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //Search
            var searchResults = client.Search<Event>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, Keyword)
                )
            );
        }

        public void AdvancedSearchEvent(string Keyword, string Type, string Where, DateTime Date)
        {

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //advanced search all parameters
            var searchResults = client.Search<Event>(body =>
            body.Query(query =>
                query.ConstantScore(csq =>
                    csq.Filter(filter =>
                            filter.Term(x =>
                                x.Date, Date))
                        .Filter(filter =>
                            filter.Term(x =>
                                x.EPlace.Name, Where))
                        .Filter(filter =>
                            filter.Term(x =>
                                x.Type, Type))
                       .Query(q =>
                            q.Term(p => p.Name, Keyword))))
            .Take(20));
        }

    }
}
