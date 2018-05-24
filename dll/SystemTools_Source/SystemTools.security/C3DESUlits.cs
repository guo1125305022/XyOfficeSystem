namespace SystemTools.security
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal class C3DESUlits
    {
        private static SymmetricAlgorithm mCSP;

        static C3DESUlits()
        {
            mCSP = new TripleDESCryptoServiceProvider();
            return;
        }

        public C3DESUlits()
        {
            base..ctor();
            return;
        }

        public static string DecryptString(string Value, string sKey, string sIV)
        {
            ICryptoTransform transform;
            MemoryStream stream;
            CryptoStream stream2;
            byte[] buffer;
            string str;
            Exception exception;
        Label_0001:
            try
            {
                mCSP.Key = Convert.FromBase64String(sKey);
                mCSP.IV = Convert.FromBase64String(sIV);
                mCSP.Mode = 2;
                mCSP.Padding = 2;
                transform = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
                buffer = Convert.FromBase64String(Value);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, transform, 1);
                stream2.Write(buffer, 0, (int) buffer.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                str = Encoding.UTF8.GetString(stream.ToArray());
                goto Label_00B7;
            }
            catch (Exception exception1)
            {
            Label_009F:
                exception = exception1;
                str = "Error in Decrypting " + exception.Message;
                goto Label_00B7;
            }
        Label_00B7:
            return str;
        }

        public static string EncryptString(string Value, string sKey, string sIV)
        {
            ICryptoTransform transform;
            MemoryStream stream;
            CryptoStream stream2;
            byte[] buffer;
            string str;
            Exception exception;
        Label_0001:
            try
            {
                mCSP.Key = Convert.FromBase64String(sKey);
                mCSP.IV = Convert.FromBase64String(sIV);
                mCSP.Mode = 2;
                mCSP.Padding = 2;
                transform = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
                buffer = Encoding.UTF8.GetBytes(Value);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, transform, 1);
                stream2.Write(buffer, 0, (int) buffer.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                str = Convert.ToBase64String(stream.ToArray());
                goto Label_00B7;
            }
            catch (Exception exception1)
            {
            Label_009F:
                exception = exception1;
                str = "Error in Encrypting " + exception.Message;
                goto Label_00B7;
            }
        Label_00B7:
            return str;
        }
    }
}

