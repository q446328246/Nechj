//Jely 20130722整合js
if (top.location != location) top.location.href = location.href;
$(function () {
    //加
    $(".increase").click
    (
        function () {
            var BuyNum = parseInt($("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").val()); //购买数量
            $("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").val(BuyNum + 1)
        }
    );
    //减
    $(".decrease").click
    (
            function () {
                var BuyNum = parseInt($("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").val()); //购买数量
                if (BuyNum > 1) {
                    $("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").val(BuyNum - 1)
                }
            }
     );
    ///////////////////////<!--购买数量加减-->////////////////////////
    document.title = $("#ProductDetail_ctl00_RepeaterData_ctl00_LabelName").html() + " " + document.title;
    $(".jqzoom").jqueryzoom({
        xzoom: 400,
        yzoom: 400,
        offset: 10,
        position: "right",
        preload: 1,
        lens: 1
    });
    $("#tb_gallery").jdMarquee({
        deriction: "left",
        width: 300,
        height: 67,
        step: 2,
        speed: 4,
        delay: 10,
        control: true,
        _front: "#spec-right",
        _back: "#spec-left"
    });
    $("#tb_gallery img").bind("mouseover", function () {
        var src = $(this).attr("src");
        $("#spec-n1 img").eq(0).attr({
            src: src.replace("\/n5\/", "\/n1\/"),
            jqimg: src.replace("\/n5\/", "\/n0\/")
        });
        $(this).parent().parent().parent().addClass("tb_selected");
    }).bind("mouseout", function () {
        $(this).parent().parent().parent().removeClass("tb_selected");
    });

});
///////////////////////////////////////////物流JS//////////////////////////////////////////////////////////
function checkSubmit(num)  //点击立刻购买时候检查参数是否正确
{
    ///检查库存
    var buyNum = $("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").val();
    var numyz = /^[0-9]{1,9}$/;
    if (!numyz.exec(buyNum)) {
        alert("购买数量格式不正确!");
        $("#ProductDetail_ctl00_RepeaterData_ctl00_TextBoxBuyNum").get(0).focus();
        return false;
    }
    var allcout = $("#ProductDetail_ctl00_RepeaterData_ctl00_LabelRepertoryCount").text();
    if (parseInt(buyNum) >= parseInt(allcout)) {
        alert("库存不足!");
        return false;
    }
    //检查规格
    var juls = $(".restrict ul");
    var spenames = "";
    juls.each(function (i) {
        if ($(this).children(".liselect").length == 0) {
            spenames += "\"" + $.trim($(this).children(":first-child").find("span").text()) + "\"" + " ";
        }
    });
    if (spenames != "") {
        alert("请选择 " + spenames);
        return false;
    }
    $("#hidgotoId").val(num);
    return true;
}

