namespace SqlDataBaseService.sqlAction.SQLIter
{
    using SqlDataBaseService;
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Data.Common;
    using System.Data.SQLite;

    public class SQLiterDbAction : BaseDbActionService
    {
        public SQLiterDbAction(ConnectInfo connectInfo):base(connectInfo)
        {
         
        }

        public override DbDataAdapter ExecteAdapter(DbCommand cmd)
        {
            SQLiteCommand command;
            SQLiteDataAdapter adapter;
            command = (SQLiteCommand) cmd;
            adapter = new SQLiteDataAdapter(command);
            return adapter; 
        }

        public override Page<A> ExectuePage<A>(long startIndex, int pageSize, SQLHelper helper)
        {
            throw new NotImplementedException();
        }

        public override string getCurrentDataBaseName()
        {
            throw new NotImplementedException();
        }

        public override string ShowALLDataBaseSQL()
        {
            throw new NotImplementedException();
        }

        public override string ShowAllDataBaseTables(string dataBaseName)
        {
            throw new NotImplementedException();
        }

        public override string ShowAllDataBaseTables()
        {
            throw new NotImplementedException();
        }
    }
}

