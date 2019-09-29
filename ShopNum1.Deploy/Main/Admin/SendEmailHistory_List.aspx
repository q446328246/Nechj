<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SendEmailHistory_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SendEmailHistory_List" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʼ�������ʷ</title>
    <link rel="stylesheet" type="text/css" href="css/index.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    padding: 0;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div class="navigator">
        <asp:Label ID="LabelTitle" runat="server" Text="���ʼ�������ʷ��"></asp:Label></div>
    <div class="query">
        <table width="100%" cellpadding="0" cellspacing="1" border="0">
            <tr>
                <td style="text-align: right;">
                    <asp:Localize ID="LocalizeTitle" runat="server" Text="�ʼ�����:"></asp:Localize>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="allinput1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTitle" runat="server"
                        ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Localize ID="LocalizeState" runat="server" Text="����״̬:"></asp:Localize>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListState" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <asp:Localize ID="LocalizeSendObject" runat="server" Text="���Ͷ���:"></asp:Localize>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSendObject" runat="server" CssClass="allinput1"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxSendObject"
                        runat="server" ControlToValidate="TextBoxSendObject" Display="Dynamic" ErrorMessage="���50���ַ�"
                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                </td>
                <td style="text-align: right;">
                    <asp:Localize ID="LocalizeReplyTime" runat="server" Text="����ʱ��:"></asp:Localize>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTime1" runat="server" CssClass="allinput1"></asp:TextBox>
                    <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                        position: relative; top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender4"
                            runat="server" TargetControlID="TextBoxTime1" PopupButtonID="imgCalendarSReplyTime2"
                            CssClass="ajax__calendar" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                        ControlToValidate="TextBoxTime1" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                    -<asp:TextBox ID="TextBoxTime2" runat="server" CssClass="allinput1"></asp:TextBox>
                    <img id="imgCalendarSReplyTime3" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                        position: relative; top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender1"
                            runat="server" TargetControlID="TextBoxTime2" PopupButtonID="imgCalendarSReplyTime3"
                            CssClass="ajax__calendar" />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime2" runat="server"
                        ControlToValidate="TextBoxTime2" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Localize ID="LocalizeIsTime" runat="server" Text="�Ƿ�ʱ����:"></asp:Localize>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListIsTime" CssClass="allinput1" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Button ID="Button1" runat="server" Text="��ѯ" CssClass="bt2" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <cc1:Num1GridView ID="Num1GridView" runat="server" AutoGenerateColumns="False" AllowPaging="True"
        AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif" descendingimageurl="~/images/SortDesc.gif"
        Width="100%" AddSequenceColumn="False" AllowMultiColumnSorting="False" BorderColor="#CCDDEF"
        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��"
        Edit="False" FixHeader="False" GridViewSortDirection="Ascending" PagingStyle="None"
        Style="margin-left: 2px;" TableName="" DataSourceID="ObjectDataSourceDate">
        <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
        </HeaderStyle>
        <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                </HeaderTemplate>
                <ItemTemplate>
                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="30px" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="�ʼ�����" DataField="EmailTitle" />
            <asp:TemplateField HeaderText="����״̬">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# ChangeState(Eval("State").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="����ʱ��" DataField="CreateTime" />
            <asp:BoundField HeaderText="���Ͷ���" DataField="SendObject" />
            <asp:TemplateField HeaderText="���ͷ�ʽ">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# ChangeisTime(Eval("IsTime").ToString()) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </cc1:Num1GridView>
    <div class="vote2" style="padding-left: 2px;">
        <asp:Button ID="ButtonSend" runat="server" OnClientClick=" return EditButton() "
            CausesValidation="False" Text="���·���" CssClass="bt3 cancel" OnClick="ButtonSend_Click" />
        <asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" Text="ɾ��" CssClass="bt2"
            OnClick="ButtonDelete_Click1" OnClientClick=" return DeleteButton() " />
        <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="SearchEmailGroupSend"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Email_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxTitle" Name="emailtitle" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxTime1" Name="strtime1" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxTime2" Name="strtime2" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxSendObject" Name="sendObjectEmail" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListState" Name="state" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListIsTime" Name="istime" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
        <asp:HiddenField ID="HiddenFieldproduceMemLoginID" runat="server" />
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
