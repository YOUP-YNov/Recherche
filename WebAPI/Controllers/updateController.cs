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
        /// <summary>
        /// Met à jour un blog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool get_blog(string id="", string content="", string category="")
        {
            Blog XNewBlog = new Blog(id, content, category);
            blogController controller = new blogController();
            controller.UpdateBlog(XNewBlog);
            return true;
        }

        /// <summary>
        /// Met à jour un blogpost
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool get_blogpost(string id="", string content="", string author="", string title="")
        {
            BlogPost XNewBlogPost = new BlogPost(id, content, author, title);
            blogController controller = new blogController();
            controller.UpdateBlogPost(XNewBlogPost);
            return true;
        }

        /// <summary>
        /// Met à jour un blogpostcomment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public bool get_blogpostcomment(string id="", string content="", string author="")
        {
            BlogPostComment XNewBlogPostComment = new BlogPostComment(id, content, author);
            blogController controller = new blogController();
            controller.UpdateBlogPostComment(XNewBlogPostComment);
            return true;
        }

        /// <summary>
        /// Met à jour un event
        /// </summary>
        /// <param name="idP"></param>
        /// <param name="nameP"></param>
        /// <param name="town"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="idE"></param>
        /// <param name="nameE"></param>
        /// <param name="type"></param>
        /// <param name="date"></param>
        /// <param name="adresse"></param>
        /// <returns></returns>
        public bool get_event(string idP = "", string nameP = "", string town = "", decimal? latitude = 0, decimal? longitude = 0,
            string idE = "", string nameE = "", long type = 0L, DateTime date = new DateTime(), string adresse = "")
        {
            Place XNewPlace = new Place(idP, nameP, town, latitude, longitude);
            Event XNewEvent = new Event(idE, nameE, type, date, XNewPlace, adresse);
            eventsController controller = new eventsController();
            controller.UpdateEvent(XNewEvent);
            return true;
        }

        /// <summary>
        /// Met à jour un lieu
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="town"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public bool get_place(string id="", string name="", string town="", decimal? latitude=0, decimal? longitude=0)
        {
            Place XNewPlace = new Place(id, name, town, latitude, longitude);
            placesController controller = new placesController();
            controller.UpdatePlace(XNewPlace);
            return true;
        }

        /// <summary>
        /// Met à jour un profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="pseudo"></param>
        /// <param name="activity"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        public bool get_profile(string id = "", string firstname = "", string lastname = "", string pseudo = "", string activity = "",
            int age = 0, bool sex = true, string town = "")
        {
            Profile XNewProfile = new Profile(id, firstname, lastname, pseudo, activity, age, sex, town);
            profilesController controller = new profilesController();
            controller.UpdateProfile(XNewProfile);
            return true;
        }

        /// <summary>
        /// Met à jour un post forum
        /// </summary>
        /// <param name="id"></param>
        /// <param name="board"></param>
        /// <param name="content"></param>
        /// <param name="date"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public bool get_postforum(string id = "", string board = "", string content = "", DateTime date = new DateTime(), string author = "")
        {
            PostForum XNewPostForum = new PostForum(id, board, content, date, author);
            forumController controller = new forumController();
            controller.UpdatePostForum(XNewPostForum);
            return true;
        }
    }
}
