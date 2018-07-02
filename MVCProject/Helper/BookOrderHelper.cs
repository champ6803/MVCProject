using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Libraries;
using MVCProject.Models;

namespace MVCProject.Helper
{
    public class BookOrderHelper
    {
        public bool AddBookOrder(BookOrderModel m, List<BookOrderDetailModel> list)
        {
            return new BookOrderLibrary().AddBookOrder(m,list);
        }
        public bool AddBookDetailOrder(BookOrderModel id, List<BookOrderDetailModel> bookDetail)
        {
            return new BookOrderLibrary().AddBookOrder(id, bookDetail);
        }
        public bool UpdateStockBookProduct(List<BookOrderDetailModel> bookDetail)
        {
            return new BookOrderLibrary().UpdateStockBookProduct(bookDetail);
        }
    }
}