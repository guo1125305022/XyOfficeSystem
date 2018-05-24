namespace SqlDataBaseService
{
    using SqlDataBaseService.sqlAction;
    using SqlDataBaseService.sqlAction.SQLIter;
    using SqlDataBaseService.sqlAction.sqlServer;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Data.SQLite;

    public class DataBaseFactory
    {
        private static SqlDataBaseService.sqlAction.BaseDBFactory baseDBExecute;
        private static Dictionary<string, SqlDataBaseService.ConnectInfo> dictionary;

        static DataBaseFactory()
        {
            baseDBExecute = new SqlDataBaseService.sqlAction.BaseDBFactory();
            return;
        }

        private DataBaseFactory()
        {
            base..ctor();
            return;
        }

        public static SqlDataBaseService.DataBaseType AnalyzeDayaBaseType(string providerName)
        {
            SqlDataBaseService.DataBaseType type;
            string str;
            SqlDataBaseService.DataBaseType type2;
            str = providerName;
            if ((str == "System.Data.SQLite") != null)
            {
                goto Label_002C;
            }
            if ((str == "MySql.Data.MySqlClient") != null)
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
            SqlDataBaseService.DataBaseType type;
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
            SqlDataBaseService.sqlAction.BaseDbActionService service2;
            service = null;
            switch ((connectInfo.BaseType - 1))
            {
                case 0:
                    goto Label_0020;

                case 1:
                    goto Label_0029;

                case 2:
                    goto Label_002B;
            }
            goto Label_002D;
        Label_0020:
            service = new SqlDataBaseService.sqlAction.SQLIter.SQLiterDbAction(connectInfo);
            goto Label_0036;
        Label_0029:
            goto Label_0036;
        Label_002B:
            goto Label_0036;
        Label_002D:
            service = new SqlDataBaseService.sqlAction.sqlServer.ServerDbAction(connectInfo);
        Label_0036:
            service2 = service;
        Label_003A:
            return service2;
        }

        public static SqlDataBaseService.ConnectInfo Factory(ConnectionStringSettings settings)
        {
            SqlDataBaseService.ConnectInfo info1;
            string str;
            SqlDataBaseService.ConnectInfo info;
            bool flag;
            bool flag2;
            SqlDataBaseService.ConnectInfo info2;
            if ((dictionary == null) == null)
            {
                goto Label_0019;
            }
            dictionary = new Dictionary<string, SqlDataBaseService.ConnectInfo>();
        Label_0019:
            str = settings.Name + ":" + settings.ConnectionString;
            if (dictionary.ContainsKey(str) == null)
            {
                goto Label_004F;
            }
            info2 = dictionary[str];
            goto Label_0086;
        Label_004F:
            info1 = new SqlDataBaseService.ConnectInfo();
            info1.ConnectString = settings.ConnectionString;
            info1.ConnectName = settings.Name;
            info1.BaseType = AnalyzeDayaBaseType(settings.ProviderName);
            info = info1;
            info2 = info;
        Label_0086:
            return info2;
        }
    }
}

