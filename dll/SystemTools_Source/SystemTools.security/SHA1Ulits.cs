namespace SystemTools.security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class SHA1Ulits
    {
        public SHA1Ulits()
        {
            base..ctor();
            return;
        }

        private static unsafe string GetSha1Hash(string input)
        {
            byte[] buffer;
            SHA1 sha;
            byte[] buffer2;
            StringBuilder builder;
            int num;
            bool flag;
            string str;
            buffer = Encoding.Default.GetBytes(input);
            sha = new SHA1CryptoServiceProvider();
            buffer2 = sha.ComputeHash(buffer);
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

        private static bool VerifySha1Hash(string input, string hash)
        {
            string str;
            StringComparer comparer;
            bool flag;
            bool flag2;
            str = GetSha1Hash(input);
            if ((StringComparer.OrdinalIgnoreCase.Compare(str, hash) == 0) == null)
            {
                goto Label_0022;
            }
            flag2 = 1;
            goto Label_0027;
        Label_0022:
            flag2 = 0;
        Label_0027:
            return flag2;
        }
    }
}

