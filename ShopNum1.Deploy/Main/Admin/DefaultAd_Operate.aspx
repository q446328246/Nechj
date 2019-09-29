<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="DefaultAd_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.DefaultAd_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>首页幻灯片图片</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">
        //选择单图
        function openLogoSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxpath").value = "/ImgUpload/" + k.substring(lastIndex + 1, strLen);
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="添加幻灯片图片"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            图片名称：
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxExplain" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxExplain" runat="server"
                                ControlToValidate="TextBoxExplain" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxExplain" Display="Dynamic" ErrorMessage="请不要超过50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            图片地址类型：
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPathType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPathType_SelectedIndexChanged"
                                CssClass="tselect">
                                <asp:ListItem Value="0">路径</asp:ListItem>
                                <asp:ListItem Value="1">上传</asp:ListItem>
                            </asp:DropDownList>
                            <span>图片所属分类。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            链接地址：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHref" CssClass="tinput" runat="server"></asp:TextBox><span>
                                输入链接地址</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            图片地址：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxpath" runat="server" Visible="true" CssClass="tinput"></asp:TextBox>
                            <asp:FileUpload ID="FileUploadpath" runat="server" Visible="false" />
                            <input id="ButtonSelectSingleImage" runat="server" type="button" value="插入图片" visible="true"
                                onclick="openLogoSingleChild()" class="selpic" style="position: relative; top: 1px;
                                top: 0px\9; *top: -1px; _top: -1px;" />
                        </td>
                    </tr>
                    <tr id="adheight" runat="server">
                        <th align="right">
                            高度：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHeight" CssClass="tinput" runat="server"></asp:TextBox><span>
                                输入高度</span>
                        </td>
                    </tr>
                    <tr id="adwidth" runat="server">
                        <th align="right">
                            宽度：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWidth" CssClass="tinput" runat="server"></asp:TextBox><span>
                                输入宽度</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            排序号：
                        </th>
                        <td>
                            <asp:TextBox CssClass="tinput" MaxLength="9" ID="TextBoxLocation" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxLocation" runat="server"
                                ControlToValidate="TextBoxLocation" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxLocation"
                                runat="server" ControlToValidate="TextBoxLocation" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
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
    </form>
</body>
</html>
