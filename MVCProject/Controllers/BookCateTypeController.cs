using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Helper;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class BookCateTypeController : Controller
    {
        protected BookCateTypeHelper bookHelp = new BookCateTypeHelper();
        // GET: BookCateType
        public ActionResult BookCateType()
        {
            return View();
        }

        public ActionResult GetBookCateType()
        {
           try
            {
                List<BookCategoryModel> bookCateList= bookHelp.GetBookCate();
                List<BookTypeModel> bookTypeList = bookHelp.GetBookType();               
                return Json(new { bookTypeList = bookTypeList, bookCateList = bookCateList}, JsonRequestBehavior.AllowGet); // return 2 list ในครั้งเดียว
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AddBookCate(BookCategoryModel m)
        {
            try
            {
                bool added = bookHelp.AddBookCateList(m);
                if (added)
                {
                    var bookCateList = bookHelp.GetBookCate();
                    return Json(bookCateList, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }            
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddBookType(BookTypeModel m)
        {
            bool added = bookHelp.AddBookTypeList(m);
            if (added)
            {
                var bookTypeList = bookHelp.GetBookType();
                return Json(bookTypeList, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteBookCate(List<BookCategoryModel> bookCateList)
        {
            try
            {
                bool delete = bookHelp.DeleteCateList(bookCateList);
                if (delete)
                {
                    var bookCteList = bookHelp.GetBookCate();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DeleteBookType(List<BookTypeModel> bookTypeList)
        {
            try
            {
                bool del = bookHelp.DeleteBookTypeList(bookTypeList);
                if (del)
                {
                    var bookType = bookHelp.GetBookType();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }    
        }
        public ActionResult UpdateBookCate(BookCategoryModel bookCate)
        {
            try
            {
                bool updated = bookHelp.UpdateCate(bookCate);
                if (updated)
                {
                    var bc = bookHelp.GetBookCate();
                    return Json(bc, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateBookType(BookTypeModel bookType)
        {
            try
            {
                bool updated = bookHelp.UpdateType(bookType);
                if (updated)
                {
                    var bt = bookHelp.GetBookType();
                    return Json(bt, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}