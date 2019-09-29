<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<input type="hidden" name="mName" value="0" />
<asp:Repeater ID="RepeaterShow" runat="server">
<ItemTemplate><input type="hidden" name="mName" value="<%# Eval("MemberName")%>" />
    <p><%# Eval("MemberName")%>在 <span><%# Eval("CreateTime").ToString().Split(' ')[1]%> </span>抢购了它</p>
</ItemTemplate>
</asp:Repeater>
 <script type="text/javascript" language="javascript">
     $(function(){
            if($("input[name='mName']").size()==1)
            {
               $(".whoBuy").hide();
            }
     });
 </script>  
  

