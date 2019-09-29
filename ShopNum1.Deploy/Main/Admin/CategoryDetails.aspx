<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryDetails.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ������Ϣ��ϸ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeAssociatedCategoryGuid" runat="server" Text="�������ࣺ"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCategoryInfo" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>��������������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeType" runat="server" Text="�������ͣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxType" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>�����뽻������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeValidTime" runat="server" Text="��Ч�ڣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxValidTime" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>��������Ч����</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="��Ϣ���⣺"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>��������Ϣ����</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="�����ˣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>�����뷢��������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTel" runat="server" Text="��ϵ�绰��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTel" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>��������ϵ�绰</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmail" runat="server" Text="�����ʼ���"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>����������ʼ�</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeOtherContactWay" runat="server" Text="������ϵ��ʽ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOtherContactWay" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>������������ϵ��ʽ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeContent" runat="server" Text="��Ϣ���ݣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorContent" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeKeywords" runat="server" Text="�ؼ��֣�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorKeywords" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <input type="button" value="�����б�" class="fanh" onclick=" window.location.href = 'ShopNum1_CategoryInfo_List.aspx'; " />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="MemLoginID" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
