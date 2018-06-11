using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Entities;
using MVCProject.Models;
using System.Data.Entity;

namespace MVCProject.Libraries
{
    public class BookProductLibrary
    {
        mvc_projectEntities dbh = new mvc_projectEntities();

        internal BookProductModel Mapping(book_product o)
        {
            try
            {
                if (o != null)
                {
                    return new BookProductModel()
                    {
                        book_product_id = o.book_product_id,
                        book_product_name = o.book_product_name,
                        book_product_price = o.book_product_price,
                        book_product_qty = o.book_product_qty,
                        book_type_id = o.book_type_id,
                        book_category_id = o.book_category_id
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BookProductModel> Mapping(List<book_product> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<BookProductModel> mList = new List<BookProductModel>();

                    foreach (book_product o in list)
                    {
                        mList.Add(new BookProductModel()
                        {
                            book_product_id = o.book_product_id,
                            book_product_name = o.book_product_name,
                            book_product_price = o.book_product_price,
                            book_product_qty = o.book_product_qty,
                            book_type_id = o.book_type_id,
                            book_category_id = o.book_category_id
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

        public IQueryable<book_product> IQueryable()
        {
            return dbh.book_product;
        }

        public IQueryable<book_category> IQueryableCategory()
        {
            return dbh.book_category;
        }

        public IQueryable<book_type> IQueryableType()
        {
            return dbh.book_type;
        }

        public List<BookProductModel> GetBookProductList()
        {
            try
            {
                List<book_product> objList = IQueryable().ToList();
                List<BookProductModel> m = Mapping(objList);
                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal book_product Mapping(BookProductModel c)
        {
            try
            {
                if (c != null)
                {
                    return new book_product()
                    {
                        book_product_id = c.book_product_id,
                        book_product_name = c.book_product_name,
                        book_product_price = c.book_product_price,
                        book_product_qty = c.book_product_qty,
                        book_type_id = c.book_type_id,
                        book_category_id = c.book_category_id
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<book_product> Mapping(List<BookProductModel> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<book_product> mList = new List<book_product>();

                    foreach (BookProductModel o in list)
                    {
                        mList.Add(new book_product()
                        {
                            book_product_id = o.book_product_id,
                            book_product_name = o.book_product_name,
                            book_product_price = o.book_product_price,
                            book_product_qty = o.book_product_qty,
                            book_type_id = o.book_type_id,
                            book_category_id = o.book_category_id
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
        public bool AddBookProduct(BookProductModel m)
        {
            try
            {
                if (IQueryable().Where(o => o.book_product_name == m.book_product_name).ToList().Count == 0)
                {
                    book_product _obj = Mapping(m);
                    dbh.book_product.Add(_obj);
                    dbh.SaveChanges();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       
    }    
}