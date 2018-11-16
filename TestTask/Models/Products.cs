using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MarkerId { get; set; }
        public Markers Marker { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}