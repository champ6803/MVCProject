using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Libraries;
using MVCProject.Models;

namespace MVCProject.Helper
{
    public class BookCateTypeHelper
    {
        public List<BookCategoryModel> GetBookCate()
        {
            return new BookCateTypeLibrary().GetBookCategoryList();
        }

        public List<BookTypeModel> GetBookType()
        {
            return new BookCateTypeLibrary().GetBookTypeList();
        }

        public bool AddBookCateList(BookCategoryModel m)
        {
            return new BookCategoryLibrary().AddBookCategory(m);
        }

        public bool AddBookTypeList(BookTypeModel m)
        {
            return new BookCateTypeLibrary().AddBookType(m);
        }

        public bool DeleteCateList(List<BookCategoryModel> m)
        {
            return new BookCateTypeLibrary().DeleteBookCate(m);
        }

        public bool DeleteBookTypeList(List<BookTypeModel> bookTypeList)
        {
            return new BookCateTypeLibrary().DeleteBookType(bookTypeList);
        }

        public bool UpdateCate(BookCategoryModel bookCate)
        {
            return new BookCateTypeLibrary().UpdateCate(bookCate);
        }
        public bool UpdateType(BookTypeModel bookType)
        {
            return new BookCateTypeLibrary().UpdateType(bookType);
        }
    }
}