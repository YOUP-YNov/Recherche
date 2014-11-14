using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RechercheDal;

namespace RechercheDal
{
    class GenericResponse
    {

        Place Gplace;
        Event Gevent;
        Profile Gprofile;
        PostForum Gpostforum;
        Blog Gblog;
        BlogPost Gblogpost;
        BlogPostComment Gblogpostcomment;

        enum Type { Place, Event, Profile, PostForum, Blog, BlogPost, BlogPostComment };

    }
}
