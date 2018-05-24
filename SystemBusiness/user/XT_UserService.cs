
using SqlDataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels.sys;
using SystemModels.user;

namespace SystemBusiness.user
{
    public class XT_UserService:BaseService<XT_USER>
    {
        /// <summary>
        /// 根据用户名查询用户信息
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public XT_USER SelectByLoginName(string loginName) {
            SQLHelper helper = new SQLHelper("select * from XT_USER where LOGIN_NAME=@0", loginName);
            return SelectFirstOrDefault(helper);
        }

        /// <summary>
        /// 根据角色编号查询当前角色的下的用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<XT_USER> SelectByRoleId(string roleId)
        {
            if (string.IsNullOrWhiteSpace(roleId)) {
                return new List<XT_USER>();
            }
            SQLHelper helper = new SQLHelper("select * from XT_USER a,XT_USER_ROLE ");
            helper.Append("where a.ID=b.USER_ID ");
            helper.Append("and b.ROLE_ID=@0", roleId);
            return Select(helper);
        }


    }
}
