using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Entities;
using MVCProject.Models;

namespace MVCProject.Libraries
{
    public class BookCategoryLibrary
    {

        mvc_projectEntities dbh = new mvc_projectEntities();
        private List<book_category> objList;

        internal BookCategoryModel Mapping(book_category o)
        {
            try
            {
                if (o != null)
                {
                    return new BookCategoryModel()
                    {
                        book_category_id = o.book_category_id,
                        book_category_name = o.book_category_name
                    };

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BookCategoryModel> Mapping(List<book_category> list)
        {
            try {
                if (list != null && list.Count>0)
                {
                    List<BookCategoryModel> mList = new List<BookCategoryModel>();

                    foreach (book_category o in list)
                    {
                        mList.Add(new BookCategoryModel()
                        {
                            book_category_id = o.book_category_id,
                            book_category_name = o.book_category_name
                        });
                    }
                    return mList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal book_category Mapping(BookCategoryModel c)
        {
            try
            {
                if (c != null)
                {
                    return new book_category()
                    {
                        book_category_id = c.book_category_id,
                        book_category_name = c.book_category_name
                    };

                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<book_category> IQueryable()
        {
            return dbh.book_category;
        }

        public List<BookCategoryModel> GetBookCategoryList()
        {
            try
            {
                List<book_category> objList = IQueryable().ToList();
                List<BookCategoryModel> m = Mapping(objList);
                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBookCategory(BookCategoryModel m)
        {
            try
            {
                if (IQueryable().Where(o => o.book_category_name == m.book_category_name).ToList().Count == 0)
                {
                    book_category _obj = Mapping(m);
                    dbh.book_category.Add(_obj);
                    dbh.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteBookCategoryList(List<BookCategoryModel> bookCategoryList)
        {
            try
            {
                List<book_category> dbBookCategory = Mapping(bookCategoryList);
                if(dbBookCategory.Count > 0)
                {
                    foreach (book_category bookCategory in dbBookCategory)
                    {
                        dbh.book_category.Attach(bookCategory);
                        dbh.book_category.Remove(bookCategory);
                        dbh.SaveChanges();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<book_category> Mapping(List<BookCategoryModel> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<book_category> mList = new List<book_category>();

                    foreach (BookCategoryModel o in list)
                    {
                        mList.Add(new book_category()
                        {
                            book_category_id = o.book_category_id,
                            book_category_name = o.book_category_name
                        });
                    }
                    return mList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}