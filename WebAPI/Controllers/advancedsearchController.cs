using RechercheDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ControllersBll;
using Nest;

namespace MvcApplication1.Controllers
{
    public class advancedsearchController : ApiController
    {
        public GenericResponse get_place(Place XPlace)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();

            //Search in Places
            placesController Pcontroller = new placesController();
            myReturn.Gplace = Pcontroller.AdvancedSearchPlace(nvc["from"], nvc["take"], nvc["keyword"], nvc["town"]).Hits;
            return myReturn;
        }

        public GenericResponse get_blog(Blog XBlog)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            blogController Pcontroller = new blogController();
            
            GenericResponse myReturn = new GenericResponse();
            return myReturn;

        }

        ///
        public GenericResponse get_event(Event XEvent)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            //Search in Forum
            eventsController Pcontroller = new eventsController();
            myReturn.Gevent = Pcontroller.AdvancedSearchEvent(nvc["from"], nvc["take"], nvc["keyword"], nvc["type"], nvc["town"], nvc["date"]).Hits;
             
            return myReturn;
        }

        public GenericResponse get_profile(Profile XProfile)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            myReturn.Gprofile = Pcontroller.AdvancedSearchProfile(nvc["from"], nvc["take"], nvc["keyword"], nvc["age"], nvc["town"]).Hits;
             
            return myReturn;
        }

        public GenericResponse get_postforum(PostForum XPostForum)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            //Search in Profiles
            forumController Pcontroller = new forumController();
            myReturn.Gpostforum = Pcontroller.AdvancedSearchForum(nvc["from"], nvc["take"], nvc["keyword"], nvc["author"], nvc["board"], nvc["date"]).Hits;

            return myReturn;
        }
    }
}
