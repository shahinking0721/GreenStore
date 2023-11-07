using App.Domain.Core.Users.Dtos;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Services.Users
{
    public interface IAuthenticateServices
    {
        Task<IdentityResult?> CreateUser(RegisterDto registerModel);
        Task<SignInResult?> LoginUser(LoginDto LoginModel);

    }


    public class AuthenticateServices : IAuthenticateServices
    {
        protected readonly UserManager<IdentityUser> userManager;
        protected readonly SignInManager<IdentityUser> signInManager;

        public AuthenticateServices(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        public async Task<IdentityResult?> CreateUser(RegisterDto registerModel)
        {
            var user = new IdentityUser { Email = registerModel.Email, UserName = registerModel.Email };
            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task<SignInResult?> LoginUser(LoginDto LoginModel)
        {
            var result = await signInManager.PasswordSignInAsync(LoginModel.Email, LoginModel.Password, LoginModel.RememberMe, false);
            return result;
        }
    }
}
