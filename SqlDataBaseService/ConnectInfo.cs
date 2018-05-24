namespace SqlDataBaseService
{
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// 数据连接信息
    /// </summary>
    public class ConnectInfo
    {
        /// <summary>
        /// 数据库类型
        /// </summary>
        public DataBaseType BaseType
        {
            get; set;
        }
        /// <summary>
        /// 连接名称
        /// </summary>
        public string ConnectName
        {
            get; set;
        }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectString
        {
            get; set;
        }
        /// <summary>
        /// 数据库执行服务
        /// </summary>
        internal BaseDbActionService DbService
        {
            set; get;
        }
    }
}

