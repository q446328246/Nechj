<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_MemInfo.ascx.cs" Inherits="ShopNum1.Deploy.Main.Account.Skin.A_MemInfo" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.AccountWebControl" %>
<div id="list_main" class="list_main">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=0" style="text-decoration: none;">������Ϣ</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=1" style="text-decoration: none;">��ϸ��Ϣ</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=2" style="text-decoration: none;">����ͷ��</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="5"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_MemInfo.aspx?type=5" style="text-decoration: none;">������Ϣ</a></li>
    </ul>
    <div id="content">
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table id="Table2" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                runat="server">
                <tr>
                    <td class="tab_r">
                        �û�����
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text="" runat="server"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �û���ţ�
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginNO" runat="server" Text="" runat="server"></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ��Ա������
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_PalyName" runat="server" maxlength="20"
                            disabled="disabled" /><span class="gray1" id="span_pName" style="color: Red">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ��Ա�ǳƣ�
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_UserName" runat="server" maxlength="20"
                            onblur="CheckNull(this,'*��������Ϊ��')" /><span class="star" id="span_UserName">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �� ��
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <input name="name_Sex" type="radio" value="" id="sel_sex0" onclick="sel_Change(0,3)" />
                                </td>
                                <td style="padding-left: 5px;">
                                    ����
                                </td>
                                <td style="padding-left: 10px;">
                                    <input name="name_Sex" type="radio" value="" id="sel_sex1" onclick="sel_Change(1,3)" />
                                </td>
                                <td style="padding-left: 5px;">
                                    ��
                                </td>
                                <td style="padding-left: 10px;">
                                    <input name="name_Sex" type="radio" value="" id="sel_sex2" onclick="sel_Change(2,3)" />
                                </td>
                                <td style="padding-left: 5px;">
                                    Ů
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �ֻ���
                    </td>
                    <td>
                        <input name="name_Mobile" type="text" class="textwb" id="txt_Mobile" runat="server"
                            onkeyup="this.value=this.value.replace(/\D/g,'')" maxlength="11" onafterpaste="this.value=this.value.replace(/\D/g,'')"
                            onblur="CheckMobile(this,'*�ֻ����벻��Ϊ��')" />
                        <input id="btnCheckMobile" class="chax1" type="button" value="�����޸�" onclick="goToUrlMobile()" /><span
                            class="star" id="span_Mobile">*</span><span id="a_Mobile"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �����ַ��
                    </td>
                    <td>
                        <input name="name_Eail" type="text" class="textwb" id="txt_Email" runat="server"
                            onblur="CheckEmail()" maxlength="50" />
                        <input id="btnCheckEmail" class="chax1" type="button" value="�����޸�" onclick="goToUrlEmail()" /><span
                            class="star" id="span_email">*</span><span id="a_Email"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ��ѶQQ��
                    </td>
                    <td>
                        <input name="name_QQ" type="text" class="textwb" id="txt_QQ" runat="server" maxlength="15" />
                        <span class="star" id="spanQQ">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �绰��
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
                        ���� - �绰���� - �ֻ�
                    </td>
                </tr>
                <%--<tr id="MyXianShi_two" runat="server">
                    <td class="tab_r">
                        �����̣�
                    </td>
                    <td>
                        <asp:Label ID="txtPlace" runat="server"></asp:Label>
                    </td>
                </tr>--%>
                <tr id="CreateTime" runat="server">
                    <td class="tab_r">
                        ע��ʱ�䣺
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
                        <asp:Button ID="btn_Sure" runat="server" Text="ȷ���޸�" CssClass="querbtn" OnClientClick=" return checkSumbit();"
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
                        ���棺
                    </td>
                    <td>
                        <input name="name_Fax" type="text" class="textwb" id="txt_Fax" runat="server" maxlength="20" />
                        <span class="star" id="spanFax">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �������룺
                    </td>
                    <td>
                        <input name="name_PostalCode" type="text" class="textwb" id="txt_Post" runat="server"
                            maxlength="10" onblur="CheckNull(this,'*�����������')" /><span class="star" id="span_PostCode">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        �������ڣ�
                    </td>
                    <td>
                        <input name="name_Birthday" type="text" class="ss_nrduan1" id="txt_Bth" runat="server"
                            onclick=" WdatePicker({dateFmt:'yyyy-MM-dd'})" />
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ������ҵ��
                    </td>
                    <td>
                        <input name="name_Vocation" type="text" class="textwb" id="txt_Voc" runat="server"
                            maxlength="50" />
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ���˲��ͻ���վ��
                    </td>
                    <td>
                        <input name="name_WebSite" type="text" class="textwb" runat="server" id="txt_WebSite"
                            maxlength="50" style="width: 317px;" />
                        <span class="gray1">����http://��ͷ</span> <span id="spanWebSite" class="star"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ���ڵأ�
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
                        <input name="name_Address" type="text" class="textwb" id="txt_Address" runat="server"
                            maxlength="200" onblur="CheckNull(this,'*��ַ����Ϊ��')" style="width: 400px;" /><span
                                class="star" id="span_Address">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="btn_Save" runat="server" Text="����" CssClass="querbtn" OnClientClick="return  checkSumbitDetil()"
                            OnClick="btn_Save_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="1"||ShopNum1.Common.Common.ReqStr("type")=="5"||ShopNum1.Common.Common.ReqStr("type")=="4"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div>
                <!--������-->
                <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                    runat="server">
                    <tr>
                        <td class="tab_r">
                            �ҵ�ͷ��
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
                            <!--������-->
                            <input name="" type="button" class="selpic" onclick="funOpen()" value="ѡ��ͼƬ" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="1"||ShopNum1.Common.Common.ReqStr("type")=="4"||ShopNum1.Common.Common.ReqStr("type")=="2"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div>
                <!--������-->
                <table id="Table5" width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao"
                    runat="server">
                    <tr>
                        <td class="tab_r">
                            �����У�
                        </td>
                        <td>
                            <asp:DropDownList ID="TxtBanklist" runat="server">
                                <asp:ListItem Selected="True">ũҵ����</asp:ListItem>
                                <asp:ListItem>��������</asp:ListItem>
                                <asp:ListItem>��������</asp:ListItem>
                                <asp:ListItem>��������</asp:ListItem>
                                <asp:ListItem>��������</asp:ListItem>
                            </asp:DropDownList>
                            ��ǰ��ѡ��<span style="color: red"><asp:Label ID="TxtBank" runat="server" Text="Label"></asp:Label></span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_r">
                            ����������
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBankName" ReadOnly="true" runat="server"></asp:TextBox>&nbsp;&nbsp;<span
                                style="color: Red">�����˵���ȷ����</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_r">
                            �����˺ţ�
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBankNo" runat="server"></asp:TextBox>&nbsp;&nbsp;<span style="color: Red">�����˵������˺�</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="tab_r">
                            �����е�ַ��
                        </td>
                        <td>
                            <asp:TextBox ID="TxtBankAddress" runat="server"></asp:TextBox>&nbsp;&nbsp;<span style="color: Red">�����˵Ŀ������е�ַ</span>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Button ID="btnBank" class="querbtn" runat="server" Text="�޸�������Ϣ" OnClick="btnBank_Click" />
                            <!--������-->
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
                    ѡ��ͼƬ</h4>
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
      // ��������
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
    // Simple    2013-7-11  �����Ա��ֶεĴ���
    function sel_Change(i, j) {
        if ($("#sel_sex" + i).attr('checked') == true) {
            $("#<%=hid_Sex.ClientID%>").val(i);
        }
    };
    //simple 2013-7-12 �ύ��������Ϣ
    function checkSumbit() {

        //�ύʱ���и�ʽ��֤
        var userName = $("#<%=txt_UserName.ClientID%>").val();
        var userEmail = $("#<%=txt_Email.ClientID%>").val();
        var userMobile = $("#<%=txt_Mobile.ClientID%>").val();
        if (!checkPalyName()) {
            return false;
        }

        if (userName == "") {
            $("#<%=txt_UserName.ClientID%>").focus();
            $("#span_UserName").text("*��������Ϊ��");
            return false;
        }
        if (!CheckEmailCommon(userEmail)) {
            $("#<%=txt_Email.ClientID%>").focus();
            $("#span_email").text("*�����ʽ��ƥ��");
            return false;
        }
        if (!CheckMobileCommon(userMobile)) {
            $("#<%=txt_Mobile.ClientID%>").focus();
            $("#span_Mobile").text("*�ֻ������ʽ����ȷ");
            return false;
        }

        if ($("#<%= txt_QQ.ClientID %>").val() != "") {
            var reg = /^[1-9]\d{3,}$/;
            if (!reg.test($("#<%= txt_QQ.ClientID %>").val())) {
                $("#spanQQ").text("��ѶQQ��ʽ���벻��ȷ");
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
                $("#spanFax").text("�����ʽ���벻��ȷ");
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
            $("#p_local").next().text("*����д������Ϣ");
            return false;
        }
        else {
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 3 && $("select[name='city']").find("option").size() != 1) {
                $("#p_local").next().text("*����д������Ϣ");
                return false;
            }
            if ($("#<%=hid_AreaCode.ClientID%>").val().length == 6 && $("select[name='district']").find("option").size() != 1) {
                $("#p_local").next().text("*����д������Ϣ");
                return false;
            }
        };

        //�ύ��֤�ʱ���Ϣ
        var userPostelCode = $("#<%=txt_Post.ClientID%>").val();

        //      if(!CheckPostCodeCommon(userPostelCode))
        //    {
        //           $("#<%=txt_Post.ClientID%>").focus();
        //           $("#span_PostCode").text("*�������벻��ȷ");
        //           return false;
        //    }

        if ($("#<%= txt_WebSite.ClientID %>").val() != "" && $("#<%= txt_WebSite.ClientID %>").val().substring(0, 7) != "http://") {
            $("#spanWebSite").text("���˲��ͻ���վ��ʽ���벻��ȷ");
            return false;
        }

        var userAddress = $("#<%=txt_Address.ClientID%>").val();
        if (userAddress == "") {
            $("#<%=txt_Address.ClientID%>").focus();
            var userAddress = $("#<%=txt_Address.ClientID%>").next().text("*��ַ����Ϊ��");
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
         //areaCode ������
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
                $("#btnCheckMobile").attr("value", "�����޸�");
                $("#<%=txt_Mobile.ClientID%>").attr("readonly", "readonly");
                $("#a_Mobile").text("����֤");
            }
            else {
                $("#btnCheckMobile").attr("value", "������֤");
                $("#a_Mobile").text("δ��֤");
            }
        }
        else {
            $("#btnCheckMobile").attr("value", "������֤");
            $("#a_Mobile").text("δ��֤");
        }

        if (strEmail != null && strEmail != "") {
            if (parseInt(isCheckEmail) == 1) {
                $("#btnCheckEmail").attr("value", "�����޸�");
                $("#<%=txt_Email.ClientID%>").attr("readonly", "readonly");
                $("#a_Email").text("����֤");
            }
            else {
                $("#btnCheckEmail").attr("value", "������֤");
                $("#a_Email").text("δ��֤");
            }
        }
        else {
            $("#btnCheckEmail").attr("value", "������֤");
            $("#a_Email").text("δ��֤");
        }


    })
