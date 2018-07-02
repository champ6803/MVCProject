using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Entities;

namespace MVCProject.Libraries
{    
    public class BookOrderLibrary
    {
        mvc_projectEntities db = new mvc_projectEntities();
        public BookOrderModel Mapping(book_order o)
        {
            try
            {
                if (o != null)
                {
                    BookOrderModel bookOrder = new BookOrderModel();
                    bookOrder.book_order_id = o.book_order_id;
                    bookOrder.cus_id = o.cus_id;
                    bookOrder.book_status_code = o.book_status_code;
                    bookOrder.book_order_total = o.book_order_total;
                    bookOrder.book_order_date = o.book_order_date;
                    return bookOrder;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BookOrderModel> Mapping(List<book_order> list)
        {
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<BookOrderModel> oList = new List<BookOrderModel>();
                    foreach (book_order bo in list)
                    {
                        BookOrderModel bookOrder = new BookOrderModel();
                        bookOrder.book_order_id = bo.book_order_id;
                        bookOrder.book_order_date = bo.book_order_date;
                        bookOrder.book_order_total = bo.book_order_total;
                        bookOrder.book_status_code = bo.book_status_code;
                        bookOrder.cus_id = bo.cus_id;
                        oList.Add(bookOrder);
                    }
                    return oList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public book_order Mapping(BookOrderModel o)
        {
            try
            {
                if (o != null)
                {
                    book_order bookOrder = new book_order();
                    bookOrder.book_order_id = o.book_order_id;
                    bookOrder.book_order_date = o.book_order_date;
                    bookOrder.book_order_total = o.book_order_total;
                    bookOrder.book_status_code = "WP";
                    bookOrder.cus_id = 3;
                    return bookOrder;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<book_order> Mapping(List<BookOrderModel> list)
        {
            try
            {
                if(list != null && list.Count > 0)
                {
                    List<book_order> boList = new List<book_order>();
                    foreach(BookOrderModel b in list)
                    {
                        book_order bookOrder = new book_order();
                        bookOrder.book_order_id = b.book_order_id;
                        bookOrder.book_order_date = b.book_order_date;
                        bookOrder.book_order_total = b.book_order_total;
                        bookOrder.book_status_code = "WP";
                        bookOrder.cus_id = 3;
                        boList.Add(bookOrder);
                    }
                    return boList;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<book_order> IQueryableBookOrder()
        {
            return db.book_order;
        }
        public IQueryable<book_product> IQueryableBookProduct()
        {
            return db.book_product;
        }
        /*
        public int AddBookOrder(BookOrderModel bookOrder)
        {
            try
            {
                book_order bc = Mapping(bookOrder);
                db.book_order.Add(bc);
                db.SaveChanges();
                return bc.book_order_id;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        */
        public bool AddBookOrder(BookOrderModel bookOrder, List<BookOrderDetailModel> bookDetail)
        {
            try
            {
                book_order bc = Mapping(bookOrder);
                db.book_order.Add(bc);
                db.SaveChanges();
                int id = bc.book_order_id;

                
                AddOrderDetail(id, bookDetail);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddOrderDetail(int id, List<BookOrderDetailModel> bookDetail)
        {
            try
            {

                List<BookOrderDetailModel> detailList = new List<BookOrderDetailModel>();
                foreach(BookOrderDetailModel de in bookDetail)
                {
                    BookOrderDetailModel detail = new BookOrderDetailModel();
                    detail.book_product_id = de.book_product_id;
                    detail.book_order_detail_qty = de.book_order_detail_qty;
                    detailList.Add(detail);
                 
                   UpdateStockBookProduct(detailList);
                }

                List<book_order_detail> deList = new List<book_order_detail>();
                foreach (BookOrderDetailModel d in bookDetail)
                {
                    book_order_detail detail = new book_order_detail();
                    detail.book_order_detail_id = d.book_order_detail_id;
                    detail.book_order_id = id;
                    detail.book_product_id = d.book_product_id;
                    detail.book_order_detail_price = d.book_order_detail_price;
                    detail.book_order_detail_qty = d.book_order_detail_qty;
                    deList.Add(detail);
                }

                foreach(book_order_detail o in deList)
                {                    
                    db.book_order_detail.Add(o);
                    db.SaveChanges();
                }                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       public bool UpdateStockBookProduct(List<BookOrderDetailModel> bookDetail)
        {
            try
            { 
                if(bookDetail  != null && bookDetail.Count > 0)
                {
                    List<book_product> deList = new List<book_product>();
                    foreach(BookOrderDetailModel d in bookDetail)
                    {
                        book_product product = IQueryableBookProduct().FirstOrDefault(o => o.book_product_id == d.book_product_id);
                       
                        product.book_product_id = d.book_product_id;
                        product.book_product_qty = (product.book_product_qty - d.book_order_detail_qty);
                        deList.Add(product);
                        
                    }
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
    }
}