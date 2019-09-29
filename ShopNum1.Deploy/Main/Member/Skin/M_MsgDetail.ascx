<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MsgDetail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MsgDetail" %>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href='M_Msg.aspx?isread=<%=Request.QueryString["isread"]%>&pageid=<%=Request.QueryString["pageid"] %>'>会员消息</a><span
            class="breadcrume_icon">>></span><span class="breadcrume_text">会员消息详细</span></p>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblTitle" runat="server" Style="color: #005ea7; font-size: 16px; font-weight: bold;"></asp:Label>
            </td>
        </tr>
        <tr>
            <th colspan="2" scope="col" style="background: #e5e4e4; height: 24px; line-height: 24px;
                border: 1px solid #dddddd; text-align: center;">
                <span>发信人：<asp:Label ID="lblSendUser" runat="server"></asp:Label></span> <span>收信人：<asp:Label
                    ID="lblReceiveUser" runat="server"></asp:Label></span> <span>时间：<asp:Label ID="lblDate"
                        runat="server"></asp:Label></span>
            </th>
        </tr>
        <tr>
            <td>
            </td>
            <td style="text-align: left;">
                <asp:Literal ID="LitContent" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    <div style="margin: 20px 10px 20px 10px; line-height: 20px;">
        <a href='M_Msg.aspx?isread=<%=Request.QueryString["isread"]%>&pageid=<%=Request.QueryString["pageid"] %>'
            class="baocbtn" style="float: none; display: block; color: #ffffff; margin: 0 auto;">
            返回</a>
    </div>
</div>
