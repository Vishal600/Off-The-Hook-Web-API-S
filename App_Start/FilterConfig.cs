using System.Web;
using System.Web.Mvc;

namespace TakeoutRestaurant
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
