<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_VideoCommentDetail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_VideoCommentDetail" %>
<asp:Repeater ID="RepeaterShow" runat="server">
    <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2" scope="col" width="130">
                    平台视频评论详细
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td class="bordleft">
                评论时间：
            </td>
            <td class="bordrig">
                <%#Eval("CreateTime")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                平台视频：
            </td>
            <td class="bordrig">
                <%#Eval("VideoTitle")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                评论内容：
            </td>
            <td class="bordrig">
                <%#Eval("Content")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                审核状态：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <%#ShopNum1.MemberWebControl.M_SupplyDemandComment.IsAudit(Eval("IsAudit").ToString())%>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
<div style="text-align: center; margin: 20px 0px 50px 0px;">
    <asp:Button ID="ButtonGoBack" runat="server" Text="返回" CssClass="baocbtn" />&nbsp;&nbsp;
</div>
