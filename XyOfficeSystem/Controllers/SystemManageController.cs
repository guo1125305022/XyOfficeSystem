using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemModels.sys;

namespace XyOfficeSystem.Controllers
{
    public class SystemManageController : BaseController
    {
        // GET: SystemManage
        public ActionResult Index()
        {
            if (string.IsNullOrWhiteSpace(action)){
                
                return View();
            }
            JsonResult result = new JsonResult();
            string menu_parentId = GetParams("menu_parentId");
            switch (action) {
                case "MenuList":
                    //List<XT_MENU> menu_list=
                    break;
            }

            return result;
        }
    }
}