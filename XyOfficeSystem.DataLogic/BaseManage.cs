using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemBusiness;

namespace XyOfficeSystem.DataLogic
{
    /// <summary>
    /// 基本系统管理
    /// </summary>
    public class BaseManage
    {
        private static readonly Dictionary<string, BaseManage> ManageList = new Dictionary<string, BaseManage>();

        protected static T GetService<T>() {
            return ServiceManage.GetService<T>();
        }
        public static T GetInstance<T>() where T : BaseManage {

            return default(T);
        }
    }
}
