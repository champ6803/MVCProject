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
                if (GetBookTypeList.Count > 0) {
                    var list = GetBookTypeList.Select(o => new
                    {
                        id = o.book_type_id,
                        name = o.book_type_name
                    }).ToList();
                    return Json(list, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
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

        public ActionResult DeleteBookType(List<BookTypeModel> book_typeList)
        {
            try
            {
                bool del = book_typeHelp.DeleteBookTypeList(book_typeList);
                if (del)
                {
                    var Book_typeList = book_typeHelp.GetBookTypeList();
                    return Json(Book_typeList, JsonRequestBehavior.AllowGet);
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