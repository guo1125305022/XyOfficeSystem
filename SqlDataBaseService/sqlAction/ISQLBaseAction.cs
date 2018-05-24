namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using System.Collections.Generic;
    using System.Data;

    public interface ISQLBaseAction
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        int Delete(SQLHelper helper);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Delete(object obj, string key, object value);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="helper"></param>
        /// <returns></returns>
        Page<T> ExectuePage<T>(long startIndex, int pageSize, SQLHelper helper);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        DataTable ExecuteToDataTable(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> ExecuteToList(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        int Insert(SQLHelper helper);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Insert(object obj);
        /// <summary>
        ///  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>

        List<T> Select<T>(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        long SelectCount(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>
        T SelectFirstOrDefault<T>(SQLHelper helper);

        int Update(SQLHelper helper);

        int Update(object obj, string key, object value);


        /// <summary>
        /// 获取当前数据库引擎所有的数据库名称
        /// </summary>
        /// <returns></returns>
        string ShowALLDataBaseSQL();

        /// <summary>
        /// 查询指定数据库中的所有数据表
        /// </summary>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        string ShowAllDataBaseTables(string dataBase);
        /// <summary>
        /// 获取当前数据中的所有数据表
        /// </summary>
        /// <returns></returns>
        string ShowAllDataBaseTables();

        /// <summary>
        /// 获取当前连接数据库名称
        /// </summary>
        /// <returns></returns>
        string getCurrentDataBaseName();
    }
}

