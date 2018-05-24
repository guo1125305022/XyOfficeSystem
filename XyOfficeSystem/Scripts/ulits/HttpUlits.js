//基本网络请求
function BaseAjax(url, action, data, success, error) {
    if (data == undefined || data == null) {
        data = {};
    }
    data.action = action;
    var config = {
        type:"post",
        timeout: 6000,
        dataType: "json",
        data: data,
        url: url,
        error: error,
        success: success
    };
    $.ajax(config);

}
//当地址网络基本请求
function CurrentBaseAjax(action, data, success, error) {
    BaseAjax(location.href, action, data, success, error);
}

//获取当前网站根目录
function GetRootPath() {
    var pathName = window.location.pathname.substring(1);
    var webName = pathName == '' ? '' : pathName.substring(0, pathName.indexOf('/'));
    if (webName == "") {
        return window.location.protocol + '//' + window.location.host;
    }
    else {
        return window.location.protocol + '//' + window.location.host + '/' + webName;
    }
}




