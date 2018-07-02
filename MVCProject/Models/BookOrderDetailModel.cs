using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class BookOrderDetailModel
    {
        public int book_order_detail_id { get; set; }
        public int book_order_id { get; set; }
        public int book_product_id { get; set; }
        public float book_order_detail_price { get; set; }
        public int book_order_detail_qty { get; set; }
    }
}