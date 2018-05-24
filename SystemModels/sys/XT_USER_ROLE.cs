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
    /// 用户角色
    /// </summary>
    [TargetTbale]
    [Serializable]
    public class XT_USER_ROLE:BaseModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string USER_ID { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string ROLE_ID { get; set; }
    }
}
