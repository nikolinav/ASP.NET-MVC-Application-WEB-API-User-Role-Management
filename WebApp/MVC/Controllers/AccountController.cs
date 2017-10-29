using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Model;
using Service.Interface;
using Data.ClientConection;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Data.Entity.Infrastructure;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {

        public IUserAccountRepository _repository;

        public AccountController(IUserAccountRepository repository)
        {
            _repository = repository;
        }

        public AccountController()
        {
         
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            
            if (ModelState.IsValid)
            {
                UserClient UC = new UserClient();
                UC.Register(account);

                 
                ViewBag.Message = account.FirstName + " " + account.LastName + "successfully registered.";

            }
            return View("Login");
        }
        [Authorize]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View(new UserAccountDto());
        }

        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        public ActionResult Login(UserAccountDto user, string returnUrl)
        {

            UserClient UC = new UserClient();
            var viewModel = UC.Login(user);
            bool result = UC.CheckLogin(user);

            if (ModelState.IsValid) { 
               
                
               
                if (result == true)
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                        return Redirect(returnUrl ?? Url.Action("Index", "User"));
                }

            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong.");
            }

            return View();
        }


    }
}
