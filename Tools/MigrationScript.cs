using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using MvcApplication1;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MvcApplication1.Controllers;

namespace Tools
{
    class MigrationScript
    {
        //Main
        static void Main(string[] args)
        {
            ElasticClient elastic = YoupElasticSearch.InitializeConnection();
            
            if (blogMigration(elastic))
            {
                Console.WriteLine("Blogs ==> Done.");
            }
            if (placeMigration(elastic))
            {
                Console.WriteLine("Places ==> Done.");
            }
            if (userMigration(elastic))
            {
                Console.WriteLine("Users ==> Done.");
            }
            Console.ReadLine();
        }

        //Migration blog
        public static bool blogMigration(ElasticClient elastic)
        {
            using (var context = new YoupDEVEntities())
            {
                var blogs = (from b in context.BLOG_Blog
                             select b).ToList<BLOG_Blog>();
                foreach (var blog in blogs)
                {
                    Blog blogElastic = new Blog(blog.Blog_id.ToString(), blog.TitreBlog, blog.Theme_id.ToString());
                    var indexB = elastic.Index(blogElastic);
                    /* var visits = (from v in context.BLOG_Visite
                                  where v.Blog_Id == blog.Blog_id
                                  select v).Count();*/

                    var articles = (from a in context.BLOG_Article
                                    where a.Blog_id == blog.Blog_id
                                    select a).ToList<BLOG_Article>();

                    foreach (var article in articles)
                    {
                        BlogPost articleElastic = new BlogPost(article.Article_id.ToString(), article.ContenuArticle, blog.Utilisateur_id.ToString(), article.TitreArticle);
                        var indexA = elastic.Index(articleElastic);

                        var comments = (from c in context.BLOG_Commentaire
                                        where c.Article_id == article.Article_id
                                        select c).ToList<BLOG_Commentaire>();
                        foreach (var comment in comments)
                        {
                            BlogPostComment commentElastic = new BlogPostComment(comment.Commentaire_id.ToString(), comment.ContenuCommentaire, comment.Utilisateur_id.ToString());
                            var indexC = elastic.Index(commentElastic);
                        }
                    }
                }
            }
            return true;
        }

        public static bool placeMigration(ElasticClient elastic)
        {
            using (var context = new YoupDEVEntities())
            {
                var places = (from p in context.EVE_LieuEvenement
                             select p).ToList<EVE_LieuEvenement>();
                
                foreach(var place in places){
                    Place placeElastic = new Place(place.LieuEvenement_id.ToString(), place.Nom, place.Ville);
                    var indexP = elastic.Index(placeElastic);
                }
            }
            return true;
        }

        //Migration user
        public static bool userMigration(ElasticClient elastic)
        {
            using (var context = new YoupDEVEntities())
            {
                //Get BASE
                var users = (from u in context.UT_Utilisateur
                               select u).ToList<UT_Utilisateur>();

                //Translate into LUCENE
                foreach (var user in users)
                {
                    //Age (years only)
                    var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                    var dob = float.Parse(user.DateNaissance.ToString("yyyy.MMdd"));
                    int userAge = (int)(now - dob);
                    //Create entity into LUCENE
                    Profile profileElastic = new Profile(user.Utilisateur_id.ToString(), user.Prenom, user.Nom, user.Pseudo, user.Situation, userAge, user.Sexe);
                    //Index entity
                    var indexP = elastic.Index(profileElastic);
                }
            }
            return true;
        }


    }
}
