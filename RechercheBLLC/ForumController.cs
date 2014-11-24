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

        public void RemovePostForum(string id)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<PostForum>(id);
        }

        public void UpdatePostForum(PostForum newpostforum)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<PostForum, PostForum>(u => u
                .Index("youp")
                .Id(newpostforum.Id)
                .Doc(newpostforum)
             );
        }

        public ISearchResponse<PostForum> SimpleSearchPostForum(string keyword, int from, int take)
        {
         //   IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<PostForum>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.QueryString(qs => qs
                .OnFields(p => p.content, p => p.author, p => p.board)
                .Query(keyword)
                )));

            return searchResults;
        }

        public ISearchResponse<PostForum> AdvancedSearchForum(int from, int take, string Keyword, string Author, string Board, DateTime? Date)
        {
            //IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();

            //advanced search all parameters
            var searchResults = client.Search<PostForum>(body =>
                body.Filter(filter =>
                    filter.Term(x =>
                        x.board, Board)
                    && filter.Term(x =>
                        x.author, Author) 
                    && filter.Term(x =>
                        x.date, Date))
                    .Query(q =>
                        q.QueryString(qs => qs
                        .OnFields(p => p.content)
                        .Query(Keyword)
                        ))
            .From(from)
            .Take(take));

            return searchResults;
        }
    }
}
