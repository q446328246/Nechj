<%@ Control Language="C#" %>
<style type="text/css">
    .style1
    {
        width: 197px;
    }
    .style2
    {
        width: 404px;
    }
    .style3
    {
        width: 401px;
    }
</style>
<script language="javascript" type="text/javascript">
<!--
    function reloadcode() {
        var verify = document.getElementById('safecode');
        verify.setAttribute('src', 'imagecode.aspx?' + Math.random());
    }



    function cansubmit() {
        if (Page_ClientValidate()) {
            if (document.getElementById("<%= DropDownListQuestion.ClientID %>").value == "-1" && document.getElementById("<%= TextBoxQuestion.ClientID %>").value == "") {
                document.getElementById("divQuestion").style.display = "block";
                document.getElementById("divQuestion").innerHTML = "请填写答案";
                return false;
            }
            else {
                if (document.getElementById("<%= DropDownListQuestion.ClientID %>").value == "0") {
                    document.getElementById("divQuestion").style.display = "block";
                    document.getElementById("divQuestion").innerHTML = "请选择问题";
                    return false;
                }
                else {
                    document.getElementById("divQuestion").style.display = "none";
                    return true;
                }
            }
        }
    }
//-->
</script>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="conttn">
    <table cellpadding="4" cellspacing="0" border="0" width="100%">
        <tr>
            <td colspan="3">
                <div class="cont">
                    <img src="Themes/Skin_Default/Images/so3.gif" />帐号密码填写</div>
            </td>
        </tr>
        <tr>
            <td align="right" width="200">
                用户名：
            </td>
            <td class="style3">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBoxMemLoginID" runat="server" AutoPostBack="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                            ErrorMessage="用户名必填项" ControlToValidate="TextBoxMemLoginID" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorMemLoginID" runat="server"
                            ErrorMessage="用户名格式不正确" ControlToValidate="TextBoxMemLoginID" Display="Dynamic"
                            ValidationExpression="^[a-zA-Z0-9_]{3,24}$"></asp:RegularExpressionValidator>
                        <asp:Label ID="LabelMemLoginIDStatic" runat="server" Text="Label" Style="display: none;
                            color: #3333cc;"></asp:Label>
                        <br />
                        <%--                        <asp:Button ID="ButtonConfirmMemberID" runat="server" CausesValidation="False" CssClass="botton1"
                            Text="检测用户名" />--%>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="3-24个英文字母或数字下划线" ForeColor="#3333CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                用户密码：
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password" Width="150"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorPwd" runat="server" ErrorMessage="密码不能为空"
                    ControlToValidate="TextBoxPwd" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd" runat="server"
                    ErrorMessage="密码格式不正确" ControlToValidate="TextBoxPwd" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{6,32}$"></asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="6-32个英文字母或数字，字母区分大小写" ForeColor="#3333CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                确认密码：
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxRePwd" runat="server" TextMode="Password" Width="150"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorRePwd" runat="server" ErrorMessage="密码必须一致"
                    ControlToValidate="TextBoxRePwd" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidatorPwd" runat="server" ControlToCompare="TextBoxPwd"
                    ControlToValidate="TextBoxRePwd" ErrorMessage="两次密码输入不一致"></asp:CompareValidator>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="6-32个英文字母或数字，字母区分大小写" ForeColor="#3333CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                电子邮箱：
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="200"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxEmail"
                    Display="Dynamic" ErrorMessage="邮箱必须填写"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail"
                    Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                提示问题：
            </td>
            <td class="style3">
                <asp:DropDownList ID="DropDownListQuestion" runat="server" CssClass="regist_input1">
                    <asp:ListItem Value="0">选择密码保护问题</asp:ListItem>
                    <asp:ListItem Value="我妈妈的名字是什么？">我妈妈的名字是什么？</asp:ListItem>
                    <asp:ListItem Value="我爸爸的名字是什么？">我爸爸的名字是什么？</asp:ListItem>
                    <asp:ListItem Value="我的出生地在哪？">我的出生地在哪？</asp:ListItem>
                    <asp:ListItem Value="我爱人的名字是什么？">我爱人的名字是什么？</asp:ListItem>
                    <asp:ListItem Value="我爱人的生日是什么？">我爱人的生日是什么？</asp:ListItem>
                    <asp:ListItem Value="我初中学校校名是什么？">我初中学校校名是什么？</asp:ListItem>
                    <asp:ListItem Value="我妈妈的生日是什么？">我妈妈的生日是什么？</asp:ListItem>
                    <asp:ListItem Value="我外公名字是什么？">我外公名字是什么？</asp:ListItem>
                    <asp:ListItem Value="-1">自定义问题</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="TextBoxQuestion" runat="server" Style="display: none"></asp:TextBox>
                <div id="divQuestion" style="display: none; color: Red;">
                </div>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="非常重要您可以用它来找回您的密码" ForeColor="#3333CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                提示答案：
            </td>
            <td class="style3">
                <asp:TextBox ID="TextBoxAnswer" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxAnswer"
                    Display="Dynamic" ErrorMessage="答案不能为空"></asp:RequiredFieldValidator>
            </td>
            <td>
            </td>
        </tr>
    </table>
