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
    /// 系统菜单
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_MENU:BaseModel
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [TargetColumn(null, "varchar", 200)]
        public string MENU_NAME { get; set; }
        /// <summary>
        /// 菜单URL 地址
        /// </summary>
        [TargetColumn(null, "varchar", 2000)]
        public string MENU_URL { get; set; }
        /// <summary>
        /// 菜单父级编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string PARENT_ID { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [TargetColumn(null, "varchar", 2000)]
        public string ICON { get; set; }
        /// <summary>
        /// 菜单排序
        /// </summary>
        [TargetColumn(null, "int")]
        public int SORT { get; set; }
    }
}
