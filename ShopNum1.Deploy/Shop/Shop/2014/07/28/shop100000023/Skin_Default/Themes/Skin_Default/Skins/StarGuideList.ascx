<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="ks_panel" style="padding-bottom: 5px;">
    <div class="storn_hd">
        <h3>
            店铺导购员</h3>
    </div>
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="1">
                <tr>
                    <td bgcolor="#FFFFFF">
                        <div style="border: #cccccc 1px solid; width: 100px; height: 120px; padding: 2px;">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Height="120px"
                                onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" Width="100px" />
                        </div>
                    </td>
                    <td valign="top" align="left" style="line-height: 25px; padding: 5px;">
                        导购员：<%# Eval("Name")%><br />
                        简介：<%# Eval("Remark")%>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
</div>
