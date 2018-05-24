namespace SystemTools
{
    using System;
    using System.Configuration;
    using System.Web;
    using System.Web.Configuration;

    public class AppConfigManage
    {
        public AppConfigManage()
        {
            base..ctor();
            return;
        }

        public static ConnectionStringSettings CurrentDb()
        {
            ConnectionStringSettingsCollection settingss;
            string str;
            ConnectionStringSettings settings;
            settingss = GetCurrentAppConnetionStringCollection();
            str = GetDataBaseDefaultConnectName();
            settings = settingss[str];
        Label_0017:
            return settings;
        }

        public static T GetConfigValue<T>(string key)
        {
            string str;
            bool flag;
            bool flag2;
            T local;
            T local2;
            bool flag3;
            if (string.IsNullOrWhiteSpace(key) == null)
            {
                goto Label_0019;
            }
            local2 = default(T);
            goto Label_0054;
        Label_0019:
            str = "";
            if (IsWebApp() == null)
            {
                goto Label_003C;
            }
            str = WebConfigurationManager.AppSettings[key];
            goto Label_004A;
        Label_003C:
            str = ConfigurationManager.AppSettings[key];
        Label_004A:
            local2 = StringTools.StringToType<T>(str);
        Label_0054:
            return local2;
        }

        public static ConnectionStringSettingsCollection GetCurrentAppConnetionStringCollection()
        {
            ConnectionStringSettingsCollection settingss;
            bool flag;
            bool flag2;
            ConnectionStringSettingsCollection settingss2;
            settingss = null;
            if (IsWebApp() == null)
            {
                goto Label_0018;
            }
            settingss = WebConfigurationManager.ConnectionStrings;
            goto Label_0020;
        Label_0018:
            settingss = ConfigurationManager.ConnectionStrings;
        Label_0020:
            settingss2 = settingss;
        Label_0024:
            return settingss2;
        }

        public static string GetDataBaseDefaultConnectName()
        {
            string str;
            bool flag;
            bool flag2;
            bool flag3;
            string str2;
            if (IsWebApp() == null)
            {
                goto Label_0020;
            }
            str = WebConfigurationManager.AppSettings["defaule_sql_connect"];
            goto Label_0032;
        Label_0020:
            str = ConfigurationManager.AppSettings["defaule_sql_connect"];
        Label_0032:
            if ((str == null) == null)
            {
                goto Label_0046;
            }
            throw new Exception("没有配置defaule_sql_connect这个节点");
        Label_0046:
            str2 = str;
        Label_004B:
            return str2;
        }

        public static string GetDefaultSysLogConfig()
        {
            string str;
            bool flag;
            bool flag2;
            bool flag3;
            string str2;
            if (IsWebApp() == null)
            {
                goto Label_0020;
            }
            str = WebConfigurationManager.AppSettings["default_log_connect"];
            goto Label_0032;
        Label_0020:
            str = ConfigurationManager.AppSettings["default_log_connect"];
        Label_0032:
            if ((str == null) == null)
            {
                goto Label_0046;
            }
            throw new Exception("没有配置default_log_connect这个节点");
        Label_0046:
            str2 = str;
        Label_004B:
            return str2;
        }

        public static ConnectionStringSettings GetSysLogConnection()
        {
            ConnectionStringSettingsCollection settingss;
            string str;
            ConnectionStringSettings settings;
            ConnectionStringSettings settings2;
            settingss = GetCurrentAppConnetionStringCollection();
            str = GetDataBaseDefaultConnectName();
            settings = settingss[str];
            settings2 = settings;
        Label_0019:
            return settings2;
        }

        public static string GetSysUserCookeFlag()
        {
            bool flag;
            string str;
            if ((IsWebApp() == 0) == null)
            {
                goto Label_0012;
            }
            str = null;
            goto Label_0024;
        Label_0012:
            str = WebConfigurationManager.AppSettings["sys_cooke_user_flag"];
        Label_0024:
            return str;
        }

        public static string[] GetSysUserInfo()
        {
            string[] strArray;
            bool flag;
            string[] strArray2;
            strArray = null;
        Label_0003:
            try
            {
                if (IsWebApp() == null)
                {
                    goto Label_003C;
                }
                strArray = new string[] { WebConfigurationManager.AppSettings["SysManageName"], WebConfigurationManager.AppSettings["SysManagePwd"] };
                goto Label_0069;
            Label_003C:
                strArray = new string[] { ConfigurationManager.AppSettings["SysManageName"], ConfigurationManager.AppSettings["SysManagePwd"] };
            Label_0069:
                goto Label_0079;
            }
            catch
            {
            Label_006C:
                throw new Exception("获取系统默认管理员失败 请检查您的配置的 SysManageName 和 SysManagePwd");
            }
        Label_0079:
            strArray2 = strArray;
        Label_007D:
            return strArray2;
        }

        public static string GetSysUserSessionFlag()
        {
            bool flag;
            string str;
            if ((IsWebApp() == 0) == null)
            {
                goto Label_0012;
            }
            str = null;
            goto Label_0024;
        Label_0012:
            str = WebConfigurationManager.AppSettings["sys_session_user_flag"];
        Label_0024:
            return str;
        }

        public static bool IsWebApp()
        {
            bool flag;
            flag = HttpContext.Current > null;
        Label_000C:
            return flag;
        }
    }
}

