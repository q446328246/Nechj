<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopCategoryAply_Audit.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopCategoryAply_Audit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body class="widthah1">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ����˵��̷���
                </h3>
                <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
                    runat="server">
                </asp:ScriptManager>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                �������ƣ�
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxShopName" CssClass="tinput" Width="200" runat="server" Text=""></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                ��ԱID��
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMemberName" Width="200" CssClass="tinput" runat="server"
                                    Text=""></asp:TextBox>
                            </td>
                            <td class="lmf_padding">
                                ����������ࣺ
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListShopCategoryCode1" runat="server" AutoPostBack="true"
                                    CssClass="tselect" Style="width: 100px;" OnSelectedIndexChanged="DropDownListShopCategoryCode1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListShopCategoryCode2" runat="server" AutoPostBack="true"
                                    CssClass="tselect" Style="width: 100px;" OnSelectedIndexChanged="DropDownListShopCategoryCode2_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListShopCategoryCode3" runat="server" CssClass="tselect"
                                    Style="width: 100px;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="height: 35px; vertical-align: top;">
                            <td>
                                ���״̬��
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" Width="207px" CssClass="tselect">
                                </asp:DropDownList>
                            </td>
                            <td class="lmf_padding">
                                ����ʱ�䣺
                            </td>
                            <td colspan="3">
                                <table cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="TextBoxStartTime" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                                position: relative; top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxStartTime"
                                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                                ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                                ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                        </td>
                                        <td class="lmf_px">
                                            -
                                        </td>
                                        <td>
                                            <asp:TextBox ID="TextBoxEndTime" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="padding-left: 4px; vertical-align: top;">
                                            <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                                top: 3px; width: 16px;" />
                                        </td>
                                        <td>
                                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxEndTime"
                                                PopupButtonID="img1" CssClass="ajax__calendar" />
                                        </td>
                                        <td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndTime"
                                                Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="��ѯ"
                                                CssClass="dele" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonSearchShop" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="dele" OnClick="ButtonSearchShop_Click" Visible="false">
                                            <span>�鿴</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonOperate" runat="server" OnClick="ButtonOperate_Click" OnClientClick=" return OperateButton() "
                                    CssClass="shtg lmf_btn">
                                            <span>���ͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonOperate1" runat="server" OnClientClick=" return OperateButton() "
                                    CssClass="shwtg lmf_btn" OnClick="ButtonOperate1_Click">
                                            <span>���δͨ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                    CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click">
                                            <span>����ɾ��</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                    <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="GetShopCategoryApplyInfo"
                        TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TextBoxShopName" PropertyName="Text" Name="ShopName"
                                Type="String"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="TextBoxMemberName" Name="memberLoginID" PropertyName="Text"
                                Type="String" />
                            <asp:ControlParameter Name="ShopCategoryCode" Type="String" ControlID="HiddenFieldCode"
                                PropertyName="Value" />
                            <asp:ControlParameter ControlID="DropDownListIsAudit" DefaultValue="-2" Name="IsAudit"
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="TextBoxStartTime" DefaultValue="" Name="startTime"
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="TextBoxEndTime" DefaultValue="" Name="endTime" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" AllowMultiColumnSorting="False" BackColor="White"
                BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4" GridLines="Vertical">
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
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��������" SortExpression="ShopName">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopUrl").ToString()) %>' target="_blank">
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("ShopName") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="OldShopCategoryName" HeaderText="����ǰ���̷���" SortExpression="OldShopCategoryName"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField DataField="ShopCategoryName" HeaderText="�������" SortExpression="ShopCategoryName"
                        ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                    <asp:BoundField HeaderText="���̻�ԱID" DataField="ShopID" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField HeaderText="����ʱ��" DataField="ApplyTime" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="���״̬">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Is(Eval("IsAudit")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����" SortExpression="IsShow">
                        <ItemTemplate>
                            <a href="<%# "ShopCategoryAply_SearchDetail.aspx?guid=" + Eval("Guid") %>" style="color: #4482b4;">
                                �鿴</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); " OnClick="ButtonDeleteBylink_Click">ɾ��</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
</body>
</html>
