<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_UpPayPwdSucceed.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_UpPayPwdSucceed" %>
<div class="zhszmian1" style="padding-left: 15px;">
    <ul class="mimbz">
        <li class="bztwo">1.��֤���ֻ�</li>
        <li class="bztwo" id="setPwd">2.���ý������� </li>
        <li class="bzone" id="setSuccess">3.���óɹ� </li>
    </ul>
</div>
<div style="clear: both;">
</div>
<div class="masznr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <th scope="row" width="25%">
                ����ǰ���ʺţ�
            </th>
            <td>
                <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>
                <span>�����������óɹ� </span>
            </td>
        </tr>
        <tr>
            <th scope="row">
                &nbsp;
            </th>
            <td>
                <input type="button" class="querbtn" value="��ȫ����" onclick="showLoction()" />
                <asp:Button ID="btn_Retrun" Visible="false" runat="server" Text="��ȫ����" OnClientClick="return showLoction()"
                    CssClass="querbtn" PostBackUrl="/Main/Account/A_PwdSer.aspx" />
            </td>
        </tr>
    </table>
</div>
<script type="text/javascript" language="javascript">
    function showLoction() {
        location.href = "A_PwdSer.aspx";
    }
</script>
