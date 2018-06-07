using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class CustomerModel
    {
        public int cus_id { get; set; }
        public string cus_name { get; set; }
        public int cus_age { get; set; }
        public string cus_address { get; set; }
        public bool state { get; set; }
    }
}