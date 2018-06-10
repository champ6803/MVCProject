using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class BookProductModel
    {
        public int book_product_id { get; set; }
        public int book_type_id { get; set; }
        public int book_category_id { get; set; }
        public string book_product_name { get; set; }
        public float book_product_price { get; set; }
        public int book_product_qty { get; set; }
        public string book_type_name { get; set; }
        public string book_category_name { get; set; }
    }
}