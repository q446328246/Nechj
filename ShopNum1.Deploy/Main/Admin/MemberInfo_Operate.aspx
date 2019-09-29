<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberInfo_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberInfo_Operate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��Ա��ϸ��Ϣ</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script src="/Main/js/location.js" type="text/javascript"> </script>
    <script src="/Main/js/areas.js" type="text/javascript"> </script>
    <script type="text/javascript">


        window.onload = function () {
            var v_birthday = document.getElementById("TextBoxBirthday");
            if (v_birthday.value == "1900-1-1") {
                v_birthday.value = "";
            }
        }
         
    </script>
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
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="��Ա��ϸ��Ϣ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            ��ԱID��
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxName" CssClass="tinput" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            ��Ա�ȼ���
                        </th>
                        <td>

                            <asp:Label ID="LabelMemberRankGuid" runat="server" Text=""></asp:Label>
                            <asp:Label ID="MemberRankGuid"  runat="server" Text="Label" Visible="false"></asp:Label>
                            <asp:Label ID="LabelRetailersStates"  runat="server" Text="Label" Visible="false"></asp:Label>
                            <ShopNum1:DropDownList ID="DropDownListMemberRankGuid"  runat="server" 
                                onselectedindexchanged="DropDownListMemberRankGuid_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                <asp:ListItem Value="a6da75ad-e1ac-4df8-99ad-980294a16581">��ϰҵ��Ա</asp:ListItem>
                                <asp:ListItem Value="197b6b51-3eb3-452e-bd03-d560577a34d2">�˿�</asp:ListItem>
                                <asp:ListItem Value="1">������</asp:ListItem>
                                <asp:ListItem Value="e5ea79ac-a3e9-492b-9f86-9c7f8a48aa76">ҵ��Ա</asp:ListItem>
                                <asp:ListItem Value="d4438a97-d63a-4d08-b090-3de0aab69dc2">��ʱ������</asp:ListItem>
                                <asp:ListItem Value="d09e7ab5-f355-417e-be27-1df0258cb76a">��ʱ������</asp:ListItem>
                                <asp:ListItem Value="2fcf4209-7971-41d2-8fdd-419aaa4cf771">������I</asp:ListItem>
                                <asp:ListItem Value="d33de7ad-d020-42cc-93ce-6e75f9025015">������I</asp:ListItem>
                                <asp:ListItem Value="575b91f2-1b30-4abd-ad2b-5ef33a36f9c0">ҵ�񶽵�</asp:ListItem>
                                <asp:ListItem Value="49844669-3893-413e-951e-77b2ebe4fe28">������II</asp:ListItem>
                                <asp:ListItem Value="2b1d8354-f929-42a7-8c8c-7a0f68c28eba">������II</asp:ListItem>
                            </ShopNum1:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <th align="right" width="150px">
                            �����̣�
                        </th>
                        <td>
                            <asp:Label ID="LabelIsRetailersStates" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="��Ա�ǳƣ�"></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxMemberName" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRealName" runat="server"
                                ControlToValidate="TextBoxMemberName" Display="Dynamic" ErrorMessage="��Ա�ǳ����50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRealName" runat="server" Text="��Ա������"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRealName" runat="server" CssClass="tinput"></asp:TextBox><span>
                            </span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxRealName"
                                Display="Dynamic" ErrorMessage="�������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>

                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopNames" runat="server" Text="�������ƣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopNames" runat="server" CssClass="tinput"></asp:TextBox><span>
                            </span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxRealName"
                                Display="Dynamic" ErrorMessage="�����������50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>

                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="�������ڣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBirthday" runat="server" CssClass="tinput" Style="width: 80px;"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                ControlToValidate="TextBoxBirthday" Display="Dynamic" ErrorMessage="ʱ���ʽ����ȷ"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" />
                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxBirthday"
                                PopupButtonID="imgCalendarStartTime" Format="yyyy-MM-dd"  CssClass="ajax__calendar">
                            </t:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label14" runat="server" Text="�Ա�"></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSex" runat="server" Width="180px" CssClass="tselect"
                                Style="width: 80px;">
                                <asp:ListItem Selected="True" Value="0">����</asp:ListItem>
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="2">Ů</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
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
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label7" runat="server" Text="�ֻ����룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMobile" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="����д��ȷ���ֻ���"
                                Display="Dynamic" ControlToValidate="TextBoxMobile" ValidationExpression="^(1[3|5|7|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonMobile" runat="server" OnClick="ButtonCheckMobile_Click" Text="����ֻ�����"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="��������:"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmail" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle9" runat="server"
                                ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="�����������100���ַ�"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxEmail"
                                Display="Dynamic" ErrorMessage="�����ʽ����ȷ��" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonEmail" runat="server" OnClick="ButtonCheckEmail_Click" Text="�������"
                                CssClass="selpic" CausesValidation="False" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="��¼���룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label1" runat="server" Text="(��д�����ε�½������޸�ԭ��½����)"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxPwd"
                                Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ" ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPwd2" runat="server" Text="��¼����ȷ�ϣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPwd2" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPwd2" runat="server"
                                ControlToValidate="TextBoxPwd2" Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ"
                                ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPwd"
                                ControlToValidate="TextBoxPwd2" ErrorMessage="��¼�������벻һ��" Display="Dynamic"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPayPwd" runat="server" Text="�������룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPayPwd" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="Label11" runat="server" Text="(��д�����ν���������޸�ԭ��������)"></asp:Label>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPayPwd" runat="server"
                                ControlToValidate="TextBoxPayPwd" Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ"
                                ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label12" runat="server" Text="��������ȷ�ϣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPayPwd2" runat="server" CssClass="tinput" TextMode="Password"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxPayPwd2"
                                Display="Dynamic" ErrorMessage="���볤������Ϊ6-30λ" ValidationExpression="^[\s\S]{6,30}$"></asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="TextBoxPayPwd"
                                ControlToValidate="TextBoxPayPwd2" ErrorMessage="�����������벻һ��" Display="Dynamic"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRemark" runat="server" Text="��Ա���ͣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelMemberType" runat="server" CssClass="tinput"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <th align="right">
                            <asp:Label ID="Label2333" runat="server" Text="�Ƽ��ˣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSuperior" CssClass="tinput" runat="server" disabled="disabled"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelArea" runat="server" Text="���ڵ�����"></asp:Label>
                        </th>
                        <td>
                            <div id="p_local">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddress" runat="server" Text="��ϸ��ַ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAddress" CssClass="tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="������ҵ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVocation" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorVocation" runat="server"
                                ControlToValidate="TextBoxVocation" Display="Dynamic" ErrorMessage="��ҵ���50���ַ�"
                                ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="�������룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPostalcode" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle10" runat="server"
                                ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="���������ʽ����"
                                ValidationExpression="^[0-9 ]{6}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelTel" runat="server" Text="�绰��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTel" runat="server" CssClass="tinput"></asp:TextBox><span>
                            </span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle11" runat="server"
                                ControlToValidate="TextBoxTel" Display="Dynamic" ErrorMessage="�绰��ʽ����" ValidationExpression="^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label9" runat="server" Text="������룺"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxFax" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle13" runat="server"
                                ControlToValidate="TextBoxFax" Display="Dynamic" ErrorMessage="��������20���ַ�" ValidationExpression="^[\s\S]{0,20}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <tr >
                            <th align="right">
                                <asp:Label ID="LabelCardNum" runat="server" Text="֤�����룺"></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxCardNum" CssClass="tinput"  runat="server"></asp:TextBox><span>
                                    ��Ч���֤</span>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle17" runat="server"
                                    ControlToValidate="TextBoxCardNum" Display="Dynamic" ErrorMessage="���֤�����ʽ����ȷ"
                                    ValidationExpression="^(\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <th align="right">
                            <asp:Label ID="Label16" runat="server" Text="��ѶQQ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxQQ" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle14" runat="server"
                                ControlToValidate="TextBoxQQ" Display="Dynamic" ErrorMessage="QQ��ʽ����" ValidationExpression="^[1

-9][0-9]{4,10}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label18" runat="server" Text="���˲��ͻ���վ��"></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxWebSite" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle18" runat="server"
                                ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="��վ��ʽ����" ValidationExpression="^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$"></asp:RegularExpressionValidator>
                            <span>(����http://��ͷ)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label19" runat="server" Text="���ö�ȣ�"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelCreditMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label20" runat="server" Text="ע��ʱ�䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelRegeDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label22" runat="server" Text="�ϴε�¼ʱ�䣺"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLastLoginTime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label24" runat="server" Text="���Ѻ����"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelScore" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label26" runat="server" Text="��ǰ�����ң�BV����"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLockAdvancePayment" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="Label21" runat="server" Text="��ǰ��������"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelLockSocre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label25" runat="server" Text="�����ѽ�"></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelCostMoney" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click"
                    OnClientClick=" return CheckSumbit() " />
                <input id="inputBack" type="button" onclick=" javascript: window, location.href = 'Member_List.aspx'; "
                    value="�����б�" class="fanh" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldRegionValue" runat="server" Value="0" />
    </form>
</body>
</html>
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
                //areaCode ������
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
<script type="text/javascript" language="javascript"> </script>
