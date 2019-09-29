<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Limit_Setting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Limit_Setting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ʱ�ۿ�����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript">
        function NumTxt_Int(o) {
            if (o.toString() == "")
                o.value = "0";
            o.value = o.value.replace(/\D/g, '');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="mhead">
            <div class="ml">
                <div class="mr">
                    <ul class="mul">
                        <li id="current1"><a href="Limit_ActivityList.aspx">��б�</a> </li>
                        <li id="current2" style="display: none;"><a href="Limit_Setting.aspx" class="cur">����</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellspacing="1" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <th align="right" style="width: 100px;">
                                <span id="LabelName">��ʱ�ۿ���Ҫ�Ľ�ң�BV��:</span>
                            </th>
                            <td>
                                <input type="text" id="txtMoney" runat="server" class="tinput" maxlength="100" />
                                &nbsp;<span check="errormsg" style="color: Red;"></span> <span style="color: Red;">*</span>
                                ����Ϊ��λ�۳����ҹ������ڷ�����ʱ�ۿۻ����Ҫ�Ľ�ң�BV��
                            </td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 100px;">
                                <span id="Span1">ÿ�·����������:</span>
                            </th>
                            <td>
                                <input type="text" id="txtMonthActivity" runat="server" class="tinput" onkeyup="NumTxt_Int(this)"
                                    maxlength="5" />
                                &nbsp;<span check="errormsg" style="color: Red;"></span> <span style="color: Red;">*</span>
                                ÿ�������Է�������ʱ�ۿۻ����
                            </td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 100px;">
                                <span id="Span2">ÿ�λ����Ʒ������:</span>
                            </th>
                            <td>
                                <input type="text" id="txtGoodsCount" runat="server" class="tinput" onkeyup="NumTxt_Int(this)"
                                    maxlength="5" />
                                &nbsp;<span check="errormsg" style="color: Red;"></span> <span style="color: Red;">*</span>
                                ÿ�������Է�������ʱ�ۿۻ����
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="btnSub" CssClass="fanh" runat="server" OnClientClick=" return funCheck() "
                    Text="�ύ" OnClick="btnSub_Click" />
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <input type="hidden" id="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
