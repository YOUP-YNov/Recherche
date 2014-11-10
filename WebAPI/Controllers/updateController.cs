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
        public bool _blog()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            Blog XOldBlog = new Blog(nvc["idO"], nvc["contentO"], nvc["categoryO"]);
            Blog XNewBlog = new Blog(nvc["idN"], nvc["contentN"], nvc["categoryN"]);
            blogController controller = new blogController();
            controller.UpdateBlog(XOldBlog, XNewBlog);
            return true;
        }

        public bool _blogpost()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            BlogPost XOlgBlogPost = new BlogPost(nvc["idO"], nvc["contentO"], nvc["authorO"], nvc["titleO"]);
            BlogPost XNewBlogPost = new BlogPost(nvc["idN"], nvc["contentN"], nvc["authorN"], nvc["titleN"]);
            blogController controller = new blogController();
            controller.UpdateBlogPost(XOlgBlogPost, XNewBlogPost);
            return true;
        }

        public bool _blogpostcomment()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            BlogPostComment XOldBlogPostComment = new BlogPostComment(nvc["idO"], nvc["contentO"], nvc["authorO"]);
            BlogPostComment XNewBlogPostComment = new BlogPostComment(nvc["idN"], nvc["contentN"], nvc["authorN"]);
            blogController controller = new blogController();
            controller.UpdateBlogPostComment(XOldBlogPostComment, XNewBlogPostComment);
            return true;
        }

        public bool _event()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            decimal? latitudeO = decimal.Parse(nvc["latitudeO"]);
            decimal? longitudeO = decimal.Parse(nvc["longitudeO"]);
            decimal? latitudeN = decimal.Parse(nvc["latitudeN"]);
            decimal? longitudeN = decimal.Parse(nvc["longitudeN"]);
            Place XOldPlace = new Place(nvc["idOp"], nvc["nameOp"], nvc["townOp"], latitudeO, longitudeO);
            Place XNewPlace = new Place(nvc["idNp"], nvc["nameNp"], nvc["townNp"], latitudeO, longitudeO);
            Event XOldEvent = new Event(nvc["idOe"], nvc["nameOe"], long.Parse(nvc["typeOe"]), DateTime.Parse(nvc["dateOe"]), XOldPlace, nvc["adresseOe"]);
            Event XNewEvent = new Event(nvc["idNe"], nvc["nameNe"], long.Parse(nvc["typeNe"]), DateTime.Parse(nvc["dateNe"]), XNewPlace, nvc["adresseNe"]);
            eventsController controller = new eventsController();
            controller.UpdateEvent(XOldEvent, XNewEvent);
            return true;
        }

        public bool _place()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            decimal? latitudeO = decimal.Parse(nvc["latitudeO"]);
            decimal? longitudeO = decimal.Parse(nvc["longitudeO"]);
            decimal? latitudeN = decimal.Parse(nvc["latitudeN"]);
            decimal? longitudeN = decimal.Parse(nvc["longitudeN"]);
            Place XOldPlace = new Place(nvc["idOp"], nvc["nameOp"], nvc["townOp"], latitudeO, longitudeO);
            Place XNewPlace = new Place(nvc["idNp"], nvc["nameNp"], nvc["townNp"], latitudeO, longitudeO);
            placesController controller = new placesController();
            controller.UpdatePlace(XOldPlace, XNewPlace);
            return true;
        }

        public bool _profile()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            Profile XOldProfile = new Profile(nvc["idO"], nvc["firstnameO"], nvc["lastNameO"], nvc["pseudoO"], nvc["activityO"], Int32.Parse(nvc["ageO"]), bool.Parse(nvc["sexO"]));
            Profile XNewProfile = new Profile(nvc["idN"], nvc["firstnameN"], nvc["lastNameN"], nvc["pseudoN"], nvc["activityN"], Int32.Parse(nvc["ageN"]), bool.Parse(nvc["sexN"]));
            ProfilesController controller = new ProfilesController();
            controller.UpdateProfile(XOldProfile, XNewProfile);
            return true;
        }

        public bool _postforum()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            PostForum XOldPostForum = new PostForum(nvc["idO"], nvc["boardO"], nvc["contentO"], DateTime.Parse(nvc["dateO"]), nvc["authorO"]);
            PostForum XNewPostForum = new PostForum(nvc["idN"], nvc["boardN"], nvc["contentN"], DateTime.Parse(nvc["dateN"]), nvc["authorN"]);
            forumController controller = new forumController();
            controller.UpdatePostForum(XOldPostForum, XNewPostForum);
            return true;
        }
    }
}
