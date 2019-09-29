<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="js/CommonJS.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"> </script>
<script type='text/javascript' src='js/resolution-test.js'> </script>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<link rel='stylesheet' type='text/css' href='style/s.css' />
<link rel='stylesheet' type='text/css' href='style/dshow.css' />
<script type="text/javascript">
    function funClose() {
        $("#sp_dialog_contDiv").css("display", "none");
        $("#sp_dialog_outDiv").css("display", "none");
        $("#sp_overlayDiv").css("display", "none");
    }

    function funOpen() {
        $("#sp_dialog_contDiv").css("display", "block");
        $("#sp_dialog_outDiv").css("display", "block");
        $("#sp_overlayDiv").css("display", "block");
    }

    $(function () {
        $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode1").change(function () {
            var fenlei = $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode1").val();
            if (fenlei != "-1") {
                var fenleiID = fenlei.split('/')[0];
                $.ajax({
                    type: "get",
                    url: "/api/ZtcProduct.ashx",
                    async: false,
                    data: "FatherID=" + fenleiID + "&type=fenlei",
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData != "") {
                            $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").html(ajaxData);
                            $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val(fenlei);
                            if ($("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").val() == "-1") {
                                $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").html("<option value=\"-1\">-请选择-</option>");
                            }
                        } else {
                            $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").html("<option value=\"-1\">-请选择-</option>");
                            $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").html("<option value=\"-1\">-请选择-</option>");
                            $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val("0");
                        }
                    }
                });
            } else {
                $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").html("<option value=\"-1\">-请选择-</option>");
                $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").html("<option value=\"-1\">-请选择-</option>");
                $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val("0");
            }
        }); //求三级分类
        $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").change(function () {
            var fenlei = $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").val();
            if (fenlei != "-1") {
                var fenleiID = fenlei.split('/')[0];
                $.ajax({
                    type: "get",
                    url: "/api/ZtcProduct.ashx",
                    async: false,
                    data: "FatherID=" + fenleiID + "&type=fenlei",
                    dataType: "html",
                    success: function (ajaxData) {
                        if (ajaxData != "") {
                            $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").html(ajaxData);
                            $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val(fenlei);
                        } else {
                            $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").html("<option value=\"-1\">-请选择-</option>");
                            $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val($("#S_ZtcApply_ctl00_DropDownListProductSeriesCode1").val());
                        }
                    }
                });
            } else {
                $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").html("<option value=\"-1\">-请选择-</option>");
                $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val($("#S_ZtcApply_ctl00_DropDownListProductSeriesCode1").val());
            }
        });
        $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").change(function () {
            var fenlei = $("#S_ZtcApply_ctl00_DropDownListProductSeriesCode3").val();
            if (fenlei != "-1") {
                $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val(fenlei);
            } else {
                $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val($("#S_ZtcApply_ctl00_DropDownListProductSeriesCode2").val());
            }


        });
    });


    //搜索

    function funGetData() {
        var textName = $("#S_ZtcApply_ctl00_TextBoxNumber").val(); //商品名称
        var code = $("#S_ZtcApply_Edit_ctl00_HiddenFieldCode").val(); //店铺分类id
        $("#showLoading").css("display", "block");
        $.ajax({
            type: "get",
            url: "/api/ZtcProduct.ashx",
            async: false,
            data: "code=" + code + "&type=product&textName=" + textName,
            dataType: "html",
            success: function (ajaxData) {
                $("#selectproduct").html("");
                if (ajaxData != "") {
                    var data = eval('(' + ajaxData + ')');
                    var xhtml = new Array();
                    $.each(data, function (m, n) {
                        xhtml.push("<option value='" + n.guid + "'>" + n.name + "</option>");
                    });
                    $("#selectproduct").append(xhtml.join(""));
                    $("#showLoading").css("display", "none");
                } else {
                    alert("没有合适的商品！");
                    $("#showLoading").css("display", "none");
                }
            }
        });
    }

    function funSelectClick() {
        //选中
        var productguid = $("#selectproduct").val(); //var v=productguid.split(',').length;
        //alert(productguid);
        if (productguid != null) {
            $("#S_ZtcApply_Edit_ctl00_HiddenFieldSelectPrpductName").val($("#selectproduct option:selected").text());
            $("#S_ZtcApply_Edit_ctl00_HiddenFieldSelectPrpductGuid").val(productguid);
            $("#S_ZtcApply_Edit_ctl00_TextBoxProductName").val($("#selectproduct option:selected").text());
            funClose();
            funGetProductImage();
        } else {
            alert("没有选中一项！");
        }

    }

    function funGetProductImage() {
        var guid = $("#S_ZtcApply_Edit_ctl00_HiddenFieldSelectPrpductGuid").val();
        $.ajax({
            type: "get",
            url: "/api/ZtcProduct.ashx",
            async: false,
            data: "productGuid=" + guid + "&type=productImage",
            dataType: "html",
            success: function (ajaxData) {
                if (ajaxData.indexOf("~") != -1) {
                    $("#ImageProduct").attr("src", ajaxData.substr(1));
                } else {
                    $("#ImageProduct").attr("src", ajaxData);
                }
            }
        });
    }

    function funGetOrderMoney() {
        var money = $("#S_ZtcApply_Edit_ctl00_HiddenFieldMoney").val();
        var textMoney = $("#S_ZtcApply_Edit_ctl00_TextBoxMoney").val();
        if (textMoney != "" && textMoney != "0") {
            if (parseFloat(textMoney) < parseFloat(money)) {
                $.ajax({
                    type: "get",
                    url: "/api/ZtcProduct.ashx",
                    async: false,
                    data: "Money=" + textMoney + "&type=Money",
                    dataType: "html",
                    success: function (ajaxData) {
                        //                    alert(ajaxData);
                        $("#S_ZtcApply_Edit_ctl00_LabelMoney").html("当前排名:第" + ajaxData + "位");
                        $("#S_ZtcApply_Edit_ctl00_HiddenFieldIsRight").val("1");
                    }
                });
            } else {
                alert("金币（BV）不足");
                $("#S_ZtcApply_Edit_ctl00_TextBoxMoney").val(money);
            }

        } else {
            alert("消耗金币（BV）不能为空");
        }
    }

    $(function () {
        $("#S_ZtcApply_Edit_ctl00_TextBoxMoney").keyup(function () {
            funGetOrderMoney();
        });
    });

    function funCheck() {
        var WxPay = $("#S_ZtcApply_Edit_ctl00_hidWxPay").val();
        var WxMoney = $("#S_ZtcApply_Edit_ctl00_TextBoxMoney").val();
        if (parseFloat(WxMoney) < parseFloat(WxPay)) {
            alert("消耗金币（BV）不能小于" + parseFloat(WxPay) + "元");
            return false;
        }
        funGetOrderMoney();
        var guid = $("#S_ZtcApply_Edit_ctl00_HiddenFieldSelectPrpductGuid").val();
        if (guid != "0") {
            if ($("#S_ZtcApply_Edit_ctl00_HiddenFieldIsRight").val() == "1") {
                if ($("#S_ZtcApply_Edit_ctl00_TextBoxStartTime").val() == "") {
                    alert("请填写开始时间！");
                    return false;
                } else {
                    return true;
                }
            } else {
                return false;
            }

        } else {
            alert("请选择商品！");
        }
        return false;
    }

