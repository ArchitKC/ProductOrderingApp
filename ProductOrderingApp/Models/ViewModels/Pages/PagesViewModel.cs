using ProductOrderingApp.Models.Data;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProductOrderingApp.Models.ViewModels.Pages
{
    public class PagesViewModel
    {
        public PagesViewModel()
        {

        }

        public PagesViewModel(PageDTO pageData)
        {
            Id = pageData.Id;
            Title = pageData.Title;
            Slug = pageData.Slug;
            Body = pageData.Body;
            Sorting = pageData.Sorting;
            HasSidebar = pageData.HasSidebar;
        }
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength =5)]
        public string Title { get; set; }
        public string Slug { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 5)]        
        [AllowHtml]
        public string Body { get; set; }
        public int Sorting { get; set; }
        public bool HasSidebar { get; set; }

    }
}