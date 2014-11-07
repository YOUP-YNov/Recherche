using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class Profile
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pseudo { get; set; }
        public string Activity { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }

        public Profile(string _Id, string _Firstname, string _Lastname, string _Pseudo, string _Activity, int _Age, bool _Sex)
        {
            this.Id = _Id;
            this.Firstname = _Firstname;
            this.Lastname = _Lastname;
            this.Pseudo = _Pseudo;
            this.Activity = _Activity;
            this.Age = _Age;
            this.Sex = _Sex;
        }

    }
    

    public class profilesController : ApiController
    {
        //
        // GET: /Profiles/

        public void AddProfile(Profile profile)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(profile);
        }

        public IEnumerable<Profile> GetSimpleSearchProfile()
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
          
            var searchResults = client.Search<Profile>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Pseudo, nvc["keyword"])
                )
            // Add OR LName - FName
            );

            return searchResults.Documents;
        }

        public void AdvancedSearchProfile(string Keyword, string FName, string LName, int Age)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //recherche avancée if all parameters != null
            var searchResults = client.Search<Profile>(body =>
                body.Query(query =>
                    query.ConstantScore(csq =>
                        csq.Filter(filter =>
                                filter.Term(x =>
                                    x.Lastname, LName))
                            .Filter(filter =>
                                filter.Term(x =>
                                    x.Firstname, FName))
                            .Filter(filter =>
                                filter.Term(x =>
                                    x.Age, Age))
                           .Query(q =>
                                q.Term(p => p.Pseudo, Keyword))))
                .Take(20));
        }

    }
}
