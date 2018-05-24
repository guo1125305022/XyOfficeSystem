namespace SystemTools.webulits
{
    using System;
    using System.Web;

    public class SessionUlits
    {
        public SessionUlits()
        {
            base..ctor();
            return;
        }

        public static object GetData(string flag)
        {
            object obj2;
            obj2 = HttpContext.Current.Session[flag];
        Label_0014:
            return obj2;
        }

        public static T GetData<T>(string flag)
        {
            object obj2;
            bool flag2;
            T local;
            T local2;
            obj2 = GetData(flag);
            if ((obj2 == null) == null)
            {
                goto Label_001D;
            }
            local2 = default(T);
            goto Label_0026;
        Label_001D:
            local2 = (T) obj2;
        Label_0026:
            return local2;
        }

        public static bool Save(string flag, object obj)
        {
            object obj2;
            bool flag2;
            bool flag3;
            obj2 = HttpContext.Current.Session[flag];
            if (((obj2 == null) ? 1 : (obj.GetType() == obj2.GetType())) == null)
            {
                goto Label_0044;
            }
            HttpContext.Current.Session[flag] = obj;
            flag3 = 1;
            goto Label_0048;
        Label_0044:
            flag3 = 0;
        Label_0048:
            return flag3;
        }
    }
}

