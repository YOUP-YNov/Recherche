using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ControllersBll;

namespace MvcApplication1.Controllers
{
    public class searchController : ApiController
    {
        public bool get()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            Pcontroller.SimpleSearchProfile(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Blogs
            blogController Bcontroller = new blogController();
            Bcontroller.SimpleSearchBlog(nvc["keyword"], nvc["from"], nvc["take"]);
            Bcontroller.SimpleSearchBlogPost(nvc["keyword"], nvc["from"], nvc["take"]);
            Bcontroller.SimpleSearchBlogComment(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Places
            eventsController Econtroller = new eventsController();
            Econtroller.SimpleSearchEvent(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Events
            placesController PLcontroller = new placesController();
            PLcontroller.SimpleSearchPlace(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Forum
            forumController Fcontroller = new forumController();
            Fcontroller.SimpleSearchPostForum(nvc["keyword"], nvc["from"], nvc["take"]);

            return true;
        }
    }
}
