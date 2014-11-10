using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RechercheDal;
using Nest;
using Tools;

namespace MvcApplication1.Controllers
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

        public void RemoveBlog(Blog blog)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete(new DeleteRequest(blog.Id, "blogs", "1"));

        }

        public void RemoveBlogPost(BlogPost blogpost)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete(new DeleteRequest(blogpost.Id, "blogposts", "1"));

        }

        public void RemoveBlogPostComment(BlogPostComment blogpostcomment)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete(new DeleteRequest(blogpostcomment.Id, "blogpostcomments", "1"));

        }

        public void UpdateBlog(Blog oldblog, Blog newblog)
        {
            RemoveBlog(oldblog);
            AddBlog(newblog);
        }

        public void UpdateBlogPost(BlogPost oldblogpost, BlogPost newblogpost)
        {
            RemoveBlogPost(oldblogpost);
            AddBlogPost(newblogpost);
        }

        public void UpdateBlogPostComment(BlogPostComment oldblogpostcomment, BlogPostComment newblogpostcomment)
        {
            RemoveBlogPostComment(oldblogpostcomment);
            AddBlogPostComment(newblogpostcomment);
        }

        // GET search/blog/get
        public IEnumerable<Blog> SimpleSearchBlog()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Blog>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, nvc["keyword"])
                )
            );
            return searchResults.Documents;
        }

        public IEnumerable<BlogPost> SimpleSearchBlogPost(string Keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<BlogPost>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Title, Keyword)
                )
            );
            return searchResults.Documents;
         //   return searchResults.Documents;
        }


        public void SimpleSearchBlogComment(string Keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<BlogPostComment>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Content, Keyword)
                )
            );

        }

    }
}
