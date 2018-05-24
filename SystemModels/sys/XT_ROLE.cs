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
    public class XT_ROLE:BaseModel
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [TargetColumn(null, "varchar", 500)]
        public string ROLE_NAME { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string PARENT_ID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        [TargetColumn(null, "int", 40)]
        public int SORT { get; set; }
    }
}
