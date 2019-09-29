<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_BindMobile.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_BindMobile" %>
<script type="text/javascript">
    function reloadcode2() {
        var verify = document.getElementById('ImgX');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    //��֤��
    function existcode() {
        var boolresult = true;
        var inputcontrol = $("#txtMCode").val();
        var context = document.getElementById("spanShowMsg");
        if (inputcontrol != "") {
            $.ajax({
                url: "/api/CheckMemberLogin.ashx",
                data: "type=findpwdverifycode&findpwdcode=" + inputcontrol + "",
                success: function (result) {
                    if (result == "true") {
                        context.innerHTML = "";
                        //context.className="onCorrect1";
                        $("#spanShowMsg").attr("state", "1");
                        boolresult = true;
                    } else {
                        boolresult = false;
                        context.innerHTML = "��֤�����";
                        //context.className="onError1";
                        $("#spanShowMsg").attr("state", "0");
                    }
                }
            });
        }
        else {
            context.innerHTML = "��֤�벻��Ϊ��";
            $("#spanShowMsg").attr("state", "0");
            //context.className="onError1";
            boolresult = false;
        }
        return boolresult;
    }

    var timerId;
    var $thisid;
    $(function () {
        $("#a1").click(function () {

            if (ExistMobile()) {
                $.get("/Api/CheckInfo.ashx?type=1&mobile=" + $("#J_cellphone").val(), null, function (data) {
                    if (data == "1") {
                        $("#step1").hide();
                        $("#nextmobile").html($("#J_cellphone").val());
                        $("#step2").show();
                        $("#li_Select").removeClass(".first current");
                        $("#li_GetCode").removeClass(".next");
                        $("#li_GetCode").addClass(".first current");
                    }
                    else {
                        $("#span_MobileValue").get(0).className = "onError1";
                        $("#span_MobileValue").text("�ֻ������Ѿ���ʹ����");
                    }
                });
            }
        });

        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);

        });
        $("#J_ver_btn").click(function () {
            if ($("#spanShowMsg").attr("state") == "0") {
                $("#spanShowMsg").text("��֤�����!"); return false;
            }
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            $("#spanShowMsg").get(0).className = "onCorrect1";
            $("#spanShowMsg").text("�ֻ�������֤���ѷ��ͣ������ĵȴ�...");
            $("#J_phone_msg_row").hide();
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=2&mobile=" + $("#nextmobile").text(), null, function (data) {
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("�ֻ�������֤�뷢���쳣����������֤");
                }
            });
        });
        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("��֤����6λ�ַ�");
            $("#spanConfirm").get(0).className = "";
        })
        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("��������֤��");
            } else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#nextmobile").text(), null, function (data) {
                    if (data == "1") {
                        $("#spanShowMsg").get(0).className = "";
                        $("#spanShowMsg").text("");
                        $("#spanConfirm").get(0).className = "onCorrect1";
                        $("#spanConfirm").text("");

                    } else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("��֤�������ѹ��ڣ����������룡");
                    }
                });
            }
        });

        $("#a2").click(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("��������֤��");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#nextmobile").text(), null, function (data) {
                    if (data == "1") {
                        $("#li_Select").removeClass(".first current");
                        $("#li_GetCode").removeClass(".first current");
                        $("#li_GetCode").addClass(".next");
                        $("#li_Succuess").removeClass(".last");
                        $("#li_Succuess").addClass(".first current");
                        $("#span_Mobile").text($("#nextmobile").text());
                        $("#step2").hide(); $("#step3").show();
                        $("#<%= hid_Mobile.ClientID %>").val($("#nextmobile").text());

                    }
                    else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("��֤�������ѹ��ڣ����������룡");
                    }
                });
            }
        });
    });
    var i = 60;
    function goTo() {
        i--;
        $thisid.val("�ѷ�����֤��(" + i + "��)");
        if (i == 0) {
            $thisid.val("��ѻ�ȡ��֤��");
            clearInterval(timerId);
            i = 60;
            $thisid.removeAttr("disabled");
        }
    }

    function BtnSubmit() {
        if ($("#<%= hid_Mobile.ClientID %>").val() == "")
            return false;
        else
            return true;
    }
        
