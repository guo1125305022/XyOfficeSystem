namespace SqlDataBaseService.colunm
{
    using System;

    public class TargetColumnAttribute : Attribute
    {
      
        public TargetColumnAttribute(string name = null, string columnType = "varchar", int dataLength = -1, bool is_pk = false, bool is_fk = false, bool isHasNull = true, object default_value = null)
        {
            
            this.Name = name;
            this.ColumnType = columnType;
            this.DataLength = dataLength;
            this.Is_PK = is_pk;
            this.IsFK = is_fk;
            this.Default_Value = default_value;
            this.IsHasNull = isHasNull;
            
        }

        public string ColumnType
        {
            get;set;
        }

        public int DataLength
        {
            get;set;
        }

        public object Default_Value
        {
            get;set;
        }

        public bool Is_PK
        {
            get;set;
        }

        public bool IsFK
        {
            get;set;
        }

        public bool IsHasNull
        {
            get;set;
        }

        public string Name
        {
            get;set;
        }
    }
}

