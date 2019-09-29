<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_AddressOpeater.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AddressOpeater" %>
<table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
    runat="server">
    <tr>
        <td class="tab_r">
            �ջ��ˣ�
        </td>
        <td>
            <input name="input" type="text" class="textwb" id="txt_UserName" runat="server" onblur="CheckNull(this,'*�ջ��˱���')"
                maxlength="30" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
        </td>
        <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
            ����д��ʵ����
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            ���ڵ�����
        </td>
        <td>
            <div id="p_local" style="float: left;">
            </div>
            <span class="star" style="float: left;" id="diqu">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            ��ϸ��ַ��
        </td>
        <td>
            <input name="name_Address" type="text" class="textwb" style="width: 400px;" id="txt_Address"
                runat="server" onblur="CheckNull(this,'*��ַ����')" maxlength="100" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            �������룺
        </td>
        <td>
            <input name="name_PostalCode" type="text" class="textwb" id="txt_Post" runat="server"
                onblur="CheckNull1(this,'*�����������')" maxlength="6" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            �ֻ����룺
        </td>
        <td>
            <input name="name_Mobile" type="text" class="textwb" id="txt_Mobile" runat="server"
                onblur="CheckNull2(this,'*�ֻ��������')" maxlength="11" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            �绰���룺
        </td>
        <td>
            <input name="name_Mobile" type="text" class="textwb" id="txt_Tel" runat="server"
                onblur="CheckTelCommon()" maxlength="15" style="float: left;" /><span class="star"
                    id="haoma" style="float: left; padding-top: 3px;"> </span>
        </td>
    </tr>
    <tr>
        <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
        </td>
        <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
            ���� - �绰���� - �ֻ�(xxx-xxxxxxx)
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            �����ַ��
        </td>
        <td>
            <input name="name_Eail" type="text" class="textwb" id="txt_Email" runat="server"
                maxlength="30" /><span class="star"></span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            &nbsp;
        </td>
        <td style="padding: 10px 0px 10px 0px;">
            <asp:Button ID="btn_Save" runat="server" Text="ȷ��" CssClass="querbtn" 
                OnClientClick=" return  checkSumbit();" onclick="btn_Save_Click" />
            <asp:Button ID="btn_Back" runat="server" Text="����" CssClass="querbtn" PostBackUrl="../A_ShipAddress.aspx" />
        </td>
    </tr>
</table>
<%--��ַ��Ϣ--%>
<input id="hid_Area" type="hidden" runat="server" />
<input id="hid_AreaCode" type="hidden" runat="server" />
<script type="text/javascript" language="javascript">
    $(function () {
        $("#p_local").LocationSelect();

        $("select[name='district']").change(function () {
            if ($(this).find("option:selected").val() != "0") {
                document.getElementById("diqu").style.display = "none";
                return true;
            }
        });
    });
 
</script>
<script type="text/javascript" language="javascript">
    function CheckNull1(i, j) {
        var a = $(i).val();
        if (a == "") {
            $(i).next().text(j);
            return false;
        }
        else {
            var userPostelCode = $("#<%=txt_Post.ClientID%>").val();
            if (!CheckPostCodeCommon(userPostelCode)) {
                $("#<%=txt_Post.ClientID%>").next().text("*�������벻��ȷ");
                return false;
            } else {


                $(i).next().text(" *");
                return true;
            }
        }
    };

    function CheckNull2(i, j) {
        var a = $(i).val();
        if (a == "") {
            $(i).next().text(j);
            return false;
        }
        else {
            var userMobile = $("#<%=txt_Mobile.ClientID%>").val();
            if (!CheckMobileCommon(userMobile)) {
                $("#<%=txt_Mobile.ClientID%>").next().text("*�ֻ������ʽ����ȷ");
                return false;
            }
            else { $(i).next().text(" *"); return true; }
        }
    };

    $(document).ready(
 function () {
     var area = $("#<%=hid_Area.ClientID%>").val().split("|");
     var areaCode = $("#<%=hid_AreaCode.ClientID%>").val();
     var code1;
     var code2;
     var code3;
     if (areaCode.length > 8) {
         //areaCode ������
         code1 = areaCode.substring(0, 3);
         code2 = areaCode.substring(4, 6);
         code3 = areaCode.substring(7, 9);
     }
     if ($("#<%=hid_Area.ClientID%>").val() != "") {
         var areacode = area[1].split(",");
         var areaname = area[0].split(",");
         if (areaname[0] != "")
             $("select[name='province']").append("<option value=\"" + code1 + "\" selected=\"selected\">" + areaname[0] + "</option>");
         if (areaname[1] != "")
             $("select[name='city']").append("<option value=\"" + code2 + "\" selected=\"selected\">" + areaname[1] + "</option>");
         if (areaname[2] != "")
             $("select[name='district']").append("<option value=\"" + code3 + "\" selected=\"selected\">" + areaname[2] + "</option>");
     }

 }
 );
