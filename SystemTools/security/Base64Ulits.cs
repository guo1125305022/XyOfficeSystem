namespace SystemTools.security
{
    using System;
    using System.Text;

    public class Base64Ulits
    {

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string DecryptBase64(string input)
        {
            byte[] buffer = Convert.FromBase64String(input);
            return Encoding.UTF8.GetString(buffer);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string EncryptBase64(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input)); ;
        }
    }
}