</script>
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right" style="float: none;">
        <div class="ps_width clearfix" style="margin-left: 5px;">
            <h1 class="bw h1c">
            </h1>
            <div class="notify main_tip">
                <div class="notify_correct">
                    <span class="f14 bw rw notify_correct_text">��ɰ��ֻ���������Ч��ֹ�˻����������ʧ�� </span>
                    <ul>
                        <li>�ֻ�����󶨺���Ե�¼�̳ǵ�½�����������޸ĵȲ�����</li>
                        <li>�̳ǻ��������Ϣ�ϸ��ܡ�</li>
                    </ul>
                </div>
            </div>
            <div class="pp_steps three_steps">
                <ol>
                    <li class="first current" id="li_Select"><span>1.�����ֻ�����</span> </li>
                    <li class="next" id="li_GetCode"><span>2.��д������֤��</span> </li>
                    <li class="last" id="li_Succuess"><span>3.�󶨳ɹ�</span> </li>
                </ol>
            </div>
            <div class="form_top" id="step1">
                <div class="form_row" id="divProMobile" runat="server">
                    <span class="form_left">����֤�ֻ��� </span>
                    <div class="form_right" style="position: relative;">
                        <span class="star" id="spanMobileValue"></span>
                    </div>
                </div>
                <div class="form_row">
                    <span class="form_left">�������ֻ����룺 </span>
                    <div class="form_right" style="position: relative;">
                        <span id="J_m_77cbc1f75a" style="display: none; position: absolute; left: 0px; top: -42px;"
                            class="mf"></span>
                        <input type="text" name="mobile" maxlength="11" id="J_cellphone" class="intext nullv tov"
                            onblur="CheckMobile()">
                        <span id="span_MobileValue" class="star"></span><i class="safe_center_saftey_icon">
                        </i>
                    </div>
                </div>
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <a href="javascript:void(0)" id="a1" class="btn btn-green J_ftrack">ȷ�ϰ�</a>(��ͬ�ֻ���һ���ȡ��֤���������(3-5��))
                    </div>
                </div>
            </div>
            <div class="form_top" style="display: none" id="step2">
                <div class="form_row">
                    <span class="form_left">���ֻ����룺 </span><span class="form_right f14" id="nextmobile">
                    </span>
                </div>
                <input type="hidden" value="13545281376" name="mobile" class="tov">
                <div class="form_row">
                    <span class="form_left">��֤�룺 </span>
                    <div class="form_right">
                        <div>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" id="txtMCode" style="border: 1px solid #CCCCCC; height: 20px;
                                            width: 80px;" onblur="existcode()" />
                                    </td>
                                    <td style="padding-left: 7px;">
                                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX" border="0" onclick="reloadcode2()"
                                            alt="������?��һ��" />
                                    </td>
                                    <td style="padding-left: 8px;">
                                        <a onclick="reloadcode2()">���������</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-top: 10px;">
                            <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="�����ѻ�ȡ"
                                style="width: 150px;" />
                            <input type="text" id="M_code" name="code" data-tip="��֤��" disabled="disabled" maxlength="6"
                                class="intext intext_short nullv tov vfb" runat="server">
                            <div>
                                <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">�ղ���������֤�룿
                                </a><span id="spanConfirm"></span>
                                <div style="display: none;" class="tooltip cp_tooltip">
                                    ������֤�뷢�ͺ�30�����ھ���ʹ�á���֤����ž�������ʱ������ͨѶ�쳣���ܻ���ɶ��Ŷ�ʧ����ʱ���������ĵȴ������߻�һ��ʱ��ν�����ز�����
                                </div>
                            </div>
                            <span class="vc vf" id="yzMsg" style="display: none">��������֤�� </span>
                        </div>
                    </div>
                </div>
                <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw">
                        <%-- ��֤����6λ����--%>
                        <span id="spanShowMsg"></span></span>
                </div>
                <div id="J_phone_msg_row" class="form_row form_height_auto_row nice_info_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <div class="phone_info">
                            <div id="J_phone_info">
                                <span class="l">������֤�뷢�ͺ�30�����ھ���ʹ�� </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right" style="text-align: right;">
                        <a data-tid="bindphone_uid_button068" data-tprefix="/virtual/ucenter/myfanli" href="javascript:void(0)"
                            id="a2" class="J_ftrack btn btn-green">ȷ�ϰ� </a><span id="spanShowMsg" state="0"
                                style="color: Red; padding-left: 10px;"></span>(��ͬ�ֻ���һ���ȡ��֤���������(3-5��))
                    </div>
                </div>
            </div>
            <div id="step3" style="display: none">
                <center>
                    <font style="font-size: 16px; font-family: ΢���ź�; display: block; margin-bottom: 20px;
                        margin-top: 10px;">
                        <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label> ��ϲ�㣬�ֻ����� <span
                            id="span_Mobile"></span>�󶨳ɹ� </font>
                    <br />
                    <asp:Button ID="btn_Next" runat="server" Text="ȷ��" data-tid="bindphone_uid_button068"
                        data-tprefix="/virtual/ucenter/myfanli" class="J_ftrack btn btn-green" OnClientClick="return BtnSubmit()" onclick="btn_Next_Click"/>
                    <input type="hidden" name="mobile" class="tov" runat="server" id="hid_Mobile"  />
                </center>
            </div>
            <div class="form_top">
                <div class="form_row form_height_auto_row clearfix">
                    <div class="bp_faq">
                        <h4 class="bw f16">
                            ����˵����
                        </h4>
                        <ul>
                            <li class="bw bp_q">�÷�����ȫ��ѣ� </li>
                            <li>��󶨵��ֻ����룬�ɽ��е�½�̳�ϵͳ���޸Ľ�������Ȳ��������ǻ�������Ϣ�����ϸ�ı��ܡ� </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {

        if (window.location.search.indexOf('type=1') > 0) {
            $("#J_cellphone").val($("#<%= hid_Mobile.ClientID %>").val());
        }

        if ($("#<%= hid_Mobile.ClientID %>").val() != "") {
            $("#spanMobileValue").text($("#<%= hid_Mobile.ClientID %>").val());
            $("#<%= hid_Mobile.ClientID %>").val("");
        }
    });

    function ExistMobile() {
        var v_flag = false;
        var str = $("#J_cellphone").val();
        if (str != "") {
            if (CheckMobileCommon(str)) {
                v_flag = true;
            }
            else {
                $("#span_MobileValue").get(0).className = "onError1";
                $("#span_MobileValue").text("��������Ч���ֻ�����");
            }
        }
        else {
            $("#span_MobileValue").get(0).className = "onError1";
            $("#span_MobileValue").text("�������ֻ�����");
        }
        return v_flag;
    }

    function CheckMobile() {
        if (ExistMobile()) {

            $.ajax({
                url: "/api/CheckInfo.ashx",
                data: "type=1&mobile=" + $("#J_cellphone").val(),
                success: function (data) {
                    if (data == "1") {
                        $("#span_MobileValue").get(0).className = "onCorrect1";
                        $("#span_MobileValue").text("");
                    }
                    else {
                      $("#span_MobileValue").get(0).className = "onError1";
                        $("#span_MobileValue").text("�ֻ������Ѿ���ʹ����");
                    }
                }
            });

                        $.get("/Api/CheckInfo.ashx?type=1&mobile=" + $("#J_cellphone").val(), null, function (data) {
                            if (data == "1") {
                                $("#span_MobileValue").get(0).className = "onCorrect1";
                                $("#span_MobileValue").text("");
                            }
                            else {
                                $("#span_MobileValue").get(0).className = "onError1";
                                $("#span_MobileValue").text("�ֻ������Ѿ���ʹ����");
                            }
                        });
        }
    }
  
</script>
