<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_AdPayTransfer.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AdPayTransfer" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=0" style="text-decoration: none;">ת��</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=1" style="text-decoration: none;">ת���б�</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayTransfer.aspx?type=2" style="text-decoration: none;">ת���б�</a></li>
    </ul>
    <div id="content">
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        �û���ţ�
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label></strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ��ǰ����ң�
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">��<asp:Label ID="Lab_AdPayment" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �տ��˱�ţ�
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_TransferID" runat="server"
                            onblur="funCheckTransferID()" /><span class="star" id="errTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ȷ���տ��˱�ţ�
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_ConfirmTransferID" runat="server"
                            onblur="funSameName()" /><span class="star" id="errConfirmTransferID">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ȷ���տ���������
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_TransferName" runat="server" /><span
                            class="star" id="Span1">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ת�˽�
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Transfer" runat="server" value="0.00"
                            style="width: 100px;" onblur="funTransfer()" /><span class="star">Ԫ</span><span id="errTransfer"
                                style="color: Red"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �������룺
                    </td>
                    <td>
                        <input name="input" type="password" class="textwb" id="input_PayPwd" runat="server"
                            onblur="funCheckPayPwd()" /><span class="star" id="errPwd">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ��Ա��ע��
                    </td>
                    <td>
                        <textarea id="txt_Remark" cols="20" rows="2" class="textwb" style="width: 430px;
                            height: 90px; margin-top: 5px;" runat="server" onchange="CheckFull(this,200)"></textarea><br />
                        (��Աת�˱�ע���Ȳ��ܴ���100���ַ�) <span class="gray1" style="color: Red">&nbsp;</span>
                    </td>
                </tr>
                <tr id="tr1221" runat="server">
                    <td class="tab_r">
                        <span class="form_left">���ֻ����룺 </span>
                    </td>
                    <td>
                        <asp:Label ID="nextmobile" runat="server" Text="" CssClass="orm_right f14" runat="server">
                
                        </asp:Label>
                    </td>
                </tr>
                <tr id="tr12211" runat="server">
                    <td class="tab_r">
                        <span class="form_left">��֤�룺 </span>
                    </td>
                    <td>
                        <input type="text" id="txtMCode" style="border: 1px solid #CCCCCC; height: 20px;
                            width: 80px;" onblur="existcode()" />
                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX" border="0" onclick="reloadcode2()"
                            alt="������?��һ��" />
                        <a onclick="reloadcode2()">���������</a>
                    </td>
                </tr>
                <tr id="tr12221" runat="server">
                    <td class="tab_r">
                    </td>
                    <td>
                        <input type="text" id="M_code" name="code" data-tip="��֤��" maxlength="6" class="intext intext_short nullv tov vfb"
                            autocomplete="off" runat="server" disabled="disabled" runat="server" />
                        <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="�����ѻ�ȡ"
                            style="width: 100px; height: 25px; margin-left: 10px" />

                        <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">�ղ���������֤�룿
                        </a><span id="spanConfirm"></span>
                        <div style="display: none;" class="tooltip cp_tooltip">
                            ������֤�뷢�ͺ�30�����ھ���ʹ�á���֤����ž�������ʱ������ͨѶ�쳣���ܻ���ɶ��Ŷ�ʧ����ʱ���������ĵȴ������߻�һ��ʱ��ν�����ز�����
                        </div>
                        <span class="vc vf" id="yzMsg" style="display: none">��������֤�� </span>
                         <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw" id="spanShowMsg" state="0" style="color: Red;
                            padding-left: 10px;">
                </div>
               
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="ȷ��" CssClass="baocbtn" OnClientClick=" return funCheckButton()"
                            OnClick="Btn_Confirm_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            ת�˵��ţ�
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            ����ʱ�䣺
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_StartTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan Wdate" runat="server" id="txt_EndTime" onclick="WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Button ID="Btn_Select" runat="server" Text="��ѯ" CssClass="chax btn_spc" />
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;">
                        &nbsp;&nbsp;&nbsp; ת�˱�����<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>�� &nbsp;&nbsp;&nbsp; ת�˽� ��<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayTransfer" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        ת�˵���
                    </th>
                    <th>
                        ��������
                    </th>
                    <th>
                        ת�˽��
                    </th>
                    <th>
                        �տ���ID
                    </th>
                    <th>
                        ��ע
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayTransfer">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td style="color: Red">
                                <%=ShopNum1.Common.Common.ReqStr("type")=="2"?"+":"-"%><%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "RMemberID")%>
                            </td>
                            <td class="picture">
                                <span style="display: none;">
                                    <%#Eval("Memo").ToString() %></span>
                                <%#(Eval("Memo").ToString().Length > 15? Eval("Memo").ToString().Substring(0, 15) + "..." : Eval("Memo").ToString())%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 86px;" colspan="5">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--��ҳ-->
            <div class="fenye">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_b">
                    <tr>
                        <td style="border-right: none; border-left: solid 1px #e3e3e3; width: 30px;">
                            &nbsp;
                        </td>
                        <td style="border-left: none;">
                            <div id="pageDiv" runat="server" class="fy">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <!--��ҳ-->
        </div>
    </div>
