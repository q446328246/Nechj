<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SupplyDemandDetails.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SupplyDemandDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>供求信息查看</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
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
    <script language="javascript" type="text/javascript">
        function reloadcode() {
            var verify = document.getElementById('safecode');
            verify.setAttribute('src', 'imagecode.aspx?' + Math.random());
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
                    供求信息查看</h3>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeType" runat="server" Text="所属类别："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxType" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize2" runat="server" Text="所属区域："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxAddressValue" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="信息标题："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTradeType" runat="server" Text="类型："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTradeType" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="联系电话："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTel" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize4" runat="server" Text="电子邮件："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize5" runat="server" Text="其他联系方式："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOtherContactWay" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize6" runat="server" Text="联系人："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContactName" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeKeywords" runat="server" Text="查询关键字："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywords" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeDescription" runat="server" Text="信息描述："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" ReadOnly="true" CssClass="tinput" TextMode="MultiLine"
                                runat="server" Height="100" Width="600"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeValidTime" runat="server" Text="信息有效期："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxValidTime" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize1" runat="server" Text="审核状态："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxIsAudit" ReadOnly="true" CssClass="tinput" runat="server">无</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeOrderID" runat="server" Text="发布人："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeImage" runat="server" Text="图片："></asp:Localize>
                        </th>
                        <td>
                            <asp:Image ID="ImageOriginalImge" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                Width="150" Height="150" runat="server" />
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
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" CausesValidation="false" runat="server"
                    Text="返回列表" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
