using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NReddit.Data;
using NReddit.Data.Model;
using System.Linq;
using System.Web.Mvc;

namespace NReddit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var database = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                List<Post> viewModel = new List<Post>();

                foreach (var post in database.Posts)
                {
                    if (post.UsersWhoVoted.Any(user => user.Id == userId))
                    {
                        post.Voted = true;
                    }
                    viewModel.Add(post);
                }

                return View(viewModel);
            }
        }

        [Authorize]
        public JsonResult Vote(int id)
        {
            using (var database = new ApplicationDbContext())
            {
                var model = database.Posts.Find(id);
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(database));
                var user = manager.FindById(User.Identity.GetUserId());

                if (model == null)
                {
                    // error..
                }

                bool alreadyVoted = model.UsersWhoVoted.Any(u => u.Id == user.Id);

                if (alreadyVoted)
                {
                    model.Score -= 1;
                    model.UsersWhoVoted.Remove(user);
                    database.SaveChanges();

                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }

                model.Score += 1;
                model.UsersWhoVoted.Add(user);

                database.SaveChanges();
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}