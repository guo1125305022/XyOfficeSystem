namespace SqlDataBaseService.objectUlits
{
    using System;
    using System.Reflection;

    public class DynamicMethodUlits
    {


        public static object ExecutMethod(object obj, string methodName, params object[] methodParams)
        {
            return null;
        }

        /// <summary>
        /// 获取方法信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodName">方法名称</param>
        /// <returns></returns>
        public static MethodInfo GetMethod<T>(string methodName)
        {
            return GetMethod(typeof(T), methodName);
        }

        /// <summary>
        /// 方法信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(object obj, string methodName)
        {
            return GetMethod(obj.GetType(), methodName);
        }


        /// <summary>
        /// 获取方信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static MethodInfo GetMethod(Type type, string methodName)
        {
            MethodInfo[] infoArray = type.GetMethods();
            foreach (MethodInfo info in infoArray) {
                if (info.Name == methodName)
                {
                   return info;
                }
            }
            return null;
        }
        /// <summary>
        /// 获取公共成员信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo<T>(string name)
        {
            return GetPropertyInfo(typeof(T), name);
        }
        /// <summary>
        /// 获取公共成员信息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo(object obj, string name)
        {
            return GetPropertyInfo(obj.GetType(), name);
        }
        /// <summary>
        /// 获取公共成员信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name">成员名称</param>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo(Type type, string name)
        {
            PropertyInfo[] properties=type.GetProperties();
            foreach (PropertyInfo info in properties) {
                if (info.Name == name) {
                    return info;
                }
            }
            return null;
        }
    }
}

