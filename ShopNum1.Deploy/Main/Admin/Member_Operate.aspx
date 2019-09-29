b<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Member_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Member_Operate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增会员</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
            runat="server">
        </asp:ScriptManager>
        <div id="right">
            <div class="rhigth">
                <div class="rl">
                </div>
                <div class="rcon">
                    <h3>
                        <asp:Label ID="LabelPageTitle" runat="server" Text="新增会员"></asp:Label></h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="welcon clearfix">
                <div class="inner_page_list">
                    <table border="0" cellpadding="0" cellspacing="1">
                        <%-- <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="会员ID："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" MaxLength="20"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                                ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxMemLoginID"
                                Display="Dynamic" ErrorMessage="会员ID为长度为2-20位由英文字母,汉字和数字组成的字符串" ValidationExpression="^[\s\S]{2,20}$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonCheckName" runat="server" OnClick="ButtonCheckName_Click" Text="检测会员名"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>--%>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelMobile" runat="server" Text="手机号码："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxMobile" runat="server" CssClass="tinput" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    MaxLength="11"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" ForeColor="red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxMobile"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="请填写正确的手机号"
                                    Display="Dynamic" ControlToValidate="TextBoxMobile" ValidationExpression="^(1[3|5|7|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
                                <asp:Button ID="ButtonCheckMobile" runat="server" OnClick="ButtonCheckMobile_Click"
                                    Text="检测手机号码" CssClass="selpic" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelRealName" runat="server" Text="会员姓名："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxRealName" runat="server" CssClass="tinput"></asp:TextBox><span>
                                会员名称</span>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRealName" runat="server"
                                    ControlToValidate="TextBoxRealName" Display="Dynamic" ErrorMessage="姓名最多50个字符"
                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right" width="150px">
                                <asp:Label ID="LabelMemLoginID" runat="server" Text="推荐人："></asp:Label>
                            </th>
                            <td valign="middle">
                                <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label><span>
                                推荐人</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                                    ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>

                                <asp:Button ID="ButtonCheckName" runat="server" OnClick="ButtonCheckName_Click" Text="检测推荐人"
                                    CssClass="selpic" CausesValidation="False" />
                            </td>
                        </tr>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelBirthday" runat="server" Text="出生日期："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBirthday" runat="server"  CssClass="tinput" onfucus="getBirthday()" Style="width: 80px;" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                ControlToValidate="TextBoxBirthday" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" />
                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxBirthday"
                                PopupButtonID="imgCalendarStartTime" Format="yyyy-MM-dd"  CssClass="ajax__calendar">
                            </t:CalendarExtender>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelMember" runat="server" Text="">会员头像：</asp:Label>
                        </th>
                        <td>
                            <input id="ButtonSelectSingleImage" type="button" value="选择图片" onclick=" openSingleChild() "
                                class="selpic" />
                            <img id="ImagePhoto" runat="server" onerror="javascript:this,src='/ImgUpload/noImage.gif'"
                                src="" alt="" width="80" height="80" />
                            <asp:HiddenField ID="HiddenFieldOriginalImge" runat="server" />
                            <span>选择头像</span>
                        </td>
                    </tr>--%>

                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelEmail" runat="server" Text="电子邮箱："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxEmail"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle9" runat="server"
                                ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="电子邮箱最多100个字符"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail"
                                Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonEmail" runat="server" OnClick="ButtonCheckEmail_Click" Text="检测邮箱"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>--%>
                        <%--<tr>
                            <th align="right">
                                <asp:Label ID="LabelSex" runat="server" Text="性别："></asp:Label>
                            </th>
                            <td>
                                <asp:DropDownList ID="DropDownListSex" runat="server" CssClass="tselect" Width="120">
                                    <asp:ListItem Selected="True" Value="0">保密</asp:ListItem>
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label8" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPwd" runat="server" Text="登录密码："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPwd"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd" runat="server"
                                    ControlToValidate="TextBoxPwd" Display="Dynamic" ErrorMessage="密码长度限制为6-30位"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPwd2" runat="server" Text="登录密码确认："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPwd2" runat="server" CssClass="tinput" TextMode="Password"
                                    onblur="emptyPwdCheck()"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPwd2"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd2" runat="server"
                                    ControlToValidate="TextBoxPwd2" Display="Dynamic" ErrorMessage="密码长度限制为6-30位"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPwd"
                                    ControlToValidate="TextBoxPwd2" ErrorMessage="登录密码不一致" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPayPwd" runat="server" Text="交易密码："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPayPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPayPwd" runat="server"
                                    ControlToValidate="TextBoxPayPwd" Display="Dynamic" ErrorMessage="密码长度限制为6-30位"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPayPwd2" runat="server" Text="交易密码确认："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPayPwd2" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="填写后两次交易密码后，保存交易密码"></asp:Label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPayPwd2" runat="server"
                                    ControlToValidate="TextBoxPayPwd2" Display="Dynamic" ErrorMessage="密码长度限制为6-30位"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxPayPwd"
                                    ControlToValidate="TextBoxPayPwd2" ErrorMessage="交易密码不一致" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>
                        <%--<tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelCreditMoney" runat="server" Text="信用额度："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCreditMoney" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>
                                信用额度</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCreditMoney" runat="server"
                                ControlToValidate="TextBoxCreditMoney" Display="Dynamic" ErrorMessage="格式不正确"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelVocation" runat="server" Text="从事行业："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVocation" runat="server" CssClass="tinput"></asp:TextBox><span>
                                行业最多50个字符</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorVocation" runat="server"
                                ControlToValidate="TextBoxVocation" Display="Dynamic" ErrorMessage="行业描述最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$" Visible="false"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelArea" runat="server" Text="所在地区："></asp:Label>
                        </th>
                        <td>
                            <div id="p_local">
                            </div>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelAddress" runat="server" Text="家庭住址："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="tinput"></asp:TextBox><span>
                                住址最多250个字符</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle8" runat="server"
                                ControlToValidate="TextBoxAddress" Display="Dynamic" ErrorMessage="家庭住址描述250个字符之内"
                                ValidationExpression="^[\s\S]{0,250}$" Visible="false"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelPostalcode" runat="server" Text="邮政编码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPostalcode" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle10" runat="server"
                                ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="邮政编码格式不对"
                                ValidationExpression="^[a-zA-Z0-9 ]{3,12}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%-- <tr>
                        <th align="right">
                            <asp:Label ID="LabelTel" runat="server" Text="电话："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle11" runat="server"
                                ControlToValidate="TextBoxTel" Display="Dynamic" ErrorMessage="电话格式不对" ValidationExpression="^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%-- <tr>
                        <th align="right">
                            <asp:Label ID="LabelFax" runat="server" Text="传真号码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxFax" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle13" runat="server"
                                ControlToValidate="TextBoxFax" Display="Dynamic" ErrorMessage="传真号最多20个字符" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelQQ" runat="server" Text="腾讯QQ："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxQQ" runat="server" CssClass="tinput"></asp:TextBox><span> QQ</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle14" runat="server"
                                ControlToValidate="TextBoxQQ" Display="Dynamic" ErrorMessage="QQ格式不对" ValidationExpression="^[1-9][0-9]{4,10}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelMsn" runat="server" Text="MSN帐号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMsn" runat="server" CssClass="tinput"></asp:TextBox><span> MSN</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle16" runat="server"
                                ControlToValidate="TextBoxMsn" Display="Dynamic" ErrorMessage="MSN最多20个字符" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr >
                        <th align="right">
                            <asp:Label ID="LabelCardNum" runat="server" Text="证件号码："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCardNum" runat="server"  CssClass="tinput" ></asp:TextBox><span>
                                有效身份证</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle17" runat="server"
                                ControlToValidate="TextBoxCardNum" Display="Dynamic" ErrorMessage="身份证号码格式不正确"
                                ValidationExpression="^(\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)"></asp:RegularExpressionValidator>
                            

                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="个人博客或网站："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWebSite" runat="server" CssClass="tinput"></asp:TextBox><span>
                                网站格式如“http://www.sample.com”</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle18" runat="server"
                                ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="网站格式不对" ValidationExpression="^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelQuestion" runat="server" Text="取回密码问题："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListQuestion" runat="server" CssClass="tselect" Width="260">
                                <asp:ListItem> 你爱她吗？</asp:ListItem>
                                <asp:ListItem>你的名字叫什么</asp:ListItem>
                            </asp:DropDownList>
                            <span>您想要的密码问题</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelAnswer" runat="server" Text="取回密码答案："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAnswer" runat="server" CssClass="tinput"></asp:TextBox><span>
                                记住密码答案</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle19" runat="server"
                                ControlToValidate="TextBoxAnswer" Display="Dynamic" ErrorMessage="答案最多50个字符"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                            <th align="right">
                                <asp:Label ID="LabelIsForbid" runat="server" Text="禁用状态："></asp:Label>
                            </th>
                            <td>
                                <asp:DropDownList ID="DropDownListIsForbid" runat="server" CssClass="tselect" Width="260">
                                    <asp:ListItem Value="1">禁用</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">启用</asp:ListItem>
                                </asp:DropDownList>
                                <span>选择禁用状态</span>
                            </td>
                        </tr>--%>
                    </table>
                </div>
                <div class="tablebtn">
                    <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                        ToolTip="Submit" CssClass="fanh" OnClientClick=" CheckSumbit() " />
                    <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                        PostBackUrl="~/Main/Admin/Member_List.aspx" Text="返回列表" />
                    <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldRegionValue" runat="server" Value="0" />
    </form>
