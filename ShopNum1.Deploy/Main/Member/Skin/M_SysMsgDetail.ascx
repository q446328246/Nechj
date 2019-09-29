<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_SysMsgDetail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_SysMsgDetail" %>
<%@ Import Namespace="System.Data" %>
<style type="text/css">
.btn-white 
{
	float:right;
    background: linear-gradient(#FFFFFF, #EEEEEE) repeat scroll 0 0 transparent;
    border-color: #BDBDBD;
    color: #333333;
}
.btn-white:hover, .btn-white:focus {
    background: linear-gradient(#FFFFFF, #F7F7F7) repeat scroll 0 0 transparent;
    color: #333333;
}
.btn{position:relative;display:inline-block;*display:inline;zoom:1;overflow:visible;vertical-align:middle;height:26px;margin:0;padding:0
1.2em;border-width:1px;border-style:solid;outline:0;-webkit-border-radius:0.2em;-moz-border-radius:0.2em;border-radius:0.2em;-webkit-box-shadow:2px 2px 2px #cfcfcf;-moz-box-shadow:2px 2px 2px #cfcfcf;box-shadow:2px 2px 2px #cfcfcf;cursor:pointer;-moz-background-clip:padding;background-clip:padding-box;font:bold 14px/26px 'SimSun',sans-serif;text-decoration:none;text-align:center;white-space:nowrap}.btn:hover,.btn:active,.btn:focus{text-decoration:none}.btn::-moz-focus-inner{padding:0;border:0}button.btn,input.btn{height:28px;*line-height:23px}
</style>
<div class="tjsp_mian">
    <p class="ptitle">
        <a href="M_Welcome.aspx">我是买家</a><span class="breadcrume_icon">>></span><a href='<%="M_SysMsg.aspx?isread="+ShopNum1.Common.Common.ReqStr("isread")+"&pageid=1"%>'>系统消息</a><span
            class="breadcrume_icon">>></span><span class="breadcrume_text">系统消息详细</span></p>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="lblTitle" runat="server" Style="color: #005ea7; font-size: 16px; font-weight: bold;"></asp:Label>
            </td>
        </tr>
        <tr>
            <th colspan="2" scope="col" style="background: #e5e4e4; height: 24px; line-height: 24px;
                border: 1px solid #dddddd; text-align: center;">
                <span style="display: none">发信人：<asp:Label ID="lblSendUser" runat="server"></asp:Label></span>
                <span style="display: none">收信人：<asp:Label ID="lblReceiveUser" runat="server"></asp:Label></span>
                <span>时间：<asp:Label ID="lblDate" runat="server"></asp:Label></span>
            </th>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <div style="margin: 20px 10px 20px 10px; line-height: 20px; text-align: left;">
                    <asp:Literal ID="LitContent" runat="server"></asp:Literal>
                </div>
            </td>
        </tr>
    </table>
    <div style="text-align: center; margin: 20px 10px 50px 10px;">
        &nbsp; <a href='M_SysMsg.aspx?isread=<%=Request.QueryString["isread"]%>&pageid=<%=Request.QueryString["pageid"] %>'
            class="baocbtn" style="float: none; display: block; color: #ffffff; margin: 0 auto;">
            返回</a>
    </div>
</div>
