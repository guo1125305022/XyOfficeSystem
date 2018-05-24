namespace SystemTools.security
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    internal class DESUlits
    {
        public DESUlits()
        {
            base..ctor();
            return;
        }

        private static string DecryptDES(string pToDecrypt, string sKey)
        {
            byte[] buffer;
            DESCryptoServiceProvider provider;
            MemoryStream stream;
            string str;
            CryptoStream stream2;
            string str2;
            buffer = Convert.FromBase64String(pToDecrypt);
            provider = new DESCryptoServiceProvider();
        Label_000E:
            try
            {
                provider.Key = Encoding.ASCII.GetBytes(sKey);
                provider.IV = Encoding.ASCII.GetBytes(sKey);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, provider.CreateDecryptor(), 1);
            Label_0048:
                try
                {
                    stream2.Write(buffer, 0, (int) buffer.Length);
                    stream2.FlushFinalBlock();
                    stream2.Close();
                    goto Label_0076;
                }
                finally
                {
                Label_0069:
                    if (stream2 == null)
                    {
                        goto Label_0075;
                    }
                    stream2.Dispose();
                Label_0075:;
                }
            Label_0076:
                str = Encoding.UTF8.GetString(stream.ToArray());
                stream.Close();
                str2 = str;
                goto Label_009E;
            }
            finally
            {
            Label_0093:
                if (provider == null)
                {
                    goto Label_009D;
                }
                provider.Dispose();
            Label_009D:;
            }
        Label_009E:
            return str2;
        }

        private static string EncryptDES(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider provider;
            byte[] buffer;
            MemoryStream stream;
            string str;
            CryptoStream stream2;
            string str2;
            provider = new DESCryptoServiceProvider();
        Label_0007:
            try
            {
                buffer = Encoding.UTF8.GetBytes(pToEncrypt);
                provider.Key = Encoding.ASCII.GetBytes(sKey);
                provider.IV = Encoding.ASCII.GetBytes(sKey);
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, provider.CreateEncryptor(), 1);
            Label_004D:
                try
                {
                    stream2.Write(buffer, 0, (int) buffer.Length);
                    stream2.FlushFinalBlock();
                    stream2.Close();
                    goto Label_007B;
                }
                finally
                {
                Label_006E:
                    if (stream2 == null)
                    {
                        goto Label_007A;
                    }
                    stream2.Dispose();
                Label_007A:;
                }
            Label_007B:
                str = Convert.ToBase64String(stream.ToArray());
                stream.Close();
                str2 = str;
                goto Label_009E;
            }
            finally
            {
            Label_0093:
                if (provider == null)
                {
                    goto Label_009D;
                }
                provider.Dispose();
            Label_009D:;
            }
        Label_009E:
            return str2;
        }
    }
}

