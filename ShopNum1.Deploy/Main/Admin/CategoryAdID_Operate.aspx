<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdID_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdID_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加分类广告位</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">

        //选择单图
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var imgvalue = new Array();
                imgvalue = k.split(",");
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxAdDefaultPic").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImageOriginalImge").src = imgvalue[1];
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    添加分类广告位</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            广告位名称：
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxAdName" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxAdName" runat="server"
                                ControlToValidate="TextBoxAdName" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            页面名：
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPageName" CssClass="tselect" runat="server">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                <asp:ListItem Value="1">商品分类</asp:ListItem>
                                <asp:ListItem Value="2">分类信息分类</asp:ListItem>
                                <asp:ListItem Value="3">供求分类</asp:ListItem>
                                <asp:ListItem Value="4">店铺分类</asp:ListItem>
                                <asp:ListItem Value="5">资讯分类</asp:ListItem>
                                <asp:ListItem Value="6">品牌分类</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareDdl" runat="server" ControlToValidate="DropDownListPageName"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            广告位宽度：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdWidth" MaxLength="10000" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span><span>px</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertory" runat="server"
                                ControlToValidate="TextBoxAdWidth" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            广告位高度：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" MaxLength="10000" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span><span>px</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxHeight"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            广告位默认图片：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdDefaultPic" CssClass="tinput" runat="server"></asp:TextBox>
                            <input id="ButtonSelectSingleImage" class="selpic" type="button" value="选择图片" onclick=" openSingleChild() " /><asp:RegularExpressionValidator
                                ID="RegularExpressionValidatorLogo" runat="server" ControlToValidate="TextBoxAdDefaultPic"
                                Display="Dynamic" ErrorMessage="最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            <img id="ImageOriginalImge" alt="" src="" runat="server" width="20" height="20" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            广告位默认链接：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultLike" CssClass="tinput" runat="server"></asp:TextBox><span>广告链接</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxDefaultLike"
                                Display="Dynamic" ErrorMessage="最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">
                            广告位流量：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxCategoryAdflow" MaxLength="10000" CssClass="allinput1" runat="server">0</asp:TextBox>
                            <span style="color: Red">*</span>（每天）
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxCategoryAdflow"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td align="right">
                            广告位访问人数：
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxvisitPeople" CssClass="allinput1" MaxLength="10000" runat="server">0</asp:TextBox>
                            <span style="color: Red">*</span>（每天）
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxvisitPeople"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            是否显示：
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" Checked="true" runat="server" /><span>是否前台显示。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            说明：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdIntroduce" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
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
