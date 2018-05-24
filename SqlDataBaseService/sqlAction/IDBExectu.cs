namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using System;
    using System.Data.Common;

    public interface IDBExectu
    {
        DbDataAdapter ExecteAdapter(SQLHelper helper);
        DbDataAdapter ExecteAdapter(DbCommand command);
        int ExecuteNonQuery(SQLHelper helper);
        DbDataReader ExecuteReader(SQLHelper helper);
        object ExecuteScalar(SQLHelper helper);
    }
}

