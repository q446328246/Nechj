<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>


    
           <img src="Themes/Skin_Default/Images/2010-08-04_112953.gif" /><span style="font-size: 14px;
                    font-weight: bold; position: relative; top: -4px;">&nbsp 商品评论</span>
  <div style="border: 1px solid #E0E0E0; background:#F4F4F4; padding: 8px;">
        <asp:Repeater ID="RepeaterStat" runat="server">
            <ItemTemplate>
                <table width="80%" style="border: 1px solid #ccc; margin: 0 auto; padding: 10px">
                    <tr>
                        <td class="title">
                            宝贝与描述相符
                        </td>
                        <td class="count">
                        <img id="c1" src="Themes/Skin_Default/Images/icon_star_1.gif" style="cursor:pointer" />
                        <img id="c2" src="Themes/Skin_Default/Images/icon_star_1.gif" style="cursor:pointer" />
                        <img id="c3" src="Themes/Skin_Default/Images/icon_star_1.gif" style="cursor:pointer" />
                        <img id="c4" src="Themes/Skin_Default/Images/icon_star_1.gif" style="cursor:pointer" />
                        <img id="c5" src="Themes/Skin_Default/Images/icon_star_1.gif" style="cursor:pointer" />
                        <asp:HiddenField ID="hc" runat="server" value='<%# ProductCommentList.SetNoNull(Eval("Characteravg"))%>'  /> 
                            <%# ProductCommentList.SetNoNull(Eval("Characteravg"))%>分
                        </td>
                    </tr>
                </table>
                <span class="fr" style="margin: 10px; font-weight: bold"> 共有<%# Eval("Allnum")%>评论</span>
            </ItemTemplate>
        </asp:Repeater>
        <table cellpadding="0" cellspacing="1" width="100%" style="color: #333; font-weight: bold;
            margin: 0 auto; background: #dedede">
            <tr class="MemberTr">
                <td align="center" width="80%">
                    评论
                </td>
                <td align=" center" width="20%">
                    评价人
                </td>
            </tr>
        </table>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <table cellpadding="0" cellspacing="1" width="100%" style="border-bottom: 1px solid #ccc;
                    margin: 0 auto; color: #333">
                    <tr>
                        <td align="left" width="80%">
                            <%# Eval("Comment")%>
                            <p style="color: #999999">
                                <%# Eval("CommentTime")%></p>
                        </td>
                        <td align="left" width="20%">
                            <%# DataBinder.Eval(Container.DataItem, "MemberName")%>
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
      
 

<!-- 分页部分-->
<div class="pager">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
<script language="javascript" type="text/javascript">
    for(var i=1;i<6;i++) {
        var img = document.getElementById("c"+i);
        if(i<=document.getElementById("ProductCommentList_ctl00_RepeaterStat_ctl00_hc").value) {
            img.src="Themes/Skin_Default/Images/icon_star_2.gif";
        }
        else {
            img.src="Themes/Skin_Default/Images/icon_star_1.gif";
        }
    }
</script>