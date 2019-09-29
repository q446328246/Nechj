<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_MemInfo.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_MemInfo" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.AccountWebControl" %>
<div id="list_main" class="list_main">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=0" style="text-decoration: none;">个人信息</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=1" style="text-decoration: none;">详细信息</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=2" style="text-decoration: none;">个人头像</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="5"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=5" style="text-decoration: none;">银行信息</a></li>
    </ul>
    <div id="content">
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table id="Table2" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                runat="server">
                <tr>
                    <td class="tab_r">
                        用户名：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text="" runat="server"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        用户编号：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginNO" runat="server" Text="" runat="server"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        会员姓名：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_PalyName" runat="server" maxlength="20"
                            disabled="disabled" /><span class="gray1" id="span_pName" style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        会员昵称：
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_UserName" runat="server" maxlength="20"
                            onblur="CheckNull(this,'*姓名不能为空')" /><span class="star" id="span_UserName">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        性 别：
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input name="name_Sex" type="radio" value="" id="sel_sex0" onclick="sel_Change(0,3)" />
                                </td>
                                <td style="padding-left: 5px;">
                                    保密
                                </td>
                                <td style="padding-left: 10px;">
                                    <input name="name_Sex" type="radio" value="" id="sel_sex1" onclick="sel_Change(1,3)" />
                                </td>
                                <td style="padding-left: 5px;">
                                    男
                                </td>
                                <td style="padding-left: 10px;">
                                    <input name="name_Sex" type="radio" value="" id="sel_sex2" onclick="sel_Change(2,3)" />
                                </td>
                                <td style="padding-left: 5px;">
                                    女
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        手机：
                    </td>
                    <td>
                        <input name="name_Mobile" type="text" class="textwb" id="txt_Mobile" runat="server"
                            onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="11" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                            onblur="CheckMobile(this,'*手机号码不能为空')" />
                        <input id="btnCheckMobile" class="chax1" type="button" value="不能修改" onclick="goToUrlMobile()" /><span
                            class="star" id="span_Mobile">*</span><span id="a_Mobile"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        邮箱地址：
                    </td>
                    <td>
                        <input name="name_Eail" type="text" class="textwb" id="txt_Email" runat="server"
                            onblur="CheckEmail()" maxlength="50" />
                        <input id="btnCheckEmail" class="chax1" type="button" value="不能修改" onclick="goToUrlEmail()" /><span
                            class="star" id="span_email">*</span><span id="a_Email"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        腾讯QQ：
                    </td>
                    <td>
                        <input name="name_QQ" type="text" class="textwb" id="txt_QQ" runat="server" maxlength="15" />
                        <span class="star" id="spanQQ">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        电话：
                    </td>
                    <td>
                        <input name="name_Mobile" type="text" class="textwb" id="txt_Tel" runat="server"
                            maxlength="20" onblur="CheckNull(this,'')" /><span class="star" id="spanTel"></span>
                    </td>
                </tr>
                <tr>
                    <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
                    </td>
                    <td style="color: #bbbbbb; height: 15px; line-height: 15px; padding: 0;">
                        区号 - 电话号码 - 分机
                    </td>
                </tr>
                <%--<tr id="MyXianShi_two" runat="server">
                    <td class="tab_r">
                        销售商：
                    </td>
                    <td>
                        <asp:Label ID="txtPlace" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr id="CreateTime" runat="server">
                    <td class="tab_r">
                        注册时间：
                    </td>
                    <td>
                        <asp:Label ID="txtPCreateTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="btn_Sure" runat="server" Text="确认修改" CssClass="querbtn" OnClientClick=" return checkSumbit();"
                            OnClick="btn_Sure_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="2"||ShopNum1.Common.Common.ReqStr("type")=="5"||ShopNum1.Common.Common.ReqStr("type")=="4"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <table id="table3" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                runat="server">
                <tr>
                    <td class="tab_r">
                        传真：
                    </td>
                    <td>
                        <input name="name_Fax" type="text" class="textwb" id="txt_Fax" runat="server" maxlength="20" />
                        <span class="star" id="spanFax">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        邮政编码：
                    </td>
                    <td>
                        <input name="name_PostalCode" type="text" class="textwb" id="txt_Post" runat="server"
                            maxlength="10" onblur="CheckNull(this,'*邮政编码必填')" /><span class="star" id="span_PostCode">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        出生日期：
                    </td>
                    <td>
                        <input name="name_Birthday" type="text" class="ss_nrduan1" id="txt_Bth" runat="server"
                            onclick=" WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        从事行业：
                    </td>
                    <td>
                        <input name="name_Vocation" type="text" class="textwb" id="txt_Voc" runat="server"
                            maxlength="50" />
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        个人博客或网站：
                    </td>
                    <td>
                        <input name="name_WebSite" type="text" class="textwb" runat="server" id="txt_WebSite"
                            maxlength="50" style="width: 317px;" />
                        <span class="gray1">请以http://开头</span> <span id="spanWebSite" class="star"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        所在地：
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
                        <input name="name_Address" type="text" class="textwb" id="txt_Address" runat="server"
                            maxlength="200" onblur="CheckNull(this,'*地址不能为空')" style="width: 400px;" /><span
                                class="star" id="span_Address">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="btn_Save" runat="server" Text="保存" CssClass="querbtn" OnClientClick="return  checkSumbitDetil()"
                            OnClick="btn_Save_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="1"||ShopNum1.Common.Common.ReqStr("type")=="5"||ShopNum1.Common.Common.ReqStr("type")=="4"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div>
                <!--弹出层-->
                <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                    runat="server">
                    <tr>
                        <td class="tab_r">
                            我的头像：
                        </td>
                        <td>
                            <asp:Image ID="ImagePath" Style="height: 120px; width: 120px; border-width: 0px;"
                                runat="server" onerror="javascript:this.src='/Main/Account/images/admin_pic.jpg'" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <!--弹出层-->
                            <input name="" type="button" class="selpic" onclick="funOpen()" value="选择图片" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="1"||ShopNum1.Common.Common.ReqStr("type")=="4"||ShopNum1.Common.Common.ReqStr("type")=="2"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div>
                <!--弹出层-->
                <table id="Table5" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                    runat="server">
                    <tr>
                        <td class="tab_r">
                            开户行：
                        </td>
                        <td>
                            <asp:DropDownList ID="TxtBanklist" runat="server">
                                <asp:ListItem Selected="True">农业银行</asp:ListItem>
                                <asp:ListItem>建设银行</asp:ListItem>
                                <asp:ListItem>工商银行</asp:ListItem>
                                <asp:ListItem>邮政银行</asp:ListItem>
                                <asp:ListItem>招行银行</asp:ListItem>
                            </asp:DropDownList>
                            当前已选择：<span style="color: red"><asp:Label ID="TxtBank" runat="server" Text="Label"></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_r">
                            开户姓名：
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBankName" ReadOnly="true" runat="server"></asp:TextBox>&nbsp;&nbsp;<span
                                style="color: Red">开户人的正确姓名</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_r">
                            银行账号：
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBankNo" runat="server"></asp:TextBox>&nbsp;&nbsp;<span style="color: Red">开户人的银行账号</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_r">
                            开户行地址：
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBankAddress" runat="server"></asp:TextBox>&nbsp;&nbsp;<span style="color: Red">开户人的开户银行地址</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnBank" class="querbtn" runat="server" Text="修改银行信息" OnClick="btnBank_Click" />
                            <!--弹出层-->
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
        <input id="hid_Sex" type="hidden" runat="server" value="" />
        <input id="hid_Img" type="hidden" runat="server" value="" />
        <input id="hid_AreaCode" type="hidden" runat="server" value="" />
        <input id="hid_AreaValue" type="hidden" runat="server" value="" />
        <input id="hid_CheckMobile" type="hidden" runat="server" value="" />
        <input id="hid_CheckEmail" type="hidden" runat="server" value="" />
        <input type="hidden" id="hidImgPath" runat="server" />
    </div>
    <div class="sp_dialog sp_dialog_out" style="display: none; height: 575px;" id="sp_dialog_outDiv">
        <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
            <div class="sp_tan">
                <h4>
                    选择图片</h4>
                <div class="sp_close">
                    <a href="javascript:void(0)" onclick="funClose()"></a>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="sp_tan_content" id="A_LoadUserPhoto">
                <iframe src="A_LoadUserPhoto.aspx" id="showiframe" width="100%" height="500" frameborder="0"
                    scrolling="no"></iframe>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(document).ready(
  function () {
      // 加载区域
      $("#p_local").LocationSelect();
      var sextype = $("#<%=hid_Sex.ClientID%>").val();
      if (sextype == "0") {
          $("#sel_sex0").attr("checked", "true");
      }
      else {
          if (sextype == "1") {
              $("#sel_sex1").attr("checked", "true");
          } else {
              $("#sel_sex2").attr("checked", "true");
          }
      }
  }
  );
