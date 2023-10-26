using BlogAppAPI.Interfaces;
using BlogAppAPI.Models;
using BlogAppAPI.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Repository
{
    public class AccountRepo : IAccount
    {
        private readonly BlogAppDBContext _context;
        public AccountRepo(BlogAppDBContext context)
        {
            _context = context;
        }
        public bool RegisterUser(Register model)
        {
            try
            {
                UserDetail userDetail = new UserDetail()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password,
                    UserName = model.UserName,
                    UserId = Guid.NewGuid().ToString(),
                    LastUpdated = DateTime.Now.ToString()

                };
                _context.UserDetails.Add(userDetail);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }
    }
}
