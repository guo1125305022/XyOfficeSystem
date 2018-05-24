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
        /// <summary>
        /// 数据列信息
        /// </summary>
        public const string COLUNM_INFO = "colunm_info";
        /// <summary>
        /// 数据表名
        /// </summary>
        public const string TABLE_NAME = "default_table_name";


        /// <summary>
        /// 根据实体类型获取自定义注解
        /// </summary>
        /// <typeparam name="T">注解类型</typeparam>
        /// <param name="type">实体类型</param>
        /// <returns></returns>
        public static T GetClassAttribute<T>(Type type) where T : Attribute
        {
            IEnumerable<Attribute> attributes = type.GetCustomAttributes(typeof(T));
            foreach (Attribute attr in attributes) {
                if (attr.GetType() == typeof(T)) {
                    return (T)attr;
                }
            }
            return default(T);
        }


        public static List<ClassFiledInfo> GetClassFiedlAttributeInfo(Type type)
        {
            return GetClassTypeFiedlAttributeInfo(type, null); ;
        }

        /// <summary>
        /// 获取数据表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetClassTable<T>()
        {
            TargetTbaleAttribute attribute = GetClassTargetTbaleAttribute<T>();
            Type type = typeof(T);
            string str = type.Name;
            if (!string.IsNullOrWhiteSpace(attribute.Name))
            {
                str = attribute.Name;

            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static TargetTbaleAttribute GetClassTargetTbaleAttribute<T>()
        {
            Type type = typeof(T);
            return type.GetCustomAttribute<TargetTbaleAttribute>();
        }

        public static List<ClassFiledInfo> GetClassTypeFiedlAttributeInfo(Type type, object obj = null)
        {
            PropertyInfo[] infoArray;
            List<ClassFiledInfo> list;
            PropertyInfo[] infoArray2;
            int num;
            PropertyInfo info;
            List<ClassFiledInfo> list2;
            infoArray = type.GetProperties();
            list = new List<ClassFiledInfo>();
            infoArray2 = infoArray;
            num = 0;
            goto Label_002A;
            Label_0015:
            info = infoArray2[num];
            ClassFiledInfo.AddToList(list, info, obj);
            num += 1;
            Label_002A:
            if (num < ((int)infoArray2.Length))
            {
                goto Label_0015;
            }
            list2 = list;
            Label_0035:
            return list2;
        }

        public static Dictionary<string, object> ResolveObj<T>()
        {
            return ResolveObj(typeof(T)); ;
        }

        public static Dictionary<string, object> ResolveObj(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            return ResolveObj(obj.GetType());
        }

        /// <summary>
        /// 解析实体
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ResolveObj(Type classType)
        {
            Dictionary<string, object> dictionary;
            TargetTbaleAttribute attribute = GetClassAttribute<TargetTbaleAttribute>(classType);
            string tableName;
            List<ClassFiledInfo> list;
            dictionary = new Dictionary<string, object>();
            tableName = classType.Name;
            if (string.IsNullOrWhiteSpace(attribute.Name))
            {
                tableName = attribute.Name;
            }
            dictionary.Add(TABLE_NAME, tableName);
            list = GetClassFiedlAttributeInfo(classType);
            dictionary.Add(COLUNM_INFO, list);
            return dictionary;
        }
    }
}

