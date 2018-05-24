namespace SqlDataBaseService.sqlAction
{
    using SqlDataBaseService;
    using System.Collections.Generic;
    using System.Data;

    public interface ISQLBaseAction
    {
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        int Delete(SQLHelper helper);
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int Delete(object obj, string key, object value);
        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="startIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="helper"></param>
        /// <returns></returns>
        Page<T> ExectuePage<T>(long startIndex, int pageSize, SQLHelper helper);
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        DataTable ExecuteToDataTable(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        List<Dictionary<string, object>> ExecuteToList(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        int Insert(SQLHelper helper);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int Insert(object obj);
        /// <summary>
        ///  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>

        List<T> Select<T>(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        long SelectCount(SQLHelper helper);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="helper"></param>
        /// <returns></returns>
        T SelectFirstOrDefault<T>(SQLHelper helper);

        int Update(SQLHelper helper);

        int Update(object obj, string key, object value);


        /// <summary>
        /// ��ȡ��ǰ���ݿ��������е����ݿ�����
        /// </summary>
        /// <returns></returns>
        string ShowALLDataBaseSQL();

        /// <summary>
        /// ��ѯָ�����ݿ��е��������ݱ�
        /// </summary>
        /// <param name="dataBase"></param>
        /// <returns></returns>
        string ShowAllDataBaseTables(string dataBase);
        /// <summary>
        /// ��ȡ��ǰ�����е��������ݱ�
        /// </summary>
        /// <returns></returns>
        string ShowAllDataBaseTables();

        /// <summary>
        /// ��ȡ��ǰ�������ݿ�����
        /// </summary>
        /// <returns></returns>
        string getCurrentDataBaseName();
    }
}

