using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RechercheDal;
using Tools;
using Nest;

namespace MvcApplication1.Controllers
{

    public class forumController
    {
        //
        // GET: /Forum/
        public void AddPostForum(PostForum postforum)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(postforum);
        }

        public void RemovePostForum(PostForum postforum)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<PostForum>(postforum.Id);
        }

        public void UpdatePostForum(PostForum oldpostforum, PostForum newpostforum)
        {
            RemovePostForum(oldpostforum);
            AddPostForum(newpostforum);
        }

        public void SimpleSearchPostForum(string Keyword, string from, string take)
        {
            ClassLibrary1.IntParsRTestR ParsRtesR = new ClassLibrary1.IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<PostForum>(s => s
            .From(ParsRtesR.Intfrom)
            .Size(ParsRtesR.Inttake)
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
