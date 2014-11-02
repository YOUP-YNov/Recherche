using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1;
using MvcApplication1.Controllers;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        /*
        [TestMethod]
        public void Get()
        {
            // Réorganiser
            GeneralSearchController controller = new GeneralSearchController();

            // Agir
            IEnumerable<string> result = controller.GetPlaces();

            // Déclarer
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }*/

        [TestMethod]
        public void GetById()
        {
            // Réorganiser
            GeneralSearchController controller = new GeneralSearchController();

            // Agir
            string result = controller.Get(5);

            // Déclarer
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Réorganiser
            GeneralSearchController controller = new GeneralSearchController();

            // Agir
            controller.Post("value");

            // Déclarer
        }

        [TestMethod]
        public void Put()
        {
            // Réorganiser
            GeneralSearchController controller = new GeneralSearchController();

            // Agir
            controller.Put(5, "value");

            // Déclarer
        }

        [TestMethod]
        public void Delete()
        {
            // Réorganiser
            GeneralSearchController controller = new GeneralSearchController();

            // Agir
            controller.Delete(5);

            // Déclarer
        }
    }
}
