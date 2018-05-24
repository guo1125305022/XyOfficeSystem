namespace SqlDataBaseService.objectUlits
{
    using SqlDataBaseService.objectUlit;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class ObjectResolverManage
    {
        private Dictionary<string, Dictionary<string, object>> dictionary;
        private static readonly object Locker;
        private static SqlDataBaseService.objectUlits.ObjectResolverManage manage;

        static ObjectResolverManage()
        {
            Locker = new object();
            return;
        }

        private ObjectResolverManage()
        {
            base..ctor();
            this.dictionary = new Dictionary<string, Dictionary<string, object>>();
            return;
        }

        private string CreateKey(Type type)
        {
            string str;
            string str2;
            string str3;
            string str4;
            str = type.FullName;
            str2 = type.Name;
            str4 = str + "." + str2;
        Label_0020:
            return str4;
        }

        public static T CreateObjectBy<T>()
        {
            Type type;
            bool flag;
            T local;
            type = typeof(T);
            if ((type == null) == null)
            {
                goto Label_0023;
            }
            throw new SqlDataBaseService.objectUlits.ObjectAttrResolverException("动态创建对象失败 因为这个对象类型为空 ");
        Label_0023:
            local = (T) CreateObjectBy(type);
        Label_0031:
            return local;
        }

        public static object CreateObjectBy(Type type)
        {
            object obj2;
            obj2 = Activator.CreateInstance(type);
        Label_000A:
            return obj2;
        }

        public static unsafe SqlDataBaseService.objectUlits.ObjectResolverManage GetInstance()
        {
            bool flag;
            object obj2;
            bool flag2;
            bool flag3;
            SqlDataBaseService.objectUlits.ObjectResolverManage manage;
            if ((SqlDataBaseService.objectUlits.ObjectResolverManage.manage == null) == null)
            {
                goto Label_0047;
            }
            obj2 = Locker;
            flag2 = 0;
        Label_0016:
            try
            {
                Monitor.Enter(obj2, &flag2);
                if ((SqlDataBaseService.objectUlits.ObjectResolverManage.manage == null) == null)
                {
                    goto Label_0038;
                }
                SqlDataBaseService.objectUlits.ObjectResolverManage.manage = new SqlDataBaseService.objectUlits.ObjectResolverManage();
            Label_0038:
                goto Label_0046;
            }
            finally
            {
            Label_003B:
                if (flag2 == null)
                {
                    goto Label_0045;
                }
                Monitor.Exit(obj2);
            Label_0045:;
            }
        Label_0046:;
        Label_0047:
            manage = SqlDataBaseService.objectUlits.ObjectResolverManage.manage;
        Label_0050:
            return manage;
        }

        public List<SqlDataBaseService.objectUlits.ClassFiledInfo> GetTableColumnsInfo<T>()
        {
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            list = this.GetTableColumnsInfo(typeof(T));
        Label_0014:
            return list;
        }

        public List<SqlDataBaseService.objectUlits.ClassFiledInfo> GetTableColumnsInfo(object obj)
        {
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            list = this.GetTableColumnsInfo(obj.GetType());
        Label_0010:
            return list;
        }

        public List<SqlDataBaseService.objectUlits.ClassFiledInfo> GetTableColumnsInfo(Type type)
        {
            string str;
            object obj2;
            Dictionary<string, object> dictionary;
            bool flag;
            bool flag2;
            List<SqlDataBaseService.objectUlits.ClassFiledInfo> list;
            str = this.CreateKey(type);
            if ((this.dictionary.ContainsKey(str) == 0) == null)
            {
                goto Label_0026;
            }
            this.ResolverObject(type);
        Label_0026:
            obj2 = this.dictionary[str];
            if ((obj2 == null) == null)
            {
                goto Label_0054;
            }
            this.dictionary.Remove(str);
            this.ResolverObject(type);
        Label_0054:
            dictionary = this.dictionary[str];
            list = (List<SqlDataBaseService.objectUlits.ClassFiledInfo>) dictionary["colunm_info"];
        Label_0075:
            return list;
        }

        public string GetTableName<T>()
        {
            Type type;
            string str;
            type = typeof(T);
            str = this.GetTableName(type);
        Label_0016:
            return str;
        }

        public string GetTableName(object obj)
        {
            Type type;
            string str;
            type = obj.GetType();
            str = this.GetTableName(type);
        Label_0012:
            return str;
        }

        public string GetTableName(Type type)
        {
            string str;
            string str2;
            object obj2;
            Dictionary<string, object> dictionary;
            bool flag;
            bool flag2;
            string str3;
            str = this.CreateKey(type);
            str2 = null;
            if ((this.dictionary.ContainsKey(str) == 0) == null)
            {
                goto Label_002A;
            }
            this.ResolverObject(type);
        Label_002A:
            obj2 = this.dictionary[str];
            if ((obj2 == null) == null)
            {
                goto Label_0058;
            }
            this.dictionary.Remove(str);
            this.ResolverObject(type);
        Label_0058:
            dictionary = this.dictionary[str];
            str3 = Convert.ToString(dictionary["default_table_name"]);
        Label_007B:
            return str3;
        }

        public Dictionary<string, object> ResolverObject<T>()
        {
            Type type;
            Dictionary<string, object> dictionary;
            type = typeof(T);
            dictionary = this.ResolverObject(type);
        Label_0016:
            return dictionary;
        }

        public Dictionary<string, object> ResolverObject(object obj)
        {
            Type type;
            Dictionary<string, object> dictionary;
            type = obj.GetType();
            dictionary = this.ResolverObject(type);
        Label_0012:
            return dictionary;
        }

        public unsafe Dictionary<string, object> ResolverObject(Type type)
        {
            string str;
            bool flag;
            Dictionary<string, object> dictionary;
            bool flag2;
            Dictionary<string, object> dictionary2;
            object obj2;
            bool flag3;
            Dictionary<string, object> dictionary3;
            bool flag4;
            str = this.CreateKey(type);
            if (this.dictionary.ContainsKey(str) == null)
            {
                goto Label_004E;
            }
            dictionary = this.dictionary[str];
            if ((dictionary > null) == null)
            {
                goto Label_0040;
            }
            dictionary2 = this.dictionary[str];
            goto Label_00B1;
        Label_0040:
            this.dictionary.Remove(str);
        Label_004E:
            obj2 = Locker;
            flag3 = 0;
        Label_0058:
            try
            {
                Monitor.Enter(obj2, &flag3);
                dictionary3 = SqlDataBaseService.objectUlit.ObjectAttrResolver.ResolveObj(type);
                if ((dictionary3 == null) == null)
                {
                    goto Label_0082;
                }
                throw new Exception("对象解析失败 未找到对应的解析属性");
            Label_0082:
                this.dictionary.Add(str, dictionary3);
                goto Label_00A1;
            }
            finally
            {
            Label_0094:
                if (flag3 == null)
                {
                    goto Label_00A0;
                }
                Monitor.Exit(obj2);
            Label_00A0:;
            }
        Label_00A1:
            dictionary2 = this.dictionary[str];
        Label_00B1:
            return dictionary2;
        }
    }
}

