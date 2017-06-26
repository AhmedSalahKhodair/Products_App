using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductApps.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

    }
}