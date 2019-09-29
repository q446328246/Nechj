<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Video_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Video_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <script type="text/javascript" language="javascript" src="../js/CommonJS.js"> </script>
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
    <%--<script type="text/javascript">
　　    //<![CDATA[
　　    var fckeditorContentLength = 0;

　　    function checkFckeditorContent(source, arguments)
　　    {
　　        arguments.IsValid = (fckeditorContentLength  > 0);
　　    }

　　    function FCKeditor_OnComplete(editorInstance)
　　    {

　   　    editorInstance.Events.AttachEvent('OnBlur', FCKeditor_OnBlur); //附加失去焦点的事件

　　    }

　　    function FCKeditor_OnBlur(editorInstance)
　　    {
　　      fckeditorContentLength = editorInstance.GetXHTML(true).length;
　　      //在FCKeditor失去焦点时，如果内容不为空则隐藏验证提示
　  　    if(fckeditorContentLength > 0){
　  　    document.getElementById("<%= CustomValidatorRemark.ClientID %>").style.display = "none";
　　      }
　　    }
　　    //]]>
    </script>--%>
    <script type="text/javascript">
        lock = 0;
        //选择单图

        function openSingleChild() {
            if (lock == 0) {
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                lock = 0;
                if (k != null) {
                    var strLen = k.length;
                    var index = k.indexOf('/');
                    document.getElementById("ImageSingleImage").src = k.substring(index, strLen).split(',')[0];
                    document.getElementById("TextBoxImg").value = k.substring(index, strLen).split(',')[0];
                }
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增视频"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <th align="right" width="150px;">
                            <asp:Label ID="LabelTitle" runat="server" Text="视频标题："></asp:Label>
                            </td>
                            <td valign="middle">
                                <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="TextBoxTitle"
                                    Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="视频分类："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryID" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidatorArticleCatogory" runat="server" ControlToValidate="DropDownListCategoryID"
                                Style="color: Red" Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual"
                                ValueToCompare="-1"></asp:CompareValidator>
                            <font style="color: Red">*</font>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="视频代码："></asp:Label>
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddress" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
                            <font style="color: Red">
                                <asp:Label ID="Label7" runat="server" Text="*"></asp:Label></font>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxAddress"
                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxAddress"
                    Display="Dynamic" ErrorMessage="地址最多500个字符" ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>--%>
                        </td>
                    </tr>
                    <th align="right">
                        <asp:Label ID="Label2" runat="server" Text="视频图片："></asp:Label>
                    </th>
                    <td>
                        <asp:TextBox ID="TextBoxImg" runat="server" Width="200" CssClass="tinput"></asp:TextBox>
                        <asp:Label ID="Label16" runat="server" Text="*" ForeColor="red"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxImg"
                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        <input id="ButtonSelectSingleImage" type="button" value="插入图片" onclick=" openSingleChild() "
                            class="selpic" style="position: relative; top: 0px; top: 0px\9; *top: -1px; _top: -1px;" />
                        <br />
                        <asp:Image ID="ImageSingleImage" runat="server" ImageUrl="~/images/noImage.gif" Height="156"
                            Width="156" />
                    </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label5" runat="server" Text="是否推荐："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxRecommend" runat="server" />
                            <asp:Label ID="Label9" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxTitle"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label10" runat="server" Text="排序号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderId" runat="server" Width="200" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxOrderId" runat="server"
                                ControlToValidate="TextBoxOrderId" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label12" runat="server" Text="视频标签："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeyWords" runat="server" Width="200" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label13" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxKeyWords"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxKeyWords"
                                Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywordSeo" runat="server" Text="SEO关键字："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywordSeo" runat="server" Width="200" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNotNull5" runat="server" ControlToValidate="TextBoxKeywordSeo"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitlesize2" runat="server"
                                ControlToValidate="TextBoxKeywordSeo" Display="Dynamic" ErrorMessage="标题最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelDescription" runat="server" Text="SEO描述："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" Width="200" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNotNull7" runat="server" ControlToValidate="TextBoxDescription"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitlesize3" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="标题最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label14" runat="server" Text="视频信息："></asp:Label>
                        </th>
                        <td>
                            <FCKeditorV2:FCKeditor ID="FCKeditorRegProtocol" runat="server" Visible="false">
                            </FCKeditorV2:FCKeditor>
                            <asp:TextBox ID="FCKeditorRemark" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>
                            <%--<FCKeditorV2:FCKeditor ID="FCKeditorRemark" runat="server" Height="300px" Width="80%">
                </FCKeditorV2:FCKeditor>--%>
                            <%--<asp:TextBox ID="FCKeditorRemark" runat="server" CssClass="Texteditor" Width="600px"
                                Height="400px"></asp:TextBox>--%>
                            <%--<asp:Label ID="Label15" runat="server" Text="*"  ForeColor="red"></asp:Label>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FCKeditorRemark" runat="server" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>--%>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="FCKeditorRemark"
                    Display="Dynamic" ErrorMessage="标题最多250个字符" ValidationExpression="^[\s\S]{0,650}$"></asp:RegularExpressionValidator>
                     <asp:CustomValidator ID="CustomValidatorRemark" runat="server" ErrorMessage="该值不能为空"
                    ClientValidationFunction="checkFckeditorContent"></asp:CustomValidator>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    ToolTip="Submit" CssClass="fanh" />
                <input id="inputReset" runat="server" type="reset" value="重置" class="fanh" style="display: none;" />
                <asp:Button ID="btnConfirm" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="Video_List.aspx"
                    CausesValidation="False" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="false" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
