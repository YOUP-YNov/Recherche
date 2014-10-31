using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;

namespace MvcApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManagerController : Controller
    {
        //Adding the ReIndex action. The action return a redirect to the index view.
        public ActionResult Index()
        {
            return RedirectToAction("Index");
        }

        //Saving connection settings - localhost:9200
        var setting = new ConnectionSettings("localhost", 9200);
        //Initializing new Client
        var client = new ElasticClient(setting);
    }
}
