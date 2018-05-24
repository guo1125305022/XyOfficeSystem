namespace SqlDataBaseService
{
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Threading;
    using SystemTools;

    public class DbAction : IDisposable
    {
        private static DbAction db;
        private Dictionary<string, ConnectInfo> dictionary;
        private static DbAction lockeObject = new DbAction();

        
        private DbAction()
        {

            dictionary = new Dictionary<string,ConnectInfo>();
           
        }

        private void AddConnectionInfo(SqlDataBaseService.ConnectInfo connectInfo)
        {
            bool flag;
            if (this.HasConnect(connectInfo) == null)
            {
                goto Label_000F;
            }
            goto Label_0022;
        Label_000F:
            this.dictionary.Add(connectInfo.ConnectName, connectInfo);
        Label_0022:
            return;
        }

        public static unsafe SqlDataBaseService.sqlAction.BaseDbActionService CreateNewDbAction(SqlDataBaseService.ConnectInfo connectInfo)
        {
            bool flag;
            SqlDataBaseService.DbAction action;
            bool flag2;
            bool flag3;
            SqlDataBaseService.sqlAction.BaseDbActionService service;
            if ((db == null) == null)
            {
                goto Label_0047;
            }
            action = lockeObject;
            flag2 = 0;
        Label_0016:
            try
            {
                Monitor.Enter(action, &flag2);
                if ((db == null) == null)
                {
                    goto Label_0038;
                }
                db = new SqlDataBaseService.DbAction();
            Label_0038:
                goto Label_0046;
            }
            finally
            {
            Label_003B:
                if (flag2 == null)
                {
                    goto Label_0045;
                }
                Monitor.Exit(action);
            Label_0045:;
            }
        Label_0046:;
        Label_0047:
            service = db.GetDbConnection(connectInfo);
        Label_0056:
            return service;
        }

        public static SqlDataBaseService.sqlAction.BaseDbActionService CurrentDB()
        {
            SqlDataBaseService.ConnectInfo info;
            SqlDataBaseService.sqlAction.BaseDbActionService service;
            service = CreateNewDbAction(SqlDataBaseService.DataBaseFactory.Factory(AppConfigManage.CurrentDb()));
        Label_0015:
            return service;
        }

        public void Dispose()
        {
            return;
        }

        private SqlDataBaseService.ConnectInfo GetConnectInfo(SqlDataBaseService.ConnectInfo connectInfo)
        {
            SqlDataBaseService.ConnectInfo info;
            info = this.dictionary[connectInfo.ConnectName];
        Label_0015:
            return info;
        }

        public static SqlDataBaseService.sqlAction.BaseDbActionService GetDBByConnectionStringSettings(ConnectionStringSettings settings)
        {
            SqlDataBaseService.ConnectInfo info;
            SqlDataBaseService.sqlAction.BaseDbActionService service;
            service = CreateNewDbAction(SqlDataBaseService.DataBaseFactory.Factory(settings));
        Label_0011:
            return service;
        }

        private SqlDataBaseService.sqlAction.BaseDbActionService GetDbConnection(SqlDataBaseService.ConnectInfo connectInfo)
        {
            bool flag;
            SqlDataBaseService.sqlAction.BaseDbActionService service;
            if ((this.HasConnect(connectInfo) == 0) == null)
            {
                goto Label_0026;
            }
            connectInfo.DbService = DataBaseFactory.DbServerFactory(connectInfo);
            this.AddConnectionInfo(connectInfo);
        Label_0026:
            connectInfo = this.GetConnectInfo(connectInfo);
            service = connectInfo.DbService;
        Label_0038:
            return service;
        }

        private bool HasConnect(SqlDataBaseService.ConnectInfo connectInfo)
        {
            return dictionary.ContainsKey(connectInfo.ConnectName);
        }
    }
}

