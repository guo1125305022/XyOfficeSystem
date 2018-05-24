namespace SystemTools
{
    using Newtonsoft.Json;
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 字符串数据工具类
    /// </summary>
    public class StringTools
    {
        #region 基本数据类型转换
        /// <summary>
        /// 基本数据类型转换
        /// </summary>
        /// <param name="typeStr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object ConverBaseType(string typeStr, string value)
        {
            object objValue = null;
            switch (typeStr) {
                case "System.Int16":
                    objValue = Convert.ToInt16(value);
                    break;
                case "System.Int32":
                    objValue = Convert.ToInt32(value);
                    break;
                case "System.Int64":
                    objValue = Convert.ToInt64(value);
                    break;
                case "System.Float":
                    objValue = float.Parse(value.ToString());
                    break;
                case "System.Double":
                    objValue = Convert.ToDouble(value);
                    break;
                case "System.Long":
                    objValue = long.Parse(value);
                    break;
                case "System.DateTime":
                    objValue = Convert.ToDateTime(value);
                    break;
                case "System.String":
                    objValue = value;
                    break;
            }
            return objValue;
        }
        #endregion

        #region 将字符串转换为实体对象
        /// <summary>
        /// 将字符串转换为实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        #endregion

        #region 检查字符串是否是邮件格式
        /// <summary>
        /// 检查字符串是否是邮件格式
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool IsEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z\d]+([-_.][A-Za-z\d]+)*@([A-Za-z\d]+[-.])+[A-Za-z\d]{2,4}$ ");
           
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
      
            return regex.IsMatch(email);
        }
        #endregion

        #region 检查字符串是否是电话号码格式
        /// <summary>
        /// 检查字符串是否是电话号码格式
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsMobileNumber(string number)
        {
            Regex regex = new Regex(@"134[0-8]\d{7}$|^13[^4]\d{8}$|^14[5-9]\d{8}$|^15[^4]\d{8}$|^16[6]\d{8}$|^17[0-8]\d{8}$|^18[\d]{9}$|^19[8,9]\d{8}$"); 
           
            if (string.IsNullOrWhiteSpace(number))
            {
                return false;
            }
          
            return regex.IsMatch(number);
        }
        #endregion

        #region 将实体对象转化为json字符串
        /// <summary>
        /// 将实体对象转化为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            
            return JsonConvert.SerializeObject(obj);
        }
        #endregion

        #region 将字符串转化为类型诗句
        /// <summary>
        /// 将字符串转化为类型诗句
        /// </summary>
        /// <typeparam name="T">；实体类型</typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T StringToType<T>(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return default(T);
            }
            Type type = typeof(T);
            object objValue = ConverBaseType(type.FullName, value);
            if (objValue != null)
            {
                return (T)objValue;
            }
            objValue = DeserializeObject<T>(value);
            return (T)objValue;
        }
        #endregion

       
    }
}

