using SqlDataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels.sys;

namespace SystemBusiness.sys
{
    /// <summary>
    /// 用户角色服务
    /// </summary>
    public class SysUserRoleService:BaseService<XT_USER_ROLE>
    {
        /// <summary>
        /// 查询用户的所有角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<XT_USER_ROLE> SelectByUserId(string userId) {
            if (string.IsNullOrWhiteSpace(userId)) {
                return new List<XT_USER_ROLE>();
            }
            SQLHelper helper = new SQLHelper("select * from XT_USER_ROLE where USER_ID=@0",userId );
            return Select(helper);
        }
    }
}
