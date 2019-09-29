<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopArticleCommentAudit_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopArticleCommentAudit_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ѷ����</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah1">
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
                    <asp:Label ID="LabelPageTitle1" runat="server" Text="������������б�"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td align="right">
                                <asp:Label ID="LabelSMemLoginID" runat="server" Text="�����ˣ�"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSMemLoginID" CssClass="tinput" Width="200" runat="server"></asp:TextBox>
                            </td>
                            <td class="lmf_padding" style="display: none">
                                <asp:Label ID="LabelSTitle" runat="server" Text="���۱��⣺"></asp:Label>
                            </td>
                            <td style="display: none">
                                <asp:TextBox CssClass="tinput" ID="TextBoxSTitle" Width="200" runat="server"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSIsAudit0" runat="server" Text="���״̬��"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListSIsAudit" Width="201" runat="server" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSSendTime" runat="server" Text="����ʱ�䣺"></asp:Label>
                            </td>
                            <td colspan="3">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBoxSSendTime1" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="imgCalendarSReplyTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                                position: relative; top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate1" runat="server"
                                                ControlToValidate="TextBoxSSendTime1" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxSSendTime1"
                                                PopupButtonID="imgCalendarSReplyTime1" CssClass="ajax__calendar" />
                                        </td>
                                        <td class="lmf_px">
                                            -
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxSSendTime2" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                                position: relative; top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate2" runat="server"
                                                ControlToValidate="TextBoxSSendTime2" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBoxSSendTime2"
                                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td align="right">
                                <asp:Label ID="LabelSIsAudit1" runat="server" Text="������Ѷ��"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSArticleGuid" Width="200" CssClass="tinput" runat="server"></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                <asp:Label ID="LabelSIsReply0" runat="server" Text="����IP��"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSIPAddress" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td class="lmf_padding" style="display: none">
                                <asp:Label ID="LabelSIsReply" runat="server" Text="�ظ�״̬��"></asp:Label>
                            </td>
                            <td style="display: none">
                                <asp:DropDownList ID="DropDownListSIsReply" Width="201" runat="server" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="&nbsp;&nbsp;&nbsp;���۵���ID��"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" CssClass="dele" OnClick="ButtonSearch_Click"
                                    Text="��ѯ" />
                                <asp:TextBox ID="TextBoxSReplyTime1" Visible="false" CssClass="allinput1" runat="server"></asp:TextBox>
                                <asp:TextBox CssClass="allinput1" Visible="false" ID="TextBoxSReplyTime2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonReply" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="dele" OnClick="ButtonReply_Click" Visible="false"><span>�鿴</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonIsAudit1" runat="server" OnClick="ButtonIsAudit1_Click"
                                    OnClientClick=" return AuditButton() " CssClass="shtg lmf_btn" CausesValidation="False"><span>���ͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonIsAudit0" runat="server" OnClick="ButtonIsAudit0_Click"
                                    OnClientClick=" return AuditButton() " CssClass="shwtg lmf_btn" CausesValidation="False"><span>���δͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn" CausesValidation="False"><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
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
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" />
                    <asp:BoundField HeaderText="������Ѷ" DataField="Name" SortExpression="Name" />
                    <asp:BoundField DataField="CommentTime" HeaderText="����ʱ��" SortExpression="CommentTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="������" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="���۵���" SortExpression="ShopName">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ShopName") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����ID" SortExpression="ShopID">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%#"shop" + Eval("ShopID") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���״̬" SortExpression="IsAudit">
                        <ItemTemplate>
                            <%#Eval("IsAudit").ToString() == "0" ? "δ���" : "���δͨ��" %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="IPAddress" HeaderText="����IP" SortExpression="IPAddress">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ShopArticleComment_Operate.aspx?guid='" + Eval("Guid") + "'&Type=Audit" %>"
                                style="color: #4482b4;">�鿴</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
            <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
                TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopArticleComment_Action" OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBoxSTitle" Name="title" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSMemLoginID" Name="memLoginID" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSArticleGuid" Name="Name" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxShopID" Name="ShopID" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSSendTime1" Name="CommentTime1" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSSendTime2" Name="CommentTime2" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSReplyTime1" Name="replyTime1" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="TextBoxSReplyTime2" Name="replyTime2" PropertyName="Text"
                        Type="String" />
                    <asp:ControlParameter ControlID="DropDownListSIsReply" Name="isReply" PropertyName="SelectedValue"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="DropDownListSIsAudit" Name="isAudit" PropertyName="SelectedValue"
                        Type="Int32" />
                    <asp:ControlParameter ControlID="TextBoxSIPAddress" Name="iPAddress" PropertyName="Text"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </div>
    </div>
    </form>
</body>
</html>
