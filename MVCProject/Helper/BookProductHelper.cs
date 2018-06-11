using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Libraries;

namespace MVCProject.Helper
{
    public class BookProductHelper
    {
        public List<BookProductModel> GetBookProductList()
        {
            List<BookProductModel> list = new BookProductLibrary().GetBookProductList();
            return list;
        }

        public bool AddBookProduct(BookProductModel bookProd)
        {
            return new BookProductLibrary().AddBookProduct(bookProd);
        }

    }
}