//////////////////////邮费相关////////////////////////////////////////////////
$(function () {
    //如果是包邮就退出
    if (document.getElementById("ahrefregionname") == null) { return; }
    //绑定移除事件
    $("#divProvinceRegion").mouseout(function () { $(this).hide(); $("#divProvinceRegion table tr td a").removeAttr("style"); $("#divProvinceRegion table tr td a").parent().removeAttr("style"); });
    $("#divProvinceRegion").mouseover(function () { $(this).show() });
    //地区鼠标移动事件
    $("#divProvinceRegion table tr td").each(function (i) {
        $(this).mouseover(function () {
            $("#divProvinceRegion table tr td a").removeAttr("style");
            $("#divProvinceRegion table tr td").removeAttr("style");
            $(this).find("a").css({ color: "#FFF" });
            $(this).css({ background: "#ffbf69" });
        })
    });
    //地区鼠标点击事件
    $("#divProvinceRegion table tr td").each(function (i) {
        $(this).click(function () {
            //所选地区
            $("#ahrefregionname").html($(this).find("a").html()); //改变所选地区
            $("#divProvinceRegion").hide();
            //没有启用模板或者为空的时候
            if (feetemplateId == "" || feetemplateId == "0") {
                return;
            }
            $("#spanFee").html("<span style='color:red;font-size:12px;'>读取中...</span>"); //物流费用等待中显示的信息
            provCode = $(this).find("a").attr("code");
            params = { "code": provCode, "yz": "shopnum1ntbl", "path": shoppath, "feetemplateid": feetemplateId, "type": "fee" };
            $.getJSON("/Main/Api/shopfeetemplate.ashx", params, function (json) {

                if (json != null) {
                    var spanCon = "";
                    var spanfeetemp1 = "";
                    var spanfeetemp2 = "";
                    var spanfeetemp3 = "";
                    for (var j = 0; j < json.length; j++) {
                        //平邮
                        if (json[j].feetype == 1) {
                            spanfeetemp1 = "<span style='font-size:12px;'> 平邮 </span>" + "<span> " + json[j].fee + " </span>";
                        }
                        //快递
                        else if (json[j].feetype == 2) {
                            spanfeetemp2 = "<span style='font-size:12px;'> 快递 </span>" + "<span> " + json[j].fee + " </span>";
                        }
                        //ems
                        else if (json[j].feetype == 3) {
                            spanfeetemp3 = "<span style='font-size:12px;'> EMS </span>" + "<span> " + json[j].fee + " </span>";
                        }
                    }
                    spanCon = spanfeetemp1 + spanfeetemp2 + spanfeetemp3;
                    if (spanCon != "") {
                        $("#spanFee").html(spanCon);
                    }
                    else {
                        $("#spanFee").html(spanallfee);
                    }
                }
                else {
                    $("#spanFee").html(spanallfee);
                }
            });
        })
    });

    //全国默认物流
    spanallfee = "";
    var feetemplateId = $("#shopFeeTemplateHidden").val(); //物流模板id
    var havefeetemplate = false;
    //根据地区读取 对应的邮费
    if (feetemplateId != "0" && feetemplateId != "") {
        $("#spanFee").html("<span style='color:red;font-size:12px;'>读取中...</span>"); //物流费用等待中显示的信息
    }
    var shoppath = '<%=ShopUrlOperate.GetShopPath() %>'; //店铺路径
    var ycity = '<%=ShopUrlOperate.GetUserCity() %>';
    var vcity1 = $.trim(ycity).substring(0, 2);
    $("#divProvinceRegion table tr td a").each(function (i) {
        if ($.trim($(this).html()).substring(0, 2) == vcity1) {
            $("#ahrefregionname").html($(this).html()); //设置当前地区
            //店铺模板为空的时候 
            if (feetemplateId == "" || feetemplateId == "0") {
                return;
            }
            ///开始计算当前地区的邮费
            var provCode = $(this).attr("code");  //地区code
            params = { "code": provCode, "yz": "shopnum1ntbl", "path": shoppath, "feetemplateid": feetemplateId, "type": "fee" };
            $.getJSON("/Main/Api/shopfeetemplate.ashx", params, function (json) {

                $("#spanFee").html(spanallfee); //当前物流费用
                if (json != null) {

                    var spanCon = "";
                    var spanfeetemp1 = "";
                    var spanfeetemp2 = "";
                    var spanfeetemp3 = "";
                    for (var j = 0; j < json.length; j++) {
                        //平邮
                        if (json[j].feetype == 1) {
                            spanfeetemp1 = "<span style='font-size:12px;'> 平邮 </span>" + "<span> " + json[j].fee + " </span>";
                        }
                        //快递
                        else if (json[j].feetype == 2) {
                            spanfeetemp2 = "<span style='font-size:12px;'> 快递 </span>" + "<span> " + json[j].fee + " </span>";
                        }
                        //ems
                        else if (json[j].feetype == 3) {
                            spanfeetemp3 = "<span style='font-size:12px;'> EMS </span>" + "<span> " + json[j].fee + " </span>";
                        }
                    }
                    spanCon = spanfeetemp1 + spanfeetemp2 + spanfeetemp3;
                    if (spanCon != "") {
                        $("#spanFee").html(spanCon);
                        havefeetemplate = true;
                    }
                }
            });
            return;
        }

    });
    //如果当前地区没有物流费用就取全国的物流
    if (!havefeetemplate) {
        if (feetemplateId == "" || feetemplateId == "0") { return; }
        else {
            ///取全国物流
            params = { "code": "000", "yz": "shopnum1ntbl", "path": shoppath, "feetemplateid": feetemplateId, "type": "fee" };
            $.getJSON("/Main/Api/shopfeetemplate.ashx", params, function (json) {


                if (json != null) {

                    var spanCon = "";
                    var spanfeetemp1 = "";
                    var spanfeetemp2 = "";
                    var spanfeetemp3 = "";
                    for (var j = 0; j < json.length; j++) {
                        //平邮
                        if (json[j].feetype == 1) {
                            spanfeetemp1 = "<span style='font-size:12px;'> 平邮 </span>" + "<span> " + json[j].fee + " </span>";
                        }
                        //快递
                        else if (json[j].feetype == 2) {
                            spanfeetemp2 = "<span style='font-size:12px;'> 快递 </span>" + "<span> " + json[j].fee + " </span>";
                        }
                        //ems
                        else if (json[j].feetype == 3) {
                            spanfeetemp3 = "<span style='font-size:12px;'> EMS </span>" + "<span> " + json[j].fee + " </span>";
                        }
                    }
                    spanCon = spanfeetemp1 + spanfeetemp2 + spanfeetemp3;
                    if (spanCon != "") {
                        $("#spanFee").html(spanCon);
                        //全国默认物流
                        spanallfee = spanCon;

                    }
                }
            });
        }
    }
});
//配送显示隐藏		
function ShowHideRegion(hre) {
    if (hre == "hide") {
        $("#divProvinceRegion").hide();
    }
    else {
        $("#divProvinceRegion").show();
    }
}
//////////////////////邮费相关////////////////////////////////////////////////
//收藏排行切换
function tab(selfid, targetid, index, count, selfclass, otherclass) {
    for (var i = 0; i < count; i++) {
        if (i == index) {
            document.getElementById(selfid + i).className = selfclass;
            document.getElementById(targetid + i).style.display = "block";
        }
        else {
            document.getElementById(selfid + i).className = otherclass;
            document.getElementById(targetid + i).style.display = "none";
        }
    }
}

