

using SqlDataBaseService;
using System;
using System.Web;
using SystemBusiness;
using SystemBusiness.user;
using SystemModels.sys;
using SystemModels.user;
using SystemModels.webData.user;
using SystemTools;
using SystemTools.security;
using SystemTools.webulits;

namespace XyOfficeSystem.DataLogic
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManage
    {
        #region 用户登录验证
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="userLoginName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static UserLoginData Login(string userLoginName, string pwd)
        {
            UserLoginData loginData = new UserLoginData();
            SQLHelper helper = new SQLHelper("select * from XT_USER where USER_NAME=@0 and PWD=@1", userLoginName,MD5Ulits.GetMd5Hash( pwd));
            XT_UserService service = ServiceManage.GetService<XT_UserService>();
            XT_USER user = service.SelectFirstOrDefault(helper);

            if (user == null && userLoginName == AppConfigManage.GetSysUserInfo()[0])
            {
                user = service.SelectByLoginName(userLoginName);
                if (user != null)
                {
                    loginData.Message = "用户名或密码错误";
                    loginData.LoginState = false;
                    return loginData;
                }
                user = new XT_USER()
                {
                    USER_NAME = userLoginName,
                    PWD = MD5Ulits.GetMd5Hash(pwd),
                    CREATE_BY = "system_",
                    CREATE_TIME = DateTime.Now,
                    LOGIN_NAME = userLoginName,
                    MODIFY_BY = "system_",
                    MODIFY_TIME = DateTime.Now,
                    PING_YIN = ""
                };
                service.Insert(user);
            }
            else
            {
                if (user == null)
                {
                    loginData.Message = "用户名或密码错误";
                    loginData.LoginState = false;
                    return loginData;
                }
            }

            loginData.Message = "登录成功";
            loginData.LoginState = true;
            loginData.Data = user;
            return loginData;

        }
        #endregion

        public static void SaveToSession(XT_TEMP_PORARY_USER user) {
            XT_LOGIN_INFO info = new XT_LOGIN_INFO()
            {
                USER_ID = user.ID,
                ID = GuidTools.NewGuid(),
                LOGIN_ADRESS_IP = HttpContext.Current.Request.UserHostAddress,
                LOGIN_ADDRESS_MAC = "",
                CREATE_BY = "_system",
                CREATE_TIME = DateTime.Now,
                MODIFY_BY = "_system",
                MODIFY_TIME = DateTime.Now
            };
            SaveToSession(info);
        }
        #region 保存用户信息到服务器中
        /// <summary>
        /// 保存用户信息到服务器中
        /// </summary>
        /// <param name="user"></param>
        public static void SaveToSession(XT_USER user)
        {
            XT_LOGIN_INFO info = new XT_LOGIN_INFO()
            {
                USER_ID = user.ID,
                ID = GuidTools.NewGuid(),
                LOGIN_ADRESS_IP = HttpContext.Current.Request.UserHostAddress,
                LOGIN_ADDRESS_MAC = "",
                CREATE_BY = "_system",
                CREATE_TIME = DateTime.Now,
                MODIFY_BY = "_system",
                MODIFY_TIME = DateTime.Now
            };
            SaveToSession(info);
        }
        #endregion
        public static void SaveToSession(XT_LOGIN_INFO info) {
            XT_LoginInfoService service = ServiceManage.GetService<XT_LoginInfoService>();
            service.Insert(info);
            string key = Base64Ulits.EncryptBase64(AppConfigManage.GetSysUserSessionFlag());
            string value = value = Base64Ulits.EncryptBase64(info.ID);
            value = Base64Ulits.EncryptBase64(value);
            SessionUlits.Save(key, value);
        }
        #region 获取客服端用户登录的信息
        /// <summary>
        /// 获取客服端用户登录的信息
        /// </summary>
        /// <returns></returns>
        public static XT_LOGIN_INFO GetLoginInfo()
        {
            string key = Base64Ulits.EncryptBase64(AppConfigManage.GetSysUserSessionFlag());
            string loginId = (string)SessionUlits.GetData(key);
            if (string.IsNullOrWhiteSpace(loginId))
            {
                return null;
            }
            loginId = Base64Ulits.DecryptBase64(loginId);
            loginId = Base64Ulits.DecryptBase64(loginId);
            XT_LoginInfoService service = ServiceManage.GetService<XT_LoginInfoService>();
            SQLHelper helper = new SQLHelper("select * from XT_LOGIN_INFO where ID=@0", loginId);
            XT_LOGIN_INFO info = service.SelectFirstOrDefault(helper);
            return info;
        }
        #endregion

        #region 获取当前用户信息
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public static XT_USER GetCurrentUserInfo()
        {
            XT_LOGIN_INFO info = GetLoginInfo();
            if (info == null)
            {
                return null;
            }
            XT_USER user = null;
            XT_UserService service = ServiceManage.GetService<XT_UserService>();
            SQLHelper helper = new SQLHelper("select * from XT_USER where ID=@0", info.USER_ID);
            user = service.SelectFirstOrDefault(helper);
            if (user != null)
            {
                return user;
            }
            XT_TempUserService tempService = ServiceManage.GetService<XT_TempUserService>();
            helper = new SQLHelper("select * from XT_TEMP_PORARY_USER  where  ID=@0", info.ID);
            XT_TEMP_PORARY_USER tempUser = tempService.SelectFirstOrDefault(helper);
            if (tempUser == null) {
                return null;
            }
            user = new XT_USER()
            {
                USER_NAME = tempUser.USER_NAME,
                CREATE_BY = tempUser.CREATE_BY,
                CREATE_TIME = tempUser.CREATE_TIME,
                LOGIN_NAME = null,
                MODIFY_BY = tempUser.MODIFY_BY,
                MODIFY_TIME = tempUser.MODIFY_TIME,

            };

            return user;

        }
        #endregion
    }
}
