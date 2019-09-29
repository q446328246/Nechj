<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<div class="warp clearfix">
    <div id="left">
        <div class="mod1" id="HelpCenter">
            <div class="title clearfix">
                <span class="left"></span><span class="right"></span>
                <div class="fl">
                    帮助中心</div>
            </div>
            <div class="content" style="overflow: hidden">
                <asp:DataList ID="DataListHelpList" runat="server" RepeatColumns="1" BorderWidth="0"
                    Width="100%">
                    <ItemTemplate>
                        <dl>
                            <dt>
                                <asp:HiddenField ID="HiddenFieldGuid" runat="server" Visible="False" Value='<%#((DataRowView)Container.DataItem).Row["Guid"] %>' />
                                &nbsp;<%#((DataRowView)Container.DataItem).Row["Name"]%>
                            </dt>
                            <asp:Repeater ID="RepeaterHelp" runat="server">
                                <ItemTemplate>
                                    <dd>
                                        <a href='<%# "HelpList.aspx?guid=" +DataBinder.Eval(Container.DataItem,"Guid")+"&AgentLoginID=" +Page.Request.QueryString["AgentLoginID"] %>'
                                            target="_self">
                                            <%# ((DataRowView)Container.DataItem).Row["Title"]%></a></dd>
                                </ItemTemplate>
                            </asp:Repeater>
                        </dl>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <!--this is the end-->
    </div>
    <!--rRight start-->
    <div id="right">
        <div id="HelpTitle clearfix">
            <asp:Repeater ID="RepeaterRemark" runat="server">
                <ItemTemplate>
                    <%# Server.HtmlDecode(Eval("Remark").ToString()) %>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
