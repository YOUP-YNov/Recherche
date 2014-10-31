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
        public void AddProfile()
        {
            //Saving Node
            var node = new Uri("http://localhost:9200/");
            //Saving Settings
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "Youp"
            );
            //Starting Client
            var client = new ElasticClient(settings);

            var PersonTest = new Profile();
            PersonTest.Id = "1";
            PersonTest.Firstname = "Flavien";
            PersonTest.Lastname = "Geslin";

            var index = client.Index(PersonTest);
        }


        // GET api/values
        public IEnumerable<string> Get()
        {
            AddProfile();
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