</script>
<script type="text/javascript" language="javascript">
    // Simple    2013-7-11  对于性别字段的处理
    function sel_Change(i, j) {
        if ($("#sel_sex" + i).attr('checked') == true) {
            $("#<%=hid_Sex.ClientID%>").val(i);
        }
    };
    //simple 2013-7-12 提交地区的信息
    function checkSumbit() {

        //提交时进行格式验证
        var userName = $("#<%=txt_UserName.ClientID%>").val();
        var userEmail = $("#<%=txt_Email.ClientID%>").val();
        var userMobile = $("#<%=txt_Mobile.ClientID%>").val();
        if (!checkPalyName()) {
            return false;
        }

        if (userName == "") {
            $("#<%=txt_UserName.ClientID%>").focus();
            $("#span_UserName").text("*姓名不能为空");
            return false;
        }
        if (!CheckEmailCommon(userEmail)) {
            $("#<%=txt_Email.ClientID%>").focus();
            $("#span_email").text("*邮箱格式不匹配");
            return false;
        }
        if (!CheckMobileCommon(userMobile)) {
            $("#<%=txt_Mobile.ClientID%>").focus();
            $("#span_Mobile").text("*手机号码格式不正确");
            return false;
        }

        if ($("#<%= txt_QQ.ClientID %>").val() != "") {
            var reg = /^[1-9]\d{3,}$/;
            if (!reg.test($("#<%= txt_QQ.ClientID %>").val())) {
                $("#spanQQ").text("腾讯QQ格式输入不正确");
                return false;
            }
        }

    };
