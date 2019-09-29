<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CouponList_Search.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CouponList_Search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�Ż�ȯ�鿴</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
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
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="�Ż�ȯ�鿴"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="Label3" runat="server" Text="�Żݻ���ƣ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxSaleTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="�Ż�ȯ���ƣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="�Żݻ���ͣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCouponType" runat="server" CssClass="tinput"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="���ʼʱ�䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxStartTime" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelLogo" runat="server" Text="�����ʱ�䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEndTime" runat="server" CssClass="tinput"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="���ڵ�����"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdressName" runat="server" CssClass="tinput"></asp:TextBox>
                            <span></span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="�Ż�ȯͼƬ��"></asp:Label>
                        </th>
                        <td>
                            <a id="ACoupon" runat="server" target="_blank">
                                <asp:Image ID="ImageCoupon" Height="200" Width="200" runat="server" /></a>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="�������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorContent" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" CausesValidation="false"
                    Text="�����б�" OnClick="ButtonBack_Click" />
                <asp:HiddenField ID="hiddenField1" runat="server" Value="0" />
                <asp:HiddenField ID="HiddenFieldCode" Value="0" runat="server" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
