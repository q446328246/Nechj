<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopWebControl" %>

<script language="javascript" type="text/javascript">
<!--
    function reloadcode(){
    var verify=document.getElementById('Img1');
    verify.setAttribute('src','imagecode.aspx?'+Math.random());
    }
//-->
</script>

<script>
    function funMainTitle()
    {
        var title=$("#MessageBoardAdd_ctl00_TextBoxTitle").val();
        var content=$("#MessageBoardAdd_ctl00_TextBoxContent").val();
        var vcode=$("#MessageBoardAdd_ctl00_TextBoxCode").val();
        if(title=="")
        {
            alert("主题不能为空！");
            return false;
        }
        if(content=="")
        {
            alert("评论内容不能为空！");
            return false;
        }
        if(vcode=="")
        {
            alert("验证码不能为空！");
            return false;
        }
        return true;
    }
    function funButonCheck()
    {
         if(funMainTitle())
         {
            return true;
         } 
         return false;
    }
</script>

<div class="bBox bBoxnt">
    <h2>我要留言：</h2>
    <div class="content">
        <asp:Panel ID="PanelAdd" runat="server">
            <div class="accretion">
                <table width="100%" border="0" cellpadding="10">
                    <tr style="display: none;">
                        <td align="right"></td>
                        <td><asp:Label ID="LabelMemLoginID" runat="server" Visible="false"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label class="spenel">主&nbsp;&nbsp;题：</label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxTitle" ValidationGroup="MessageBoard" CssClass="inpt_cont" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelTitle" runat="server" Text="*" ForeColor="red"></asp:Label>
                             
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label class="spenel">留言类型：</label>
                        </td>
                        <td align="left">
                            <div class="mold">
                                <asp:RadioButtonList ID="RadioButtonListmessageType" runat="server" RepeatColumns="6">
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <label class="spenel">留言内容：</label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxContent" CssClass="inpt_cont" runat="server" Height="60px" TextMode="MultiLine" Width="440px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr id="VerifyCode" runat="server">
                        <td align="right">
                            <asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="TextBoxCode" runat="server" CssClass="inpt_cont" onkeydown="if(event.keyCode==13){(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).focus();(document.getElementById('MessageBoardAdd_ctl00_ButtonConfrim')).click();}"></asp:TextBox>
                            <img src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()" alt="看不清?点一下" style="cursor: pointer;" />
                            <a style="cursor: pointer" onclick="reloadcode()">看不清楚?点一下</a>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td align="left">
                            <asp:Button ID="ButtonConfrim" OnClientClick="return funButonCheck()"   runat="server" Text="" CssClass="bntonts" />
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="PanelOut" runat="server">
            <div class="pada">
                请先
                <asp:LinkButton ID="LinkButtonLogin" runat="server">登录</asp:LinkButton>或
                <asp:LinkButton ID="LinkButtonRegister" runat="server">注册</asp:LinkButton>再留言
            </div>
        </asp:Panel>
    </div>
</div>
