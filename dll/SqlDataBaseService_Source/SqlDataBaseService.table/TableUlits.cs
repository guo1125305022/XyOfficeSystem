namespace SqlDataBaseService.table
{
    using SqlDataBaseService;
    using SqlDataBaseService.objectUlits;
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TableUlits
    {
        public TableUlits()
        {
            base..ctor();
            return;
        }

        public static void CreateTable(Dictionary<string, object> tableInfo)
        {
            string str;
            SqlDataBaseService.sqlAction.BaseDbActionService service;
            bool flag;
            SqlDataBaseService.SQLHelper helper;
            Exception exception;
            str = ResolveCreateTableSql(tableInfo);
            if (string.IsNullOrWhiteSpace(str) == null)
            {
                goto Label_0015;
            }
            goto Label_0055;
        Label_0015:
            service = SqlDataBaseService.DbAction.CurrentDB();
        Label_001B:
            try
            {
                try
                {
                    helper = new SqlDataBaseService.SQLHelper(str, Array.Empty<object>());
                    service.ExecuteNonQuery(helper);
                    goto Label_0049;
                }
                catch (Exception exception1)
                {
                Label_0033:
                    exception = exception1;
                    throw new Exception("数据表创建失败:执行语句\n" + str, exception);
                }
            Label_0049:
                goto Label_0055;
            }
            finally
            {
            Label_004B:
                service.Dispose();
            }
        Label_0055:
            return;
        }

        private static string ResolveClassFiled(SqlDataBaseService.objectUlits.ClassFiledInfo classFiled)
        {
            StringBuilder builder;
            bool flag;
            bool flag2;
            string str;
            bool flag3;
            bool flag4;
            builder = new StringBuilder(classFiled.ColunmName);
            builder.Append(" " + classFiled.Column_type);
            if ((classFiled.DataLength > 0) == null)
            {
                goto Label_0054;
            }
            builder.Append("(" + ((int) classFiled.DataLength) + ")");
        Label_0054:
            if (classFiled.IsPk == null)
            {
                goto Label_0074;
            }
            builder.Append(" PRIMARY KEY");
            str = builder.ToString();
            goto Label_00E4;
        Label_0074:
            if ((classFiled.Default_value > null) == null)
            {
                goto Label_00DB;
            }
            if (((classFiled.Default_value as string) > null) == null)
            {
                goto Label_00B8;
            }
            builder.Append(" default '" + classFiled.Default_value + "'");
            goto Label_00DA;
        Label_00B8:;
        Label_00D3:
            builder.Append((" default " + classFiled.Default_value) ?? "");
        Label_00DA:;
        Label_00DB:
            str = builder.ToString();
        Label_00E4:
            return str;
        }

        public static unsafe string ResolveCreateTableSql(Dictionary<string, object> modelInfo)
        {
            string str;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            StringBuilder builder;
            int num;
            bool flag;
            string str2;
            bool flag2;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo>.Enumerator enumerator;
            SqlDataBaseService.objectUlits.ClassFiledInfo info;
            bool flag3;
            str = modelInfo["default_table_name"].ToString();
            list = (List<SqlDataBaseService.objectUlits.ClassFiledInfo>) modelInfo["colunm_info"];
            if (string.IsNullOrWhiteSpace(str) == null)
            {
                goto Label_0038;
            }
            str2 = null;
            goto Label_00EE;
        Label_0038:
            if (((list == null) ? 1 : (list.Count < 1)) == null)
            {
                goto Label_0056;
            }
            str2 = null;
            goto Label_00EE;
        Label_0056:
            builder = new StringBuilder("create table " + str + " (");
            num = 0;
            enumerator = list.GetEnumerator();
        Label_0077:
            try
            {
                goto Label_00BE;
            Label_0079:
                info = &enumerator.Current;
                if ((num < 1) == null)
                {
                    goto Label_009F;
                }
                builder.Append(ResolveClassFiled(info));
                goto Label_00B9;
            Label_009F:
                builder.Append(",\n" + ResolveClassFiled(info));
            Label_00B9:
                num += 1;
            Label_00BE:
                if (&enumerator.MoveNext() != null)
                {
                    goto Label_0079;
                }
                goto Label_00D8;
            }
            finally
            {
            Label_00C9:
                &enumerator.Dispose();
            }
        Label_00D8:
            builder.Append(")");
            str2 = builder.ToString();
        Label_00EE:
            return str2;
        }
    }
}

