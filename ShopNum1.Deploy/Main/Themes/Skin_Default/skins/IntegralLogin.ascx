<%@ Control Language="C#" %>
<div class="stx clearfix">
    <div class="lhead">
        <a href="/main/member/m_index.aspx" class="headpic">
            <asp:Image ID="ImagePhoto" runat="server" Width="69" Height="69" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
        </a>
        <div class="slogin">
            <asp:Panel ID="PanelDiv" runat="server" Visible="false">
                <p class="tit">
                    登录显示红包情况</p>
                <asp:Button ID="LoginUser" runat="server" Text="会员登录" class="sbtn" />
            </asp:Panel>
            <asp:Panel ID="PanelLogin" runat="server" Visible="false">
                <p class="tit">
                    当前可使用红包</p>
                <p class="tit" style="text-align: center; font-weight: bold;">
                    <asp:Label ID="LabelScore" runat="server" Text="0"></asp:Label>
                </p>
            </asp:Panel>
        </div>
    </div>
    <div class="sul">
        <ul>
            <li><a href="javascript:void(0)">·10万红包勋章会员专享</a></li>
            <li><a href="javascript:void(0)">·领勋章，抽红包，ipad免费送！</a></li>
        </ul>
    </div>
</div>
