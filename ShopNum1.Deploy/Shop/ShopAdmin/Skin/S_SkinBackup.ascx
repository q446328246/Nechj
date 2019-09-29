<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad_ny">
    <div class="mobanjj">
        <asp:Image ID="ImageCurrentSkin" runat="server" Width="155" Height="139" CssClass="mobanpic" />
        <div class="mbjs">
            <ul>
                <li class="bigblue">当前模板</li>
                <li>模板压缩包名称：
                    <asp:Label ID="LabelFolderNameValue" runat="server"></asp:Label></li>
                <li>模板名称：
                    <asp:Label ID="LabelNameValue" runat="server"></asp:Label></li>
                <li>模板说明：
                    <asp:Label ID="LabelDescriptionValue" runat="server"></asp:Label></li>
            </ul>
            <p>
                <asp:LinkButton ID="LinkButton_BackUp" runat="server" CssClass="backupbtn lmf_btn">&nbsp;&nbsp;&nbsp;备份当前模板</asp:LinkButton>
            </p>
        </div>
    </div>
    <div class="mobantitle">
        可恢复模板
    </div>
    <table border="0" cellspacing="0" cellpadding="0">
        <asp:Repeater runat="server" ID="RepeaterShow">
            <HeaderTemplate>
                <tr>
            </HeaderTemplate>
            <ItemTemplate>
                <%# (Container.ItemIndex)%4 == 0 ? "</tr><tr>" : "" %>
                <td height="25" align="left" style="padding: 0 18px;">
                    <dl class="mbtp">
                        <dt><a href="#">
                            <img src='<%# DataBinder.Eval(Container.DataItem, "SkinImage") %>' width="155" height="139" /></a></dt>
                        <dd>
                            <asp:Label ID="LabelNameValue" runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                        </dd>
                        <dd class="blue" style="font-weight: bold;">
                            <asp:Label ID="LabelCreateTime" runat="server" Text='  <%# DataBinder.Eval(Container.DataItem, "createTime") %>'></asp:Label>
                        </dd>
                        <dd>
                            <table width="150" border="0" cellspacing="0" cellpadding="0" style="margin: 0 auto;">
                                <tr>
                                    <td>
                                        <img src="images/mobantb.gif" width="14" height="14" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonSelect" runat="server" CommandName="select" CssClass="lmf_l">恢复模板</asp:LinkButton>
                                    </td>
                                    <td>
                                        <img src="images/sctb.gif" width="14" height="14" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButtonDel" runat="server" CommandName="delete" CssClass="lmf_r"
                                            OnClientClick=" return confirm('是否确认删除?') ">删除模板</asp:LinkButton>
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
</div>
