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

        public BaseDbActionService(ConnectInfo connectInfo)
        {
            this.paramterInfo = null;
            this.disposedValue = false;
           
            this.connectInfo = connectInfo;
            this.InitConnection();
      
        }

        public DbTransaction BeginTransaction()
        {
            OpenConnect();
            DbTransaction transaction = connection.BeginTransaction(); 
            return transaction;
        }

        protected A CreateParameter<A>(string key, object value)
        {
            object[] objArray1;
            Type type;
            bool flag;
            A local;
            A local2;
            if (string.IsNullOrWhiteSpace(key) )
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

        public int Delete(SQLHelper helper)
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
            str = ObjectResolverManage.GetInstance().GetTableName(obj);
            objArray1 = new object[] { value };
            helper = new SQLHelper($"delete {str} where {key}=@0", objArray1);
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
            connection.Close();
        }

        public DbDataAdapter ExecteAdapter(SQLHelper helper)
        {
            DbCommand command = SQlHelperToCommand(helper);
            DbDataAdapter adapter = this.ExecteAdapter(command);
            return adapter;
        }

        public abstract DbDataAdapter ExecteAdapter(DbCommand cmd);
        public abstract SqlDataBaseService.Page<A> ExectuePage<A>(long startIndex, int pageSize, SqlDataBaseService.SQLHelper helper);
        public int ExecuteNonQuery(SQLHelper helper)
        {
            DbCommand command;
            int num;
            command = this.SQlHelperToCommand(helper);
            this.OpenConnect();
            num = command.ExecuteNonQuery();
            return num;
        }

        public DbDataReader ExecuteReader(SQLHelper helper)
        {
        
            DbDataReader reader=SQlHelperToCommand(helper).ExecuteReader(); ;
         
         
            return reader;
        }

        public object ExecuteScalar(SQLHelper helper)
        {
            DbCommand command;
            object obj2;
            obj2 = this.SQlHelperToCommand(helper).ExecuteScalar();
        Label_0012:
            return obj2;
        }

        public DataTable ExecuteToDataTable(SQLHelper helper)
        {
            DbCommand command;
            DbDataAdapter adapter;
            DataTable table;
            command = SQlHelperToCommand(helper);
            adapter = ExecteAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            adapter.Dispose();
           
  
            return table;
        }

        public List<Dictionary<string, object>> ExecuteToList(SQLHelper helper)
        {
            List<Dictionary<string, object>> list;
            DbDataReader reader;
            int num;
            Dictionary<string, object> dictionary;
            int num2;
            string str;
            object obj2;
      
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
            command = DataBaseFactory.DbCommandFactory(this.connectInfo);
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
            SQLHelper helper;
            int num;
            helper = this.ObjectToInsertSQlHelper(obj);
            num = this.Insert(helper);
     
            return num;
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

        protected unsafe SQLHelper ObjectToInsertSQlHelper(object obj)
        {
            ObjectResolverManage manage = ObjectResolverManage.GetInstance();
            List<ClassFiledInfo> list = manage.GetTableColumnsInfo(obj);
            string tableName = manage.GetTableName(obj);
            SQLHelper helper = new SQLHelper("insert into " + tableName+"(");
            int index = 0;
            foreach (ClassFiledInfo info in list) {
                if (index < 1)
                {
                    helper.Append(info.ColunmName,info.ColunmValue);
                }
                else {
                    helper.Append(","+info.ColunmName, info.ColunmValue);
                }
            }
            helper.Append(")values(");
            helper.Append(")");
            return helper;
        }

        protected SQLHelper ObjectToUpdataSQlHelper(object obj, string key, object whereValue)
        {
            ObjectResolverManage manage;
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

        public long SelectCount(SQLHelper helper)
        {
            object[] objArray1;
            string str;
            SqlDataBaseService.SQLHelper helper2;
            DbDataReader reader;
            long num;
            objArray1 = new object[] { helper.Parameters };
            helper2 = new SQLHelper(@"select Count(*) as CountNumber from ({helper.Sql}) as temp ", objArray1);
            reader = this.ExecuteReader(helper2);
            num = -1L;
        Label_0035:
            return num;
        }

        public unsafe T SelectFirstOrDefault<T>(SQLHelper helper)
        {
            DbCommand command;
            DbDataReader reader;
            object obj2;
            List<ClassFiledInfo> list;
            List<ClassFiledInfo>.Enumerator enumerator;
            ClassFiledInfo info;
            T local;
            bool flag;
            bool flag2;
            T local2;
            command = SQlHelperToCommand(helper);
            reader = this.ExecuteReader(helper);
            goto Label_00A0;
        Label_0016:
            obj2 = ObjectResolverManage.CreateObjectBy(typeof(T));
            list = ObjectResolverManage.GetInstance().GetTableColumnsInfo(typeof(T));
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

        protected DbCommand SQlHelperToCommand(SQLHelper helper)
        {
            object[] objArray1;
            Type type;
            Regex regex;
            MatchCollection matchs;
            Type type2;
            object[] objArray;
            int num;
            DbCommand command2;
            IEnumerator enumerator;
            Match match;
            string str;
            object obj3;
            IDisposable disposable;
            bool flag3;
            bool flag4;
            DbCommand command = this.GetDbCommand();
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
            type2 = GetCommandParameterType(command);
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
            if ((paramterInfo == null) == null)
            {
                goto Label_0165;
            }
            paramterInfo = DynamicMethodUlits.GetPropertyInfo(type, "Parameters");
            if ((paramterInfo == null) == null)
            {
                goto Label_0164;
            }
            throw new Exception("获取指定公共成员变量失败");
        Label_0164:;
        Label_0165:
            DynamicMethodUlits.ExecutMethod(paramterInfo.GetValue(command), "AddRange", objArray);
            this.OpenConnect();
            command2 = command;
        Label_018E:
            return command2;
        }

        public int Update(SQLHelper helper)
        {
     
            return ExecuteNonQuery(helper);
        }

        public int Update(object obj, string key, object value)
        {
            SQLHelper helper = ObjectToUpdataSQlHelper(obj, key, value);
            return Update(helper);
        }
    }
}

