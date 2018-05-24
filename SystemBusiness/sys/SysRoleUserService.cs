using SqlDataBaseService;
using SystemModels.sys;

namespace SystemBusiness.sys
{
    public class SysRoleUserService : BaseService<XT_USER_ROLE>
    {
        ///// <summary>
        ///// 查询角色所拥有的菜单
        ///// </summary>
        ///// <param name="roles"></param>
        ///// <returns></returns>
        //public List<XT_USER_ROLE> SelectByRoles(List<XT_ROLE> roles) {
        //    if (roles == null || roles.Count < 1) {
        //        return new List<XT_ROLE_MENU>();
        //    }
        //    SQLHelper helper = new SQLHelper("select distinct MNEU_ID from XT_ROLE_MENU where 1=1 and");
        //    helper.Append(" and (");
        //    int i = 0;
        //    foreach (XT_ROLE role in roles) {
        //        if (i++ > 1)
        //        {
        //            helper.Append(" ROLE_ID=@" + i, role.ID);
        //        }
        //        else {
        //            helper.Append(" or ROLE_ID=@" + i, role.ID);
        //        }
        //    }
        //    helper.Append(" ) ");
        //    return Select(helper);
        //}
        public int DeleteByRoleId(string roleId) {
            if (string.IsNullOrWhiteSpace(roleId)) {
                return -1;
            }
            SQLHelper helper = new SQLHelper("delete XT_USER_ROLE where ROLE_ID=@0",roleId);
            return ExecuteNonQuery(helper);
        }
    }
}
