<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ReceiveMessage_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ReceiveMessage_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ϣ�ռ���</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ��Ϣ�ռ���
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            ���ͻ�Ա��
                        </td>
                        <td>
                            <asp:TextBox ID="textBoxMemLoginID" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            ��Ϣ���⣺
                        </td>
                        <td>
                            <asp:TextBox ID="textBoxSTitle" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none; text-align: right;">
                            �Ƿ��Ѷ���
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListSIsRead" runat="server" Width="101px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            �Ƿ�ظ���
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListSIsReply" runat="server" Width="207px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            ����ʱ�䣺
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="textBoxSSendTimeStart" runat="server" CssClass="tinput" Width="58"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorSSendTimeStart" runat="server"
                                            ControlToValidate="textBoxSSendTimeStart" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </ShopNum1:ToolkitScriptManager>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="textBoxSSendTimeStart"
                                            PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        <asp:Label ID="LabelName2" runat="server" Text="-" Font-Bold="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="textBoxSSendTimeEnd" runat="server" CssClass="tinput" Width="58"></asp:TextBox>
                                    </td>
                                    <td style="padding-left: 4px; vertical-align: top;">
                                        <img id="imgCalendarEndTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 3px; width: 16px;" />
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorSSendTimeEnd" runat="server"
                                            ControlToValidate="textBoxSSendTimeEnd" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="textBoxSSendTimeEnd"
                                            PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                            CssClass="dele" /><asp:TextBox ID="textBoxLoginID" Visible="false" runat="server"
                                                CssClass="tinput" Width="100"></asp:TextBox>
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
                                <%--  <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" OnClientClick="GetCheckedBoxValues()"
                        CssClass="tianjiafl lmf_btn"  ><span>��Ӷ���</span></asp:LinkButton>

                                --%>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" if (Page_ClientValidate()) return DeleteButton();return false; "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn">
                                            <span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" if (Page_ClientValidate()) return EditButton();return false; "
                                    CssClass="fanh" Visible="false"><span>�鿴|�ظ�</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridiewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" GridLines="Vertical" Style="margin-top: 15px;">
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
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="3%" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="GUID" SortExpression="Guid" Visible="False"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Title" HeaderText="��Ϣ����" SortExpression="Title" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="SendID" HeaderText="���ͻ�Ա" SortExpression="SendID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����ʱ��" DataField="SendTime" SortExpression="SendTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%--<asp:BoundField DataField="ReceiveID" HeaderText="������" SortExpression="ReceiveID">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>--%>
                    <asp:BoundField DataField="Content" HeaderText="��Ϣ����" SortExpression="Content" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="�Ƿ��Ѷ�" SortExpression="IsRead">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ChangeIsRead(DataBinder.Eval(Container, "DataItem(IsRead)", "{0}")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ƿ�ظ�">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ReplyTime" HeaderText="�ظ�ʱ��" SortExpression="ReplyTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="����" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButtonSearch" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClick="ButtonSearchBylink_Click">�鿴</asp:LinkButton>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchReceive"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_MessageInfo_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="textBoxMemLoginID" Name="SendID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="textBoxLoginID" Name="ReceiveID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="textBoxSSendTimeStart" Name="startDate" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="textBoxSSendTimeEnd" Name="endDate" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="textBoxSTitle" Name="title" PropertyName="Text"
                    Type="String" />
                <asp:Parameter DefaultValue="1" Name="type" Type="String" />
                <asp:ControlParameter ControlID="DropDownListSIsRead" Name="isRead" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListSIsReply" Name="isReply" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="isDelete" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
