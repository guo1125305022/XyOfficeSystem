namespace SystemTools.security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class MD5Ulits
    {
        public MD5Ulits()
        {
            base..ctor();
            return;
        }

        public static unsafe string GetMd5Hash(string input)
        {
            MD5CryptoServiceProvider provider;
            byte[] buffer;
            byte[] buffer2;
            StringBuilder builder;
            int num;
            bool flag;
            string str;
            provider = new MD5CryptoServiceProvider();
            buffer = Encoding.Default.GetBytes(input);
            buffer2 = provider.ComputeHash(buffer);
            builder = new StringBuilder();
            num = 0;
            goto Label_0047;
        Label_0026:
            builder.Append(&(buffer2[num]).ToString("x2"));
            num += 1;
        Label_0047:
            if ((num < ((int) buffer2.Length)) != null)
            {
                goto Label_0026;
            }
            str = builder.ToString();
        Label_005E:
            return str;
        }
    }
}

