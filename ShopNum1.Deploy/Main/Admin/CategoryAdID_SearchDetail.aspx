<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdID_SearchDetail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdID_SearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������λ�鿴��ϸ</title>
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
                    ������λ�鿴��ϸ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λID��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxID" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>��������λID</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λ���ƣ�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCategoryAdName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span>��������λ����</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λ����ҳ��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCategoryType" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>��������λ����ҳ</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λ��ȣ�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxWidth" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>��������λ���</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λ�߶ȣ�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxHeight" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>��������λ�߶�</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 120px;">
                            ���λĬ��ͼƬ��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 120px;">
                            <asp:Image ID="ImageAdDefalutPic" Height="100" Width="200" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λĬ�����ӣ�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdDefalutLike" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <span>��������λĬ������</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λ������
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdflow" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>��ÿ�죩
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="border-bottom: none;">
                            ���λ����������
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="border-bottom: none;">
                            <asp:TextBox ID="TextBoxvisitPeople" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>��ÿ�죩
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            �Ƿ���ʾ��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:CheckBox ID="CheckBoxIsShow" Checked="true" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 120px;">
                            ��ע��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 120px;">
                            <asp:TextBox ID="TextBoxIntroduce" TextMode="MultiLine" Height="100px" Width="500px"
                                CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                            <span>�����뱸ע����</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="�����б�" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