</div>
<style type="text/css">
    #tooltip
    {
        position: absolute;
        z-index: 1000;
        max-width: 300px;
        width: auto !important;
        width: auto;
        background: #e3e3e3;
        border: #FEFFD4 solid 1px;
        text-align: left;
        padding: 3px;
    }
    #tooltip p
    {
        padding: 10px;
        color: #FF0000;
        font: 12px verdana,arial,sans-serif;
        line-height: 180%;
    }
</style>
<input type="hidden" value="" id="havaUser" runat="server" />
<input type="hidden" value="" id="HiddenPayPwd" runat="server" />
<%--    <script type="text/javascript" language="javascript">--%>
<script type="text/javascript" language="javascript">
    //         function ontoPage(txtId)
    //         {
    //               location.href='?sort=<%=ShopNum1.Common.Common.ReqStr("sort")%>&typeid=<%=ShopNum1.Common.Common.ReqStr("typeid")%>&pageid='+$("#txtIndex").val();
    //         }
    $(function () {
        //������ʾЧ����
        var sweetTitles = {
            x: 10, y: 20, tipElements: ".picture", init: function () {
                $(this.tipElements).mouseover(function (e) {
                    var myTitle = $(this).find("span").html(); var tooltip = "";
                    tooltip = "<div id='tooltip'><p>" + myTitle + "</p></div>";
                    $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX - 50) + "px" }).show('fast'); $('body').append(tooltip);
                }).mouseout(function () { $('#tooltip').remove(); }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX - 50) + "px" }); });
            }
        };
        sweetTitles.init();
    });
