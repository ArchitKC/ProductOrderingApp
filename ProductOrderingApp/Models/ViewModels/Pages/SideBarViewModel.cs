using ProductOrderingApp.Models.Data;
using System.Web.Mvc; 

namespace ProductOrderingApp.Models.ViewModels.Pages
{
    public class SideBarViewModel
    {
        public SideBarViewModel()
        {

        }

        public SideBarViewModel(SideBarDTO sideBarDTO)
        {
            Id = sideBarDTO.Id;
            Body = sideBarDTO.Body;

        }
        public int Id { get; set; }

        [AllowHtml]
        public string Body { get; set; }
    }

}