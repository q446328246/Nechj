<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="S_PostageSettings.ascx.cs"
    Inherits="ShopNum1.Deploy.Shop.ShopAdmin.Skin.S_PostageSettings" %>
     <div id="content">
        <div style='<%= ShopNum1.Common.Common.ReqStr("type") == "0" || ShopNum1.Common.Common.ReqStr("type") == "" ? "display:block": "display:none" %>'>
            <div class="pad" style="margin-bottom: 0px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                    
                    <tr id="tr_Phone">
                        <td align="right">
                            首重费用(按首重重量)：
                        </td>
                        <td>
                            <asp:TextBox id="Txt_FirstPrice" type="text" maxlength="11" runat="server" class="textwb" />元
                        </td>
                    </tr>
                    <tr id="tr1">
                        <td align="right">
                            超重费用(按每千克算)：
                        </td>
                        <td>
                            <asp:TextBox id="Txt_AfterPrice" type="text" maxlength="11" runat="server" class="textwb" />元
                        </td>
                    </tr>
                    <tr id="tr2">
                        <td align="right">
                            首重重量：
                        </td>
                        <td>
                            <asp:TextBox id="Txt_FirstHeavy" type="text" maxlength="11" runat="server" class="textwb" />克
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                            <asp:Button ID="Btn_OK" runat="server" Text="确定" CssClass="baocbtn" 
                                onclick="Btn_OK_Click" style="height: 30px" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>