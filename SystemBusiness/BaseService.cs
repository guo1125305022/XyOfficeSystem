using SqlDataBaseService;
using SqlDataBaseService.objectUlits;
using SqlDataBaseService.sqlAction;
using System;
using System.Collections.Generic;
using System.Data;
using SystemModels;
using SystemTools;

namespace SystemBusiness
{
    /// <summary>
    /// 基本数据库服务
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseService<T> where T : BaseModel 
    {
        public BaseDbActionService db = DbAction.CurrentDB();

        #region 数据查询
        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public List<T> Select(SQLHelper helper) {
            
            try
            {
                return db.Select<T>(helper);
            }
            catch (Exception e){
                throw new Exception("数据查询失败", e);
            }
            finally {
                db.Dispose();
            }
         
        }
        #endregion

        #region 添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Insert(T obj,bool returnObj=false)
        {
            int rowNum = -1;
            try
            {
                obj.ID = GuidTools.NewGuid();
                obj.CREATE_TIME = DateTime.Now;
                obj.MODIFY_TIME = DateTime.Now;
                rowNum = db.Insert(obj);
                if (returnObj)
                {
                    return obj;
                }
            }
            catch(Exception e)
            {
                throw new Exception("数据添加失败" + e.Message);
            }
            finally
            {
                db.Dispose();
            }
            return rowNum;
        }
        #endregion

        #region 更新数据
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update(T obj)
        {
            int rowNum = -1;
            try
            {
                obj.MODIFY_TIME = DateTime.Now;
                rowNum = db.Update(obj, "ID", obj.ID);
            }
            catch(Exception e)
            {
                throw new Exception("数据表更新失败"+e.Message);

            }
            finally
            {
                db.Dispose();
            }
            return rowNum;

        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Delete(T obj)
        {
            int rowNum = -1;
            try
            {
                rowNum = db.Delete(obj, "ID", obj.ID);
            }
            catch
            {

            }
            finally
            {
                db.Dispose();
            }
            return rowNum;
        }
        #endregion

        #region 只查询一个
        /// <summary>
        /// 只查询一个
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public T SelectFirstOrDefault(SQLHelper helper)
        {
            return db.SelectFirstOrDefault<T>(helper);
        }
        #endregion

        #region 查询所有数据
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderByColumnNames"></param>
        /// <returns></returns>
        public List<T> SelectAll(List<string> orderByColumnNames=null) {
            string tableName = ObjectResolverManage.GetInstance().GetTableName<T>();
            SQLHelper helper = new SQLHelper("select * from " + tableName);
            if (orderByColumnNames != null&&orderByColumnNames.Count>0) {
               
                helper.Append(" order by ");
                int index = 0;
                foreach (string columnName in orderByColumnNames) {
                    if (index < 1)
                    {
                        helper.Append(columnName);
                        index++;
                    }
                    else {
                        helper.Append(","+columnName);
                    }
                }
            }
            return db.Select<T>(helper);
        }
        #endregion
        
        #region 获取总数
        /// <summary>
        /// 获取总数
        /// </summary>
        /// <returns></returns>
        public long GetCount()
        {
            string tableName = ObjectResolverManage.GetInstance().GetTableName<T>();
            SQLHelper helper = new SQLHelper("select count(ID) as countNum from " + tableName);
            DataTable dt = db.ExecuteToDataTable(helper);
            DataRow dr = dt.Rows[0];
            return Convert.ToInt64(dr["countNum"]);
        }
        #endregion

        #region 更新数据或插入数据
        /// <summary>
        /// 更新数据或插入数据
        /// </summary>
        /// <param name="obj">数据对象</param>
        /// <returns></returns>
        public int InsertOrUpdate(T obj) {
            if (string.IsNullOrWhiteSpace(obj.ID))
            {
               return (int)Insert(obj);
            }
            else {
                return Update(obj);
            }
        }
        #endregion;

        #region 根据ID 查询记录
        /// <summary>
        /// 根据ID 查询记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T SelectById(string Id) {
            string tableName = ObjectResolverManage.GetInstance().GetTableName<T>();
            SQLHelper helper = new SQLHelper("select * from " + tableName + " where ID=@0", Id);
            return SelectFirstOrDefault(helper);
        }
        #endregion;

        #region 查询数据返回数据表类型
        /// <summary>
        /// 查询数据返回数据表类型
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public DataTable SelectToTable(SQLHelper helper) {
            return db.ExecuteToDataTable(helper);
        }
        #endregion;

        #region sql执行
        /// <summary>
        /// sql执行
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(SQLHelper helper) {
            try
            {
               return db.ExecuteNonQuery(helper);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally {
                db.Dispose();
            }
           
        }
        #endregion
    }
}
