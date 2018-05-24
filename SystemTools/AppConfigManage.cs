namespace SystemTools
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Configuration;

    public class AppConfigManage
    {

        public static ConnectionStringSettings CurrentDb()
        {
            ConnectionStringSettingsCollection settingss = GetCurrentAppConnetionStringCollection();
            string str = GetDataBaseDefaultConnectName();
            return settingss[str];
        }

        public static T GetConfigValue<T>(string key)
        {
           
            if (string.IsNullOrWhiteSpace(key))
            {
                return default(T);
            }
           
            string value = "";
            if (IsWebApp())
            {
                value = WebConfigurationManager.AppSettings[key];
            }
            else {
                value = ConfigurationManager.AppSettings[key];
            }
            return StringTools.StringToType<T>(value);
        }

        #region 获取数据库配置信息
        /// <summary>
        /// 获取数据库配置信息
        /// </summary>
        /// <returns></returns>
        public static ConnectionStringSettingsCollection GetCurrentAppConnetionStringCollection()
        {
            ConnectionStringSettingsCollection settingss;
         
            settingss = null;
            if (IsWebApp())
            {
                settingss = WebConfigurationManager.ConnectionStrings;
            }
            else {
                settingss = ConfigurationManager.ConnectionStrings;
            }
            if (settingss == null) {
                throw new Exception("获取数据库配置信息失败请配置 ConnectionStringSettingsCollection 节点");
            }
            return settingss;
        }
        #endregion

        #region 获取默认数据库连接字符串
        /// <summary>
        /// 获取默认数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetDataBaseDefaultConnectName()
        {
            string connectStr = "";
            if (IsWebApp())
            {
                connectStr = ConfigurationManager.AppSettings["defaule_sql_connect"];
            }
            else {
                connectStr=WebConfigurationManager.AppSettings["defaule_sql_connect"];
            }
           
            if (string.IsNullOrWhiteSpace(connectStr))
            {
                throw new Exception("没有配置defaule_sql_connect这个节点");
            }
            return connectStr;
        }
        #endregion

        #region 获取系统日志数据库配置连接名称
        /// <summary>
        /// 获取系统日志数据库配置连接名称
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultSysLogConfig()
        {
            string connectStr = "";
            if (IsWebApp())
            {
                connectStr = WebConfigurationManager.AppSettings["default_log_connect"];
            }
            else {
                connectStr = ConfigurationManager.AppSettings["default_log_connect"];
            }
            if (string.IsNullOrWhiteSpace(connectStr)) {
                throw new Exception("没有配置default_log_connect这个节点");
            }
            return connectStr;
        }
        #endregion

        #region 获取系统日志数据库配置信息
        /// <summary>
        /// 获取系统日志数据库配置信息
        /// </summary>
        /// <returns></returns>
        public static ConnectionStringSettings GetSysLogConnection()
        {
            ConnectionStringSettingsCollection settingss;
            string connectStr = GetDataBaseDefaultConnectName() ;
        
            settingss = GetCurrentAppConnetionStringCollection();
      
           
            return settingss[connectStr];
        }
        #endregion

        #region 获取web应用程序cookie标识
        /// <summary>
        /// 获取web应用程序cookie标识
        /// </summary>
        /// <returns></returns>
        public static string GetSysUserCookeFlag()
        {
            
            string str="";
            if (IsWebApp())
            {
                str = WebConfigurationManager.AppSettings["sys_cooke_user_flag"];
            }
           
            return str;
        }
        #endregion

        #region 获取默认用户配置信息
        /// <summary>
        /// 获取默认用户配置信息
        /// </summary>
        /// <returns></returns>
        public static string[] GetSysUserInfo()
        {
            string[] userInfo;

            if (IsWebApp())
            {
                userInfo = new string[] { WebConfigurationManager.AppSettings["SysManageName"], WebConfigurationManager.AppSettings["SysManagePwd"] };
            }
            else {
                userInfo = new string[] { ConfigurationManager.AppSettings["SysManageName"], ConfigurationManager.AppSettings["SysManagePwd"] };
            }
            if (userInfo == null || userInfo.Length < 1 || string.IsNullOrWhiteSpace(userInfo[0]) || string.IsNullOrWhiteSpace(userInfo[1])) {
                throw new Exception("获取系统默认管理员失败 请检查您的配置的 SysManageName 和 SysManagePwd");
            }
           
            return userInfo;
        }
        #endregion

        #region 获取web用户session配置标识
        /// <summary>
        /// 获取web用户session配置标识
        /// </summary>
        /// <returns></returns>
        public static string GetSysUserSessionFlag()
        {
            string session = null;
            if (IsWebApp())
            {
                session=WebConfigurationManager.AppSettings["sys_session_user_flag"];
            }
            return session;
        }
        #endregion

        #region 判断当前应用程序是否是web应用
        /// <summary>
        /// 判断当前应用程序是否是web应用
        /// </summary>
        /// <returns></returns>
        public static bool IsWebApp()
        {
            return HttpContext.Current!=null;
        }
        #endregion
    }
}

