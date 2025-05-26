using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroAPI.DOTs;
using SuperheroAPI.Entites;
using SuperheroAPI.Interfaces;
using SuperheroAPI.Repositories;
using SuperheroAPI.Service;

namespace SuperheroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser>userManager , ITokenService tokenService , SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized("Invalid username or password");

            var token = _tokenService.CreateToken(user);

            return Ok(new
            {
                username = user.UserName,
                email = user.Email,
                token = token
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appuser = new AppUser
            {
                UserName = registerDto.Username,
                Email = registerDto.EmailAddress
            };

            var result = await _userManager.CreateAsync(appuser, registerDto.Password!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Errors = errors });
            }

            return Ok(
                new NewUserDto
                {
                    UserName = appuser.UserName,
                        Email = appuser.Email,
                        Token = _tokenService.CreateToken(appuser)

                }
                
                );
        }

    }


}


