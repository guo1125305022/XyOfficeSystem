using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDataBaseService.sqlAction
{
    public interface IDBCommand
    {
        /// <summary>
        /// 根据数据库类型获取数据库命令执行类型
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        Type GetCommandType(DataBaseType dataBaseType);

        /// <summary>
        /// 根据数据库类型获取命令执行参数类型
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        Type GetCommandParameter(DataBaseType dataBaseType);

        /// <summary>
        /// 创建命令执行对象
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <returns></returns>
        DbCommand CreateCommand(DataBaseType dataBaseType);

        /// <summary>
        /// 创建命令执行对象
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        DbCommand CreateCommand(DataBaseType dataBaseType, String sql);

        /// <summary>
        /// 创建命令执行对象
        /// </summary>
        /// <param name="dataBaseType"></param>
        /// <param name="sql"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        DbCommand CreateCommand(DataBaseType dataBaseType, String sql, params object[] objects);


        string GetSQLVariableChar(DataBaseType dataBaseType);








    }
}
