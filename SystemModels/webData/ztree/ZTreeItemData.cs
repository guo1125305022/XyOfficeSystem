using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemModels.webData.ztree
{
    /// <summary>
    /// bootstrap TreeView 树 的结构
    /// </summary>
    public class ZTreeItemData
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 父级编号
        /// </summary>
        public string PId { get; set; }
        public Dictionary<string,object> Attribute { get; set; }
        public void AddAttribute(string key,object value) {
            if (string.IsNullOrWhiteSpace(key)) {
                return;
            }
            if (Attribute == null) {
                Attribute = new Dictionary<string, object>();
            }
            Attribute.Add(key, value);
        }
        /// <summary>
        /// 树图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 树节点展开是图标
        /// </summary>
        public string IconOpen { get; set; }
        /// <summary>
        /// 树节点关闭是图标
        /// </summary>
        public string IconClose { get; set; }

        /// <summary>
        /// 创建数据结构数据
        /// </summary>
        /// <returns></returns>
        public static List<ZTreeItemData> CreateZTreeData() {
            return new List<ZTreeItemData>();
        }

        /// <summary>
        /// 创建数据结构数据
        /// </summary>
        /// <param name="rootNodeId">根节点ID</param>
        /// <param name="nodeText">根节点文本</param>
        /// <returns></returns>
        public static List<ZTreeItemData> CreateZTreeData(string rootNodeId, string nodeText) {
            List<ZTreeItemData> list= CreateZTreeData();
            if (string.IsNullOrWhiteSpace(rootNodeId)||string.IsNullOrWhiteSpace(nodeText)) {
                return new List<ZTreeItemData>();
            }
            ZTreeItemData zTreeItem = new ZTreeItemData();
            zTreeItem.name = nodeText;
            zTreeItem.Id = rootNodeId;
            list.Add(zTreeItem);
            return list;
        }
    }
}
