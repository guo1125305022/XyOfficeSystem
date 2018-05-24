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
    /// 游客访问
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_TEMP_PORARY_USER:BaseModel
    {
        /// <summary>
        /// 游客名称
        /// </summary>
        [TargetColumn(null, "varchar", 200)]
        public string USER_NAME { get; set;}
        /// <summary>
        /// 登录后的用户编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string USER_ID { get; set; }
    }
}
