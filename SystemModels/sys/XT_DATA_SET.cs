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
    /// 数据表
    /// </summary>
    [TargetTbale]
    [Serializable]
    public class XT_DATA_SET:BaseModel
    {
        /// <summary>
        /// 数据表名
        /// </summary>
        [TargetColumn(null,null,500)]
        public string TABLE_NAME { get; set; }

        /// <summary>
        /// 数据表名中文名
        /// </summary>
        [TargetColumn(null, null, 500)]
        public string TABLE_NAME_CN { get; set; }

        /// <summary>
        /// 是否分组 1分组0数据表
        /// </summary>
        [TargetColumn(null,"int", 500)]
        public int IS_GROUP { get; set; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        [TargetColumn(null,null,500)]
        public string DATA_BASE_NAME { get; set; }

    }
}
