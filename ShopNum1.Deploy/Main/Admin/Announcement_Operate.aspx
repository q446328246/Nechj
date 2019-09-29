<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Announcement_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Announcement_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>公告操作</title>
        <link href="style/css.css" rel="stylesheet" type="text/css" />
        <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
        <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
        <script type="text/javascript">
            var editor;
            KindEditor.ready(function(K) {
                editor = K.create('.Texteditor', {
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
        <script type="text/javascript">
        //选择单图
            function openSingleChild() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    editor.insertHtml("<img src='" + imgvalue[1] + "'>");
                }
            }

            window.onload = function SetTineValue() {
                var d, s; //Declare variables.
                d = new Date(); //Create Date object.
                s += (d.getMonth() + 1) + "/"; //Get month
                s += d.getDate() + "/"; //Get day
                s += d.getYear() + " ";
                s += d.getHours() + ":";
                s += d.getMinutes();
                document.getElementById["TextBoxCreateTime"].value = s;
            };
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
                               runat="server">
            </asp:ScriptManager>
            <div id="right">
            <div class="rhigth">
                <div class="rl">
                </div>
                <div class="rcon">
                    <h3>
                        <asp:Label ID="LabelPageTitle" runat="server" Text="新增公告"></asp:Label></h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="welcon clearfix">
                <div class="inner_page_list">
                    <table border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <th align="right" width="150px">
                                <asp:Label ID="LabelTitle" runat="server" Text="公告标题："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                                <font style="color: Red">
                                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="TextBoxTitle"
                                                                Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label4" runat="server" Text="公告分类："></asp:Label>
                            </th>
                            <td>
                                <asp:DropDownList ID="DropDownListFatherID" runat="server" CssClass="tselect" Width="265">
                                </asp:DropDownList>
                                <font style="color: Red">
                                    <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitle"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelRemark" runat="server" Text="公告内容："></asp:Label>
                            </th>
                            <td>
                                <input id="ButtonSelectSingleImage" class="selpic" type="button" value="插入图片" onclick=" openSingleChild() " />
                                <asp:TextBox ID="FCKeditorReMark" runat="server" CssClass="Texteditor" Width="600px"
                                             Height="400px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelKeywords" runat="server" Text="关键字："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxKeywords" CssClass="tinput" runat="server"></asp:TextBox>
                                <span>(用于网站SEO)</span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelCreateTime" runat="server" Text="发布时间："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxCreateTime" runat="server" CssClass="tinput"></asp:TextBox>
                                <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndDate" runat="server"
                                                                ControlToValidate="TextBoxCreateTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                <font style="color: Red">
                                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label></font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCreateTime" runat="server"
                                                            ControlToValidate="TextBoxCreateTime" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <t:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxCreateTime"
                                                           PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                </t:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Labeldescription" runat="server" Text="描述："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxdescription" TextMode="MultiLine" CssClass="tinput txtarea"
                                             runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tablebtn">
                    <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                                ToolTip="Submit" CssClass="fanh" />
                    <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="Announcement_List.aspx"
                                Text="返回列表" CausesValidation="False" />
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
        </form>
    </body>
</html>