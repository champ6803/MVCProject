using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Helper;
using MVCProject.Models;

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
                var bookProductList = bookProductHelp.GetBookProduct();

                var list = bookProductList.Select(o => new
                {
                    id = o.book_product_id,
                    name = o.book_product_name,
                    price = o.book_product_price,
                    qty = o.book_product_qty,
                    idType = o.book_type_id,
                    idCate = o.book_category_id

                }).ToList();

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddBookProduct(BookCategoryModel bookProd)
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