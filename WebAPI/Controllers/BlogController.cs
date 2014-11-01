using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;

namespace MvcApplication1.Controllers
{

    public class Blog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }

        public Blog(string _Id, string _Name, string _Theme)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Theme = _Theme;
        }

    }

    public class BlogPost
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public BlogPost(string _Id, string _Content, string _Author, string _Title)
        {
            this.Id = _Id;
            this.Content = _Content;
            this.Author = _Author;
            this.Title = _Title;
        }

    }

    public class BlogPostComment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public BlogPostComment(string _Id, string _Content, string _Author)
        {
            this.Id = _Id;
            this.Content = _Content;
            this.Author = _Author;
        }
    }



    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public void AddBlog(ElasticClient client, Blog blog)
        {
            var index = client.Index(blog);
        }

        public void SimpleSearchBlog(ElasticClient client, string Keyword)
        {
            //Search
            var searchResults = client.Search<Blog>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, Keyword)
                )
            );
        }

        public void AddBlogPost(ElasticClient client, BlogPost blogpost)
        {
            var index = client.Index(blogpost);
        }

        public void SimpleSearchBlogPost(ElasticClient client, string Keyword)
        {
            //Search
            var searchResults = client.Search<BlogPost>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Title, Keyword)
                )
            );
        }

        public void AddBlog(ElasticClient client, BlogPostComment blogpostcomment)
        {
            var index = client.Index(blogpostcomment);
        }
        public void SimpleSearchBlogComment(ElasticClient client, string Keyword)
        {
            //Search
            var searchResults = client.Search<BlogPostComment>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Content, Keyword)
                )
            );
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
