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
            string str;
            BaseDbActionService service = DbAction.CurrentDB(); ;

            SQLHelper helper;
     
            str = ResolveCreateTableSql(tableInfo);
          
            try
            {
             helper = new SQLHelper(str, Array.Empty<object>());
             service.ExecuteNonQuery(helper);
            }
            catch (Exception e)
            {

                throw new Exception("数据表创建失败:执行语句\n" + str, e);
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

            List<ClassFiledInfo> list;
            StringBuilder builder;
            int num;
            
            string str2;
            bool flag2;
    
            ClassFiledInfo info;
            bool flag3;
            string sql = modelInfo[ObjectAttrResolver.TABLE_NAME].ToString();
            list = (List<ClassFiledInfo>) modelInfo["colunm_info"];
            if (string.IsNullOrWhiteSpace(str) )
            {
                return null;
             
            }
         
            return str2;
        }
    }
}

