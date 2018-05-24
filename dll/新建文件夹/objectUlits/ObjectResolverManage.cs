namespace SqlDataBaseService.objectUlits
{
    using SqlDataBaseService.objectUlit;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    /// <summary>
    /// 实体解析管理器
    /// </summary>
    public class ObjectResolverManage
    {
        private Dictionary<string, Dictionary<string, object>> objectDictionary;
        private static readonly object Locker = new object();
        private static ObjectResolverManage manage;


        private ObjectResolverManage()
        {
            objectDictionary = new Dictionary<string, Dictionary<string, object>>();

        }

        /// <summary>
        /// 创建KEY
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string CreateKey(Type type)
        {
            return type.FullName + "." + type.Name;
        }

        public static T CreateObjectBy<T>()
        {
            Type type;
            type = typeof(T);
            if (type == null)
            {
                throw new ObjectAttrResolverException("动态创建对象失败 因为这个对象类型为空 ");
            }

            return (T)CreateObjectBy(type);
        }
        /// <summary>
        /// 创建实体对象
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object CreateObjectBy(Type type)
        {
            return Activator.CreateInstance(type);
        }

        /// <summary>
        /// 获取对象解析管理器
        /// </summary>
        /// <returns></returns>
        public static ObjectResolverManage GetInstance()
        {
            if (manage == null)
            {
                lock (Locker)
                {
                    if (manage == null)
                    {
                        manage = new ObjectResolverManage();
                    }

                }

            }

            return manage;
        }
        /// <summary>
        /// 解析对象数据列信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<ClassFiledInfo> GetTableColumnsInfo<T>()
        {
            return GetTableColumnsInfo(typeof(T));
        }
        /// <summary>
        /// 解析对象数据列信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<ClassFiledInfo> GetTableColumnsInfo(object obj)
        {
            return GetTableColumnsInfo(obj.GetType());
        }

        public List<ClassFiledInfo> GetTableColumnsInfo(Type type)
        {
            string key;
            Dictionary<string, object> dictionary;
            List<ClassFiledInfo> list;
            key = CreateKey(type);
            if (objectDictionary.ContainsKey(key))
            {
                if (objectDictionary[key] == null)
                {
                    objectDictionary.Remove(key);
                }
            }

            dictionary = ResolverObject(type);
            objectDictionary.Add(key, dictionary);
            list = (List<ClassFiledInfo>)dictionary[ObjectAttrResolver.COLUNM_INFO];
            return list;
        }
        /// <summary>
        /// 解析实体表明
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public string GetTableName<T>()
        {
            return GetTableName(typeof(T));
        }

        public string GetTableName(object obj)
        {
            return GetTableName(obj.GetType());
        }

        /// <summary>
        /// 解析获取表名
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetTableName(Type type)
        {
            string key = CreateKey(type);
            if (objectDictionary.ContainsKey(key))
            {
                if (objectDictionary[key] == null)
                {
                    objectDictionary.Remove(key);
                }
            }
            Dictionary<string, object> dictionary = ResolverObject(type);
            objectDictionary.Add(key, dictionary);
            return (string)dictionary[ObjectAttrResolver.TABLE_NAME];
        }
        /// <summary>
        /// 解析泛型对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Dictionary<string, object> ResolverObject<T>()
        {
            Type type = typeof(T);
            return ResolverObject(type);
        }
        /// <summary>
        /// 解析数据对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dictionary<string, object> ResolverObject(object obj)
        {
            Type type = obj.GetType();
            return ResolverObject(type);
        }

        public Dictionary<string, object> ResolverObject(Type type)
        {
            Dictionary<string, object> dictionary;
            string key = CreateKey(type);
            if (objectDictionary.ContainsKey(key))
            {
                if (objectDictionary[key] == null)
                {
                    objectDictionary.Remove(key);
                }
            }
            dictionary = ObjectAttrResolver.ResolveObj(type);
            if (dictionary != null)
            {
                objectDictionary.Add(key, dictionary);
            }
            else
            {
                throw new Exception("对象解析失败 未找到对应的解析属性");
            }
            return dictionary;
        }
    }
}

