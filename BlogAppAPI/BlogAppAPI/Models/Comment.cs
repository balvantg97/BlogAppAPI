using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Models
{
    public class Comment
    {
        public string CommentText { get; set; }
        public string ReplyText { get; set; }
        public int BlogId { get; set; }
        public string CommentedBy { get; set; }
        public string CommentedOn { get; set; }
        public string UserName { get; set; }
    }
}
