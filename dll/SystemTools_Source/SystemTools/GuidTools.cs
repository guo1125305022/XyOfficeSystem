namespace SystemTools
{
    using System;

    public class GuidTools
    {
        public GuidTools()
        {
            base..ctor();
            return;
        }

        public static unsafe string NewGuid()
        {
            string str;
            Guid guid;
            string str2;
            str2 = &Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        Label_002D:
            return str2;
        }
    }
}

