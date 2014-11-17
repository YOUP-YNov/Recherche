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

        public GenericResponse get(string keyword, int from = 0, int take=20)
        {
          //  var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            GenericResponse myReturn = new GenericResponse();
            
            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            myReturn.Gprofile = Pcontroller.SimpleSearchProfile(keyword, from, take).Hits;            

            //Search in Blogs
            blogController Bcontroller = new blogController();
            myReturn.Gblog = Bcontroller.SimpleSearchBlog(keyword, from, take).Hits;
            myReturn.Gblogpost = Bcontroller.SimpleSearchBlogPost(keyword, from, take).Hits;
            myReturn.Gblogpostcomment = Bcontroller.SimpleSearchBlogComment(keyword, from, take).Hits;
            
            //Search in Events
            eventsController Econtroller = new eventsController();
            myReturn.Gevent = Econtroller.SimpleSearchEvent(keyword, from, take).Hits;

            //Search in Places
            placesController PLcontroller = new placesController();
            myReturn.Gplace = PLcontroller.SimpleSearchPlace(keyword, from, take).Hits;

            //Search in Forum
            forumController Fcontroller = new forumController();
            myReturn.Gpostforum = Fcontroller.SimpleSearchPostForum(keyword, from, take).Hits;

            return myReturn;

        }
    }
}
