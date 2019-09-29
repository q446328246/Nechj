<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="websites_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.websites_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>【添加站点】</title>
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
                    <asp:Label ID="LabelTitle" runat="server" Text="添加站点"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeName" runat="server" Text="地区："></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownLis1_SelectedIndexChanged" CssClass="tselect"
                                Style="width: 80px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode2" runat="server" Visible="false" AutoPostBack="true"
                                OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" CssClass="tselect"
                                Style="width: 80px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode3" runat="server" Visible="false" CssClass="tselect"
                                Style="width: 80px;">
                            </asp:DropDownList>
                            <span style="color: Red">*</span><span>选择地区。</span>
                            <asp:CompareValidator ID="CompareValidatorDropDownListRegionCode1" runat="server"
                                ControlToValidate="DropDownListRegionCode1" Display="Dynamic" ErrorMessage="该值必需选择"
                                Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localizereplacement" runat="server" Text="域名："></asp:Localize>
                        </th>
                        <td>
                            <ShopNum1:TextBox ID="TextBoxDomain" runat="server" CssClass="tinput" RequiredFieldType="网页地址"
                                CanBeNull="必填" /><span>网页地址。</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="状态："></asp:Localize>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListOpen" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1" Text="开启" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="0" Text="禁用"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    ToolTip="" />
                <input type="button" value="返回列表" class="fanh" onclick=" window.location.href = 'websites_list.aspx' " />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
