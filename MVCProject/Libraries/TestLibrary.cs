using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Entities;
using MVCProject.Models;

namespace MVCProject.Libraries
{
    public class TestLibrary
    {
        mvc_projectEntities db = new mvc_projectEntities();

        public IQueryable<book_category> IQueryableBookCate()
        {
            return db.book_category;
        }
        public List<BookCategoryModel> GetBookCategoryList()
        {
            try
            {
                List<book_category> bookcateDB = IQueryableBookCate().ToList();
                List<BookCategoryModel> bookList = new List<BookCategoryModel>();
                foreach(book_category b in bookcateDB)
                {
                    BookCategoryModel bookModel = new BookCategoryModel();
                    bookModel.book_category_id = b.book_category_id;
                    bookModel.book_category_name = b.book_category_name;
                    bookList.Add(bookModel);
                }
                return bookList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}