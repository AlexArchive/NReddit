using System.Net.Mime;
using Microsoft.AspNet.Identity;
using NReddit.Data;
using NReddit.Data.Model;
using NReddit.Models;
using System.Linq;
using System.Web.Mvc;

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
                           .ThenBy(post => post.Id)
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

        public ActionResult IsUsernameAvailable(string username)
        {
            using (var context = new ApplicationDbContext())
            {
                var usernameAvailable = !context.Users.Any(user => user.UserName == username);
                return Json(usernameAvailable, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize]
        public ActionResult Post()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Post(PostInputModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            using (var context = new ApplicationDbContext())
            {
                var post = new Post();
                post.Title = model.Title;
                post.Tagline = model.Tagline;
                post.Link = model.Link;

                context.Posts.Add(post);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}