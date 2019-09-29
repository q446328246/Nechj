<%@ Control Language="C#" EnableViewState="false"%>

<script language="javascript" type="text/javascript">
    function reloadcode(){
    var verify=document.getElementById('Img1');
    verify.setAttribute('src','imagecode.aspx?'+Math.random());
    }
</script>
<div class="bBoxnt">
    <h2>我要评论</h2>
    <div class="content NewsDiscuss">
        <table width="100%" border="0" cellpadding="3">
            <tr>
                <td align="right">
                    用户名：
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxMemLoginID" ReadOnly="true"  ValidationGroup="comment" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style=" display:none">
                <td align="right">
                    评论等级：
                </td>
                <td align="left">
                    <asp:RadioButton ID="RadioButton1" runat="server" GroupName="gp1" Checked="True" />
                   <asp:HyperLink ID="HyperLink5" runat="server" ImageUrl="../images/stars4.gif" />
                    <asp:RadioButton ID="RadioButton2" runat="server" GroupName="gp1" />
                   <asp:HyperLink ID="HyperLink3" runat="server" ImageUrl="../images/stars2.gif" />
                    <asp:RadioButton ID="RadioButton3" runat="server" GroupName="gp1" /> 
                    <asp:HyperLink ID="HyperLink2" runat="server" ImageUrl="../images/stars1.gif" />
                    <asp:RadioButton ID="RadioButton4" runat="server" GroupName="gp1" />
                    <asp:HyperLink ID="HyperLink4" runat="server" ImageUrl="../images/stars3.gif" />
                    <asp:RadioButton ID="RadioButton5" runat="server" GroupName="gp1" />
                     <asp:HyperLink ID="HyperLink1" runat="server" ImageUrl="../images/stars0.gif" />
                    
                </td>
            </tr>
            <tr style=" display:none">
                <td align="right">
                    评论标题：
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxTitle" ValidationGroup="comment" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    评论内容：
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxContent" runat="server" Height="60px" TextMode="MultiLine" Width="440px"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxContent"
                        Display="Dynamic" ValidationGroup="comment" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="VerifyCode" runat="server">
                <td align="right">
                    <asp:Localize ID="LocalizeCode" runat="server" Text="验证码："></asp:Localize>
                </td>
                <td align="left">
                    <asp:TextBox ID="TextBoxCode" runat="server" CssClass="allinput1"
                        onkeydown="if(event.keyCode==13){(document.getElementById('ShopArticleCommentAdd1_ctl00_ButtonConfirm')).focus();(document.getElementById('ShopArticleCommentAdd1_ctl00_ButtonConfirm')).click();}"></asp:TextBox>
                    <img src="imagecode.aspx?javascript:Math.random()" id="Img1" border="0" onclick="reloadcode()" style="vertical-align:middle;"
                        alt="看不清?点一下" />
                    <a onclick="reloadcode()">看不清楚?点一下</a>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="left">
                    <asp:Button ID="ButtonConfirm" ValidationGroup="comment" Text="确定" runat="server"
                        CssClass="bnt1" />
                </td>
            </tr>
        </table>
    </div>
</div>