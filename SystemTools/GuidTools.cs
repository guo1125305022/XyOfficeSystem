namespace SystemTools
{
    using System;

    public class GuidTools
    {
        public static  string NewGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }

    }
}

