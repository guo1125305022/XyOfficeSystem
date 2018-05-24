namespace SqlDataBaseService.sqlAction
{
    using System;
    using System.Data.Common;

    public interface IDBFactory : IDisposable
    {
        DbCommand CreateSQLCommand<T>() where T: DbCommand;
        DbConnection CreateSQLConnect<T>(string connectString) where T: DbConnection;
    }
}

