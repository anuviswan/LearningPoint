using JwtExample.Dtos;
using JwtExample.Models;
using JwtExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController:ControllerBase 
    {
        private string generatedToken = null;
        private readonly ITokenService _tokenService;
        private readonly IUserRepositoryService _userRepositoryService;
        private readonly IConfiguration _configuration; 
        public HomeController(ITokenService tokenService,IUserRepositoryService userRepositoryService,IConfiguration config )
        {
            _tokenService = tokenService;
            _userRepositoryService = userRepositoryService;
            _configuration = config;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public ActionResult Login(UserModel userModel)
        {
            if(string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return RedirectToAction("Error");
            }

            IActionResult response = Unauthorized();
            var user = GetUser(userModel);

            if(user != null)
            {
                generatedToken = _tokenService.BuildToken(_configuration["Jwt:Key"].ToString(), _configuration["Jwt:Issuer"].ToString(), user);
                return Ok(new
                {
                    token = generatedToken,
                    user = user.UserName
                });

            }
            return RedirectToAction("Error");
        }


        [Authorize]
        [Route("Secret")]
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ActionResult SecretFunction()
        {
            return Ok("Alright, you are authorized user");
        }

        private UserDto GetUser(UserModel userModel)
        {
            return new UserDto("Jia", "admin", "admin");
           
        }
    }
}
