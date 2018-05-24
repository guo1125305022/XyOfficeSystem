using System.Web;
using System.Web.Mvc;
using XyOfficeSystem.App_Start;

namespace XyOfficeSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ServerErrorCatch());
        }
    }
}
