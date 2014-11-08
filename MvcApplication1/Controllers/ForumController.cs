using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using System.Web.Http;
using RechercheDal;
using Tools;

namespace MvcApplication1.Controllers
{

    public class forumController : ApiController
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

        public void AdvancedSearchForum(string Keyword, string Author, string Board, DateTime Date)
        {

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //advanced search all parameters
            var searchResults = client.Search<PostForum>(body =>
            body.Query(query =>
                query.ConstantScore(csq =>
                    csq.Filter(filter =>
                            filter.Term(x =>
                                x.board, Board))
                        .Filter(filter =>
                            filter.Term(x =>
                                x.author, Author))
                        .Filter(filter =>
                            filter.Term(x =>
                                x.date, Date))
                       .Query(q =>
                            q.Term(p => p.content, Keyword))))
            .Take(20));
        }
    }
}
