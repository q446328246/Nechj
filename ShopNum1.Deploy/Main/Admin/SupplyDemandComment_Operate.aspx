<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SupplyDemandComment_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SupplyDemandComment_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�������۲���</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
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
                height: '450px;',
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

        //ѡ��ͼ
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxLogo").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImageOriginalImge").src = k;
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="�鿴����������ϸ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="Label1" runat="server" Text="���������ԱID��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMember" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="������⣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSupplyTitle" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="�������ݣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorDetail" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="���۱��⣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="����ʱ�䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTime" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="�����û���"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxUser" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelLogo" runat="server" Text="����IP��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxIP" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRemark" runat="server" Text="�������ݣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"
                                ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="�ظ����ݣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxReplyContent" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                            <span style="color: red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxReplyContent"
                                runat="server" ErrorMessage="�ظ����ݲ���Ϊ�գ�"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonSubmit" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonSubmit_Click" />
                <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" OnClick="ButtonBack_Click"
                    ValidationGroup="fh" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
