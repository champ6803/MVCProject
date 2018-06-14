using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Entities;
using MVCProject.Models;

namespace MVCProject.Libraries
{
    public class BookCateTypeLibrary
    {
        mvc_projectEntities db = new mvc_projectEntities();
        public IQueryable<book_category> IQueryableCategory()
        {
            return db.book_category;
        }
        public IQueryable<book_type> IQueryableType()
        {
            return db.book_type;
        }

        internal BookCategoryModel Mapping(book_category m) //จะ return ไปข้างหน้า จึงreturn เป็น model
        {
            try
            {
                if (m != null)
                {
                    BookCategoryModel bm = new BookCategoryModel();
                    bm.book_category_id = m.book_category_id;
                    bm.book_category_name = m.book_category_name;
                    return bm;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal BookTypeModel Mapping(book_type m)
        {
            try
            {
                if (m != null)
                {
                    BookTypeModel bt = new BookTypeModel();
                    bt.book_type_id = m.book_type_id;
                    bt.book_type_name = m.book_type_name;
                    return bt;
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
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<BookCategoryModel> bList = new List<BookCategoryModel>();

                    foreach (book_category bc in list)
                    {
                        BookCategoryModel b = new BookCategoryModel();
                        b.book_category_id = bc.book_category_id;
                        b.book_category_name = bc.book_category_name;
                        bList.Add(b);
                    }
                    return bList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BookTypeModel> Mapping(List<book_type> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<BookTypeModel> bList = new List<BookTypeModel>();
                    foreach (book_type bt in list)
                    {
                        BookTypeModel b = new BookTypeModel();
                        b.book_type_id = bt.book_type_id;
                        b.book_type_name = bt.book_type_name;
                        bList.Add(b);
                    }
                    return bList;
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
                    book_category bc = new book_category();
                    bc.book_category_id = c.book_category_id;
                    bc.book_category_name = c.book_category_name;
                    return (bc);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<book_category> Mapping(List<BookCategoryModel> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<book_category> bcList = new List<book_category>();
                    foreach (BookCategoryModel bc in list)
                    {
                        book_category b = new book_category();
                        b.book_category_id = bc.book_category_id;
                        b.book_category_name = bc.book_category_name;
                        bcList.Add(b);
                    }
                    return bcList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BookCategoryModel> GetBookCategoryList()
        {
            try
            {
                List<book_category> b = IQueryableCategory().ToList();
                List<BookCategoryModel> bList = Mapping(b);
                return bList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public book_type Mapping(BookTypeModel t)
        {
            try
            {
                if (t != null)
                {
                    book_type bt = new book_type();
                    bt.book_type_id = t.book_type_id;
                    bt.book_type_name = t.book_type_name;
                    return bt;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<book_type> Mapping(List<BookTypeModel> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<book_type> btList = new List<book_type>();
                    foreach (BookTypeModel bt in list)
                    {
                        book_type b = new book_type();
                        b.book_type_id = bt.book_type_id;
                        b.book_type_name = bt.book_type_name;
                        btList.Add(b);
                    }
                    return btList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookTypeModel> GetBookTypeList()
        {
            try
            {
                List<book_type> b = IQueryableType().ToList();
                List<BookTypeModel> bList = Mapping(b);
                return bList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBookCate(BookCategoryModel m)
        {
            try
            {
                if (IQueryableCategory().Where(o => o.book_category_name == m.book_category_name).ToList().Count == 0)
                {
                    book_category _obj = Mapping(m);
                    db.book_category.Add(_obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddBookType(BookTypeModel m)
        {
            try
            {
                if (IQueryableType().Where(o => o.book_type_name == m.book_type_name).ToList().Count == 0)
                {
                    book_type _obj = Mapping(m);
                    db.book_type.Add(_obj);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
        public bool DeleteBookCate(List<BookCategoryModel> m)
        {
            try
            {
                if (m != null && m.Count > 0)
                {
                    List<book_category> dbBookCate = Mapping(m);
                    
                        foreach (book_category bc in dbBookCate)
                        {
                            db.book_category.Attach(bc);
                            db.book_category.Remove(bc);
                            db.SaveChanges();
                        }
                        return true;                    
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }
        public bool DeleteBookType(List<BookTypeModel> bookTypeList)
        {
            try
            {
                if (bookTypeList != null && bookTypeList.Count > 0)
                {
                    List<book_type> dbBookTypeList = Mapping(bookTypeList);

                    foreach (book_type bt in dbBookTypeList)
                    {
                        db.book_type.Attach(bt);
                        db.book_type.Remove(bt);
                        db.SaveChanges();
                    }
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateCate(BookCategoryModel bookCate)
        {
            try
            {
                book_category bc = IQueryableCategory().FirstOrDefault(o => o.book_category_id == bookCate.book_category_id);
                bc.book_category_name = bookCate.book_category_name;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateType(BookTypeModel bookType)
        {
            try
            {
                book_type bt = IQueryableType().FirstOrDefault(o => o.book_type_id == bookType.book_type_id);
                bt.book_type_name = bookType.book_type_name;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}