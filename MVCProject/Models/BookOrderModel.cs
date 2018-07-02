using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class BookOrderModel
    {
        public int book_order_id { get; set; }
        public int cus_id { get; set; }
        public string book_status_code { get; set; }
        public float book_order_total { get; set; }
        public DateTime book_order_date {get;set;}

    }
}