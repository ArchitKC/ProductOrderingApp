﻿using ProductOrderingApp.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductOrderingApp.Models.ViewModels.Shopping
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {

        }

        public CategoryViewModel(CategoryDTO categoryDTO)
        {
            Id = categoryDTO.Id;
            Name = categoryDTO.Name;
            Slug = categoryDTO.Slug;
            Sorting = categoryDTO.Sorting;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; }
    }
}