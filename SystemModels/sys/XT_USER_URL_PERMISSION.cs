using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;

namespace SystemModels.sys
{
    /// <summary>
    /// 用户访问地权限控制
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_USER_URL_PERMISSION:BaseModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [TargetColumn(null, "varchar", 40)]
        public string USER_ID { get; set; }
        /// <summary>
        /// URL地址
        /// </summary>
        [TargetColumn(null, "varchar", 2000)]
        public string URL { get; set; }

        
    }
}