using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace XyOfficeSystem.Controllers
{
    public class SystemPageManageController : Controller
    {
        // GET: SystemPageManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditorPage() {
            return View();
        }
    }
}