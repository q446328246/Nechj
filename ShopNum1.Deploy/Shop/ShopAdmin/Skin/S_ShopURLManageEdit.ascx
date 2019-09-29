<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="../js/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script>
    function funCheckDoMain() {
        var DoMain = $("#S_ShopURLManageEdit_ctl00_TextBoxDoMain").val();
        if (DoMain == "") {
            $("#errDoMain").html("域名不能为空！");
            return false;
        } else {
            //检查域名单一性
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx",
                async: true,
                data: "type=Shopurl&Shopurl=" + DoMain,
                dataType: "html",
                success: function (ajaxData) {
                    if (ajaxData != "") {
                        if (ajaxData == "false") {
                            $("#errDoMain").html("");
                            $("#<%= HiddenFieldShopurl.ClientID %>").val("ok");
                            return true;
                        } else if (ajaxData == "true") {
                            $("#errDoMain").html("域名已存在！");
                            $("#<%= HiddenFieldShopurl.ClientID %>").val("no");
                            return false;
                        }
                    }
                }
            });

            $("#errDoMain").html("*");
            return true;
        }
    }

    function funCheckButton() {
        funCheckDoMain();
        if ($("#<%= HiddenFieldShopurl.ClientID %>").val() == "ok") {
            return true;
        } else {
            return false;
        }
    }

</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="S_ShopURLManage.aspx">店铺域名</a><span
            class="breadcrume_icon">>></span><asp:Label ID="LabelTitle" runat="server" Text=""
                CssClass="breadcrume_text"></asp:Label>
    </p>
    <div class="biaogenr">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
            <tr>
                <th colspan="2" scope="col">
                    店铺域名
                </th>
            </tr>
            <tr>
                <td class="bordleft">
                    域名：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:TextBox ID="TextBoxDoMain" runat="server" CssClass="textwb" onblur="funCheckDoMain()"></asp:TextBox>
                    <asp:Label ID="LabelDomain" runat="server" Text=""></asp:Label><span class="star"
                        id="errDoMain">*</span>
                    <div style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0 0 8px 0;">
                        店铺为二级域名，只需填写二级域名头部即可！</div>
                </td>
            </tr>
        </table>
        <div class="op_btn">
            <asp:Button ID="ButtonSubmit" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
            <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldID" runat="server" />
<asp:HiddenField ID="HiddenFieldShopurl" runat="server" />
