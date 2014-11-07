﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nest;
using System.Web;

namespace MvcApplication1.Controllers
{
    public class globalController : ApiController
    {

        //GET search/simple
        public void simple()
        {

        }

        //GET search/advanced
        public void advanced()
        {

        }

        //GET search/add
        public void add()
        {

        }

        //GET search/reindex
        public void reindex()
        {

        }

        //GET search/remove
        public void remove()
        {

        }


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

        // POST search/values
        public void Post([FromBody]string value)
        {
        }

        // PUT search/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE search/values/5
        public void Delete(int id)
        {
        }

        public string Get(int p)
        {
            throw new NotImplementedException();
        }
    }
}