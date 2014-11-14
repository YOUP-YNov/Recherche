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
    public class TestRemove
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
        public void TestRemoveEvent()
        {
            Place PlaceTest = new Place("60", "Place", "Ville", 2, 4);
            Event EventTest = new Event("600", "Event test", 1L, new DateTime(2014, 11, 30), PlaceTest, "adresse test");
            client.Index(EventTest);

            controllerEvent.RemoveEvent(EventTest); //test de la suppression

            var searchResults = client.Search<Event>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestMethod]
        public void TestRemoveProfile()
        {
            Profile ProfileTest = new Profile("600", "Firstname test", "Lastname test", "pseudo test", "activity test", 20, true);
            client.Index(ProfileTest);

            controllerProfile.RemoveProfile(ProfileTest); //test de la suppression

            var searchResults = client.Search<Profile>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestMethod]
        public void TestRemovePlace()
        {
            Place PlaceTest = new Place("600", "Nom test", "Ville test", 2, 5);
            client.Index(PlaceTest);

            controllerPlace.RemovePlace(PlaceTest); //test de la suppression

            var searchResults = client.Search<Place>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestMethod]
        public void TestRemovePostForum()
        {
            PostForum PostForumTest = new PostForum("600", "Post Test", "Content test", new DateTime(2014, 11, 30), "Author test");
            client.Index(PostForumTest);

            controllerForum.RemovePostForum(PostForumTest); //test de la suppression

            var searchResults = client.Search<PostForum>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestMethod]
        public void TestRemoveBlog()
        {
            Blog BlogTest = new Blog("600", "Content test", "Blog Test");
            client.Index(BlogTest);

            controllerBlog.RemoveBlog(BlogTest); //test de la suppression

            var searchResults = client.Search<Blog>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestMethod]
        public void TestRemoveBlogPost()
        {
            BlogPost BlogPostTest = new BlogPost("600", "Content", "Author", "BlogPost Test");
            client.Index(BlogPostTest);

            controllerBlog.RemoveBlogPost(BlogPostTest); //test de la suppression

            var searchResults = client.Search<BlogPost>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestMethod]
        public void TestRemoveBlogPostComment()
        {
            BlogPostComment BlogPostCommentTest = new BlogPostComment("600", "content", "BlogPostComment Test");
            client.Index(BlogPostCommentTest);

            controllerBlog.RemoveBlogPostComment(BlogPostCommentTest); //test de la suppression

            var searchResults = client.Search<BlogPostComment>(s => s.Query(q => q.Term(p => p.Id, "600")));
            Assert.AreEqual(0, searchResults.Total);
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }
    }
}
