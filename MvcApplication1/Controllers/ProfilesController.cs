using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using System.Web.Http;
using Tools;
using RechercheDal;

namespace MvcApplication1.Controllers
{

    
    public class ProfilesController : ApiController
    {
        //
        // GET: /Profiles/

        public void AddProfile(Profile profile)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(profile);
        }

        public void RemoveProfile(Profile profile)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete(new DeleteRequest(profile.Id, "profiles", "1"));
        }

        public IEnumerable<Profile> GetSimpleSearchProfile()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            int from, take;

            //Test parameters FROM & SET if null
            if (nvc["from"] == null) { from = 0; }
            //Else GET parameter From
            else { from = Int32.Parse(nvc["from"]); }
            //Test parameters TAKE & SET if null
            if ((nvc["take"] == null) || (Int32.Parse(nvc["take"]) == 0)) { take = 20; }
            //Else GET parameters From && TAKE from URL
            else { take = Int32.Parse(nvc["take"]); }

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Profile>(s => s
            .Query(q => q
                .Term(p => p.Firstname, nvc["keyword"])
                )
                .From(from)
                .Take(take)

            // Add OR LName - FName
            );

            return searchResults.Documents;
        }

        public IEnumerable<Profile> GetAdvancedSearchProfile()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            int from, take;

            //Test parameters FROM & SET if null
            if (nvc["from"] == null) { from = 0; }
            //Else GET parameter From
            else { from = Int32.Parse(nvc["from"]); }
            //Test parameters TAKE & SET if null
            if ((nvc["take"] == null) || (Int32.Parse(nvc["take"]) == 0)) { take = 20; }
            //Else GET parameters From && TAKE from URL
            else { take = Int32.Parse(nvc["take"]); }

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            // Solution - Pas trop perf
            //Search per location
            var searchResults = client.Search<Profile>(body => 
                body.Filter(filter =>
                    filter.Term(x =>
                        x.Age, nvc["age"]))
                    .Query(q => q
                        .Term(p => p.Firstname, nvc["keyword"])  
                        )
            .Take(100));

            /*
            //recherche avancée if all parameters != null
            var searchResults = client.Search<Profile>(body =>
                body.Query(query =>
                    query.ConstantScore(csq =>
                        csq.Filter(filter =>
                                filter.Term(x =>
                                    x.Lastname, nvc["lastname"]))
                            .Filter(filter =>
                                filter.Term(x =>
                                    x.Firstname, nvc["firstname"]))
                            .Filter(filter =>
                                filter.Term(x =>
                                    x.Age, nvc["age"]))
                           .Query(q =>
                                q.Term(p => p.Firstname, nvc["keyword"]))))
                .Take(take)
                .From(from));
            */

            return searchResults.Documents;
        }

    }
}
