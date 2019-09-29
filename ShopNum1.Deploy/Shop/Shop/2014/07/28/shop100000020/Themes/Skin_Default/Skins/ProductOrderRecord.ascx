<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="aBox11 clearfix">
    <div class="content">
        <div class="RecordNum">
            <span id="spanOrderCount" runat="server"></span>
        </div>
        <table cellpadding="0" cellspacing="1" width="100%" class="OrderRecord_th">
            <tr class="MemberTr">
                <td align="left" width="20%">买家</td>
                <td align=" left" width="30%">宝贝名称</td>
                <td align="left" width="10%">出价</td>
                <td align="left" width="10%">购买数量</td>
                <td align="left" width="20%">付款时间</td>
                <td align="left" width="10%" style="display:none;">状态</td>
            </tr>
        </table>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="1" width="100%" class="OrderRecord_con">
                    <tr>
                        <td align="left" width="20%">
                            <%# ((DataRowView)Container.DataItem).Row["MemLoginID"].ToString()==string.Empty?"匿名":((DataRowView)Container.DataItem).Row["MemLoginID"]%>
                        </td>
                        <td align="left" width="30%">
                            <%# ((DataRowView)Container.DataItem).Row["ProductName"]%>
                            <br />
                            <%# ((DataRowView)Container.DataItem).Row["SpecificationName"]%>
                        </td>
                        <td align="left" width="10%">
                            <%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%>元
                        </td>
                        <td align="left" width="10%">
                            <%# ((DataRowView)Container.DataItem).Row["BuyNumber"]%>
                        </td>
                        <td align="left" width="20%">
                            <%# ((DataRowView)Container.DataItem).Row["PayTime"]%>
                        </td>
                        <td align="left" width="10%" style="display:none;">
                            <%#ProductOrderRecord.ChangeOperateType(((DataRowView)Container.DataItem).Row["PaymentStatus"].ToString())%>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <FooterTemplate>
                <!-- ********* FooterTemplate.Start ************* //-->
                <!-- ********* FooterTemplate.End ************* //-->
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function(){
            $("select[name='selectPage']").change(function(){
        location.href="http://"+location.hostname+"/productdetail.html?Page="+$(this).find("option:selected").val()+"&guid=<%=Request.QueryString["guid"] %>";
            });
    });
</script>
<!-- 分页部分-->
<div class="pager">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到<asp:Literal ID="lnkTo" runat="server" />页</span>
</div>
