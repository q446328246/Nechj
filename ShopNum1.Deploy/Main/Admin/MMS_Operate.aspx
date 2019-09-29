<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMS_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.MMS_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��������</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript">
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="��������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr style="display: none">
                        <th align="right" width="150px">
                            <asp:Label ID="LabelType" runat="server" Text="�������"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <%--<asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareValidatorType" runat="server" ControlToValidate="DropDownListType"
                                Op--%>erator="NotEqual" ValueToCompare="-1" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelTitle" runat="server" Text="���ű��⣺"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxTitle" CssClass="tinput" MaxLength="60" runat="server"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{1,50}$"></asp:RegularExpressionValidator>
                            ���ű��ⲻ��Ϊ�գ�����������1-50���ַ�֮��
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelDescription" runat="server" Text="����������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                            ��������������Ҫ���ܸ�ģ����еĲ���
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="��ǩ˵����"></asp:Label>
                        </th>
                        <td>
                            <p id="ce05437f-75a7-4ee2-8014-4bd992357e51" lang="�µ�ʱ��������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}</p>
                            <p id="baf3ca6b-e3b2-4a9d-beb3-5385ed81c69c" lang="���뿪���������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}&nbsp;&nbsp;����״̬��{$ShopStatus}</p>
                            <p id="e77e5311-e0d2-4b6e-b16d-65db7f4ace40" lang="ȷ���ջ���������" style="display: none">
                                �û�����{$Name}&nbsp;&nbsp;������Ϊ��{$OrderNumber}&nbsp;&nbsp;�������ƣ�{$ShopName}&nbsp;&nbsp;ϵͳʱ�䣺{$SendTime}
                                &nbsp;&nbsp;����״̬��{$OrderStatus}</p>
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
                        <th align="right">
                            <asp:Label ID="LabelNameRemark" runat="server" Text="�������ݣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="FCKeditorRemark" runat="server" Width="600px" Height="200px" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRemark" runat="server" ControlToValidate="FCKeditorRemark"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��" EnableClientScript="False"></asp:RequiredFieldValidator>
                            �������ݲ���Ϊ�գ�����������1-300���ַ�֮��
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="butConfirm" runat="server" OnClick="butConfirm_Click" Text="ȷ��" CssClass="fanh"
                    ToolTip="Submit" />
                <%-- <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                    CssClass="fanh" ToolTip="Submit" />--%>
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/MMS_List.aspx" Text="�����б�" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
