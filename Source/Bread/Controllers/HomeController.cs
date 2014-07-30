using System.Linq;
using System.Web.Mvc;
using Bread.Data;

namespace Bread.Controllers
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