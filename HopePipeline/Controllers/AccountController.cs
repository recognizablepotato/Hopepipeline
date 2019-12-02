﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HopePipeline.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

       [Route("login")]
       [HttpPost]

        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null && username.Equals("ccr") && password.Equals("123"))
            {
                HttpContext.Session.SetString("username", username);
                return View("../Home/Referral");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("../Home/Index");
            }
        }

        [Route("logout")]
        [HttpGet]

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}
