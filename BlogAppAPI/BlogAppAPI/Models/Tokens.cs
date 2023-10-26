using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Models
{
    public class Tokens
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string RefreshToken { get; set; }
    }
}
