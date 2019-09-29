<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad_ny">
    <div class="mobanjj">
        <asp:Image ID="ImageCurrentSkin" runat="server" Height="155" Width="139" CssClass="mobanpic" />
        <div class="mbjs">
            <ul>
                <li class="bigblue">当前模板：</li>
                <li>模板文件夹名称：
                    <asp:Label ID="LabelFolderNameValue" runat="server"></asp:Label></li>
                <li>模板名称：
                    <asp:Label ID="LabelNameValue" runat="server"></asp:Label></li>
                <li>模板说明：
                    <asp:Label ID="LabelDescriptionValue" runat="server"></asp:Label></li>
            </ul>
        </div>
    </div>
    <div class="mobantitle">
        可用模板
    </div>
    <table border="0" cellspacing="0" cellpadding="0">
        <asp:Repeater runat="server" ID="Rep_SkinSelect">
            <HeaderTemplate>
                <tr>
            </HeaderTemplate>
            <ItemTemplate>
                <%# (Container.ItemIndex + 1)%5 == 0 ? "</tr><tr>" : "" %>
                <td height="25" align="left" style="padding: 0 18px;">
                    <dl class="mbtp">
                        <dt><a href="#">
                            <asp:Image ID="ImageSkin" ImageUrl='<%# Page.ResolveClientUrl("/Template/ShopTemplate/" + Eval("TemplateImg")) %>'
                                runat="server" Height="139" Width="155" /></a></dt>
                        <dd>
                            <asp:Label ID="LabelSkinNameValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TemplateImg") %>'
                                Visible="false"></asp:Label>
                            <asp:Label ID="LabelName" runat="server" Text="模板名称：" Visible="false"></asp:Label>
                            <asp:Label ID="LabelDescription" runat="server" Text="模板说明：" Visible="false"></asp:Label>
                            <input type="hidden" runat="server" id="hidPath" value='<%# DataBinder.Eval(Container.DataItem, "Path") %>' />
                            <a href='<%# Page.ResolveClientUrl("/Template/ShopTemplate/" + Eval("Path")) %>'>
                                <asp:Label ID="LabelNameValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                            </a>
                        </dd>
                        <dd class="blue" style="font-weight: bold;">
                            <%# Eval("createtime") %></dd>
                        <dd>
                            <table width="150" border="0" cellspacing="0" cellpadding="0" style="margin: 0 auto;">
                                <tr>
                                    <td>
                                        <img src="images/yingy01.gif" width="12" height="11" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonSelect" Style="margin-right: 10px;" runat="server"
                                            CommandName="select">应用</asp:LinkButton>
                                    </td>
                                    <td>
                                        <img src="images/yulan02.gif" width="12" height="11" />
                                    </td>
                                    <td>
                                        <a target="_blank" href='<%# Page.ResolveClientUrl("/Template/ShopTemplate/" + Eval("TemplateImg")) %>'
                                            style="margin-right: 10px;">预览</a>
                                    </td>
                                    <td style="display: none">
                                        <img src="images/shanc03.gif" width="12" height="11" />
                                    </td>
                                    <td style="display: none">
                                        <asp:LinkButton ID="LinkButtonDelete" Style="margin-right: 10px;" runat="server"
                                            CommandName="delete">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </dd>
                    </dl>
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </tr>
            </FooterTemplate>
        </asp:Repeater>
    </table>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
</div>