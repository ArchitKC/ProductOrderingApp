﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductOrderingApp.Models.Data
{
    public class ShoppingCart : DbContext
    {
        public DbSet<PageDTO> PagesData { get; set; }
        public DbSet<SideBarDTO> SideBarData { get; set; }
    }
}