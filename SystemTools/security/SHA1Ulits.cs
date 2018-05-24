namespace SystemTools.security
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class SHA1Ulits
    {
      

        private static  string GetSha1Hash(string input)
        {
            byte[] buffer  = Encoding.Default.GetBytes(input); ;
            SHA1 sha = new SHA1CryptoServiceProvider();
            StringBuilder builder = new StringBuilder(); 
            buffer = sha.ComputeHash(buffer);
            foreach (byte b in buffer) {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }

        private static bool VerifySha1Hash(string input, string hash)
        {
           
            string str = GetSha1Hash(input);
            return StringComparer.OrdinalIgnoreCase.Compare(str, hash) == 0;
          
        }
    }
}

