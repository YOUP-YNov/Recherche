using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
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
}
