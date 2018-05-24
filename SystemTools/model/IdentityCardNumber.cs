using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTools.model
{
    /// <summary>
    /// 身份证号号码解析实体
    /// </summary>
    public class IdentityCardNumber
    {
        
        public IdentityCardNumber(string idCardNumber) {
            if (string.IsNullOrWhiteSpace(idCardNumber)) {

            }
        }
    }
}
