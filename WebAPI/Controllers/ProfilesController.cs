using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;

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
    

    public class ProfilesController : Controller
    {
        //
        // GET: /Profiles/

        public void AddProfile(ElasticClient client, Profile profile)
        {
            var index = client.Index(profile);
        }

        public void SimpleSearchProfile(ElasticClient client, string Keyword)
        {
            //Search
            var searchResults = client.Search<Profile>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Pseudo, Keyword)
                )
            // Add OR LName - FName
            );
        }

        public void AdvancedSearchProfile(ElasticClient client, string Keyword, string FName, string LName, int Age)
        {
            //TODO filtres multiples
            var searchResults = client.Search<Profile>(body =>
                body.Query(query =>
                    query.ConstantScore(csq =>
                        csq.Filter(filter =>
                            filter.Term(x =>
                                x.Lastname, LName))
                           .Query(q =>
                                q.Term(p => p.Pseudo, Keyword))))
                .Take(100));
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
