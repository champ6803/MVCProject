using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class BookTypeModel
    {
        public int book_type_id { get; set; }
        public string book_type_name { get; set; }
        public bool state { get; set; }
    }
}