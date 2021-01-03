using ProductOrderingApp.Models.Data;
using ProductOrderingApp.Models.ViewModels.Shopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductOrderingApp.Areas.Admin.Controllers
{
    public class ShopController : Controller
    {
        // GET: Admin/Shop/Categories
        public ActionResult Categories()
        {
            //Declare a list of models
            List<CategoryViewModel> categoryViewModelList;

            using (ShoppingCart db = new ShoppingCart())
            {

                //Init the list
                categoryViewModelList = db.CategoryData
                                        .ToArray()
                                        .OrderBy(x => x.Sorting)
                                        .Select(x=> new CategoryViewModel(x))
                                        .ToList();
            }

            return View(categoryViewModelList);
        }
    }
}