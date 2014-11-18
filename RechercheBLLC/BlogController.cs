using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RechercheDal;
using Nest;
using Tools;

namespace ControllersBll
{

    public class blogController
    {
        public void AddBlog(Blog blog)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(blog);
        }

        public void AddBlogPost(BlogPost blogpost)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(blogpost);
        }

        public void AddBlogPostComment(BlogPostComment blogpostcomment)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(blogpostcomment);
        }

        public void RemoveBlog(string id)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Blog>(id);
        }

        public void RemoveBlogPost(string id)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<BlogPost>(id);

        }

        public void RemoveBlogPostComment(string id)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<BlogPostComment>(id);

        }

        public void UpdateBlog(Blog newblog)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<Blog, Blog>(u => u
                .Index("youp")
                .Id(newblog.Id)
                .Doc(newblog)
             );
        }

        public void UpdateBlogPost(BlogPost newblogpost)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<BlogPost, BlogPost>(u => u
                .Index("youp")
                .Id(newblogpost.Id)
                .Doc(newblogpost)
             );
        }

        public void UpdateBlogPostComment(BlogPostComment newblogpostcomment)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var response = client.Update<BlogPostComment, BlogPostComment>(u => u
                .Index("youp")
                .Id(newblogpostcomment.Id)
                .Doc(newblogpostcomment)
             );
        }


        public ISearchResponse<Blog> SimpleSearchBlog(string keyword, int from, int take)
        {
         //   IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Blog>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.QueryString(qs => qs
                .OnFields(p => p.Name, p => p.Categorie)
                .Query(keyword)
                )));
            return searchResults;
        }

        public ISearchResponse<BlogPost> SimpleSearchBlogPost(string keyword, int from, int take)
        {
           // IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<BlogPost>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.QueryString(qs => qs
                .OnFields(p => p.Content, p => p.Author, p => p.Title)
                .Query(keyword)
                )));
            return searchResults;
        }


        public ISearchResponse<BlogPostComment> SimpleSearchBlogComment(string keyword, int from, int take)
        {
           // IntParsRTestR ParsRtesR = new IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<BlogPostComment>(s => s
            .From(from)
            .Size(take)
            .Query(q => 
                q.QueryString(qs => qs
                .OnFields(p => p.Content, p => p.Author)
                .Query(keyword)
                )));
            return searchResults;

        }

    }
}
