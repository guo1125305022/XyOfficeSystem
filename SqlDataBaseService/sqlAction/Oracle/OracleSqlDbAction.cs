using Oracle.ManagedDataAccess.Client;
using System;
using System.Data.Common;

namespace SqlDataBaseService.sqlAction.Oracle
{
    public class OracleSqlDbAction : BaseDbActionService
    {
        public OracleSqlDbAction(ConnectInfo connectInfo) : base(connectInfo)
        {
        }

        public override DbDataAdapter ExecteAdapter(DbCommand cmd)
        {
            OracleCommand command =(OracleCommand) cmd;
            OracleDataAdapter adapter = new OracleDataAdapter(command);
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
            return "select t.table_name from user_tables t";
        }

        public override string ShowAllDataBaseTables(string dataBaseName)
        {
            return ShowALLDataBaseSQL();
        }

        public override string ShowAllDataBaseTables()
        {
            return null;
        }
    }
}
