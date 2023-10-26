using BlogAppAPI.Interfaces;
using BlogAppAPI.Models;
using BlogAppAPI.Models.DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Repository
{
    public class BlogRepo:IBlog
    {
        private readonly BlogAppDBContext _context;
        private readonly IWebHostEnvironment _environment;
        public BlogRepo(BlogAppDBContext context, IWebHostEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        public bool PostNewBlog(PostBlog blog)
        {
            try
            {
                var result=UploadFile(blog.Img);
                if (result.Result!="")
                {
                    BlogDetail model = new BlogDetail()
                    {
                        Title = blog.Title,
                        Description = blog.Description,
                        Img = result.Result,
                        CreatedBy = blog.CreatedBy,
                        CreatedOn = DateTime.Now.ToString()
                    };
                    _context.BlogDetails.Add(model);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<string> UploadFile(IFormFile file)
        {
            try
            {
                string fName = file.FileName;
                string path = Path.Combine(_environment.ContentRootPath, "Images", fName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return path;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return "";
            }
        }

        public List<PostBlog> GetMyBlogs(string userId)
        {
            try
            {
                var result=_context.BlogDetails.Where(y => y.CreatedBy == userId).Select(x => new PostBlog()
                {
                    Title=x.Title,
                    Description=x.Description,
                    ImgPath = Convert.ToBase64String(System.IO.File.ReadAllBytes(x.Img)),
                    CreatedBy = _context.UserDetails.Where(p => p.UserId == x.CreatedBy).FirstOrDefault().UserName,
                    CreatedOn = x.CreatedOn,
                    BlogId = x.BlogId
                }).OrderByDescending(y=>y.CreatedOn).ToList();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PostBlog> GetAllBlogs()
        {
            try
            {
                var result = _context.BlogDetails.Select(x => new PostBlog()
                {
                    Title = x.Title,
                    Description = x.Description,
                    ImgPath = Convert.ToBase64String(System.IO.File.ReadAllBytes(x.Img)),
                    CreatedBy = _context.UserDetails.Where(p => p.UserId == x.CreatedBy).FirstOrDefault().UserName,
                    CreatedOn = x.CreatedOn,
                    BlogId=x.BlogId
                }).OrderByDescending(y => y.CreatedOn).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddComment(Comment cm)
        {
            try
            {
                CommentDetail model = new CommentDetail()
                {
                    CommentText = cm.CommentText,
                    BlogId = cm.BlogId,
                    CommentedBy = cm.CommentedBy,
                    CommentedOn = DateTime.Now.ToString(),
                };
                _context.CommentDetails.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Comment> GetAllComments(int blogId)
        {
            try
            {
                var result = _context.CommentDetails.Where(x => x.BlogId == blogId).Select(x => new Comment()
                {
                   CommentedOn=x.CommentedOn,
                   CommentedBy=x.CommentedBy,
                   CommentText=x.CommentText,
                   UserName= _context.UserDetails.Where(p=>p.UserId==x.CommentedBy).FirstOrDefault().UserName
                }).OrderByDescending(y => y.CommentedOn).ToList();

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PostBlog GetBlogById(int blogId)
        {
            try
            {
                return GetAllBlogs().Where(x => x.BlogId == blogId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
