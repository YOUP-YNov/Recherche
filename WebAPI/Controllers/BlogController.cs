﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nest;
using System.Web.Http;

namespace MvcApplication1.Controllers
{

    public class Blog
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Categorie { get; set; }

        public Blog(string _Id, string _Name, string _Categorie)
        {
            this.Id = _Id;
            this.Name = _Name;
            this.Categorie = _Categorie;
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



    public class BlogController : ApiController
    {
        //
        // GET: /Blog/

        public void AddBlog(Blog blog)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(blog);
        }

        public void SimpleSearchBlog(string Keyword)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            //Search
            var searchResults = client.Search<Blog>(s => s
            .From(0)
            .Size(10)
            .Query(q => q
            .Term(p => p.Name, Keyword)
                )
            );
        }

        public void AddBlogPost(BlogPost blogpost)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(blogpost);
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
        }

        public void AddBlog(BlogPostComment blogpostcomment)
        {
            ElasticClient client = YoupElasticSearch.InitializeConnection();
            var index = client.Index(blogpostcomment);
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
