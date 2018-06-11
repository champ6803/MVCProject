using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Helper;
using MVCProject.Models;
using MVCProject.Entities;

namespace MVCProject.Controllers
{    
    public class BookProductController : Controller
    {
        protected BookProductHelper bookProductHelp = new BookProductHelper();
        // GET: BookProduct
        public ActionResult BookProduct()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBookProductList()
        {
            try
            {
                var GetBookProductList = bookProductHelp.GetBookProductList();
                var list = GetBookProductList.Select(o => new
                {
                    book_product_id = o.book_product_id,
                    book_product_name = o.book_product_name,
                    book_product_price = o.book_product_price,
                    book_product_qty = o.book_product_qty,
                    book_type_id = o.book_type_id,
                    book_category_id = o.book_category_id
                }).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddBookProduct(BookProductModel bookProd)
        {
            try
            {
                bool added = bookProductHelp.AddBookProduct(bookProd);
                if(added)
                {
                    var bookProductList = bookProductHelp;
                    return Json(bookProductList, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


    }    
    
}