//控制商品详细页面选项卡切换
function changeTab(count, index) {
    for (var i = 1; i <= count; i++) {

        document.getElementById('content' + i).style.display = "none";
        document.getElementById("current" + i).className = "";
    }
    document.getElementById('content' + index).style.display = "block";
    document.getElementById('current' + index).className = "selected";
}
//百度地图和二维码切换
function changes(value) {
    if (value == "1") {
        $("#map1").show(); $("#dz1").addClass("current");
        $("#map2").hide(); $("#dz2").removeClass("current");
        var Longitude = $("#ShopInfo_ctl00_RepeaterShow_ctl00_HiddenFieldLongitude").val();
        var Latitude = $("#ShopInfo_ctl00_RepeaterShow_ctl00_HiddenFieldLatitude").val();
        var map = new BMap.Map("map1");
        map.centerAndZoom(new BMap.Point(Longitude, Latitude), 14);
        map.addControl(new BMap.NavigationControl());  //添加默认缩放平移控件
        map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_TOP_RIGHT, type: BMAP_NAVIGATION_CONTROL_SMALL }));  //右上角，仅包含平移和缩放按钮
        map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_LEFT, type: BMAP_NAVIGATION_CONTROL_PAN }));  //左下角，仅包含平移按钮
        map.addControl(new BMap.NavigationControl({ anchor: BMAP_ANCHOR_BOTTOM_RIGHT, type: BMAP_NAVIGATION_CONTROL_ZOOM }));  //右下角，仅包含缩放按钮
    }
    else {
        $("#map2").attr("style", "height:255px"); $("#map2").show();
        $("#dz2").addClass("current");
        $("#dz1").removeClass("current");
        $("#map1").attr("style", "");
    }
}


function resizepic(picObj) {
    var defineScreenWidth = 1024;
    var defineScreenSideWidth = 42;

    var picWidth = parseInt(picObj.width);
    var picHeight = parseInt(picObj.height);
    var screenWidth = parseInt(window.screen.width);
    var screenHeight = parseInt(window.screen.height);

    var screenSideWidth = Math.ceil(screenWidth / defineScreenWidth * defineScreenSideWidth);

    var percent = (screenWidth - 2 * screenSideWidth) / picWidth;
    var picWidthResult = Math.floor(picWidth * percent);
    var picHeightResult = Math.floor(picHeight * percent);

    if (picObj.width > picWidthResult) {
        picObj.width = picWidthResult;
        picObj.height = picHeightResult;
    }
}

//给firefox添加鼠标滚动事件
if (window.addEventListener) {
    window.addEventListener('DOMMouseScroll', wheel, false);
}