//初始化zTree
function InitTree(treeId, setting, data) {
    treeId = getTreeId(treeId);
    $.fn.zTree.init($("#"+treeId), setting, data);
}
//获取zTree object
function getTree(treeId) {
    treeId = getTreeId(treeId);
    return $.fn.zTree.getZTreeObj(treeId);
}
///获取标准的树id
function getTreeId(treeId) {
    if (treeId.indexOf("#") > -1) {
        treeId = treeId.replace("#", "");
    }
    return treeId;
}
//获取选择的节点
function getTreeSelected(treeId) {
    return getTree(treeId).getSelectedNodes();
}
//获取选中的第一个节点
function getTreeSingleSelected(treeId) {
    var nodes = getTreeSelected(treeId);
    if (!nodes) {
        return null;
    }
    return nodes[0];
}
///删除节点
function removeNode(treeId, nodes) {
    var tree = getTree(treeId);
    if (nodes instanceof Array) {
        for (var i = 0; i < nodes.length; i++) {
            tree.removeNode(nodes);
        }
    } else {
        tree.removeNode(nodes);
    }
   
}
/*添加节点*/
function addNodes(treeId, childerNodes) {
    var parentNode = null;
    if (childerNodes instanceof Array) {
        parentNode= getNodeById(treeId, childerNodes[0].PId);
        for (var i = 0; i < childerNodes.length; i++) {
            childerNodes[i].isParent = "isParent";
        }
    } else {
        childerNodes.isParent = "";
        parentNode = getNodeById(treeId, childerNodes.PId);
    }
    
    getTree(treeId).addNodes(parentNode, childerNodes);
}

//根据ID获取查找节点
function getNodeById(treeId, nodeId) {
    return getTree(treeId).getNodeByParam("Id", nodeId, null);
}

