using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class Person
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
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
