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
    /// 网络访问中请求的参数
    /// </summary>
    [TargetTbale]
    public class XT_REQUEST_PARAMETER : BaseModel
    {
        /// <summary>
        /// 参数名
        /// </summary>

        [TargetColumn(null, "varchar", 1000)]
        public string PARAMETER_NAME { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        [TargetColumn(null, "text")]
        public string PARAMETER_VALUE { get; set; }
        /// <summary>
        /// 日志编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string LOG_ID { get; set; }
    }
}
