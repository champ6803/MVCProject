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
    public class BookTypeController : Controller
    {
        protected BookTypeHelper book_typeHelp = new BookTypeHelper();
        public ActionResult BookType()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBookTypeList()
        {
            try
            {
                var GetBookTypeList = book_typeHelp.GetBookTypeList();
                return Json(GetBookTypeList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddBookType(BookTypeModel book)
        {
            try
            {
                bool added = book_typeHelp.AddBookType(book);
                if (added)
                {
                    var book_typeList = book_typeHelp.GetBookTypeList();
                    return Json(book_typeList, JsonRequestBehavior.AllowGet);
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