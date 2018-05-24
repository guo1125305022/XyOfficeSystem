namespace SqlDataBaseService.sqlAction.sqlServer
{
    using SqlDataBaseService;
    using SqlDataBaseService.sqlAction;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class ServerDbAction : BaseDbActionService
    {
        public ServerDbAction(ConnectInfo connectInfo):base(connectInfo)
        {
          
        }

        public override DbDataAdapter ExecteAdapter(DbCommand cmd)
        {
            SqlCommand command = (SqlCommand) cmd;
           
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            return adapter;
        }

        public override Page<A> ExectuePage<A>(long startIndex, int pageSize, SQLHelper helper)
        {
            return null;
        }

        public override string getCurrentDataBaseName()
        {
            throw new System.NotImplementedException();
        }

        public override string ShowALLDataBaseSQL()
        {
            throw new System.NotImplementedException();
        }

        public override string ShowAllDataBaseTables(string dataBaseName)
        {
            return "use " + dataBaseName + " go \n select NAME from sys.tables";
        }

        public override string ShowAllDataBaseTables()
        {
            return "SELECT Name FROM Master..SysDatabases ORDER BY Name";
        }
    }
}

