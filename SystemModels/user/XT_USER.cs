using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;
using SystemModels.sys;

namespace SystemModels.user
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_USER: XT_TEMP_PORARY_USER
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        [TargetColumn(null, "varchar", 200)]
        public string LOGIN_NAME { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        [TargetColumn(null, "varchar", 200)]
        public string PWD { get; set; }
        /// <summary>
        /// 用户拼音
        /// </summary>
        [TargetColumn(null, "varchar", 200)]
        public string PING_YIN { get; set; }
        
    }
}