</script>
<script type="text/javascript" language="javascript">
    function checkSumbitDetil() {
        if ($("#<%= txt_Fax.ClientID %>").val() != "") {
            var regFax = /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/;
            if (!regFax.test($("#<%= txt_Fax.ClientID %>").val())) {
                $("#spanFax").text("传真格式输入不正确");
                return false;
            }
        }


        var info = $("#p_local").getLocation();
        if (info.pcode == "0") {
            $("#p_local").next().show();
        }
        $("#<%=hid_AreaValue.ClientID%>").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);
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
        };

        if ($("#<%=hid_AreaValue.ClientID%>").val() == ",,|0,0,0") {
            $("#p_local").next().text("*请填写地区信息");
            return false;
        }
        else {
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 3 && $("select[name='city']").find("option").size() != 1) {
                $("#p_local").next().text("*请填写城市信息");
                return false;
            }
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 6 && $("select[name='district']").find("option").size() != 1) {
                $("#p_local").next().text("*请填写区域信息");
                return false;
            }
        };

        //提交验证邮编信息
        var userPostelCode = $("#<%=txt_Post.ClientID%>").val();

        //      if(!CheckPostCodeCommon(userPostelCode))
        //    {
        //           $("#<%=txt_Post.ClientID%>").focus();
        //           $("#span_PostCode").text("*邮政编码不正确");
        //           return false;
        //    }

        if ($("#<%= txt_WebSite.ClientID %>").val() != "" && $("#<%= txt_WebSite.ClientID %>").val().substring(0, 7) != "http://") {
            $("#spanWebSite").text("个人博客或网站格式输入不正确");
            return false;
        }

        var userAddress = $("#<%=txt_Address.ClientID%>").val();
        if (userAddress == "") {
            $("#<%=txt_Address.ClientID%>").focus();
            var userAddress = $("#<%=txt_Address.ClientID%>").next().text("*地址不能为空");
            return false;
        }


    }
