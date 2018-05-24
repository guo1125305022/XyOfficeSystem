using SqlDataBaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using SystemModels.sys;

namespace SystemBusiness.sys
{
    public partial class SysMenuService : BaseService<XT_MENU>
    {
        public  void DeleteMenuAndChilderById(string menuId)
        {
            List<XT_MENU> list = GetSelfAndChilder(menuId);
            foreach (XT_MENU menu in list) {
                Delete(menu);
            }
            
        }
        /// <summary>
        /// 根据菜单ID获取菜单以及所有的子级菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public  List<XT_MENU> GetSelfAndChilder(string menuId) {
            List<XT_MENU> list = SelectAll();
            List<XT_MENU> result = new List<XT_MENU>();
            Action<string> full = null;
            full = id =>
            {
                XT_MENU target = list.FirstOrDefault(it => it.ID == id);
                if (target != null)
                {
                    result.Add(target);
                }
                var temp = list.Where(it => it.PARENT_ID == id);
                foreach (var v in temp) {
                    full(v.ID);
                }

            };
            full(menuId);
            return result;
        }

        public void UpdataMenuSotrAndGroup(string menuId, string parentId, int sort) {
            if (string.IsNullOrWhiteSpace(menuId)) {
                return;
            }
            XT_MENU menu = SelectById(menuId);
            if (menu == null){
                return;
            }
             UpdateSortPlusByParentMaxSort(parentId, sort);
            menu.SORT = sort;
            menu.PARENT_ID = parentId;
            Update(menu);

        }

        public int UpdateSortPlusByParentMaxSort(string parentId, int maxSort) {
            SQLHelper helper = new SQLHelper("update XT_MENU set SORT=SORT+1 where PARENT_ID=@0 and SORT>@1", parentId, maxSort);
            return db.ExecuteNonQuery(helper);
        }
        /// <summary>
        /// 根据父级编号查询指定序号的记录
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="targetSort"></param>
        /// <returns></returns>
        public  XT_MENU SelectByParentIdAndSort(string parentId, int targetSort)
        {
            SQLHelper helper = new SQLHelper("select * from XT_MENU where PARENT_ID=@0,SORT=@1", parentId, targetSort);
            return SelectFirstOrDefault(helper);
        }
    }
}
