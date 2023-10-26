using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Models
{
    public class PostBlog
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Img { get; set; }
        public string ImgPath { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public int BlogId { get; set; }

    }
}
