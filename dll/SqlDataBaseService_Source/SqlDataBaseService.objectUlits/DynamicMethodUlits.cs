namespace SqlDataBaseService.objectUlits
{
    using System;
    using System.Reflection;

    public class DynamicMethodUlits
    {
        public DynamicMethodUlits()
        {
            base..ctor();
            return;
        }

        public static object ExecutMethod(object obj, string methodName, params object[] methodParams)
        {
            object[] objArray2;
            object[] objArray1;
            Type type;
            MethodInfo info;
            object obj2;
            ParameterInfo[] infoArray;
            bool flag;
            int num;
            ParameterInfo info2;
            Type type2;
            bool flag2;
            Array array;
            int num2;
            object obj3;
            bool flag3;
            object obj4;
            type = obj.GetType();
            info = GetMethod(obj, methodName);
            if ((info == null) == null)
            {
                goto Label_002F;
            }
            throw new Exception("没有找到该方法" + methodName);
        Label_002F:
            obj2 = null;
            infoArray = info.GetParameters();
            num = (int) infoArray.Length;
            if (num == null)
            {
                goto Label_004D;
            }
        Label_0043:
            if (num == 1)
            {
                goto Label_005B;
            }
            goto Label_00E5;
        Label_004D:
            obj2 = info.Invoke(obj, null);
            goto Label_00F0;
        Label_005B:
            info2 = infoArray[0];
            type2 = info2.ParameterType;
            if (type2.IsArray == null)
            {
                goto Label_00D1;
            }
            array = Array.CreateInstance(type2.GetElementType(), (int) methodParams.Length);
            num2 = 0;
            goto Label_00AB;
        Label_0091:
            obj3 = methodParams[num2];
            array.SetValue(obj3, num2);
            num2 += 1;
        Label_00AB:
            if ((num2 < array.Length) != null)
            {
                goto Label_0091;
            }
            objArray1 = new object[] { array };
            obj2 = info.Invoke(obj, objArray1);
            goto Label_00F0;
        Label_00D1:
            objArray2 = new object[] { methodParams };
            obj2 = info.Invoke(obj, objArray2);
            goto Label_00F0;
        Label_00E5:
            obj2 = info.Invoke(obj, methodParams);
        Label_00F0:
            obj4 = obj2;
        Label_00F5:
            return obj4;
        }

        public static MethodInfo GetMethod<T>(string methodName)
        {
            MethodInfo info;
            info = GetMethod(typeof(T), methodName);
        Label_0014:
            return info;
        }

        public static MethodInfo GetMethod(object obj, string methodName)
        {
            Type type;
            MethodInfo info;
            info = GetMethod(obj.GetType(), methodName);
        Label_0012:
            return info;
        }

        public static MethodInfo GetMethod(Type type, string methodName)
        {
            MethodInfo info;
            MethodInfo[] infoArray;
            MethodInfo[] infoArray2;
            int num;
            MethodInfo info2;
            bool flag;
            MethodInfo info3;
            info = null;
            infoArray = type.GetMethods();
            infoArray2 = infoArray;
            num = 0;
            goto Label_0035;
        Label_0011:
            info2 = infoArray2[num];
            if ((info2.Name == methodName) == null)
            {
                goto Label_0030;
            }
            info = info2;
            goto Label_003B;
        Label_0030:
            num += 1;
        Label_0035:
            if (num < ((int) infoArray2.Length))
            {
                goto Label_0011;
            }
        Label_003B:
            info3 = info;
        Label_0040:
            return info3;
        }

        public static PropertyInfo GetPropertyInfo<T>(string name)
        {
            Type type;
            PropertyInfo info;
            type = typeof(T);
            info = GetPropertyInfo(type, name);
        Label_0016:
            return info;
        }

        public static PropertyInfo GetPropertyInfo(object obj, string name)
        {
            PropertyInfo info;
            info = GetPropertyInfo(obj.GetType(), name);
        Label_0010:
            return info;
        }

        public static PropertyInfo GetPropertyInfo(Type type, string name)
        {
            PropertyInfo info;
            PropertyInfo[] infoArray;
            PropertyInfo[] infoArray2;
            int num;
            PropertyInfo info2;
            bool flag;
            PropertyInfo info3;
            info = null;
            infoArray = type.GetProperties();
            infoArray2 = infoArray;
            num = 0;
            goto Label_0035;
        Label_0011:
            info2 = infoArray2[num];
            if ((info2.Name == name) == null)
            {
                goto Label_0030;
            }
            info = info2;
            goto Label_003B;
        Label_0030:
            num += 1;
        Label_0035:
            if (num < ((int) infoArray2.Length))
            {
                goto Label_0011;
            }
        Label_003B:
            info3 = info;
        Label_0040:
            return info3;
        }
    }
}

