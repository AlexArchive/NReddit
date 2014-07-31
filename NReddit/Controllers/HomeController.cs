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
                var model = database.Posts.ToList();
                return View(model);
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
                    return Json(new { Success = false, Message = "You have already voted on this post." }, JsonRequestBehavior.AllowGet);
                }

                model.Score += 1;
                model.UsersWhoVoted.Add(user);

                database.SaveChanges();
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}