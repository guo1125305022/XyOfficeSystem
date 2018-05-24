namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using SqlDataBaseService.objectUlits;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public abstract class BaseDbActionService : BaseCommandService, IDisposable, ISQLBaseAction, IDBExectu
    {
        private ConnectInfo connectInfo;
        protected DbConnection connection;
        private bool disposedValue;
        protected PropertyInfo paramterInfo;


        public BaseDbActionService(ConnectInfo connectInfo)
        {
            paramterInfo = null;
            disposedValue = false;
            this.connectInfo = connectInfo;
            InitConnection();


        }

        public DbTransaction BeginTransaction()
        {
            OpenConnect();
            DbTransaction transaction = connection.BeginTransaction();
            return transaction;
        }

        protected A CreateParameter<A>(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return default(A);
            }
            Type type = typeof(A);
            return (A)Activator.CreateInstance(type, new object[] { key, value });
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public int Delete(SQLHelper helper)
        {

            return ExecuteNonQuery(helper);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Delete(object obj, string key, object value)
        {
            string tableName = ObjectResolverManage.GetInstance().GetTableName(obj);
            SQLHelper helper = new SQLHelper(@"delete " + tableName + " where {key}=@0", value);
            return Delete(helper);
        }

        public void Dispose()
        {
            Dispose(true);

        }

        protected virtual void Dispose(bool disposing)
        {
            connection.Close();
        }

        public DbDataAdapter ExecteAdapter(SQLHelper helper)
        {
            DbCommand command = SQlHelperToCommand(helper);
            DbDataAdapter adapter = ExecteAdapter(command);
            return adapter;
        }

        public abstract DbDataAdapter ExecteAdapter(DbCommand cmd);
        public abstract Page<A> ExectuePage<A>(long startIndex, int pageSize, SQLHelper helper);
        public int ExecuteNonQuery(SQLHelper helper)
        {
            this.OpenConnect();
            DbCommand command = SQlHelperToCommand(helper);
            return command.ExecuteNonQuery();
        }

        public DbDataReader ExecuteReader(SQLHelper helper)
        {
            OpenConnect();
            DbDataReader reader = SQlHelperToCommand(helper).ExecuteReader();
            return reader;
        }

        public object ExecuteScalar(SQLHelper helper)
        {
            return SQlHelperToCommand(helper).ExecuteScalar();
        }

        public DataTable ExecuteToDataTable(SQLHelper helper)
        {

            DataTable table;
            DbCommand command = SQlHelperToCommand(helper);
            DbDataAdapter adapter = ExecteAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            return table;
        }
        /// <summary>
        /// 获取数据记录
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public List<Dictionary<string, object>> ExecuteToList(SQLHelper helper)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>(); ;
            DbDataReader reader = ExecuteReader(helper);
            while (reader.Read())
            {
                Dictionary<string, object> row = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row.Add(reader.GetName(i), reader.GetValue(i));
                }
                list.Add(row);
            }
            reader.Close();
            return list;
        }


        /// <summary>
        /// 获取数据库命令执行对象
        /// </summary>
        /// <returns></returns>
        public DbCommand GetDbCommand()
        {
            DbCommand command;
            command = DataBaseFactory.DbCommandFactory(connectInfo);
            return command;
        }

        private void InitConnection()
        {
            connection = DataBaseFactory.ConnectionFactory(connectInfo);
        }

        public int Insert(SQLHelper helper)
        {
            return ExecuteNonQuery(helper);
        }

        public int Insert(object obj)
        {

            SQLHelper helper = ObjectToInsertSQlHelper(obj);
            return Insert(helper);
        }

        protected SQLHelper ObjectToDeleteSQlHelper(object obj, string key, object whereValue)
        {
            ObjectResolverManage manage = ObjectResolverManage.GetInstance();
            List<ClassFiledInfo> list = manage.GetTableColumnsInfo(obj);
            SQLHelper helper = new SQLHelper("delete " + manage.GetTableName(obj) + " ");
            helper.Append(" where " + key + "=@" + key);
            helper.AddParameter(whereValue);
            return helper;
        }

        protected SQLHelper ObjectToInsertSQlHelper(object obj)
        {
            ObjectResolverManage manage = ObjectResolverManage.GetInstance();
            List<ClassFiledInfo> list = manage.GetTableColumnsInfo(obj);
            string tableName = manage.GetTableName(obj);
            SQLHelper helper = new SQLHelper("insert into " + tableName + "(");
            int index = 0;
            StringBuilder sb_valueFlag = new StringBuilder();
            foreach (ClassFiledInfo info in list)
            {
                if (index < 1)
                {
                    sb_valueFlag.Append("@" + info.ColunmName);
                    helper.Append(info.ColunmName, info.MpropertyInfo.GetValue(obj));
                }
                else
                {
                    sb_valueFlag.Append(",@" + info.ColunmName);
                    helper.Append("," + info.ColunmName, info.MpropertyInfo.GetValue(obj));
                }
                index++;
            }
            helper.Append(")values(");
            helper.Append(sb_valueFlag.ToString());
            helper.Append(")");
            return helper;
        }
        /// <summary>
        /// 将实体对象转换为sql中的更新语句
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="whereValue"></param>
        /// <returns></returns>
        protected SQLHelper ObjectToUpdataSQlHelper(object obj, string key, object whereValue)
        {
            ObjectResolverManage manage = ObjectResolverManage.GetInstance();
            List<ClassFiledInfo> list = manage.GetTableColumnsInfo(obj);
            StringBuilder builder = new StringBuilder();
            SQLHelper helper = new SQLHelper("updata " + manage.GetTableName(obj) + " set ");
            int num = 0;
            foreach (ClassFiledInfo info in list)
            {
                if (num < 1)
                {
                    helper.Append(info.ColunmName + "=@" + info.ColunmName, info.ColunmValue);
                }
                else
                {
                    helper.Append("," + info.ColunmName + "=@" + info.ColunmName, info.ColunmValue);
                }
            }
            helper.Append(" where " + key + "=@" + key, whereValue);
            return helper;
        }
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        protected void OpenConnect()
        {

            if (string.IsNullOrWhiteSpace(connection.DataSource) || string.IsNullOrWhiteSpace(connection.ConnectionString))
            {
                throw new Exception("未找到数据库");
            }

            if (connection.State == ConnectionState.Closed)
            {

                connection.Open();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>
        public List<T> Select<T>(SQLHelper helper)
        {
            DbCommand command = SQlHelperToCommand(helper);
            DbDataReader reader = ExecuteReader(helper);
            Type type = typeof(T);
            List<ClassFiledInfo> filedInfos = ObjectResolverManage.GetInstance().GetTableColumnsInfo(type);
            List<T> list = new List<T>();
            while (reader.Read())
            {
                T model = (T)ObjectResolverManage.CreateObjectBy(type);
                foreach (ClassFiledInfo info in filedInfos)
                {
                    info.MpropertyInfo.SetValue(model, reader[info.ColunmName]);
                }
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public long SelectCount(SQLHelper helper)
        {
            SQLHelper countHelper = new SQLHelper(@"select Count(*) as CountNumber from (" + helper.Sql + ") as temp ", helper.Parameters);
            long num = -1;
            try
            {
                DbDataReader reader = ExecuteReader(countHelper);
                reader.Read();
                num = Convert.ToInt64(reader["CountNumber"]);
                reader.Close();
            }
            catch (Exception e)
            {

            }
            return num;
        }

        public T SelectFirstOrDefault<T>(SQLHelper helper)
        {
            DbCommand command = SQlHelperToCommand(helper);
            DbDataReader reader = ExecuteReader(helper);
            List<ClassFiledInfo> list = ObjectResolverManage.GetInstance().GetTableColumnsInfo(typeof(T));
            try
            {
                reader.Read();
                T mode = (T)ObjectResolverManage.CreateObjectBy(typeof(T));
                foreach (ClassFiledInfo info in list)
                {
                    info.MpropertyInfo.SetValue(mode, reader[info.ColunmName]);
                }
                return mode;
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return default(T);
        }

        protected DbCommand SQlHelperToCommand(SQLHelper helper)
        {
            Regex regex = new Regex(@"@\w*");
            DbCommand command = GetDbCommand();
            command.CommandText = helper.Sql;
            command.Connection = connection;
            if (helper.Parameters == null || helper.Parameters.Count < 1)
            {
                return command;
            }
            if (!helper.Sql.Contains("@"))
            {
                return command;
            }

            MatchCollection matchs = regex.Matches(helper.Sql);

            if (matchs.Count != helper.Parameters.Count)
            {
                throw new Exception("");
            }

            Array arr = Array.CreateInstance(command.CreateParameter().GetType(), matchs.Count);

            int num = 0;
            foreach (Match match in matchs)
            {
                string flagName = match.Value;
                object value = helper.Parameters[num];
                DbParameter dbParameter = command.CreateParameter();
                dbParameter.ParameterName = flagName;
                dbParameter.Value = value;
                arr.SetValue(dbParameter, num);
                num++;
            }


            command.Parameters.AddRange(arr);

            OpenConnect();
            return command;
        }

        /// <summary>
        /// 更新语句
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public int Update(SQLHelper helper)
        {
            return ExecuteNonQuery(helper);
        }

        /// <summary>
        /// sql更新
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Update(object obj, string key, object value)
        {
            SQLHelper helper = ObjectToUpdataSQlHelper(obj, key, value);
            return Update(helper);
        }

        /// <summary>
        /// 当前数据名称
        /// </summary>
        /// <returns></returns>
        public abstract string getCurrentDataBaseName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string ShowALLDataBaseSQL();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataBaseName"></param>
        /// <returns></returns>
        public abstract string ShowAllDataBaseTables(string dataBaseName);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string ShowAllDataBaseTables();

    }
}

