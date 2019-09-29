<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
        <tr>
            <th colspan="2">
                咨询详细
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                留言人：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeMemLoginID" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言类型：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeType" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言标题：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeTitle" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言时间：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeSendTime" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言回复时间：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeReplyTime" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                是否回复：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeIsReply" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr style="display: none">
            <td class="bordleft">
                是否显示：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeIsShow" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言内容：
            </td>
            <td class="bordrig">
                <asp:Localize ID="LocalizeContent" runat="server"></asp:Localize>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: 1px solid #C6DFFF;">
                回复内容：
            </td>
            <td class="bordrig" style="border-bottom: 1px solid #C6DFFF;">
                <asp:TextBox ID="TextBoxReplyContent" runat="server" CssClass="op_area" TextMode="MultiLine"
                    MaxLength="200"></asp:TextBox>
                <span id="sapnContent" runat="server"></span>
                <%--这里需要验证回复的内容是否为空，或者，是否超出了限制200--%>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="btn_OK" runat="server" Text="确定" CssClass="querbtn" OnClientClick=" return funContent() " />
        <asp:Button ID="btn_Back" runat="server" Text="返回列表" CssClass="querbtn" />
    </div>
</div>
<script type="text/javascript" language="javascript">
    function funContent() {
        var Content = $("#S_MessageBoardReply_ctl00_TextBoxReplyContent").val();
        if (Content == "" || Content == null) {
            $("#<%= sapnContent.ClientID %>").html("留言内容不能为空！");
            return false;
        }
        $("#<%= sapnContent.ClientID %>").html("*");
        return true;
    }
</script>
