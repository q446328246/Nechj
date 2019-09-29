/*shopnum1   jely 20130726优化封装的js*/
if (top.location != location) top.location.href = location.href;
//给卖家留言
function MessageboxChange(tobj) { $(tobj).next().val($(tobj).val()); }
function ChangeTextStyle(textobj, status) {
    if (status == "1") {
        textobj.style.color = "#808080";
        textobj.style.border = "#8ab6dd 1px solid";
        textobj.style.height = "20px";
        textobj.style.width = "400px";
        textobj.style.fontSize = "12px";
    }
    else {
        textobj.style.color = "#000";
        textobj.style.border = "#ffad33 1px solid";
        textobj.style.height = "45px";
        textobj.style.width = "400px";
        textobj.style.fontSize = "12px";
    }
}

//是否需要发票
function GetRadioInvoice(obj) {
    var radios = obj.getElementsByTagName("input");
    if (radios[0].checked) { $(obj).parent().next().show(); }
    else { $(obj).parent().next().hide(); $(obj).parent().next().find("textarea").val(""); }
}
/*<!--选择收货地址-->*/
$(function () {
    $(".contant").click(function () {
        $(this).attr("class", "contant conselect").siblings(".contant").attr("class", "contant"); // 选择特定元素的所有同级元素

        var temp = $(this).attr("value");
        $(hidGuID).val(temp.split('|')[0]);
        $(HiddenFieldAddressCode).val(temp.split('|')[1]);
        var shoppath;
        var ProductGuid = $("#ShoppingCart2_New_ctl00_RepeaterShopProduct_ctl00_HiddenFieldGuid").val();
        var feetemplateId = $(HiddenFieldFeeTemplateID).val();
        var mid = $(this).attr("lang");
        $.get("/Api/Main/ShopCart.ashx?mid=" + escape(mid) + "&guid=" + $(this).attr("value").split("|")[0] + "&sign=address", null, function (data) { });
        //立即购买 绑定邮费 2013-10-30 add by Victor  2013-11-11 Update by Jely
        if (ProductGuid != undefined && feetemplateId != "0" && feetemplateId != "") {
            params = { "code": temp.split('|')[1], "yz": "shopnum1ntbl", "path": shoppath, "feetemplateid": feetemplateId, "type": "GetFreeTemplate", "productguid": ProductGuid };
            $.getJSON("/Main/Api/shopfeetemplate.ashx", params, function (json) {
                if (json != null) {
                    /*$("#ShoppingCart2_New_ctl00_DropDownListPost").empty();

                    for (var j = 0; j < json.length; j++) {
                        //平邮
                        if (json[j].feetype == 1) {
                            $("<option value='" + json[j].fee + ":1" + "' lang='" + json[j].fee + "'>平邮" + json[j].fee + "元</option>").appendTo("#ShoppingCart2_New_ctl00_DropDownListPost");
                        }
                        //快递
                        else if (json[j].feetype == 2) {
                            $("<option value='" + json[j].fee + ":2" + "' lang='" + json[j].fee + "'>快递" + json[j].fee + "元</option>").appendTo("#ShoppingCart2_New_ctl00_DropDownListPost");
                        }
                        //ems
                        else if (json[j].feetype == 3) {
                            $("<option value='" + json[j].fee + ":3" + "' lang='" + json[j].fee + "'>EMS" + json[j].fee + "元</option>").appendTo("#ShoppingCart2_New_ctl00_DropDownListPost");
                        }
                        else {
                            $("<option value='0:-2'>免运费</option>").appendTo("#ShoppingCart2_New_ctl00_DropDownListPost");
                        }
                    }*/

                    //suanqian();
                } else {
                    //$("<option value='0:-2'>免运费</option>").appendTo("#ShoppingCart2_New_ctl00_DropDownListPost");
                }
                //$("#ShoppingCart2_New_ctl00_HiddenFieldDispatchPrice").val($("#ShoppingCart2_New_ctl00_DropDownListPost").find("option:selected").attr("lang"));
            });
        }

        //加入购物车 绑定邮费

            ProductGuid = $("#ShoppingCart2_New_ctl00_HiddenFieldMoreMemloginid").val();

            feetemplateId = $("#ShoppingCart2_New_ctl00_HiddenFieldFeeTemplateIDandNumber").val();


        if (feetemplateId != "0" && feetemplateId != "") {
            params = { "code": temp.split('|')[1], "yz": "shopnum1ntbl", "path": shoppath, "feetemplateid": feetemplateId, "type": "GetMoreFreeTemplate", "productguid": ProductGuid };
            $.getJSON("/Main/Api/shopfeetemplate.ashx", params, function (json) {
                if (json != null) {
                    /*$("#ShoppingCart2_New_ctl00_RepeaterShopCart2_ctl00_DropDownListPost").empty();

                    if (json[0].Post != 0) {
                        //平邮
                        $("<option value='" + json[0].Post + ":1" + "'>平邮" + json[0].Post + "元</option>").appendTo("#ShoppingCart2_New_ctl00_RepeaterShopCart2_ctl00_DropDownListPost");
                    }
                    if (json[0].Express != 0) {
                        //快递
                        $("<option value='" + json[0].Express + ":2" + "'>快递" + json[0].Express + "元</option>").appendTo("#ShoppingCart2_New_ctl00_RepeaterShopCart2_ctl00_DropDownListPost");
                    }
                    if (json[0].Ems != 0) {
                        //ems
                        $("<option value='" + json[0].Ems + ":3" + "'>EMS" + json[0].Ems + "元</option>").appendTo("#ShoppingCart2_New_ctl00_RepeaterShopCart2_ctl00_DropDownListPost");
                    }*/

                    suanqian();
                }
                else {
                    //$("<option value='0:-2'>免运费</option>").appendTo("#ShoppingCart2_New_ctl00_RepeaterShopCart2_ctl00_DropDownListPost");
                }
            });
        }

    });
    if ($("#ShoppingCart2_New_ctl00_DropDownListPost").find("option:selected").val() == undefined) {
        $("<option value='0:-2'>免运费</option>").appendTo("#ShoppingCart2_New_ctl00_DropDownListPost");
    }
    $("#ShoppingCart2_New_ctl00_DropDownListPost").change(function () {
        suanqian();
    });

    // 页面首次加载后 是否是默认收货地址 
    var divContant = $(".contant");
    var bflag = true;
    for (var i = 0; i < divContant.length; i++) {
        var IsDefault = $(divContant[i]).attr("IsDefault");
        if (IsDefault == "1") {
            $(divContant[i]).attr("class", "contant conselect"); bflag = false;
        }
    }
    if (bflag) {
        $(divContant[0]).attr("class", "contant conselect");
    }
});
/*<!--购买数量加减 计算费用-->*/
$(function () {
    //文本框值变化改变金额
    $(".or_input").change(function () {
        var danjia = parseFloat($(this).parent().prev().find("span").text());
        $(this).parent().next().find("span.labelAll").text((danjia * parseFloat($(this).val())).toFixed(2));

        var labelAll = $("span.labelAll");
        var NumlabelAll = 0;
        for (var i = 0; i < labelAll.length; i++) {
            NumlabelAll += parseFloat($(labelAll[i]).text());
        }
        $(this).parents("table.test").next().find(".yunright>b>span").text(NumlabelAll.toFixed(2));
        suanqian();
    });
    //加
    $(".ImgAdd").click
    (
        function () {
            var BuyNum = parseFloat($(this).prev().val()) + 1; //购买数量
            $(this).prev().val(BuyNum);

            //小计的计算
            var danjia = parseFloat($(this).parent().prev().find("span").text()); //单价
            var labelAll = $(this).parent().next().find("span"); //小计
            $(labelAll).text((danjia * BuyNum).toFixed(2));

            ////商品合计（含运费）
            var labelAll = $(this).parents("table.test").find("span.labelAll"); //所有小计控件
            var NumlabelAll = 0;
            for (var i = 0; i < labelAll.length; i++) {
                NumlabelAll += parseFloat($(labelAll[i]).text());
            }
            $(this).parents("table.test").next().find(".yunright>b>span").text(NumlabelAll.toFixed(2)); //商品合计（含运费）￥ 控件
            //算钱
            suanqian();
        }
    );
    //减
    $(".ImgDelete").click
        (
            function () {
                var intBuyNum = parseInt($(this).next().val()); //购买数量
                if (intBuyNum > 1) {
                    $(this).next().val(intBuyNum - 1)

                    //小计的计算
                    var BuyNum = parseFloat(intBuyNum - 1); //购买数量

                    var danjia = parseFloat($(this).parent().prev().find("span").text()); //单价
                    var labelAll = $(this).parent().next().find("span"); //小计
                    $(labelAll).text((danjia * BuyNum).toFixed(2));

                    ////商品合计（含运费）
                    var labelAll = $(this).parents("table.test").find("span.labelAll"); //所有小计控件
                    var NumlabelAll = 0;
                    for (var i = 0; i < labelAll.length; i++) {
                        NumlabelAll += parseFloat($(labelAll[i]).text());
                    }
                    $(this).parents("table.test").next().find(".yunright>b>span").text(NumlabelAll.toFixed(2)); //商品合计（含运费）

                    //算钱
                    suanqian();
                }
            }
        );
});


