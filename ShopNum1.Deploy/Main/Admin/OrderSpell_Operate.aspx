<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrderSpell_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrderSpell_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�Ź���������</title>
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
                    �Ź���������</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="ordertable">
                <tr>
                    <td colspan="8" align="left">
                        <div class="shux">
                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="��Ʒ����"></asp:Label></div>
                    </td>
                </tr>
                <tr align="center">
                    <td scope="col" style="display: none;">
                        Guid
                    </td>
                    <th scope="col">
                        ��Ʒ����
                    </th>
                    <th scope="col">
                        ��Ʒ����
                    </th>
                    <th scope="col">
                        ����
                    </th>
                    <th scope="col">
                        �г���
                    </th>
                    <th scope="col">
                        �����ۼ�
                    </th>
                    <th scope="col">
                        ����۸�
                    </th>
                    <th scope="col">
                        ��������
                    </th>
                    <th scope="col">
                        С��
                    </th>
                    <td style="display: none">
                    </td>
                    <td style="display: none">
                    </td>
                </tr>
                <tr>
                    <asp:Repeater ID="RepeaterData" runat="server">
                        <ItemTemplate>
                            <td align="center" style="display: none;">
                                <asp:Label ID="Label10" runat="server" Text='<%# Eval("Guid") %>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="Label9" runat="server" Text='<%# Eval("Attributes") %>' Visible="false"></asp:Label>
                            </td>
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
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("GroupPrice") %>'></asp:Label>
                            </td>
                            <td align="center" style="display: none">
                                <asp:Label ID="Label11" runat="server" Text='<%# Eval("productGuid") %>' Visible="false"></asp:Label>
                            </td>
                            <td align="center" style="display: none">
                                <asp:Label ID="Label12" runat="server" Text='<%# Eval("Attributes") %>' Visible="false"></asp:Label>
                            </td>
                        </ItemTemplate>
                    </asp:Repeater>
                </tr>
                <asp:GridView ID="Num1GridViewShowOrderProduct" runat="server" AutoGenerateColumns="False"
                    AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif" descendingimageurl="~/images/SortDesc.gif"
                    Width="100%" AddSequenceColumn="False" AllowMultiColumnSorting="False" CellPadding="0"
                    CellSpacing="0" BorderWidth="0" Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False"
                    FixHeader="False" GridViewSortDirection="Ascending" PagingStyle="None" TableName=""
                    OnRowDataBound="Num1GridViewShowOrderProduct_RowDataBound" CssClass="ordertable"
                    Visible="false">
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                    <Columns>
                        <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                        <asp:BoundField DataField="Name" HeaderText="��Ʒ����">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="��Ʒ����">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Attributes") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="RepertoryNumber" HeaderText="����">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MarketPrice" HeaderText="�г���">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ShopPrice" HeaderText="�����ۼ�">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="����۸�" DataField="BuyPrice">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="��������" DataField="BuyNumber">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="С��" DataField="GroupPrice">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="С��" Visible="false">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="productGuid" HeaderText="��Ʒ��guid" Visible="false" />
                        <asp:BoundField DataField="Attributes" HeaderText="��Ʒ����" Visible="false" />
                    </Columns>
                </asp:GridView>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                <tr>
                    <th colspan="6" align="left">
                        <div class="shux">
                            <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="������Ϣ"></asp:Label>
                        </div>
                    </th>
                </tr>
                <tr>
                    <th width="10%">
                        <asp:Label ID="LabelShopID" runat="server" Text="���ң�"></asp:Label>
                    </th>
                    <td width="15%">
                        <asp:Label ID="LabelShopIDValue" runat="server"></asp:Label>
                    </td>
                    <th width="10%">
                        <asp:Label ID="LabelShopName" runat="server" Text="���̣�"></asp:Label>
                    </th>
                    <td width="30%">
                        <asp:Label ID="LabelShopNameValue" runat="server"></asp:Label>
                    </td>
                    <th width="10%">
                        <asp:Label ID="LabelOrderNumber" runat="server" Text="�����ţ�"></asp:Label>
                    </th>
                    <td width="23%">
                        <asp:Label ID="LabelOrderNumberValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelNameMemLoginID" runat="server" Text="��ң�"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelMemLoginIDValue" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="LabelMemLoginIDValueShow" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelOderStatus" runat="server" Text="����״̬��"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelOderStatusValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelCreateTime" runat="server" Text="�µ�ʱ�䣺"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelCreateTimeValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelNamePaymentName" runat="server" Text="֧����ʽ��"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelPaymentNameValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelNameShipmentNumber" runat="server" Text="�������ţ�"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelShipmentNumberValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelPayTime" runat="server" Text="����ʱ�䣺"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelPayTimeValue" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelNameDispatchModeName" runat="server" Text="���ͷ�ʽ��"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelDispatchModeNameValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelNameFromUrl" runat="server" Text="������Դ��"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelFromUrlValue" runat="server"></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelNameDispatchTime" runat="server" Text="����ʱ�䣺"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelDispatchTimeValue" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" class="ordertable2">
                <tr>
                    <th colspan="4" align="left">
                        <div class="shux">
                            <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="������Ϣ"></asp:Label></div>
                    </th>
                </tr>
                <tr>
                    <th width="16%">
                        <asp:Label ID="LabelInvoiceType" runat="server" Text="��Ʊ���ͣ�"></asp:Label>
                    </th>
                    <td width="33%">
                        <asp:Label ID="LabelInvoiceTypeValue" runat="server" Text=""></asp:Label>
                    </td>
                    <th width="12%">
                        <asp:Label ID="LabelInvoiceTitle" runat="server" Text="��Ʊ̧ͷ��"></asp:Label>
                    </th>
                    <td width="37%">
                        <asp:Label ID="LabelInvoiceTitleValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelNameInvoiceContent" runat="server" Text="��Ʊ���ݣ�"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelInvoiceContentValue" runat="server" Text=""></asp:Label>
                    </td>
                    <th>
                        <asp:Label ID="LabelOutOfStockOperate" runat="server" Text="ȱ������"></asp:Label>
                    </th>
                    <td>
                        <asp:Label ID="LabelOutOfStockOperateValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelClientToSellerMsg" runat="server" Text="�ͻ����̼ҵ����ԣ�"></asp:Label>
                    </th>
                    <td colspan="3">
                        <asp:Label ID="LabelClientToSellerMsgValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelSellerToClientMsg" runat="server" Text="�̼Ҹ��ͻ������ԣ�"></asp:Label>
                    </th>
                    <td colspan="3">
                        <asp:Label ID="LabelSellerToClientMsgValue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <th>
                        <asp:Label ID="LabelUseScore" runat="server" Text="ʹ�õ����Ѻ����"></asp:Label>
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
                            <asp:Label ID="Label31" runat="server" Font-Bold="True" Text="������Ϣ"></asp:Label></div>
                    </th>
                </tr>
                <tr>
                    <th>
                        <div class="ftotle">
                            <asp:Label ID="LabelProductPrice" runat="server" Text="��Ʒ�ܽ�"></asp:Label>
                            <b>
                                <asp:Label ID="LabelProductPriceValue" runat="server"></asp:Label></b> -<asp:Label
                                    ID="LabelNameDiscount" runat="server" Text="�ۿۣ�"></asp:Label>
                            <b>
                                <asp:Label ID="LabelDiscountValue" runat="server">0.00</asp:Label></b> +<asp:Label
                                    ID="LabelInvoiceTax" runat="server" Text="��Ʊ˰�"></asp:Label>
                            <b>
                                <asp:Label ID="LabelInvoiceTaxValue" runat="server"></asp:Label></b> +<asp:Label
                                    ID="LabelDispatchPrice" runat="server" Text="���ͷ��ã�"></asp:Label>
                            <b>
                                <asp:Label ID="LabelDispatchPriceValue" runat="server"></asp:Label></b>+<asp:Label
                                    ID="LabelPaymentPrice" runat="server" Text="֧�����ã�"></asp:Label>
                            <b>
                                <asp:Label ID="LabelPaymentPriceValue" runat="server"></asp:Label></b> =<asp:Label
                                    ID="LabelOrderPrice" runat="server" Text="�����ܽ�"></asp:Label>
                            <b>
                                <asp:Label ID="LabelOrderPriceValue" runat="server"></asp:Label></b>-<asp:Label ID="LabelAlreadPayPrice"
                                    runat="server" Text="�Ѹ����"></asp:Label>
                            <b>
                                <asp:Label ID="LabelAlreadPayPriceValue" runat="server"></asp:Label>
                            </b>-<asp:Label ID="LabelSurplusPrice" runat="server" Text="ʹ����"></asp:Label>
                            <b>
                                <asp:Label ID="LabelSurplusPriceValue" runat="server"></asp:Label></b> -<asp:Label
                                    ID="LabelScorePrice" runat="server" Text="ʹ�ú��(������õĽ��)��"></asp:Label>
                            <b>
                                <asp:Label ID="LabelScorePriceValue" runat="server"></asp:Label></b> =<asp:Label
                                    ID="LabelShouldPayPrice" runat="server" Text="Ӧ�����"></asp:Label>
                            <b>
                                <asp:Label ID="LabelShouldPayPriceValue" runat="server"></asp:Label>
                            </b>
                        </div>
                    </th>
                </tr>
            </table>
        </div>
    </div>
    <asp:Button ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" Text="������Html"
        OnClientClick=" this.form.target = '_blank';window.location.href = window.location.href; "
        CausesValidation="False" CssClass="bt3" Visible="false" />
    <table cellpadding="0" cellspacing="0" border="0" style="display: none; width: 100%;">
        <tr>
            <td colspan="4" style="background-color: #6699CC; width: 100%;">
                <div style="color: White; margin: 3px;">
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="�ջ�����Ϣ"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelName" runat="server" Text="�ջ��ˣ�"></asp:Label>
            </td>
            <td align="left" style="width: 30%;">
                <asp:Label ID="LabelNameValue" runat="server"></asp:Label>
            </td>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelEmail" runat="server" Text="�����ʼ���"></asp:Label>
            </td>
            <td align="left" style="width: 30%;">
                <asp:Label ID="LabelEmailValue" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelAddress" runat="server" Text="��ַ��"></asp:Label>
            </td>
            <td align="left" style="width: 30%;">
                <asp:Label ID="LabelAddressValue" runat="server" Text=""></asp:Label>
            </td>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelPostalcode" runat="server" Text="�ʱࣺ"></asp:Label>
            </td>
            <td align="left" style="width: 30%;">
                <asp:Label ID="LabelPostalcodeValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelTel" runat="server" Text="�绰��"></asp:Label>
            </td>
            <td align="left" style="width: 30%;">
                <asp:Label ID="LabelTelValue" runat="server"></asp:Label>
            </td>
            <td align="right" style="width: 20%;">
                <asp:Label ID="LabelMobile" runat="server" Text="�ֻ���"></asp:Label>
            </td>
            <td align="left" style="width: 30%;">
                <asp:Label ID="LabelMobileValue" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" />
    <asp:HiddenField ID="HiddenFieldAllWeight" Value="0.00" runat="server" />
    <asp:HiddenField ID="HiddenFieldBuyType" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldDeposit" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldIsPayDeposit" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldActivityGuid" runat="server" Value="0" />
    </form>
</body>
</html>
