using RechercheDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class addController : ApiController
    {
        public bool _place(Place XPlace)
        {
            return true;
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

        public bool _profile(Profile XProfile)
        {
            return true;
        }

        public bool _postforul(PostForum XPostForum)
        {
            return true;
        }
    }
}
