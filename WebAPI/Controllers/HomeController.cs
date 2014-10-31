using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;



namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {        
        //Method InitializeConnection : Explicit
        public void InitializeConnection(){

            //Saving Node
            var node = new Uri("http://localhost:9200");
            //Saving Settings
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "Youp"
            );
            //Starting Client
            var client = new ElasticClient(settings);

            var PersonTest = new Person();
            PersonTest.Id = "1";
            PersonTest.Firstname = "Flavien";
            PersonTest.Lastname = "Geslin";

            var index = client.IndexAsync(PersonTest);
        }
   
        //Method ReIndex : Explicit
        //Adding the ReIndex action. The action return a redirect to the index view.
        public ActionResult Index()
        {
           InitializeConnection();
           return View();
        }

    }
}
