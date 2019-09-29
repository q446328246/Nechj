<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_AdPayRecharge.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AdPayRecharge" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script>
    function fundeleteData(val) {
        if (confirm("�Ƿ�ɾ���ü�¼��")) {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=PaymentApplyLog&delid=" + val.title, null, function (data) {
                if (data == "ok") { alert("ɾ���ɹ���"); location.reload(); return false; }
                else { alert("ɾ��ʧ�ܣ�"); return false; }
            });
            return true;
        }
        return false;
    }


   


</script>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayRecharge.aspx?type=0" style="text-decoration: none;">��ֵ����</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayRecharge.aspx?type=1" style="text-decoration: none;">��ֵ�б�</a></li>
    </ul>
    <div id="content">
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        �û�����
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
                        ��ֵ��
                    </td>
                    <td>
                        <input name="input" type="text" class="textwb" id="txt_Recharge" runat="server" value="0.00"
                            style="width: 100px;" onchange="funCheckMoney()" /><span class="star">Ԫ</span>
                        <span id="errMoney" class="star">*</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ֧����ʽ��
                    </td>
                    <td>
                        <select name="sel" size="1" class="tselect" id="sel_PayMent" runat="server" onchange="funCheckPayType()">
                        </select><span class="star" id="errPayMent">*</span>
                    </td>
                </tr>
                <tr>
                <td class="tab_r" id="BankID">
                ��ֵ�����п�����λ��
                </td>
                <td id="testBankID">
                        <input name="input" type="text" class="textwb" id="txtBankCard" runat="server" 
                            style="width: 100px;" onblur="VerifyISNull()"  /><span class="star"></span>
                        <span id="Span1" class="star">*</span>
                    </td>
                </tr>
                <tr>
                <td class="tab_r" id="RechargeName">
                ��ֵ��������
                </td>
                <td id="testRechargeName">
                        <input name="input" type="text" class="textwb" id="txtUserName" runat="server" 
                            style="width: 100px;" onblur="VerifyISNull_two()"  /><span class="star"></span>
                        <span id="Span2" class="star">*</span>
                    </td>
                </tr>
                <tr>
                <td class="tab_r"  id="selecet_td_two" style="display:none">
                ��ֵ���Ŀ��ţ�
                </td>
                <td id="selecet_td" style="display:none">
                        
                        <%--<input name="input" type="text" class="textwb" id="txtGetBamkCard" runat="server" 
                            style="width: 100px;" onblur="VerifyISNull_free()" />--%>
                    
                    <asp:RadioButtonList ID="RadioButtonList_Bank" runat="server">
                
                        <asp:ListItem Text="����ǧ��������Դ������ҵ�ɷ����޹�˾(�й������˺ţ�110255946849���й��������������֧��" Value="123908865410301"  Selected="True"/>
                        <%--<asp:ListItem Text="�����ƽ������������޹�˾��ũ���ʺţ�31021101040007537��������Ԭ�Ҹ�֧��
