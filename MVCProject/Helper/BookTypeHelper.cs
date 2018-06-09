using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Libraries;
using MVCProject.Models;

namespace MVCProject.Helper
{
    public class BookTypeHelper
    {
        public List<BookTypeModel> GetBookTypeList()
        {
            List<BookTypeModel> list = new BookTypeLibrary().GetBookTypeList();
            return list;
        }

        public bool AddBookType(BookTypeModel book)
        {
            return new BookTypeLibrary().AddBookType(book);
        }

        public bool DeleteBookTypeList(List<BookTypeModel> book_typeList)
        {
            return new BookTypeLibrary().DeleteBookType(book_typeList);
        }
    }
}