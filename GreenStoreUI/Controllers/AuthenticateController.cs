using App.Domain.Core.Products.Entities;
using App.Domain.Core.Users.Dtos.Authenticate;
using App.Domain.Core.Users.Entities;

using EShop.ViewModels.Authenticate;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Composition;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GreenStoreUI.Controllers
{
    public class AuthenticateController : Controller
    {

       
        protected readonly SignInManager<ApplicationUser> signInManager;
        protected readonly UserManager<ApplicationUser> userManager;
        public AuthenticateController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
         
        }


        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public async Task<ActionResult> Register(ApplicationUser registerModel, CancellationToken cancellationToken)
        ////{
        ////    if (!ModelState.IsValid)
        ////        return View(registerModel);

        ////    try
        ////    {

        ////        var user = new ApplicationUser();
        ////        user = new ApplicationUser
        ////        {
                    
        ////            UserName = registerModel.Email,
        ////            Email = registerModel.Email,
        ////            Seller=registerModel.Seller
                   
        ////        };


        ////        var UserId = await userManager.CreateAsync()


        ////        if (UserId != 0 && registerModel.IsAdmin)
        ////        {

        ////            AdminAddDto adminDto = new AdminAddDto
        ////            {
        ////                Id = UserId,
        ////                FirstName = registerModel.FirstName,
        ////                LastName = registerModel.LastName,
        ////                Address = registerModel.Address
        ////            };
        ////            var Result = await adminRepository.Create(adminDto);
        ////            return RedirectToAction("Index", "Home");
        ////        }
        ////        else if (UserId != 0 && !registerModel.IsAdmin)
        ////        {
        ////            CustomerAddDto customerDto = new CustomerAddDto
        ////            {
        ////                Id = UserId,
        ////                Name = registerModel.FirstName,
        ////                LastName = registerModel.LastName,
        ////                Address = registerModel.Address
        ////            };
        ////            var Result = await customerRepository.Create(customerDto);
        ////            return RedirectToAction("Index", "Home");

        ////        }
        ////        else
        ////        {
        ////            return View();
        ////        }



        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        ModelState.AddModelError("", ex.Message);
        ////        return View();
        ////    }


        ////}

        //[AllowAnonymous]
        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginViewModel LoginModel, CancellationToken cancellationToken)
        //{
        //    if (!ModelState.IsValid)
        //        return View(LoginModel);

        //    UserLoginDto userLogin = new UserLoginDto
        //    {
        //        Email = LoginModel.Email,
        //        Password = LoginModel.Password,
        //        IsPersistent = LoginModel.RememberMe
        //    };

        //    var result = await userRepository.Login(userLogin, cancellationToken);

        //    IList<string> roles = null;
        //    if (result.Succeeded)
        //    {
        //        var user = await userManager.FindByNameAsync(userLogin.Email);
        //        roles = await userManager.GetRolesAsync(user);
        //    }


        //    //var result = await authenticate.Login(LoginModel);

        //    if (result != null)
        //    {
        //        if (result != null && roles.Contains("Customer"))
        //            return RedirectToAction("index", "Home");
        //        else
        //            return RedirectToAction("index", "Panel", new { area = "Admin" });

        //    }
        //    else
        //    {
        //        return View(LoginModel);
        //    }

        //}


        //[HttpPost]
        //public async Task<ActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("Index", "Home");
        //}



    }
}