</script>
<script>

    function funCheckButton() {
        if ($("#<%=txt_Remark.ClientID%>").val().length > 100) {
            alert("��Աת�˱�ע���Ȳ��ܴ���100���ַ���"); return false;
        }
        funCheckTransferID(); funTransfer(); funCheckPayPwd();
        if ($("#<%=havaUser.ClientID%>").val() == "1" && funTransfer() && $("#<%=HiddenPayPwd.ClientID %>").val() == "1") {
            return true;
        }
        return false;
    }

    function funCheckPayPwd() {
        var payPwd = $("#<%=input_PayPwd.ClientID%>").val();
        if (payPwd != "") {
            $("#errPwd").html("��ѯ��...");
            $.ajax({
                type: "get",
                url: "/Api/ShopAdmin/S_AdminOpt.ashx?date=" + new Date(),
                async: false,
                data: "type=paypwd&payPwd=" + payPwd,
                dataType: "html",
                success: function (ajaxData) {
                    if (ajaxData != "") {
                        if (ajaxData == "false") {
                            $("#errPwd").html("�����������");
                            $("#<%=HiddenPayPwd.ClientID %>").val("0");
                            return true;
                        }
                        else if (ajaxData == "true") {
                            $("#errPwd").html("*");
                            $("#<%=HiddenPayPwd.ClientID %>").val("1");
                            return false;
                        }
                    }
                }
            });
        }
        else {
            $("#errPwd").html("�������벻��Ϊ�գ�");
        }

    }

    function funTransfer() {
        var Transfer = $("#<%=txt_Transfer.ClientID%>").val()
        if (Transfer != "") {
            var oo = /^(-)?(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/;
            if (!oo.test(Transfer)) {
                $("#errTransfer").html("ת�˽���ʽ����");
                return false;
            }
            else {
                if (parseFloat(Transfer) > 0) {
                    var txtMoney = parseFloat($("#<%=Lab_AdPayment.ClientID%>").text());
                    if (txtMoney < parseFloat(Transfer)) {
                        $("#errTransfer").html("ת�˽��ܴ��ڵ�ǰ����ң�");
                        return false;
                    }
                    else {
                        $("#errTransfer").html("");
                        return true;
                    }
                }
                else {
                    $("#errTransfer").html("ת�˽���Ϊ0���߸�����");
                    return false;
                }

            }
            return false;
        }
        else {
            $("#errTransfer").html("ת�˽���Ϊ�գ�");
            return false;
        }
    }

    function funSameName() {
        var samename = $("#<%=txt_ConfirmTransferID.ClientID%>").val();
        var yuanname = $("#<%=txt_Transfer.ClientID%>ID").val();
        if (samename != yuanname) {
            $("#errConfirmTransferID").html("ȷ���տ���ID���벻��ȷ��");
            return false;
        }
        else {
            $("#errConfirmTransferID").html("*");
            return true;
        }
    }


    function funCheckTransferID() {
        var TransferID = $("#<%=txt_Transfer.ClientID%>ID").val();
        if (TransferID != "") {
            if ($("#<%=Lab_MemLoginID.ClientID%>").text() == TransferID) {
                $("#errTransferID").html("���ܸ��Լ�ת�ˣ�");
                return false;
            }
            else {
                //�տ����Ƿ����
                $.ajax({
                    url: "/api/CheckMemberLogin.ashx",
                    data: encodeURI("type=userisexist&UserID=" + TransferID + ""), //���ı���
                    success: function (result) {
                        if (result != null) {
                            if (result) {
                                $("#errTransferID").html("*");
                                $("#<%=havaUser.ClientID%>").val("1")
                                return true;
                            } else {
                                $("#errTransferID").html("�տ��˲����ڣ�");
                                $("#<%=havaUser.ClientID%>").val("0")
                                return false;
                            }
                        } else {
                            return false;
                        }
                    }
                });

                $("#errTransferID").html("");
            }
        } else { $("#errTransferID").html("�տ��˲���Ϊ�գ�"); return false; }
    }
</script>
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

        $("#J_cannot_receive").click(function () {
            $(".cp_tooltip").show(); setTimeout(function () { $(".cp_tooltip").hide(); }, 3000);
        });
        $("#J_ver_btn").click(function () {
            if ($("#txtMCode").val() == "") {
                $("#spanShowMsg").text("��֤�벻��Ϊ�գ�"); return false;
            }
            if ($("#spanShowMsg").attr("state") == "0") {
                $("#spanShowMsg").text("��֤�벻��ȷ��"); return false;
            }
            $("#J_ver_btn").attr("disabled", "disabled");
            $("#<%= M_code.ClientID %>").removeAttr("disabled");
            $("#spanConfirm").get(0).className = "";
            // $("#spanShowMsg").get(0).className="onCorrect1";
            $("#spanShowMsg").text("�����ѷ��ͣ������ĵȴ�...");
            $("#spanShowMsg").attr("style", "color:green; padding-left:10px;");
            $thisid = $(this);
            timerId = setInterval("goTo()", 1000);
            $.get("/Api/CheckInfo.ashx?type=2&Mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
                //alert("�ֻ�������֤���ѷ��ͣ������ĵȴ�......");
                if (data != "1") {
                    $("#spanShowMsg").get(0).className = "onError1";
                    $("#spanShowMsg").text("���ŷ��ͳ����쳣����������֤");
                }
            });
        });

        $("#<%= M_code.ClientID %>").focus(function () {
            $("#spanShowMsg").get(0).className = "onTips1";
            $("#spanShowMsg").text("��֤����6λ�ַ�");
            $("#spanConfirm").get(0).className = "";
        });

        $("#<%= M_code.ClientID %>").blur(function () {
            if (this.value == "") {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("��������֤��");
            }
            else {
                $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
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
            clearInterval(timerId); i = 60;
            $thisid.removeAttr("disabled");
        }
    }
</script>
<%--<script type="text/javascript" language="javascript">
    function Btn_Confirm_Click() {
        if ($("#<%= M_code.ClientID %>").val() == "") {
            $("#spanShowMsg").get(0).className = "onError1";
            $("#spanShowMsg").text("��������֤��");
            return;
        }

        $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
            if (data == "1") {
                window.location.href = "A_UpProtection.aspx?Mobile=" + $("#<%=nextmobile.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val();
            }
            else {
                $("#spanShowMsg").get(0).className = "onError1";
                $("#spanShowMsg").text("��֤�������ѹ��ڣ�����������!");
            }
        });
    }

    function GoURL() {
        window.location.href = "A_UpProtection.aspx?Mobile=" + $("#<%=nextmobile.ClientID%>").text() + "&key=" + $("#<%=M_code.ClientID%>").val() + "&type=Email";
    };
    function goNext() {
        setTimeout(GoURL, 1000);
    }

</script>--%>
