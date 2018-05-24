namespace SqlDataBaseService.objectUlits
{
    using SqlDataBaseService.colunm;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class ClassFiledInfo
    {
        private string _column_type;
        private string _colunmName;
        private object _colunmValue;
        private TargetColumnAttribute _customAttribute;
        private int _dataLength;
        private object _default_value;
        private bool _isFK;
        private bool _isHasNull;
        private bool _isPk;
        private PropertyInfo _mpropertyInfo;

        private ClassFiledInfo(PropertyInfo info, object _colunmValue = null)
        {
            this._colunmName = null;
            this._colunmValue = null;
            this._isPk = false;
            this._customAttribute = null;
            this._mpropertyInfo = null;
            this._isFK = false;
            this._isHasNull = true;
            this._column_type = "";
            this._dataLength = -1;
            this._default_value = null;
           
            this.MpropertyInfo = info;
            this._colunmValue = _colunmValue;
            this.Init();
           
        }

        public static void AddToList(List<ClassFiledInfo> list, PropertyInfo propertyInfo, object obj = null)
        {
            IgnoreColumnAttribute attribute;
            ClassFiledInfo info;

            if (((list == null) ? 1 : (propertyInfo == null)) == null)
            {

            }

            if ((propertyInfo.GetCustomAttribute<IgnoreColumnAttribute>() == null))
            {
                info = new ClassFiledInfo(propertyInfo, null);
                info.CustomAttribute = propertyInfo.GetCustomAttribute<TargetColumnAttribute>();
                if (!list.Contains(info))
                {
                    list.Add(info);
                }
            }

            info = null;


            return;
        }

        private void Init()
        {


            TargetColumnAttribute attribute = this.MpropertyInfo.GetCustomAttribute<SqlDataBaseService.colunm.TargetColumnAttribute>();
            if (attribute == null)
            {
                this._colunmName = this._mpropertyInfo.Name;
                this._isPk = false;
                this.IsFK = false;
                this.IsHasNull = true;
                this.Column_type = "varchar";
                this.DataLength = -1;
            }


            if (string.IsNullOrWhiteSpace(attribute.Name))
            {
                this._colunmName = this._mpropertyInfo.Name;
            }
            else
            {
                this._colunmName = attribute.Name;
            }
            if (string.IsNullOrWhiteSpace(attribute.ColumnType))
            {
                this.Column_type = attribute.ColumnType;
            }
            this.Column_type = "varchar";

            if (attribute.DataLength < 1)
            {
                this.DataLength = attribute.DataLength;
            }
            else
            {
                this.DataLength = -1;
            }

            if (attribute.Default_Value == null)
            {
                this.Default_value = attribute.Default_Value;
            }
            this.Default_value = null;
            this._isPk = attribute.Is_PK;
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
    }
}

