using SqlDataBaseService.colunm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.sys
{
    /// <summary>
    /// 角色操作
    /// </summary>
    public class XT_ROLE_ACTION
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string ROLE_ID { get; set; }
        /// <summary>
        /// 操作编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string ACTION_ID { get; set; }

    }
}