</script>
<script type="text/javascript" language="javascript">
    $(document).ready(
 function () {
     var area = $("#<%=hid_AreaValue.ClientID%>").val().split("|");
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
     if ($("#<%=hid_AreaValue.ClientID%>").val() != "") {
         var areacode = area[1].split(",");
         var areaname = area[0].split(",");
         if (areaname[0] != "")
             $("select[name='province']").append("<option value=\"" + code1 + "\" selected=\"selected\">" + areaname[0] + "</option>");
         if (areaname[1] != "")
             $("select[name='city']").append("<option value=\"" + code2 + "\" selected=\"selected\">" + areaname[1] + "</option>");
         if (areaname[2] != "")
             $("select[name='district']").append("<option value=\"" + code3 + "\" selected=\"selected\">" + areaname[2] + "</option>");
     }
 });

    $(function () {
        var isCheckMobile = $("#<%=hid_CheckMobile.ClientID%>").val();
        var isCheckEmail = $("#<%=hid_CheckEmail.ClientID%>").val();
        var strMobile = $("#<%=txt_Mobile.ClientID%>").val();
        var strEmail = $("#<%=txt_Email.ClientID%>").val();
        if (strMobile != null && strMobile != "") {
            if (parseInt(isCheckMobile) == 1) {
                $("#btnCheckMobile").attr("value", "不能修改");
                $("#<%=txt_Mobile.ClientID%>").attr("readonly", "readonly");
                $("#a_Mobile").text("已验证");
            }
            else {
                $("#btnCheckMobile").attr("value", "立即验证");
                $("#a_Mobile").text("未验证");
            }
        }
        else {
            $("#btnCheckMobile").attr("value", "立即验证");
            $("#a_Mobile").text("未验证");
        }

        if (strEmail != null && strEmail != "") {
            if (parseInt(isCheckEmail) == 1) {
                $("#btnCheckEmail").attr("value", "不能修改");
                $("#<%=txt_Email.ClientID%>").attr("readonly", "readonly");
                $("#a_Email").text("已验证");
            }
            else {
                $("#btnCheckEmail").attr("value", "立即验证");
                $("#a_Email").text("未验证");
            }
        }
        else {
            $("#btnCheckEmail").attr("value", "立即验证");
            $("#a_Email").text("未验证");
        }


    })
</script>
<script type="text/javascript">
   
</script>
<script type="text/javascript" language="javascript">
    //手机部分的js验证操作
    function goToUrlMobile() {
        var str = $("#<%=txt_Mobile.ClientID%>").val();
        if (str != "") {
            if (CheckMobileCommon(str)) {
                $.get("/Api/CheckInfo.ashx?type=1&mobile=" + str, null, function (data) {
                    if (data == "1") {
                        document.location.href = "A_BindMobile.aspx?mobile=" + str + "&type=1";
                    }
                    else {
                        var strValue = $("#btnCheckMobile").val();

                        if (strValue != "不能修改" && str != "") {
                            document.location.href = "A_BindMobile.aspx?mobile=" + str + "&type=2";
                        }


                    }
                });
            }
            else {
                $("#span_Mobile").text("手机号码格式错误");
                return false;
            }
        }
        else {
            $("#span_Mobile").text("*手机号码不能为空");
        }
    }
    function CheckMobile() {
        var str = $("#<%=txt_Mobile.ClientID%>").val();
        if (str != "") {
            if (CheckMobileCommon(str)) {
                $.get("/Api/CheckInfo.ashx?type=1&mobile=" + str, null, function (data) {
                    if (data == "1") {
                        $("#span_Mobile").text("手机号码可以进行绑定");
                    }
                    else {
                        var strValue = $("#btnCheckMobile").val();
                        if (strValue != "不能修改") {

                        }
                        else {
                            $("#span_Mobile").text("*");
                        }
                    }
                });
            }
            else {
                $("#span_Mobile").text("手机号码格式错误");
            }
        }
        else {
            $("#span_Mobile").text("手机号码不能为空");
        }
    }

    //邮箱部分的js 验证操作


    function goToUrlEmail() {
        var str = $("#<%=txt_Email.ClientID%>").val();
        if (str != "") {
            if (CheckEmailCommon(str)) {
                $.get("/Api/CheckInfo.ashx?type=12&email=" + str, null, function (data) {
                    if (data == "1") {
                        document.location.href = "A_BindEmail.aspx?Email=" + str + "&type=1";
                    }
                    else {
                        var strValue = $("#btnCheckEmail").val();



                    }
                });
            }
            else {
                $("#span_email").text("邮箱格式错误");
                return false;
            }
        }
        else {
            $("#span_email").text("邮箱不能为空");
            return false;
        }
    }
    function CheckEmail() {
        var str = $("#<%=txt_Email.ClientID%>").val();

        if (str != "") {
            if (CheckEmailCommon(str)) {
                $.get("/Api/CheckInfo.ashx?type=12&Email=" + str, null, function (data) {
                    if (data == "1") {
                        $("#span_email").text("邮箱可以进行绑定");
                    }
                    else {
                        var strValue = $("#btnCheckEmail").val();
                        if (strValue != "不能修改") {

                        }
                        else {
                            $("#span_email").text("*");
                        }
                    }
                });
            }
            else {
                $("#span_email").text("邮箱格式格式错误");
            }
        }
        else {
            $("#span_email").text("邮箱不能为空");
        }
    }
</script>
