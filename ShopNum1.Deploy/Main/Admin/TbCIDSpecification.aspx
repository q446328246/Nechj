<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbCIDSpecification.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.TbCIDSpecification" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�����Ա�������</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<!--�Ա����� -->
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �Ա������б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table>
                    <tr type="taobao">
                        <td colspan="2">
                            <div class="htweb_top">
                                <div class="toptitle">
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="ListBoxTop" runat="server" Style="overflow: auto" Height="210px"
                                        Width="189px" CssClass="tinput" AutoPostBack="true" OnSelectedIndexChanged="ListBoxTop_SelectedIndexChanged">
                                        <asp:ListItem Value="1">��Ϸ����           -></asp:ListItem>
                                        <asp:ListItem Value="2">��װЬ��           -></asp:ListItem>
                                        <asp:ListItem Value="3">�ֻ�����           -></asp:ListItem>
                                        <asp:ListItem Value="4">���õ���           -></asp:ListItem>
                                        <asp:ListItem Value="5">��ױ��Ʒ           -></asp:ListItem>
                                        <asp:ListItem Value="6">ĸӤ��Ʒ           -></asp:ListItem>
                                        <asp:ListItem Value="7">�Ҿӽ���           -></asp:ListItem>
                                        <asp:ListItem Value="8">�ٻ�ʳƷ           -></asp:ListItem>
                                        <asp:ListItem Value="9">�˶�����           -></asp:ListItem>
                                        <asp:ListItem Value="10">�Ļ�����           -></asp:ListItem>
                                        <asp:ListItem Value="11">�������           -></asp:ListItem>
                                        <asp:ListItem Value="12">����           -></asp:ListItem>
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox1" runat="server" Style="overflow: auto" Height="210px" Width="189px"
                                        CssClass="tinput" OnSelectedIndexChanged="lbox1_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox2" runat="server" Height="210px" Width="189px" Visible="false"
                                        CssClass="tinput" AutoPostBack="true" OnSelectedIndexChanged="lbox2_SelectedIndexChanged">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox3" runat="server" Style="overflow: auto:" Height="210px" Width="189px"
                                        CssClass="tinput" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="lbox3_SelectedIndexChanged">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox4" runat="server" Height="210px" Visible="false" Width="189px"
                                        CssClass="tinput" OnSelectedIndexChanged="lbox4_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:ListBox>
                                </div>
                                <div class="topk" style="float: left; margin-right: 10px;">
                                    <asp:ListBox ID="lbox5" runat="server" Style="overflow: auto:" Height="210px" Width="189px"
                                        CssClass="tinput" Visible="false"></asp:ListBox>
                                </div>
                            </div>
                            <!-- ���� -->
                            <div class="gk">
                            </div>
                        </td>
                    </tr>
                </table>
                <div style="margin-top: 20px;">
                    <asp:Button ID="ButtonCatetory" CssClass="fanh" runat="server" Text="�������" OnClick="ButtonCatetory_Click" /><span
                        style="color: Red">ע�⣺�������ֻ��ѡ��һ�����ർ��!</span>
                    <asp:Button ID="Button1" CssClass="fanh" runat="server" Text="������" OnClick="Button1_Click" />
                    <span style="color: Red">ע�⣺����������Ҫѡ����׼����࣬������Ӧ�Ա������µĹ������ԡ�</span>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
