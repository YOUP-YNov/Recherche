using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nest;

namespace MvcApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public /*IEnumerable<string>IEnumerable<BlogPost> */ string Get()
        {
            
          //  Profile ProfilTest = new Profile();
            ElasticClient NewClient = YoupElasticSearch.InitializeConnection();
           /* ProfilTest.AddProfile(NewClient);
            ProfilTest.SearchProfile(NewClient);*/
            string testc  = "test";
            BlogController ControllerTest = new BlogController();
            return ControllerTest.SimpleSearchBlogPost(NewClient, testc).ToString();
         //   return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}