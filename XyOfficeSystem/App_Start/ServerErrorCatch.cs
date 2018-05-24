using SqlDataBaseService;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SystemBusiness;
using SystemBusiness.sys;
using SystemModels.sys;
using SystemTools;
using SystemTools.webulits;
using XyOfficeSystem.DataLogic;

namespace XyOfficeSystem.App_Start
{
    public class ServerErrorCatch: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext) {
            Exception e= filterContext.Exception;
            ConnectionStringSettings settings= AppConfigManage.GetSysLogConnection();
            SysLogService service = ServiceManage.GetService<SysLogService>();
            XT_SYS_LOG log = new XT_SYS_LOG()
            {
                ADDRESS_URL = HttpContext.Current.Request.Url.AbsolutePath,
                CREATE_BY = "sys",
                MODIFY_BY = "sys",
                CREATE_TIME = DateTime.Now,
                MODIFY_TIME = DateTime.Now,
                EX_MESSAGE = e.Message,
                ID = GuidTools.NewGuid(),
                USER_ID = UserManage.GetCurrentUserInfo().ID

            };
            service.Insert(log);
            NameValueCollection collection= HttpContext.Current.Request.Params;
            StringBuilder builder = new StringBuilder();
            SysLogParamter paramterService = ServiceManage.GetService<SysLogParamter>();

            foreach (string name in collection.Keys) {
                XT_REQUEST_PARAMETER paramters = new XT_REQUEST_PARAMETER()
                {
                    ID = GuidTools.NewGuid(),
                    CREATE_BY = log.CREATE_BY,
                    CREATE_TIME = log.CREATE_TIME,
                    LOG_ID = log.ID,
                    MODIFY_BY = log.MODIFY_BY,
                    MODIFY_TIME = log.MODIFY_TIME,
                    PARAMETER_NAME = name,
                    PARAMETER_VALUE = collection[name]
                };
                paramterService.Insert(paramters);
            }
            
            HttpContext.Current.Server.ClearError();

        }
    }
} 