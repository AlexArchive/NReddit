using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using NReddit.Data;
using NReddit.Data.Model;

namespace NReddit
{
    public class Authenticator
    {
        private UserManager<ApplicationUser> UserManager
        {
            get
            {
                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                return new UserManager<ApplicationUser>(store);
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        public IdentityResult Register(string username, string password)
        {
            var user = new ApplicationUser { UserName = username };
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

        public void Authenticate(ApplicationUser user, bool persistent)
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