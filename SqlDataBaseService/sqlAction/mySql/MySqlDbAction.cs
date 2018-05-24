using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace SqlDataBaseService.sqlAction.mySql
{
    public class MySqlDbAction : BaseDbActionService
    {
        public MySqlDbAction(ConnectInfo connectInfo) : base(connectInfo)
        {
        }

        public override DbDataAdapter ExecteAdapter(DbCommand cmd)
        {
            MySqlCommand command = (MySqlCommand)cmd;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            return adapter;
        }

        public override Page<A> ExectuePage<A>(long startIndex, int pageSize, SQLHelper helper)
        {
            long startRow = (startIndex < 1L ? 0L : startIndex - 1L)*pageSize;
            helper.Append(" limit " + startRow + "," + pageSize);
            List<A> list = Select<A>(helper);
            return null;
        }

        public override string getCurrentDataBaseName()
        {
            throw new NotImplementedException();
        }

        public override string ShowALLDataBaseSQL()
        {
            
            return "select database() as dataBaseName;";
        }

        public override string ShowAllDataBaseTables(string dataBaseName)
        {
           
            return "select TABLE_NAME from information_schema.tables where table_schema = '" + dataBaseName+"'";
        }

        public override string ShowAllDataBaseTables()
        {
           
            return "show tables";
        }
    }
}
