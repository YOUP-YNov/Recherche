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


        public ISearchResponse<Blog> SimpleSearchBlog(string keyword, string from, string take)
        {
            ClassLibrary1.IntParsRTestR ParsRtesR = new ClassLibrary1.IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Blog>(s => s
            .From(ParsRtesR.Intfrom)
            .Size(ParsRtesR.Intfrom)
            .Query(q => q
            .Term(p => p.Name, keyword)
                )
            );
            return searchResults;
        }

        public ISearchResponse<BlogPost> SimpleSearchBlogPost(string keyword, string from, string take)
        {
            ClassLibrary1.IntParsRTestR ParsRtesR = new ClassLibrary1.IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<BlogPost>(s => s
            .From(ParsRtesR.Intfrom)
            .Size(ParsRtesR.Intfrom)
            .Query(q => q
            .Term(p => p.Title, keyword)
                )
            );
            return searchResults;
        }


        public ISearchResponse<BlogPostComment> SimpleSearchBlogComment(string keyword, string from, string take)
        {
            ClassLibrary1.IntParsRTestR ParsRtesR = new ClassLibrary1.IntParsRTestR(from, take);

            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<BlogPostComment>(s => s
            .From(ParsRtesR.Intfrom)
            .Size(ParsRtesR.Intfrom)
            .Query(q => q
            .Term(p => p.Content, keyword)
                )
            );
            return searchResults;

        }

    }
}
