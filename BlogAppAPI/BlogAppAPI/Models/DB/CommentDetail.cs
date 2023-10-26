using System;
using System.Collections.Generic;

#nullable disable

namespace BlogAppAPI.Models.DB
{
    public partial class CommentDetail
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public string ReplyText { get; set; }
        public int? BlogId { get; set; }
        public string CommentedBy { get; set; }
        public string CommentedOn { get; set; }
    }
}
