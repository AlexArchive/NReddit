using Microsoft.AspNet.Identity;
using NReddit.Data;
using NReddit.Data.Model;
using System.Linq;
using System.Web.Mvc;
using NReddit.Models;

namespace NReddit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                var query =
                    context.Posts
                           .OrderByDescending(post => post.Score)
                           .Select(post => new PostViewModel
                           {
                               Id = post.Id,
                               Link = post.Link,
                               Title = post.Title,
                               Score = post.Score,
                               Tagline = post.Tagline,
                               Voted = post.UsersWhoVoted.Any(user => user.Id == userId)
                           });

                return View(query.ToList());
            }
        }

        [Authorize]
        public ActionResult Vote(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var post = context.Posts.Find(id);

                if (post == null)
                {
                    return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
                }

                var user = context.Users.Find(User.Identity.GetUserId());
                var alreadyVoted = post.UsersWhoVoted.Any(u => u.Id == user.Id);

                if (alreadyVoted)
                {
                    post.Score -= 1;
                    post.UsersWhoVoted.Remove(user);
                    context.SaveChanges();

                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }

                post.Score += 1;
                post.UsersWhoVoted.Add(user);
                context.SaveChanges();

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}