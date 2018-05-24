using SqlDataBaseService.colunm;
using SqlDataBaseService.table;
using System;

namespace SystemModels.sys
{
    #region 网页组件模板
    /// <summary>
    /// 网页组件模板
    /// </summary>
    [Serializable]
    [TargetTbale]
    public class XT_HTML_COMPONENT:BaseModel
    {

        /// <summary>
        /// 组建名称
        /// </summary>
        [TargetColumn(DataLength = 200)]
        public string COMPONT_NAME { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [TargetColumn(DataLength =500)]
        public string REMARK { get; set; }

        /// <summary>
        /// 模板
        /// </summary>
        [TargetColumn(ColumnType ="text")]
        public string COMPONT_TEMPLATE { get; set; }

        #region 版本
        /// <summary>
        /// 版本
        /// </summary>
        [TargetColumn(ColumnType = "int")]
        public int VERSION { get; set; }
        #endregion 版本

        #region 排序序号
        /// <summary>
        /// 排序序号
        /// </summary>
        [TargetColumn(ColumnType ="int")]
        public int SORT { get; set; }
        #endregion

        #region 是否组件
        /// <summary>
        /// 是否组件
        /// 0 分组：1组件
        /// </summary>
        [TargetColumn(ColumnType ="int")]
        public int IS_COMPONENT { get; set; }
        #endregion

        #region 父级编号
        /// <summary>
        /// 父级编号
        /// </summary>
        [TargetColumn(DataLength =40)]
        public int PARENT_ID { get; set; }
        #endregion

    }
    #endregion
}