</body>
</html>
<script type="text/javascript">
    function getBirthday() {
        alert("--------");
        var boolresult = true;
      
        var identityCard = document.getElementById("TextBoxCardNum").innerText;
        var birthday = document.getElementById("TextBoxBirthday");
        var tmpStr = "";
        if (identityCard.length == 15) {

            tmpStr = "19" + identityCard.substring(6, 2) + "-" + identityCard.substring(8, 2) + "-" + identityCard.substring(10, 2)
            birthday.innerHTML = tmpStr;
            return tmpStr;
        }
        else {
            alert("+++++++++++++");
            tmpStr = identityCard.substring(6, 10) + "-" + identityCard.substring(10, 12) + "-" + identityCard.substring(12, 14);
            alert(tmpStr);

            birthday.innerText = tmpStr;

            return tmpStr;
        }
    }
</script>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#p_local").LocationSelect();
    })

</script>
<script type="text/javascript" language="javascript">
    $(document).ready(
        function () {
            var area = $("#HiddenFieldRegionValue").val().split("|");
            var areaCode = $("#HiddenFieldRegionCode").val();
            var code1;
            var code2;
            var code3;
            if (areaCode.length > 8) {
                code1 = areaCode.substring(0, 3);
                code2 = areaCode.substring(4, 6);
                code3 = areaCode.substring(7, 9);
            }
            if ($("#HiddenFieldRegionValue").val() != "") {
                var areacode = area[1].split(",");
                var areaname = area[0].split(",");
                $("select[name='province']").append("<option value=\"" + code1 + "\" selected=\"selected\">" + areaname[0] + "</option>");
                $("select[name='city']").append("<option value=\"" + code2 + "\" selected=\"selected\">" + areaname[1] + "</option>");
                $("select[name='district']").append("<option value=\"" + code3 + "\" selected=\"selected\">" + areaname[2] + "</option>");
            }

        }
    );
</script>
<script language="javascript" type="text/javascript">
    function CheckSumbit() {
        var info = $("#p_local").getLocation();
        if (info.pcode == "0") {
            $("#p_local").next().show();
        }
        $("#HiddenFieldRegionValue").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);
        if (info.dcode != "0") {
            $("#HiddenFieldRegionCode").val(info.dcode);
        } else {
            if (info.ccode != "0") {
                $("#HiddenFieldRegionCode").val(info.ccode);
            } else {
                $("#HiddenFieldRegionCode").val(info.pcode);
            }
        }

    }

</script>
<script type="text/javascript" language="javascript">
    var lock = 0;
    //选择单图

    function openSingleChild() {
        if (lock == 0) {
            lock = 1;
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k == null)
                k = window.returnValue;
            if (k != null) {
                var imgvalue = new Array();
                imgvalue = k.split(",");
                document.getElementById("HiddenFieldOriginalImge").value = imgvalue[0];
                document.getElementById("ImagePhoto").src = imgvalue[1];
            }
            lock = 0;
        }
    }
</script>
<script type="text/javascript" language="javascript">
    function emptyPwdCheck() {
        document.getElementById("LabelPwdCheck").text = "";
    }

</script>
