b<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Member_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Member_Operate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ա</title>
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
                        <asp:Label ID="LabelPageTitle" runat="server" Text="������Ա"></asp:Label></h3>
                </div>
                <div class="rr">
                </div>
            </div>
            <div class="welcon clearfix">
                <div class="inner_page_list">
                    <table border="0" cellpadding="0" cellspacing="1">
                        <%-- <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="��ԱID��"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" MaxLength="20"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                                ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxMemLoginID"
                                Display="Dynamic" ErrorMessage="��ԱIDΪ����Ϊ2-20λ��Ӣ����ĸ,���ֺ�������ɵ��ַ���" ValidationExpression="^[\s\S]{2,20}$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonCheckName" runat="server" OnClick="ButtonCheckName_Click" Text="����Ա��"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>--%>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelMobile" runat="server" Text="�ֻ����룺"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxMobile" runat="server" CssClass="tinput" onkeyup="this.value=this.value.replace(/\D/g,'')"
                                    MaxLength="11"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" ForeColor="red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxMobile"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="����д��ȷ���ֻ���"
                                    Display="Dynamic" ControlToValidate="TextBoxMobile" ValidationExpression="^(1[3|5|7|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
                                <asp:Button ID="ButtonCheckMobile" runat="server" OnClick="ButtonCheckMobile_Click"
                                    Text="����ֻ�����" CssClass="selpic" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelRealName" runat="server" Text="��Ա������"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxRealName" runat="server" CssClass="tinput"></asp:TextBox><span>
                                ��Ա����</span>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRealName" runat="server"
                                    ControlToValidate="TextBoxRealName" Display="Dynamic" ErrorMessage="�������50���ַ�"
                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right" width="150px">
                                <asp:Label ID="LabelMemLoginID" runat="server" Text="�Ƽ��ˣ�"></asp:Label>
                            </th>
                            <td valign="middle">
                                <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" MaxLength="20"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label><span>
                                �Ƽ���</span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorMemLoginID" runat="server"
                                    ControlToValidate="TextBoxMemLoginID" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>

                                <asp:Button ID="ButtonCheckName" runat="server" OnClick="ButtonCheckName_Click" Text="����Ƽ���"
                                    CssClass="selpic" CausesValidation="False" />
                            </td>
                        </tr>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelBirthday" runat="server" Text="�������ڣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBirthday" runat="server"  CssClass="tinput" onfucus="getBirthday()" Style="width: 80px;" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                ControlToValidate="TextBoxBirthday" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
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
                            <asp:Label ID="LabelMember" runat="server" Text="">��Աͷ��</asp:Label>
                        </th>
                        <td>
                            <input id="ButtonSelectSingleImage" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() "
                                class="selpic" />
                            <img id="ImagePhoto" runat="server" onerror="javascript:this,src='/ImgUpload/noImage.gif'"
                                src="" alt="" width="80" height="80" />
                            <asp:HiddenField ID="HiddenFieldOriginalImge" runat="server" />
                            <span>ѡ��ͷ��</span>
                        </td>
                    </tr>--%>

                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelEmail" runat="server" Text="�������䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxEmail"
                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle9" runat="server"
                                ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="�����������100���ַ�"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxEmail"
                                Display="Dynamic" ErrorMessage="�����ʽ����ȷ��" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonEmail" runat="server" OnClick="ButtonCheckEmail_Click" Text="�������"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>--%>
                        <%--<tr>
                            <th align="right">
                                <asp:Label ID="LabelSex" runat="server" Text="�Ա�"></asp:Label>
                            </th>
                            <td>
                                <asp:DropDownList ID="DropDownListSex" runat="server" CssClass="tselect" Width="120">
                                    <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                                    <asp:ListItem Value="1">��</asp:ListItem>
                                    <asp:ListItem Value="2">Ů</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="Label8" runat="server" ForeColor="red" Text="*"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPwd" runat="server" Text="��¼���룺"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" ForeColor="red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPwd"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd" runat="server"
                                    ControlToValidate="TextBoxPwd" Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPwd2" runat="server" Text="��¼����ȷ�ϣ�"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPwd2" runat="server" CssClass="tinput" TextMode="Password"
                                    onblur="emptyPwdCheck()"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" ForeColor="red" Text="*"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPwd2"
                                    Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd2" runat="server"
                                    ControlToValidate="TextBoxPwd2" Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPwd"
                                    ControlToValidate="TextBoxPwd2" ErrorMessage="��¼���벻һ��" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPayPwd" runat="server" Text="�������룺"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPayPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPayPwd" runat="server"
                                    ControlToValidate="TextBoxPayPwd" Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelPayPwd2" runat="server" Text="��������ȷ�ϣ�"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPayPwd2" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="��д�����ν�������󣬱��潻������"></asp:Label>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPayPwd2" runat="server"
                                    ControlToValidate="TextBoxPayPwd2" Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ"
                                    ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxPayPwd"
                                    ControlToValidate="TextBoxPayPwd2" ErrorMessage="�������벻һ��" Display="Dynamic"></asp:CompareValidator>
                            </td>
                        </tr>
                        <%--<tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelCreditMoney" runat="server" Text="���ö�ȣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCreditMoney" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox><span>
                                ���ö��</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCreditMoney" runat="server"
                                ControlToValidate="TextBoxCreditMoney" Display="Dynamic" ErrorMessage="��ʽ����ȷ"
                                ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelVocation" runat="server" Text="������ҵ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVocation" runat="server" CssClass="tinput"></asp:TextBox><span>
                                ��ҵ���50���ַ�</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorVocation" runat="server"
                                ControlToValidate="TextBoxVocation" Display="Dynamic" ErrorMessage="��ҵ�������50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$" Visible="false"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelArea" runat="server" Text="���ڵ�����"></asp:Label>
                        </th>
                        <td>
                            <div id="p_local">
                            </div>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelAddress" runat="server" Text="��ͥסַ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="tinput"></asp:TextBox><span>
                                סַ���250���ַ�</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle8" runat="server"
                                ControlToValidate="TextBoxAddress" Display="Dynamic" ErrorMessage="��ͥסַ����250���ַ�֮��"
                                ValidationExpression="^[\s\S]{0,250}$" Visible="false"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelPostalcode" runat="server" Text="�������룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPostalcode" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle10" runat="server"
                                ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="���������ʽ����"
                                ValidationExpression="^[a-zA-Z0-9 ]{3,12}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%-- <tr>
                        <th align="right">
                            <asp:Label ID="LabelTel" runat="server" Text="�绰��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle11" runat="server"
                                ControlToValidate="TextBoxTel" Display="Dynamic" ErrorMessage="�绰��ʽ����" ValidationExpression="^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%-- <tr>
                        <th align="right">
                            <asp:Label ID="LabelFax" runat="server" Text="������룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxFax" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle13" runat="server"
                                ControlToValidate="TextBoxFax" Display="Dynamic" ErrorMessage="��������20���ַ�" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelQQ" runat="server" Text="��ѶQQ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxQQ" runat="server" CssClass="tinput"></asp:TextBox><span> QQ</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle14" runat="server"
                                ControlToValidate="TextBoxQQ" Display="Dynamic" ErrorMessage="QQ��ʽ����" ValidationExpression="^[1-9][0-9]{4,10}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelMsn" runat="server" Text="MSN�ʺţ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMsn" runat="server" CssClass="tinput"></asp:TextBox><span> MSN</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle16" runat="server"
                                ControlToValidate="TextBoxMsn" Display="Dynamic" ErrorMessage="MSN���20���ַ�" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr >
                        <th align="right">
                            <asp:Label ID="LabelCardNum" runat="server" Text="֤�����룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxCardNum" runat="server"  CssClass="tinput" ></asp:TextBox><span>
                                ��Ч���֤</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle17" runat="server"
                                ControlToValidate="TextBoxCardNum" Display="Dynamic" ErrorMessage="���֤�����ʽ����ȷ"
                                ValidationExpression="^(\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)"></asp:RegularExpressionValidator>
                            

                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="���˲��ͻ���վ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWebSite" runat="server" CssClass="tinput"></asp:TextBox><span>
                                ��վ��ʽ�硰http://www.sample.com��</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle18" runat="server"
                                ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="��վ��ʽ����" ValidationExpression="^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelQuestion" runat="server" Text="ȡ���������⣺"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListQuestion" runat="server" CssClass="tselect" Width="260">
                                <asp:ListItem> �㰮����</asp:ListItem>
                                <asp:ListItem>������ֽ�ʲô</asp:ListItem>
                            </asp:DropDownList>
                            <span>����Ҫ����������</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelAnswer" runat="server" Text="ȡ������𰸣�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAnswer" runat="server" CssClass="tinput"></asp:TextBox><span>
                                ��ס�����</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle19" runat="server"
                                ControlToValidate="TextBoxAnswer" Display="Dynamic" ErrorMessage="�����50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>--%>
                        <%--<tr>
                            <th align="right">
                                <asp:Label ID="LabelIsForbid" runat="server" Text="����״̬��"></asp:Label>
                            </th>
                            <td>
                                <asp:DropDownList ID="DropDownListIsForbid" runat="server" CssClass="tselect" Width="260">
                                    <asp:ListItem Value="1">����</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                                </asp:DropDownList>
                                <span>ѡ�����״̬</span>
                            </td>
                        </tr>--%>
                    </table>
                </div>
                <div class="tablebtn">
                    <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="ȷ��"
                        ToolTip="Submit" CssClass="fanh" OnClientClick=" CheckSumbit() " />
                    <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                        PostBackUrl="~/Main/Admin/Member_List.aspx" Text="�����б�" />
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
    //ѡ��ͼ

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
