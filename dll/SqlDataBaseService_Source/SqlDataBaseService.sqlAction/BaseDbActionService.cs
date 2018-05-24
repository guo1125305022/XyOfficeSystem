namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using SqlDataBaseService.objectUlits;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public abstract class BaseDbActionService : IDisposable, SqlDataBaseService.sqlAction.ISQLBaseAction, SqlDataBaseService.sqlAction.IDBExectu
    {
        private SqlDataBaseService.ConnectInfo connectInfo;
        protected DbConnection connection;
        private bool disposedValue;
        protected PropertyInfo paramterInfo;

        public BaseDbActionService(SqlDataBaseService.ConnectInfo connectInfo)
        {
            this.paramterInfo = null;
            this.disposedValue = 0;
            base..ctor();
            this.connectInfo = connectInfo;
            this.InitConnection();
            return;
        }

        public DbTransaction BeginTransaction()
        {
            DbTransaction transaction;
            DbTransaction transaction2;
            this.OpenConnect();
            transaction2 = this.connection.BeginTransaction();
        Label_0018:
            return transaction2;
        }

        protected A CreateParameter<A>(string key, object value)
        {
            object[] objArray1;
            Type type;
            bool flag;
            A local;
            A local2;
            if (string.IsNullOrWhiteSpace(key) == null)
            {
                goto Label_0018;
            }
            local2 = default(A);
            goto Label_003F;
        Label_0018:
            type = typeof(A);
            objArray1 = new object[] { key, value };
            local2 = (A) Activator.CreateInstance(type, objArray1);
        Label_003F:
            return local2;
        }

        public int Delete(SqlDataBaseService.SQLHelper helper)
        {
            int num;
            num = this.ExecuteNonQuery(helper);
        Label_000B:
            return num;
        }

        public int Delete(object obj, string key, object value)
        {
            object[] objArray1;
            string str;
            string str2;
            SqlDataBaseService.SQLHelper helper;
            int num;
            str = SqlDataBaseService.objectUlits.ObjectResolverManage.GetInstance().GetTableName(obj);
            objArray1 = new object[] { value };
            helper = new SqlDataBaseService.SQLHelper($"delete {str} where {key}=@0", objArray1);
            num = this.Delete(helper);
        Label_0035:
            return num;
        }

        public void Dispose()
        {
            this.Dispose(1);
            return;
        }

        protected virtual void Dispose(bool disposing)
        {
            bool flag;
            bool flag2;
            bool flag3;
            if ((this.disposedValue == 0) == null)
            {
                goto Label_0039;
            }
            if (disposing == null)
            {
                goto Label_0016;
            }
        Label_0016:
            if ((this.connection > null) == null)
            {
                goto Label_0031;
            }
            this.connection.Close();
        Label_0031:
            this.disposedValue = 1;
        Label_0039:
            return;
        }

        public DbDataAdapter ExecteAdapter(SqlDataBaseService.SQLHelper helper)
        {
            DbCommand command;
            DbDataAdapter adapter;
            command = this.SQlHelperToCommand(helper);
            adapter = this.ExecteAdapter(command);
        Label_0013:
            return adapter;
        }

        public abstract DbDataAdapter ExecteAdapter(DbCommand cmd);
        public abstract SqlDataBaseService.Page<A> ExectuePage<A>(long startIndex, int pageSize, SqlDataBaseService.SQLHelper helper);
        public int ExecuteNonQuery(SqlDataBaseService.SQLHelper helper)
        {
            DbCommand command;
            int num;
            command = this.SQlHelperToCommand(helper);
            this.OpenConnect();
            num = command.ExecuteNonQuery();
        Label_0019:
            return num;
        }

        public DbDataReader ExecuteReader(SqlDataBaseService.SQLHelper helper)
        {
            DbCommand command;
            DbDataReader reader;
            DbDataReader reader2;
            reader2 = this.SQlHelperToCommand(helper).ExecuteReader();
        Label_0014:
            return reader2;
        }

        public object ExecuteScalar(SqlDataBaseService.SQLHelper helper)
        {
            DbCommand command;
            object obj2;
            obj2 = this.SQlHelperToCommand(helper).ExecuteScalar();
        Label_0012:
            return obj2;
        }

        public DataTable ExecuteToDataTable(SqlDataBaseService.SQLHelper helper)
        {
            DbCommand command;
            DbDataAdapter adapter;
            DataTable table;
            DataTable table2;
            command = this.SQlHelperToCommand(helper);
            adapter = this.ExecteAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
            table2 = table;
        Label_002A:
            return table2;
        }

        public List<Dictionary<string, object>> ExecuteToList(SqlDataBaseService.SQLHelper helper)
        {
            List<Dictionary<string, object>> list;
            DbDataReader reader;
            int num;
            Dictionary<string, object> dictionary;
            int num2;
            string str;
            object obj2;
            bool flag;
            bool flag2;
            bool flag3;
            List<Dictionary<string, object>> list2;
            list = new List<Dictionary<string, object>>();
            reader = this.ExecuteReader(helper);
            goto Label_005F;
        Label_0011:
            num = reader.FieldCount;
            dictionary = new Dictionary<string, object>();
            num2 = 0;
            goto Label_004B;
        Label_0024:
            str = reader.GetName(num2);
            obj2 = reader[str];
            dictionary.Add(str, obj2);
            num2 += 1;
        Label_004B:
            if ((num2 < num) != null)
            {
                goto Label_0024;
            }
            list.Add(dictionary);
        Label_005F:
            if (reader.Read() != null)
            {
                goto Label_0011;
            }
            if ((reader > null) == null)
            {
                goto Label_007E;
            }
            reader.Close();
        Label_007E:
            list2 = list;
        Label_0083:
            return list2;
        }

        protected Type GetCommandParameterType(object commandObject)
        {
            object obj2;
            bool flag;
            bool flag2;
            bool flag3;
            Type type;
            obj2 = null;
            if (((commandObject as SQLiteCommand) > null) == null)
            {
                goto Label_001A;
            }
            obj2 = new SQLiteParameter();
            goto Label_002F;
        Label_001A:
            if (((commandObject as SqlCommand) > null) == null)
            {
                goto Label_002F;
            }
            obj2 = new SqlParameter();
        Label_002F:
            if ((obj2 == null) == null)
            {
                goto Label_003D;
            }
            type = null;
            goto Label_0047;
        Label_003D:
            type = obj2.GetType();
        Label_0047:
            return type;
        }

        public DbCommand GetDbCommand()
        {
            DbCommand command;
            command = SqlDataBaseService.DataBaseFactory.DbCommandFactory(this.connectInfo);
        Label_000F:
            return command;
        }

        private void InitConnection()
        {
            this.connection = SqlDataBaseService.DataBaseFactory.ConnectionFactory(this.connectInfo);
            return;
        }

        public int Insert(SqlDataBaseService.SQLHelper helper)
        {
            int num;
            num = this.ExecuteNonQuery(helper);
        Label_000B:
            return num;
        }

        public int Insert(object obj)
        {
            SqlDataBaseService.SQLHelper helper;
            int num;
            helper = this.ObjectToInsertSQlHelper(obj);
            num = this.Insert(helper);
        Label_0013:
            return num;
        }

        protected SqlDataBaseService.SQLHelper ObjectToDeleteSQlHelper(object obj, string key, object whereValue)
        {
            SqlDataBaseService.objectUlits.ObjectResolverManage manage;
            string str;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            SqlDataBaseService.SQLHelper helper;
            StringBuilder builder;
            SqlDataBaseService.SQLHelper helper2;
            manage = SqlDataBaseService.objectUlits.ObjectResolverManage.GetInstance();
            str = manage.GetTableName(obj);
            list = manage.GetTableColumnsInfo(obj);
            helper = new SqlDataBaseService.SQLHelper("delete " + str + " ", Array.Empty<object>());
            builder = new StringBuilder();
            helper.Append(builder.ToString(), Array.Empty<object>());
            helper.Append(" where " + key + "=@" + key, Array.Empty<object>());
            helper.AddParameter(whereValue);
            helper2 = helper;
        Label_0076:
            return helper2;
        }

        protected unsafe SqlDataBaseService.SQLHelper ObjectToInsertSQlHelper(object obj)
        {
            SqlDataBaseService.objectUlits.ObjectResolverManage manage;
            string str;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            SqlDataBaseService.SQLHelper helper;
            StringBuilder builder;
            StringBuilder builder2;
            int num;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo>.Enumerator enumerator;
            SqlDataBaseService.objectUlits.ClassFiledInfo info;
            object obj2;
            bool flag;
            SqlDataBaseService.SQLHelper helper2;
            manage = SqlDataBaseService.objectUlits.ObjectResolverManage.GetInstance();
            str = manage.GetTableName(obj);
            list = manage.GetTableColumnsInfo(obj);
            helper = new SqlDataBaseService.SQLHelper("insert into " + str, Array.Empty<object>());
            builder = new StringBuilder();
            builder2 = new StringBuilder();
            num = 0;
            enumerator = list.GetEnumerator();
        Label_0047:
            try
            {
                goto Label_00E0;
            Label_004C:
                info = &enumerator.Current;
                if ((num == 0) == null)
                {
                    goto Label_008D;
                }
                builder2.Append(info.ColunmName);
                builder.Append("@" + info.ColunmName);
                goto Label_00C1;
            Label_008D:
                builder2.Append("," + info.ColunmName);
                builder.Append(",@" + info.ColunmName);
            Label_00C1:
                obj2 = info.MpropertyInfo.GetValue(obj);
                helper.AddParameter(obj2);
                num += 1;
            Label_00E0:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_004C;
                }
                goto Label_00FD;
            }
            finally
            {
            Label_00EE:
                &enumerator.Dispose();
            }
        Label_00FD:
            builder2.Insert(0, "(");
            builder2.Insert(builder2.Length, ")");
            builder.Insert(0, "values(");
            builder.Insert(builder.Length, ")");
            helper.Append(builder2.ToString(), Array.Empty<object>());
            helper.Append(builder.ToString(), Array.Empty<object>());
            helper2 = helper;
        Label_016C:
            return helper2;
        }

        protected unsafe SqlDataBaseService.SQLHelper ObjectToUpdataSQlHelper(object obj, string key, object whereValue)
        {
            SqlDataBaseService.objectUlits.ObjectResolverManage manage;
            string str;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            SqlDataBaseService.SQLHelper helper;
            StringBuilder builder;
            int num;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo>.Enumerator enumerator;
            SqlDataBaseService.objectUlits.ClassFiledInfo info;
            object obj2;
            bool flag;
            SqlDataBaseService.SQLHelper helper2;
            manage = SqlDataBaseService.objectUlits.ObjectResolverManage.GetInstance();
            str = manage.GetTableName(obj);
            list = manage.GetTableColumnsInfo(obj);
            helper = new SqlDataBaseService.SQLHelper("updata " + str + " set ", Array.Empty<object>());
            builder = new StringBuilder();
            num = 0;
            enumerator = list.GetEnumerator();
        Label_0045:
            try
            {
                goto Label_00C6;
            Label_0047:
                info = &enumerator.Current;
                if ((num == 0) == null)
                {
                    goto Label_0080;
                }
                builder.Append(info.ColunmName + "=@" + info.ColunmName);
                goto Label_00A7;
            Label_0080:
                builder.Append("," + info.ColunmName + "=@" + info.ColunmName);
            Label_00A7:
                obj2 = info.MpropertyInfo.GetValue(obj);
                helper.AddParameter(obj2);
                num += 1;
            Label_00C6:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_0047;
                }
                goto Label_00E3;
            }
            finally
            {
            Label_00D4:
                &enumerator.Dispose();
            }
        Label_00E3:
            helper.Append(builder.ToString(), Array.Empty<object>());
            helper.Append(" where " + key + "=@" + key, Array.Empty<object>());
            helper.AddParameter(whereValue);
            helper2 = helper;
        Label_0120:
            return helper2;
        }

        protected void OpenConnect()
        {
            string str;
            bool flag;
            bool flag2;
            if (((string.IsNullOrWhiteSpace(this.connection.DataSource) == null) ? 0 : string.IsNullOrWhiteSpace(this.connection.ConnectionString)) == null)
            {
                goto Label_0038;
            }
            throw new Exception("未找到数据库");
        Label_0038:
            if (((this.connection.State == 0x10) ? 1 : (this.connection.State == 0)) == null)
            {
                goto Label_006A;
            }
            this.connection.Open();
        Label_006A:
            return;
        }

        public unsafe List<T> Select<T>(SqlDataBaseService.SQLHelper helper)
        {
            List<T> list;
            DbCommand command;
            DbDataReader reader;
            Type type;
            T local;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list2;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo>.Enumerator enumerator;
            SqlDataBaseService.objectUlits.ClassFiledInfo info;
            bool flag;
            bool flag2;
            List<T> list3;
            list = new List<T>();
            command = this.SQlHelperToCommand(helper);
            reader = this.ExecuteReader(helper);
            type = typeof(T);
            goto Label_00A3;
        Label_0024:
            local = (T) SqlDataBaseService.objectUlits.ObjectResolverManage.CreateObjectBy(type);
            list2 = SqlDataBaseService.objectUlits.ObjectResolverManage.GetInstance().GetTableColumnsInfo(type);
            enumerator = list2.GetEnumerator();
        Label_0049:
            try
            {
                goto Label_007F;
            Label_004B:
                info = &enumerator.Current;
            Label_0055:
                try
                {
                    info.MpropertyInfo.SetValue((T) local, reader[info.ColunmName]);
                    goto Label_007E;
                }
                catch
                {
                Label_007A:
                    goto Label_007F;
                }
            Label_007E:;
            Label_007F:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_004B;
                }
                goto Label_0099;
            }
            finally
            {
            Label_008A:
                &enumerator.Dispose();
            }
        Label_0099:
            list.Add(local);
        Label_00A3:
            if (reader.Read() != null)
            {
                goto Label_0024;
            }
            if ((reader > null) == null)
            {
                goto Label_00C5;
            }
            reader.Close();
        Label_00C5:
            list3 = list;
        Label_00CA:
            return list3;
        }

        public long SelectCount(SqlDataBaseService.SQLHelper helper)
        {
            object[] objArray1;
            string str;
            SqlDataBaseService.SQLHelper helper2;
            DbDataReader reader;
            long num;
            objArray1 = new object[] { helper.Parameters };
            helper2 = new SqlDataBaseService.SQLHelper($"select Count(*) as CountNumber from ({helper.Sql}) as temp ", objArray1);
            reader = this.ExecuteReader(helper2);
            num = -1L;
        Label_0035:
            return num;
        }

        public unsafe T SelectFirstOrDefault<T>(SqlDataBaseService.SQLHelper helper)
        {
            DbCommand command;
            DbDataReader reader;
            object obj2;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo>.Enumerator enumerator;
            SqlDataBaseService.objectUlits.ClassFiledInfo info;
            T local;
            bool flag;
            bool flag2;
            T local2;
            command = this.SQlHelperToCommand(helper);
            reader = this.ExecuteReader(helper);
            goto Label_00A0;
        Label_0016:
            obj2 = SqlDataBaseService.objectUlits.ObjectResolverManage.CreateObjectBy(typeof(T));
            list = SqlDataBaseService.objectUlits.ObjectResolverManage.GetInstance().GetTableColumnsInfo(typeof(T));
            enumerator = list.GetEnumerator();
        Label_0045:
            try
            {
                goto Label_0075;
            Label_0047:
                info = &enumerator.Current;
            Label_0051:
                try
                {
                    info.MpropertyInfo.SetValue(obj2, reader[info.ColunmName]);
                    goto Label_0074;
                }
                catch
                {
                Label_0070:
                    goto Label_0075;
                }
            Label_0074:;
            Label_0075:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_0047;
                }
                goto Label_008F;
            }
            finally
            {
            Label_0080:
                &enumerator.Dispose();
            }
        Label_008F:
            reader.Close();
            local = (T) obj2;
            goto Label_00D0;
        Label_00A0:
            if (reader.Read() != null)
            {
                goto Label_0016;
            }
            if ((reader > null) == null)
            {
                goto Label_00C2;
            }
            reader.Close();
        Label_00C2:
            local = default(T);
        Label_00D0:
            return local;
        }

        protected DbCommand SQlHelperToCommand(SqlDataBaseService.SQLHelper helper)
        {
            object[] objArray1;
            DbCommand command;
            Type type;
            Regex regex;
            MatchCollection matchs;
            Type type2;
            object[] objArray;
            int num;
            object obj2;
            bool flag;
            DbCommand command2;
            bool flag2;
            IEnumerator enumerator;
            Match match;
            string str;
            object obj3;
            IDisposable disposable;
            bool flag3;
            bool flag4;
            command = this.GetDbCommand();
            command.CommandText = helper.Sql;
            command.Connection = this.connection;
            type = command.GetType();
            if (((helper.Parameters == null) ? 1 : (helper.Parameters.Count < 1)) == null)
            {
                goto Label_0051;
            }
            command2 = command;
            goto Label_018E;
        Label_0051:
            if ((helper.Sql.Contains("@") == 0) == null)
            {
                goto Label_0073;
            }
            command2 = command;
            goto Label_018E;
        Label_0073:
            regex = new Regex(@"@\w*");
            matchs = regex.Matches(helper.Sql);
            type2 = this.GetCommandParameterType(command);
            objArray = new object[matchs.Count];
            num = 0;
            enumerator = matchs.GetEnumerator();
        Label_00AD:
            try
            {
                goto Label_0101;
            Label_00AF:
                match = (Match) enumerator.Current;
                str = match.Value;
                objArray1 = new object[] { str, helper.Parameters[num] };
                obj3 = Activator.CreateInstance(type2, objArray1);
                objArray[num] = obj3;
                num += 1;
                Debug.WriteLine(str);
            Label_0101:
                if (enumerator.MoveNext() != null)
                {
                    goto Label_00AF;
                }
                goto Label_0122;
            }
            finally
            {
            Label_010C:
                disposable = enumerator as IDisposable;
                if (disposable == null)
                {
                    goto Label_0121;
                }
                disposable.Dispose();
            Label_0121:;
            }
        Label_0122:
            if ((this.paramterInfo == null) == null)
            {
                goto Label_0165;
            }
            this.paramterInfo = SqlDataBaseService.objectUlits.DynamicMethodUlits.GetPropertyInfo(type, "Parameters");
            if ((this.paramterInfo == null) == null)
            {
                goto Label_0164;
            }
            throw new Exception("获取指定公共成员变量失败");
        Label_0164:;
        Label_0165:
            SqlDataBaseService.objectUlits.DynamicMethodUlits.ExecutMethod(this.paramterInfo.GetValue(command), "AddRange", objArray);
            this.OpenConnect();
            command2 = command;
        Label_018E:
            return command2;
        }

        public int Update(SqlDataBaseService.SQLHelper helper)
        {
            int num;
            num = this.ExecuteNonQuery(helper);
        Label_000B:
            return num;
        }

        public int Update(object obj, string key, object value)
        {
            SqlDataBaseService.SQLHelper helper;
            int num;
            helper = this.ObjectToUpdataSQlHelper(obj, key, value);
            num = this.Update(helper);
        Label_0015:
            return num;
        }
    }
}

