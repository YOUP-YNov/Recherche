﻿using System;
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
    public class TestSearch
    {
        ElasticClient client;
        eventsController controllerEvent;
        profilesController controllerProfile;
        placesController controllerPlace;
        forumController controllerForum;
        blogController controllerBlog;

        [TestInitialize]
        public void TestInitialize()
        {
            client = YoupElasticSearch.InitializeConnection();
            controllerEvent = new eventsController();
            controllerProfile = new profilesController();
            controllerPlace = new placesController();
            controllerForum = new forumController();
            controllerBlog = new blogController();
        }

        [TestMethod]
        public void TestSearchEvent()
        {
            Place PlaceTest = new Place("80", "Place", "Ville", 2, 4);
            Event EventTest = new Event("800", "événement", 1L, new DateTime(2014, 11, 30), PlaceTest, "adresse test");
            client.Index(EventTest);

            var searchResults = controllerEvent.SimpleSearchEvent("événement", "0","1"); //test de la recherche
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }
    }
}