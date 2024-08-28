using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Models;
using TunifyDb2.Models.DTO;
using TunifyDb2.Repositories.Interfaces;
using TunifyPlatform.Repositories.Interfaces;


namespace TunifyPlatform.Repositories.Services
{
    public class IdentityAccountService : IAccounts
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public IdentityAccountService(UserManager<ApplicationUser> Manager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = Manager;
            _signInManager = signInManager;
        }
        public async Task<AccountDto> Register(RegisterDto registerDto, ModelStateDictionary modleState)
        {
            var user = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    UserName = user.UserName

                };
            }

            //detect type of error
            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("password") ? nameof(registerDto) :
                                error.Code.Contains("Email") ? nameof(registerDto) :
                                error.Code.Contains("Username") ? nameof(registerDto) : "";
                modleState.AddModelError(errorCode, error.Description);
            }
            return null;
        }

        public async Task<AccountDto> UserAuthentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);
            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            return null;
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}