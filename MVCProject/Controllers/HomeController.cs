using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Helper;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult getCustomerList()
        {
            try
            {
                CustomerHelper cusHelp = new CustomerHelper();
                var customerList = cusHelp.GetCustomerList();
                return Json(customerList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //log.Error(ex.StackTrace);
                //log.Error(ex.Message);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}