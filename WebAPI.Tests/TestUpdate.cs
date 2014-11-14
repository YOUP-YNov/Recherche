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
    public class TestUpdate
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
        public void TestUpdateEvent()
        {
            Place PlaceTest = new Place("70", "Place test", "Ville", 2, 4);
            Event EventTest = new Event("700", "Event test", 1L, new DateTime(2014, 11, 30), PlaceTest, "adresse");
            Event newEvent = new Event("700", "Event updated", 1L, new DateTime(2014, 11, 30), PlaceTest, "adresse");
            client.Index(EventTest);

            controllerEvent.UpdateEvent(EventTest, newEvent); //test de la modification

            var searchResults = client.Search<Event>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (Event hit in searchResults.Hits)
                Assert.AreEqual("Event updated", hit.Name);
        }

        [TestMethod]
        public void TestUpdateProfile()
        {
            Profile ProfileTest = new Profile("700", "Firstname test", "Lastname test", "pseudo test", "activity test", 20, true, "Ville");
            Profile newProfile = new Profile("700", "Profile updated", "Lastname test", "pseudo test", "activity test", 20, true, "Ville");
            client.Index(ProfileTest);

            controllerProfile.UpdateProfile(ProfileTest, newProfile); //test de la modification

            var searchResults = client.Search<Profile>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (Profile hit in searchResults.Hits)
                Assert.AreEqual("Profile updated", hit.Firstname);
        }

        [TestMethod]
        public void TestUpdatePlace()
        {
            Place PlaceTest = new Place("700", "Lieu test", "Town", 2, 5);
            Place newPlace = new Place("700", "Lieu updated", "Town", 2, 5);
            client.Index(PlaceTest);

            controllerPlace.UpdatePlace(PlaceTest, newPlace); //test de la modification

            var searchResults = client.Search<Place>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (Place hit in searchResults.Hits)
                Assert.AreEqual("Lieu updated", hit.Name);
        }

        [TestMethod]
        public void TestUpdatePostForum()
        {
            PostForum PostForumTest = new PostForum("700", "Post Test", "Content", new DateTime(2014, 11, 30), "Author");
            PostForum newPostForum = new PostForum("700", "Post updated", "Content", new DateTime(2014, 11, 30), "Author");
            client.Index(PostForumTest);

            controllerForum.UpdatePostForum(PostForumTest, newPostForum); //test de la modification

            var searchResults = client.Search<PostForum>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (PostForum hit in searchResults.Hits)
                Assert.AreEqual("Post updated", hit.board);
        }

        [TestMethod]
        public void TestUpdateBlog()
        {
            Blog BlogTest = new Blog("700", "Content", "Blog Test");
            Blog newBlog = new Blog("700", "Content", "Blog Updated");
            client.Index(BlogTest);

            controllerBlog.UpdateBlog(BlogTest, newBlog); //test de la modification

            var searchResults = client.Search<Blog>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (Blog hit in searchResults.Hits)
                Assert.AreEqual("Blog updated", hit.Categorie);
        }

        [TestMethod]
        public void TestUpdateBlogPost()
        {
            BlogPost BlogPostTest = new BlogPost("700", "Content", "Author", "BlogPost Test");
            BlogPost newBlogPost = new BlogPost("700", "Content", "Author", "BlogPost updated");
            client.Index(BlogPostTest);

            controllerBlog.UpdateBlogPost(BlogPostTest, newBlogPost); //test de la modification

            var searchResults = client.Search<BlogPost>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (BlogPost hit in searchResults.Hits)
                Assert.AreEqual("BlogPost updated", hit.Title);
        }

        [TestMethod]
        public void TestUpdateBlogPostComment()
        {
            BlogPostComment BlogPostCommentTest = new BlogPostComment("700", "content", "BlogPostComment Test");
            BlogPostComment newBlogPostComment = new BlogPostComment("700", "content", "BlogPostComment updated");
            client.Index(BlogPostCommentTest);

            controllerBlog.UpdateBlogPostComment(BlogPostCommentTest, newBlogPostComment); //test de la modification

            var searchResults = client.Search<BlogPostComment>(s => s.Query(q => q.Term(p => p.Id, "700")));
            foreach (BlogPostComment hit in searchResults.Hits)
                Assert.AreEqual("BlogPostComment updated", hit.Author);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            client.Delete<Event>("700");
            client.Delete<Profile>("700");
            client.Delete<Place>("700");
            client.Delete<PostForum>("700");
            client.Delete<Blog>("700");
            client.Delete<BlogPost>("700");
            client.Delete<BlogPostComment>("700");
        }
    }
}
