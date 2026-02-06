using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
 
namespace dotnetapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _um;
        private readonly SignInManager<IdentityUser> _sm;
       
 
        public AccountController(UserManager<IdentityUser> u,SignInManager<IdentityUser> s)
        {
            _um = u;
            _sm= s;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser{UserName = model.Email,Email=model.Email};
                var result = await _um.CreateAsync(user,model.Password);
                if(result.Succeeded)
                  return RedirectToAction("Login");
            }
            return View(model);
        }
 
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
             if(ModelState.IsValid)
            {
                var result = await _sm.PasswordSignInAsync(
                    model.Email,model.Password,false,false
                );
                if(result.Succeeded)
                  return RedirectToAction("Index");
            }
            return View(model);
           
        }
        public async Task<IActionResult> Logout()
        {
            await _sm.SignOutAsync();
            return RedirectToAction("Login");
        }
       
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
 
