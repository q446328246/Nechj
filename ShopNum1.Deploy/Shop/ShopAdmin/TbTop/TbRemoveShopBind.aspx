<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbRemoveShopBind.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbRemoveShopBind" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">ɾ����</span></p>
                <div class="pad divheig leftp" style="padding-left: 30px;">
                    <div style="margin-top: 10px;">
                        <asp:LinkButton ID="ButtonRemoveAdmin" runat="server" Text="ɾ���Ա����̰�" OnClientClick=" return confirm('���иõ��̵���Ʒ�ͷ���ȶ�����ɾ����\n\t�Ƿ�ȷ��ɾ����') "
                                        OnClick="ButtonRemoveAdmin_Click" CssClass="shancbtn">ɾ���Ա����̰�</asp:LinkButton>
                    </div>
                    <ul class="scbdul">
                        <li class="ultit">ɾ���󶨺�������Ϣ�ᱻɾ��</li>
                        <li>1. ���̵ĵ�����Ϣ</li>
                        <li>2. ���̵���Ʒ��Ϣ����Ʒ����</li>
                        <li>3. ���̵Ķ�����Ϣ</li>
                        <li>4. ���̵Ļ�Ա��Ϣ</li>
                    </ul>
                </div>
            </div>
        </form>
    </body>
</html>