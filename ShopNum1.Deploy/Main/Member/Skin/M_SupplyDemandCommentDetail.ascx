<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_SupplyDemandCommentDetail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_SupplyDemandCommentDetail" %>
<%@ Import Namespace="System.Data" %>
<asp:Repeater ID="RepeaterShow" runat="server">
    <HeaderTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2" scope="col" width="130">
                    供求评论详细
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr style="display: none;">
            <td class="bordleft">
                评论标题：
            </td>
            <td class="bordrig">
                <%#Eval("Title")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                供求信息标题：
            </td>
            <td class="bordrig">
                <a href='<%# ShopUrlOperate.RetUrl("SupplyDemandDetail",((DataRowView)Container.DataItem).Row["SupplyDemandGuid"]) %>'
                    target="_blank">
                    <%#Eval("CommentTitle")%>
                </a>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                评论IP：
            </td>
            <td class="bordrig">
                <%#Eval("CreateIP")%>
            </td>
        </tr>
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
                审核状态：
            </td>
            <td class="bordrig">
                <%#ShopNum1.MemberWebControl.M_SupplyDemandComment.IsAudit(Eval("IsAudit").ToString())%>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;" width="130">
                评论内容：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <%#Eval("Content")%>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;" width="130">
                评论回复：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                <%#Eval("Reply")%>
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
