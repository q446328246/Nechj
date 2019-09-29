<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopArticle_Details.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopArticle_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('.Texteditor', {
                //上传管理
                uploadJson: '/kindeditor/file/upload_json.ashx',
                //文件管理
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
                //编辑器高度
                width: '700px',
                //编辑器宽度
                height: '420px;',
                //配置编辑器的工具栏
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
                    <span id="Span1">
                        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="店铺文章详细"></asp:Label></span></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="0" width="100%" id="RadioButtonListSendObject"
                    border="0">
                    <tr>
                        <th style="text-align: right; width: 20%;">
                            <asp:Localize ID="LocalizeAssociatedCategoryGuid" runat="server" Text="店铺文章分类："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCategoryGuid" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: right">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="店铺文章标题："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" ReadOnly="true" CssClass="allinput3 tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: right">
                            <asp:Localize ID="LocalizeCreateTime" runat="server" Text="发布时间："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCreateTime" ReadOnly="true" CssClass="allinput3 tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: right">
                            <asp:Localize ID="LocalizeMember" runat="server" Text="发布人："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemberLoginID" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: right">
                            <asp:Localize ID="LocalizeKeywords" runat="server" Text="关键字："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywords" ReadOnly="true" CssClass="allinput3 tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align: right">
                            <asp:Localize ID="LocalizeContent" runat="server" Text="店铺文章内容："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorConten" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <%--     <tr>
            <td style="text-align: right">
            </td>
            <td>
                 <input type="
                <a href="ShopArticle_Check.aspx" target="_self"><img src='images/back.png' alt="返回列表" /></a>
            </td>
        </tr>--%>
                </table>
                <div class="tablebtn">
                    <asp:Button ID="ButtonGoBack" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonGoBack_Click" />
                    <%--<input type="button" value="返回列表" class="fanh" onclick="location.href='ShopArticle_List.aspx';" />--%>
                </div>
                <div>
                    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
