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
         
        }

        public SQLHelper(string sql, params object[] parameters)
        {
            Sql = sql;
            Parameters = new List<object>();
            Parameters.AddRange(parameters);
            
        }

        public SQLHelper(StringBuilder sql, params object[] parameters)
        {
            Sql = sql.ToString();
            Parameters = new List<object>();
            Parameters.AddRange(parameters);
        }

        public void AddParameter(object parameter)
        {
            Parameters.Add(parameter);
         
        }

        public void Append(string sql, params object[] parameter)
        {
            Sql = Sql+ sql;
            Parameters.AddRange(parameter);
        }

        public static SQLHelper CreateNewSQLHelper(string sql, params object[] parameters)
        {
            SQLHelper helper;
            helper = new SQLHelper(sql, parameters);
            return helper;
        }

        public static SQLHelper CreateNewSQLHelper(StringBuilder builder, params object[] parameters)
        {
            SQLHelper helper;
            helper = CreateNewSQLHelper(builder.ToString(), parameters);
            return helper;
        }

        public void Dispose()
        {
            Sql = null;
            Parameters = null;
           
        }

        public List<object> Parameters
        {
            get
            {
                List<object> list;
                list = _parameters;
           
                return list;
            }
            set
            {
                _parameters = new List<object>();
                _parameters.Clear();
                _parameters.AddRange(value);
                return;
            }
        }

        public string Sql
        {
            get;set;
        }
    }
}

