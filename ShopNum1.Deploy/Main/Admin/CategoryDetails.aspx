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
                height: '450px;',
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
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    分类信息详细</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeAssociatedCategoryGuid" runat="server" Text="所属大类："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCategoryInfo" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入所属大类</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeType" runat="server" Text="交易类型："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxType" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入交易类型</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeValidTime" runat="server" Text="有效期："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxValidTime" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入有效日期</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="信息标题："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入信息标题</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="发布人："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入发布人姓名</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTel" runat="server" Text="联系电话："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTel" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入联系电话</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmail" runat="server" Text="电子邮件："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入电子邮件</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeOtherContactWay" runat="server" Text="其它联系方式："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOtherContactWay" runat="server" ReadOnly="true" CssClass="tinput"></asp:TextBox>
                            <span>请输入其它联系方式</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeContent" runat="server" Text="信息内容："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorContent" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeKeywords" runat="server" Text="关键字："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorKeywords" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <input type="button" value="返回列表" class="fanh" onclick=" window.location.href = 'ShopNum1_CategoryInfo_List.aspx'; " />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="MemLoginID" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
