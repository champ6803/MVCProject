using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;
using MVCProject.Helper;

namespace MVCProject.Controllers
{
    public class TestController : Controller
    {
        protected TestHelper testHelp = new TestHelper();
        // GET: Test
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            try
            {
                List<BookCategoryModel> bookList = testHelp.GetBookCategoryList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}