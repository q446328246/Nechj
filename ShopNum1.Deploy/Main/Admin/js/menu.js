var shopnum1;
if (shopnum1 == undefined || typeof (shopnum1) == undefined || shopnum1 == null) {
    shopnum1 = function () {
    };
}
if (typeof (shopnum1.Tool) == undefined || shopnum1.Tool == null) {
    shopnum1.Tool = function () {
    };
}

//数据加载
shopnum1.Tool.LoadMask = {
    defaults: {
        isClose: false, //是否显示一定时间后自动关闭
        time: 0, //显示时间:为秒数
        timespan: 1000,
        text: ""
    },
    show: function (option) {
        var loadmask = null;
        var options = $.extend({}, shopnum1.Tool.LoadMask.defaults, option);
        if ($(window.top.document).find("#loadMask").length == 0) {
            loadmask = $("<div id='loadMask' class='loading' style=''><span class='loading_img'><img src='img/load_c011.gif' style='border:0px;' /></span><span class='loading_message'>数据加载中，请稍后...</span></div>");
            $(window.top.document).find("body").append(loadmask);

        } else {
            $(window.top.document).find("#loadMask").show();
            if (options.isClose) {
                setTimeout(shopnum1.Tool.LoadMask.hide, options.time * timespan);
            }
        }
    },
    hide: function () {
        $(window.top.document).find("#loadMask").hide();
    }
};