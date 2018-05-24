using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.sys
{
    /// <summary>
    /// 用户登录信息
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_LOGIN_INFO:BaseModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string USER_ID { get; set; }
        /// <summary>
        /// 用户登陆IP地址
        /// </summary>
        [TargetColumn(null, "varchar", 100)]
        public string LOGIN_ADRESS_IP { get; set; }
        /// <summary>
        /// 用登陆MAC地址
        /// </summary>
        [TargetColumn(null, "varchar", 100)]
        public string LOGIN_ADDRESS_MAC { get; set; }

        public XT_LOGIN_INFO() { }
        public XT_LOGIN_INFO(string userId, DateTime loginTime) {
            this.USER_ID = userId;
        }


    }
}
