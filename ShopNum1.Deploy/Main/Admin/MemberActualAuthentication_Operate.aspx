<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberActualAuthentication_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberActualAuthentication_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员实名列表</title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="操作会员实名认证"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="1" border="0">
                    <tr>
                        <th align="right">
                            会员登录名： </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxName" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            会员真实姓名： </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxRealName" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            会员身份证号： </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxCardNum" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            申请时间： </td>
                            <td align="left">
                                <asp:TextBox ID="TextBoxTime" ReadOnly="true" CssClass="allinput3" runat="server"></asp:TextBox>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            身份证l图片(正面)： </td>
                            <td align="left">
                                <asp:Image ID="ImageIdentityCard" runat="server" />
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            身份证l图片(反面)： </td>
                            <td align="left">
                                <asp:Image ID="ImageIdentityCardBack" runat="server" />
                            </td>
                    </tr>
                    <tr id="trID" runat="server">
                        <th align="right">
                            <asp:Label ID="LabelAuditStatus" runat="server" Text="审核状态："></asp:Label>
                        </th>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListAuditStatus" runat="server" AutoPostBack="true"
                                Width="180px">
                                <asp:ListItem Value="2">审核未通过</asp:ListItem>
                                <asp:ListItem Value="1">审核已通过</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%-- <tr>
            <th>
                审核状态
            </th>
            <td><%=strstate%></td>
        </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAuditFailedReason" runat="server" Text="审核理由："></asp:Label>
                        </th>
                        <td align="left">
                            <textarea id="TextBoxAuditFailedReason" runat="server" style="height: 100px; width: 500px;"
                                class="allinput1"></textarea>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxAuditFailedReason" ValidationGroup="ConfiirmButton"
                                ControlToValidate="TextBoxAuditFailedReason" runat="server" ErrorMessage="此项必填"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxAuditFailedReason"
                                runat="server" ControlToValidate="TextBoxAuditFailedReason" ValidationGroup="ConfiirmButton"
                                Display="Dynamic" ErrorMessage="备注最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <div class="vote" style="margin: 15px 42px; margin-left: 250px; padding-left: 2px;">
                    <asp:Button ID="ButtonConfiirm" runat="server" ValidationGroup="ConfiirmButton" Text="确定"
                        CssClass="fanh" OnClick="ButtonConfiirm_Click" />
                    <input id="inputReset" runat="server" type="reset" value="重置" cssclass="fanh" visible="false" />
                    <asp:Button ID="ButtonBank" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonBank_Click" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
