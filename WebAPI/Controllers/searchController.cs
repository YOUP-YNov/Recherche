using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ControllersBll;
using RechercheDal;
using Nest;

namespace MvcApplication1.Controllers
{
    public class searchController : ApiController
    {
        public GenericResponse get()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            
            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            myReturn.Gprofile = Pcontroller.SimpleSearchProfile(nvc["keyword"], nvc["from"], nvc["take"]).Hits;            

            //Search in Blogs
            blogController Bcontroller = new blogController();
            myReturn.Gblog = Bcontroller.SimpleSearchBlog(nvc["keyword"], nvc["from"], nvc["take"]).Hits;
            myReturn.Gblogpost = Bcontroller.SimpleSearchBlogPost(nvc["keyword"], nvc["from"], nvc["take"]).Hits;
            myReturn.Gblogpostcomment = Bcontroller.SimpleSearchBlogComment(nvc["keyword"], nvc["from"], nvc["take"]).Hits;
            

            //Search in Events
            eventsController Econtroller = new eventsController();
            myReturn.Gevent = Econtroller.SimpleSearchEvent(nvc["keyword"], nvc["from"], nvc["take"]).Hits;

            //Search in Places
            placesController PLcontroller = new placesController();
            myReturn.Gplace = PLcontroller.SimpleSearchPlace(nvc["keyword"], nvc["from"], nvc["take"]).Hits;

            //Search in Forum
            forumController Fcontroller = new forumController();
            myReturn.Gpostforum = Fcontroller.SimpleSearchPostForum(nvc["keyword"], nvc["from"], nvc["take"]).Hits;

            return myReturn;

        }
    }
}
