using Relearn_MVC_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Relearn_MVC_CRUD.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Relearn_MVC_CRUD")
        {

        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}