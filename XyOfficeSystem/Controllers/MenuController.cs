using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemBusiness;
using SystemBusiness.sys;
using SystemModels.sys;
using SystemModels.webData.ztree;
using System.IO;

namespace XyOfficeSystem.Controllers
{
    public class MenuController : BaseController
    {
        // GET: Menu
        public ActionResult Index()
        {
            if (string.IsNullOrWhiteSpace(action)) {
                string path=Server.MapPath("~/images/menu");
                DirectoryInfo directory = new DirectoryInfo(path);
                FileInfo[] files = directory.GetFiles("*.png");
                List<string> list = new List<string>();
                foreach (FileInfo info in files) {
                    list.Add("~/images/menu/"+info.Name);
                }
                ViewBag.MenuIcos = list;
                return View();
            }
            JsonResult result = new JsonResult();
            string menuId = GetParams("menuId");
            SysMenuService menuService = GetService<SysMenuService>();
            XT_MENU menu = null;
            switch (action) {
                case "GetMenus":
                    List<XT_MENU> menus=menuService.SelectAll(new List<string>() { "PARENT_ID", "SORT" });
                    List<ZTreeItemData> treeDatas = new List<ZTreeItemData>();
                    ZTreeItemData itemData = new ZTreeItemData()
                    {
                        name = "菜单根节点",
                        Id = "0",
                    };
                    treeDatas.Add(itemData);
                    foreach (XT_MENU item in menus) {
                        ZTreeItemData data = new ZTreeItemData {
                             Id=item.ID,
                             name=item.MENU_NAME,
                             PId=item.PARENT_ID,
                        };
                        data.AddAttribute("MENU_URL", item.MENU_URL);
                        data.AddAttribute("ICON", item.ICON);
                        data.AddAttribute("SORT", item.SORT);
                        treeDatas.Add(data);
                    }
                    result.Data = treeDatas;
                    break;
                case "DeleteMenu":
                    if (string.IsNullOrWhiteSpace(menuId)) {
                        result.Data = false;
                        break;
                    }
                    menuService.DeleteMenuAndChilderById(menuId);
                    result.Data = true;
                    break;
                case "menuMove":
                    List<string[]> menuList = GetParams<List<string[]>>("treeMenus");
                    try
                    {
                        foreach (string[] item in menuList)
                        {
                            menuService.UpdataMenuSotrAndGroup(item[0], item[1], int.Parse(item[2]));
                        }
                        result.Data = new object[2] { true, menuList };
                    }
                    catch (Exception e) {
                        result.Data = new object[2] { false, menuList };
                    }
                   
                    break;
                case "AddMenu":
                    menu = GetParams<XT_MENU>("xt_menu");
                    if (menu == null) {
                        result.Data = false;
                    }
                    menu.CREATE_BY = UserInfo.ID;
                    menu.MODIFY_BY = UserInfo.ID;
                    if (string.IsNullOrWhiteSpace(menu.MENU_URL)) {
                        menu.MENU_URL = "";
                    }
                    menu= (XT_MENU)menuService.Insert(menu,true);
                    ZTreeItemData newMenu = new ZTreeItemData
                    {
                        Id = menu.ID,
                        name = menu.MENU_NAME,
                        PId = menu.PARENT_ID,
                    };
                    newMenu.AddAttribute("MENU_URL", menu.MENU_URL);
                    newMenu.AddAttribute("ICON", menu.ICON);
                    newMenu.AddAttribute("SORT", menu.SORT);
                    result.Data = new object[2] { true, newMenu };
                    break;
                case "modityMenn":
                    menu = GetParams<XT_MENU>("xt_menu");
                    menuService.InsertOrUpdate(menu);
                    break;
                    
            }
            return result;
           
        }


    }
}