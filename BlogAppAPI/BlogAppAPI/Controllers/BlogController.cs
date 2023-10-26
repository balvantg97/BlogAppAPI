using BlogAppAPI.Interfaces;
using BlogAppAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlog _repo;
        public BlogController(IBlog repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("CreateNewBlog")]
        [Consumes("multipart/form-data")]
        public bool PostNewBlog([FromForm] PostBlog postBlog)
        {
           return  _repo.PostNewBlog(postBlog);
        }

        [HttpGet]
        [Route("GetMyBlogs")]
        public List<PostBlog> GetMyBlogs(string userId)
        {
            return _repo.GetMyBlogs(userId);
        }
        [HttpGet]
        [Route("GetAllBlogs")]
        public List<PostBlog> GetAllBlogs()
        {
            return _repo.GetAllBlogs();
        }
        [HttpPost]
        [Route("AddComment")]
        public bool AddComment(Comment model)
        {
            return _repo.AddComment(model);
        }
        [HttpGet]
        [Route("GetAllComments")]
        public List<Comment> GetAllComments(int blogId)
        {
            return _repo.GetAllComments(blogId);
        }
        [HttpGet]
        [Route("GetBlogById")]
        public PostBlog GetBlogById(int blogId)
        {
            return _repo.GetBlogById(blogId);
        }
    }
}
