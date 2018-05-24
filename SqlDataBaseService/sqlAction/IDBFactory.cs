namespace SqlDataBaseService.sqlAction
{
    using System;
    using System.Data.Common;

    public interface IDBFactory : IDisposable
    {
        
        DbConnection CreateSQLConnect<T>(string connectString) where T: DbConnection;
    }
}

