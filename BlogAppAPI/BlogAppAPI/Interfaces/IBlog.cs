using BlogAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Interfaces
{
    public interface IBlog
    {
        bool PostNewBlog(PostBlog blog);
        List<PostBlog> GetMyBlogs(string userId);
        bool AddComment(Comment cm);
        List<PostBlog> GetAllBlogs();
        List<Comment> GetAllComments(int blogId);
        PostBlog GetBlogById(int blogId);
    }
}
