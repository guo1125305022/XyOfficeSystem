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
         
            return;
        }

        public SQLHelper(string sql, params object[] parameters)
        {
           
            this._sql = sql;
            this._parameters = new List<object>();
            this._parameters.AddRange(parameters);
            return;
        }

        public SQLHelper(StringBuilder sql, params object[] parameters)
        {
           
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

        public static SQLHelper CreateNewSQLHelper(string sql, params object[] parameters)
        {
            SqlDataBaseService.SQLHelper helper;
            helper = new SqlDataBaseService.SQLHelper(sql, parameters);
      
            return helper;
        }

        public static SqlDataBaseService.SQLHelper CreateNewSQLHelper(StringBuilder builder, params object[] parameters)
        {
            SqlDataBaseService.SQLHelper helper;
            helper = CreateNewSQLHelper(builder.ToString(), parameters);
      
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
           
                return list;
            }
            set
            {
              
              
                this._parameters = new List<object>();
                this._parameters.Clear();
                this._parameters.AddRange(value);
                return;
            }
        }

        public string Sql
        {
            get =>
                _sql;
            set
            {
                _sql = value;
                return;
            }
        }
    }
}

