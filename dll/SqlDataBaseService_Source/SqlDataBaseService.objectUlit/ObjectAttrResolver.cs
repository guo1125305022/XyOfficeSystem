namespace SqlDataBaseService.objectUlit
{
    using SqlDataBaseService.objectUlits;
    using SqlDataBaseService.table;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class ObjectAttrResolver
    {
        public const string COLUNM_INFO = "colunm_info";
        public const string DEFAULT_TABLE_NAME = "default_table_name";

        public ObjectAttrResolver()
        {
            base..ctor();
            return;
        }

        public static T GetClassAttribute<T>(Type type) where T: Attribute
        {
            IEnumerable<Attribute> enumerable;
            IEnumerator<Attribute> enumerator;
            Attribute attribute;
            bool flag;
            T local;
            T local2;
            enumerable = type.GetCustomAttributes(typeof(T));
            enumerator = enumerable.GetEnumerator();
        Label_001A:
            try
            {
                goto Label_003D;
            Label_001C:
                attribute = enumerator.Current;
                if (((attribute as T) > null) == null)
                {
                    goto Label_003C;
                }
                local = (T) attribute;
                goto Label_0060;
            Label_003C:;
            Label_003D:
                if (enumerator.MoveNext() != null)
                {
                    goto Label_001C;
                }
                goto Label_0052;
            }
            finally
            {
            Label_0047:
                if (enumerator == null)
                {
                    goto Label_0051;
                }
                enumerator.Dispose();
            Label_0051:;
            }
        Label_0052:
            local = default(T);
        Label_0060:
            return local;
        }

        public static List<SqlDataBaseService.objectUlits.ClassFiledInfo> GetClassFiedlAttributeInfo(Type type)
        {
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            list = GetClassTypeFiedlAttributeInfo(type, null);
        Label_000B:
            return list;
        }

        public static string GetClassTable<T>()
        {
            SqlDataBaseService.table.TargetTbaleAttribute attribute;
            Type type;
            string str;
            bool flag;
            string str2;
            attribute = GetClassTargetTbaleAttribute<T>();
            type = typeof(T);
            str = type.Name;
            if (string.IsNullOrWhiteSpace(attribute.Name) == null)
            {
                goto Label_0031;
            }
            str = attribute.Name;
        Label_0031:
            str2 = str;
        Label_0036:
            return str2;
        }

        public static SqlDataBaseService.table.TargetTbaleAttribute GetClassTargetTbaleAttribute<T>()
        {
            Type type;
            SqlDataBaseService.table.TargetTbaleAttribute attribute;
            type = typeof(T);
            attribute = type.GetCustomAttribute<SqlDataBaseService.table.TargetTbaleAttribute>();
        Label_0015:
            return attribute;
        }

        public static List<SqlDataBaseService.objectUlits.ClassFiledInfo> GetClassTypeFiedlAttributeInfo(Type type, object obj = null)
        {
            PropertyInfo[] infoArray;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            PropertyInfo[] infoArray2;
            int num;
            PropertyInfo info;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list2;
            infoArray = type.GetProperties();
            list = new List<SqlDataBaseService.objectUlits.ClassFiledInfo>();
            infoArray2 = infoArray;
            num = 0;
            goto Label_002A;
        Label_0015:
            info = infoArray2[num];
            SqlDataBaseService.objectUlits.ClassFiledInfo.AddToList(list, info, obj);
            num += 1;
        Label_002A:
            if (num < ((int) infoArray2.Length))
            {
                goto Label_0015;
            }
            list2 = list;
        Label_0035:
            return list2;
        }

        public static Dictionary<string, object> ResolveObj<T>()
        {
            Type type;
            Dictionary<string, object> dictionary;
            type = typeof(T);
            dictionary = ResolveObj(type);
        Label_0015:
            return dictionary;
        }

        public static Dictionary<string, object> ResolveObj(object obj)
        {
            Type type;
            bool flag;
            Dictionary<string, object> dictionary;
            if ((obj == null) == null)
            {
                goto Label_000E;
            }
            dictionary = null;
            goto Label_001E;
        Label_000E:
            dictionary = ResolveObj(obj.GetType());
        Label_001E:
            return dictionary;
        }

        public static Dictionary<string, object> ResolveObj(Type classType)
        {
            Dictionary<string, object> dictionary;
            SqlDataBaseService.table.TargetTbaleAttribute attribute;
            string str;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            bool flag;
            Dictionary<string, object> dictionary2;
            dictionary = new Dictionary<string, object>();
            attribute = GetClassAttribute<SqlDataBaseService.table.TargetTbaleAttribute>(classType);
            str = classType.Name;
            if ((string.IsNullOrWhiteSpace(attribute.Name) == 0) == null)
            {
                goto Label_0032;
            }
            str = attribute.Name;
        Label_0032:
            dictionary.Add("default_table_name", str);
            list = GetClassFiedlAttributeInfo(classType);
            dictionary.Add("colunm_info", list);
            dictionary2 = dictionary;
        Label_0058:
            return dictionary2;
        }
    }
}

