using System.Web;
using System.Web.Mvc;

namespace ASYC_AWAT_TEST
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
