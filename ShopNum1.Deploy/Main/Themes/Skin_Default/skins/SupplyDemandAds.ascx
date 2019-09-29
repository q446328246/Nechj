<%@ Control Language="C#" %>
<div style="display: block;" class="supply_demand_left">
    <img src="" runat="server" id="ImgAdv" width="222" height="300" />
    <div class="supply_demand_left_list">
        <ul>
            <asp:Repeater ID="RepeaterContent" runat="server">
                <ItemTemplate>
                    <li style='<%# RepeaterContent.Items.Count==0?"background: #8c6249": "" %>' onmouseover="document.getElementById('<%=ImgAdv.ClientID %>').src='<%# Page.ResolveClientUrl("/"+Eval("content").ToString()) %>'">
                        <a href="javascript:void(0)">·<%# ShopNum1.Common.Utils.GetUnicodeSubString(Eval("explain").ToString(),28,"")%></a></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>
