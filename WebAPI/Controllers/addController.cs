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
    public class addController : ApiController
    {

        public bool get_blog(string id = "", string content = "", string category = "")
        {
            Blog XBlog = new Blog(id, content, category);
            blogController controller = new blogController();
            controller.AddBlog(XBlog);
            return true;
        }

        public bool get_blogpost(string id = "", string content = "", string author = "", string title ="")
        {
            BlogPost XBlogPost = new BlogPost(id, content, author, title);
            blogController controller = new blogController();
            controller.AddBlogPost(XBlogPost);
            return true;
        }

        public bool get_blogpostcomment(string id="", string content="", string author="")
        {
            BlogPostComment XBlogPostComment = new BlogPostComment(id, content, author);
            blogController controller = new blogController();
            controller.AddBlogPostComment(XBlogPostComment);
            return true;
        }

        public bool get_event(string idP="", string nameP="", string town="", decimal latitude=0, decimal longitude=0,
            string idE="", string nameE="", long type=0L, DateTime date = new DateTime(), string adresse="")
        {
            Place XPlace = new Place(idP, nameP, town, latitude, longitude);
            Event XEvent = new Event(idE, nameE, type, date, XPlace, adresse);
            eventsController controller = new eventsController();
            controller.AddEvent(XEvent);
            return true;
        }

        public bool get_place(string id = "", string name = "", string town = "", decimal latitude = 0, decimal longitude = 0)
        {
            Place XPlace = new Place(id, name, town, latitude, longitude);
            placesController controller = new placesController();
            controller.AddPlace(XPlace);
            return true;
        }

        public bool get_profile(string id="", string firstname="", string lastname="", string pseudo="", string activity="",
            int age=0, bool sex=true, string town="")
        {
            Profile XProfile = new Profile(id, firstname, lastname, pseudo, activity, age, sex, town);
            profilesController controller = new profilesController();
            controller.AddProfile(XProfile);
            return true;
        }

        public bool get_postforum(string id="", string board="", string content="", DateTime date = new DateTime(), string author="")
        {
            PostForum XPostForum = new PostForum(id, board, content, date, author);
            forumController controller = new forumController();
            controller.AddPostForum(XPostForum);
            return true;
        }
    }
}
