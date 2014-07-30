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
    }
}