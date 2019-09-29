<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_Settings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_Settings" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>վ������</title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <script type="text/javascript" language="javascript" src="../js/CommonJS.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('.Texteditor', {
                //�ϴ�����
                uploadJson: '/kindeditor/file/upload_json.ashx',
                //�ļ�����
                fileManagerJson: '/kindeditor/file/file_manager_json.ashx',

                afterCreate: function () {
                    var self = this;
                    K.ctrl(document, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                    K.ctrl(self.edit.doc, 13, function () {
                        self.sync();
                        K('form[name=example]')[0].submit();
                    });
                },
                allowFileManager: true,
                //�༭���߶�
                width: '700px',
                //�༭�����
                height: '420px;',
                //���ñ༭���Ĺ�����
                items: [
                        'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
                        'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
                        'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
                        'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
                        'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
                        'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
                        'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
                        'anchor', 'link', 'unlink', '|', 'about'
                    ]
            });
            prettyPrint();
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
                    document.getElementById("HiddenFieldOriginalImge").value = imgvalue[0];
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
                    document.getElementById("HiddenFieldMemberOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageMemberOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        //ѡ���ֻ���ά��

        function openSingleChildPhoneEWM() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("hfPhoneEWM").value = imgvalue[0];
                    document.getElementById("imgPhoneEWM").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        //ѡ��΢�Ŷ�ά��

        function openSingleChildMicroEWM() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("hfMicroEWM").value = imgvalue[0];
                    document.getElementById("ImgMicroEWM").src = imgvalue[1];
                }
                lock = 0;
            }
        }

    </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    վ����Ϣ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeName" runat="server" Text="վ�����ƣ�"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxName" runat="server"
                                ControlToValidate="TextBoxName" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="Title(����)��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <span>һ�㲻����80���ַ�</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxTitle" runat="server"
                                ControlToValidate="TextBoxTitle" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeDescription" runat="server" Text="Meta_Description(����)��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <span>һ�㲻����200���ַ�</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxDescription" runat="server"
                                ControlToValidate="TextBoxDescription" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeKeyWords" runat="server" Text="Meta_Keywords(�ؼ���)��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeyWords" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <span>һ�㲻����100���֡�</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxKeyWords"
                                ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeCopyright" runat="server" Text="վ���Ȩ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCopyright" runat="server" TextMode="MultiLine" CssClass="tinput"
                                Width="380px"></asp:TextBox>
                            <asp:Label ID="Label5" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxCopyright" runat="server"
                                ControlToValidate="TextBoxCopyright" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="�����������ã�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="txtShopUrl" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label10" runat="server" ForeColor="red" Text="�ı���Ϊ��ʱĬ�����֣���http://10001.shop.com"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Localize ID="Localize9" runat="server" Text="վ���Ȩ���ӣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCopyrightLink" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label22" runat="server" ForeColor="red" Text="��http://"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeLogo" runat="server" Text="վ��Logo��"></asp:Localize>
                        </th>
                        <td>
                            <asp:HiddenField ID="HiddenFieldOriginalImge" runat="server" />
                            <%--<asp:TextBox ID="TextBoxOriginalImge" runat="server" CssClass="tinput" Width="380px" ReadOnly="true"></asp:TextBox>--%>
                            <img id="ImageOriginalImge" runat="server" onerror="javascript:this,src='/ImgUpload/noImage.gif'"
                                src="" alt="" width="200" height="60" />
                            <input id="ButtonSelectSingleImage" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() "
                                class="selpic" />
                            <asp:Label ID="Label11" runat="server" Text="ע��ߴ�(����ߴ�406 x 76)"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeLink" runat="server" Text="Logo�����ӵ�ַ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxLink" runat="server" CssClass="tinput" Width="380px"></asp:TextBox>
                            <asp:Label ID="Label23" runat="server" ForeColor="red" Text="��http://"></asp:Label>
                        </td>
                    </tr>
                    <!-- ******************************��Ա��������****************************-->
                    <tr>
                        <th align="right" valign="top">
                            <asp:Localize ID="Localize5" runat="server" Text="��Ա����Logo��"></asp:Localize>
                        </th>
                        <td>
                            <asp:HiddenField ID="HiddenFieldMemberOriginalImge" runat="server" />
                            <%--<asp:TextBox ID="TextBox" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>--%>
                            <img id="ImageMemberOriginalImge" runat="server" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                src="" alt="" width="200" height="60" />
                            <input id="ButtonSelectMemberImage" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild2() "
                                class="selpic" />
                            <asp:Label ID="Label7" runat="server" Text="ע��ߴ�(����ߴ�456 x 60)"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right" valign="top">
                            <asp:Localize ID="Localize7" runat="server" Text="��Ա���İ�Ȩ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCopyrightMember" runat="server" TextMode="MultiLine" CssClass="tinput"
                                Height="50px"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCopyrightMember" runat="server"
                                ControlToValidate="TextBoxCopyrightMember" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right" valign="top">
                            <asp:Localize ID="Localize2" runat="server" Text="����Logo��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopOriginalImge" runat="server" CssClass="tinput"></asp:TextBox>
                            <input id="ButtonSelectShopImage" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild1() "
                                class="selpic" />
                            <img id="ImageShopOriginalImge" runat="server" onerror="javascript:this.src='/ImgUpload/noImage.gif'"
                                alt="" width="144" height="40" />
                            <asp:Label ID="Label6" runat="server" Text="ע��ߴ�"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="top">
                            <asp:Localize ID="Localize6" runat="server" Text="��Ա����ײ���Ϣ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCopyrightShop" runat="server" TextMode="MultiLine" CssClass="tinput"
                                Height="90px" Width="500px"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCopyrightShop" runat="server"
                                ControlToValidate="TextBoxCopyrightShop" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="top">
                            <asp:Localize ID="Localize10" runat="server" Text="�ֻ���ά�룺"></asp:Localize>
                        </th>
                        <td>
                            <asp:HiddenField ID="hfPhoneEWM" runat="server" />
                            <img id="imgPhoneEWM" runat="server" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                src="" alt="" width="160" height="160" />
                            <input id="btnPhoneEWM" type="button" value="ѡ��ͼƬ" onclick=" openSingleChildPhoneEWM() "
                                class="selpic" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="top">
                            <asp:Localize ID="Localize11" runat="server" Text="΢�Ŷ�ά�룺"></asp:Localize>
                        </th>
                        <td>
                            <asp:HiddenField ID="hfMicroEWM" runat="server" />
                            <img id="ImgMicroEWM" runat="server" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                src="" alt="" width="160" height="160" />
                            <input id="btnXEWM" type="button" value="ѡ��ͼƬ" onclick=" openSingleChildMicroEWM() "
                                class="selpic" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="�û�ע��Э�飺"></asp:Localize>
                        </th>
                        <td>
                            <FCKeditorV2:FCKeditor ID="FCKeditorRegProtocol" runat="server" Visible="false">
                            </FCKeditorV2:FCKeditor>
                            <asp:TextBox ID="TexteditorReg" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize8" runat="server" Text="����Э�飺"></asp:Localize>
                        </th>
                        <td>
                            <FCKeditorV2:FCKeditor ID="FCKeditorShopRegProtocol" runat="server" Visible="false">
                            </FCKeditorV2:FCKeditor>
                            <asp:TextBox ID="TexteditorShopReg" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="��վ�ײ���Ϣ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxButtomInfo" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonEdit_Click" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
