﻿using Bread.Models;
using System.Web.Mvc;

namespace Bread.Controllers
{
    public class AccountController : Controller
    {
        private readonly Authenticator authenticator = new Authenticator();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authenticated = authenticator.Login(model.Username, model.Password);
                if (authenticated)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = authenticator.Register(model.Username, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            return View(model);
        }

        public ActionResult SignOut()
        {
            authenticator.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}