using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RechercheDal;
using ControllersBll;
using MvcApplication1.Controllers;
using Nest;
using Tools;
using System.Collections.Generic;

namespace MvcApplication1.Tests
{
    [TestClass]
    public class TestAdd
    {
        ElasticClient client;
        eventsController controllerEvent;

        [TestInitialize]
        public void TestInitialize()
        {
            client = YoupElasticSearch.InitializeConnection();
            controllerEvent = new eventsController();
        }

        // * Verifie le bon fonctionnement de la méthode add pour les événements
        [TestMethod]
        public void TestMethodAddEvent()
        {
            Place PlaceTest = new Place("500", "Place test add", "Ville Test", 2, 4);
            Event EventTest = new Event("500", "Event test add", 1L, new DateTime(2014, 11, 30), PlaceTest, "adresse test add");
            //ajout de l'événements
            controllerEvent.AddEvent(EventTest); 
           //recherche de l'événement que l'on vient d'ajouter
            var searchResults = client.Search<Event>(s => s.Query(q => q.Term(p => p.Id, "500")));
            //on vérifie combien de résultats on a
            int resultats = 0;
            foreach (var hit in searchResults.Hits)
                resultats++;

            //client.Delete(new DeleteRequest("500", "event", "1"));

            Assert.AreEqual(1, resultats);

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }
    }
}
