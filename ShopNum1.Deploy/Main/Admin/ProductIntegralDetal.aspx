<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ProductIntegralDetal.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ProductIntegralDetal" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>红包商品查看</title>
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="红包商品查看页"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            商品图片：
                        </th>
                        <td valign="middle">
                            <asp:Image ID="ImageProduct" runat="server" Width="120" Height="100" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品名称：
                        </th>
                        <td>
                            <asp:Label ID="LabelProductName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            商品分类：
                        </th>
                        <td valign="middle">
                            <asp:Label ID="LabelProductCategoryName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品货号：
                        </th>
                        <td>
                            <asp:Label ID="LabelRepertoryNumber" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品单位：
                        </th>
                        <td>
                            <asp:Label ID="LabelProductUnit" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            市场价：
                        </th>
                        <td>
                            <asp:Label ID="LabelMarketPrice" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            红包：
                        </th>
                        <td>
                            <asp:Label ID="LabelScore" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            库存：
                        </th>
                        <td>
                            <asp:Label ID="LabelRepertoryCount" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            标题：
                        </th>
                        <td>
                            <asp:Label ID="LabelTitle" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            关键字：
                        </th>
                        <td>
                            <asp:Label ID="LabelKeywords" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            描述：
                        </th>
                        <td>
                            <asp:Label ID="LabelDescribe" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            是否新品：
                        </th>
                        <td>
                            <asp:Label ID="LabelIsNew" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            是否热销：
                        </th>
                        <td>
                            <asp:Label ID="LabelIsHot" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            是否上架：
                        </th>
                        <td>
                            <asp:Label ID="LabelIsSaled" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            是否审核：
                        </th>
                        <td>
                            <asp:Label ID="LabelIsAudit" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品详细：
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorDetail" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" CausesValidation="false"
                    Text="返回列表" OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldMemLoginID" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldType" runat="server" Value="0" />
    </form>
</body>
</html>
