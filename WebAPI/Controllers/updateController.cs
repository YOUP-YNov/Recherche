using RechercheDal;
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
    public class updateController : ApiController
    {
        public bool get_blog(string id="", string author="", string category="")
        {
            Blog XNewBlog = new Blog(id, author, category);
            blogController controller = new blogController();
            controller.UpdateBlog(XNewBlog);
            return true;
        }

        public bool get_blogpost(string id="", string content="", string author="", string title="")
        {
            BlogPost XNewBlogPost = new BlogPost(id, content, author, title);
            blogController controller = new blogController();
            controller.UpdateBlogPost(XNewBlogPost);
            return true;
        }

        public bool get_blogpostcomment(string id="", string content="", string author="")
        {
            BlogPostComment XNewBlogPostComment = new BlogPostComment(id, content, author);
            blogController controller = new blogController();
            controller.UpdateBlogPostComment(XNewBlogPostComment);
            return true;
        }

        public bool get_event(string idP = "", string nameP = "", string town = "", decimal? latitude = 0, decimal? longitude = 0,
            string idE = "", string nameE = "", long type = 0L, DateTime date = new DateTime(), string adresse = "")
        {
            Place XNewPlace = new Place(idP, nameP, town, latitude, longitude);
            Event XNewEvent = new Event(idE, nameE, type, date, XNewPlace, adresse);
            eventsController controller = new eventsController();
            controller.UpdateEvent(XNewEvent);
            return true;
        }

        public bool get_place(string id="", string name="", string town="", decimal? latitude=0, decimal? longitude=0)
        {
            Place XNewPlace = new Place(id, name, town, latitude, longitude);
            placesController controller = new placesController();
            controller.UpdatePlace(XNewPlace);
            return true;
        }

        public bool get_profile(string id = "", string firstname = "", string lastname = "", string pseudo = "", string activity = "",
            int age = 0, bool sex = true, string town = "")
        {
            Profile XNewProfile = new Profile(id, firstname, lastname, pseudo, activity, age, sex, town);
            profilesController controller = new profilesController();
            controller.UpdateProfile(XNewProfile);
            return true;
        }

        public bool get_postforum(string id = "", string board = "", string content = "", DateTime date = new DateTime(), string author = "")
        {
            PostForum XNewPostForum = new PostForum(id, board, content, date, author);
            forumController controller = new forumController();
            controller.UpdatePostForum(XNewPostForum);
            return true;
        }
    }
}
