<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_MemberUpgrade1.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberUpgrade1" %>
<div id="content" class="ordmain1">
    <div class="pad">
    <asp:Label ID="Name" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="RealName" runat="server" Text="" Visible="false"></asp:Label>
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    开户银行：
                </td>
                <td width="190">
                    <asp:DropDownList ID="TextBoxbank" runat="server" class="ss_nr1">
                        <asp:ListItem Value="农业银行">农业银行</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    服务网点：
                </td>
                 
                <td width="190">
                    <asp:DropDownList ID="DropDownListLiShu" runat="server" class="ss_nr1">
                    </asp:DropDownList>
                </td>

            </tr>
            <tr class="up_spac">
                <td align="right">
                    银行帐号：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxaccount_no" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right">
                    开户行名称：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxbank_address" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    开户名：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxaccount_name" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td align="right">
                    销售商：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxReferee" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    服务商：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxPlacement" runat="server" class="ss_nr1" MaxLength="32"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonUpgrade" runat="server" Text="申请" class="chax btn_spc" name="12"
                        OnClick="ButtonUpgrade_Click" />
                </td>
            </tr>
        </table>
    </div>
</div>

