<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript">
    function kf_close() {
        $("#master").hide();
    }
</script>
<!--底部在线客服-->
<asp:Panel ID="PanelShowServer" runat="server">
    <table id="master" cellpadding="0" cellspacing="0" border="0" class="online">
        <tr>
            <td>
                <p>
                    <img height="37" width="146" src="/Main/Themes/Skin_Default/Images/kefu_2.png" /></p>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="kefu_info">
                <table cellpadding="0" cellspacing="0">
                    <asp:Panel ID="PanelQQ" runat="server">
                        <tr>
                            <td>
                                <div class="panelQQ">
                                    <p class="QQtitle">
                                        <a href="javascript:list('tr1');">
                                            <img height="25" src="/Main/Themes/Skin_Default/Images/qqbg.jpg" /></a></p>
                                    <div id="tr1">
                                        <asp:Repeater EnableViewState="False" ID="RepeaterQQ" runat="server">
                                            <ItemTemplate>
                                                <p class="onsever">
                                                    <a href="tencent://message/?uin=<%#((DataRowView)Container.DataItem).Row["ServiceAccount"]%>&Site=shopnum1&Menu=yes">
                                                        <img src="/Main/Themes/Skin_Default/Images/QQB.gif" />
                                                        <asp:Label ID="Label1" ForeColor="#621800" Font-Size="" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"] %>'></asp:Label>
                                                    </a>
                                                </p>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelWW" runat="server">
                        <tr>
                            <td>
                                <div class="panelWW">
                                    <p class="WWtitle">
                                        <a href="javascript:list('tr4');">
                                            <img height="35" src="/Main/Themes/Skin_Default/Images/wangwangkef.jpg" /></a></p>
                                    <div id="tr4">
                                        <asp:Repeater EnableViewState="False" ID="RepeaterWW" runat="server">
                                            <ItemTemplate>
                                                <p class="onsever">
                                                    <a target="_blank" href='http://www.taobao.com/webww/ww.php?spm=a1z10.1.w6612080-4892696461.1.s3EjFr&ver=3&touid=<%#((DataRowView)Container.DataItem).Row["ServiceAccount"]  %>&site=cntaobao&status=2&charset=utf-8'
                                                        style="text-decoration: none">
                                                        <img src="http://amos.im.alisoft.com/online.aw?v=2&uid=1212121212&site=cntaobao&s=1&charset=utf-8"
                                                            alt='<%#((DataRowView)Container.DataItem).Row["Name"]  %>' />
                                                        <asp:Label ID="Label1" ForeColor="#621800" Font-Size="" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["Name"]  %>'
                                                            Visible="false">
                                                        </asp:Label></a>
                                                </p>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelPhone" runat="server">
                        <tr>
                            <td>
                                <div class="panelPhone">
                                    <p class="kefu_phone">
                                        <a href="javascript:list('tr3');"></a>
                                        <asp:Label ID="Lab_ServerPhone" ForeColor="#621800" Font-Size="" runat="server"></asp:Label></p>
                                </div>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </td>
            <td valign="top" class="OnlineImg">
                <img onclick="expand()" height="139" id="menu" width="32" src="../Main/Themes/Skin_Default/Images/kefu_1.gif"
                    original="../Main/Themes/Skin_Default/Images/kefu_1.png" />
            </td>
        </tr>
    </table>
</asp:Panel>
<script type="text/javascript" src='<%=ResolveUrl(Globals.SkinPath+"/js/footonlineservice.js") %>'></script>
<script language="javascript">
    var obj;
    function list(cs1) {

        obj = document.getElementById(cs1);

        if (obj) {

            if (obj.style.display == 'none') {
                obj.style.display = '';
            }
            else {
                obj.style.display = 'none';
            }
        }

    }



    function OpenKFT(url) {
        //打开对话框
        window.open(url, '在线客服', ' left=200,top=100, height=475, width=700, toolbar=no, menubar=no, scrollbars=no, resizable=no, location=no, status=no');
    }
</script>