"  Value="31021101040007537"/>--%>
                        
                    </asp:RadioButtonList>
                            <%--<span class="star"></span>--%>
                       <%-- <span id="Span3" class="star">*</span>--%>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        ��Ա��ע��
                    </td>
                    <td>
                        <textarea id="txt_Remark" cols="20" rows="2" class="textwb" style="width: 430px;
                            height: 90px; margin-top: 5px;" runat="server"></textarea>
                        <span>��Ա��ע���ܴ���200���ַ�</span> <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="��ֵ" CssClass="baocbtn" 
                            OnClientClick="return funCheckButton()" onclick="Btn_Confirm_Click" />
                    </td>
                </tr>
            </table>
            <input id="hid_PayMent" type="hidden" runat="server" />
            <input id="hid_PayMentValue" type="hidden" runat="server" value="-1" />
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            ��ֵ���ţ�
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            ��ֵ��ʽ��
                        </td>
                        <td>
                            <select name="sel" size="1" class="tselect" id="sel_PayMentType" runat="server" onchange="ccc()">
                            </select>
                            <input id="hid_SelPayMentType" type="hidden" runat="server" />
                        </td>
                    </tr>
                    <tr class="up_spac">
                        <td align="right">
                            �������ڣ�
                        </td>
                        <td colspan="3">
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
                                    <td>
                                        <asp:Button ID="Btn_Select" runat="server" Text="��ѯ" CssClass="chax btn_spc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="btntable_top">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; text-align: left;">
                        &nbsp;&nbsp;&nbsp;���ױ����� <span style="color: #ff0000; font-weight: bold;">
                            <asp:Label ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>�� &nbsp;&nbsp;&nbsp; ��ֵ�� ��<span style="color: #ff0000; font-weight: bold;"><asp:Label
                            ID="lab_PayRecharge" runat="server" Text="0.00"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        ��ֵ����
                    </th>
                    <th width="126">
                        ��������
                    </th>
                    <th>
                        ��ǰ�����
                    </th>
                    <th>
                        ��ֵ���
                    </th>
                    <th>
                        ��ֵ״̬
                    </th>
                    <th>
                        ��ֵ��ʽ
                    </th>
                    <th>
                        ��Ա��ע
                    </th>
                    <th>
                        ����Ա��ע
                    </th>
                    <th>
                        ����
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayRecharge">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td class="red" align="right">
                                <%# DataBinder.Eval(Container.DataItem, "CurrentAdvancePayment")%>
                            </td>
                            <td style="color: Red" align="right">
                                +<%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td class="blue">
                                <asp:Label ID="LabelOperateStatus" runat="server" Text='<%#ShopNum1.AccountWebControl.A_AdPayRecharge.GetType(Eval("OperateStatus").ToString())%>'></asp:Label>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "PaymentName")%>
                            </td>
                            <td class="picture">
                                <span style="display: none;">
                                    <%#Eval("Memo").ToString() %></span>
                                <%#Eval("Memo").ToString().Length > 6 ? Eval("Memo").ToString().Substring(0, 6) + "..." : Eval("Memo").ToString()%>
                            </td>
                            <td class="picture">
                                <span style="display: none;">
                                    <%#Eval("UserMemo").ToString()%></span>
                                <%#(Eval("UserMemo").ToString().Length > 6 ? Eval("UserMemo").ToString().Substring(0, 6) + "..." : Eval("UserMemo").ToString())%>
                            </td>
                            <td>
                                <a href="" runat="server" id="PayUrl" target="_blank">��ֵ</a>
                                <asp:HiddenField ID="HiddenFieldPayMentValue" runat="server" Value='<%#Eval("PaymentGuid") %>' />
                                <asp:HiddenField ID="HiddenFieldOrderNumber" runat="server" Value='<%#Eval("OrderNumber") %>' />
                                <asp:HiddenField ID="HiddenFieldOperateMoney" runat="server" Value='<%#Eval("OperateMoney") %>' />
                                <asp:HiddenField ID="HiddenFieldPaymentName" runat="server" Value='<%#Eval("PaymentName") %>' />
                                <a href="javascript:void(0)" title='<%#Eval("Guid")%>' onclick="fundeleteData(this)"
                                    runat="server" id="deleteData">ɾ��</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 86px;" colspan="9">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="btntable_t">
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
<script type="text/javascript" language="javascript">
    $(function () {
        var reType = '<%=ShopNum1.Common.Common.ReqStr("RechargeType")%>';
        $("#<%=sel_PayMent.ClientID%>Type").find("option[value='" + reType + "']").attr("selected", true);
        //������ʾЧ����
        var sweetTitles = {
            x: 10, y: 20, tipElements: ".picture", init: function () {
                $(this.tipElements).mouseover(function (e) {
                    var myTitle = $(this).find("span").html();
                    var tooltip = "";
                    if (myTitle != "") {
                        tooltip = "<div id='tooltip'><p>" + myTitle + "</p></div>";
                    }
                    $('#tooltip').css({ "opacity": "0.8", "top": (e.pageY + 20) + "px", "left": (e.pageX - 50) + "px" }).show('fast'); $('body').append(tooltip);
                }).mouseout(function () { $('#tooltip').remove(); }).mousemove(function (e) { $('#tooltip').css({ "top": (e.pageY + 20) + "px", "left": (e.pageX - 50) + "px" }); });
            }
        };
        sweetTitles.init();

    });
