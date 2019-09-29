<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad">
    <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <tr>
                    <td width="120px" style="text-align: right">
                        姓名：
                    </td>
                    <td>
                        <%# Eval("Name") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        详细地址：
                    </td>
                    <td>
                        <%# Eval("Address") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        手机号码：
                    </td>
                    <td>
                        <%# Eval("Mobile") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        邮政编码：
                    </td>
                    <td>
                        <%# Eval("Postalcode") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        电话号码：
                    </td>
                    <td>
                        <%# Eval("Tel") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        电子邮件：
                    </td>
                    <td>
                        <%# Eval("Email") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        送货日期：
                    </td>
                    <td>
                        <%# Eval("SendDate") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        是否预约：
                    </td>
                    <td>
                        <%# Eval("IsAudit") %>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        备注：
                    </td>
                    <td>
                        <%# Eval("Rank") %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="background-color: #EEEEEE;">
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td class="tab_r">
                &nbsp;
            </td>
            <td style="padding: 10px 0px 10px 0px;">
                <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" />
            </td>
        </tr>
    </table>
</div>
