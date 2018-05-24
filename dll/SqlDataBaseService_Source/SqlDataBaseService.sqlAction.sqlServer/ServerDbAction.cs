namespace SqlDataBaseService.sqlAction.sqlServer
{
    using SqlDataBaseService;
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class ServerDbAction : SqlDataBaseService.sqlAction.BaseDbActionService
    {
        public ServerDbAction(SqlDataBaseService.ConnectInfo connectInfo)
        {
            base..ctor(connectInfo);
            return;
        }

        public override DbDataAdapter ExecteAdapter(DbCommand cmd)
        {
            SqlCommand command;
            SqlDataAdapter adapter;
            DbDataAdapter adapter2;
            command = (SqlCommand) cmd;
            adapter = new SqlDataAdapter(command);
            adapter2 = adapter;
        Label_0013:
            return adapter2;
        }

        public override SqlDataBaseService.Page<A> ExectuePage<A>(long startIndex, int pageSize, SqlDataBaseService.SQLHelper helper)
        {
            object[] objArray1;
            string str;
            int num;
            string str2;
            SqlDataBaseService.SQLHelper helper2;
            List<A> list;
            SqlDataBaseService.Page<A> page;
            bool flag;
            SqlDataBaseService.Page<A> page2;
            str = "";
            num = helper.Sql.ToLower().LastIndexOf("order by");
            if ((num < -1) == null)
            {
                goto Label_0031;
            }
            str = " ID ";
            goto Label_004B;
        Label_0031:
            str = helper.Sql.Substring(num, helper.Sql.Length);
        Label_004B:
            objArray1 = new object[] { helper.Parameters };
            helper2 = new SqlDataBaseService.SQLHelper($"select *,ROW_NUMBER() over({str})  from ({helper.Sql}) as temp ", objArray1);
            list = base.Select<A>(helper2);
            page = new SqlDataBaseService.Page<A>();
            page2 = null;
        Label_0088:
            return page2;
        }
    }
}

