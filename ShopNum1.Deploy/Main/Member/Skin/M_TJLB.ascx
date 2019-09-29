<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_TJLB.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_TJLB" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //搜索
        $("#sk").click(function () {

            location.href = "M_TJLB.aspx?sd=" + $("#txtstartdate").val() + "&ed=" + $("#txtenddate").val();
        });
    });
</script>
<div id="Div2">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">

            <tr class="up_spac">
                <td width="70%"></td>
                <td>您目前已经推荐了<span style="color: red"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>人!</td>
            </tr>
        </table>
    </div>

    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tb2">
        <tr>
            <th>账号
            </th>
            <th>电话
            </th>
            <th>姓名
            </th>
            <th>推荐时间
            </th>



        </tr>
        <asp:Repeater runat="server" ID="RepeaterShow">
            <ItemTemplate>
                <tr>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "MemLoginID")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Mobile")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "RealName")%>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "RegeDate")%>
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
