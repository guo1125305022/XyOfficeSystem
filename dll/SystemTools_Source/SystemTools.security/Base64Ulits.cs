namespace SystemTools.security
{
    using System;
    using System.Text;

    public class Base64Ulits
    {
        public Base64Ulits()
        {
            base..ctor();
            return;
        }

        public static string DecryptBase64(string input)
        {
            byte[] buffer;
            string str;
            buffer = Convert.FromBase64String(input);
            str = Encoding.UTF8.GetString(buffer);
        Label_0016:
            return str;
        }

        public static string EncryptBase64(string input)
        {
            byte[] buffer;
            string str;
            str = Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        Label_0016:
            return str;
        }
    }
}

