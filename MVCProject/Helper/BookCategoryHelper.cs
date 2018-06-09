using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Libraries;

namespace MVCProject.Helper
{
    public class BookCategoryHelper
    {
        public List<BookCategoryModel> GetBookCategory()
        {
            List<BookCategoryModel> list = new BookCategoryLibrary().GetBookCategoryList();
            return list;
        }
        public bool AddBookCategory(BookCategoryModel bookCategory)
        {
            return new BookCategoryLibrary().AddBookCategory(bookCategory);
        }
        public bool DeleteBookCategoryList(List<BookCategoryModel> bookCategoryList)
        {
            return new BookCategoryLibrary().DeleteBookCategoryList(bookCategoryList);
        }
    }
}