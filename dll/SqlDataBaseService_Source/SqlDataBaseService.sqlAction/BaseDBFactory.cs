namespace SqlDataBaseService.sqlAction
{
    using System;
    using System.Data.Common;

    public class BaseDBFactory : SqlDataBaseService.sqlAction.IDBFactory, IDisposable
    {
        public BaseDBFactory()
        {
            base..ctor();
            return;
        }

        public DbCommand CreateSQLCommand<T>() where T: DbCommand
        {
            Type type;
            DbCommand command;
            DbCommand command2;
            type = typeof(T);
            command = (DbCommand) Activator.CreateInstance(type);
            command2 = command;
        Label_001C:
            return command2;
        }

        public DbConnection CreateSQLConnect<T>(string connectString) where T: DbConnection
        {
            object[] objArray1;
            Type type;
            DbConnection connection;
            DbConnection connection2;
            type = typeof(T);
            objArray1 = new object[] { connectString };
            connection = (DbConnection) Activator.CreateInstance(type, objArray1);
            connection2 = connection;
        Label_0026:
            return connection2;
        }

        public void Dispose()
        {
            return;
        }
    }
}

