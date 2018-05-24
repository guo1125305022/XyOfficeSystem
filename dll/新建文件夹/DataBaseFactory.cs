namespace SqlDataBaseService
{

    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Common;


    public class DataBaseFactory
    {
        private static BaseDBFactory baseDBExecute;
        private static Dictionary<string, SqlDataBaseService.ConnectInfo> dictionary;

        static DataBaseFactory()
        {
            baseDBExecute = new SqlDataBaseService.sqlAction.BaseDBFactory();
            return;
        }

        private DataBaseFactory()
        {
         
        }

        public static SqlDataBaseService.DataBaseType AnalyzeDayaBaseType(string providerName)
        {
            SqlDataBaseService.DataBaseType type;
            string str;
            SqlDataBaseService.DataBaseType type2;
            str = providerName;
            switch (str) {
                case "System.Data.SQLite":
                    break;
                case "MySql.Data.MySqlClient":
                    break;
                case "System.Data.OleDb":
                    break;
                default:

                    break;
            }
            if ((str == "System.Data.SQLite") != null)
            {
                goto Label_002C;
            }
            if (str == "MySql.Data.MySqlClient")
            {
                goto Label_0030;
            }
            if ((str == "System.Data.OleDb") != null)
            {
                goto Label_0034;
            }
            goto Label_0038;
        Label_002C:
            type = 1;
            goto Label_003C;
        Label_0030:
            type = 2;
            goto Label_003C;
        Label_0034:
            type = 3;
            goto Label_003C;
        Label_0038:
            type = 0;
        Label_003C:
            type2 = type;
        Label_0040:
            return type2;
        }

        public static DbConnection ConnectionFactory(SqlDataBaseService.ConnectInfo connectinfo)
        {
            DbConnection connection;
            DataBaseType type;
            DbConnection connection2;
            connection = null;
            switch ((connectinfo.BaseType - 1))
            {
                case 0:
                    goto Label_0020;

                case 1:
                    goto Label_0033;

                case 2:
                    goto Label_0035;
            }
            goto Label_0037;
        Label_0020:
            connection = baseDBExecute.CreateSQLConnect<SQLiteConnection>(connectinfo.ConnectString);
            goto Label_004A;
        Label_0033:
            goto Label_004A;
        Label_0035:
            goto Label_004A;
        Label_0037:
            connection = baseDBExecute.CreateSQLConnect<SqlConnection>(connectinfo.ConnectString);
        Label_004A:
            connection2 = connection;
        Label_004E:
            return connection2;
        }

        public static DbCommand DbCommandFactory(SqlDataBaseService.ConnectInfo info)
        {
            DbCommand command;
            SqlDataBaseService.DataBaseType type;
            DbCommand command2;
            command = null;
            switch ((info.BaseType - 1))
            {
                case 0:
                    goto Label_0020;

                case 1:
                    goto Label_0028;

                case 2:
                    goto Label_002A;
            }
            goto Label_002C;
        Label_0020:
            command = new SQLiteCommand();
            goto Label_0034;
        Label_0028:
            goto Label_0034;
        Label_002A:
            goto Label_0034;
        Label_002C:
            command = new SqlCommand();
        Label_0034:
            command2 = command;
        Label_0038:
            return command2;
        }

        public static SqlDataBaseService.sqlAction.BaseDbActionService DbServerFactory(SqlDataBaseService.ConnectInfo connectInfo)
        {
            SqlDataBaseService.sqlAction.BaseDbActionService service;
            SqlDataBaseService.DataBaseType type;
          
            switch ((connectInfo.BaseType - 1))
            {
                case 0:
                    service = new SqlDataBaseService.sqlAction.SQLIter.SQLiterDbAction(connectInfo);
                case 1:
                  
                case 2:
                  
                default:
                    service = new SqlDataBaseService.sqlAction.sqlServer.ServerDbAction(connectInfo);
                    break;
            }
      
            return service;
        }

        public static ConnectInfo Factory(ConnectionStringSettings settings)
        {
            SqlDataBaseService.ConnectInfo info1;
            string str;
            SqlDataBaseService.ConnectInfo info;
            bool flag;
            bool flag2;
            SqlDataBaseService.ConnectInfo info2;
            if (dictionary == null)
            {
                str = settings.Name + ":" + settings.ConnectionString;
                if (dictionary.ContainsKey(str))
                {
                    info1 = new SqlDataBaseService.ConnectInfo();
                    info1.ConnectString = settings.ConnectionString;
                    info1.ConnectName = settings.Name;
                    info1.BaseType = AnalyzeDayaBaseType(settings.ProviderName);
                    info = info1;
                    info2 = info;
                }
                info2 = dictionary[str];
            }
            dictionary = new Dictionary<string, SqlDataBaseService.ConnectInfo>();
   
         
         
            return info2;
        }
    }
}

