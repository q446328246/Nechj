<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
function kf_close(){
$("#master").hide();
}
</script>

<!--底部在线客服-->
<asp:Panel ID="PanelShowServer" runat="server">
    <table id="master" cellpadding="0" cellspacing="0" border="0" class="online">
        <tr>
            <td><img height="37" width="146" src="/Main/Themes/Skin_Default/Images/kefu_2.png" /></td>
            <td>&nbsp;</td>
        </tr>      
        <tr>
            <td class="kefu_info">
                <table cellpadding="0" cellspacing="0">
                  <asp:Panel ID="PanelQQ" runat="server">
                    <tr style=" overflow:hidden">
                        <td>
                            <div class="kefu_info_list">
                                <p class="pQQ">
                                    <a href="javascript:list('tr1');"><img height="25" src="/Main/Themes/Skin_Default/Images/qqbg.jpg" /></a>
                                </p>
                                <div id="tr1" style="display:none">
                                    <asp:Repeater EnableViewState="False" ID="RepeaterQQ" runat="server">
                                        <ItemTemplate>
                                            <p class="onsever">
                                                <a href="http://wpa.qq.com/msgrd?V=1&Uin=<%#((DataRowView)Container.DataItem).Row["ServiceAccount"]  %>&Menu=yes" target="_blank">
                                                    <img height="15" src="/Main/Themes/Skin_Default/Images/QQB.gif" />
                                                    <asp:Label ID="Label1" ForeColor="#621800" Font-Size="" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["Name"]  %>'></asp:Label></a></p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </td>
                    </tr>
                   </asp:Panel>
                  <asp:Panel ID="PanelWW" runat="server">
                    <tr style=" overflow:hidden">
                        <td>
                            <div class="kefu_info_list">
                                <p class="pWW">
                                    <a href="javascript:list('tr4');"><img height="35" src="/Main/Themes/Skin_Default/Images/wangwangkef.jpg" /></a>
                                </p>
                                <div id="tr4" style="display: none;">
                                    <asp:Repeater EnableViewState="False" ID="RepeaterWW" runat="server">
                                        <ItemTemplate>
                                            <p class="onsever">
                                                <a target="_blank" href='http://amos1.taobao.com/msg.ww?v=2&uid=<%#((DataRowView)Container.DataItem).Row["ServiceAccount"]  %>&s=1'>
                                                    <img src="/Main/Themes/Skin_Default/Images/amos.gif" />
                                                <asp:Label ID="Label1" ForeColor="#621800" Font-Size="" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["Name"]  %>'></asp:Label></a>
                                            </p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </td>
                    </tr>
                     </asp:Panel>
                  <asp:Panel ID="PanelPhone" runat="server" >
                    <tr style="overflow:hidden">
                        <td>
                             <div class="kefu_info_list">
                             <p class="kefu_phone">
                    <asp:Label ID="Lab_Phone" runat="server" Text="Label"></asp:Label>
                                          </p>
                         <%--     
                                <div id="tr3" style="display: none;">
                                    <asp:Repeater EnableViewState="False" ID="RepeaterPH" runat="server">
                                        <ItemTemplate>
                                           <p class="onsever">
                                                <asp:Label ID="Label1" ForeColor="#621800" Font-Size="" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["serviceaccount"]  %>'></asp:Label>
                                           </p>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>--%>
                            </div>
                        </td>
                    </tr>
                   </asp:Panel>
                </table>
            </td>
            <td valign="top" style="padding-top: 4px;">
                <img onclick="expand()" height="139" id="menu" width="32" src="/Main/Themes/Skin_Default/Images/kefu_1.gif"
                    original="/Main/Themes/Skin_Default/Images/kefu_1.png" />
            </td>
        </tr>
    </table>

    <script type="text/javascript" src='<%=ResolveUrl(Globals.SkinPath+"/js/footonlineservice.js") %>'></script>

    <script language="javascript">
		var obj;
function list(cs1)
{
         
  obj=document.getElementById(cs1);
 
  if (obj)
  {
     
     if (obj.style.display=='none')
      {
         obj.style.display='';
      }
     else
      {
       obj.style.display='none';
      }
  }
 
}



function OpenKFT(url){
//打开对话框
 window.open(url, '在线客服', ' left=200,top=100, height=475, width=700, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
}
    </script>

</asp:Panel>
