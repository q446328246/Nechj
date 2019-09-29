<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_ShipAddress.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_ShipAddress" %>
<div class="list_main1">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbw" style="margin-top: 20px;">
        <tr>
            <th style="border-left: solid 1px #e3e3e3;" width="5%">
            </th>
            <th width="10%">
                收货人
            </th>
            <th width="25%">
                详细地址
            </th>
            <th>
                邮政编码
            </th>
            <th>
                电话
            </th>
            <th>
                手机号码
            </th>
            <th>
                电子邮件
            </th>
            <th class="th_ri1">
                操作
            </th>
        </tr>
        <asp:Repeater runat="server" ID="Rep_Address" onitemcommand="Rep_Address_ItemCommand">
            <ItemTemplate>
                <tr style='<%# DataBinder.Eval(Container.DataItem, "IsDefault").ToString()=="1"?"background:#f3f3f3;": "" %>'>
                    <td align="center" class="tb_left">
                        <span runat="server" visible="false" id="guid">
                            <%# DataBinder.Eval(Container.DataItem, "Guid") %></span>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </td>
                    <td style="line-height: 150%;" valign="middle">
                        <%# ShopNum1.AccountWebControl.A_ShipAddress.GetAddressDetil(Eval("AddressValue").ToString(),Eval("Address").ToString())%>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Postalcode") %>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Tel") %>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Mobile") %>
                    </td>
                    <td align="center">
                        <%# DataBinder.Eval(Container.DataItem, "Email") %>
                    </td>
                    <td style="line-height: 150%;" valign="middle" class="th_ri1">
                        <a href='A_AddressOpeater.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                            class="alink_blue">修改</a>
                        <asp:LinkButton ID="LinkButton_delete" runat="server" CssClass="alink_blue" OnClientClick="return window.confirm('您确定要删除吗?');"
                            CommandName="delete">删除</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton_defalut" runat="server" CssClass="alink_blue" CommandName="defalut">                        <%#Eval("IsDefault").ToString()=="1"?"[取消默认地址设置]":"[设为默认地址]" %>
                        </asp:LinkButton>
                        <asp:HiddenField ID="HiddenField_Guid" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Guid")%>' />
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
            <ItemTemplate>
                <tr>
                    <td style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;"
                        colspan="8">
                        <div class="no_data">
                            <%# DataBinder.Eval(Container.DataItem, "NoValue")%></div>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <!--分页-->
    <div class="fenye">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_t">
            <tr>
                <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
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
