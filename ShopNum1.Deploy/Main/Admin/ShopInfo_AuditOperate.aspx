<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopInfo_AuditOperate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopInfo_AuditOperate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������˲���</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <span id="Span1">
                        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="������ϸ"></asp:Label></span></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="1" border="0">
                    <tr>
                        <th align="right">
                            �������ƣ�
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxName" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            �������ƣ�
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopName" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            �������
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopType" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            ���̷��ࣺ
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopCategory" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            ��Ӫ��Ʒ��
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxMainGoods" ReadOnly="true" CssClass="allinput3 tinput" runat="server"
                                TextMode="MultiLine" Width="300" Height="60"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right" width="20%">
                            ���۷�Χ��
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxSalesRange" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
            <th align="right">
                �����ʼ���
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxEmail" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <tr>
                        <th align="right">
                            �������룺
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxTel" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �ֻ����룺
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPhone" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �������룺
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPostalCode" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���֤��ţ�
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxIdentityCard" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                      <tr>
                        <th align="right">
                            �Ƽ��ˣ�
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxReferral" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
            <th align="right">
                ע��ţ�
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxRegistrationNum" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                ��ҵ���ƣ�
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxCompanName" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                ���˴���
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxLegalPerson" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                ע���ʱ���
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxRegisteredCapital" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>

��Ԫ
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                Ӫҵ���ޣ�
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxBusinessTerm" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <%--<tr>
            <th align="right">
                Ӫҵ��Χ��
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxBusinessScope" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
            </td>
        </tr>--%>
                    <tr style="display: none">
                        <th align="right">
                            ��ϵ��ַ��
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddress" ReadOnly="true" CssClass="allinput3 tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���ڵ�����
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddressValue" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��ϸ��ַ��
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddressDeteil" ReadOnly="true" CssClass="allinput3 tinput"
                                runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���֤����������
                        </th>
                        <td align="left">
                            <a runat="server" target="_blank" id="aCardImage1">
                                <asp:Image ID="ImageCardImage1" runat="server" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                    Height="187px" Width="191px" class="fanh" /></a>
                        </td>
                    </tr>
                    <%--<tr>
            <th align="right">
                ֤��ͼƬ��������
            </th>
            <td align="left">
                <a runat="server" target="_blank" id="aCardImage2">
                    <asp:Image ID="ImageCardImage2" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                        runat="server" Height="178px" Width="190px" /></a>
            </td>
        </tr>--%>
                    <asp:Panel ID="PanelShowBusinessLicense" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                Ӫҵִ�գ�
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aBusinessLicense">
                                    <asp:Image ID="ImageBusinessLicense" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelTaxRegistrationtr" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                ˰��Ǽ�֤��
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aTaxRegistrationtr">
                                    <asp:Image ID="ImageTaxRegistrationtr" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelOrganization" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                ��֯�������룺
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aOrganization">
                                    <asp:Image ID="ImageOrganization" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
                <div class="tablebtn">
                    <asp:Button ID="ButtonBank" runat="server" Text="�����б�" CssClass="fanh" OnClick="ButtonBank_Click" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
