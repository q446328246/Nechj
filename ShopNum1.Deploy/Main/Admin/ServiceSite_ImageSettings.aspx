<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_ImageSettings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_ImageSettings" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>վ������</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <link href="../../kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <script src="../../kindeditor/kindeditor-min.js" type="text/javascript"> </script>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <!--ȡɫ��-->
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
                    noColor: '����ɫ',
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
        //ѡ��ͼ

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

        //ѡ��ˮӡͼƬ

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
                    ˮӡ����</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Label ID="Label13" runat="server" Text="ˮӡ�������ã�"></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListIfSetWaterMark" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0">������ˮӡ</asp:ListItem>
                                <asp:ListItem Value="1">��������ˮӡ</asp:ListItem>
                                <asp:ListItem Value="2">����ͼƬˮӡ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="top">
                            <asp:Label ID="Label14" runat="server" Text="ˮӡͼƬ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWaterMarkOriginalImge" runat="server" CssClass="tinput"></asp:TextBox>
                            <input id="Button1" type="button" value="ѡ��ͼƬ" onclick=" openWaterMarkImage() " class="selpic" />
                            <img id="ImgWaterMarkOriginalImge" alt="" src="" runat="server" height="110" />
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="Label15" runat="server" Text="ͼƬˮӡλ�ã�"></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListWaterMarkImagePosition" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="1">���Ͻ�</asp:ListItem>
                                <asp:ListItem Value="2">ˮƽ���д�ֱ����</asp:ListItem>
                                <asp:ListItem Value="3">���Ͻ�</asp:ListItem>
                                <asp:ListItem Value="4">��ֱ����ˮƽ����</asp:ListItem>
                                <asp:ListItem Value="5">����</asp:ListItem>
                                <asp:ListItem Value="6">��ֱ����ˮƽ����</asp:ListItem>
                                <asp:ListItem Value="7">���½�</asp:ListItem>
                                <asp:ListItem Value="8">ˮƽ���д�ֱ�ײ�</asp:ListItem>
                                <asp:ListItem Value="9">ˮӡ�������½�</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label16" runat="server" Text="ͼƬˮӡ͸���ȣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxImageWaterMarkClarity" MaxLength="3" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>%
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxImageWaterMarkClarity"
                                runat="server" ControlToValidate="TextBoxImageWaterMarkClarity" Display="Dynamic"
                                ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorImageWaterMarkClarity"
                                runat="server" ControlToValidate="TextBoxImageWaterMarkClarity" Display="Dynamic"
                                ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <tr>
                            <th align="right">
                                ˮӡ���֣�
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxWaterMarkWords" runat="server" CssClass="tinput"></asp:TextBox><span
                                    style="color: Red"> *</span>
                            </td>
                        </tr>
                        <tr>
                            <tr>
                                <th align="right">
                                    ˮӡ�������壺
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
                                        <asp:Label ID="Label19" runat="server" Text="ˮӡ���������С��"></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxWaterMarkWordsFontSize" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                                        <span style="color: Red">*</span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxWaterMarkWordsFontSize"
                                            runat="server" ControlToValidate="TextBoxWaterMarkWordsFontSize" Display="Dynamic"
                                            ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorWaterMarkWordsFontSize"
                                            runat="server" ControlToValidate="TextBoxWaterMarkWordsFontSize" Display="Dynamic"
                                            ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <tr>
                                        <th align="right">
                                            <asp:Label ID="Label21" runat="server" Text="ˮӡ����������ɫ��"></asp:Label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="TextBoxWaterMarkWordsColor" runat="server" CssClass="tinput"></asp:TextBox>
                                            <input type="button" id="colorpicker" value="��ȡɫ��" class="selpic" />
                                        </td>
                                    </tr>
                                    <tr class="radiobtn">
                                        <th align="right">
                                            <asp:Label ID="Label20" runat="server" Text="����ˮӡλ�ã�"></asp:Label>
                                        </th>
                                        <td align="left">
                                            <asp:RadioButtonList ID="RadioButtonListWordsWaterMarkPosition" runat="server" RepeatDirection="Horizontal"
                                                RepeatLayout="Flow">
                                                <asp:ListItem Value="1" Selected="True">���Ͻ�</asp:ListItem>
                                                <asp:ListItem Value="2">ˮƽ���д�ֱ����</asp:ListItem>
                                                <asp:ListItem Value="3">���Ͻ�</asp:ListItem>
                                                <asp:ListItem Value="4">��ֱ����ˮƽ����</asp:ListItem>
                                                <asp:ListItem Value="5">����</asp:ListItem>
                                                <asp:ListItem Value="6">��ֱ����ˮƽ����</asp:ListItem>
                                                <asp:ListItem Value="7">���½�</asp:ListItem>
                                                <asp:ListItem Value="8">ˮƽ���д�ֱ�ײ�</asp:ListItem>
                                                <asp:ListItem Value="9">ˮӡ�������½�</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="ȷ��" CssClass="qued" OnClick="ButtonEdit_Click" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
