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
        private SqlDataBaseService.colunm.TargetColumnAttribute _customAttribute;
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
            this._isPk = 0;
            this._customAttribute = null;
            this._mpropertyInfo = null;
            this._isFK = 0;
            this._isHasNull = 1;
            this._column_type = "";
            this._dataLength = -1;
            this._default_value = null;
            base..ctor();
            this.MpropertyInfo = info;
            this._colunmValue = _colunmValue;
            this.Init();
            return;
        }

        public static void AddToList(List<SqlDataBaseService.objectUlits.ClassFiledInfo> list, PropertyInfo propertyInfo, object obj = null)
        {
            SqlDataBaseService.colunm.IgnoreColumnAttribute attribute;
            SqlDataBaseService.objectUlits.ClassFiledInfo info;
            bool flag;
            bool flag2;
            bool flag3;
            if (((list == null) ? 1 : (propertyInfo == null)) == null)
            {
                goto Label_0015;
            }
            goto Label_0059;
        Label_0015:
            if ((propertyInfo.GetCustomAttribute<SqlDataBaseService.colunm.IgnoreColumnAttribute>() > null) == null)
            {
                goto Label_0027;
            }
            goto Label_0059;
        Label_0027:
            info = new SqlDataBaseService.objectUlits.ClassFiledInfo(propertyInfo, null);
            info.CustomAttribute = propertyInfo.GetCustomAttribute<SqlDataBaseService.colunm.TargetColumnAttribute>();
            if (list.Contains(info) == null)
            {
                goto Label_004F;
            }
            info = null;
            goto Label_0059;
        Label_004F:
            list.Add(info);
        Label_0059:
            return;
        }

        private void Init()
        {
            SqlDataBaseService.colunm.TargetColumnAttribute attribute;
            bool flag;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            attribute = this.MpropertyInfo.GetCustomAttribute<SqlDataBaseService.colunm.TargetColumnAttribute>();
            if ((attribute == null) == null)
            {
                goto Label_0057;
            }
            this._colunmName = this._mpropertyInfo.Name;
            this._isPk = 0;
            this.IsFK = 0;
            this.IsHasNull = 1;
            this.Column_type = "varchar";
            this.DataLength = -1;
            goto Label_0131;
        Label_0057:
            if (string.IsNullOrWhiteSpace(attribute.Name) == null)
            {
                goto Label_007B;
            }
            this._colunmName = this._mpropertyInfo.Name;
            goto Label_0089;
        Label_007B:
            this._colunmName = attribute.Name;
        Label_0089:
            if (string.IsNullOrWhiteSpace(attribute.ColumnType) == null)
            {
                goto Label_00A8;
            }
            this.Column_type = "varchar";
            goto Label_00B7;
        Label_00A8:
            this.Column_type = attribute.ColumnType;
        Label_00B7:
            if ((attribute.DataLength < 1) == null)
            {
                goto Label_00D2;
            }
            this.DataLength = -1;
            goto Label_00E1;
        Label_00D2:
            this.DataLength = attribute.DataLength;
        Label_00E1:
            if ((attribute.Default_Value == null) == null)
            {
                goto Label_00FC;
            }
            this.Default_value = null;
            goto Label_010B;
        Label_00FC:
            this.Default_value = attribute.Default_Value;
        Label_010B:
            this._isPk = attribute.Is_PK;
            this.IsFK = attribute.IsFK;
            this.IsHasNull = attribute.IsHasNull;
        Label_0131:
            return;
        }

        public string Column_type
        {
            get => 
                this._column_type;
            set
            {
                this._column_type = value;
                return;
            }
        }

        public string ColunmName
        {
            get
            {
                string str;
                str = this._colunmName;
            Label_000A:
                return str;
            }
            set
            {
                this._colunmName = value;
                return;
            }
        }

        public object ColunmValue
        {
            get
            {
                object obj2;
                obj2 = this._colunmValue;
            Label_000A:
                return obj2;
            }
            set
            {
                this._colunmValue = value;
                return;
            }
        }

        public SqlDataBaseService.colunm.TargetColumnAttribute CustomAttribute
        {
            get
            {
                SqlDataBaseService.colunm.TargetColumnAttribute attribute;
                attribute = this._customAttribute;
            Label_000A:
                return attribute;
            }
            set
            {
                this._customAttribute = value;
                return;
            }
        }

        public int DataLength
        {
            get => 
                this._dataLength;
            set
            {
                this._dataLength = value;
                return;
            }
        }

        public object Default_value
        {
            get => 
                this._default_value;
            set
            {
                this._default_value = value;
                return;
            }
        }

        public bool IsFK
        {
            get => 
                this._isFK;
            set
            {
                this._isFK = value;
                return;
            }
        }

        public bool IsHasNull
        {
            get => 
                this._isHasNull;
            set
            {
                this._isHasNull = value;
                return;
            }
        }

        public bool IsPk
        {
            get
            {
                bool flag;
                flag = this._isPk;
            Label_000A:
                return flag;
            }
            set
            {
                this._isPk = value;
                return;
            }
        }

        public PropertyInfo MpropertyInfo
        {
            get
            {
                PropertyInfo info;
                info = this._mpropertyInfo;
            Label_000A:
                return info;
            }
            set
            {
                this._mpropertyInfo = value;
                return;
            }
        }
    }
}

