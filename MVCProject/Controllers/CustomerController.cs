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
    public class CustomerController : Controller
    {
        protected CustomerHelper cusHelp = new CustomerHelper();
        public ActionResult Customer()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCustomerList()
        {
            try
            {
                var customerList = cusHelp.GetCustomerList();
                return Json(customerList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerModel cus)
        {
            try
            {
                bool added = cusHelp.AddCustomer(cus);
                if (added)
                {
                    var customerList = cusHelp.GetCustomerList();
                    return Json(customerList, JsonRequestBehavior.AllowGet);
                }
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteCustomer(List<CustomerModel> cusList)
        {
            try
            {
                bool del = cusHelp.DeleteCustomerList(cusList);
                if (del)
                {
                    var customerList = cusHelp.GetCustomerList();
                    return Json(customerList, JsonRequestBehavior.AllowGet);
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