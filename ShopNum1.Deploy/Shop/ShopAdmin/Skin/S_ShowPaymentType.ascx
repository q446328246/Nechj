<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <table cellspacing="0" cellpadding="0" border="0" class="blue_tb2" width="100%">
            <tr>
                <th width="130" class="th_le">
                    名称
                </th>
                <th width="500">
                    插件说明
                </th>
                <th width="80">
                    启用
                </th>
                <th width="80" class="th_ri">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Name") %>
                        </td>
                        <td style="text-align: left;">
                            <%#Eval("Memo") %>
                        </td>
                        <td>
                            <asp:Label ID="LabelRun" runat="server" Text='<%#Eval("PaymentType") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenFieldType" runat="server" Value='<%#Eval("PaymentType") %>' />
                            <asp:Button ID="runbutton" runat="server" Text="安装" CssClass="dele" OnClientClick=" return messageBox($(this).val()) " />
                            <a href='S_DeployPayment.aspx?run=edit&type=<%#eval("PaymentType") %>' class="blue"
                                runat="server" id="pzcj" style="display: block;">配置插件</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <script type="text/javascript">
    <!--
        var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
    //-->
    </script>
</div>
