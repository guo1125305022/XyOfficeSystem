using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.sys
{
    [Serializable]
    [TargetTbale]
    public class XT_SYS_LOG:BaseModel
    {
        /// <summary>
        /// 访问的地址
        /// </summary>
        [TargetColumn(null, "varchar", 2000)]
        public string ADDRESS_URL { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string USER_ID { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        [TargetColumn(null, "text")]
        public string EX_MESSAGE { get; set; }
        /// <summary>
        /// 访问的参数
        /// </summary>
        [TargetColumn(null, "text")]
        public string ACCESS_PARAMER { get; set;}

    }
}
