﻿using AutoMapper;
using FeedbackApi.DTOs.User;
using FeedbackApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userLoginDto.Password))
                return Unauthorized();

            var mappedUser = _mapper.Map<UserDto>(user);

            return Ok(mappedUser);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var user = new User { UserName = userRegisterDto.Username, Email = userRegisterDto.Email, Name = userRegisterDto.Name };

            var result = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return ValidationProblem();
            }

            await _userManager.AddToRoleAsync(user, "User");

            return StatusCode(201);
        }
    }
}
