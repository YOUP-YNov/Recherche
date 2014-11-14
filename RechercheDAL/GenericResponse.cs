using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RechercheDal;
using Nest;

namespace RechercheDal
{
    public class GenericResponse
    {
        public IEnumerable<IHit<Place>> Gplace;
        public IEnumerable<IHit<Event>> Gevent;
        public IEnumerable<IHit<Profile>> Gprofile;
        public IEnumerable<IHit<PostForum>> Gpostforum;
        public IEnumerable<IHit<Blog>> Gblog;
        public IEnumerable<IHit<BlogPost>> Gblogpost;
        public IEnumerable<IHit<BlogPostComment>> Gblogpostcomment;

        public GenericResponse() { }
    }
}
