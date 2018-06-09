using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Entities;
using System.Data.Entity.Validation;

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

        internal customer Mapping(CustomerModel c)
        {
            try
            {
                if (c != null)
                {
                    return new customer()
                    {
                        cus_id = c.cus_id,
                        cus_name = c.cus_name,
                        cus_age = c.cus_age,
                        cus_address = c.cus_address
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<customer> Mapping(List<CustomerModel> list)
        {
            //ACTION = "Mapping(CustomerModel)";
            try
            {
                if (list != null && list.Count > 0)
                {
                    List<customer> mList = new List<customer>();

                    foreach (CustomerModel o in list)
                    {
                        mList.Add(new customer()
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
                List<CustomerModel> m = Mapping(objList);  // เอามา map กับ model ของ C# ที่เราเขียน

                return m;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddCustomer(CustomerModel m)
        {
            if (m == null)
                throw new Exception("no object");
            try
            {

                if (IQueryable().Where(o => o.cus_name == m.cus_name).ToList().Count == 0)
                {
                    customer _obj = Mapping(m);
                    dbh.customer.Add(_obj);
                    dbh.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteCustomerList(List<CustomerModel> cusList)
        {
            try
            {
                //customer dbCustomer = dbh.customer.FirstOrDefault(o => o.cus_id == cus_id);
                List<customer> dbCustomer = Mapping(cusList);
                if (dbCustomer.Count > 0)
                {
                    foreach (customer cus in dbCustomer)
                    {
                        dbh.customer.Attach(cus);
                        dbh.customer.Remove(cus);
                        dbh.SaveChanges();
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}