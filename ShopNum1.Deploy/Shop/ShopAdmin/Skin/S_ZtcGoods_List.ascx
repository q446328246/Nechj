<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            var falt = false;
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    falt = true;
                    ArrayGuid.push("'" + $(this).val() + "'");
                }
            });
            if (falt == false) {
                alert("请选择一项！");
            } else {
                IsDelete(ArrayGuid.join(","));
            }
        });
    });

    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ZtcGoods&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    location.reload();
                    window.location.href = "S_ZtcGoods_List.aspx";
                    return false;
                } else {
                    alert("删除失败！");
                    return false;
                }
            });
        }
    }

    $(function () {
        $("#checktop").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    直通车名称：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="ss_nr1"></asp:TextBox>
                </td>
                <td align="right" class="ss_nr_spac">
                    状态：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListState" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">请选择</asp:ListItem>
                        <asp:ListItem Value="1">开启</asp:ListItem>
                        <asp:ListItem Value="0">关闭</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" name="12" />
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div class="shanc">
            <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th class="th_le" width="4%">
                <input name="checktop" type="checkbox" title="全选" id="checktop" />
            </th>
            <th width="10%">
                直通车名称
            </th>
            <th>
                图片
            </th>
            <th>
                剩余金额
            </th>
            <th>
                开始时间
            </th>
            <th>
                商品价格
            </th>
            <th>
                销售价格
            </th>
            <th>
                销售数量
            </th>
            <th>
                显示状态
            </th>
            <th>
                状态
            </th>
            <th class="th_ri" width="10%">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le">
                        <input name="checksub" type="checkbox" class="vcheck" value='<%# Eval("ID") %>' />
                    </td>
                    <td>
                        <a target="_blank" href='<%#ShopUrlOperate.shopHref(((DataRowView) Container.DataItem).Row["ProductGuid"].ToString(), ((DataRowView) Container.DataItem).Row["MemberID"].ToString()) %>'
                            class="tjimga" style="line-height: 18px;">
                            <%#Utils.GetUnicodeSubString(Eval("ZtcName").ToString(), 26, "") %>
                        </a>
                    </td>
                    <td width="60">
                        <asp:Image ID="ImageProduct" runat="server" Width="60" Height="60" ImageUrl='<%#Eval("ZtcImg") %>'
                            onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                    </td>
                    <td width="60">
                        <%#Eval("Ztc_Money").ToString() %>
                    </td>
                    <td width="66" style="line-height: 18px;">
                        <%# DataBinder.Eval(Container.DataItem, "StartTime") %>
                    </td>
                    <td width="60">
                        <%# DataBinder.Eval(Container.DataItem, "ProductPrice") %>
                    </td>
                    <td width="60">
                        <%# DataBinder.Eval(Container.DataItem, "SellPrice") %>
                    </td>
                    <td width="60">
                        <%# DataBinder.Eval(Container.DataItem, "SellCount") %>
                    </td>
                    <td width="60">
                        <%#ShopNum1.ShopAdminWebControl.S_ZtcGoods_List.Expire(Eval("StartTime").ToString(), Eval("Ztc_Money").ToString()) == "余额不足" ? "<font color=red>余额不足</font>" : ShopNum1.ShopAdminWebControl.S_ZtcGoods_List.Expire(Eval("StartTime").ToString(), Eval("Ztc_Money").ToString()) %>
                    </td>
                    <td width="30">
                        <%#Eval("State").ToString() == "1" ? "开启" : "<span color=red>关闭</span>" %>
                    </td>
                    <td class="th_ri" width="66" style="line-height: 18px;">
                        <a href="S_ZtcGoods_Operate.aspx?ID=<%#Eval("ID") %>">编辑</a> <a href="S_ZtcGoodsAddMoney_Operate.aspx?ID=<%#Eval("ID") %>">
                            续费</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <% if (RepeaterShow.Items.Count == 0)
           { %>
        <tr>
            <td colspan="11" class="th_le th_ri">
                <div class="no_datas">
                    <div class="no_data">
                        暂无数据</div>
                </div>
            </td>
        </tr>
        <% } %>
    </table>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
