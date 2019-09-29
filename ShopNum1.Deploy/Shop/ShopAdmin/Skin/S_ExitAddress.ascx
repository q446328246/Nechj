<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="biaogenr">
    <table width="98%" border="0" cellspacing="0" cellpadding="0" class="blue_tbw" style="margin-top: 20px;">
        <tr>
            <th>
                收货人姓名
            </th>
            <th>
                电子邮件
            </th>
            <th>
                详细地址
            </th>
            <th>
                邮政编码
            </th>
            <th>
                电话/手机号码
            </th>
            <th class="th_ri1">
                操作
            </th>
        </tr>
        <asp:Repeater runat="server" ID="Rep_Address">
            <ItemTemplate>
                <tr style='<%# DataBinder.Eval(Container.DataItem, "IsDefault").ToString() == "1" ? "background:#f3f3f3;": "" %>'>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Email") %>
                    </td>
                    <td style="line-height: 150%;" valign="middle">
                        <%# ShopNum1.AccountWebControl.A_ShipAddress.GetAddressDetil(Eval("Area").ToString(), Eval("Address").ToString()) %>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Postalcode") %>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Mobile") %>
                    </td>
                    <td style="line-height: 150%;" valign="middle" class="th_ri1">
                        <a href='A_AddressOpeater.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                            class="alink_blue">修改</a>
                        <asp:LinkButton ID="LinkButton_delete" runat="server" CssClass="alink_blue" OnClientClick=" return window.confirm('您确定要删除吗?'); "
                            CommandName="delete">删除</asp:LinkButton><br />
                        <asp:HiddenField ID="HiddenField_Guid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Guid") %>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="btntable_t">
    </table>
    <!--分页-->
    <div class="fenye">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_t">
            <tr>
                <td style="border-left: solid 1px #e3e3e3; border-right: none; width: 30px;">
                    &nbsp;
                </td>
                <td style="border-left: none;">
                    <div id="pageDiv" runat="server" class="fy">
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <!--分页-->
</div>
