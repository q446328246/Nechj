<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopProductComment_Detail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopProductComment_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ʒ������ϸ</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ��Ʒ������ϸ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            ������Ʒ��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ������Ʒ</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �����ˣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMenLoginID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ����ʱ�䣺
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCommentTime" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ����ʱ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���۵ȼ���
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCommentType" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ���۵ȼ�</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �����ٶȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSpeed" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                �����ٶ�</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ����̬�ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAttitude" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ����̬��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��������������ȣ�
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCharacter" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox><span>
                                ���������������</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �ظ�ʱ�䣺
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxReplyTime" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox><span>
                                �ظ�ʱ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="height: 115px;">
                            �������ݣ�
                        </th>
                        <td style="height: 115px;">
                            <asp:TextBox ID="TextBoxComment" TextMode="MultiLine" ReadOnly="true" runat="server"
                                CssClass="tinput txtarea"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" style="border-bottom: none; height: 115px;">
                            �ظ����ݣ�
                        </th>
                        <td style="border-bottom: none; height: 115px;">
                            <asp:TextBox ID="TextBoxReply" TextMode="MultiLine" CssClass="tinput txtarea" ReadOnly="true"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="�����б�" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