//算钱的方法<!--邮费变化时候算钱-->
function suanqian() {
    ////商品总价格（不含运费）
    var labelAll = $("span.labelAll"); //所有小计控件
    var NumlabelAll = 0;
    for (var i = 0; i < labelAll.length; i++) {
        if ($(labelAll[i]).text() != "") {
            NumlabelAll += parseFloat($(labelAll[i]).text());
        }
    }

    $(AllCount).text(NumlabelAll.toFixed(2)); //商品总价格
    //商品合计（含运费）
    var labelProtectHeji = $("span.labelProtectHeji"); //商品合计（含运费）
   
    //labelProtectHeji.text(NumlabelAll.toFixed(2));
    for (var n = 0; n < labelProtectHeji.length; n++) {
        var NumlabelAllForHeji = 0;
        var labelAllForHeji = $(labelProtectHeji[n]).parents("div.salemessage").prev("table.test").find(".labelAll");
        for (var j = 0; j < labelAllForHeji.length; j++) {
            NumlabelAllForHeji += parseFloat($(labelAllForHeji[j]).text());
        }

        //加上邮费
        var DropDownListPost = $(labelProtectHeji[n]).parents("div.salemessage").prev("table.test").find(".DropDownListPost"); //邮费控件
        NumlabelAllForHeji += parseFloat($(DropDownListPost).children("option:selected").val());
        $(labelProtectHeji[n]).text(NumlabelAllForHeji.toFixed(2));
    }

    //商品总价格下面的总邮费
    var labelAllPost = $(".DropDownListPost"); //所有小计控件
    var NumlabelAllPost = 0;
    for (var i = 0; i < labelAllPost.length; i++) {
        NumlabelAllPost += parseFloat($(labelAllPost[i]).children("option:selected").val());
    }
    $(LabelPost).text(NumlabelAllPost.toFixed(2));


    //支付费用
    var checked = $("#tablePayment").find(':input:radio:checked'); //单选按钮控件
    var LabelCharge = $(checked).parent().parent().find(".LabelCharge").text(); //支付费用或比例
    var HiddenFieldIsPersent = $(checked).parent().parent().children("td:eq(4)").children().val(); //是否是百分号 1是 0 否
    var NumLabelPaymentCharge = 0; //支付费用 用于计算
    if (HiddenFieldIsPersent == "0") {
        NumLabelPaymentCharge = parseFloat(LabelCharge);
        $(LabelPaymentCharge).text("0.00");
    }

    if (HiddenFieldIsPersent == "1") {
        NumLabelPaymentCharge = (NumlabelAll + NumlabelAllPost) * parseFloat(LabelCharge) / 100;
        $(LabelPaymentCharge).text("0.00");
    }
    //总金额
    $(LabelShouldPrice).text((NumlabelAll + NumlabelAllPost).toFixed(2));
    $("#ShoppingCart2_New_ctl00_HiddenFieldPaymentPriceValue").val("0.00");
    $(LabelAllCartPrice).text($(LabelShouldPrice).text());
    $(HiddenFieldAllCartPrice).val($(LabelShouldPrice).text());

}
/*<!--页面加载时候算钱 --改变支付方式时候算钱-->*/
$(function () {
    suanqian(); //页面加载时候算钱
    $("input[name='RadioButtonPayment']").change(function () { //改变支付方式时候算钱
        suanqian();
    });
});

