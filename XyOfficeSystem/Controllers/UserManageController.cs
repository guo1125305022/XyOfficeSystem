using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemBusiness;
using SystemBusiness.user;
using SystemModels.user;
using XyOfficeSystem.DataLogic;

namespace XyOfficeSystem.Controllers
{
    public class UserManageController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            if (string.IsNullOrWhiteSpace(action)) {
                return View();
            }
            JsonResult result = new JsonResult();
            switch (action) {
                case "GetTable":
                    break;
                    
            }

            return result;
        }

        public ActionResult EditUser() {
            XT_UserService service = ServiceManage.GetService<XT_UserService>();
            
            string userId = GetParams("userId");
            if (string.IsNullOrWhiteSpace(action)) {
                XT_USER user = service.SelectById(userId);
                if (user == null) {
                    user = new XT_USER();
                }
                return View(user);
            }
            JsonResult result = new JsonResult();
            switch (action) {
                case "editUser":
                    try
                    {
                        XT_USER user = GetParams<XT_USER>("userModel");
                        service.InsertOrUpdate(user);
                    }
                    catch (Exception e) {
                        
                    }
                    

                    break;
            }
            return result;
                

        }
        
    }
}