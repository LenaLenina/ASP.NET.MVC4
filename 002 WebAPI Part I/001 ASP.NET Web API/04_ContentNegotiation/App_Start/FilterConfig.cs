using System.Web;
using System.Web.Mvc;

namespace _04_ContentNegotiation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}