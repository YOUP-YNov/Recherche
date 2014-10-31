using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using Elasticsearch.Net;
using Elasticsearch.Net.ConnectionPool;
using Elasticsearch.Net.Connection;

namespace MvcApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManagerController : Controller
    {

        
        //Method InitializeConnection : Explicit
        public void InitializeConnection() {

            //Saving Node
            var node = new Uri("http://localhost:9200");

            //Saving Settings
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "my-application"
            );

            //Starting Client
            var client = new ElasticClient(settings);


        }


        //Method ReIndex : Explicit
        //Adding the ReIndex action. The action return a redirect to the index view.
        public ActionResult Index()
        {
            InitializeConnection();
            //Indexer

            //Return complete
            return RedirectToAction("Index");
        }


        

    }
}
