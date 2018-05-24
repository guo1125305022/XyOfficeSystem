namespace SqlDataBaseService.colunm
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [AttributeUsage(0x80)]
    public class TargetColumnAttribute : Attribute
    {
        [CompilerGenerated, DebuggerBrowsable(0)]
        private string <ColumnType>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private int <DataLength>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private object <Default_Value>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private bool <Is_PK>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private bool <IsFK>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private bool <IsHasNull>k__BackingField;
        [CompilerGenerated, DebuggerBrowsable(0)]
        private string <Name>k__BackingField;

        public TargetColumnAttribute(string name = null, string columnType = "varchar", int dataLength = -1, bool is_pk = false, bool is_fk = false, bool isHasNull = true, object default_value = null)
        {
            base..ctor();
            this.Name = name;
            this.ColumnType = columnType;
            this.DataLength = dataLength;
            this.Is_PK = is_pk;
            this.IsFK = is_fk;
            this.Default_Value = default_value;
            this.IsHasNull = isHasNull;
            return;
        }

        public string ColumnType
        {
            [CompilerGenerated]
            get => 
                this.<ColumnType>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<ColumnType>k__BackingField = value;
                return;
            }
        }

        public int DataLength
        {
            [CompilerGenerated]
            get => 
                this.<DataLength>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<DataLength>k__BackingField = value;
                return;
            }
        }

        public object Default_Value
        {
            [CompilerGenerated]
            get => 
                this.<Default_Value>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<Default_Value>k__BackingField = value;
                return;
            }
        }

        public bool Is_PK
        {
            [CompilerGenerated]
            get => 
                this.<Is_PK>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<Is_PK>k__BackingField = value;
                return;
            }
        }

        public bool IsFK
        {
            [CompilerGenerated]
            get => 
                this.<IsFK>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<IsFK>k__BackingField = value;
                return;
            }
        }

        public bool IsHasNull
        {
            [CompilerGenerated]
            get => 
                this.<IsHasNull>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<IsHasNull>k__BackingField = value;
                return;
            }
        }

        public string Name
        {
            [CompilerGenerated]
            get => 
                this.<Name>k__BackingField;
            [CompilerGenerated]
            set
            {
                this.<Name>k__BackingField = value;
                return;
            }
        }
    }
}

