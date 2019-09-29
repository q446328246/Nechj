<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="biaogenr">
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
                <tr>
                    <th colspan="2" scope="col">
                        直通车申请详细
                    </th>
                </tr>
                <tr>
                    <td class="bordleft" width="200">
                        商品名称：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("ProductName") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        支付金币（BV）金额：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("Ztc_Money") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        开始时间：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("StartTime") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        支付状态：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("PayState").ToString() == "1" ? "已支付" : "<span style='color:red'>未支付</span>" %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        审核状态：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#ShopNum1.ShopAdminWebControl.S_ZtcApply_List.shenhe(Eval("AuditState").ToString()) %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        审核时间：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("AuditTime").ToString() == "1900-1-1 0:00:00" ? "" : Eval("AuditTime").ToString() %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        类型：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("Type").ToString() == "0" ? "申请" : "<span style='color:green'>续费</span>" %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft">
                        申请时间：
                    </td>
                    <td class="bordrig" style="padding-top: 8px;">
                        <%#Eval("ApplyTime") %>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                        备注：
                    </td>
                    <td class="bordrig" style="border-bottom: solid 1px #c6dfff;">
                        <%#Eval("Remark") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="op_btn">
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" ValidationGroup="fh" />
    </div>
</div>