</script>
<script type="text/javascript">
   
</script>
<script type="text/javascript" language="javascript">
    //�ֻ����ֵ�js��֤����
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

                        if (strValue != "�����޸�" && str != "") {
                            document.location.href = "A_BindMobile.aspx?mobile=" + str + "&type=2";
                        }


                    }
                });
            }
            else {
                $("#span_Mobile").text("�ֻ������ʽ����");
                return false;
            }
        }
        else {
            $("#span_Mobile").text("*�ֻ����벻��Ϊ��");
        }
    }
    function CheckMobile() {
        var str = $("#<%=txt_Mobile.ClientID%>").val();
        if (str != "") {
            if (CheckMobileCommon(str)) {
                $.get("/Api/CheckInfo.ashx?type=1&mobile=" + str, null, function (data) {
                    if (data == "1") {
                        $("#span_Mobile").text("�ֻ�������Խ��а�");
                    }
                    else {
                        var strValue = $("#btnCheckMobile").val();
                        if (strValue != "�����޸�") {

                        }
                        else {
                            $("#span_Mobile").text("*");
                        }
                    }
                });
            }
            else {
                $("#span_Mobile").text("�ֻ������ʽ����");
            }
        }
        else {
            $("#span_Mobile").text("�ֻ����벻��Ϊ��");
        }
    }

    //���䲿�ֵ�js ��֤����


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
                $("#span_email").text("�����ʽ����");
                return false;
            }
        }
        else {
            $("#span_email").text("���䲻��Ϊ��");
            return false;
        }
    }
    function CheckEmail() {
        var str = $("#<%=txt_Email.ClientID%>").val();

        if (str != "") {
            if (CheckEmailCommon(str)) {
                $.get("/Api/CheckInfo.ashx?type=12&Email=" + str, null, function (data) {
                    if (data == "1") {
                        $("#span_email").text("������Խ��а�");
                    }
                    else {
                        var strValue = $("#btnCheckEmail").val();
                        if (strValue != "�����޸�") {

                        }
                        else {
                            $("#span_email").text("*");
                        }
                    }
                });
            }
            else {
                $("#span_email").text("�����ʽ��ʽ����");
            }
        }
        else {
            $("#span_email").text("���䲻��Ϊ��");
        }
    }
</script>
