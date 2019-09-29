<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="PageAdID_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.PageAdID_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加广告位</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
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
                    <asp:Label ID="lbltitle" runat="server" Text="添加广告位"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            页面名：
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPageName" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                            <span class="red" style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPageName" ControlToValidate="TextBoxPageName"
                                runat="server" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxPageName" Display="Dynamic" ErrorMessage="请不要超过150个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            文件名：
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListFileName" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFileName"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            广告位ID：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdID" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox><span></span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            高度：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" runat="server"></asp:TextBox><span>
                                广告的高度</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            宽度：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWidth" CssClass="tinput" runat="server"></asp:TextBox><span>
                                广告的宽度</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            说明：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" CausesValidation="false"
                    OnClick="ButtonBack_Click" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADCount" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADGuid" runat="server" Value="0" />
    </form>
</body>
</html>
