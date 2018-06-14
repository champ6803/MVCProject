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
                var list = bookProductHelp.GetBookProductList();
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

        public ActionResult UpdateBookProduct(BookProductModel bookProd)
        {
            try
            {
                bool updated = bookProductHelp.UpdateProduct(bookProd);
                if (updated)
                {
                    var bookProduct = bookProductHelp;
                    return Json(bookProduct, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteBookProduct(List<BookProductModel> bookProductList)
        {
            try
            {
                bool del = bookProductHelp.DeleteBookProduct(bookProductList);
                if (del)
                {
                    var bookProdList = bookProductHelp.GetBookProductList();
                    return Json(true, JsonRequestBehavior.AllowGet);
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