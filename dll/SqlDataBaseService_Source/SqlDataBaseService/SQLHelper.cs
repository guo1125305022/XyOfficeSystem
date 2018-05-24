namespace SqlDataBaseService
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SQLHelper : IDisposable
    {
        private List<object> _parameters;
        private string _sql;

        private SQLHelper()
        {
            base..ctor();
            return;
        }

        public SQLHelper(string sql, params object[] parameters)
        {
            this..ctor();
            this._sql = sql;
            this._parameters = new List<object>();
            this._parameters.AddRange(parameters);
            return;
        }

        public SQLHelper(StringBuilder sql, params object[] parameters)
        {
            this..ctor(sql.ToString(), parameters);
            return;
        }

        public void AddParameter(object parameter)
        {
            this.Parameters.Add(parameter);
            return;
        }

        public void Append(string sql, params object[] parameter)
        {
            this._sql = this._sql + sql;
            return;
        }

        public static SqlDataBaseService.SQLHelper CreateNewSQLHelper(string sql, params object[] parameters)
        {
            SqlDataBaseService.SQLHelper helper;
            helper = new SqlDataBaseService.SQLHelper(sql, parameters);
        Label_000B:
            return helper;
        }

        public static SqlDataBaseService.SQLHelper CreateNewSQLHelper(StringBuilder builder, params object[] parameters)
        {
            SqlDataBaseService.SQLHelper helper;
            helper = CreateNewSQLHelper(builder.ToString(), parameters);
        Label_0010:
            return helper;
        }

        public void Dispose()
        {
            this._sql = null;
            this._parameters = null;
            return;
        }

        public List<object> Parameters
        {
            get
            {
                List<object> list;
                list = this._parameters;
            Label_000A:
                return list;
            }
            set
            {
                bool flag;
                if ((this._parameters == null) == null)
                {
                    goto Label_001B;
                }
                this._parameters = new List<object>();
            Label_001B:
                this._parameters.Clear();
                this._parameters.AddRange(value);
                return;
            }
        }

        public string Sql
        {
            get => 
                this._sql;
            set
            {
                this._sql = value;
                return;
            }
        }
    }
}

