<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addGroup.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.addGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="JS/jquery-1.9.1.js"> </script>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <%--<script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>--%>
        <script src="js/tanchuDIV2.js" type="text/javascript"> </script>
    </head>
    <body style="background: none;">
        <form id="form1" runat="server">
            <div style="padding: 20px;">
                <div class="inner_page_list">
                    <table width="100%" border="0" cellspacing="1" cellpadding="0" style="line-height: 180%; text-align: left">
                        <tr>
                            <th align="right" width="150">
                                <asp:Label ID="LabelAddName" runat="server" Text="角色组名称："></asp:Label>
                            </th>
                            <td colspan="4">
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="220"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLoginID" runat="server" ControlToValidate="TextBoxName"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="用户组名最多50个字符"
                                                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelAddShortName" runat="server" Text="角色组标志："></asp:Label>
                            </th>
                            <td colspan="4">
                                <asp:TextBox ID="TextBoxShortName" runat="server" CssClass="tinput" Width="220"></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorLoginID0" runat="server" ControlToValidate="TextBoxShortName"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorShortName" runat="server"
                                                                ControlToValidate="TextBoxShortName" Display="Dynamic" ErrorMessage="用户组标志最多20个字符"
                                                                ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr style="display: none; height: 30px;">
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4">
                                <asp:Label ID="LabelControlPage" runat="server" Text="控制页面："></asp:Label>
                            </td>
                        </tr>
                        <tr style="display: none; height: 240px;">
                            <td>
                                &nbsp;
                            </td>
                            <td style="display: none; width: 220px;">
                                <asp:ListBox ID="ListBoxPageLeft" runat="server" CssClass="tinput" Height="440px"
                                             Width="200px" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td align="center">
                                <table width="80%" border="0" cellspacing="1" cellpadding="0" style="text-align: center">
                                    <tr>
                                        <%-- <td>
                                                    <asp:Button ID="ButtonAddAllPage" runat="server" CausesValidation="False" OnClick="ButtonAddAllPage_Click"
                                                        Text="&gt;&gt;" CssClass="bt3" />
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <%-- <td>
                                                    <asp:Button ID="ButtonAddPage" runat="server" Text="&gt;" OnClick="ButtonAddPage_Click"
                                                        CausesValidation="False" CssClass="bt3" />
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <%-- <td>
                                                    <asp:Button ID="ButtonDeletePage" runat="server" Text="&lt;" OnClick="ButtonDeletePage_Click"
                                                        CausesValidation="False" CssClass="bt3" />
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                            <%-- <asp:Button ID="ButtonDeleteAllPage" runat="server" OnClick="ButtonDeleteAllPage_Click"
                                                        CausesValidation="False" Text="&lt;&lt;" CssClass="bt3" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <%--  <asp:ListBox ID="ListBoxPageRight" CssClass="tinput" runat="server" Height="440px"
                                            Width="200px" SelectionMode="Multiple" AutoPostBack="True" OnSelectedIndexChanged="ListBoxPageRight_SelectedIndexChanged">--%>
                            </asp:ListBox>
                            </td>
                            <td width="20%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4" style="display: none">
                                <%-- <asp:Button ID="ButtonSetControlPower" runat="server" Text="设置页面控件访问权限" OnClick="ButtonSetControlPower_Click"
                                            CausesValidation="False" CssClass="bnt1" Visible="false" /><asp:DataList ID="DataListPageControl"
                                                runat="server" OnItemDataBound="DataListPageControl_ItemDataBound" Width="100%">--%>
                                <itemtemplate>
                                    <br />
                                    ---------------------------------------<br />
                                    <asp:Label ID="LabelPageName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    <asp:Label ID="LabelPageGuid" runat="server" Text='<%#Eval("Guid") %>' Visible="false"></asp:Label>
                                    <asp:CheckBoxList ID="CheckBoxListControl" runat="server" DataTextField="Name" DataValueField="Guid"
                                                      RepeatDirection="Horizontal" AutoPostBack="True">
                                    </asp:CheckBoxList>
                                </itemtemplate>
                            </asp:DataList>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th align="right">
                                将权限赋予给该部门：
                            </th>
                            <%--<td colspan="4" align="left">
                                        <asp:DropDownList ID="DropDownListDept" runat="server" Width="220" CssClass="tselect"
                                            AutoPostBack="True" OnSelectedIndexChanged="DropDownListDept_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>--%>
                        </tr>
                        <tr>
                            <th align="right" width="20%">
                                <asp:Label ID="Label1" runat="server" Text="角色描述："></asp:Label>
                            </th>
                            <td colspan="4">
                            <textarea id="TextBoxRemarks" runat="server" class="tinput" style="height: 150px; width: 420px;"></textarea>
                            <th align="right" style="display: none;">
                                <asp:Label ID="LabelGroupUser" runat="server" Text="用户组用户："></asp:Label>
                            </th>
                            <td style="display: none">
                                <asp:ListBox ID="ListBoxLeftUser" CssClass="allinput3" runat="server" Height="340px"
                                             Width="200px" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                            <td align="center" style="border: none; display: none;">
                                <table width="100%" border="0" cellspacing="3" cellpadding="2">
                                    <tr>
                                        <td style="border: none;">
                                            <asp:Button ID="ButtonAddAllUser" CausesValidation="False" runat="server" Text="&gt;&gt;"
                                                        CssClass="bt3" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td style="border: none;">
                                                    <asp:Button ID="ButtonAddUser" runat="server" Text="&gt;" OnClick="ButtonAddUser_Click"
                                                        CausesValidation="False" CssClass="bt3" />
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <%--<td style="border: none;">
                                                    <asp:Button ID="ButtonDeleteUser" runat="server" Text="&lt;" OnClick="ButtonRemoveUser_Click"
                                                        CausesValidation="False" CssClass="bt3" />
                                                </td>--%>
                                    </tr>
                                    <tr>
                                        <%--<td style="border: none;">
                                                    <asp:Button ID="ButtonDeleteAllUser" runat="server" Text="&lt;&lt;" OnClick="ButtonRemoveUser_Click"
                                                        CausesValidation="False" CssClass="bt3" />
                                                </td>--%>
                                    </tr>
                                </table>
                            </td>
                            <td style="display: none">
                                <asp:ListBox ID="ListBoxUserRight" CssClass="allinput3" runat="server" Height="340px"
                                             Width="200px" SelectionMode="Multiple"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-top: 12px; text-align: center;">
                    <%--<asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                                    ToolTip="Submit" CssClass="dele" />
                                <input id="inputReset" type="reset" value="重置" runat="server" class="dele" visible="false" />--%>
                    <%--  <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />--%>
                    <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="dele" OnClick="ButtonConfirm_Click"
                                ToolTip="Submit" />
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    <div style="margin-top: 12px; text-align: center;">
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
        </form>
    </body>
</html>