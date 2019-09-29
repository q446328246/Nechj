<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    //优惠活动名称
    function funSaleTitle() {
        var SaleTitle = $("#<%= TextBoxSaleTitle.ClientID %>").val();
        if (SaleTitle == "") {
            $("#errSaleTitle").html("优惠活动名称不能为空！");
            return false;
        }
        $("#errSaleTitle").html("*");
        return true;
    }

    //优惠券名称
    function funCouponName() {
        $("#errLocal").text("*");
        var CouponName = $("#<%= TextBoxCouponName.ClientID %>").val();
        if (CouponName == "") {
            $("#errCouponName").html("优惠券名称不能为空！");
            return false;
        }
        $("#errCouponName").html("*");
        return true;
    }

    //优惠券类型
    function funType() {
        var Type = $("#<%= DropDownListType.ClientID %>").val();
        if (Type == "-1") {
            $("#errType").html("优惠券类型必须选择一项！");
            return false;
        }
        $("#errType").html("*");
        return true;
    }

    function getDate(strDate) {
        var date = eval('new Date(' + strDate.replace(/\d+(?=-[^-]+$)/,
            function (a) { return parseInt(a, 10) - 1; }).match(/\d+/g) + ')');
        return date;
    }

    //使用开始时间

    function funStartTime() {
        var StartTime = $("#<%= TextBoxStartTime.ClientID %>").val();
        if (StartTime == "") {
            $("#errStartTime").html("使用开始时间不能为空！");
            return false;
        } else {
            var date = new Date();
            var ms = date.valueOf() - getDate(StartTime).valueOf();
            if (ms > 0) {
                $("#errStartTime").html("使用开始时间不能小于当前时间！");
                return false;
            } else {
                $("#errStartTime").html("*");
                return true;
            }
        }

    }

    //使用结束时间
    function funEndTime() {
        var EndTime = $("#<%= TextBoxEndTime.ClientID %>").val();
        var StartTime = $("#<%= TextBoxStartTime.ClientID %>").val();
        if (EndTime == "") {
            $("#errEndTime").html("使用结束时间不能为空！");
            return false;
        } else {
            var date = new Date();
            var ms = getDate(EndTime).valueOf() - getDate(StartTime).valueOf();
            if (ms <= 0) {
                $("#errEndTime").html("使用结束时间不能小于使用开始时间！");
                return false;
            } else {
                $("#errEndTime").html("*");
                return true;
            }
        }
    }

    //限制上传图片
    function funCheckImage() {
        var image = $("#S_ShopCouponEdit_ctl00_FileUploadImgPath").val();
        if ($("#<%= hid_Image.ClientID %>").val() == "") {
            if (image == "") {
                $("#errImgPath").html("优惠券图片必须选择！");
                return false;
            } else {
                $("#errImgPath").html("*");
                return true;
            }
        }

        $("#errImgPath").html("*");
        return true;
    }


    //内容
    function funContent() {
        var Type = $("#<%= TexteditorContent.ClientID %>").html();
        if (Type == "") {
            $("#errContent").html("使用结束时间不能为空！");
            return false;
        }
        $("#errContent").html("*");
        return true;
    }

    function funCheckArea() {
        var code = "";
        var info = $("#p_local").getLocation();
        if (info.pcode == "0") {
            $("#errLocal").focus().text("*请选择省市！");
            return false;
        }
        if (info.dcode != "0") {
            code = info.dcode;
        } else {
            if (info.ccode != "0") {
                code = info.ccode;
            } else {
                code = info.pcode;
            }
        }
        if (code.length == 3 && $("select[name='city']").find("option").size() != 1) {
            $("#errLocal").focus().text("*请填写城市信息");
            return false;
        }
        if (code.length == 6 && $("select[name='district']").find("option").size() != 1) {
            $("#errLocal").focus().text("*请填写区域信息");
            return false;
        }
        return true;
    }

    function funCheckButton() {
        checkSumbit();
        if (funSaleTitle() && funCheckArea() && funCouponName() && funType() && funStartTime() && funEndTime() && funCheckImage()) {
            return true;
        }
        return false;
    }

</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a>我是卖家</a> >> <a>营销管理</a> >> <a href="S_ShopCoupon.aspx">优惠券管理</a> >>
        <asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label>
    </p>
    <div class="biaogenr">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
            <tr>
                <th colspan="2">
                    优惠券管理
                </th>
            </tr>
            <tr>
                <td class="bordleft">
                    优惠活动名称：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxSaleTitle" runat="server" MaxLength="200" CssClass="op_text"
                        onblur="funSaleTitle()"></asp:TextBox>
                    <span class="red" id="errSaleTitle">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    优惠券名称：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxCouponName" runat="server" MaxLength="100" CssClass="op_text"
                        onblur="funCouponName()"></asp:TextBox>
                    <span class="red" id="errCouponName">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    优惠券类型：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:DropDownList ID="DropDownListType" runat="server" onchange="funType()" CssClass="op_select">
                    </asp:DropDownList>
                    <span class="red" id="errType">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    所在地区：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <table>
                        <tr>
                            <td>
                                <div id="p_local">
                                </div>
                            </td>
                            <td>
                                <span class="red" id="errLocal">*</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    是否前台显示：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    使用开始时间：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxStartTime" runat="server" CssClass="ss_nrduan1" onchange="funStartTime()"
                        onclick="WdatePicker()" Style="width: 170px;" onblur="funStartTime()"></asp:TextBox>
                    <span class="red" id="errStartTime">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    使用结束时间：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxEndTime" runat="server" CssClass="ss_nrduan1" onclick="WdatePicker()"
                        Style="width: 170px;" onchange="funEndTime()" onblur="funEndTime()"></asp:TextBox>
                    <span class="red" id="errEndTime">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    优惠券图片：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:FileUpload ID="FileUploadImgPath" runat="server" onchange="funCheckImage()" />
                    <span class="red" id="errImgPath">*</span>
                </td>
            </tr>
            <asp:Panel ID="PanelShowImage" runat="server" Visible="false">
                <tr>
                    <td class="bordleft">
                        图片预览：
                    </td>
                    <td class="bordrig" style="padding-right: 20px;">
                        <asp:Image ID="InputImgPath" runat="server" Width="200" Height="200" />
                    </td>
                </tr>
            </asp:Panel>
            <tr>
                <td class="bordleft" style="border-bottom: 1px solid #C6DFFF;">
                    内容：
                </td>
                <td class="bordrig" style="border-bottom: 1px solid #C6DFFF; padding-top: 8px;">
                    <asp:TextBox ID="TexteditorContent" runat="server" CssClass="Texteditor" onblur="funContent()"></asp:TextBox>
                    <span class="red" id="errContent" style="display: none">*</span>
                </td>
            </tr>
        </table>
        <div class="op_btn">
            <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
            <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
<input id="hid_Area" type="hidden" runat="server" value="" />
<input id="hid_AreaCode" type="hidden" runat="server" value="" />
<input id="hid_Image" type="hidden" runat="server" value="" />