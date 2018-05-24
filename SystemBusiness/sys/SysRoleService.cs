
using SqlDataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemBusiness.user;
using SystemModels.sys;
using SystemModels.user;
using SystemTools;

namespace SystemBusiness.sys
{
    /// <summary>
    /// 角色服务
    /// </summary>
    public class SysRoleService:BaseService<XT_ROLE>
    {
        public void DeleteAndChilderById(string menuId)
        {
            List<XT_ROLE> list = GetSelfAndChilder(menuId);
            foreach (XT_ROLE role in list)
            {
                Delete(role);
            }

        }
        /// <summary>
        /// 根据菜单ID获取菜单以及所有的子级菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public List<XT_ROLE> GetSelfAndChilder(string menuId)
        {
            List<XT_ROLE> list = SelectAll();
            List<XT_ROLE> result = new List<XT_ROLE>();
            Action<string> full = null;
            full = id =>
            {
                XT_ROLE target = list.FirstOrDefault(it => it.ID == id);
                if (target != null)
                {
                    result.Add(target);
                }
                var temp = list.Where(it => it.PARENT_ID == id);
                foreach (var v in temp)
                {
                    full(v.ID);
                }

            };
            full(menuId);
            return result;
        }

        public void UpdataSotrAndGroup(string menuId, string parentId, int sort)
        {
            if (string.IsNullOrWhiteSpace(menuId))
            {
                return;
            }
            XT_ROLE menu = SelectById(menuId);
            if (menu == null)
            {
                return;
            }
            UpdateSortPlusByParentMaxSort(parentId, sort);
            menu.SORT = sort;
            menu.PARENT_ID = parentId;
            Update(menu);

        }

        public int UpdateSortPlusByParentMaxSort(string parentId, int maxSort)
        {
            SQLHelper helper = new SQLHelper("update XT_ROLE set SORT=SORT+1 where PARENT_ID=@0 and SORT>@1", parentId, maxSort);
            return db.ExecuteNonQuery(helper);
        }

        /// <summary>
        /// 根据父级编号查询指定序号的记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="targetSort"></param>
        /// <returns></returns>
        public XT_ROLE SelectByParentIdAndSort(string parentId, int targetSort)
        {
            SQLHelper helper = new SQLHelper("select * from XT_ROLE where PARENT_ID=@0,SORT=@1", parentId, targetSort);
            return SelectFirstOrDefault(helper);
        }

        /// <summary>
        /// 根据用户编号查询用户可授予别的用户角色
        /// </summary>
        /// <param name="userId"></param>
        public List<XT_ROLE> SelectByUser(string userId)
        {
            XT_USER user = ServiceManage.GetService<XT_UserService>().SelectById(userId);
            if (user == null) {
                return new List<XT_ROLE>();
            }
            if (user.LOGIN_NAME == AppConfigManage.GetSysUserInfo()[0]) {
                return SelectAll();
            }
            SQLHelper helper = new SQLHelper("select c.* from XT_USER a,XT_USER_ROLE b, XT_ROLE c)");
            helper.Append("where a.ID = b.USER_ID");
            helper.Append("and b.ROLE_ID = c.ID ");
            helper.Append("and a.ID=@0", userId);
            return Select(helper);
        }
    }
}
