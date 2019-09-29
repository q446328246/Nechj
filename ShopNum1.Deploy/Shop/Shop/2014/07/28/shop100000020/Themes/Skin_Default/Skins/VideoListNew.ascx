<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="bBoxnt VideoBox">
    <h2>
        <span class="fl">视频列表</span> 
        <span class="VideoSearch" style="display: none; float:right;">视频关键字：
        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSearch" runat="server" Text="" CssClass="search_btn" /></span>
    </h2>
    <div class="content">
        <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
            <p class="nofind">没有找到符合条件的视频</p>
        </asp:Panel>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <div class="fquency">
                    <div class="filmes">
                        <a href='<%# GetPageName.RetUrl("VideoDetail",Eval("Guid"))%>'>
                            <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("ImgAdd")%>' onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" /></a>
                    </div>
                    <p class="voide_name">
                        <a href='<%# GetPageName.RetUrl("VideoDetail",Eval("Guid"))%>'><%# Eval("Title")%></a>
                    </p>
                    <p class="method">播放次数<%#Eval("BroadcastCount")%></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="clear"></div>    
</div>
<!--分页-->
<div class="fenye">
    <div class="lambert">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td><span class="fenye1">共</span></td>
                <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                <td><span class="fenye2">页，到第</span></td>
                <td><asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input"></asp:TextBox></td>
                <td class="fenye_td1"><span class="fenye3">页</span></td>
                <td class="fenye_td2"><asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" /></td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 ">
            <span class="disabled">< </span><span class="current">1</span><a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>
