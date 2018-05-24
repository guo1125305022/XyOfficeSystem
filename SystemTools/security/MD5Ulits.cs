namespace SystemTools.security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class MD5Ulits
    {
      
        /// <summary>
        /// MD5º”√‹
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static  string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
            byte[] buffer = Encoding.UTF8.GetBytes(input);
            StringBuilder builder = new StringBuilder(); 
            buffer = provider.ComputeHash(buffer);
            foreach (byte b in buffer) {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}

