namespace SqlDataBaseService.objectUlit
{
    using SqlDataBaseService.colunm;
    using SqlDataBaseService.objectUlits;
    using SqlDataBaseService.table;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class ObjectAttrResolver
    {
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        public const string COLUNM_INFO = "colunm_info";
        /// <summary>
        /// ���ݱ���
        /// </summary>
        public const string TABLE_NAME = "default_table_name";


        /// <summary>
        /// ����ʵ�����ͻ�ȡ�Զ���ע��
        /// </summary>
        /// <typeparam name="T">ע������</typeparam>
        /// <param name="type">ʵ������</param>
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
        /// ��ȡ���ݱ���
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
            PropertyInfo[] properties=type.GetProperties();
            List<ClassFiledInfo> list = new List<ClassFiledInfo>();
            foreach (PropertyInfo info in properties) {
                ClassFiledInfo.AddToList(list, info, obj);
            }
            return list;
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
        /// ����ʵ��
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static Dictionary<string, object> ResolveObj(Type classType)
        {
            
            TargetTbaleAttribute attribute = GetClassAttribute<TargetTbaleAttribute>(classType);
            Dictionary<string, object>  dictionary = new Dictionary<string, object>();
            string tableName = classType.Name;
            if (!string.IsNullOrWhiteSpace(attribute.Name))
            {
                tableName = attribute.Name;
            }
            dictionary.Add(TABLE_NAME, tableName);
            List<ClassFiledInfo> list = GetClassFiedlAttributeInfo(classType);
            dictionary.Add(COLUNM_INFO, list);
            return dictionary;
        }
    }
}

