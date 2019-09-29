<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Email_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Email_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʼ�����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script type="text/javascript">
            KindEditor.ready(function(K) {
                var editor = K.create('.Texteditor', {
                    //�ϴ�����
                    uploadJson: '/kindeditor/file/upload_json.ashx',
                    //�ļ�����
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
                    //�༭���߶�
                    width: '700px',
                    //�༭�����
                    height: '300px;',
                    //���ñ༭���Ĺ�����
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
            $(function() {
                var url = location.href;
                var id = url.substring(url.indexOf("=") + 1, url.length).replace("%27", "").replace("%27", "");
                $("#" + <%= Request.QueryString["guid"] %>).show();
            });
    </script>
    <style type="text/css">
        p
        {
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="����ʼ�ģ��"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr style="display: none">
                        <th align="right">
                            <asp:Localize ID="LocalizeType" runat="server" Text="�ʼ����"></asp:Localize>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <%-- <asp:Label ID="Label5" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:CompareValidator ID="CompareDropDownListType" runat="server" ControlToValidate="DropDownListType"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="�ʼ����⣺"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxTitle" runat="server"
                                ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTitle" runat="server"
                                ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="�ʼ����ⲻ�ܳ���50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            �ʼ����ⲻ��Ϊ�գ�����������1-50���ַ�֮��
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeDescription" runat="server" Text=" �ʼ�������"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" ForeColor="red" Text="*"></asp:Label>�ʼ�����������Ҫ���ܸ�ģ����еĲ���
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxDescription" runat="server"
                                ControlToValidate="TextBoxDescription" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxDescription"
                                runat="server" ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="�ʼ��������50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="��ǩ˵����"></asp:Label>
                        </th>
                        <td>
                            <p id="457f965d-f1cc-45cf-b4a5-ddbbd6b7fdc0" lang="�µ�ʱ���̼ҷ����ʼ�" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;��Ա���ƣ�{$MemLoginId}&nbsp;&nbsp;��Ա�绰��{$UserTel}&nbsp;&nbsp;��Ա�ֻ����룺{$UserMobile}&nbsp;&nbsp;��Ʒ���ƣ�{$ProductName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="ce05437f-75a7-4ee2-8014-4bd992357e51" lang="�µ�ʱ�ʼ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c" lang="���뿪���ʼ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}&nbsp;&nbsp;����״̬��{$ShopStatus}</p>
                            <p id="e77e5311-e0d2-4b6e-b16d-65db7f4ace40" lang="ȷ���ջ��ʼ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}&nbsp;&nbsp;����״̬��{$OrderStatus}</p>
                            <p id="204e827c-a610-4212-836e-709cd59cba83" lang="����ʱ�ʼ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="7c367402-4219-46b7-bc48-72cf48f6a836" lang="����ʱ�ʼ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;������ע��{$Memo}&nbsp;&nbsp;������վ��{$DoMain}&nbsp;&nbsp;����ʱ�䣺{$SendTime}&nbsp;&nbsp;��ݵ��ţ�{$SendNumber}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="7790bcf5-f88a-46bd-8ead-959118481c02" lang="ע��ʱ�ʼ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;���룺{$PassWord}&nbsp;&nbsp;������֤��ַ��{$CheckUrl}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="60c1bef2-33e4-4510-944c-afca43d09f0c" lang="������˺�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������վ��{$DoMain}&nbsp;&nbsp;����״̬��{$ShopStatus}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2" lang="ȡ����������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp; ����״̬��{$OrderStatus}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="4a12724c-5154-4928-b867-d5bd180e80e6" lang="ע���Ա�ɹ�" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;�������ƣ�{$ShopName} &nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="5387cec4-05ed-41d1-bc1f-c900c4959585" lang="�������ʧ�ܺ�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������վ��{$DoMain}&nbsp;&nbsp; ����״̬��{$ShopStatus}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="00000000-0000-0000-0000-000000000000" lang="�Զ���ģ�����" style="display: none">
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeRemark" runat="server" Text="�ʼ����ݣ�"></asp:Localize>
                        </th>
                        <td>
                            <textarea id="FCKeditorRemark" runat="server" class="Texteditor tinput txtarea"></textarea>
                            <asp:Label ID="Label6" runat="server" ForeColor="red" Text="*"></asp:Label>
                            �ʼ����ݲ���Ϊ�գ�����������1-1000���ַ�֮��
                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidatorFCKeditorRemark" runat="server"
                                ControlToValidate="FCKeditorRemark" ErrorMessage="��ֵ����Ϊ�� "></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" />
                <asp:Button ID="Button1" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/Email_List.aspx" Text="�����б�" />
                <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldproduceMemLoginID" runat="server" />
    </form>
</body>
</html>
