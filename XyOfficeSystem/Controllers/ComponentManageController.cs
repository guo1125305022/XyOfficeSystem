using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemBusiness.sys;
using SystemModels.sys;

namespace XyOfficeSystem.Controllers
{
    /// <summary>
    /// 网页组件管理
    /// </summary>
    public class ComponentManageController : BaseController
    {
        /// <summary>
        /// 组件列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (string.IsNullOrWhiteSpace(action)) {
                return View();
            }
            SysComponentService service = GetService<SysComponentService>();
            JsonResult result = new JsonResult();
            switch (action) {
                case "Get_all_Templates":
                    List<XT_HTML_COMPONENT> list= service.SelectAll();
                    result.Data = list;
                    break;
                   
            }
            return result;
        }

        /// <summary>
        /// 预览组件
        /// </summary>
        /// <returns></returns>
        public ActionResult PreviewComponent()
        {
            if (string.IsNullOrWhiteSpace(action)) {
                return View();
            }
            JsonResult result = new JsonResult();
            return result;
        }

        /// <summary>
        /// 组件编辑
        /// </summary>
        /// <returns></returns>
        public ActionResult EditorComponent() {
            if (string.IsNullOrWhiteSpace(action)) {
                return View();
            }
            
            JsonResult result = new JsonResult();
            return result;
        }


        


    }
}