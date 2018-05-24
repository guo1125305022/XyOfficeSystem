using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemBusiness;
using SystemBusiness.sys;
using SystemModels.sys;
using SystemModels.user;
using SystemTools;
using XyOfficeSystem.DataLogic;

namespace XyOfficeSystem.Controllers
{
    public class BaseController : Controller
    {
        protected string action;
        
        /// <summary>
        /// 用户信息
        /// </summary>
        protected XT_TEMP_PORARY_USER UserInfo;
        protected override void OnActionExecuting(ActionExecutingContext filterContext) {
           string sessionId =filterContext.HttpContext.Session.SessionID;
            var info =UserManage.GetCurrentUserInfo();
            if (info == null) {
                XT_TEMP_PORARY_USER userInfo = new XT_TEMP_PORARY_USER()
                {
                    ID = GuidTools.NewGuid(),
                    USER_NAME = "游客",
                    CREATE_BY = "sys",
                    CREATE_TIME = DateTime.Now,
                    MODIFY_BY = "sys",
                    MODIFY_TIME = DateTime.Now,
                    USER_ID = ""

                };
                UserManage.SaveToSession(userInfo);
                GetService<SysTempPoraryUserService>().Insert(userInfo);
                this.UserInfo = userInfo;
            }
            if (info is XT_USER) {
                UserInfo= info as XT_USER;
            }
            action = Request.Params["action"];
            string url = Request.Url.AbsoluteUri;
            //if(CheckUserUrlAndActionPermission(url,))
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramsName"></param>
        /// <returns></returns>
        protected T GetParams<T>(string paramsName) {
            string value = GetParams(paramsName);
           return StringTools.StringToType<T>(value);

        }
        private object ConverBaseType(string typeString, string value) {
            object val = null;
            switch (typeString)
            {
                case "System.Int16":
                case "System.Int32":
                    val = Convert.ToInt32(value);
                    break;
                case "System.Int64":
                    val = Convert.ToInt64(value);
                    break;
                case "System.Float":
                    val =float.Parse(value);
                    break;
                case "System.Double":
                    val = Double.Parse(value);
                    break;
              
            }
            return val;
        }
        protected string GetParams(string paramsName)
        {
            return Request.Params[paramsName];
        }

        #region 获取当前用户
        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns></returns>
        protected XT_USER GetCurrerUser() {
            if (UserInfo is XT_USER)
            {
                return UserInfo as XT_USER;
            }
            return null;
        }
        #endregion

        #region 获取数据库服务
        /// <summary>
        /// 获取数据库服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetService<T>() {
            return ServiceManage.GetService<T>();
        }
        #endregion 获取数据库服务

    }
}