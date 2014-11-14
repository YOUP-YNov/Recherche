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
            myReturn.Gplace = Pcontroller.AdvancedSearchPlace(nvc["from"], nvc["take"], nvc["keyword"], nvc["town"]).Documents;
            return myReturn;
        }

        public bool _blog(Blog XBlog)
        {
            return true;
        }

        public bool _blogpost(BlogPost XBlogPost)
        {
            return true;
        }

        public bool _blogpostcomment(BlogPostComment XBlogPostComment)
        {
            return true;
        }

        public bool _event(Event XEvent)
        {
            return true;
        }

        public GenericResponse get_profile(Profile XProfile)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            myReturn.Gprofile = Pcontroller.AdvancedSearchProfile(nvc["from"], nvc["take"], nvc["keyword"], nvc["age"], nvc["pseudo"]).Documents;

            return myReturn;
        }

        public GenericResponse _postforum(PostForum XPostForum)
        {
            //Url parser
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            //Search in Profiles
            forumController Pcontroller = new forumController();
            myReturn.Gpostforum = Pcontroller.AdvancedSearchForum(nvc["from"], nvc["take"], nvc["keyword"], nvc["author"], nvc["board"], nvc["date"]).Documents;

            return myReturn;
        }
    }
}
