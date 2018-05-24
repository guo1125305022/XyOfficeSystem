namespace SqlDataBaseService
{
    using SqlDataBaseService.sqlAction;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// ����������Ϣ
    /// </summary>
    public class ConnectInfo
    {
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public DataBaseType BaseType
        {
            get; set;
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string ConnectName
        {
            get; set;
        }
        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public string ConnectString
        {
            get; set;
        }
        /// <summary>
        /// ���ݿ�ִ�з���
        /// </summary>
        internal BaseDbActionService DbService
        {
            set; get;
        }
    }
}

