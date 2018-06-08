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

                if (IQueryable().Where(b => b.book_type_name == m.book_type_name).ToList().Count == 0)
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

        public bool DeleteBookType(List<BookTypeModel> book_typeList)
        {
            try
            {
                List<book_type> dbBookType = Mapping (book_typeList);
                if (dbBookType.Count > 0)
                {
                    foreach (book_type book_type in dbBookType)
                    {
                        dbh.book_type.Attach(book_type);
                        dbh.book_type.Remove(book_type);
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

        private List<book_type> Mapping(List<BookTypeModel> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<book_type> mList = new List<book_type>();

                    foreach (BookTypeModel o in list)
                    {
                        mList.Add(new book_type()
                        {
                            book_type_id = o.book_type_id,
                            book_type_name = o.book_type_name
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

