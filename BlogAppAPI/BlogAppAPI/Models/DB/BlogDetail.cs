using System;
using System.Collections.Generic;

#nullable disable

namespace BlogAppAPI.Models.DB
{
    public partial class BlogDetail
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
}