</script>
<script type="text/javascript" language="javascript">
    //��ѡ������У����� ��������Ϣ�����ؿؼ�
    $(function () {
        $("#<%=sel_PayMent.ClientID%>").change(function () {
            var payText = $(this).find("option:selected").text();
            var payValue = $(this).find("option:selected").val();
            $("#<%=hid_PayMent.ClientID%>").val(payText);
            $("#<%=hid_PayMentValue.ClientID%>").val(payValue);
            if ($(this).find("option:selected").text() == "����֧��(PayPal)") {
                $("#<%=txt_Recharge.ClientID%>").next().text("��Ԫ");
            }
        });
        $("#<%=sel_PayMent.ClientID%>Type").change(function () {
            $("#<%=hid_SelPayMentType.ClientID%>").val($("#<%=sel_PayMent.ClientID%>Type").find("option:selected").val());
        });
    });

    function funCheckPayType() {
        if ($("#<%=sel_PayMent.ClientID%>").val() == "-1") {
            $("#errPayMent").html("��ѡ��֧����ʽ��");
            return false;
        }
        else {
            $("#errPayMent").html("*");
            return true;
        }
        return false;
    }

    function funCheckButton() {
        if ($("#<%=txt_Remark.ClientID%>").val().length > 200) {
            alert("��Ա��ע���Ȳ��ܴ���200���ַ���"); return false;
        }
        funCheckMoney();
        funCheckPayType();
        VerifyISNull_two();
        VerifyISNull(); 

        var payPrice = $("#<%=txt_Recharge.ClientID%>").text();
        if (payPrice.indexOf(".") == -1)
            payPrice = payPrice + ".00";
        this.fromA_AdPayTiXian.target = '_blank';
        if (funCheckMoney() && funCheckPayType() && VerifyISNull_two() && VerifyISNull()) {
            if ($("#<%=sel_PayMent.ClientID%>").val() != "4f038afb-debe-45f2-9ca8-e07a23394983") {
                setTimeout("funCheckButton()", "5000");
                this.fromA_AdPayTiXian.target = '_blank';
                 window.location.href=window.location.href+"?response=data";
            }
            return true;
        }
        return true;

    }


    function funCheckMoney() {
        var Transfer = $("#<%=txt_Recharge.ClientID%>").val();

        if (Transfer != "") {
            var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
            if (!oo.test(Transfer)) {
                $("#errMoney").html("��ֵ����ʽ����");
                return false;
            }
            else {
                if (parseFloat(Transfer) > 0) {
                    $("#errMoney").html("");
                    return true;
                }
                else {
                    $("#errMoney").html("��ֵ����Ϊ0���߸�����");
                    return false;
                }
            }
            return false;
        }
        else {
            $("#errMoney").html("��ֵ����Ϊ�գ�");
            return false;
        }
    }

    function VerifyISNull_two() {
        var banknumber_two = $("#<%=txtUserName.ClientID%>").val();

        if (banknumber_two == "") {

            $("#Span2").html("��ֵ��������");
            return false;
        }
        else if (banknumber_two != "") {
            $("#Span2").html("*");
            return true;
            
        }
    }



    function VerifyISNull() {
        var banknumber = $("#<%=txtBankCard.ClientID%>").val();

        if (banknumber == "") {

            $("#Span1").html("��ֵ�����п�����λ����Ϊ�գ�");
            return false;
        }
        else if (banknumber != "") {
            $("#Span1").html("*");
            return true;
        }
    }

    $(function () {
        $('#A_AdPayRecharge1_sel_PayMent').change(function () {

            var p1 = $(this).children('option:selected').val(); //�����selected��ֵ 

            if (p1 == "1e7cc2d2-130e-4e62-9be9-aa07f727ed4c") {
                $("#selecet_td ").show();
                $("#selecet_td_two ").show();
                
                $("#BankID ").show();
                $("#testBankID ").show();
                $("#RechargeName ").show();
                $("#testRechargeName ").show();
                
            }
            else {
                $("#selecet_td ").hide();
                $("#BankID ").hide();
                $("#testBankID ").hide();
                $("#RechargeName ").hide();
                $("#testRechargeName ").hide();
                $("#selecet_td_two ").hide();
            }
        })
    }) 
</script>
