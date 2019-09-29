<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Order_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Order_Operate" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>订单操作</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">

                        <h3>
                            订单详细综合</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <table border="0" cellpadding="0" cellspacing="0" class="ordertable">
                        <tr>
                            <td colspan="8" align="left">
                                <div class="shux">
                                    <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="商品属性"></asp:Label></div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td scope="col"  style="display: none;">
                                Guid
                            </td>
                            <th scope="col">
                                商品名称
                            </th>
                            <th scope="col" >
                                商品规格
                            </th>
                            <th scope="col">
                                货号
                            </th>
                            <th scope="col">
                                零售价
                            </th>
                            <th scope="col">
                                进货价
                            </th>
                            <th scope="col">
                                实际售价
                            </th>
                            <th scope="col">
                                购买数量
                            </th>
                            <th scope="col">
                                小计
                            </th>
                            <td style="display: none" >
                            </td>
                            <td style="display: none" >
                            </td>
                        </tr>
              
                        <asp:Repeater ID="RepeaterData" runat="server">
                            <itemtemplate>  <tr>
                                                <td align="center"  style="display: none;">
                                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("Guid") %>'></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                                </td>
                                                <td align="center" ><%# Eval("specificationname").ToString().Replace("%2f", "/") %> </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("RepertoryNumber") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("MarketPrice") %>'></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("ShopPrice") %>'></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("BuyPrice") %>'></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("BuyNumber") %>'></asp:Label>
                                                </td>
                                                <td align="center">
                                                    <asp:Label ID="Label8" runat="server" Text='<%#Convert.ToDouble(Eval("ShopPrice"))*Convert.ToDouble(Eval("BuyNumber")) %>'></asp:Label>
                                                </td>
                                                <td align="center" style="display: none">
                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("productGuid") %>' Visible="false" ></asp:Label>
                                                </td>
                                                <td align="center" style="display: none" >
                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Attributes") %>' Visible="false"  ></asp:Label>
                                                </td></tr>
                            </itemtemplate>
                        </asp:Repeater>
                    
               
                        <asp:GridView ID="Num1GridViewShowOrderProduct" runat="server" AutoGenerateColumns="False"
                                      AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif" descendingimageurl="~/images/SortDesc.gif"
                                      Width="100%" AddSequenceColumn="False" AllowMultiColumnSorting="False" CellPadding="0"
                                      CellSpacing="0" BorderWidth="0" Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False"
                                      FixHeader="False" GridViewSortDirection="Ascending" PagingStyle="None" TableName=""
                                      OnRowDataBound="Num1GridViewShowOrderProduct_RowDataBound" CssClass="ordertable"  Visible="false" >
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                            <Columns>
                                <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                                <asp:BoundField DataField="Name" HeaderText="商品名称"  >
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RepertoryNumber" HeaderText="货号">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MarketPrice" HeaderText="市场价">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ShopPrice" HeaderText="本店售价">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="购买价格" DataField="BuyPrice">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="购买数量" DataField="BuyNumber">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="小计" DataField="GroupPrice">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="小计" Visible="false">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="productGuid" HeaderText="商品的guid" Visible="false" />
                                <asp:BoundField DataField="Attributes" HeaderText="商品属性" Visible="false" />
                            </Columns>
                        </asp:GridView>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                        <tr>
                            <th colspan="6" align="left">
                                <div class="shux">
                                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="订单信息"></asp:Label>
                                </div>
                            </th>
                        </tr>
                        <tr>
                            <th width="10%">
                                <asp:Label ID="LabelShopID" runat="server" Text="卖家："></asp:Label>
                            </th>
                            <td width="15%">
                                <asp:Label ID="LabelShopIDValue" runat="server"></asp:Label>
                            </td>
                            <th width="10%">
                                <asp:Label ID="LabelShopName" runat="server" Text="店铺："></asp:Label>
                            </th>
                            <td width="30%">
                                <asp:Label ID="LabelShopNameValue" runat="server"></asp:Label>
                            </td>
                            <th width="10%">
                                <asp:Label ID="LabelOrderNumber" runat="server" Text="订单号："></asp:Label>
                            </th>
                            <td width="23%">
                                <asp:Label ID="LabelOrderNumberValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelNameMemLoginID" runat="server" Text="买家："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelMemLoginIDValue" runat="server" Visible="False"></asp:Label>
                                <asp:Label ID="LabelMemLoginIDValueShow" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelOderStatus" runat="server" Text="订单状态："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelOderStatusValue" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelCreateTime" runat="server" Text="下单时间："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelCreateTimeValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelNamePaymentName" runat="server" Text="支付方式："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelPaymentNameValue" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelNameShipmentNumber" runat="server" Text="发货单号："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelShipmentNumberValue" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelPayTime" runat="server" Text="付款时间："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelPayTimeValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelNameDispatchModeName" runat="server" Text="配送方式："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelDispatchModeNameValue" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelNameFromUrl" runat="server" Text="订单来源："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelFromUrlValue" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelNameDispatchTime" runat="server" Text="发货时间："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelDispatchTimeValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelOrderRefundStatus" runat="server" Text="退款状态："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelOrderRefundStatusValue" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelShopNotAgreedRefund" runat="server" Text="不同意退款理由："></asp:Label>
                            </th>
                            <td valign=middle>
                                <asp:Label ID="LabelShopNotAgreedRefundValue" runat="server"></asp:Label>
                                <img id="imgRefund" runat="server" style="height: 100px; width: 100px;" visible="false" />
                            </td>
                            <th>
                                <asp:Label ID="LabelAdminoperation" runat="server" Text="平台操作："></asp:Label>
                            </th>
                            <td>
                                <asp:Button ID="ButtonAdminAgreed" runat="server" Text="同意退款" CssClass="fanh" Visible="false"  OnClick="ButtonAdminAgreed_Click" />
                            </td>
                        </tr>
                        <tr>
                        <th>
                                <asp:Label ID="LabelJiFenA" runat="server" Text="获得A积分："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelJiFenAText" runat="server"></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelJiFenB" runat="server" Text="获得B积分："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelJiFenBText" runat="server"></asp:Label>

                            </td>
                            <th>
                                <asp:Label ID="LabelKouH" runat="server" Text="所扣红包数："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelKouHV" runat="server"></asp:Label>

                            </td>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                        <tr>
                            <th colspan="4" align="left">
                                <div class="shux">
                                    <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="其它信息"></asp:Label></div>
                            </th>
                        </tr>
                        <tr>
                            <th width="16%">
                                <asp:Label ID="LabelInvoiceType" runat="server" Text="发票类型："></asp:Label>
                            </th>
                            <td width="33%">
                                <asp:Label ID="LabelInvoiceTypeValue" runat="server" Text=""></asp:Label>
                            </td>
                            <th width="12%">
                                <asp:Label ID="LabelInvoiceTitle" runat="server" Text="发票抬头："></asp:Label>
                            </th>
                            <td width="37%">
                                <asp:Label ID="LabelInvoiceTitleValue" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelNameInvoiceContent" runat="server" Text="发票内容："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelInvoiceContentValue" runat="server" Text=""></asp:Label>
                            </td>
                            <th>
                                <asp:Label ID="LabelOutOfStockOperate" runat="server" Text="缺货处理："></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="LabelOutOfStockOperateValue" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelClientToSellerMsg" runat="server" Text="客户给商家的留言："></asp:Label>
                            </th>
                            <td colspan="3">
                                <asp:Label ID="LabelClientToSellerMsgValue" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="LabelSellerToClientMsg" runat="server" Text="商家给客户的留言："></asp:Label>
                            </th>
                            <td colspan="3">
                                <asp:Label ID="LabelSellerToClientMsgValue" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th>
                                <asp:Label ID="LabelUseScore" runat="server" Text="使用的消费红包："></asp:Label>
                            </th>
                            <td colspan="3">
                                <asp:Label ID="LabelUseScoreValue" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
            
                    <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                        <tr>
                            <th colspan="8" align="left">
                                <div class="shux">
                                    <asp:Label ID="Label31" runat="server" Font-Bold="True" Text="费用信息"></asp:Label></div>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <div class="ftotle">
                                    <asp:Label ID="LabelProductPrice" runat="server" Text="商品总金额:"></asp:Label>
                                    <b><asp:Label ID="LabelProductPriceValue" runat="server"></asp:Label></b>&nbsp;-&nbsp;<asp:Label
                                                                                                                              ID="LabelNameDiscount" runat="server" Text="折扣:"></asp:Label>
                                    <b>
                                        <asp:Label ID="LabelDiscountValue" runat="server">0.00</asp:Label></b>&nbsp;+&nbsp;<asp:Label
                                                                                                                               ID="LabelInvoiceTax" runat="server" Text="发票税额:"></asp:Label>
                                    <b>
                                        <asp:Label ID="LabelInvoiceTaxValue" runat="server"></asp:Label></b>&nbsp;+&nbsp;<asp:Label
                                                                                                                             ID="LabelDispatchPrice" runat="server" Text="配送费用:"></asp:Label>
                                    <b>
                                        <asp:Label ID="LabelDispatchPriceValue" runat="server"></asp:Label></b>&nbsp;+&nbsp;<asp:Label
                                                                                                                                ID="LabelPaymentPrice" runat="server" Text="支付费用:"></asp:Label>
                                    <b>
                                        <asp:Label ID="LabelPaymentPriceValue" runat="server"></asp:Label></b>&nbsp;=&nbsp;<span style="font-weight: bold;"><asp:Label
                                                                                                                                                                ID="LabelOrderPrice" runat="server" Text="订单总金额:"></asp:Label></span>
                                    
                                    <b style="font-size: 18px;">
                                        <asp:Label ID="LabelOrderPriceValue" runat="server"></asp:Label></b>
                                    <br />  
                                </div>
                            </th>
                        </tr>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                        <tr>
                            <th colspan="4" align="left">
                                <div class="shux">
                                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="操作日志"></asp:Label></div>
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <div class="ftotle">
                                    <ul>
                                        <%
                                            if (dt_OrderOperate != null)
                                            {
                                                
                                                for (int v = 0; v < dt_OrderOperate.Rows.Count; v++)
                                                {
                                        %>
                                                <li>
                                                    <%= dt_OrderOperate.Rows[v]["createuser"] + " 于 " + dt_OrderOperate.Rows[v]["operatedatetime"] + "  当前状态为：" + dt_OrderOperate.Rows[v]["currentstatemsg"] + " 下一步状态为：" + dt_OrderOperate.Rows[v]["nextstatemsg"] %>
                                                </li>
                                        <% }
                                            } %>
                                    </ul>
                                </div>
                            </th>
                        </tr>
                    </table>
                </div>
            </div>
            <asp:Button ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" Text="导出到Html"
                        OnClientClick=" this.form.target = '_blank';window.location.href = window.location.href; "
                        CausesValidation="False" CssClass="bt3" Visible="false" />
            <table cellpadding="0" cellspacing="0" border="0" style="display: none; width: 100%;">
                <tr>
                    <td colspan="4" style="background-color: #6699CC; width: 100%;">
                        <div style="color: White; margin: 3px;">
                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="收货人信息"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;">
                        <asp:Label ID="LabelName" runat="server" Text="收货人："></asp:Label>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:Label ID="LabelNameValue" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="width: 20%;">
                        <asp:Label ID="LabelEmail" runat="server" Text="电子邮件："></asp:Label>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:Label ID="LabelEmailValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;">
                        <asp:Label ID="LabelAddress" runat="server" Text="地址："></asp:Label>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:Label ID="LabelAddressValue" runat="server" Text=""></asp:Label>
                    </td>
                    <td align="right" style="width: 20%;">
                        <asp:Label ID="LabelPostalcode" runat="server" Text="邮编："></asp:Label>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:Label ID="LabelPostalcodeValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;">
                        <asp:Label ID="LabelTel" runat="server" Text="电话："></asp:Label>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:Label ID="LabelTelValue" runat="server"></asp:Label>
                    </td>
                    <td align="right" style="width: 20%;">
                        <asp:Label ID="LabelMobile" runat="server" Text="手机："></asp:Label>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:Label ID="LabelMobileValue" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <span id="butto1" runat="server" style="display:none">
                <asp:Button ID="Button1" runat="server" CssClass="fanh" CausesValidation="false"
                            Text="通过" OnClick="ButtonBack_Click1" />
                </span>
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" CausesValidation="false"
                            Text="返回列表" OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
    
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" />
            <asp:HiddenField ID="HiddenFieldAllWeight" Value="0.00" runat="server" />
            <asp:HiddenField ID="HiddenFieldBuyType" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFieldType" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldDeposit" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldIsPayDeposit" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldActivityGuid" runat="server" Value="0" />
            <input type="hidden" id="hidRefundMoney" runat="server" />
            <input type="hidden" id="hidProductGuId" runat="server" />
            <input type="hidden" id="hidOnPassReason" runat="server" />
            <input type="hidden" id="hidRefundImg" runat="server" />
            <input type="hidden" id="hidrefundstatus" runat="server" />
            <input type="hidden" id="hidRefundType" runat="server" />
        </form>
    </body>
</html>