function NumTxt_Int(o) {
    o.value = o.value.replace(/\D/g, '');
}

/*    <!--收货人信息-->*/

$(function () {
    if ($(".contant").text() != "") { $(".contable").hide(); }
    if ($(".contable").is(':visible')) { $("#butReceiveAddress").next().show(); }
    $("#butReceiveAddress").click(function () {
        if ($(this).val() == "隐藏新地址") { $(this).val("使用新地址"); $(".contable").hide(); $(this).next().hide(); } else { $(this).val("隐藏新地址"); $(".contable").show(); $(this).next().show(); }
    });
});
function checkSub() {
    suanqian();
    if ($(".contable").is(':visible')) {
        if ($("#tablePayment tr").size() == 1) {
            alert("支付方式必须选择！"); return false;
        }
        return checkInput();
    }
    if ($("#tablePayment tr").size() == 1) {
        alert("支付方式必须选择！"); return false;
    }
    return true;
}
function checkInput() {
    $("#errormsg").hide();
    var txtpostcode = $(TextBoxPostalcode).val();
    var txtaddress = $(TextBoxAddress).val();
    var txtemail = $(TextBoxEmail).val();
    var txtmobile = $(TextBoxMobile).val();
    var txttel = $(TextBoxTel).val();
    var Regex_Email = /^(?:\w+\.?)*\w+@(?:\w+\.)*\w+$/;
    var Regex_Mobile = /^([0-9]{11})?$/;
    var Regex_Tel = /(\(\d{3,4}\)|\d{3,4}-|\s)?\d{8}/;
    var txtname = $(TextBoxName).val();
    var info = $("#localshow").getLocation();
    if (info.pcode == "0") {
        $("#errormsg").show().text("请选择省市！");
        $("#localshow").find("select[name='province']").focus().click(); return false;
    }

    if (info.ccode == "0" && $("#localshow").find("select[name='city'] option").size() != 1) {
        $("#errormsg").show().text("请选择城市！");
        $("#localshow").find("select[name='city']").focus().click(); return false;
    }

    if (info.dcode == "0" && $("#localshow").find("select[name='district'] option").size() != 1) {
        $("#errormsg").show().text("请选择区域！");
        $("#localshow").find("select[name='district']").focus().click(); return false;
    }
    if (info.dcode != 0) { $(HiddenFieldAddressCode).val(info.dcode); }
    else if (info.ccode != 0) { $(HiddenFieldAddressCode).val(info.ccode); }
    else if (info.pcode != 0) { $(HiddenFieldAddressCode).val(info.pcode); }
    $(HiddenFieldAddressName).val(info.province + "," + info.city + "," + info.district);
    //            if(txtpostcode==""){$("#errormsg").text("邮政编码不能为空！");$(TextBoxPostalcode).focus();  return false;}
    //if(txtpostcode.length!=6){$("#errormsg").text("邮政编码格式不对！");$(TextBoxPostalcode).focus();return false;}
    if (!Regex_Tel.test(txttel) && txttel != "") { $("#errormsg").show().text("电话格式不对！"); $(TextBoxTel).focus(); return false; }
    if (txtaddress == "") { $("#errormsg").show().text("收货地址不能为空！"); $(TextBoxAddress).focus(); return false; }
    else if (txtname == "") {
        $("#errormsg").show().text("收货人姓名不能为空！"); $(TextBoxName).focus(); return false;
    }
    else if (txtmobile == "") { $("#errormsg").show().text("手机号码不能为空！"); $(TextBoxMobile).focus(); return false; }
    else if (!Regex_Mobile.test(txtmobile)) { $("#errormsg").show().text("手机号码格式不正确！"); $(TextBoxMobile).focus(); return false; }
    else {
        return true;
    }
}
//        function clearInput()
//        {
//           $(TextBoxPostalcode).val("");$(TextBoxAddress).val("");$(TextBoxEmail).val("");$(TextBoxMobile).val("");$(TextBoxName).val("");
//        }
//        
//商品价格格式化方法
function number_format(num, ext) {
    if (ext < 0) { return num; }
    num = Number(num);
    if (isNaN(num)) { num = 0; }
    var _str = num.toString();
    var _arr = _str.split('.');
    var _int = _arr[0];
    var _flt = _arr[1];
    if (_str.indexOf('.') == -1) {
        /* 找不到小数点，则添加 */
        if (ext == 0) { return _str; }
        var _tmp = '';
        for (var i = 0; i < ext; i++) { _tmp += '0'; }
        _str = _str + '.' + _tmp;
    } else {
        if (_flt.length == ext) { return _str; }
        /* 找得到小数点，则截取 */
        if (_flt.length > ext) {
            _str = _str.substr(0, _str.length - (_flt.length - ext));
            if (ext == 0) { _str = _int; }
        } else {
            for (var i = 0; i < ext - _flt.length; i++) {
                _str += '0';
            }
        }
    }
    return _str;
}