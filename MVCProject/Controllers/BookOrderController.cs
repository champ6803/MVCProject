using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using MVCProject.Helper;
using MVCProject.Entities;

namespace MVCProject.Controllers
{
    public class BookOrderController : Controller
    {
        BookOrderHelper orderHelp = new BookOrderHelper();
        // GET: BookOrder
        public ActionResult BookOrder()
        {
            return View();
        }

        public ActionResult AddBookOrder(BookOrderModel bookOrder, List<BookOrderDetailModel> bookDetail)
        {
            try
            {
                bool added = orderHelp.AddBookOrder(bookOrder, bookDetail);
                if (added)
                {
                    var b = orderHelp;
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddOrderDetail(BookOrderModel id, List<BookOrderDetailModel> bookDetail)
        {
            try
            {
                bool added = orderHelp.AddBookDetailOrder(id, bookDetail);
                if (added)
                {
                    var b = orderHelp;
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateStockBookProduct(List<BookOrderDetailModel> bookDetail)
        {
            bool update = orderHelp.UpdateStockBookProduct(bookDetail);
            if (update)
            {
                var u = orderHelp;
                return Json(u, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}