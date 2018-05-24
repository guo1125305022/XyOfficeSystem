
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
    /// 系统可操作对象
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_ACTION : BaseModel
    {
        /// <summary>
        /// 操作名称
        /// </summary>
        [TargetColumn(null, "varchar", 200)]
        public string ACTION_NAME { get; set; }
        /// <summary>
        /// 操作动作
        /// </summary>
        [TargetColumn(null, "bigint")]
        public string ACTION_CODE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [TargetColumn(null, "varchar",500)]
        public string ACTION_REMARK { get; set; }
        
    }
}
