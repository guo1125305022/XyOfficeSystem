using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.webData.user
{
    /// <summary>
    /// 用户登录返回登录信息
    /// </summary>
    [Serializable]
    public class UserLoginData : BaseData
    {
        public bool LoginState { get; set;}
    }
}
