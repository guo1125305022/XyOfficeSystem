namespace SystemTools.security
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal class C3DESUlits
    {
        private static SymmetricAlgorithm mCSP= new TripleDESCryptoServiceProvider();

       

        public static string DecryptString(string Value, string sKey, string sIV)
        {
            ICryptoTransform transform;
            MemoryStream stream;
            CryptoStream stream2;
            byte[] buffer;
            string str;
        
            try
            {
                mCSP.Key = Convert.FromBase64String(sKey);
                mCSP.IV = Convert.FromBase64String(sIV);
                mCSP.Mode = CipherMode.ECB;
                mCSP.Padding =PaddingMode.PKCS7;
                transform = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                buffer = Convert.FromBase64String(Value);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                str = Encoding.UTF8.GetString(stream.ToArray());
               
            }
            catch (Exception e)
            {

                throw new Exception("Error in Decrypting ", e);
              
            }
    
            return str;
        }

        public static string EncryptString(string Value, string sKey, string sIV)
        {
            ICryptoTransform transform;
            MemoryStream stream;
            CryptoStream stream2;
            byte[] buffer;
            string str;
         

            try
            {
                mCSP.Key = Convert.FromBase64String(sKey);
                mCSP.IV = Convert.FromBase64String(sIV);
                mCSP.Mode = CipherMode.ECB;
                mCSP.Padding = PaddingMode.PKCS7;
                transform = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
                buffer = Encoding.UTF8.GetBytes(Value);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, (int)buffer.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                str = Convert.ToBase64String(stream.ToArray());

            }
            catch (Exception e)
            {
                throw new Exception("Error in Encrypting", e);
            }
      
            return str;
        }
    }
}