</div>
<div class="conttn">
    <table cellpadding="4" cellspacing="0" border="0" width="100%">
        <tr>
            <td colspan="3">
                <div class="cont">
                    <img src="Themes/Skin_Default/Images/so5.gif" />店铺信息填写</div>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                店铺名称：
            </td>
            <td class="style2">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TextBoxShopName" runat="server" AutoPostBack="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorShopName" runat="server" ControlToValidate="TextBoxShopName"
                            Display="Dynamic" ErrorMessage="店铺名称必须填写"></asp:RequiredFieldValidator>
                        <asp:Label ID="LabelShopNameStatic" runat="server" Text="Label" Style="display: none;
                            color: #3333cc"></asp:Label>
                        <%--                        <asp:Button ID="ButtonConfirmShopName" runat="server" CausesValidation="False" CssClass="botton1"
                            Text="检测店铺名" />--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <font color="#3333CC">注册店铺请填写工商局注册的全称</font>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                <asp:Label ID="Label2" runat="server" Text="店标："></asp:Label>
            </td>
            <td align="left" class="style2">
                <asp:TextBox ID="TextBoxBanner" runat="server"></asp:TextBox>
                <font color="red">
                    <asp:Label ID="Label8" runat="server" Text="*"></asp:Label>不填为默认图片</font>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" class="style1">
                店铺类别：
            </td>
            <td class="style2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DropDownListShopCategoryCode1" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListShopCategoryCode2" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListShopCategoryCode3" runat="server">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidatorShopCategoryCode1" runat="server" ControlToValidate="DropDownListShopCategoryCode1"
                            Display="Dynamic" ErrorMessage="此项为必填项" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                经营范围：
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxSalesRange" runat="server" TextMode="MultiLine" Height="80px"
                    Width="300px"></asp:TextBox>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                店铺地区：
            </td>
            <td class="style2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListRegionCode3" runat="server" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:DropDownList ID="DropDownListRegionCode4" runat="server">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidatorRegionCode1" runat="server" ControlToValidate="DropDownListRegionCode1"
                            Display="Dynamic" ErrorMessage="所在地必须选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                详细地址：
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxAddress" runat="server" Width="228px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress"
                    Display="Dynamic" ErrorMessage="详细地址必填项"></asp:RequiredFieldValidator>
            </td>
            <td>
                <font color="#3333CC">请详细些贵店铺地址</font>
            </td>
        </tr>
        <tr>
            <td align="right" class="style1">
                简介：
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBoxMemo" runat="server" Height="147px" Width="298px"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <%--        <tr>
           <td align="right">
                注册资金：
            </td>
            <td>
                <asp:TextBox ID="TextBoxRegisteredFunds" runat="server" Width="100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostFunds" runat="server"
                    ControlToValidate="TextBoxRegisteredFunds" Display="Dynamic" ErrorMessage="价格格式不正确，只需填写金额数"
                    ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
            </td>
            <td>
                <font color="#3333CC">只需填写金额数</font>
            </td>
        </tr>--%>
        <%--        <tr>
            <td align="right">
                成立时间：
            </td>
            <td>
                <asp:TextBox ID="TextBoxSetUpTime" onfocus="showCalendar(this)" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorSetUpTime" runat="server"
                    ControlToValidate="TextBoxSetUpTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                    ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
            </td>
            <td>
                <font color="#3333CC">请填写真实的成立时间</font>
            </td>
        </tr>--%>
        <%--        <tr>
            <td align="right">
                企业性质：
            </td>
            <td>
                <asp:DropDownList ID="DropDownListShopNature" runat="server">
                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                    <asp:ListItem Value="110">国有企业</asp:ListItem>
                    <asp:ListItem Value="120">集体企业</asp:ListItem>
                    <asp:ListItem Value="131">国有企业改组的股份合作企业</asp:ListItem>
                    <asp:ListItem Value="132">集体企业改组的股份合作企业</asp:ListItem>
                    <asp:ListItem Value="139">其它类型企业改组的股份合作企业</asp:ListItem>
                    <asp:ListItem Value="141">国有联营企业</asp:ListItem>
                    <asp:ListItem Value="142">集体联营企业</asp:ListItem>
                    <asp:ListItem Value="143">国有与集体联营企业</asp:ListItem>
                    <asp:ListItem Value="149">其它联营企业</asp:ListItem>
                    <asp:ListItem Value="151">国有独资企业</asp:ListItem>
                    <asp:ListItem Value="159">其它有限责任公司</asp:ListItem>
                    <asp:ListItem Value="161">股份有限公司（上市公司）</asp:ListItem>
                    <asp:ListItem Value="162">股份有限公司（非上市公司）</asp:ListItem>
                    <asp:ListItem Value="171">私营独资企业</asp:ListItem>
                    <asp:ListItem Value="172">私营合伙企业</asp:ListItem>
                    <asp:ListItem Value="173">私营有限责任公司</asp:ListItem>
                    <asp:ListItem Value="174">私营股份有限公司</asp:ListItem>
                    <asp:ListItem Value="190">其它内资企业</asp:ListItem>
                    <asp:ListItem Value="210">合资经营企业（港或澳、台资）</asp:ListItem>
                    <asp:ListItem Value="220">合作经营企业（港或澳、台资）</asp:ListItem>
                    <asp:ListItem Value="230">港、澳、台商经营企业</asp:ListItem>
                    <asp:ListItem Value="240">港、澳、台商股份投资有限公司</asp:ListItem>
                    <asp:ListItem Value="310">中外合资经营企业</asp:ListItem>
                    <asp:ListItem Value="320">中外合作经营企业</asp:ListItem>
                    <asp:ListItem Value="330">外资企业</asp:ListItem>
                    <asp:ListItem Value="340">外商投资股份有限公司</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator ID="CompareValidatorShopNature" runat="server" ControlToValidate="DropDownListShopNature"
                    Display="Dynamic" ErrorMessage="此项为必填项" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
            </td>--%>
        <%--            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                销售的产品：
            </td>
            <td>
                <asp:TextBox ID="TextBoxSaleProduct" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorSaleProduct" runat="server"
                    ControlToValidate="TextBoxSaleProduct" Display="Dynamic" ErrorMessage="最多250个字符"
                    ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>--%>
        <%--        <tr>
            <td align="right">
                采购的产品：
            </td>
            <td>
                <asp:TextBox ID="TextBoxBuyProdut" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorBuyProdut" runat="server"
                    ControlToValidate="TextBoxBuyProdut" Display="Dynamic" ErrorMessage="最多250个字符"
                    ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>--%>
        <%--        <tr>
            <td align="right">
                固定电话：
            </td>
            <td>
                <asp:TextBox ID="TextBoxTel" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTel" runat="server"
                    ControlToValidate="TextBoxTel" Display="Dynamic" ErrorMessage="最多20个字符" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
            </td>
            <td>
                <font color="#3333CC">真实的电话号码可以调高您的信誉</font>
            </td>
        </tr>
        <tr>
            <td align="right">
                传真号码：
            </td>
            <td>
                <asp:TextBox ID="TextBoxFax" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorFax" runat="server"
                    ControlToValidate="TextBoxFax" Display="Dynamic" ErrorMessage="最多20个字符" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right">
                邮编：
            </td>
            <td>
                <asp:TextBox ID="TextBoxPostalcode" runat="server" Width="100"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPostalcode" runat="server"
                    ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="最多8个字符"
                    ValidationExpression="^[\s\S]{0,8}$"></asp:RegularExpressionValidator>
            </td>
            <td>
            </td>
        </tr>--%>
    </table>
</div>
<div class="conttn">
    <table width="100%" border="0" cellspacing="0" cellpadding="4">
        <tr>
            <td colspan="2">
                <div class="cont">
                    <img src="Themes/Skin_Default/Images/so7.gif" />信息验证</div>
            </td>
        </tr>
        <tr>
            <td align="right" width="200">
                验证码：
            </td>
            <td>
                <asp:TextBox ID="TextBoxCode" runat="server" Width="100"></asp:TextBox>
                <img src="imagecode.aspx" id="safecode" border="0" onclick="reloadcode()" alt="看不清楚?点一下"
                    style="cursor: pointer;" />
                <a href="#" onclick="reloadcode()">看不清楚?点一下</a>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:CheckBox ID="CheckBoxIfAgree" runat="server" Checked="True" />
                我已经阅读并同意<a href="javascript:void(0)">会员注册协议</a>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="ButtonConfirm" runat="server" Text="提交" OnClientClick="return cansubmit()"
                    CssClass="bnt9" />
                <input type="reset" value="重置" class="bnt1" />
            </td>
        </tr>
    </table>
</div>
<asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
<asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
