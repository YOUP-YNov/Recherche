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
        public IEnumerable<Profile> get()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            
            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            ISearchResponse<Profile> myListP = Pcontroller.SimpleSearchProfile(nvc["keyword"], nvc["from"], nvc["take"]);
            myReturn.Gprofile = myListP.Documents;
            

            //Search in Blogs
            blogController Bcontroller = new blogController();
            Bcontroller.SimpleSearchBlog(nvc["keyword"], nvc["from"], nvc["take"]);
            Bcontroller.SimpleSearchBlogPost(nvc["keyword"], nvc["from"], nvc["take"]);
            Bcontroller.SimpleSearchBlogComment(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Events
            eventsController Econtroller = new eventsController();
            Econtroller.SimpleSearchEvent(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Places
            placesController PLcontroller = new placesController();
            PLcontroller.SimpleSearchPlace(nvc["keyword"], nvc["from"], nvc["take"]);

            //Search in Forum
            forumController Fcontroller = new forumController();
            Fcontroller.SimpleSearchPostForum(nvc["keyword"], nvc["from"], nvc["take"]);

            return myListP.Documents;

        }
    }
}
