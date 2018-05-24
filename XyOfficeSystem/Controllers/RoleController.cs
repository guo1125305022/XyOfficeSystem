using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemBusiness.sys;
using SystemBusiness.user;
using SystemModels.sys;
using SystemModels.user;
using SystemModels.webData.ztree;

namespace XyOfficeSystem.Controllers
{
    public class RoleController : BaseController
    {
        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (string.IsNullOrWhiteSpace(action)) {
                return View();
            }
            JsonResult result = new JsonResult();
            SysRoleService roleService = GetService<SysRoleService>();
            XT_ROLE role = null;
            string roleId = GetParams("roleId");
            switch (action) {
                case "GetRoles":
                    List<XT_ROLE> roles = roleService.SelectAll(new List<string>() { "PARENT_ID", "SORT" });
                    List<ZTreeItemData> treeDatas = new List<ZTreeItemData>();
                    ZTreeItemData itemData = new ZTreeItemData()
                    {
                        name = "根节点",
                        Id = "0",
                    };
                    treeDatas.Add(itemData);
                    foreach (XT_ROLE item in roles)
                    {
                        ZTreeItemData data = new ZTreeItemData
                        {
                            Id = item.ID,
                            name = item.ROLE_NAME,
                            PId = item.PARENT_ID,
                        };
                        data.AddAttribute("SORT", item.SORT);
                        treeDatas.Add(data);
                    }
                    result.Data = treeDatas;
                    break;
                case "Deleterole":
                    if (string.IsNullOrWhiteSpace(roleId))
                    {
                        result.Data = false;
                        break;
                    }
                    roleService.DeleteAndChilderById(roleId);
                    result.Data = true;
                    break;
                case "roleMove":
                    List<string[]> roleList = GetParams<List<string[]>>("treeroles");
                    try
                    {
                        foreach (string[] item in roleList)
                        {
                            roleService.UpdataSotrAndGroup(item[0], item[1], int.Parse(item[2]));
                        }
                        result.Data = new object[2] { true, roleList };
                    }
                    catch (Exception e)
                    {
                        result.Data = new object[2] { false, roleList };
                    }

                    break;
                case "AddRole":
                    role = GetParams<XT_ROLE>("xt_role");
                    if (role == null)
                    {
                        result.Data = false;
                    }
                    role.CREATE_BY = UserInfo.ID;
                    role.MODIFY_BY = UserInfo.ID;
                   
                    role = (XT_ROLE)roleService.Insert(role, true);
                    ZTreeItemData newrole = new ZTreeItemData
                    {
                        Id = role.ID,
                        name = role.ROLE_NAME,
                        PId = role.PARENT_ID,
                    };
                 
                    newrole.AddAttribute("SORT", role.SORT);
                    result.Data = new object[2] { true, newrole };
                    break;
                case "modityMenn":
                    role = GetParams<XT_ROLE>("xt_role");
                    roleService.InsertOrUpdate(role);
                    break;

            }
            return result;
        }
        /// <summary>
        /// 用户角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult UserRoleManage() {
            if (string.IsNullOrWhiteSpace(action)) {
                return View();
            }
            JsonResult result = new JsonResult();
            SysRoleService roleService = GetService<SysRoleService>();
            XT_UserService userService = GetService<XT_UserService>();
            
            List<XT_ROLE> roles = null;
            string roleId = null;
            switch (action) {
                case "GetRoles":
                    roles = roleService.SelectByUser(GetCurrerUser().ID);
                    List<ZTreeItemData> ztreeList = ZTreeItemData.CreateZTreeData("0","根节点");
                   
                    foreach (XT_ROLE role in roles) {
                        ztreeList.Add(new ZTreeItemData() {
                            name=role.ROLE_NAME,
                            Id=role.ID,
                            PId=role.PARENT_ID,
                        });
                    }
                    result.Data = ztreeList;
                    break;
                case "GetAllUsers":
                    //roles= roleService.SelectByUser(GetCurrerUser().ID);
                
                    result.Data= userService.SelectAll();
                    break;
                case "GetRoleUser":
                    roleId = GetParams("roleId");
                    result.Data=userService.SelectByRoleId(roleId);
                    break;
                case "saveUserRole":
                    List<XT_USER_ROLE> user_role_list = GetParams<List<XT_USER_ROLE>>("user_role_list");
                    roleId = GetParams("roleId");
                    SysRoleUserService roleUserService = GetService<SysRoleUserService>();
                    roleUserService.DeleteByRoleId(roleId);
                    if (user_role_list != null) {
                        foreach (XT_USER_ROLE user_role in user_role_list) {
                            user_role.ROLE_ID = roleId;
                            roleUserService.InsertOrUpdate(user_role);
                        }
                    }
                    result.Data = true;
                    break;
            }
            return result;
        }
    }
}