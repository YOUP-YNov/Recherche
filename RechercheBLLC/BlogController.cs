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

        public void RemoveBlog(Blog blog)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<Blog>(blog.Id);

        }

        public void RemoveBlogPost(BlogPost blogpost)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<BlogPost>(blogpost.Id);

        }

        public void RemoveBlogPostComment(BlogPostComment blogpostcomment)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            client.Delete<BlogPostComment>(blogpostcomment.Id);

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
        public IEnumerable<Blog> SimpleSearchBlog(string keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Blog>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, keyword)
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
