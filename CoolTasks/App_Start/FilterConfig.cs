using CoolTasks.Filters;
using System.Web;
using System.Web.Mvc;

namespace CoolTasks
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Remove ASP.NET MVC Error filter to use Global.asax error handler 
            // for both ASP.NET and ASP.NET MVC errors
            // filters.Add(new HandleErrorAttribute());
            filters.Add(new LogRequestFilter());
        }
    }
}
