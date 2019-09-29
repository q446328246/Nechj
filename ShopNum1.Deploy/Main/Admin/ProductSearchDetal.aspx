<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ProductSearchDetal.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ProductSearchDetal" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>普通商品查看</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
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
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="普通商品查看页"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            商品分类：
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxProductCategory" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>商品分类</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品品牌：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProductBrand" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>商品品牌</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            店铺商品分类：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopProductCategory" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                            <span>店铺商品分类</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品名称：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProductName" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                            <span>商品名称</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            商品类型：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProductType" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>商品类型</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            商品类别：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxType" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                            <span>商品类别</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" valign="middle">
                            <asp:Label ID="LocalizeBuyCount" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyCount" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>商品数量</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品货号：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProductNum" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>商品货号</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品单位：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProductUnit" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>商品单位</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            市场价：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMarketPrice" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>市场价</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            本店价：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopPrice" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>本店价</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            利润分成：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxProfit" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>利润分成</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            运费：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxFeeType" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>运费</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            标题：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>标题</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            关键字：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywords" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>关键字</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            描述：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescribe" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>描述</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            方式：
                        </th>
                        <td>
                            平邮：
                            <asp:TextBox ID="TextBoxPost_fee" Enabled="false" Width="70px" runat="server" CssClass="tinput"
                                Style="width: 60px;"></asp:TextBox>元 快递：
                            <asp:TextBox ID="TextBoxExpress_fee" Enabled="false" Width="70px" runat="server"
                                CssClass="tinput" Style="width: 60px;"></asp:TextBox>元 EMS：
                            <asp:TextBox ID="TextBoxEms_fee" Width="70px" Enabled="false" runat="server" CssClass="tinput"
                                Style="width: 60px;"></asp:TextBox>元
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品图片：
                        </th>
                        <td>
                            <asp:Image ID="ProductImage" Height="20" Width="20" ImageUrl="../../ImgUpload/noImage.gif"
                                onerror="javascript:this.src='../../ImgUpload/noImage.gif'" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品多图：
                        </th>
                        <td>
                            <asp:DataList ID="DataListPorductImage" runat="server" RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="padding: 6px;">
                                                <asp:Image ID="ProductImageList" runat="server" ImageUrl='<%# Eval("OriginalImge", "{0}") %>'
                                                    onerror="javascript:this.src='../../ImgUpload/noImage.gif'" Height="70px" Width="90px" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                            <%--<div class="shoptd">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="DropDownListRegionCode1_SelectedIndexChanged" CssClass="tselect"
                                        Style="width: 100px;">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="DropDownListRegionCode2_SelectedIndexChanged" CssClass="tselect"
                                        Style="width: 100px;">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListRegionCode3" runat="server" CssClass="tselect"
                                        Style="width: 100px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            商品详细：
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorDetail" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            购买须知：
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorInstruction" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LocalizePrice" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPrice" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>
                                <asp:Label ID="LabelPriceName" runat="server" Text="商品价"></asp:Label>
                            </span>
                        </td>
                    </tr>
                    <tr runat="server" id="TrStartTime">
                        <th align="right">
                            <asp:Label ID="LocalizeBuyStartTime" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyStartTime" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>
                                <asp:Label ID="LabelStartTime" runat="server" Text="开始时间"></asp:Label></span>
                        </td>
                    </tr>
                    <tr runat="server" id="TrEndTime">
                        <th align="right" valign="middle">
                            <asp:Label ID="LocalizeBuyEndTime" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyEndTime" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>
                                <asp:Label ID="LabelEndTime" runat="server" Text="结束时间"></asp:Label></span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right" valign="middle">
                            <asp:Label ID="LocalizeMemberCount" runat="server" Text=""></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSpellMemberCount" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>
                                <asp:Label ID="LocalizeMemberMM" runat="server" Text=""></asp:Label></span>
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
