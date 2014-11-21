using RechercheDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ControllersBll;
using Nest;

namespace MvcApplication1.Controllers
{
    public class advancedsearchController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="from"></param>
        /// <param name="take"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public GenericResponse get_place(string keyword="", int from=0, int take=20, string location="")
        {
            if (keyword.Contains("%20"))
            {
                keyword.Replace("%20", " ");
            }
            keyword = keyword.ToLower();
            location = location.ToLower();
            GenericResponse myReturn = new GenericResponse();

            //Search in Places
            placesController Pcontroller = new placesController();
            myReturn.Gplace = Pcontroller.AdvancedSearchPlace(from, take, keyword, location).Hits;
            return myReturn;
        }

        /// <summary>
        /// Non fonctionnel
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="from"></param>
        /// <param name="take"></param>
        /// <param name="author"></param>
        /// <returns></returns>
        public GenericResponse get_blog(string keyword, string from, string take, string author)
        {
            if (keyword.Contains("%20"))
            {
                keyword.Replace("%20", " ");
            }
            keyword = keyword.ToLower();
           
            blogController Pcontroller = new blogController();

            //Search in blog


            GenericResponse myReturn = new GenericResponse();
            return myReturn;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="take"></param>
        /// <param name="keyword"></param>
        /// <param name="type"></param>
        /// <param name="town"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public GenericResponse get_event(int from=0, int take=20, string keyword="", string type="", string town="", DateTime? date=null)
        {
            if (keyword.Contains("%20"))
            {
                keyword.Replace("%20", " ");
            }
            keyword = keyword.ToLower();
            town = town.ToLower();
            GenericResponse myReturn = new GenericResponse();
            //Search in Forum
            eventsController Pcontroller = new eventsController();
            myReturn.Gevent = Pcontroller.AdvancedSearchEvent(from, take, keyword, type, town, date).Hits;
             
            return myReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="take"></param>
        /// <param name="keyword"></param>
        /// <param name="age"></param>
        /// <param name="town"></param>
        /// <returns></returns>
        public GenericResponse get_profile(int from=0, int take=20, string keyword="", int? age=null, string town="")
        {
            if (keyword.Contains("%20"))
            {
                keyword.Replace("%20", " ");
            }
            keyword = keyword.ToLower();
            town = town.ToLower();
            GenericResponse myReturn = new GenericResponse();

            //Search in Profiles
            profilesController Pcontroller = new profilesController();
            myReturn.Gprofile = Pcontroller.AdvancedSearchProfile(from, take, keyword, age, town).Hits;
             
            return myReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="take"></param>
        /// <param name="keyword"></param>
        /// <param name="author"></param>
        /// <param name="board"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public GenericResponse get_postforum(string from, string take, string keyword, string author, string board, string date)
        {
            if (keyword.Contains("%20"))
            {
                keyword.Replace("%20", " ");
            }
            keyword = keyword.ToLower();

            GenericResponse myReturn = new GenericResponse();
            //Search in Profiles
            forumController Pcontroller = new forumController();
            myReturn.Gpostforum = Pcontroller.AdvancedSearchForum(from, take, keyword, author, board, date).Hits;

            return myReturn;
        }
    }
}
