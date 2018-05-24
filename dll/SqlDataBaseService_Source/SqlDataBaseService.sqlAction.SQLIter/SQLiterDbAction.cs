namespace SqlDataBaseService.sqlAction.SQLIter
{
    using SqlDataBaseService;
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Data.Common;
    using System.Data.SQLite;

    public class SQLiterDbAction : SqlDataBaseService.sqlAction.BaseDbActionService
    {
        public SQLiterDbAction(SqlDataBaseService.ConnectInfo connectInfo)
        {
            base..ctor(connectInfo);
            return;
        }

        public override DbDataAdapter ExecteAdapter(DbCommand cmd)
        {
            SQLiteCommand command;
            SQLiteDataAdapter adapter;
            DbDataAdapter adapter2;
            command = (SQLiteCommand) cmd;
            adapter = new SQLiteDataAdapter(command);
            adapter2 = adapter;
        Label_0013:
            return adapter2;
        }

        public override SqlDataBaseService.Page<A> ExectuePage<A>(long startIndex, int pageSize, SqlDataBaseService.SQLHelper helper)
        {
            throw new NotImplementedException();
        }
    }
}

