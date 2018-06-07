using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Entities;
using System.Data.Entity.Validation;

namespace MVCProject.Libraries
{
    public class BookTypeLibrary
    {
        string SOURCE = "BookType";
        string ACTION = "";
        mvc_projectEntities dbh = new mvc_projectEntities();

        internal BookTypeModel Mapping(book_type b)
        {
            //ACTION = "Mapping(BookType)";
            try
            {
                if (b != null)
                {
                    return new BookTypeModel()
                    {
                        book_type_id = b.book_type_id,
                        book_type_name = b.book_type_name
                        
                    };
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
            //ACTION = "Mapping(BookTypeModel)";
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<BookTypeModel> mList = new List<BookTypeModel>();

                    foreach (book_type m in list)
                    {
                        mList.Add(new BookTypeModel()
                        {
                            book_type_id = m.book_type_id,
                            book_type_name = m.book_type_name
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

        internal book_type Mapping(BookTypeModel k)
        {
            try
            {
                if (k != null)
                {
                    return new book_type()
                    {
                        book_type_id = k.book_type_id,
                        book_type_name = k.book_type_name
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<book_type> IQueryable()
        {
            return dbh.book_type;
        }

        public List<BookTypeModel> GetBookTypeList()
        {
            //ACTION = "GetFisMstDocTypeModel()";
            try
            {
                List<book_type> objList = IQueryable().ToList();
                List<BookTypeModel> m = Mapping(objList);

                return m;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddBookType(BookTypeModel m)
        {
            if (m == null)
                throw new Exception("no object");
            try
            {

                if (IQueryable().Where(b => b.book_type_id == m.book_type_id).ToList().Count == 0)
                {
                    book_type _obj = Mapping(m);
                    dbh.book_type.Add(_obj);
                    dbh.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteBookType(int book_type_id)
        {
            try
            {
                book_type dbBookType = dbh.book_type.FirstOrDefault(b => b.book_type_id == book_type_id);
                if (dbBookType != null)
                {
                    dbh.book_type.Attach(dbBookType);
                    dbh.book_type.Remove(dbBookType);
                    dbh.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}