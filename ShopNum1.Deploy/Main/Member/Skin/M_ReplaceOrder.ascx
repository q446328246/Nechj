<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_ReplaceOrder.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ReplaceOrder" %>

<script type="text/javascript" language="javascript">
    $(function () {
        //搜索
        $("#sk").click(function () {
            
            location.href = "M_ReplaceAll.aspx?sd=" + $("#txtstartdate").val() + "&ed=" + $("#txtenddate").val();
        });
    });
</script>
<div id="Div2">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">

            <tr class="up_spac">
                <td align="right">时间：
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <input value='<%=ShopNum1.Common.Common.ReqStr("sd") %>' name="startdate" type="text"
                                    id="txtstartdate" class="ss_nrduan" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" />
                            </td>
                            <td class="line_spac">-
                            </td>
                            <td>
                                <input value='<%=ShopNum1.Common.Common.ReqStr("ed") %>' name="enddate" type="text"
                                    id="txtenddate" class="ss_nrduan" onclick="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" />
                            </td>
                        </tr>
                    </table>
                </td>

                <td>
                    <input name="sk" id="sk" type="button" class="chax btn_spc" value="查询" />
                </td>
            </tr>
        </table>
    </div>

    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th>时间
            </th>
            <th>设备号
            </th>
            <th>里程
            </th>
            <th>车辆类型
            </th>
            <th>获得新能源链
            </th>
            
        </tr>
        <asp:Repeater runat="server" ID="RepeaterShow">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "CreateTime")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Device_no")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Mil")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "CarTypeName")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "GetMoney")%>
                    </td>
                    
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="6" style="height: 16px;">
                <div class="no_data">
                    暂无数据
                </div>
            </td>
        </tr>
        <% }%>
    </table>
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <script type="text/javascript">
            <!--
    var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
    //-->
    </script>
</div>
