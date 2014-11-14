using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RechercheDal;

namespace RechercheDal
{
    public class GenericResponse
    {
        public IEnumerable<Place> Gplace;
        public IEnumerable<Event> Gevent;
        public IEnumerable<Profile> Gprofile;
        public IEnumerable<PostForum> Gpostforum;
        public IEnumerable<Blog> Gblog;
        public IEnumerable<BlogPost> Gblogpost;
        public IEnumerable<BlogPostComment> Gblogpostcomment;

        public GenericResponse() { }
    }
}
