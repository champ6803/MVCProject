﻿using System;
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
    }
}