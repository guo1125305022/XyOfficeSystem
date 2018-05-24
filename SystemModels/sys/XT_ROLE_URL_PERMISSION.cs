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
    /// 用户角色访问地址权限配置
    /// <!--create by gxl 20180420-->
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_ROLE_URL_PERMISSION:BaseModel
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string ROLE_ID { get; set; }
        /// <summary>
        /// URL地址
        /// </summary>
        [TargetColumn(null, "text")]
        public string URL { get; set; }

    }
}
