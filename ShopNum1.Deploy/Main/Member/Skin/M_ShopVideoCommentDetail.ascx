<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_ShopVideoCommentDetail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ShopVideoCommentDetail" %>
<asp:Repeater ID="RepeaterShow" runat="server">
    <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2" scope="col" width="130">
                    店铺视频评论详细
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="bordleft">
                店铺视频：
            </td>
            <td class="bordrig">
                <%#Eval("VideoTitle")%>
            </td>
        </tr>
        <tr style="display: none">
            <td class="bordleft">
                评价类型：
            </td>
            <td class="bordrig">
                <%#ShopNum1.MemberWebControl.M_ShopVideoComment.PJ(Eval("CommentType").ToString())%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                店铺名称：
            </td>
            <td class="bordrig">
                <%#ShopNum1.MemberWebControl.M_ShopVideoComment.shopname(Eval("ShopID").ToString())%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                评论IP：
            </td>
            <td class="bordrig">
                <%#Eval("IPAddress")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                评论时间：
            </td>
            <td class="bordrig">
                <%#Eval("CommentTime")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft" width="160">
                评论内容：
            </td>
            <td class="bordrig">
                <%#Eval("Comment")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                审核状态：
            </td>
            <td class="bordrig">
                <%#ShopNum1.MemberWebControl.M_SupplyDemandComment.IsAudit(Eval("IsAudit").ToString())%>
            </td>
        </tr>
        <tr style="display: none">
            <td class="bordleft">
                是否回复：
            </td>
            <td class="bordrig">
                <%#Eval("IsReply").ToString() == "1" ? "是" : "否"%>
            </td>
        </tr>
        <tr style="display: none">
            <td class="bordleft">
                回复内容：
            </td>
            <td class="bordrig">
                <%#Eval("Reply")%>
            </td>
        </tr>
        <tr style="display: none">
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                回复时间：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <%#Eval("ReplyTime")%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<div style="text-align: center; margin: 20px 0px 50px 0px;">
    <asp:Button ID="ButtonGoBack" runat="server" Text="返回" CssClass="baocbtn" OnClick="ButtonGoBack_Click" />&nbsp;&nbsp;
</div>
