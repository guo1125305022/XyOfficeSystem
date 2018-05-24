namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using System;
    using System.Collections.Generic;
    using System.Data;

    public interface ISQLBaseAction
    {
        int Delete(SqlDataBaseService.SQLHelper helper);
        int Delete(object obj, string key, object value);
        SqlDataBaseService.Page<T> ExectuePage<T>(long startIndex, int pageSize, SqlDataBaseService.SQLHelper helper);
        DataTable ExecuteToDataTable(SqlDataBaseService.SQLHelper helper);
        List<Dictionary<string, object>> ExecuteToList(SqlDataBaseService.SQLHelper helper);
        int Insert(SqlDataBaseService.SQLHelper helper);
        int Insert(object obj);
        List<T> Select<T>(SqlDataBaseService.SQLHelper helper);
        long SelectCount(SqlDataBaseService.SQLHelper helper);
        T SelectFirstOrDefault<T>(SqlDataBaseService.SQLHelper helper);
        int Update(SqlDataBaseService.SQLHelper helper);
        int Update(object obj, string key, object value);
    }
}

