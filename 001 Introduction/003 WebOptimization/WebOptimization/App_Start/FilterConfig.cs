using System.Web;
using System.Web.Mvc;

namespace _07_BundlingAndMinification
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}