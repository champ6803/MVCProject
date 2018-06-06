using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Helper;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class BookCategoryController : Controller
    {
        protected BookCategoryHelper bookCategoryHelp = new BookCategoryHelper();

        // GET: BookCategory
        public ActionResult BookCategory()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBookCategoryList()
        {
            try
            {
                var bookCategoryList = bookCategoryHelp.GetBookCategory();

                return Json(bookCategoryList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddBookCategory(BookCategoryModel bookCategory)
        {
            try
            {
                bool added = bookCategoryHelp.AddBookCategory(bookCategory);
                if (added)
                {
                    var bookCategoryList = bookCategoryHelp.GetBookCategory();
                    return Json(bookCategoryList, JsonRequestBehavior.AllowGet);
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