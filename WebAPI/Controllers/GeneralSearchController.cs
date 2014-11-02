﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nest;

namespace MvcApplication1.Controllers
{
    public class GeneralSearchController : ApiController
    {
        // GET search/values
        public IEnumerable<string> GetPlaces()
        {
            PlacesController ControllerTest = new PlacesController();
            ControllerTest.SimpleSearchPlace();
            return new string[] { "Recherche", "Ok" };
        }

        // GET search/values/5
        public string Get(int id)
        {
            return "value";
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
    }
}