</script>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2">
                直通车申请
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                选择商品：
            </td>
            <td class="bordrig">
                <ShopNum1:TextBox ID="TextBoxProductName" CanBeNull="必填" MaxLength="100" runat="server"
                    Width="390" CssClass="textwb" Text="-请选择商品-" Enabled="false" />
                <input type="button" value="选择商品" class="sqjdbzj" onclick=" funOpen() " />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                商品图片：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <img id="ImageProduct" width="200" height="200" src="" onerror=" javascript:this.src = '/ImgUpload/noImage.gif'; " />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                消耗金币（BV）：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <ShopNum1:TextBox ID="TextBoxMoney" CanBeNull="必填" MaxLength="20" runat="server"
                    RequiredFieldType="金额" CssClass="op_text" Width="66" Text="0.00" />元
                <div class="gray">
                    <asp:Label ID="LabelMoney" runat="server" Text="当前拥有金币（BV）"></asp:Label>
                </div>
                <input type="hidden" id="hidWxPay" runat="server" />
                <asp:HiddenField ID="HiddenFieldMoney" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                开始时间：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <ShopNum1:TextBox ID="TextBoxStartTime" CanBeNull="必填" runat="server" onclick="WdatePicker()"
                    class="op_text" Width="160" />
                <div class="gray">
                    (请注意：系统在审核后开始时间才会生效，如果审核时间大于开始时间，那么开始时间以审核时间为准！)</div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                备注：
            </td>
            <td class="bordrig">
                <asp:TextBox ID="TextBoxRemark" runat="server" Height="69px" TextMode="MultiLine"
                    Width="500" CssClass="op_area"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonConfirm" runat="server" Text="提交" CssClass="baocbtn" OnClientClick=" return funCheck() " />
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" ValidationGroup="fh" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldCode" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldSelectPrpductGuid" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldIsRight" runat="server" Value="0" />
<asp:HiddenField ID="HiddenFieldSelectPrpductName" runat="server" Value="0" />
