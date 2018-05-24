namespace SqlDataBaseService.sqlAction
{
    using System;
    using System.Data.Common;

    public class BaseDBFactory : IDBFactory, IDisposable
    {
      

      
        public DbConnection CreateSQLConnect<T>(string connectString) where T: DbConnection
        {
            Type type = typeof(T);
            object[] paramsData = new object[] { connectString };
            return (DbConnection)Activator.CreateInstance(type, paramsData);
        }

        public void Dispose()
        {
            return;
        }
    }
}

