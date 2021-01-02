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

        //GET: Admin/Pages/AddPage
        [HttpGet]
        public ActionResult AddPage()
        {
            return View();
        }

        //GET: Admin/Pages/AddPage
        [HttpPost]
        public ActionResult AddPage(PagesViewModel pageAddData)
        {
            //Check Model State
            if (!ModelState.IsValid)
            {
                return View(pageAddData);
            }

            using (ShoppingCart db = new ShoppingCart())
            {          
                //Declare Slug
                string slug;

                //InitDTO
                PageDTO pageDto = new PageDTO();

                //DTO Title
                pageDto.Title = pageAddData.Title;

                //Check for and set slug if needed
                if (string.IsNullOrWhiteSpace(pageAddData.Slug))
                {
                    slug = pageAddData.Title.Replace(" ", "-").ToLower();
                }
                else
                {
                    slug = pageAddData.Slug.Replace(" ", "-").ToLower();
                }

                //Make sure the title and slug are unique
                if (db.PagesData.Any(x => x.Title == pageAddData.Title) ||
                                     db.PagesData.Any(x=>x.Slug == slug))
                {
                    ModelState.AddModelError("", "The Title or the Slug already exists");
                    return View(pageAddData);
                }

                //DTO the rest
                pageDto.Slug = slug;
                pageDto.HasSidebar = pageAddData.HasSidebar;
                pageDto.Body = pageAddData.Body;
                pageDto.Sorting = 100;

                //Save DTO
                db.PagesData.Add(pageDto);
                db.SaveChanges();

            }

            //Set TempData Message
            TempData["SM"] = "The page has been added";
            //Redirect
            return RedirectToAction("Index");
        }

        //GET: Admin/Pages/EditPage/Id
        public ActionResult EditPage(int id)
        {
            //Declare pageViewModel
            PagesViewModel pageVM;

            using (ShoppingCart db = new ShoppingCart())
            {
                //Get the page
                PageDTO pagedto = db.PagesData.Find(id);

                //Confirm the page exists
                if (pagedto != null)
                {                
                    //Init pageViewModel
                    pageVM = new PagesViewModel(pagedto);
                }
                else
                {
                    return Content("The page doesn't exists");
                }
            }

            //Return view with model
            return View(pageVM);
        }

        //POST: Admin/Pages/EditPage/Id
        public ActionResult EditPage(PagesViewModel editPageDetail)
        {
            //Check Model state

            //Get pageId

            //Declare slug

            //Get the page

            //DTO the title

            //Check for slug and set if needed

            //Make sure the title and slug are unique

            //DTO the rest

            //Save the DTO

            //Set TemoData Message

            //Redirect
            return View();
        }
    }
}