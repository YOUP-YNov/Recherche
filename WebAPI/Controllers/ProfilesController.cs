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

        public void AddProfile(ElasticClient client)
        {
            //Add Flavien
            var PersonTest = new Profile();
            PersonTest.Id = "2";
            PersonTest.Firstname = "Antoine";
            PersonTest.Lastname = "Geslin";
            var index = client.Index(PersonTest);

        }

        public void SearchProfile(ElasticClient client)
        {
            //Search
            var searchResults = client.Search<Profile>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Firstname, "Flavien")
                )
            );
        }
    }
    

    public class ProfilesController : Controller
    {
        //
        // GET: /Profiles/

        public ActionResult Index()
        {
            return View();
        }

    }
}
