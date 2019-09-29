<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdvertisement_SearchDetail.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdvertisement_SearchDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������鿴��ϸ</title>
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
                    ������鿴��ϸ</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ������ƣ�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxPageName" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                            <span>������������</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λ��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListAdPageName" Enabled="false" AutoPostBack="true"
                                CssClass="tselect" runat="server" Width="180px" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                <asp:ListItem Value="1">��Ʒ����</asp:ListItem>
                                <asp:ListItem Value="2">������Ϣ����</asp:ListItem>
                                <asp:ListItem Value="3">�������</asp:ListItem>
                                <asp:ListItem Value="4">���̷���</asp:ListItem>
                                <asp:ListItem Value="5">��Ѷ����</asp:ListItem>
                                <asp:ListItem Value="6">Ʒ�Ʒ���</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListAdID" Enabled="false" AutoPostBack="true" runat="server"
                                CssClass="tselect" Width="180px" OnSelectedIndexChanged="DropDownListAdID_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���λID��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxCategoryAdID" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                            <span>��������λID</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            �����ࣺ
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListCategory1" Width="180" Enabled="false" AutoPostBack="true"
                                CssClass="tselect" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCategory2" Width="180" Enabled="false" AutoPostBack="true"
                                CssClass="tselect" runat="server" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCategory3" Width="180" Enabled="false" runat="server"
                                CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���Ĭ��ͼƬ��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxDefaultPic" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <img id="ImageOriginalImge2" alt="" src="" runat="server" />
                            <span>��������Ĭ��ͼƬ</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ������ڵ�ͼƬ��
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxNowPic" ReadOnly="true" CssClass="tinput" runat="server"></asp:TextBox>
                            <img id="ImgNowPic" alt="" src="" runat="server" />
                            <span>�����������ڵ�ͼƬ</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���Ĭ������
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxDefaultLikeAddress" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>��������Ĭ������</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ������ڵ����ӣ�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxNowLikeAddress" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>�����������ڵ�����</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���۸�
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdPrice" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>��������۸�</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���������
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdflow" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>��ÿ�죩
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            ���������
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:TextBox ID="TextBoxAdIntroduce" ReadOnly="true" MaxLength="200" CssClass="tinput"
                                runat="server"></asp:TextBox>
                            <span>������������</span>
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
                            <asp:CheckBox ID="CheckBoxIsShow" Enabled="false" Checked="true" runat="server" />
                            <span>��ѡ��</span>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            �Ƿ���
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:DropDownList ID="DropDownListIsBuy" Width="180" Enabled="false" runat="server"
                                CssClass="tselect">
                                <asp:ListItem Selected="True" Value="0">δ����</asp:ListItem>
                                <asp:ListItem Value="1">�ѹ���</asp:ListItem>
                            </asp:DropDownList>
                            <span>��ѡ��</span>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" CssClass="fanh" runat="server" Text="�����б�" OnClick="ButtonBack_Click" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" Value="-1" runat="server" />
    <asp:HiddenField ID="HiddenFieldCategoryCode" Value="-1" runat="server" />
    </form>
</body>
</html>
