namespace SqlDataBaseService.objectUlits
{
    using SqlDataBaseService.colunm;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class ClassFiledInfo
    {
      
        private string _colunmName;
      
  
   
        private PropertyInfo _mpropertyInfo;

        private ClassFiledInfo(PropertyInfo info, object _colunmValue = null)
        {
            this.MpropertyInfo = info;
            this.ColunmValue = _colunmValue;
            this.Init();
           
        }

    

        private void Init()
        {


            TargetColumnAttribute attribute = this.MpropertyInfo.GetCustomAttribute<TargetColumnAttribute>();
            if (attribute == null)
            {
                this._colunmName = this._mpropertyInfo.Name;
                this.IsPk = false;
                this.IsFK = false;
                this.IsHasNull = true;
                this.Column_type = "varchar";
                this.DataLength = -1;
                return;
            }

            ColunmName = this.MpropertyInfo.Name;
            if (!string.IsNullOrWhiteSpace(attribute.Name))
            {
                ColunmName = attribute.Name;
            }
            Column_type = ColumnConfigCantas.DEFAULT_COLUMN_TYPE;
            if (!string.IsNullOrWhiteSpace(attribute.ColumnType))
            {
                Column_type = attribute.ColumnType;
            }

            DataLength = -1;
            if (attribute.DataLength > 0)
            {
                DataLength = attribute.DataLength;
            }
            Default_value = null;
            if (attribute.Default_Value != null)
            {
                this.Default_value = attribute.Default_Value;
            }
            this.IsPk = attribute.Is_PK;
            this.IsFK = attribute.IsFK;
            this.IsHasNull = attribute.IsHasNull;

        }

        public string Column_type
        {
            get; set;
        }

        public string ColunmName
        {
            get;set;
        }

        public object ColunmValue
        {
            get; set;
        }

        public TargetColumnAttribute CustomAttribute
        {
            get; set;
        }

        public int DataLength
        {
            get; set;
        }

        public object Default_value
        {
            get; set;
        }

        public bool IsFK
        {
            get; set;
        }

        public bool IsHasNull
        {
            get; set;
        }

        public bool IsPk
        {
            get; set;
        }

        public PropertyInfo MpropertyInfo
        {
            get; set;
        }

        /// <summary>
        /// 添加到集合中
        /// </summary>
        /// <param name="list"></param>
        /// <param name="propertyInfo"></param>
        /// <param name="obj"></param>
        public static void AddToList(List<ClassFiledInfo> list, PropertyInfo propertyInfo, object obj = null)
        {

            ClassFiledInfo info;

            if (list == null)
            {
                list = new List<ClassFiledInfo>();
            }

            if ((propertyInfo.GetCustomAttribute<IgnoreColumnAttribute>() == null))
            {
                info = new ClassFiledInfo(propertyInfo, null)
                {
                    CustomAttribute = propertyInfo.GetCustomAttribute<TargetColumnAttribute>()
                };
                if (!list.Contains(info))
                {
                    list.Add(info);
                }
            }
        }
    }
}

