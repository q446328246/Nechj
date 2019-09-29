<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopInfo_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopInfo_Operate" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>店铺详细</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />

        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
        <script src="js/CommonJS.js" type="text/javascript"> </script>
        <script type='text/javascript' src='js/resolution-test.js'> </script>
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
                    width: '600px',
                    //编辑器宽度
                    height: '320px;',
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
                            <asp:Label ID="LabelPageTitle" runat="server" Text="店铺详细 -> 编辑店铺"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right" width="150px">
                                    店铺类型：
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxShopType" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" width="150px">
                                    店主名称：
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <span></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    店铺名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxShopName" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <span></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    店铺ID：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <span></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    店铺地址：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxShopUrl" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    开店时间：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxOpenTime" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    销售范围：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxSalesRange" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    电子邮件：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxEmail" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <span></span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle9" runat="server"
                                                                    ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="邮件最多100个字符"
                                                                    ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxEmail"
                                                                    Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    座机号码：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxTel" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    手机号码：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxPhone" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="请填写正确的手机号"
                                                                    Display="Dynamic" ControlToValidate="TextBoxPhone" ValidationExpression="^(1[3|5|7|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    邮政编码：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxPostalCode" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <span></span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle10" runat="server"
                                                                    ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="邮政编码格式不对"
                                                                    ValidationExpression="^[0-9 ]{6}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    身份证编号：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxIdentityCard" CssClass="tinput" runat="server" ></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    注册号：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxRegistrationNum" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    企业名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxCompanName" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    法人代表：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxLegalPerson" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    注册资本：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxRegisteredCapital" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    营业期限：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxBusinessTerm" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    营业范围：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxBusinessScope" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span></span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    联系地址：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxAddress" CssClass="tinput" runat="server" MaxLength="200"></asp:TextBox>
                                    <span style="color: red">*</span>
                                    <span></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    是否过期：
                                </th>
                                <td valign="middle">
                                    <asp:DropDownList ID="DropDownListIsExpires" runat="server" CssClass="tselect" Style="margin-top: 5px; width: 100px;">
                                        <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    店铺保障编号：
                                </th>
                                <td>
                                    <asp:Repeater ID="RepeaterEnsure" runat="server">
                                        <ItemTemplate>
                                            <asp:Image ID="ImageEnsure" ImageUrl='<%#Eval("ImagePath") %>' runat="server" />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    是否关闭：
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsClose" runat="server" CssClass="tselect" Style="margin-top: 5px; width: 100px;">
                                        <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                                        <asp:ListItem Value="0">否</asp:ListItem>
                                        <asp:ListItem Value="1">是</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="color: red">*</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    主营宝贝：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxMainGoods" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <span style="color: red">*</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" valign="middle">
                                    店铺简介：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxShopIntroduce" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <span style="color: red">*</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" valign="middle">
                                    公司介绍：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxCompanyIntroduce" CssClass="Texteditor" runat="server"
                                                 TextMode="MultiLine"></asp:TextBox>
                                    <span style="color: red">*</span>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span style="color: red;">注意：以上用* 标识的数据都是可更改的。</span>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" class="imgtable" style="text-align: center">
                            <tr>
                                <th style="text-align: left">
                                    店标
                                </th>
                                <th style="text-align: left">
                                    证件图片（正反）
                                </th>
                                <th runat="server" id="thYyzz" style="text-align: left" >
                                    营业执照
                                </th>
                            </tr>
                            <tr>
                                <td align="center">
                                    <div style="padding: 10px;">
                                        <a runat="server" target="_blank" id="aBanner">
                                            <asp:Image ID="ImageBanner" onerror="javascript:this.src='/ImgUpload/noImage.gif'"
                                                       Height="120" Width="120" runat="server" /></a>
                                    </div>
                                </td>
                                <td align="center">
                                    <div style="padding: 10px;">
                                        <a runat="server" target="_blank" id="aCardImage1">
                                            <asp:Image ID="ImageCardImage1" runat="server" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                                       Height="120" Width="120" /></a>
                                    </div>
                                </td>
                                <td align="center" style="display: none">
                                    <div style="padding: 10px;">
                                        <a runat="server" target="_blank" id="aCardImage2">
                                            <asp:Image ID="ImageCardImage2" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                                       runat="server" Height="120" Width="120" /></a>
                                    </div>
                                </td>
                                <td align="center" runat="server" id="tdYyzz">
                                    <div style="padding: 10px;">
                                        <a runat="server" target="_blank" id="aBusinessLicense">
                                            <asp:Image ID="ImageBusinessLicense" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                                       runat="server" Height="120" Width="120" /></a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                        <asp:Button ID="ButtonBank" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonBank_Click" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
            <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
            <asp:HiddenField ID="HiddenFieldMemLoginID" runat="server" Value="0" />
        </form>
    </body>
</html>