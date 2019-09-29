<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            var flat = false;
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    flat = true;
                    ArrayGuid.push("'" + $(this).val() + "'");
                }
            });
            if (flat == false) {
                alert("请选择一项！");
                return;
            } else {
                IsDelete(ArrayGuid.join(","));
            }
        });
    });

    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ZtcApply&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    location.reload();
                    window.location.href = "S_ZtcApply_List.aspx";
                    return false;
                } else {
                    Alert("删除失败！");
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
                    商品名称：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductName" runat="server" CssClass="ss_nr1"></asp:TextBox>
                </td>
                <td align="right" class="ss_nr_spac">
                    类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">申请</asp:ListItem>
                        <asp:ListItem Value="1">充值</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    是否审核：
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:DropDownList ID="DropDownListAuditState" runat="server" CssClass="tselect">
                                    <asp:ListItem Value="-1">-全部-</asp:ListItem>
                                    <asp:ListItem Value="0">未审核</asp:ListItem>
                                    <asp:ListItem Value="1">审核通过</asp:ListItem>
                                    <asp:ListItem Value="2">审核未通过</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" name="12" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div class="shanc">
            <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
        </div>
        <div class="shanc">
            <a href="S_ZtcApply_Edit.aspx" class="shengqing lmf_btn">申请</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th class="th_le" width="4%">
                <input name="checktop" type="checkbox" title="全选" id="checktop" />
            </th>
            <th width="20%">
                商品名称
            </th>
            <th width="10%">
                预交金额
            </th>
            <th width="20%">
                开始时间
            </th>
            <th width="20%">
                申请时间
            </th>
            <th width="10%">
                审核状态
            </th>
            <th width="6%">
                类型
            </th>
            <th width="10%" class="th_ri">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le">
                        <input name="checksub" type="checkbox" class="vcheck" value='<%#Eval("ID") %>' />
                    </td>
                    <td align="left" style="text-align: left;">
                        <%#Utils.GetUnicodeSubString(Eval("ProductName").ToString(), 29, "") %>
                    </td>
                    <td>
                        ￥<%#Eval("Ztc_Money") %>
                    </td>
                    <td>
                        <%#Eval("StartTime") %>
                    </td>
                    <td>
                        <%#Eval("ApplyTime") %>
                    </td>
                    <td>
                        <%#ShopNum1.ShopAdminWebControl.S_ZtcApply_List.shenhe(Eval("AuditState").ToString()) %>
                    </td>
                    <td>
                        <%#Eval("Type").ToString() == "0" ? "申请" : "充值" %>
                    </td>
                    <td class="th_ri">
                        <a href="S_ZtcApply_Detail.aspx?guid=<%#Eval("ID") %>">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <% if (RepeaterShow.Items.Count == 0)
           { %>
        <tr>
            <td colspan="8" class="th_le th_ri">
                <div class="no_datas">
                    <div class="no_data">
                        暂无数据</div>
                </div>
            </td>
        </tr>
        <% } %>
    </table>
    <div class="btntable_tbg">
        <!--分页-->
        <div id="pageDiv" runat="server" class="fy">
        </div>
        <!--分页-->
    </div>
</div>
