<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberActualAuthentication_Audit.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberActualAuthentication_Audit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Աʵ����֤����б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />

    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<style type="text/css">
.gridview_m tr td{ text-align:center;}
</style>
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
                    ����Աʵ����֤����б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="margin-bottom:5px;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height:35px; vertical-align:top;">
                        <td align="right">
                            ��Ա���ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemberName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            ��Ա��ʵ���ƣ�
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxRealName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            ���״̬��
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Width="100px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height:35px; vertical-align:top;">
                        <td align="right">
                            ���֤���룺
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxCardNum" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            ����ʱ�䣺
                        </td>
                        <td colspan="3">
                        <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        <td><asp:TextBox ID="TextBoxStartTime" CssClass="dinput" runat="server" Width="58"></asp:TextBox></td>
                        <td style="padding-left:4px; vertical-align:top;"><img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                height: 18px; position: relative; top: 3px" /></td>
                        <td><t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxStartTime"
                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" /></td>
                        <td> <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator></td>
                        <td class="lmf_px">-</td>
                        <td><asp:TextBox ID="TextBoxEndTime" CssClass="dinput" runat="server" Width="58"></asp:TextBox></td>
                        <td style="padding-left:4px; vertical-align:top;"><img id="img1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px; height: 18px;
                                position: relative; top: 3px" /></td>
                        <td><t:CalendarExtender ID="CalendarExtender1"
                                    runat="server" TargetControlID="TextBoxEndTime" PopupButtonID="img1" CssClass="ajax__calendar" /></td>
                        <td><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEndTime"
                                Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator></td>
                        <td><asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" OnClick="ButtonSearch_Click" /></td>

                        </tr>
                        </table>
                        </td>

                    </tr>

                </table>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <cc1:Num1GridView ID="Num1GridViewShow" runat="server" Width="98%" AddSequenceColumn="False"
                        AllowMultiColumnSorting="False" AllowPaging="True" AutoGenerateColumns="False"
                        BorderColor="#CCDDEF" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" DataSourceID="ObjectDataSourceData"
                        Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                        PagingStyle="None" TableName="" AllowSorting="True" CssClass="gridview_m">
                        <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF" CssClass="list_header">
                        </HeaderStyle>
                        <PagerStyle HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="MemLoginID" HeaderText="�����ԱID" SortExpression="MemLoginID" />
                            <asp:BoundField DataField="RealName" HeaderText="��ʵ����" SortExpression="RealName" />
                            <asp:BoundField DataField="IdentityCard" HeaderText="���֤����" SortExpression="IdentityCard" />
                            <asp:BoundField DataField="IdentificationTime" HeaderText="����ʱ��" SortExpression="IdentificationTime" />
                            <asp:TemplateField HeaderText="���״̬">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Is(Eval("IdentificationIsAudit")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </cc1:Num1GridView>
                    <div class="vote" style="padding-left: 2px; margin:15px 42px;">
                        <asp:Button ID="ButtonSearchShop" runat="server" CausesValidation="False" Text="�鿴"
                            OnClientClick=" return EditButton() " CssClass="bt2" OnClick="ButtonSearchShop_Click"
                            Visible="false" />
                        <asp:Button ID="ButtonOperate" runat="server" Text="���ͨ��" OnClick="ButtonOperate_Click"
                            OnClientClick="return OperateButton()" CssClass="bt3" Visible="false" />
                        <asp:Button ID="ButtonOperate1" runat="server" Text="��˲���" OnClientClick="return EditButton()"
                            CssClass="fanh" OnClick="ButtonOperate1_Click" />
                        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchIsAudit"
                            TypeName="ShopNum1.BusinessLogic.ShopNum1_Member_Action" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBoxMemberName" Name="MemLoginID" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="TextBoxRealName" Name="RealName" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="TextBoxCardNum" Name="IdentityCard" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="TextBoxStartTime" Name="StartTime" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="TextBoxEndTime" Name="EndTime" PropertyName="Text"
                                    Type="String" />
                                <asp:ControlParameter ControlID="DropDownListIsAudit" DefaultValue="-2" Name="IdentificationIsAudit"
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                    </div>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    </form>
</body>
</html>
