using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using NReddit.Data;

namespace NReddit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var database = new ApplicationDbContext())
            {
                var model = database.FeedItems.ToList();
                return View(model);
            }
        }

        [Authorize]
        public JsonResult Vote(int id)
        {
            using (var database = new ApplicationDbContext())
            {
                var model = database.FeedItems.Find(id);

                if (model == null)
                {
                    // error..
                }

                model.Votes += 1;
                database.SaveChanges();
                return Json(new { Success = true, NewScore = model.Votes }, JsonRequestBehavior.AllowGet);
            }


        }
    }
}