using System;
using System.Threading;
using Microsoft.AspNet.Identity;
using NReddit.Database;
using NReddit.Database.Models;
using NReddit.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NReddit.Controllers
{
    public class HomeController : Controller
    {
        private const int PageSize = 16;

        public ActionResult Index()
        {
            return View(LoadPosts());
        }

        public ActionResult InfiniteScroll(int pageNumber)
        {
            if (Request.IsAjaxRequest())
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));

                var posts = LoadPosts(pageNumber);
                
                var data = new
                {
                    Posts = posts,
                    Finished = posts.Count() < PageSize
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }

            return HttpNotFound();
        }

        private IEnumerable<PostViewModel> LoadPosts(int pageNumber = 0)
        {

            using (var context = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();

                var query =
                    context.Posts
                           .OrderByDescending(post => post.Votes)
                           .ThenByDescending(post => post.Id)
                           .Skip(PageSize * pageNumber)
                           .Take(PageSize)
                           .Select(post => new PostViewModel
                           {
                               Id = post.Id,
                               Link = post.Link,
                               Title = post.Title,
                               Score = post.Votes,
                               Tagline = post.Tagline,
                               Voted = post.UsersWhoVoted.Any(user => user.Id == userId)
                           });

                return query.ToList();
            }
        }

        public ActionResult Vote(int id)
        {
            if (!Request.IsAuthenticated)
            {
                return Json(new { Success = false, Message = "Not authenticated." }, JsonRequestBehavior.AllowGet);
            }

            using (var context = new ApplicationDbContext())
            {
                var post = context.Posts.Find(id);

                if (post == null)
                { 
                    return Json(new { Success = false, Message = "Post does not exist." }, JsonRequestBehavior.AllowGet);
                }

                var user = context.Users.Find(User.Identity.GetUserId());
                var alreadyVoted = post.UsersWhoVoted.Any(u => u.Id == user.Id);

                if (alreadyVoted)
                {
                    post.Votes -= 1;
                    post.UsersWhoVoted.Remove(user);
                    context.SaveChanges();

                    return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
                }

                post.Votes += 1;
                post.UsersWhoVoted.Add(user);
                context.SaveChanges();

                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
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