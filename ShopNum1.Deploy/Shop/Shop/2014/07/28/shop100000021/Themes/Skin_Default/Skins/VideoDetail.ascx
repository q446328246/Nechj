<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div class="fquen_cont clearfix">
    <asp:Repeater ID="RepeaterData" runat="server">
        <ItemTemplate>
            <div class="frequen_tp">
                <h2><span><%# Eval("Title")%></span></h2>
                <div class="content clearfix">
                    <script>document.write('<%# VideoDetail.GetVideo(Eval("VideoAdd "), "524", "702")%>')</script>
                </div>
            </div>
            <div class="frequen_con">            
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="td1" colspan="3">标题：<%# Eval("Title")%></td>
                    </tr>
                    <tr >
                        <td class="td2">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImgAdd")%>' Width="100" onerror="javascript:this.src='Themes/Skin_Default/Images/noImage.gif'" Height="100" />
                        </td>
                        <td class="td3" colspan="2">
                            时　间：<span><%# Eval("CreateTime")%></span><br /> 
                            分类名：<a href='<%# GetPageName.RetUrl("VideoList", "guid="+Eval("CategoryGuid"))%>'><%# Eval("Name")%></a><br />
                            简　介：<%# Server.HtmlDecode(Eval("Content").ToString())%>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td colspan="3">
                            标签：<%# Eval("KeyWords")%>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="3"></td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="clear"></div>
</div>
