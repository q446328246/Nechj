<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_CheckEmail.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_CheckEmail" %>
<script type="text/javascript">
    var timerId;
    var $thisid;
    $(function () {
        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });

        $("#J_ver_btn").click(function () {
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            $("#spanShowMsg").get(0).className = "onCorrect1";
            $("#spanShowMsg").text("�ʼ��ѷ��ͣ������ĵȴ�...");
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=4&Email=" + $("#<%=nextEmail.ClientID%>").text(), null, function (data) {
                //alert("�ʼ��ѷ��ͣ������ĵȴ�......");
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("�ʼ����ͳ����쳣����������֤");
                }
            });
        });

        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("��֤����8λ�ַ�");
            $("#spanConfirm").get(0).className = "";
        });

        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("��������֤��");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=5&key=" + $("#<%=M_code.ClientID%>").val() + "&Email=" + $("#<%=nextEmail.ClientID%>").text(), null, function (data) {
                    if (data == "1") {
                        $("#spanConfirm").get(0).className = "onCorrect1";
                        $("#spanConfirm").text("");
                        $("#spanShowMsg").get(0).className = "";
                        $("#spanShowMsg").text("");
                    }
                    else {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("��֤�������ѹ��ڣ�����������!");
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
</script>
<div id="mobilecheck" runat="server">
    <div class="main-right" id="main-right">
        <div class="ps_width clearfix">
            <div class="zhszmian1">
                <ul class="mimbz">
                    <li class="bzone" id="li_send">1.������֤��</li>
                    <li class="bztwo" id="li_get">2.�����µĽ�������</li>
                    <li class="bzthree" id="li_succuess">3.�����������óɹ� </li>
                </ul>
            </div>
            <div style="clear: both;">
            </div>
            <div class="form_top" id="step2">
                <div class="form_row">
                    <span class="form_left">�������˺ţ� </span>
                    <asp:Label ID="nextEmail" runat="server" CssClass="orm_right f14"></asp:Label>
                </div>
                <div class="form_row">
                    <span class="form_left">��֤�룺 </span>
                    <div class="form_right">
                        <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="�����ѻ�ȡ"
                            style="width: 150px;" />
                        <input type="text" id="M_code" name="code" data-tip="��֤��" maxlength="8" class="intext intext_short nullv tov vfb"
                            autocomplete="off" runat="server" disabled="disabled">
                        <div>
                            <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">�ղ����ʼ���֤�룿
                            </a><span id="spanConfirm"></span>
                            <div style="display: none;" class="tooltip cp_tooltip">
                                ������֤�뷢�ͺ�30�����ھ���ʹ�á��ʼ��ղ�����֤�룬����������������˷��������ã���ֹİ���ʼ���ԭ���������ü������������ʼ���
                            </div>
                        </div>
                        <%--<span class="vc vf" id="yzMsg" style="display:none">
                        ��������֤��
                    </span>--%>
                    </div>
                </div>
                <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw">
                        <%--��֤����8λ����--%>
                        <span id="spanShowMsg"></span></span>
                </div>
                <div id="J_phone_msg_row" class="form_row form_height_auto_row nice_info_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right" style="line-height: 20px; height: 40px;">
                        <div class="phone_info">
                            <div id="J_phone_info">
                                <span class="l">������֤�뷢�ͺ�30�����ھ���ʹ�� </span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form_row form_height_auto_row clearfix">
                    <span class="form_left"></span>
                    <div class="form_right">
                        <input type="button" class="querbtn" data-tid="bindphone_uid_button068" data-tprefix="/virtual/ucenter/myfanli"
                            onclick="checkkey()" value="ȷ��" />
                    </div>
                </div>
            </div>
        </div>
        <div id="step3" style="display: none; line-height: 20px;">
            <center>
                <div style="height: 30px; line-height: 30px; margin-top: 10px;">
                    <font style="font-size: 16px; font-family: ΢���ź�; display: block; margin-bottom: 20px;">
                        <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>, ����ɹ�</font>
                </div>
                <br />
                <input type="btn_Next" style="width: 60px" class="J_ftrack btn btn-green" data-tid="bindphone_uid_button068"
                    data-tprefix="/virtual/ucenter/myfanli" value="��һ��" onclick="goNext()" />
            </center>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    function checkkey() {
        if ($("#<%= M_code.ClientID %>").val() == "") {
            $("#spanShowMsg").get(0).className = "onError1";
            $("#spanShowMsg").text("��������֤��");
            return;
        }

        $.get("/Api/CheckInfo.ashx?type=5&key=" + $("#<%=M_code.ClientID%>").val() + "&Email=" + $("#<%=nextEmail.ClientID%>").text(), null, function (data) {
            if (data == "1") {
                window.location.href = "A_UpPayPwd.aspx?Email=" + $("#<%=nextEmail.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("��֤�������ѹ��ڣ�����������!");
            }
        });
    }
</script>
