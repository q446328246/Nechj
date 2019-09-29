<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_AddressOpeater.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AddressOpeater" %>
<table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
    runat="server">
    <tr>
        <td class="tab_r">
            收货人：
        </td>
        <td>
            <input name="input" type="text" class="textwb" id="txt_UserName" runat="server" onblur="CheckNull(this,'*收货人必填')"
                maxlength="30" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
        </td>
        <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
            需填写真实姓名
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            所在地区：
        </td>
        <td>
            <div id="p_local" style="float: left;">
            </div>
            <span class="star" style="float: left;" id="diqu">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            详细地址：
        </td>
        <td>
            <input name="name_Address" type="text" class="textwb" style="width: 400px;" id="txt_Address"
                runat="server" onblur="CheckNull(this,'*地址必填')" maxlength="100" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            邮政编码：
        </td>
        <td>
            <input name="name_PostalCode" type="text" class="textwb" id="txt_Post" runat="server"
                onblur="CheckNull1(this,'*邮政编码必填')" maxlength="6" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            手机号码：
        </td>
        <td>
            <input name="name_Mobile" type="text" class="textwb" id="txt_Mobile" runat="server"
                onblur="CheckNull2(this,'*手机号码必填')" maxlength="11" /><span class="star">*</span>
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            电话号码：
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
            区号 - 电话号码 - 分机(xxx-xxxxxxx)
        </td>
    </tr>
    <tr>
        <td class="tab_r">
            邮箱地址：
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
            <asp:Button ID="btn_Save" runat="server" Text="确认" CssClass="querbtn" 
                OnClientClick=" return  checkSumbit();" onclick="btn_Save_Click" />
            <asp:Button ID="btn_Back" runat="server" Text="返回" CssClass="querbtn" PostBackUrl="../A_ShipAddress.aspx" />
        </td>
    </tr>
</table>
<%--地址信息--%>
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
                $("#<%=txt_Post.ClientID%>").next().text("*邮政编码不正确");
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
                $("#<%=txt_Mobile.ClientID%>").next().text("*手机号码格式不正确");
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
         //areaCode 有三级
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

    //验证 电话号码
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
                $("#<%=txt_Tel.ClientID%>").next().text("*电话号码格式不正确");
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
                $("#<%=txt_Tel.ClientID%>").next().text("*电话号码格式不正确");
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

        //提交验证邮编信息
        var userPostelCode = $("#<%=txt_Post.ClientID%>").val();
        var userAddress = $("#<%=txt_Address.ClientID%>").val();
        var userMobile = $("#<%=txt_Mobile.ClientID%>").val();
        var userName = $("#<%=txt_UserName.ClientID%>").val();
        var userTel = $("#<%=txt_Tel.ClientID%>").val();

        if (userName == "") {
            $("#<%=txt_UserName.ClientID%>").next().text("*收货人必填");
            return false;
        }

        if ($("#<%=hid_Area.ClientID%>").val() == ",,|0,0,0") {
            $("#p_local").next().text("*请填写地区信息");
            return false;
        }
        else {
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 2 && $("select[name='city']").find("option").size() != 1) {
                $("#p_local").next().text("*请填写城市信息");
                return false;
            }
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 4 && $("select[name='district']").find("option").size() != 1) {
                $("#p_local").next().text("*请填写区域信息");
                return false;
            }
        }
        if (userAddress == "") {
            $("#<%=txt_Address.ClientID%>").next().text("*地址必填");
            return false;
        }
        if (userPostelCode != "") {
            if (!CheckPostCodeCommon(userPostelCode)) {
                $("#<%=txt_Post.ClientID%>").next().text("*邮政编码不正确");
                return false;
            }
        } else { $("#<%=txt_Post.ClientID%>").next().text("*邮政编码必填"); return false; }


        if (userMobile != "") {
            if (!CheckMobileCommon(userMobile)) {
                $("#<%=txt_Mobile.ClientID%>").next().text("*手机号码格式不正确");
                return false;
            }
        } else { $("#<%=txt_Mobile.ClientID%>").next().text("*手机号码必填"); return false; }


        if (userTel != "") {
            if (!CheckTelCommon1(userTel)) {
                $("#<%=txt_Tel.ClientID%>").next().text("*电话号码格式不正确");
                return false;
            }
        }

        var inputemail = $("#<%=txt_Email.ClientID%>").val();
        if (inputemail != "") {
            var reg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            if (!reg.test(inputemail)) {
                $("#<%=txt_Email.ClientID%>").next().text("邮箱格式不对"); return false;
            }
        }
        return true;
    }

</script>
