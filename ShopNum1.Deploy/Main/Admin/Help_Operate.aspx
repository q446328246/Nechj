<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Help_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Help_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加帮助</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script type="text/javascript">
        var editor;
        KindEditor.ready(function (K) {
            editor = K.create('.Texteditor', {
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
    <script type="text/javascript">
        //选择单图
        function openSingleChild1() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            //        alert(k);
            if (k != null) {
                var imgvalue = new Array();
                imgvalue = k.split(",");
                editor.insertHtml("<img src='" + imgvalue[1] + "'>");
            }
        }

        function changeTab(count, index) {
            for (var i = 1; i <= count; i++) {
                document.getElementById('current' + i).className = '';
                document.getElementById('content' + i).style.display = 'none';
            }
            document.getElementById('current' + index).className = 'current';
            document.getElementById('content' + index).style.display = 'block';
        }

        //选择多图
        //    function openChild()
        //    { 
        //        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:600px;status:no;dialogHeight:400px"); 
        //        if(k != null) 
        //        {
        //          var strLen=k.length;
        //          var lastIndex=k.lastIndexOf('/');
        //          document.getElementById("TextBoxMultiImage").value = k.substring(lastIndex+1,strLen); 
        //         // var editor = K.create('textarea[name="Texteditor"]', {allowFileManager : true});
        //          editor.insertHtml(document.getElementById("TextBoxMultiImage").value);
        //         //document.getElementById("img1").v 
        //        }
        //    } 
        //选择单图
        //   function openSingleChild()
        //    { 
        //        var k = window.showModalDialog("Image_List_Select.aspx",window,"dialogWidth:600px;status:no;dialogHeight:400px"); 
        //        if(k != null) 
        //        {
        //          alert(k);
        //           editor.insertHtml(k);
        //          var strLen=k.length;
        //          var lastIndex=k.lastIndexOf('/');
        //          document.getElementById("TextBoxThumbImage").value = k.substring(lastIndex+1,strLen); 
        //         document.getElementById("ImageThumbImage").src = k; 
        //        }
        //    } 

        //插入附件

        function openSingleAttachMent() {
            var k = window.showModalDialog("AttachMent_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                //var oEditor = FCKeditorAPI.GetInstance("FCKeditorContent"); 
                //var content = oEditor.GetXHTML(true);
                var strs = new Array();
                strs = k.split(",");
                editor.insertHtml("<a href='" + strs[0] + "'>" + strs[1] + "</a>");
                //alert(strs[0]);
                // oEditor.SetHTML(content + "<a href='"+ strs[0] +"'>"+ strs[1] +"</a>");
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
                    <asp:Label ID="LabelTitle" runat="server" Text="添加帮助"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="帮助标题："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeHelpTypeGuid" runat="server" Text="帮助类别："></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListHelpTypeGuid" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span>不能为空</span>
                            <asp:CompareValidator ID="CompareFatherHelpTypeGuid" runat="server" ControlToValidate="DropDownListHelpTypeGuid"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeOrderID" runat="server" Text="排序号："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator><span>(自动计算)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            是否前台显示：
                        </th>
                        <td>
                            <input id="Checkbox1" type="checkbox" /><span> 是否前台显示。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeContent" runat="server" Text="帮助类容："></asp:Localize>
                        </th>
                        <td>
                            <div style="display: none">
                                <input id="ButtonSelectSingleImage0" type="button" value="插入图片" onclick=" openSingleChild1() "
                                    class="selpic" visible="false" />
                                <input id="Button1" type="button" value="插入附件" onclick=" openSingleAttachMent() "
                                    class="selpic" visible="false" />
                            </div>
                            <asp:TextBox ID="FCKeditorContent" name="Texteditor" runat="server" CssClass="Texteditor"
                                Width="600px" Height="400px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="tablebtn">
                    <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                    <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="Help_List.aspx"
                        Text="返回列表" CausesValidation="False" />
                    <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="HiddenFieldAgentLoginID" runat="server" />
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
