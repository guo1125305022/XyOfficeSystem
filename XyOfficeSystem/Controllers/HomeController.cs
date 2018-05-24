using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemModels.user;
using SystemModels.webData.user;
using XyOfficeSystem.DataLogic;

namespace XyOfficeSystem.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult UserLogin()
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                return View();
            }
            JsonResult result = new JsonResult();
            switch (action)
            {
                case "login":
                    string userName = GetParams("user_login_name");
                    string pwd = GetParams("user_login_pwd");
                    
                    UserLoginData data = UserManage.Login(userName, pwd);
                    if (data.LoginState)
                    {
                        try
                        {
                            XT_USER user = (XT_USER)data.Data;
                            UserManage.SaveToSession(user);
                            return RedirectToAction("HomePage","Home");
                        }
                        catch (Exception e)
                        {
                            throw new Exception("登录失败");
                        }

                    }
                    result.Data = data;
                    break;
            }
            
            return result;
        }
        public ActionResult HomePage() {
            return View(UserInfo);
        }

        
    }
}