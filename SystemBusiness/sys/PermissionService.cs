using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels.sys;

namespace SystemBusiness.sys
{
    /// <summary>
    /// 用户权限检查
    /// </summary>
    public class PermissionService:BaseService<XT_USER_URL_PERMISSION>
    {
        public static  bool CheckUserUrl(string url, string userId) {
            
            return false;
        }
    }
}
