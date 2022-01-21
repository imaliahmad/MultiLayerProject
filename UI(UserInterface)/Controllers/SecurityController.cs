using BOL_BusinessObjectLayer_;
using DAL_DataAccessLayer_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_UserInterface_.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly SignInManager<AppUsers> signInManager;
        private readonly AppDbContext context;
        public SecurityController(UserManager<AppUsers> _userManager, SignInManager<AppUsers> _signInManager, AppDbContext _context)
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
        }

        //Register, Login, Logout
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUsers model)
        {
            try
            {
                //sync call and async call
                if (ModelState.IsValid)
                {
                    // Create User
                  var createResult =  await userManager.CreateAsync(model, model.Password);
                    if (createResult.Succeeded)
                    {
                        // Assign Role --> Admin, User, Customer, Manager

                        //Default --> Roles, Status, Company, User (Admin, Manager) --> Data Seed

                        var roleResult = await userManager.AddToRoleAsync(model, "Customer");
                        if (roleResult.Succeeded)
                        {
                            //Login --> redirect home page
                            var isLogin = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                            if (isLogin.Succeeded)
                            {
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["ErrorMsg"] = "Login failed.";
                                return View();
                            }
                           
                        }
                        else
                        {
                            TempData["ErrorMsg"] = "Role Assign failed.";
                            return View();
                        }
                    }
                    else
                    {
                        TempData["ErrorMsg"] = $"Create new user failed. {createResult.Errors.FirstOrDefault().Description.ToString()}";
                        return View();
                    }
                }
                else
                {
                    //validation error message
                    //viewbag, viewdata, tempdata
                   
                    return View();
                }
            }
            catch (Exception ex)
            {
                //send error msg
                TempData["ErrorMsg"] = $"Error: { ex.Message}";
                return View();
            }
           
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Login(AppUsers model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = context.AppUsers.Where(x => x.Email == model.Email).FirstOrDefault();
                    var result = await signInManager.PasswordSignInAsync(obj.UserName, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["ErrorMsg"] = "Email/Password is incorrect.";
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                //send error msg
                TempData["ErrorMsg"] = $"Error: { ex.Message}";
                return View();
            }

         
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
