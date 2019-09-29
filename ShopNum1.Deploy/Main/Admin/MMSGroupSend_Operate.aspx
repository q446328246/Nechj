<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMSGroupSend_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MMSGroupSend_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����Ⱥ������</title>
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <%--
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"></script>

    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"></script>

    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"></script>--%>
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript">
        //        KindEditor.ready(function (K) {
        //            var editor = K.create('.Texteditor', {
        //                //�ϴ�����
        //                uploadJson: '/kindeditor/file/upload_json.ashx',
        //                //�ļ�����
        //                fileManagerJson: '/kindeditor/file/file_manager_json.ashx',
        //                
        //                afterCreate : function() {
        //					var self = this;
        //					K.ctrl(document, 13, function() {
        //						self.sync();
        //						K('form[name=example]')[0].submit();
        //					});
        //					K.ctrl(self.edit.doc, 13, function() {
        //						self.sync();
        //						K('form[name=example]')[0].submit();
        //					});
        //				},
        //                allowFileManager: true,
        //                //�༭���߶�
        //                width: '700px',
        //                //�༭�����
        //                height: '450px;',
        //                //���ñ༭���Ĺ�����
        //                items: [
        //                'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
        //                'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
        //                'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
        //                'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
        //                'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
        //                'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
        //                'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
        //                'anchor', 'link', 'unlink', '|', 'about'
        //                ]
        //            });
        //            prettyPrint();
        //        });

        function CheckMMs() {
            var arremail = new Array();
            var bflag = false;
            $("#selectMMS option:selected").each(function () {
                bflag = true;
                arremail.push($(this).val());
            });
            $("#hidValue").val(arremail.join("|"));
            return true;
            // alert(arremail.join(""));
        }

        $(function () {
            if ($("#hidSelect").val() != "0") {
                $("#" + $("#dropTemplte option:selected").val()).show();
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
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="����Ⱥ��"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Label ID="SendObject" runat="server" Text="���Ͷ���"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:RadioButtonList ID="RadioButtonListSendObject" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="True" OnSelectedIndexChanged="RadioButtonListSendObject_SelectedIndexChanged"
                                RepeatLayout="Flow">
                                <asp:ListItem Value="0" Selected="True">���л�Ա</asp:ListItem>
                                <asp:ListItem Value="1">�������Ա</asp:ListItem>
                                <asp:ListItem Value="3">�ȼ���Ա</asp:ListItem>
                                <asp:ListItem Value="5">�ֶ�����</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabeSendTObjectMMS" runat="server" Text="ѡ���Ա��"></asp:Label>
                        </th>
                        <td>
                            <select id="selectMMS" runat="server" style="height: 160px; width: 50%" multiple="true">
                            </select>
                            <asp:TextBox ID="TextBoxSendObjectMMS" runat="server" CssClass="tinput" Visible="false"
                                Height="66px" TextMode="MultiLine" Width="452px"></asp:TextBox>
                            <span style="color: Red">*</span>��סctrl���Զ�ѡ �ֻ�����������
                            <asp:Label ID="Labelmessage" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right" width="150px">
                            ѡ�����ģ�棺
                        </th>
                        <td>
                            <asp:DropDownList ID="dropTemplte" runat="server" Width="180px" AutoPostBack="True"
                                CssClass="tselect" OnSelectedIndexChanged="dropTemplte_SelectedIndexChanged">
                            </asp:DropDownList>
                            <span style="display: none">
                                <asp:DropDownList ID="DropDownListMMSCaregory" runat="server" Width="180px" AutoPostBack="true"
                                    CssClass="tselect" OnSelectedIndexChanged="DropDownListMMSCaregory_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownListMMSTitle" runat="server" OnSelectedIndexChanged="DropDownListMMSTitle_SelectedIndexChanged"
                                    CssClass="tselect" AutoPostBack="True" Width="180px">
                                </asp:DropDownList>
                            </span><span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareValidatorMMSTitle" runat="server" ControlToValidate="DropDownListMMSTitle"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            ��ǩ˵����
                        </th>
                        <td>
                            <p id="ce05437f-75a7-4ee2-8014-4bd992357e51" lang="�µ�ʱ��������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c" lang="���뿪���������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}&nbsp;&nbsp;����״̬��{$ShopStatus}</p>
                            <p id="e77e5311-e0d2-4b6e-b16d-65db7f4ace40" lang="ȷ���ջ���������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}&nbsp;&nbsp;����״̬��{$OrderStatus}</p>
                            <p id="204e827c-a610-4212-836e-709cd59cba83" lang="����ʱ��������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="7c367402-4219-46b7-bc48-72cf48f6a836" lang="����ʱ��������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="7790bcf5-f88a-46bd-8ead-959118481c02" lang="ע��ʱ��������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;���룺{$PassWord}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="60c1bef2-33e4-4510-944c-afca43d09f0c" lang="������˺�����" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������վ��{$DoMain}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="3b924290-4cf7-4013-9ea4-d2e3a0bfd4b2" lang="ȡ����������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp; ����״̬��{$OrderStatus}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="4a12724c-5154-4928-b867-d5bd180e80e6" lang="ע���Ա�ɹ�" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;�������ƣ�{$ShopName} &nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            �������ݣ�
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorContent" runat="server" CssClass="Texteditor" Width="600px"
                                Height="200px" TextMode="MultiLine"></asp:TextBox>
                            <font color="red">*</font> �������ݲ���Ϊ�գ�����������1-300���ַ�֮��
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClientClick=" return CheckMMs() "
                    OnClick="ButtonConfirm_Click" Text="ȷ��" ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="Button1" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="MMSGroupSend_List.aspx" Text="�����б�" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidValue" runat="server" />
    <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" Value="0" />
    </form>
</body>
</html>
