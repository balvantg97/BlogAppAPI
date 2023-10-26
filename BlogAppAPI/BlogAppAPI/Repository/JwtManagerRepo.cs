using BlogAppAPI.Interfaces;
using BlogAppAPI.Models;
using BlogAppAPI.Models.DB;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppAPI.Repository
{
    public class JwtManagerRepo: IJwtManager
    {
        private readonly BlogAppDBContext _context;

        private readonly IConfiguration iconfiguration;
        public JwtManagerRepo(BlogAppDBContext context,IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
            _context = context;
        }
        public Tokens Authenticate(Login model)
        {
            if (!_context.UserDetails.Any(x => x.UserName == model.Username && x.Password == model.Password))
            {
                return null;
            }
            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, model.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var TokenDetails = _context.UserDetails.Where(x => x.UserName == model.Username && x.Password == model.Password).Select(x => new Tokens()
            {
                UserId = x.UserId,
                FirstName = x.FirstName,
                Token = tokenHandler.WriteToken(token)
            }).FirstOrDefault();

            return TokenDetails;
        }
    }
}
