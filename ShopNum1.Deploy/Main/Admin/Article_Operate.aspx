<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Article_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/ArticleRelateArticleSelect.ascx" TagName="ArticleRelateArticleSelect"
             TagPrefix="uc2" %>
<%--<%@ Register src="UserControl/ArticleRelateProductSelect.ascx" tagname="ArticleRelateProductSelect" tagprefix="uc1" %>
--%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>操作资讯</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
        <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
        <script type="text/javascript">
            KindEditor.ready(function(K) {
                var editor = K.create('.Texteditor', {
                    //上传管理
                    uploadJson: '/kindeditor/file/upload_json.ashx',
                    //文件管理
                    fileManagerJson: '/kindeditor/file/file_manager_json.ashx',

                    afterCreate: function() {
                        var self = this;
                        K.ctrl(document, 13, function() {
                            self.sync();
                            K('form[name=example]')[0].submit();
                        });
                        K.ctrl(self.edit.doc, 13, function() {
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
        <style type="text/css">
            .hidden { display: none; }

            .content { }

            .content .contentHeader {
                background-color: #BCC7E0;
                border: solid 1px #4B66A5;
                font-weight: bold;
            }

            .content .contentMain {
                border-bottom: solid 1px #4B66A5;
                border-left: solid 1px #4B66A5;
                border-right: solid 1px #4B66A5;
                border-top: solid 0px #4B66A5;
            }
        </style>
        <script type="text/javascript">
        //选择单图
            function openSingleChild1() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    var editor = FCKeditorAPI.GetInstance('FCKeditorRemark');
                    {
                        editor.InsertHtml("<img src='" + imgvalue[1] + "'>");
                    }
                }
            }

            function changeTab(count, index) {
                for (var i = 1; i <= count; i++) {
                    document.getElementById('content' + i).style.display = 'none';
                    document.getElementById('current' + i).className = '';
                }
                document.getElementById('current' + index).className = 'cur';
                document.getElementById('content' + index).style.display = 'block';


            }

            //选择多图

            function openChild() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:600px;status:no;dialogHeight:400px");
                if (k != null) {
                    var strLen = k.length;
                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxMultiImage").value = k.substring(lastIndex + 1, strLen);
                    //document.getElementById("img1").v 
                }
            }

            //选择单图

            function openSingleChild() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:600px;status:no;dialogHeight:400px");
                if (k != null) {
                    var strLen = k.length;
                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxThumbImage").value = k.substring(lastIndex + 1, strLen);
                    document.getElementById("ImageThumbImage").src = k;
                }
            }

            //插入附件

            function openSingleAttachMent() {
                var k = window.showModalDialog("AttachMent_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k != null) {
                    var oEditor = FCKeditorAPI.GetInstance("FCKeditorRemark");
                    var content = oEditor.GetXHTML(true);
                    var strs = new Array();
                    strs = k.split(",");
                    oEditor.SetHTML(content + "<a href='" + strs[0] + "'>" + strs[1] + "</a>");
                }
            }
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="right">
                <div class="mhead">
                    <div class="ml">
                        <div class="mr" id="header">
                            <ul class="mul">
                                <li><a class="cur" id="current1" style="cursor: pointer;" onclick=" changeTab(2, 1); ">
                                        <asp:Label runat="server" ID="tab01" Text="资讯详细" /></a>
                                    <%-- <asp:LinkButton ID="LinkButtonAll" runat="server" CssClass="cur" OnClick="LinkButtonAll_Click">全部订单</asp:LinkButton>--%>
                                </li>
                                <li><a id="current2" style="cursor: pointer;" onclick=" changeTab(2, 2); ">
                                        <asp:Label runat="server" ID="tab02" Text="关联资讯" /></a>
                                    <%--<asp:LinkButton ID="LinkButtonNopayment" runat="server" OnClick="LinkButtonNopayment_Click">等待付款</asp:LinkButton>--%>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div id="content1" runat="server" style="display: block;">
                        <div class="inner_page_list">
                            <table border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <th align="right" width="150px">
                                        <asp:Label ID="LabelTitle" runat="server" Text="资讯标题："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                                        <font color="red">
                                            <asp:Label ID="Label1" runat="server" Text="*" Style="color: Red"></asp:Label>
                                        </font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                                                                    Style="color: Red" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                                                        Style="color: Red" ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="标题最多50个字符"
                                                                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelArticleCatogory" runat="server" Text="所属分类："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="DropDownListArticleCategory" runat="server" Width="300" CssClass="tselect">
                                        </asp:DropDownList>
                                        <font color="red">
                                            <asp:Label ID="Label2" runat="server" Text="*" Style="color: Red"></asp:Label></font>
                                        <asp:CompareValidator ID="CompareValidatorArticleCatogory" runat="server" ControlToValidate="DropDownListArticleCategory"
                                                              Style="color: Red" Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual"
                                                              ValueToCompare="0"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelPublisher" runat="server" Text="作者/发布人："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxPublisher" runat="server" CssClass="tinput"></asp:TextBox>
                                        <span>请输入作者/发布人</span>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle0" runat="server"
                                                                        ControlToValidate="TextBoxPublisher" Display="Dynamic" ErrorMessage="发布人最多50个字符"
                                                                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelSource" runat="server" Text="资讯来源："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxSource" runat="server" CssClass="tinput"></asp:TextBox>
                                        <span>请输入资讯来源</span>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle1" runat="server"
                                                                        ControlToValidate="TextBoxSource" Display="Dynamic" ErrorMessage="资讯来源最多150个字符"
                                                                        ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelKeyWord" runat="server" Text="关键字："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxKeyWord" runat="server" CssClass="tinput"></asp:TextBox>
                                        <span>请输入关键字</span>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle2" runat="server"
                                                                        ControlToValidate="TextBoxKeyWord" Display="Dynamic" ErrorMessage="关键字最多200个字符"
                                                                        ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelRemark" runat="server" Text="资讯描述："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput"></asp:TextBox>
                                        <span>请输入资讯描述</span>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle3" runat="server"
                                                                        ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="描述最多150个字符"
                                                                        ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelIfShow" runat="server" Text="是否显示："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="DropDownListIfShow" runat="server" Width="300" CssClass="tselect">
                                        </asp:DropDownList>
                                        <font color="red">
                                            <asp:Label ID="Label3" runat="server" Text="*" Style="color: Red"></asp:Label></font>
                                        <asp:CompareValidator ID="CompareValidatorIfShow" runat="server" ControlToValidate="DropDownListIfShow"
                                                              Style="color: Red" Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual"
                                                              ValueToCompare="-1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelIfAllowComment" runat="server" Text="是否允许评论："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="DropDownListIfAllowComment" runat="server" Width="300" CssClass="tselect">
                                        </asp:DropDownList>
                                        <font color="red">
                                            <asp:Label ID="Label4" runat="server" Text="*" Style="color: Red"></asp:Label></font>
                                        <asp:CompareValidator ID="CompareValidatorIfAllowComment" runat="server" ControlToValidate="DropDownListIfAllowComment"
                                                              Style="color: Red" Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual"
                                                              ValueToCompare="-1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelOrderID" runat="server" Text="排序号："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                                        <font color="red">
                                            <asp:Label ID="Label5" runat="server" Text="*" Style="color: Red"></asp:Label></font>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                                                                        Style="color: Red" ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="只能输入数字"
                                                                        ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                                                    Style="color: Red" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelProperty" runat="server" Text="资讯属性："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxIsHot" runat="server" Text="热点" />
                                        <asp:CheckBox ID="CheckBoxIsRecommend" runat="server" Text="推荐" />
                                        <asp:CheckBox ID="CheckBoxIsHead" runat="server" Text="头条" />
                                    </td>
                                </tr>
                                <tr>
                                    <th align="right">
                                        <asp:Label ID="LabelContent" runat="server" Text="资讯内容："></asp:Label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="FCKeditorRemark" runat="server" CssClass="Texteditor" Width="600px"
                                                     Height="400px"></asp:TextBox>
                                        <font color="red">
                                            <asp:Label ID="Label10" runat="server" Text="*" Style="color: Red"></asp:Label></font>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="FCKeditorRemark"
                                                                    Style="color: Red" Display="Dynamic" ErrorMessage="该值不能为空" EnableClientScript="False"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <!-- ***************************添加资讯*************************** -->
                    <div id="content2" runat="server" style="display: none;">
                        <%--     <div id="content2" runat="server">--%>
                        <!-- 添加资讯-->
                        <uc2:ArticleRelateArticleSelect ID="ArticleRelateArticleSelect1" runat="server" />
                    </div>
                    <!-- ***************************相关商品*************************** -->
                    <div id="content3" runat="server" style="display: none;">
                        <%--    <div id="content3" runat="server">         --%>
                        <%--<uc1:ArticleRelateProductSelect ID="ArticleRelateProductSelect11" 
                        runat="server" />--%>
                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                                    ToolTip="Submit" CssClass="fanh" />
                        <%-- <input id="inputReset" runat="server" type="reset" value="重置" class="fanh" />--%>
                        <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                                    PostBackUrl="~/Main/Admin/Article_List.aspx" Text="返回列表" />
                        <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>