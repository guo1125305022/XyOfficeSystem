using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.webData
{
    [Serializable]
    public class BaseData
    {
        public  string Message { get; set; }
        public object Data { get; set; }
        

    }
}
