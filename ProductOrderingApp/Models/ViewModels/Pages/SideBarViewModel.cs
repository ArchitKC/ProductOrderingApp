using ProductOrderingApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public string Body { get; set; }
    }

}