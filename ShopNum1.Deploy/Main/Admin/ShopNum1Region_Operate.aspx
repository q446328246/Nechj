<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1Region_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1Region_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加区域</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="添加区域"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px;">
                            <asp:Localize ID="Localize1" runat="server" Text="区域名称："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <ShopNum1:TextBox ID="TextBoxName" runat="server" CssClass="tinput" CanBeNull="必填"
                                HintInfo="请填写区域名称，区域名称不能超过50个字" HintTitle="请填区域名称，区域名称不能超过50个字符"></ShopNum1:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeFatherCateGory" runat="server" Text="上级区域名称："></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList CssClass="tselect" ID="DropDownListFatherCateGory" runat="server">
                            </asp:DropDownList>
                            <span>区域分类</span>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFatherCateGory"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="分排序："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox><span>(自动计算)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="是否显示："></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="cbShopMap" runat="server" Checked="true" />地图是否显示在前台(这里可以控制店铺地图那里是否显示店铺数量)
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="~/Main/Admin/ShopNum1Region_list.aspx"
                    Text="返回列表" CausesValidation="False" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            </div>
        </div>
    </div>
    <!-- #include file="Hintinfo.aspx" -->
    </form>
    <script type="text/javascript" src="/JS/dcommon.js"> </script>
</body>
</html>
