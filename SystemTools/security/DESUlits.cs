namespace SystemTools.security
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal class DESUlits
    {
        /// <summary>
        /// Ω‚√‹
        /// </summary>
        /// <param name="pToDecrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string DecryptDES(string pToDecrypt, string sKey)
        {
            
            DESCryptoServiceProvider provider;
            MemoryStream stream  = new MemoryStream(); ;
            string str;
            CryptoStream cryptoStream=null;
            string str2;
            byte[] buffer = Convert.FromBase64String(pToDecrypt);
            provider = new DESCryptoServiceProvider();
           
            try
            {
                provider.Key = Encoding.ASCII.GetBytes(sKey);
                provider.IV = Encoding.ASCII.GetBytes(sKey);
                cryptoStream = new CryptoStream(stream, provider.CreateDecryptor(),CryptoStreamMode.Write);
                cryptoStream.Write(buffer, 0, buffer.Length);
                cryptoStream.FlushFinalBlock();
                cryptoStream.Close();
                str = Encoding.UTF8.GetString(stream.ToArray());
                stream.Close();
                str2 = str;
                
            }
            finally
            {
                if (cryptoStream != null) {
                    cryptoStream.Dispose();
                }
                if (stream != null) {
                    stream.Dispose();
                }
                if (provider != null)
                {
                    provider.Dispose();
                }
            }
            
            return str2;
        }
        /// <summary>
        /// º”√‹
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public static string EncryptDES(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider provider;
            byte[] buffer;
            MemoryStream stream=null;
            string str;
            CryptoStream cryptoStream=null;
            provider = new DESCryptoServiceProvider();
            try
            {
                buffer = Encoding.UTF8.GetBytes(pToEncrypt);
                provider.Key = Encoding.ASCII.GetBytes(sKey);
                provider.IV = Encoding.ASCII.GetBytes(sKey);
                stream = new MemoryStream();
                cryptoStream = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(buffer, 0, (int)buffer.Length);
                cryptoStream.FlushFinalBlock();
                cryptoStream.Close();
                str = Convert.ToBase64String(stream.ToArray());
                stream.Close();
            }
            finally
            {

                if (cryptoStream != null)
                {
                    cryptoStream.Dispose();
                }
                if (stream != null)
                {
                    stream.Dispose();
                }
                if (provider != null)
                {
                    provider.Dispose();
                }

            }
           
            return str;
        }

     
    }
}

