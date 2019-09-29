<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="list_main">
    <ul id="sidebar">
        <li class='<%= ShopNum1.Common.Common.ReqStr("type") == "0" || ShopNum1.Common.Common.ReqStr("type") == "" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_OnLineServiceList.aspx?type=0" style="text-decoration: none;">客服管理</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("type") == "1" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_OnLineServiceList.aspx?type=1" style="text-decoration: none;">客服列表</a></li>
    </ul>
    <div id="content">
        <div style='<%= ShopNum1.Common.Common.ReqStr("type") == "0" || ShopNum1.Common.Common.ReqStr("type") == "" ? "display:block": "display:none" %>'>
            <div class="pad" style="margin-bottom: 0px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                    <tr>
                        <th align="right" width="150">
                            左边客服：
                        </th>
                        <td>
                            <input name="" type="checkbox" value="" checked="checked" runat="server" id="checkbox_QQ" />
                            QQ
                            <input name="" type="checkbox" value="" runat="server" id="checkbox_WW" />
                            在线旺旺
                            <input name="" type="checkbox" value="" runat="server" id="checkbox_Phone" />
                            服务电话
                        </td>
                    </tr>
                    <tr id="tr_Phone">
                        <td align="right">
                            服务电话：
                        </td>
                        <td>
                            <input id="txt_Phone" type="text" maxlength="11" runat="server" class="textwb" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            在线客服是否开启：
                        </td>
                        <td>
                            <input name="rad_onff" type="radio" value="1" checked="checked" onclick=" sel_open() "
                                id="radioOff1" />
                            开启
                            <input name="rad_onff" type="radio" value="0" onclick=" sel_close() " id="radioOff0" />
                            关闭
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                            <asp:Button ID="Btn_OK" runat="server" Text="确定" CssClass="baocbtn" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style='<%= ShopNum1.Common.Common.ReqStr("type") == "0" || ShopNum1.Common.Common.ReqStr("type") == "" ? "display:none": "display:block" %>'>
            <div class="shangpinkj">
                <div class="btntable_tbg">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                        <tr>
                            <td width="4%" class="check_td">
                                <input name="fx" type="checkbox" value="" id="checkboxAll" />
                            </td>
                            <td width="6%" style="border-right: none; padding-left: 10px; text-align: left;">
                                全选
                            </td>
                            <td width="90%">
                                <div class="shanc">
                                    <asp:LinkButton ID="LinkDelete" CssClass="shanchu lmf_btn" runat="server">批量删除
                                    </asp:LinkButton>
                                </div>
                                <div class="fy" style="float: left;">
                                    <a href="S_OnLineServiceOperate.aspx" class="tianjiafl lmf_btn">添加客服</a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <table cellspacing="0" cellpadding="0" border="0" class="blue_tb2" width="100%">
                    <tr>
                        <th width="6%" class="th_le">
                        </th>
                        <th width="10%">
                            客服类型
                        </th>
                        <th width="24%">
                            客服名称
                        </th>
                        <th width="20%">
                            客服账号
                        </th>
                        <th width="10%">
                            是否显示
                        </th>
                        <th width="10%">
                            排序号
                        </th>
                        <th width="10%" class="th_ri">
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="RepeaterShow" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" name="subcheck" />
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "TypeName") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "ServiceAccount") %>
                                </td>
                                <td>
                                    <%# ShopNum1.ShopAdminWebControl.S_OnLineServiceList.IsShow(DataBinder.Eval(Container.DataItem, "IsShow")) %>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem, "OrderID") %>
                                </td>
                                <td>
                                    <a href='S_OnLineServiceOperate.aspx?guid=<%# DataBinder.Eval(Container.DataItem, "Guid") %>'
                                        class="alink_blue">编辑</a>
                                    <asp:LinkButton ID="LinkButton_delete" runat="server" CssClass="alink_blue" OnClientClick=" return window.confirm('您确定要删除吗?'); "
                                        CommandName="delete">删除</asp:LinkButton>
                                    <input id="HiddenField_Guid" type="hidden" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "Guid") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                        <ItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <div class="no_datas">
                                        <div class="no_data">
                                            <%# DataBinder.Eval(Container.DataItem, "NoValue") %></div>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <asp:HiddenField ID="hid_SelectGuid" runat="server" />
                <input id="hid_OnOff" type="hidden" runat="server" />
                <!--分页-->
                <div class="btntable_tbg">
                    <div id="pageDiv" runat="server" class="fy">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        var sextype = $("#S_OnLineServiceList_ctl00_hid_OnOff").val();
        if (sextype == "1") {
            $("#radioOff1").attr("checked", "true");
        } else {
            $("#radioOff0").attr("checked", "true");
        }
    });
</script>
<script type="text/javascript" language="javascript">
    function sel_open() {
        $("#S_OnLineServiceList_ctl00_hid_OnOff").val("1");
    }

    function sel_close() {
        $("#S_OnLineServiceList_ctl00_hid_OnOff").val("0");
    }
</script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#checkboxAll").click(function () {
            $("input[name='subcheck']").attr("checked", $(this).is(":checked"));
        });
        //批量删除
        $(".shanchu").click(function () {
            if (confirm("是否执行批量删除操作？")) {
                var arryid = new Array();
                var bflag = false;
                $("input[name='subcheck']").each(function () {
                    if ($(this).is(":checked")) {
                        arryid.push("'" + $(this).val() + "'");
                        $("#S_OnLineServiceList_ctl00_hid_SelectGuid").val(arryid);
                        bflag = true;
                    }

                });
                if (!bflag) {
                    alert("请选择需要删除的在线客服！");
                    return false;
                }

            } else {
                return false;
            }
        });
    })

</script>
