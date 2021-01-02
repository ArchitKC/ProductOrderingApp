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
            return RedirectToAction("AddPage");
        }

        //GET: Admin/Pages/EditPage/Id
        [HttpGet]
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
        [HttpPost]
        public ActionResult EditPage(PagesViewModel editPageDetail)
        {
            //Check Model state
            if (!ModelState.IsValid)
            {
                return View(editPageDetail);
            }

            using (ShoppingCart db = new ShoppingCart())
            {
                // Get page id
                int id = editPageDetail.Id;

                // Init slug
                string slug = "home";

                // Get the page
                PageDTO dto = db.PagesData.Find(id);

                // DTO the title
                dto.Title = editPageDetail.Title;

                // Check for slug and set it if need be
                if (editPageDetail.Slug != "home")
                {
                    if (string.IsNullOrWhiteSpace(editPageDetail.Slug))
                    {
                        slug = editPageDetail.Title.Replace(" ", "-").ToLower();
                    }
                    else
                    {
                        slug = editPageDetail.Slug.Replace(" ", "-").ToLower();
                    }
                }

                // Make sure title and slug are unique
                if (db.PagesData.Where(x => x.Id != id).Any(x => x.Title == editPageDetail.Title) ||
                     db.PagesData.Where(x => x.Id != id).Any(x => x.Slug == slug))
                {
                    ModelState.AddModelError("", "That title or slug already exists.");
                    return View(editPageDetail);
                }

                // DTO the rest
                dto.Slug = slug;
                dto.Body = editPageDetail.Body;
                dto.HasSidebar = editPageDetail.HasSidebar;

                // Save the DTO
                db.SaveChanges();
            }

            //Set TemoData Message
            TempData["SM"] = "New values are updated";

            //Redirect
            return RedirectToAction("EditPage");
        }
    }
}