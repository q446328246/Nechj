<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopProductCommentAudit_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopProductCommentAudit_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ�����б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
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
                    <asp:Label ID="LabelTitle" runat="server" Text="��Ʒ�������" /></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right" style="display: none;">
                            ������Ʒ��
                        </td>
                        <td style="display: none;">
                            <asp:TextBox ID="TextBoxProductName" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                        </td>
                        <td>
                            �����ˣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCreateMerber" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            �������ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="Localize3" runat="server" Text="������Ʒ��"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <%--  <td >
                            �����ˣ�
                        </td>
                        <td > 
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                        </td>--%>
                        <td>
                            <asp:Localize ID="LocalizeCreateTime" runat="server" Text="����ʱ�䣺"></asp:Localize>
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxTime1" CssClass="tinput" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 4px; width: 16px;" />
                                        <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxTime1"
                                            PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                            ControlToValidate="TextBoxTime1" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTime2" CssClass="tinput" runat="server" Width="66"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                            top: 4px; width: 16px;" /><t:CalendarExtender ID="CalendarExtender1" runat="server"
                                                TargetControlID="TextBoxTime2" PopupButtonID="img1" CssClass="ajax__calendar" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxTime2"
                                            Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td align="right" class="lmf_px">
                                        <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" />
                                        <asp:DropDownList ID="DropDownList1" Visible="false" Width="183px" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAudit" runat="server" CssClass="shtg lmf_btn" OnClick="ButtonAudit_Click"
                                    OnClientClick=" return AuditButton() "><span>���ͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" CssClass="shwtg lmf_btn" OnClientClick=" return AuditButton() "
                                    OnClick="ButtonCancelAudit_Click"><span>���δͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                    OnClientClick=" return DeleteButton() "><span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <%-- <asp:Button ID="ButtonSearchDetail" runat="server" Text="�鿴"   CssClass="dele"   OnClientClick="return EditButton()"
            OnClick="ButtonSearchDetail_Click" />--%>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <%--                    <asp:TemplateField HeaderText="���۵���" SortExpression="ShopID">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("Shopids").ToString()) %>' target="_blank">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("ShopID") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="ShopName" HeaderText="��������" SortExpression="ShopName"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="������Ʒ" DataField="Name" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="CommentTime" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="������" DataField="MemLoginID" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="���״̬">
                        <ItemTemplate>
                            <%#Is(Eval("IsAudit").ToString()) %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" SortExpression="IsShow">
                        <ItemTemplate>
                            <a href="<%# "ShopProductComment_Detail.aspx?guid=" + "'" + Eval("Guid") + "'" + "&Type=Audit" %>"
                                style="color: #4482b4;">�鿴</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="GetProductAll"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ProductComment_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxProductName" Name="ProductName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxShopID" Name="ShopID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxCreateMerber" Name="createMember" PropertyName="Text"
                Type="String" />
            <asp:Parameter Name="isaudit" Type="String" DefaultValue="0" />
            <asp:ControlParameter ControlID="TextBoxTime1" Name="createTime1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxTime2" Name="createTime2" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
