using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using System.Web.Http;

namespace MvcApplication1.Controllers
{

    public class PostForum
    {
        public string Id { get; set; }
        public string board { get; set; }
        public string content { get; set; }

        public PostForum(string _Id, string _board, string _content)
        {
            this.Id = _Id;
            this.board = _board;
            this.content = _content;
        }

    }

    public class ForumController : ApiController
    {
        //
        // GET: /Forum/
        public void AddPostForum(PostForum postforum)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(postforum);
        }

        public void SimpleSearchPostForum(string Keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<PostForum>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.content, Keyword)
                )
            );
        }
    }
}
