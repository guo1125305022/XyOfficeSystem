namespace SystemTools.webulits
{
    using System;
    using System.Web;

    public class SessionUlits
    {

        public static object GetData(string flag)
        {
            return HttpContext.Current.Session[flag];
        }

        public static T GetData<T>(string flag)
        {
            object value = GetData(flag);
            if (value == null )
            {
                return default(T);
            }
            return (T)value;
        }

        public static bool Save(string flag, object obj)
        {
            HttpContext.Current.Session[flag] = obj;
            return true;
        }
    }
}

