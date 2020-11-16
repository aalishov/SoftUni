using SharedTrip.Services;
using SharedTrip.ViewModels.UserVM;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterUserVM vM)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(vM.Username) || vM.Username.Length < 5 || vM.Username.Length > 20)
            {
                return Error("Username must be between 5 and 20 symbols!");
            }
            if (!new EmailAddressAttribute().IsValid(vM.Email))
            {
                return Error("Email is not valid!");
            }
            if (string.IsNullOrWhiteSpace(vM.Password) || vM.Password.Length < 6 || vM.Password.Length > 20)
            {
                return Error("Password must be between 5 and 20 symbols!");
            }
            if (vM.Password != vM.ConfirmPassword)
            {
                return Error("Passwords don't mach!");
            }
            userService.CreateUser(vM);
            return Redirect("/Users/Login");
        }

    }
}
