<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SeeBuyRate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.SeeBuyRate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>���ʹ�����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ���ʹ�����</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="��Ʒ���ƣ�"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelProductCategoryID" runat="server" Text="��Ʒ���ࣺ"></asp:Label>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        CssClass="tselect" Style="width: 150px;" OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        CssClass="tselect" Style="width: 150px;" OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Style="width: 150px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelBrandGuid" runat="server" Text="��ƷƷ�ƣ�"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListBrandGuid" Width="200px" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ" CssClass="dele" />
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top; display: none">
                        <td>
                            <asp:Label ID="LabelShopPrice" runat="server" Text="�����ۼۣ�"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopPrice1" CssClass="tinput" runat="server" Width="82"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorShopPrice1" runat="server"
                                ControlToValidate="TextBoxShopPrice1" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            -&nbsp;<asp:TextBox ID="TextBoxShopPrice2" CssClass="tinput" runat="server" Width="82"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorShopPrice2" runat="server"
                                ControlToValidate="TextBoxShopPrice2" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidatorTextBoxShopPrice2" runat="server" ErrorMessage="��ʼ�۸�Ӧ������ĩβ�۸�"
                                Type="Double" Display="Dynamic" ControlToValidate="TextBoxShopPrice2" ControlToCompare="TextBoxShopPrice1"
                                Operator="GreaterThan"></asp:CompareValidator>
                        </td>
                        <td style="text-align: right;">
                            <asp:Label ID="LabelMarketPrice" runat="server" Text="�г��ۣ�"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox CssClass="tinput" ID="TextBoxMarketPrice1" runat="server" Width="82"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMarketPrice1" runat="server"
                                ControlToValidate="TextBoxMarketPrice1" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            -
                            <asp:TextBox ID="TextBoxMarketPrice2" CssClass="tinput" runat="server" Width="82"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMarketPrice2" runat="server"
                                ControlToValidate="TextBoxMarketPrice2" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidatorTextBoxMarketPrice2" runat="server" ErrorMessage="��ʼ�۸�Ӧ������ĩβ�۸�"
                                Type="Double" Display="Dynamic" ControlToValidate="TextBoxMarketPrice2" ControlToCompare="TextBoxMarketPrice1"
                                Operator="GreaterThan"></asp:CompareValidator>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" CausesValidation="False"
                                    class="daochubtn lmf_btn"><span>������Excel</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonHtml" runat="server" CausesValidation="False" OnClick="ButtonHtml_Click"
                                    OnClientClick="javascript:document.getElementById('form1').target='_blank';window.location.href=window.location.href;"
                                    class="daochubtn lmf_btn"><span>������Html</span></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="��Ʒ����" SortExpression="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="productcategoryname" HeaderText="��Ʒ����" SortExpression="productCategoryCode"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="brandname" HeaderText="��ƷƷ��" SortExpression="brandGuid"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField HeaderText="������" DataField="ClickCount" SortExpression="ClickCount"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField HeaderText="������" DataField="SaleNumber" SortExpression="SaleNumber"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField HeaderText="���ʹ�����" DataField="BuyRate" SortExpression="BuyRate" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchSeeBuyRate"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Report_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtProductName" Name="name" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListProductGuid1" DefaultValue="-1" Name="productCategoryCode1"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownListProductGuid2" DefaultValue="-1" Name="productCategoryCode2"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownListProductGuid3" DefaultValue="-1" Name="productCategoryCode3"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="DropDownListBrandGuid" DefaultValue="0" Name="brandGuid"
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="TextBoxShopPrice1" DefaultValue="0" Name="shopPrice1"
                    PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBoxMarketPrice2" DefaultValue="0" Name="shopPrice2"
                    PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBoxMarketPrice1" DefaultValue="0" Name="marketPrice1"
                    PropertyName="Text" Type="Decimal" />
                <asp:ControlParameter ControlID="TextBoxMarketPrice2" DefaultValue="0" Name="marketPrice2"
                    PropertyName="Text" Type="Decimal" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
