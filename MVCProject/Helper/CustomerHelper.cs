using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Libraries;
using MVCProject.Models;

namespace MVCProject.Helper
{
    public class CustomerHelper
    {
        public List<CustomerModel> GetCustomerList()
        {
            List<CustomerModel> list = new CustomerLibrary().GetCustomerList();
            return list;
        }
        public bool AddCustomer(CustomerModel cus)
        {
            return new CustomerLibrary().AddCustomer(cus);
        }

        public bool DeleteCustomerList(List<CustomerModel> cusList)
        {
            return new CustomerLibrary().DeleteCustomerList(cusList);
        }
    }
}