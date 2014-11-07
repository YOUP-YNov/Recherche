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
    

    public class ProfilesController : ApiController
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
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            int from = Int32.Parse(nvc["from"]);
            int take = Int32.Parse(nvc["take"]);
            if (from == null) { from = 0; }
            if ((take == null) || (take == 0)) { take = 20; }

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

            ElasticClient client = YoupElasticSearch.InitializeConnection();

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
                                q.Term(p => p.Pseudo, nvc["keyword"]))))
                .Take(20));

            return searchResults.Documents;
        }

    }
}
