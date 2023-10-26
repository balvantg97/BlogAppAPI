using BlogAppAPI.Controllers;
using BlogAppAPI.Interfaces;
using BlogAppAPI.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogAPI.Test
{
    public class Tests
    {
        private Mock<IBlog> _repo;
        private BlogController blogController;
        string user = "a299c45e-c13b-4f9a-a891-03fb321c4a16";
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IBlog>();
          
            _repo.Setup(a => a.GetMyBlogs(user)).Returns(new List<PostBlog>() { });
            blogController = new BlogController(_repo.Object);
        }

        [Test]
        public void Test1()
        {
            _repo.Setup(a => a.GetAllBlogs()).Returns(new List<PostBlog> {
                 new PostBlog()
                 {
                     BlogId = 24,
                     Title = "Happiness World",
                     Description = "Successful bloggers have to keep their heads around many different aspects of the medium – but at it’s core is being able to write compelling and engaging content on a consistent basis over time.    How you do this will vary from blogger to blogger to some extent as each blogger has their own style – however there are some basic principles of writing great blog content that might be worth keeping in mind.",
                 }
            });
            var result = blogController.GetAllBlogs();
            Assert.IsTrue(result[0].BlogId==24);
        }
        [Test]
        public void GetMyBlogsTest()
        {
           
            var result = blogController.GetMyBlogs(user);
            var value= result.Any(x => x.CreatedBy != user);
            Assert.IsFalse(value);
        }
    }
}