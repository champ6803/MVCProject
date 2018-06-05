using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Entities;

namespace MVCProject.Libraries
{
    public class CustomerLibrary
    {
        string SOURCE = "CustomerLibrary";
        string ACTION = "";
        mvc_projectEntities dbh = new mvc_projectEntities();

        internal CustomerModel Mapping(customer o)
        {
            //ACTION = "Mapping(customer)";
            try
            {
                if (o != null)
                {
                    return new CustomerModel()
                    {
                        cus_id = o.cus_id,
                        cus_name = o.cus_name,
                        cus_age = o.cus_age,
                        cus_address = o.cus_address
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<CustomerModel> Mapping(List<customer> list)
        {
            //ACTION = "Mapping(CustomerModel)";
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<CustomerModel> mList = new List<CustomerModel>();

                    foreach (customer o in list)
                    {
                        mList.Add(new CustomerModel()
                        {
                            cus_id = o.cus_id,
                            cus_name = o.cus_name,
                            cus_age = o.cus_age,
                            cus_address = o.cus_address
                        });
                    }

                    return mList;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<customer> IQueryable()
        {
            return dbh.customer;
        }

        public List<CustomerModel> GetCustomerList()
        {
            //ACTION = "GetFisMstDocTypeModel()";
            try
            {
                List<customer> objList = IQueryable().ToList();
                List<CustomerModel> m = Mapping(objList);

                return m;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}