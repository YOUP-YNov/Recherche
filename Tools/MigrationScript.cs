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
            if (eventMigration(elastic))
            {
                Console.WriteLine("Events ==> Done.");
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
                    var now = DateTime.Now.Year;
                    var dob = user.DateNaissance.Year;
                    int userAge = (int)(now - dob);
                    //Create entity into LUCENE
                    Profile profileElastic = new Profile(user.Utilisateur_id.ToString(), user.Prenom, user.Nom, user.Pseudo, user.Situation, userAge, user.Sexe);
                    //Index entity
                    var indexP = elastic.Index(profileElastic);
                }
            }
            return true;
        }

        //Migration event
        public static bool eventMigration(ElasticClient elastic)
        {
            using (var context = new YoupDEVEntities())
            {
                //Get BASE
                var events = (from e in context.EVE_Evenement
                             select e).ToList<EVE_Evenement>();

                //Translate into LUCENE
                foreach (var _event in events)
                {
                    //Place
                    // Place placeElastic = new Place(place.LieuEvenement_id.ToString(), place.Nom, place.Ville);
                    Place eventPlace = new Place(_event.LieuEvenement_id.ToString(), _event.EVE_LieuEvenement.Nom, _event.EVE_LieuEvenement.Ville);

                    //Create entity into LUCENE
                    //WARNING -- TImeslot missing --
                    /* public string Id { get; set; }
                    ** public string Name { get; set; }
                    ** public long Type { get; set; }
                    ** public DateTime Date { get; set; }
                    ** public Place EPlace { get; set; }
                    ** public string Adresse { get; set; }
                    ** public string Timeslot { get; set; } <<<!!!>>>

                    public Event(string _Id, string _Name, long _Type, DateTime _Date, Place _EPlace, string _Adresse, string _Timeslot <<<!!!>>>)*/
                    Event eventElastic = new Event(_event.Evenement_id.ToString(), _event.TitreEvenement, _event.Categorie_id, _event.DateEvenement, eventPlace, _event.EVE_LieuEvenement.Adresse);
                    //Index entity
                    var indexP = elastic.Index(eventElastic);
                }
            }
            return true;
        }



    }
}
