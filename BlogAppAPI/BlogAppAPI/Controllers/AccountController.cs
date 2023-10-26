using BlogAppAPI.Interfaces;
using BlogAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IJwtManager _jWTManager;
        private readonly IAccount _repo;

        public AccountController(IJwtManager jWTManager,IAccount repo)
        {
            this._jWTManager = jWTManager;
            _repo = repo;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Authenticate(Login model)
        {
            var token = _jWTManager.Authenticate(model);

            if (token == null)
            {
                //return Unauthorized();
            }

            return Ok(token);
        }
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public bool Register(Register model)
        {
            var result=_repo.RegisterUser(model);
            return result;
        }
    }
}
