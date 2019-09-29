<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="EmailGropSend_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.EmailGropSend_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="Service" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʼ�Ⱥ������</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
    <script type="text/javascript">
        KindEditor.ready(function (K) {
            var editor = K.create('.Texteditor', {
                //�ϴ�����
                uploadJson: '/kindeditor/file/upload_json.ashx',
                //�ļ�����
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

        function SendEmail() {
            var arremail = new Array();
            var bflag = false;
            $("#selectEmail option:selected").each(function () {
                bflag = true;
                arremail.push($(this).val());
            });
            $("#hidValue").val(arremail.join("|") + "|");
            return true;

            //alert($("#hidValue").val());return false;
        }

        $(function () {
            if ($("#hidSelect").val() != "0") {
                $("#" + $("#DropDownListEmailTitle option:selected").val()).show();
            }
        });
    </script>
    <style type="text/css">
        p
        {
            color: #000;
        }
    </style>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:HiddenField ID="hidSelect" runat="server" Value="0" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="�ʼ�Ⱥ��"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            ���Ͷ���
                        </th>
                        <td valign="middle">
                            <asp:RadioButtonList ID="RadioButtonListSendObject" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListSendObject_SelectedIndexChanged"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">���л�Ա</asp:ListItem>
                                <asp:ListItem Value="1">�ʼ����Ա</asp:ListItem>
                                <asp:ListItem Value="3">�ȼ���Ա</asp:ListItem>
                                <asp:ListItem Value="5">�ֶ�����</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabeSendTObjectEmail" runat="server" Text="ѡ���Ա��"></asp:Label>
                        </th>
                        <td>
                            <%--  <asp:CheckBoxList ID="listBox" CssClass="tinput"  runat="server" Height="100px" Width="50%" style="overflow:scroll"></asp:CheckBoxList>--%>
                            <select id="selectEmail" runat="server" multiple="true" style="height: 160px; width: 50%">
                            </select>
                            <asp:TextBox ID="TextBoxSendObjectEmail" runat="server" CssClass="tinput" Visible="false"
                                Height="66px" TextMode="MultiLine" Width="452px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:Label ID="Labelmessage" runat="server" Text=""></asp:Label>
                            <br />
                            ���л�Աչʾ���ֺ�ǰ�����ʼ���ַ���������û����� ��סctrl���Զ�ѡ
                        </td>
                    </tr>
                    <tr class="radiobtn" style="display: none">
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                <tr style="display: none">
                                    <th align="right" width="145px">
                                        ѡ���ʼ�ģ�棺
                                    </th>
                                    <td>
                                        <asp:DropDownList ID="DropDownListEmailTitle" runat="server" AutoPostBack="true"
                                            CssClass="tselect" OnSelectedIndexChanged="DropDownListEmailTitle_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="Label5" runat="server" ForeColor="red" Text="*"></asp:Label>
                                        <asp:CompareValidator ID="CompareDropDownListEmailTitle" runat="server" ControlToValidate="DropDownListEmailTitle"
                                            Display="Dynamic" ErrorMessage="��ֵ����ѡ��" ValueToCompare="-1" Operator="NotEqual"></asp:CompareValidator>
                                        <asp:TextBox ID="txtDefine" CssClass="tinput" runat="server" Visible="false"></asp:TextBox>
                                        �ʼ�ģ�����ѡ����������Զ�����Ϊ�ʼ��ı���
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <th align="right">
                                        ��ǩ˵����
                                    </th>
                                    <td>
                                        <p id="ce05437f-75a7-4ee2-8014-4bd992357e51" lang="�µ�ʱ�ʼ�����" style="display: none">
                                            �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                                        <p id="baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c" lang="���뿪���ʼ�����" style="display: none">
                                            �û�����{$Name}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}&nbsp;&nbsp;����״̬��{$SendTime}</p>
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
                                        <p id="00000000-0000-0000-0000-000000000000" lang="�Զ���ģ�����" style="display: none">
                                        </p>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="145px">
                            �ʼ����⣺
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmailTitle" runat="server" Width="600px"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxEmailTitle"
                                runat="server" ErrorMessage="�ʼ����ⲻ��Ϊ��!"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="145px">
                            �ʼ����ݣ�
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorContent" runat="server" CssClass="Texteditor" Width="600px"
                                Height="200px" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                            �ʼ����ݲ���Ϊ�գ�����������1-10000���ַ�֮��
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:HiddenField ID="hidValue" runat="server" />
                <%--        <asp:UpdatePanel ID="updatepanel2" runat="server">
                <ContentTemplate>--%>
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClientClick=" return SendEmail() "
                    OnClick="ButtonConfirm_Click" />
                <asp:Button ID="Button1" runat="server" Text="�����б�" CausesValidation="false" CssClass="fanh"
                    PostBackUrl="~/Main/Admin/EmailGroupSend_List.aspx" />
                <Service:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldProduceMemLoginID" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
                <asp:HiddenField ID="HiddenFieldmsgCount" runat="server" />
                <asp:HiddenField ID="HiddenFieldTop" runat="server" />
                <%--  </ContentTemplate>
                            </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>
    </form>
</html>
