﻿using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NReddit.Database;
using NReddit.Database.Models;

namespace NReddit.Authentication
{
    public class Authenticator
    {
        private UserManager<User> UserManager
        {
            get
            {
                var store = new UserStore<User>(new ApplicationDbContext());
                return new UserManager<User>(store);
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public IdentityResult Register(string username, string password)
        {
            var user = new User { UserName = username };
            var result = UserManager.Create(user, password);

            if (result.Succeeded)
            {
                Authenticate(user, false);
            }

            return result;
        }

        public bool Login(string username, string password, bool persistant = false)
        {
            var user = UserManager.Find(username, password);

            if (user != null)
            {
                Authenticate(user, persistant);
                return true;
            }

            return false;
        }

        public void Authenticate(User user, bool persistent)
        {
            var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            var authenticationProperties = new AuthenticationProperties { IsPersistent = persistent };
            AuthenticationManager.SignIn(authenticationProperties, identity);
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut();
        }
    }
}