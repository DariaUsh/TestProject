using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class DataBaseContext: DbContext
    {
        public DbSet<Products> ProductsList { get; set; }
        public DbSet<Markers> MarkersList { get; set; }
    }
}