namespace SqlDataBaseService
{
    using MySql.Data.MySqlClient;
    using SqlDataBaseService.sqlAction;
    using SqlDataBaseService.sqlAction.SQLIter;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using Oracle.ManagedDataAccess.Client;
    using SqlDataBaseService.sqlAction.sqlServer;
    using SqlDataBaseService.sqlAction.mySql;
    using SqlDataBaseService.sqlAction.Oracle;

    public class DataBaseFactory
    {
        private static BaseDBFactory baseDBExecute = new BaseDBFactory();
        private static Dictionary<string, ConnectInfo> dictionary = new Dictionary<string, ConnectInfo>();

        private DataBaseFactory()
        {

        }
        /// <summary>
        /// 解析数据库类型
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static DataBaseType AnalyzeDayaBaseType(string providerName)
        {
            DataBaseType type;
            switch (providerName)
            {
                case "System.Data.SQLite":
                    type = DataBaseType.SQL_LITER;
                    break;
                case "MySql.Data.MySqlClient":
                    type = DataBaseType.SQL_MY_SQL;
                    break;
                case "System.Data.OleDb":
                    type = DataBaseType.SQL_ORACLE;
                    break;
                default:
                    type = DataBaseType.SQL_SERVER;
                    break;
            }
            return type;
        }

        /// <summary>
        /// 数据库连接对象创建
        /// </summary>
        /// <param name="connectinfo"></param>
        /// <returns></returns>
        public static DbConnection ConnectionFactory(ConnectInfo connectinfo)
        {
            DbConnection connection = null;
            switch (connectinfo.BaseType)
            {
                case DataBaseType.SQL_LITER:
                    connection = baseDBExecute.CreateSQLConnect<SQLiteConnection>(connectinfo.ConnectString);
                    break;
                case DataBaseType.SQL_MY_SQL:
                    connection = baseDBExecute.CreateSQLConnect<MySqlConnection>(connectinfo.ConnectString);
                    break;
                case DataBaseType.SQL_ORACLE:
                    connection = baseDBExecute.CreateSQLConnect<OracleConnection>(connectinfo.ConnectString);
                    break;
                default:
                    connection = baseDBExecute.CreateSQLConnect<SqlConnection>(connectinfo.ConnectString);
                    break;
            }
            return connection;
        }

        /// <summary>
        /// 根据数据库类型创建数据库命令执行
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static DbCommand DbCommandFactory(ConnectInfo info)
        {
            DbCommand command = null;
            switch (info.BaseType)
            {
                case DataBaseType.SQL_LITER:
                    command = new SQLiteCommand();
                    break;
                case DataBaseType.SQL_MY_SQL:
                    command = new MySqlCommand();
                    break;
                case DataBaseType.SQL_SERVER:
                    command = new SqlCommand();
                    break;
                case DataBaseType.SQL_ORACLE:
                    command =new  OracleCommand();
                    break;
            }
            return command;
        }

        /// <summary>
        /// 创建数据库操作对象
        /// </summary>
        /// <param name="connectInfo">数据库连接信息</param>
        /// <returns></returns>
        public static BaseDbActionService DbServerFactory(ConnectInfo connectInfo)
        {
            BaseDbActionService service = null;

            switch (connectInfo.BaseType)
            {
                case DataBaseType.SQL_LITER:
                    service = new SQLiterDbAction(connectInfo);
                    break;
                case DataBaseType.SQL_MY_SQL:
                    service = new MySqlDbAction(connectInfo);
                    break;
                case DataBaseType.SQL_ORACLE:
                    service = new OracleSqlDbAction(connectInfo);
                    break;
                default:
                    service = new ServerDbAction(connectInfo);
                    break;
            }

            return service;
        }
        /// <summary>
        /// 创建数据库连接信息
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static ConnectInfo Factory(ConnectionStringSettings settings)
        {
            ConnectInfo info;
            string str = settings.Name + ":" + settings.ConnectionString;
            if (!dictionary.ContainsKey(str))
            {
                info = new ConnectInfo
                {
                    ConnectString = settings.ConnectionString,
                    ConnectName = settings.Name,
                    BaseType = AnalyzeDayaBaseType(settings.ProviderName)
                    
                };
                info.DbService = DbServerFactory(info);
                dictionary.Add(str, info);
            }
            info = dictionary[str];
            return info;
        }
    }
}

