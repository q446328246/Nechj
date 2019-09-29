<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="dpsc_mian" style="padding-bottom: 60px; width: 998px;">
    <div class="maijtitle3">
    </div>
    <div class="dianpsh" id="showCss" runat="server">
        <div class="no_data1" style="color: #ff6600; float: none; font-size: 18px; font-weight: bold;">
            <asp:Label ID="LabelShow" runat="server" Text="店铺申请成功，请等待审核！"></asp:Label></div>
        <div style="line-height: 23px; margin-top: 10px; text-align: right; text-align: center;"
            runat="server" id="OpenLink">
            <a href="S_ShopOpenStep2.aspx?OptMsg=edit" style="color: #ff6600; color: #005ea7;
                font-size: 12px; text-align: center;">(如需修改提交信息，请点击此处！)</a>
        </div>
        <div style="font-size: 12px;" id="showFailedReason" runat="server" visible="false">
            <div style="background: #ededed; color: #666666; margin: 10px auto; padding: 10px;
                text-align: left; width: 500px;">
                <strong>失败原因：</strong><asp:Label ID="LabelAuditFailedReason" runat="server" Text=""></asp:Label></div>
            <div style="line-height: 23px; margin-top: 10px; text-align: right; text-align: center;">
                <a href="S_ShopOpenStep2.aspx?OptMsg=reopen" style="color: #ff6600; color: #005ea7;
                    font-size: 12px; text-align: center;">(点击修改店铺信息，可继续申请店铺，请保证金币（BV）充足！) </a>
            </div>
        </div>
    </div>
</div>
<table cellpadding="0" cellspacing="0" width="500" border="1" style="display: none;
    margin-left: 150px;">
    <tr>
        <td width="100" style="text-align: right;">
            审核人：
        </td>
        <td width="400" style="text-align: left;">
            <asp:Label ID="LabelOperateUser" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            审核时间：
        </td>
        <td style="text-align: left;">
            <asp:Label ID="LabelAuditTime" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: right;">
            失败原因：
        </td>
        <td style="text-align: left;">
        </td>
    </tr>
</table>
