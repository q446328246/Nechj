<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_MemberApprovalDetailed.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberApprovalDetailed" %>

<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    开户银行：
                </td>
                <td width="190">
                   <asp:TextBox ID="TextBoxBankName" runat="server" class="ss_nr1" MaxLength="32" 
                        ReadOnly="True"></asp:TextBox>
                   
                 
                </td>
                <td align="right">
                    隶属区代：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxAgent" runat="server" class="ss_nr1" MaxLength="32" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    银行帐号：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxaccount_no" runat="server" class="ss_nr1" MaxLength="32" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="right">
                    开户行支行：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxbank_address" runat="server" class="ss_nr1" MaxLength="32" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    开户名：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxaccount_name" runat="server" class="ss_nr1" MaxLength="32" ReadOnly="True"></asp:TextBox>
                </td>
                <td align="right">
                    请求推荐人的用户：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxReferee" runat="server" class="ss_nr1" MaxLength="32" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    安置人：
                </td>
                <td width="190">
                    <asp:TextBox ID="TextBoxPlacement" runat="server" class="ss_nr1" MaxLength="32" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="ButtonUpgrade" runat="server" Text="升级" class="chax btn_spc" name="12"
                        />
                </td>
            </tr>
        </table>
    </div>
