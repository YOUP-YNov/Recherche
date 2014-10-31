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
            //Saving node 
            //Adress node differente exemple : http://mynode.example.com:8082/apiKey
            var node = new Uri("http://mynode.example.com:8082/apiKey");
            var connectionPool = new SniffingConnectionPool(new[] { node });
            //Saving connection settings - localhost:9200
            var config = new ConnectionConfiguration(connectionPool);
            //Initializing new Client
            var client = new ElasticsearchClient(config);

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
