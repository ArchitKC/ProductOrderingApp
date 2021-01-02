using ProductOrderingApp.Models.Data;
using ProductOrderingApp.Models.ViewModels.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProductOrderingApp.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        // GET: Admin/Pages
        public ActionResult Index()
        {

            List<PagesViewModel> pageLists;


            using(ShoppingCart db = new ShoppingCart())
            {
                pageLists = db.PagesData.ToArray()
                    .OrderBy(x=>x.Sorting)
                    .Select(x=>new PagesViewModel(x))
                    .ToList();
            }
            //Return view with list
            return View(pageLists);
        }
    }
}