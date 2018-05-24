namespace SqlDataBaseService
{
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    public class ConnectInfo
    {
        [CompilerGenerated, DebuggerBrowsable(0)]
        private SqlDataBaseService.DataBaseType <BaseType>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private string <ConnectName>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private string <ConnectString>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private SqlDataBaseService.sqlAction.BaseDbActionService <DbService>k__BackingField;

        public ConnectInfo()
        {
            base..ctor();
            return;
        }

        public SqlDataBaseService.DataBaseType BaseType
        {
            [CompilerGenerated]
            get => 
                this.<BaseType>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<BaseType>k__BackingField = value;
                return;
            }
        }

        public string ConnectName
        {
            [CompilerGenerated]
            get => 
                this.<ConnectName>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<ConnectName>k__BackingField = value;
                return;
            }
        }

        public string ConnectString
        {
            [CompilerGenerated]
            get => 
                this.<ConnectString>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<ConnectString>k__BackingField = value;
                return;
            }
        }

        internal SqlDataBaseService.sqlAction.BaseDbActionService DbService
        {
            [CompilerGenerated]
            get => 
                this.<DbService>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<DbService>k__BackingField = value;
                return;
            }
        }
    }
}

