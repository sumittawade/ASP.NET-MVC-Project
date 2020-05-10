using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace CURDOperationWithMVC.Models
{
    public class ProductModel
    {
        [DisplayName("Product ID")]
        public int ProductID { get; set; }

        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [DisplayName("Price")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Product In Stock")]
        public int UnitsInStock { get; set; }
    }
}