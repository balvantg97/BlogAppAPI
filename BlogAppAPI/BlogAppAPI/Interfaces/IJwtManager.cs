using BlogAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Interfaces
{
    public interface IJwtManager
    {
       Tokens Authenticate(Login users);
    }
}
