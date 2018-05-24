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
        /// ��ȡ��ǰ���ݿ����Ӳ�������
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
        /// ��ȡ��ǰ�����е����ݿ����Ӳ�������
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        private ConnectInfo GetConnectInfo(ConnectInfo connectInfo)
        {
            return dictionary[connectInfo.ConnectName]; 
        }

        /// <summary>
        /// �������ݿ�������Ϣ�������Ӳ�������
        /// </summary>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static BaseDbActionService GetDBByConnectionStringSettings(ConnectionStringSettings settings)
        {
            return CreateNewDbAction(DataBaseFactory.Factory(settings));
        }

        /// <summary>
        /// ��ȡ���ݿ��������
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
        /// �жϵ�ǰ���ݿ����ӹ������Ƿ��������
        /// </summary>
        /// <param name="connectInfo"></param>
        /// <returns></returns>
        private bool HasConnect(ConnectInfo connectInfo)
        {
            return dictionary.ContainsKey(connectInfo.ConnectName);
        }
    }
}

