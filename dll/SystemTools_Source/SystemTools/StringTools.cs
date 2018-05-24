namespace SystemTools
{
    using Newtonsoft.Json;
    using System;
    using System.Text.RegularExpressions;

    public class StringTools
    {
        public StringTools()
        {
            base..ctor();
            return;
        }

        private static object ConverBaseType(string typeString, string value)
        {
            object obj2;
            string str;
            object obj3;
            obj2 = null;
            str = typeString;
            if ((str == "System.Int16") != null)
            {
                goto Label_0048;
            }
            if ((str == "System.Int32") != null)
            {
                goto Label_0048;
            }
            if ((str == "System.Int64") != null)
            {
                goto Label_0056;
            }
            if ((str == "System.Float") != null)
            {
                goto Label_0064;
            }
            if ((str == "System.Double") != null)
            {
                goto Label_0072;
            }
            goto Label_0080;
        Label_0048:
            obj2 = (int) Convert.ToInt32(value);
            goto Label_0080;
        Label_0056:
            obj2 = (long) Convert.ToInt64(value);
            goto Label_0080;
        Label_0064:
            obj2 = (float) float.Parse(value);
            goto Label_0080;
        Label_0072:
            obj2 = (double) double.Parse(value);
        Label_0080:
            obj3 = value;
        Label_0084:
            return obj3;
        }

        public static T DeserializeObject<T>(string jsonString)
        {
            T local;
            local = JsonConvert.DeserializeObject<T>(jsonString);
        Label_000A:
            return local;
        }

        public static bool IsEmail(string email)
        {
            Regex regex;
            bool flag;
            bool flag2;
            if (string.IsNullOrWhiteSpace(email) == null)
            {
                goto Label_0010;
            }
            flag2 = 0;
            goto Label_0025;
        Label_0010:
            regex = new Regex(@"^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$ ");
            flag2 = regex.IsMatch(email);
        Label_0025:
            return flag2;
        }

        public static bool IsMobileNumber(string number)
        {
            Regex regex;
            bool flag;
            bool flag2;
            if (string.IsNullOrWhiteSpace(number) == null)
            {
                goto Label_0010;
            }
            flag2 = 0;
            goto Label_0025;
        Label_0010:
            regex = new Regex(@"134[0-8]\d{7}$|^13[^4]\d{8}$|^14[5-9]\d{8}$|^15[^4]\d{8}$|^16[6]\d{8}$|^17[0-8]\d{8}$|^18[\d]{9}$|^19[8,9]\d{8}$");
            flag2 = regex.IsMatch(number);
        Label_0025:
            return flag2;
        }

        public static string SerializeObject(object obj)
        {
            string str;
            str = JsonConvert.SerializeObject(obj);
        Label_000A:
            return str;
        }

        public static T StringToType<T>(string str)
        {
            string str2;
            Type type;
            object obj2;
            bool flag;
            T local;
            T local2;
            bool flag2;
            str2 = str;
            if (string.IsNullOrWhiteSpace(str2) == null)
            {
                goto Label_001C;
            }
            local2 = default(T);
            goto Label_0053;
        Label_001C:
            type = typeof(T);
            obj2 = ConverBaseType(type.FullName, str2);
            if ((obj2 > null) == null)
            {
                goto Label_0049;
            }
            local2 = (T) obj2;
            goto Label_0053;
        Label_0049:
            local2 = DeserializeObject<T>(str2);
        Label_0053:
            return local2;
        }
    }
}

