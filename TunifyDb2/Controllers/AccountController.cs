using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TunifyDb2.Models.DTO;
using TunifyDb2.Repositories.Interfaces;
using TunifyPlatform.Repositories.Interfaces;

namespace TunifyPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccounts _userService;

        public AccountController(IAccounts context)
        {
            _userService = context;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterDto registerDto)
        {
            var user = await _userService.Register(registerDto, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            if (user == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }


        [HttpPost("login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var user = await _userService.UserAuthentication(loginDto.UserName, loginDto.Password);

            //check if user not null
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return Ok();
        }

    }

}