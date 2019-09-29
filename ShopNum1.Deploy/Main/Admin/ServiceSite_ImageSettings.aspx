<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_ImageSettings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_ImageSettings" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>站点设置</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <link href="../../kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <script src="../../kindeditor/kindeditor-min.js" type="text/javascript"> </script>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <!--取色器-->
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var colorpicker;
            K('#colorpicker').bind('click', function (e) {
                e.stopPropagation();
                if (colorpicker) {
                    colorpicker.remove();
                    colorpicker = null;
                    return;
                }
                var colorpickerPos = K('#colorpicker').pos();
                colorpicker = K.colorpicker({
                    x: colorpickerPos.x,
                    y: colorpickerPos.y + K('#colorpicker').height(),
                    z: 19811214,
                    selectedColor: 'default',
                    noColor: '无颜色',
                    click: function (color) {
                        K('#TextBoxWaterMarkWordsColor').val(color);
                        colorpicker.remove();
                        colorpicker = null;
                    }
                });
            });
            K(document).click(function () {
                if (colorpicker) {
                    colorpicker.remove();
                    colorpicker = null;
                }
            });
        });
    </script>
    <script type="text/javascript">
        var lock = 0;
        //选择单图

        function openSingleChild() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        function openSingleChild1() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxShopOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageShopOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        function openSingleChild2() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxMemberOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageMemberOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        //选择水印图片

        function openWaterMarkImage() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxWaterMarkOriginalImge").value = imgvalue[0];
                    document.getElementById("ImgWaterMarkOriginalImge").src = imgvalue[1];
                }
                lock = 0;
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
                    水印设置</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Label ID="Label13" runat="server" Text="水印开启设置："></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListIfSetWaterMark" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0">不开启水印</asp:ListItem>
                                <asp:ListItem Value="1">开启文字水印</asp:ListItem>
                                <asp:ListItem Value="2">开启图片水印</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="top">
                            <asp:Label ID="Label14" runat="server" Text="水印图片："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWaterMarkOriginalImge" runat="server" CssClass="tinput"></asp:TextBox>
                            <input id="Button1" type="button" value="选择图片" onclick=" openWaterMarkImage() " class="selpic" />
                            <img id="ImgWaterMarkOriginalImge" alt="" src="" runat="server" height="110" />
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="Label15" runat="server" Text="图片水印位置："></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListWaterMarkImagePosition" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1">左上角</asp:ListItem>
                                <asp:ListItem Value="2">水平居中垂直顶部</asp:ListItem>
                                <asp:ListItem Value="3">右上角</asp:ListItem>
                                <asp:ListItem Value="4">垂直居中水平靠左</asp:ListItem>
                                <asp:ListItem Value="5">居中</asp:ListItem>
                                <asp:ListItem Value="6">垂直居中水平靠右</asp:ListItem>
                                <asp:ListItem Value="7">左下角</asp:ListItem>
                                <asp:ListItem Value="8">水平居中垂直底部</asp:ListItem>
                                <asp:ListItem Value="9">水印放置右下角</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label16" runat="server" Text="图片水印透明度："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxImageWaterMarkClarity" MaxLength="3" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>%
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxImageWaterMarkClarity"
                                runat="server" ControlToValidate="TextBoxImageWaterMarkClarity" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorImageWaterMarkClarity"
                                runat="server" ControlToValidate="TextBoxImageWaterMarkClarity" Display="Dynamic"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <th align="right">
                                水印文字：
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxWaterMarkWords" runat="server" CssClass="tinput"></asp:TextBox><span
                                    style="color: Red"> *</span>
                            </td>
                        </tr>
                        <tr>
                            <tr>
                                <th align="right">
                                    水印文字字体：
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListWaterMarkWordsFont" runat="server" CssClass="tselect">
                                    </asp:DropDownList>
                                    <span style="color: Red">*</span>
                                </td>
                            </tr>
                            <tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="Label19" runat="server" Text="水印文字字体大小："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxWaterMarkWordsFontSize" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                                        <span style="color: Red">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxWaterMarkWordsFontSize"
                                            runat="server" ControlToValidate="TextBoxWaterMarkWordsFontSize" Display="Dynamic"
                                            ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorWaterMarkWordsFontSize"
                                            runat="server" ControlToValidate="TextBoxWaterMarkWordsFontSize" Display="Dynamic"
                                            ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <tr>
                                        <th align="right">
                                            <asp:Label ID="Label21" runat="server" Text="水印文字字体颜色："></asp:Label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="TextBoxWaterMarkWordsColor" runat="server" CssClass="tinput"></asp:TextBox>
                                            <input type="button" id="colorpicker" value="打开取色器" class="selpic" />
                                        </td>
                                    </tr>
                                    <tr class="radiobtn">
                                        <th align="right">
                                            <asp:Label ID="Label20" runat="server" Text="文字水印位置："></asp:Label>
                                        </th>
                                        <td align="left">
                                            <asp:RadioButtonList ID="RadioButtonListWordsWaterMarkPosition" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="1" Selected="True">左上角</asp:ListItem>
                                                <asp:ListItem Value="2">水平居中垂直顶部</asp:ListItem>
                                                <asp:ListItem Value="3">右上角</asp:ListItem>
                                                <asp:ListItem Value="4">垂直居中水平靠左</asp:ListItem>
                                                <asp:ListItem Value="5">居中</asp:ListItem>
                                                <asp:ListItem Value="6">垂直居中水平靠右</asp:ListItem>
                                                <asp:ListItem Value="7">左下角</asp:ListItem>
                                                <asp:ListItem Value="8">水平居中垂直底部</asp:ListItem>
                                                <asp:ListItem Value="9">水印放置右下角</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="确定" CssClass="qued" OnClick="ButtonEdit_Click" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
