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
        public void TestAddEvent()
        {
            Place PlaceTest = new Place("50", "Place", "Ville", 2, 4);
            Event EventTest = new Event("500", "Event test", 1L, new DateTime(2014, 11, 30), PlaceTest, "adresse test");

            controllerEvent.AddEvent(EventTest); //test de l'ajout

            var searchResults = client.Search<Event>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestMethod]
        public void TestAddProfile()
        {
            Profile ProfileTest = new Profile("500", "Firstname test", "Lastname test", "pseudo test", "activity test", 20, true);

            controllerProfile.AddProfile(ProfileTest); //test de l'ajout

            var searchResults = client.Search<Profile>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestMethod]
        public void TestAddPlace()
        {
            Place PlaceTest = new Place("500", "Nom test", "Ville test", 2, 5);

            controllerPlace.AddPlace(PlaceTest); //test de l'ajout

            var searchResults = client.Search<Place>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestMethod]
        public void TestAddPostForum()
        {
            PostForum PostForumTest = new PostForum("500", "Post Test", "Content test", new DateTime(2014, 11, 30), "Author test");

            controllerForum.AddPostForum(PostForumTest); //test de l'ajout

            var searchResults = client.Search<PostForum>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestMethod]
        public void TestAddBlog()
        {
            Blog BlogTest = new Blog("500", "Content test", "Blog Test");

            controllerBlog.AddBlog(BlogTest); //test de l'ajout

            var searchResults = client.Search<Blog>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestMethod]
        public void TestAddBlogPost()
        {
            BlogPost BlogPostTest = new BlogPost("500", "Content test", "Author test", "BlogPost Test");

            controllerBlog.AddBlogPost(BlogPostTest); //test de l'ajout

            var searchResults = client.Search<BlogPost>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestMethod]
        public void TestAddBlogPostComment()
        {
            BlogPostComment BlogPostCommentTest = new BlogPostComment("500", "content test", "BlogPostComment Test");

            controllerBlog.AddBlogPostComment(BlogPostCommentTest); //test de l'ajout

            var searchResults = client.Search<BlogPostComment>(s => s.Query(q => q.Term(p => p.Id, "500")));
            Assert.AreEqual(1, searchResults.Total);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            client.Delete<Event>("500");
            client.Delete<Profile>("500");
            client.Delete<Place>("500");
            client.Delete<Blog>("500");
            client.Delete<PostForum>("500");
            client.Delete<BlogPost>("500");
            client.Delete<BlogPostComment>("500");
        }
    }
}
