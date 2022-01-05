using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleTracker.Authentication.Interface;
using VehicleTracker.Authentication.Service;
using VehicleTracker.Models;
using VehicleTracker.Repository;
using VehicleTracker.ViewModels;

namespace VehicleTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly RegisterService _regService;

        private readonly IToken _tokenService;

        public AccountController(RegisterService serv, IToken service)
        {
            _regService = serv;
            _tokenService = service;
        }


        [HttpPost]
        [Authorize(Policy = "Admin")]
        [Route("Registeruser")]
        public IActionResult Register(RegisterUserViewModel userModel)
        {
            
            if (ModelState.IsValid)
            {
                if (_regService.UserExists(userModel.username))
                {
                    return UnprocessableEntity(new { message = "Username exists" });
                }
                var result = _regService.CreatUser(userModel);
                string toks = _tokenService.CreateToken(result, userModel.isAdmin ? true : false);
                return Ok(new { token = toks, username = result.Username });
            }

            return BadRequest(new { message = "Model validation failed, kindly fill all the fields." });
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_regService.UserExists(model.userName))
                {
                    bool isAdmin = false;
                    ApplicationUser user = null;

                    (isAdmin, user) = _regService.SignInUser(model);
                    string toks = _tokenService.CreateToken(user, isAdmin ? true : false);
                    return Ok(new { token = toks, username = user.Username });
                }

                return UnprocessableEntity(new { message = "Username does not exist"});
                
            }

            return BadRequest(new { message = "Model validation failed, kindly fill all the fields." });
        }
    }
}
