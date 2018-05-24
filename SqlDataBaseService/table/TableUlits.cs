namespace SqlDataBaseService.table
{
    using SqlDataBaseService;
    using SqlDataBaseService.objectUlit;
    using SqlDataBaseService.objectUlits;
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TableUlits
    {
      

        public static void CreateTable(Dictionary<string, object> tableInfo)
        {
           
            BaseDbActionService service = DbAction.CurrentDB();
            string sql = ResolveCreateTableSql(tableInfo);
            SQLHelper helper = new SQLHelper(sql); 
            try
            {
             service.ExecuteNonQuery(helper);
            }
            catch (Exception e)
            {
                throw new Exception("数据表创建失败:执行语句\n" + sql, e);
            }
            finally
            {
         
                service.Dispose();
            }
     


            return;
        }
        /// <summary>
        /// 解析列数据并转换为SQL 
        /// </summary>
        /// <param name="classFiled"></param>
        /// <returns></returns>
        private static string ResolveClassFiled(ClassFiledInfo classFiled)
        {
            StringBuilder builder;
            builder = new StringBuilder(classFiled.ColunmName);
            builder.Append(" " + classFiled.Column_type);
            if (classFiled.DataLength > 0)
            {
                builder.Append("(" + classFiled.DataLength + ")");
            }
            if (classFiled.IsPk )
            {
                builder.Append(" PRIMARY KEY");
                return builder.ToString();
             
            }
            if (classFiled.Default_value!=null)
            {
                if (classFiled.Default_value is string || classFiled.Default_value is DateTime)
                {
                    builder.Append(" default '" + classFiled.Default_value + "'");
                }
                else {
                    builder.Append(" default " + classFiled.Default_value);
                }
            }
           
            return builder.ToString();
        }

        public static  string ResolveCreateTableSql(Dictionary<string, object> modelInfo)
        {

         
            string tableName = modelInfo[ObjectAttrResolver.TABLE_NAME].ToString();
            if (string.IsNullOrWhiteSpace(tableName))
            {
                return null;
            }
            List<ClassFiledInfo> list = (List<ClassFiledInfo>) modelInfo[ObjectAttrResolver.COLUNM_INFO];
            StringBuilder builder = new StringBuilder("create table "+tableName+" (");
            for (int i = 0; i <list.Count; i++)
            {
                builder.AppendLine(i < 1 ? ResolveClassFiled(list[i]) : "," + ResolveClassFiled(list[i]));
               
            }
            builder.Append(")");
            return builder.ToString(); ;
        }
    }
}

