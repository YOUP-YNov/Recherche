using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using RechercheDal;
using ControllersBll;

namespace MvcApplication1.Controllers
{
    public class removeController : ApiController
    {
        public bool get_blog()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            Blog XBlog = new Blog(nvc["id"], nvc["content"], nvc["category"]);
            blogController controller = new blogController();
            controller.RemoveBlog(XBlog);
            return true;
        }

        public bool get_blogpost()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            BlogPost XBlogPost = new BlogPost(nvc["id"], nvc["content"], nvc["author"], nvc["title"]);
            blogController controller = new blogController();
            controller.RemoveBlogPost(XBlogPost);
            return true;
        }

        public bool get_blogpostcomment()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            BlogPostComment XBlogPostComment = new BlogPostComment(nvc["id"], nvc["content"], nvc["author"]);
            blogController controller = new blogController();
            controller.RemoveBlogPostComment(XBlogPostComment);
            return true;
        }

        public bool get_event()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            decimal? latitude = decimal.Parse(nvc["latitude"]);
            decimal? longitude = decimal.Parse(nvc["longitude"]);
            Place XPlace = new Place(nvc["id"], nvc["name"], nvc["town"], latitude, longitude);
            Event XEvent = new Event(nvc["id"], nvc["name"], long.Parse(nvc["type"]), DateTime.Parse(nvc["date"]), XPlace, nvc["adresse"]);
            eventsController controller = new eventsController();
            controller.RemoveEvent(XEvent);
            return true;
        }

        public bool get_place()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            decimal? latitude = decimal.Parse(nvc["latitude"]);
            decimal? longitude = decimal.Parse(nvc["longitude"]);
            Place XPlace = new Place(nvc["id"], nvc["name"], nvc["town"], latitude, longitude);
            placesController controller = new placesController();
            controller.RemovePlace(XPlace);
            return true;
        }

        public bool get_profile()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            Profile XProfile = new Profile(nvc["id"], nvc["firstname"], nvc["lastName"], nvc["pseudo"], nvc["activity"], Int32.Parse(nvc["age"]), bool.Parse(nvc["sex"]), nvc["town"]);
            profilesController controller = new profilesController();
            controller.RemoveProfile(XProfile);
            return true;
        }

        public bool get_postforum()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            PostForum XPostForum = new PostForum(nvc["id"], nvc["board"], nvc["content"], DateTime.Parse(nvc["date"]), nvc["author"]);
            forumController controller = new forumController();
            controller.RemovePostForum(XPostForum);
            return true;
        }
    }
}
