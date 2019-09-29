<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrderProductReport.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrderProductReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ������ϸ����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="������ϸ����"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            �����ţ�
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrderNumber" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            ��Ʒ���ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="txtProductName" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            �������ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            �������ڣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxStartDate" runat="server" CssClass="tinput_data"></asp:TextBox>
                            <img id="imgCalendarSReplyTime1" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" /><asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate"
                                    runat="server" ControlToValidate="TextBoxStartDate" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxStartDate"
                                PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
                            -
                            <asp:TextBox ID="TextBoxEndDate" runat="server" CssClass="tinput_data"></asp:TextBox>
                            <img id="imgCalendarSReplyTime2" alt="UserName" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" /><asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate0"
                                    runat="server" ControlToValidate="TextBoxEndDate" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                    ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <t:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxEndDate"
                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="ButtonSearch" runat="server" Text="����" CssClass="dele"
                                OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
                <div>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" CausesValidation="False"
                                    class="daochubtn lmf_btn"><span>������Excel</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonHtml" runat="server" CausesValidation="False" OnClick="ButtonHtml_Click"
                                    OnClientClick=" javascript:document.getElementById('form1').target = '_blank';window.location.href = window.location.href; "
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
                    <asp:BoundField DataField="OrderNumber" HeaderText="������" SortExpression="OrderNumber">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%--                    <asp:BoundField DataField="MemLoginID" HeaderText="����" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="ShopName" HeaderText="��������" SortExpression="ShopName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductName" HeaderText="��Ʒ����" SortExpression="ProductName">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����" DataField="BuyNumber" SortExpression="BuyNumber">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="���׽��" DataField="Amount" SortExpression="Amount">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="��������" DataField="CreateTime" SortExpression="CreateTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchOrderProduct"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_OrderProduct_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtOrderNumber" Name="ordernum" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtProductName" Name="productname" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxShopName" DefaultValue="-1" Name="shopname"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxStartDate" DefaultValue="-1" Name="startdate"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxEndDate" DefaultValue="-1" Name="enddate"
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
