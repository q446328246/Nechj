<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<script type="text/javascript">
 function OperateCa(dobj,isout)
 {
 if(!isout)
 {
  $(dobj).next().attr("style","display:block;");
// $(dobj).next.show();
  }
  else
  {
  if($(dobj).next().onmouseover
   $(dobj).next().attr("style","display:none;");
// $(dobj).next.hide();
  }
 }
</script>
<div class="store_category_view">
    <div class="all_top">
        <div class="all_top_title">
            商品分类</div>
    </div>
    <div class="content clearfix">
        <asp:Repeater ID="RepeaterData" runat="server">
            <ItemTemplate>
                <div class="store_category_view_list">
                    <div class="store_category_title" onmouseover="OperateCa(this,false)" onmouseout="OperateCa(this,true)">
                        <a href='<%#ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"])%>'>
                            <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                            >></a></div>
                    <div style="display: none" onmouseout="this.style.display='none';" onmousemove="this.style.display='block';">
                        <asp:Repeater ID="RepeaterChild" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="store_category_detail store_category_detailon" onmouseover="OperateCa1(this,false)"
                                    onmouseout="OperateCa1(this,true)" style="font-weight: bold; margin-left: 6px;">
                                    <a href='<%#ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"])%>'>
                                        <%# ((DataRowView)Container.DataItem).Row["Name"]%>
                                    </a>
                                </div>
                                <div class="store_category_detail" onmouseout="this.style.display='none';" onmousemove="this.style.display='block';"
                                    style="margin-left: 8px; background: none; display: none;">
                                    <asp:Repeater ID="RepeaterthreeChild" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <a href='<%#ShopUrlOperate.RetUrl("productlist",((DataRowView)Container.DataItem).Row["Code"])%>'>
                                                <%# ((DataRowView)Container.DataItem).Row["Name"]%></a>
                                            <asp:Literal ID="LiteralLine" runat="server">|</asp:Literal>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <asp:HiddenField ID="HiddenFieldFID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <asp:HiddenField ID="HiddenFieldCID" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["ID"] %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
