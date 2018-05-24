
using SqlDataBaseService.colunm;
using System;

namespace SystemModels
{
    /// <summary>
    /// 基本数据表实体
    /// </summary>
    [Serializable]
    public class BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        [TargetColumn("ID","varchar",40,true)]
        public string ID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [TargetColumn("CREATE_BY","varchar",40)]
        public string CREATE_BY { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [TargetColumn("CREATE_TIME", "datetime")]
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [TargetColumn("MODIFY_BY", "varchar", 40)]
        public string MODIFY_BY { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [TargetColumn("MODIFY_TIME", "datetime")]
        public DateTime MODIFY_TIME { get; set; }

       
    }
}
