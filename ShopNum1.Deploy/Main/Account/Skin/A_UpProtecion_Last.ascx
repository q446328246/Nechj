<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_UpProtecion_Last.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_UpProtecion_Last" %>
<div class="masznr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <th scope="row">
                &nbsp;
            </th>
            <td ">
                <p style="color: Red; text-align: center;">
                    <asp:Label Text="" runat="server" ID="lableShow" /></p>
            </td>
        </tr>
        <tr>
         <th scope="row">
                &nbsp;
            </th>
            
        </tr>
        <tr>
            <th scope="row">
                &nbsp;
            </th>
            <td align="center" style=" top:10px;">
                <asp:Button ID="Button_Affirm" runat="server" Text="确认" OnClick="Button_Affirm_Click"
                    CssClass="querbtn" />
                <asp:Button ID="Button_Cancel" runat="server" Text="取消" OnClick="Button_Cancel_Click"
                    CssClass="querbtn" />
            </td>
        </tr>
    </table>
</div>
