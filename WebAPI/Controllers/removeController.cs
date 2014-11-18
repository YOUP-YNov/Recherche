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
        public bool get_blog(string id = "")
        {
            if (id == "" || id == null) return false;
            blogController controller = new blogController();
            controller.RemoveBlog(id);
            return true;
        }

        public bool get_blogpost(string id = "")
        {
            if (id == "" || id == null) return false;
            blogController controller = new blogController();
            controller.RemoveBlogPost(id);
            return true;
        }

        public bool get_blogpostcomment(string id = "")
        {
            if (id == "" || id == null) return false;
            blogController controller = new blogController();
            controller.RemoveBlogPostComment(id);
            return true;
        }

        public bool get_event(string id = "")
        {
            if (id == "" || id == null) return false;
            eventsController controller = new eventsController();
            controller.RemoveEvent(id);
            return true;
        }

        public bool get_place(string id = "")
        {
            if (id == "" || id == null) return false;
            placesController controller = new placesController();
            controller.RemovePlace(id);
            return true;
        }

        public bool get_profile(string id = "")
        {
            if (id == "" || id == null) return false;
            profilesController controller = new profilesController();
            controller.RemoveProfile(id);
            return true;
        }

        public bool get_postforum(string id = "")
        {
            if (id == "" || id == null) return false;
            forumController controller = new forumController();
            controller.RemovePostForum(id);
            return true;
        }
    }
}
