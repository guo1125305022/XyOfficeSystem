using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;

namespace SystemModels.sys
{
    [Serializable]
    [TargetTbale]
    public class XT_ROLE_MENU:BaseModel
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string MNEU_ID { get; set; }
        /// <summary>
        /// 角色编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string ROLE_ID { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        [TargetColumn(null, "varchar", 2000)]
        public string ICON { get; set; }
    }
}
