namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using System;
    using System.Data.Common;

    public interface IDBExectu
    {
        DbDataAdapter ExecteAdapter(SqlDataBaseService.SQLHelper helper);
        DbDataAdapter ExecteAdapter(DbCommand command);
        int ExecuteNonQuery(SqlDataBaseService.SQLHelper helper);
        DbDataReader ExecuteReader(SqlDataBaseService.SQLHelper helper);
        object ExecuteScalar(SqlDataBaseService.SQLHelper helper);
    }
}

