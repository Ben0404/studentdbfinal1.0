﻿using System.Web;
using System.Web.Mvc;

namespace studentdbfinal1._0
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
