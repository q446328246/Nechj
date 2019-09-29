<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ChangeScoreLog_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ChangeScoreLog_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ���Ѻ��������־</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="margin-bottom: 1px;">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="��ԱID��"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextMemLoginIDValue" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSOperateType" runat="server" Text="������ͣ�"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropdownListSOperateType" runat="server" Width="201px" CssClass="tselect">
                                    <asp:ListItem Value="-1" Selected="True">-ȫ��-</asp:ListItem>
                                    <asp:ListItem Value="1">���ͺ��</asp:ListItem>
                                    <asp:ListItem Value="2" Enabled="false">ת�˺��</asp:ListItem>
                                    <asp:ListItem Value="3">�һ���Ʒ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSDate" runat="server" Text="������ڣ�"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput_data"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 3px; width: 16px;" />
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSDate1" runat="server"
                                    ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                    EnableScriptLocalization="True">
                                </ShopNum1:ToolkitScriptManager>
                            </td>
                            <td>
                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                    PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td class="lmf_px">
                                -
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput_data"></asp:TextBox>
                            </td>
                            <td style="padding-left: 4px; vertical-align: top;">
                                <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                    position: relative; top: 3px; width: 16px;">
                            </td>
                            <td>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSDate2" runat="server"
                                    ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:CompareValidator ID="CompareValidatorTextBoxSDate2" runat="server" ErrorMessage="��ʼʱ��Ӧ�����ڽ���ʱ��"
                                    Type="Date" Display="Dynamic" ControlToValidate="TextBoxSDate2" ControlToCompare="TextBoxSDate1"
                                    Operator="GreaterThan"></asp:CompareValidator>
                            </td>
                            <td>
                                <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                    PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </ShopNum1:CalendarExtender>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CausesValidation="False" Text="��ѯ" OnClick="ButtonSearch_Click"
                                    CssClass="dele" />
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
                    <asp:TemplateField Visible="false">
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <HeaderStyle Height="25px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="��ԱID" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:BoundField DataField="Date" HeaderText="�������" SortExpression="Date">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="�������" SortExpression="OperateType">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# ChangeOperateType(DataBinder.Eval(Container, "DataItem(OperateType)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="CurrentScore" HeaderText="��ǰ���" SortExpression="CurrentScore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="������" SortExpression="OperateScore">
                        <ItemTemplate>
                            <%#Convert.ToInt32(Eval("CurrentScore").ToString()) > Convert.ToInt32(Eval("LastOperateScore").ToString()) ? "-" : "+" %><%#Eval("OperateScore") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="�������" DataField="LastOperateScore" SortExpression="LastOperateScore">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="��ע" DataField="Memo" SortExpression="Memo">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="GetDataInfoAdmin"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ScoreModifyLog_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextMemLoginIDValue" Name="MemLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropdownListSOperateType" Name="OperateType" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="TextBoxSDate1" Name="startTime" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSDate2" Name="endTime" PropertyName="Text"
                Type="String" />
            <asp:Parameter Name="IsDeleted" Type="Int32" DefaultValue="0" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </form>
</body>
</html>
