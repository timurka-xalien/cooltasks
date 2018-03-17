﻿using CoolTasks.Filters;
using System.Web;
using System.Web.Mvc;

namespace CoolTasks
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogRequestFilter());
        }
    }
}
