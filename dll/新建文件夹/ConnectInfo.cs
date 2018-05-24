namespace SqlDataBaseService
{
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class ConnectInfo
    {
      

        public ConnectInfo()
        {
          
        }

        public SqlDataBaseService.DataBaseType BaseType
        {
            get;set;
        }

        public string ConnectName
        {
            get;set;
        }

        public string ConnectString
        {
            get;set;
        }

        internal SqlDataBaseService.sqlAction.BaseDbActionService DbService
        {
            set;get;
        }
    }
}

