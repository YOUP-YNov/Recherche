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

        //Method InitializeConnection : Explicit
        public ElasticClient InitializeConnection()
        {
            //Saving Node
            var node = new Uri("http://martinleguillou.fr:1194/");
            //Saving Settings
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "youp"
            );
            //Starting Client
            var client = new ElasticClient(settings);
            return client;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            Profile ProfilTest = new Profile();
            ElasticClient NewClient = InitializeConnection();
            ProfilTest.AddProfile(NewClient);
            ProfilTest.SearchProfile(NewClient);
            return new string[] { "value1", "value2" };
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