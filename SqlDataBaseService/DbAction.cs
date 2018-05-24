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
        private static Type lockeObject =typeof(DbAction);

        
        private DbAction()
        {
            dictionary = new Dictionary<string,ConnectInfo>();
        }

        private void AddConnectionInfo(ConnectInfo connectInfo)
        {
           
            if (!HasConnect(connectInfo))
            {
                dictionary.Add(connectInfo.ConnectName, connectInfo);
            }
          
        }

        public static  BaseDbActionService CreateNewDbAction(ConnectInfo connectInfo)
        {
           
            if (db == null)
            {
                lock (lockeObject) {
                    if (db== null) {
                        db = new DbAction();
                    }
                }
            }
            BaseDbActionService service = db.GetDbConnection(connectInfo);

            return service;
        }

        /// <summary>
        /// 获取当前数据库连接操作对象
        /// </summary>
        /// <returns></returns>
        public static BaseDbActionService CurrentDB()
        {
            return CreateNewDbAction(DataBaseFactory.Factory(AppConfigManage.CurrentDb()));
        }

        public void Dispose()
        {
            return;
        }

        /// <summary>
        /// 获取当前管理中的数据库连接操作对象
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        private ConnectInfo GetConnectInfo(ConnectInfo connectInfo)
        {
            return dictionary[connectInfo.ConnectName]; 
        }

        /// <summary>
        /// 根据数据库连接信息创建连接操作对象
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static BaseDbActionService GetDBByConnectionStringSettings(ConnectionStringSettings settings)
        {
            return CreateNewDbAction(DataBaseFactory.Factory(settings));
        }

        /// <summary>
        /// 获取数据库操作对象
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        private BaseDbActionService GetDbConnection(ConnectInfo connectInfo)
        {
            if (HasConnect(connectInfo))
            {
                connectInfo = GetConnectInfo(connectInfo);
             return connectInfo.DbService;
            }
            connectInfo.DbService = DataBaseFactory.DbServerFactory(connectInfo);
            AddConnectionInfo(connectInfo);

            return connectInfo.DbService;
        }

        /// <summary>
        /// 判断当前数据库连接管理里是否存在连接
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        private bool HasConnect(ConnectInfo connectInfo)
        {
            return dictionary.ContainsKey(connectInfo.ConnectName);
        }
    }
}

