<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript">

    function funCheck() {
        var ShopMemLoginID = $("#<%= TextBoxShopMemLoginID.ClientID %>").val();
        if (ShopMemLoginID == "") {
            $("#errShopMemLoginID").html("会员ID不能为空！");
            $("#<%= HiddenFieldisShopUser.ClientID %>").val("0");
            return false;
        } else {
            $("#errShopMemLoginID").html("查询中，请稍后...");
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                async: false,
                data: "ShopMemLoginID=" + ShopMemLoginID + "&type=ShopLink",
                dataType: "html",
                success: function (ajaxData) {
                    if (ajaxData != "") {
                        if (ajaxData == "ok") {
                            $("#errShopMemLoginID").html("*");
                            $("#<%= HiddenFieldisShopUser.ClientID %>").val("1");
                            return true;
                        } else {
                            $("#errShopMemLoginID").html("会员ID不是店铺会员！");
                            $("#<%= HiddenFieldisShopUser.ClientID %>").val("0");
                            return false;
                        }
                    }
                }
            });
        }
    }

    function funCheckButton() {
        funCheck();
        if ($("#<%= HiddenFieldisShopUser.ClientID %>").val() == "1") {
            return true;
        }
        return false;
    }

</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ShopLink.aspx">友情链接</a><span
            class="breadcrume_icon">>></span><asp:Label ID="LabelTitle" runat="server" Text=""
                CssClass="breadcrume_text"></asp:Label></p>
    <div class="biaogenr">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2" scope="col">
                    友情链接
                </th>
            </tr>
            <tr>
                <td class="bordleft">
                    会员ID：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxShopMemLoginID" runat="server" CssClass="op_text" onblur="funCheck()"></asp:TextBox>
                    <span class="star" id="errShopMemLoginID">*</span>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    是否显示：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    备注：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxNote" runat="server" TextMode="MultiLine" CssClass="op_area"
                        onblur="funDescription()"></asp:TextBox>
                    <span class="star" id="errDescription"></span>
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
<asp:HiddenField ID="HiddenFieldisShopUser" runat="server" Value="0" />
