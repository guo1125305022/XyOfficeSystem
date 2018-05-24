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
    /// 系统可配网页
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_SYSTEM_PAGE : BaseModel
    {
        /// <summary>
        /// 页标题
        /// </summary>
        [TargetColumn(Name = null, ColumnType = "varchar", DataLength = 500)]
        public string PAGE_TITLE { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [TargetColumn(Name = null, ColumnType = "int")]
        public int VERSION { get; set; }

        /// <summary>
        /// 访问地址
        /// </summary>
        [TargetColumn(Name = null, DataLength = 1000, ColumnType = "varchar")]
        public string ADDRESS_URL { get; set; }
       

        /// <summary>
        /// 页面内容l
        /// </summary>
        [TargetColumn(Name =null,ColumnType ="text")]
        public string PAGE_CONTENT { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [TargetColumn(Name = null, ColumnType = "varchar",DataLength =500)]
        public string REMARK { get; set; }


        /// <summary>
        /// 是否组件
        /// 0 分组：1页面
        /// </summary>
        [TargetColumn(ColumnType = "int")]
        public int IS_PAGE { get; set; }

        /// <summary>
        /// 父级编号
        /// </summary>
        [TargetColumn(DataLength = 40)]
        public int PARENT_ID { get; set; }

    }
}
