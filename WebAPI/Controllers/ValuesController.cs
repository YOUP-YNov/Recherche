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
        public void InitializeConnection()
        {
            //Saving Node
            var node = new Uri("http://localhost:9200");
            //Saving Settings
            var settings = new ConnectionSettings(
                node,
                defaultIndex: "Youp"
            );
            //Starting Client
            var client = new ElasticClient(settings);
        }


       /* // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }*/

        // GET api/values/5
        public string Get([FromUri]Profile id)
        {
            return "First name : " + id.Firstname + "Last name : " + id.Lastname;
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