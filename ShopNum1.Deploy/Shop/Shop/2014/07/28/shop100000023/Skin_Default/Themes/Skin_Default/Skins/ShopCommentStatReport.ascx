<%@ Control Language="C#"  EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>
<%@ Import Namespace="System.Data" %>
<div class="scoring">
    <div class="bBoxnt">
        <div class="storn_hd">
            <h2>店铺动态评分</h2>
        </div>
        <script type="text/javascript" language="javascript">
        $(function(){
            var sc=parseInt($("#hidCharacter").val())-1;
            var st=parseInt($("#hidAttitude").val())-1;
            var ss=parseInt($("#hidSpeed").val())-1;
            document.getElementById("charactershow").innerHTML="<img src=\"Themes/Skin_Default/Images/stars"+sc+".png\" />";
            document.getElementById("attitudeshow").innerHTML="<img src=\"Themes/Skin_Default/Images/stars"+st+".png\" />";
            document.getElementById("speedshow").innerHTML="<img src=\"Themes/Skin_Default/Images/stars"+ss+".png\" />";
         });
     </script>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <div class="courts">
                    <div class="emperor">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="td1">
                                    <p>
                                        描述相符：<input type="hidden" id="hidCharacter" value='<%#Eval("ShopCharacter").ToString()==""?"0":Eval("ShopCharacter").ToString()%>'/>
                                        <%#((DataRowView)Container.DataItem).Row["ShopCharacter"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopCharacter"]%>分</p>
                                    <p>
                                        服务态度：<input type="hidden" id="hidAttitude" value='<%#Eval("ShopCharacter").ToString()==""?"0":Eval("ShopAttitude").ToString()%>'/>
                                        <%#((DataRowView)Container.DataItem).Row["ShopAttitude"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopAttitude"]%>分
                                    </p>
                                    <p>
                                        发货速度：<input type="hidden" id="hidSpeed" value='<%#Eval("ShopCharacter").ToString()==""?"0":Eval("ShopSpeed").ToString()%>'/>
                                        <%#((DataRowView)Container.DataItem).Row["ShopSpeed"].ToString() == string.Empty ? "暂无评论" : ((DataRowView)Container.DataItem).Row["ShopSpeed"]%>分
                                    </p>
                                </td>
                                <td>
                                   <p id="charactershow"><img src="Themes/Skin_Default/Images/stars0.png" /></p>
                                   <p id="attitudeshow"><img src="Themes/Skin_Default/Images/stars0.png" /></p>
                                   <p id="speedshow"><img src="Themes/Skin_Default/Images/stars0.png" /></p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>