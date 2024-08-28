using Microsoft.AspNetCore.Mvc.ModelBinding;
using TunifyDb2.Models.DTO;


namespace TunifyPlatform.Repositories.Interfaces
{
    public interface IAccounts
    {
        public Task<AccountDto> Register(RegisterDto registerDto, ModelStateDictionary modelState);

        public Task<AccountDto> UserAuthentication(string username, string password);
        Task Logout();
    }
}