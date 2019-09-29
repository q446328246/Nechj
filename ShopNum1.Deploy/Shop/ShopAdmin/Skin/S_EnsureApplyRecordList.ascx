<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="pad" style="margin-top: -20px;">
    <p class="wkttsfw">
        开通的消费者保障服务</p>
    <asp:Repeater runat="server" ID="Rep_EnsureApply">
        <ItemTemplate>
            <div class="xiaofbz">
                <table width="95%" border="0" cellspacing="0" cellpadding="0" class="baoz">
                    <tr>
                        <td rowspan="3" width="30" valign="top">
                            <img src='<%#ShopNum1.ShopAdminWebControl.S_EnsureApplyRecordList.GetImg(DataBinder.Eval(Container.DataItem, "ImagePath")) %>'
                                width="20" height="23" />
                        </td>
                        <td class="tdtit">
                            <span style="float: right;" class="orange">保证金额度：<%# DataBinder.Eval(Container.DataItem, "EnsureMoney") %>元
                            </span><span class="tit">
                                <%# DataBinder.Eval(Container.DataItem, "Name") %></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Remark") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <p class="wkttsfw">
        未开通的消费者保障服务</p>
    <asp:Repeater runat="server" ID="Rep_EnsureNoApply">
        <ItemTemplate>
            <div>
                <table width="95%" border="0" cellspacing="0" cellpadding="0" class="baoz">
                    <tr>
                        <td rowspan="3" width="30" valign="top">
                            <img src='<%#ShopNum1.ShopAdminWebControl.S_EnsureApplyRecordList.GetImg(DataBinder.Eval(Container.DataItem, "ImagePath")) %>'
                                width="21" height="25" />
                        </td>
                        <td class="tdtit">
                            <span style="float: right;" class="orange">保证金额度：<%# DataBinder.Eval(Container.DataItem, "EnsureMoney") %>元</span><span
                                class="tit"><%# DataBinder.Eval(Container.DataItem, "Name") %></span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Remark") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_Open" runat="server" Text='<%#ShopNum1.ShopAdminWebControl.S_EnsureApplyRecordList.GetStatus(Eval("IsAudit").ToString(), Eval("IsPayMent").ToString(), Eval("ID").ToString(), Eval("ShopID").ToString(), "0") %>'
                                CssClass="sqjdbzj" CommandName="open" />
                            <input id="hid_Open" type="hidden" runat="server" value=' <%# DataBinder.Eval(Container.DataItem, "ID") %>' />
                            <input id="hid_Type" type="hidden" runat="server" value='<%#ShopNum1.ShopAdminWebControl.S_EnsureApplyRecordList.GetStatus(Eval("IsAudit").ToString(), Eval("IsPayMent").ToString(), Eval("ID").ToString(), Eval("ShopID").ToString(), "1") %>' />
                            <input id="hid_Guid" type="hidden" runat="server" value=' <%# DataBinder.Eval(Container.DataItem, "Guid") %>' />
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