</script>
<script type="text/javascript" language="javascript">

    //��֤ �绰����
    function CheckTelCommon() {
        var str = $("#<%=txt_Tel.ClientID%>").val();

        if (str != "") {
            var reg = /^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/;

            if (reg.test(str)) {
                document.getElementById("haoma").style.display = "none";
                return true;
            }
            else {
                document.getElementById("haoma").style.display = "block";
                $("#<%=txt_Tel.ClientID%>").next().text("*�绰�����ʽ����ȷ");
                return false;
            }
        }
        else {
            document.getElementById("haoma").style.display = "none";
            return true;
        }
    }
    function CheckTelCommon1(str) {
        if (str != "") {
            var reg = /^(([0\+]\d{2,3}-)?(0\d{2,3})-)?(\d{7,8})(-(\d{3,}))?$/;

            if (reg.test(str)) {

                return true;
            }
            else {
                $("#<%=txt_Tel.ClientID%>").next().text("*�绰�����ʽ����ȷ");
                return false;
            }
        }
        else {
            return false;
        }
    }
    function checkSumbit() {

        var info = $("#p_local").getLocation();
        if (info.pcode == "0") {
            $("#p_local").next().show();
        }
        $("#<%=hid_Area.ClientID%>").val(info.province + "," + info.city + "," + info.district + "|");
        if (info.dcode != "0") {
            $("#<%=hid_AreaCode.ClientID%>").val(info.dcode);
        }
        else {
            if (info.ccode != "0") {
                $("#<%=hid_AreaCode.ClientID%>").val(info.ccode);
            }
            else {
                $("#<%=hid_AreaCode.ClientID%>").val(info.pcode);
            }
        }

        //�ύ��֤�ʱ���Ϣ
        var userPostelCode = $("#<%=txt_Post.ClientID%>").val();
        var userAddress = $("#<%=txt_Address.ClientID%>").val();
        var userMobile = $("#<%=txt_Mobile.ClientID%>").val();
        var userName = $("#<%=txt_UserName.ClientID%>").val();
        var userTel = $("#<%=txt_Tel.ClientID%>").val();

        if (userName == "") {
            $("#<%=txt_UserName.ClientID%>").next().text("*�ջ��˱���");
            return false;
        }

        if ($("#<%=hid_Area.ClientID%>").val() == ",,|0,0,0") {
            $("#p_local").next().text("*����д������Ϣ");
            return false;
        }
        else {
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 2 && $("select[name='city']").find("option").size() != 1) {
                $("#p_local").next().text("*����д������Ϣ");
                return false;
            }
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 4 && $("select[name='district']").find("option").size() != 1) {
                $("#p_local").next().text("*����д������Ϣ");
                return false;
            }
        }
        if (userAddress == "") {
            $("#<%=txt_Address.ClientID%>").next().text("*��ַ����");
            return false;
        }
        if (userPostelCode != "") {
            if (!CheckPostCodeCommon(userPostelCode)) {
                $("#<%=txt_Post.ClientID%>").next().text("*�������벻��ȷ");
                return false;
            }
        } else { $("#<%=txt_Post.ClientID%>").next().text("*�����������"); return false; }


        if (userMobile != "") {
            if (!CheckMobileCommon(userMobile)) {
                $("#<%=txt_Mobile.ClientID%>").next().text("*�ֻ������ʽ����ȷ");
                return false;
            }
        } else { $("#<%=txt_Mobile.ClientID%>").next().text("*�ֻ��������"); return false; }


        if (userTel != "") {
            if (!CheckTelCommon1(userTel)) {
                $("#<%=txt_Tel.ClientID%>").next().text("*�绰�����ʽ����ȷ");
                return false;
            }
        }

        var inputemail = $("#<%=txt_Email.ClientID%>").val();
        if (inputemail != "") {
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            if (!reg.test(inputemail)) {
                $("#<%=txt_Email.ClientID%>").next().text("�����ʽ����"); return false;
            }
        }
        return true;
    }

</script>
