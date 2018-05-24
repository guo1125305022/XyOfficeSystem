using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataBaseService.sqlAction
{
    public partial class BaseCommandService : IDBCommand
    {
        public DbCommand CreateCommand(DataBaseType dataBaseType)
        {
            Type type = GetCommandType(dataBaseType);
            DbCommand cmd =(DbCommand)Activator.CreateInstance(type);
            return cmd;
        }

        public DbCommand CreateCommand(DataBaseType dataBaseType, string sql)
        {
            DbCommand cmd = CreateCommand(dataBaseType);
            cmd.CommandText = sql;
            return cmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <param name="sql"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public DbCommand CreateCommand(DataBaseType dataBaseType, string sql, params object[] objects)
        {
            DbCommand cmd = CreateCommand(dataBaseType, sql);
            if (objects == null || objects.Length < 1) {
                return cmd;
            }
            string variableChar = GetSQLVariableChar(dataBaseType);
            if (!sql.Contains(variableChar)) {
                return cmd;
            }

            return cmd;


        }


        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        public Type GetCommandParameter(DataBaseType dataBaseType)
        {
            Type type = null;
            switch (dataBaseType)
            {
                case DataBaseType.SQL_LITER:
                    type = typeof(SQLiteParameter);
                    break;
                case DataBaseType.SQL_MY_SQL:
                    type = typeof(MySqlParameter);
                    break;
                case DataBaseType.SQL_ORACLE:
                    type = typeof(OracleParameter);
                    break;
                default:
                    type = typeof(SqlParameter);
                    break;
            }
            return type;
        }

        /// <summary>
        /// 获取命令参数执行对象类型
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        public Type GetCommandType(DataBaseType dataBaseType)
        {
            Type type = null;
            switch (dataBaseType)
            {
                case DataBaseType.SQL_LITER:
                    type = typeof(SQLiteCommand);
                    break;
                case DataBaseType.SQL_MY_SQL:
                    type = typeof(MySqlCommand);
                    break;
                case DataBaseType.SQL_ORACLE:
                    type = typeof(OracleCommand);
                    break;
                default:
                    type = typeof(SqlCommand);
                    break;
            }
            return type;
       
        }

        public string GetSQLVariableChar(DataBaseType dataBaseType)
        {
            String sql="@";
            switch (dataBaseType)
            {
                
                case DataBaseType.SQL_ORACLE:
                    sql = ":";
                    break;
                default:
                    sql = "@";
                    break;
            }
            return sql;
        }
    }
}
