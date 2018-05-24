using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModels;

namespace SystemBusiness
{
    public class ServiceManage
    {
        private static Dictionary<string, object> dictionary = new Dictionary<string, object>();
        private readonly static string locked = new ServiceManage().ToString();
        public static T GetService<T>()
        {
            string key = GetKey(typeof(T));
            T obj = default(T);
            if (!HasKey(key)) {
                lock (locked) {
                    if (!HasKey(key)) {
                        obj = (T)CreateObject(typeof(T));
                        dictionary.Add(key, obj);
                    }
                }
              
            }
            return (T)dictionary[key];
        }

        private static string GetKey<T>() {
            Type type = typeof(T);
            return GetKey(type);
           
        }
        private static string GetKey(Type type) {
            string key = type.FullName + type.Name;
            return key;
        }

        private static object CreateObject(Type type) {
            object obj = Activator.CreateInstance(type);
            return obj;
        }
        private static T  CreateObject<T>() {
            return (T)CreateObject(typeof(T));
        }
        private static bool HasKey(string key) {
            return dictionary.ContainsKey(key);
        }

    }
}
