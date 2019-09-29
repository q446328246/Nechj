<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_OrderScoreList.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_OrderScoreList" %>
<script type="text/javascript" language="javascript">
    //    $(function(){
    //            //批量删除操作
    //            $(".shanchu").click(function(){
    //                var ArrayGuid=new Array();
    //                $("input[name='checksub']").each(function(){
    //                        if($(this).is(":checked")){
    //                        ArrayGuid.push("'"+$(this).val()+"'");}
    //                }); 
    //                IsDelete(ArrayGuid.join(","));
    //            });
    //         });
    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $("input[type='checkbox']").removeAttr("checked");
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ScoreOrderInfo&delid=" + val, null, function (data) {
                if (data == "ok") { alert("删除成功！"); location.reload(); return false; }
                else { alert("删除失败！"); return false; }
            });
        }
    }

    $(function () {
        $("#checktop").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="list_main">
    <ul class="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="all"||ShopNum1.Common.Common.ReqStr("st")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_OrderScoreList.aspx?st=all">全部</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_OrderScoreList.aspx?st=0&OderStatus=0">未处理</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("st")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="M_OrderScoreList.aspx?st=2&OderStatus=1">已处理</a></li>
    </ul>
    <div id="content" class="ordmain">
        <div class="pad">
            <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                <tr class="up_spac">
                    <td align="right">
                        订单编号：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxOrderNumber" runat="server" CssClass="ss_nr1"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="btntable_tbg">
            <div class="shanc">
                <a href="#" class="shanchu lmf_btn">批量删除</a>
            </div>
        </div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="blue_tb2">
            <tr>
                <th class="th_le" width="4%">
                    <input name="checktop" type="checkbox" title="全选" id="checktop" />
                </th>
                <th width="21%">
                    订单单号
                </th>
                <th width="20%">
                    下单时间
                </th>
                <th width="25%">
                    商品总红包
                </th>
                <th width="10%">
                    订单状态
                </th>
                <th class="th_ri" width="10%">
                    <span id="OrderPanic6">操作</span>
                </th>
            </tr>
            <asp:Repeater ID="RepeaterOrderNew" runat="server">
                <ItemTemplate>
                    <tr>
                        <td scope="col">
                            <input name="checksub" type="checkbox" value='<%#Eval("Guid")%>' />
                        </td>
                        <td scope="col">
                            <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                        </td>
                        <td scope="col">
                            <%#DataBinder.Eval(Container.DataItem, "CreateTime")%>
                        </td>
                        <td scope="col">
                            <%#DataBinder.Eval(Container.DataItem, "TotalScore")%>
                        </td>
                        <td scope="col">
                            <%#Eval("OderStatus").ToString() == "1" ? "已处理" : "未处理"%>
                        </td>
                        <td scope="col">
                            <a href="M_OrderScoreDetailed.aspx?guid=<%#Eval("Guid")%>">查看</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <%if (RepeaterOrderNew.Items.Count == 0)
              { %>
            <tr>
                <td colspan="6" style="height: 16px;">
                    <div class="no_data">
                        暂无数据</div>
                </td>
            </tr>
            <% }%>
        </table>
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
        <!--分页-->
    </div>
</div>
