using SqlDataBaseService;
using SqlDataBaseService.objectUlit;
using SqlDataBaseService.objectUlits;
using SqlDataBaseService.table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SystemTools;

namespace SystemBusiness.systemBase
{
    /// <summary>
    /// 系统检查
    /// </summary>
    public class SystemCheckSelvice
    {
        private Thread checkThread;

        private Form _form;
        public SystemCheckSelvice() {

            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 系统基本数据数据集检查
        /// </summary>
        /// <returns></returns>
        private  void CheckedDataTable()
        {
            OnCheckInitListener(this);
            string assembly_path = AppConfigManage.GetConfigValue<string>("system_model_Assembly");
            var db = DbAction.CurrentDB();
            SQLHelper helper = new SQLHelper(db.ShowAllDataBaseTables());
            DataTable table = new DataTable();
            try
            {
                table= db.ExecuteToDataTable(helper);
            }
            catch (Exception e) {
                OnCheckExceptionListener(this,e);
                OnCheckEndListener(this);
                return;
                //throw new Exception("系统数据集自检失败", e);
            }
            if (table != null || table.Columns.Count < 1) {
                table.Columns[0].ColumnName = "NAME";
            }
            Assembly assembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory+"bin\\" + assembly_path);
            Type[] types=assembly.GetTypes();
            List<Dictionary<string, object>> fixList = new List<Dictionary<string, object>>();
            fixList.Clear();
            OnCheckStartListener(this, types.Length);
            int index = 0;
            foreach (Type type in types) {
                OnCheckIngListener(this, types.Length, index);
                if (!type.IsClass) {
                    continue;
                }
                TargetTbaleAttribute targetTbale = type.GetCustomAttribute<TargetTbaleAttribute>();
                if (targetTbale == null) {
                    continue;
                }
                ObjectResolverManage resolverManage=ObjectResolverManage.GetInstance();
                Dictionary<string,object> object_data=resolverManage.ResolverObject(type);
                if (object_data == null) {
                    continue;
                }
                DataRow[] rows=table.Select("NAME='" + object_data[ObjectAttrResolver.TABLE_NAME] + "'");
                if (rows.Count() >0) {
                    continue;
                }
                fixList.Add(object_data);
                index++;
            }
            index = 0;
            foreach (Dictionary<string, object> tableInfo in fixList) {
                try
                {
                    TableUlits.CreateTable(tableInfo);
                    
                    OnFixListener(this, fixList.Count, index);
                }
                catch (Exception e) {

                }
                index++;
            }
            OnCheckEndListener(this);
            Control.CheckForIllegalCrossThreadCalls = true;
            return;
        }

        
        /// <summary>
        /// 启动系统检查
        /// </summary>
        public void StartCheckSystem() {
            if (checkThread == null) {
                checkThread = new Thread(CheckedDataTable);
                checkThread.IsBackground = true;
            }
            if (checkThread.ThreadState == ThreadState.SuspendRequested || checkThread.ThreadState == ThreadState.Suspended) {
                return;
            }
            checkThread.Start();

        }
        public event OnInitStart OnCheckInitListener;
        public event OnCheckStart OnCheckStartListener;
        public event OnCheckIng OnCheckIngListener;
        public event OnCheckEnd OnCheckEndListener;
        public event OnCheckException OnCheckExceptionListener;
        public event OnFix OnFixListener;

        public delegate void OnInitStart(object service);
        public delegate void OnCheckStart(object service,int count);
        public delegate void OnCheckIng(object service,int count,int current);
        public delegate void OnCheckEnd(object service);
        public delegate void OnCheckException(object service, Exception e);
        public delegate void OnFix(object service, int count, int current);
    }
}
