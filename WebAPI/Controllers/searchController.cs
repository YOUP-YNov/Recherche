using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class searchController : ApiController
    {
        // GET search/values
        /*public string[] GetPlaces()
        {
            BlogController ControllerTest = new BlogController();
            var tests = ControllerTest.SimpleSearchBlogPost("4");
            
            List<string> testArray = new List<string>();
            foreach (var test in tests)
            {
                testArray.Add(test.Content);
            }
            return testArray.ToArray<string>();
        }*/

        // GET search/get
        public string Get()
        {
            var nvc = HttpUtility.ParseQueryString(Request.RequestUri.Query);


            return "default";
        }
    }
}
