using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.Libraries;

namespace MVCProject.Helper
{
    public class TestHelper
    {
        public List<BookCategoryModel> GetBookCategoryList()
        {
            return new TestLibrary().GetBookCategoryList();
        }
    }
}