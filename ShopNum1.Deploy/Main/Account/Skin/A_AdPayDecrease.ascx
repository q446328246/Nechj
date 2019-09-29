<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="A_AdPayDecrease.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_AdPayDecrease" %>
<%@ Import Namespace="ShopNum1.Common" %>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'
            id="0"><a href="A_AdPayDecrease.aspx?type=0" style="text-decoration: none;">人民币提现</a></li>
        <%--<li class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayDecrease.aspx?type=2" id="A1" style="text-decoration: none;">人民币提现申请</a></li>--%>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="A_AdPayDecrease.aspx?type=1" id="1" style="text-decoration: none;">提现列表</a></li>
    </ul>
    <div id="content">
       <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="1"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <br />
            <strong><font color="red">温馨提示：该提现功能目前只针对商家，个人用户暂不支持提现。</font></strong>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        用户名：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="Lab_MemLoginID" runat="server" Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        当前人民币（RV）：
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">￥<asp:Label ID="Lab_AdPayment" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr class="trshowx">
                    <td class="tab_r">
                        提现金额：
                    </td>
                    <td>
                        <input type="text" class="textwb" id="txt_Decrease" runat="server" value="0" style="width: 100px;"
                            onchange="funChecktxt_Decrease()" onblur="funChecktxt_Decrease()" maxlength="32" />
                        
                    </td>
                </tr>
                <tr class="trshowx">
                    <td class="tab_r">
                        提现方式：
                    </td>
                    <td>
                        <select name="sel" size="1" class="tselect" id="sel_Bank">
                            <option value="-1">请选择</option>
                            <option value="1">线下打款</option>
                            <%--<option value="2">网银在线</option>
                            <option value="3">支付宝</option>
                            <option value="4">财付通</option>--%>
                        </select><span class="star" id="errBank">*</span>
                    </td>
                </tr>
                <tr id="tr_RealName" class="trshowx">
                    <td class="tab_r">
                        收款人姓名：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="txt_RealName"
                            runat="server" onblur="funRealName()" maxlength="28" /><span class="star" id="errname">*</span>
                    </td>
                </tr>
                <tr id="tr_Bank" class="trshowx">
                    <td class="tab_r">
                        收款银行名称：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="txt_Bank"
                            runat="server" maxlength="30" onblur="funtxt_Bank

()" /><span class="star" id="errrvbank">* </span>
                    </td>
                </tr>
                <tr id="tr_ConfirmBankID" class="trshowx">
                    <td class="tab_r">
                        收款人银行账号：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="txt_ConfirmBankID"
                            runat="server" maxlength="50" onblur="funConfirmBankID()" /><span class="star" id="errConfirmBankID">*</span>
                    </td>
                </tr>
                <tr id="tr_Account" style="display: none" class="trshowx">
                    <td class="tab_r">
                        收款人账号：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="txt_Account"
                            runat="server" maxlength="30" onblur="funChecktxt_Account()" />
                        <span class="gray1" style="color: Red" id="errtxt_Account">*</span>
                    </td>
                </tr>
                <tr class="trshowx">
                    <td class="tab_r">
                        商城交易密码：
                    </td>
                    <td>
                        <input name="input" type="password" class="textwb" id="input_PayPwd" runat="server"
                            onblur="funCheckPayPwd()" maxlength="25" /><span class="star" id="errPwd">*</span>
                    </td>
                </tr>
                <tr id="tr12211" runat="server">
                    <td class="tab_r">
                        <span class="form_left">绑定手机号码： </span>
                    </td>
                    <td>
                        <asp:Label ID="nextmobile" runat="server" Text="" CssClass="orm_right f14" runat="server">
                
                        </asp:Label>
                    </td>
                </tr>
                <tr id="tr122211" runat="server">
                    <td class="tab_r">
                        <span class="form_left">验证码： </span>
                    </td>
                    <td>
                        <input type="text" id="txtMCode" style="border: 1px solid #CCCCCC; height: 20px;
                            width: 80px;" onblur="existcode()" />
                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX" border="0" onclick="reloadcode2()"
                            alt="看不清?点一下" />
                        <a onclick="reloadcode2()">看不清楚？</a>
                    </td>
                </tr>
                <tr id="tr122113" runat="server">
                    <td class="tab_r">
                       
                    </td>
                    <td>
                        <input type="text" id="M_code" name="code" data-tip="验证码" maxlength="6" class="intext intext_short nullv tov vfb"
                            autocomplete="off" runat="server" disabled="disabled" runat="server" />
                             <input type="button" id="J_ver_btn" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                            style="width: 100px; height: 25px; margin-left: 10px" " />

                        <a class="grew ml10 l" id="J_cannot_receive" href="javascript:void(0);">收不到短信验证码？
                        </a><span id="spanConfirm"></span>
                        <div style="display: none;" class="tooltip cp_tooltip">
                            短信验证码发送后30分钟内均可使用。验证码短信经过网关时，网络通讯异常可能会造成短信丢失或延时，请您耐心等待，或者换一个时间段进行相关操作。
                        </div>
                        <span class="vc vf" id="yzMsg" style="display: none">请输入验证码 </span>
                         <div class="form_row form_text_row">
                    <span class="form_left"></span><span class="form_right gw" id="spanShowMsg" state="0" style="color: Red;
                            padding-left: 10px;">
                        <%--验证码是6位数字--%>
                        
                    </span>
                     
                </div>
                
                
                    </td>
                    
                    
                </tr>
                
                <tr class="trshowx">
                    <td class="tab_r">
                        会员备注：
                    </td>
                    <td>
                        <textarea id="txt_Remark" cols="20" rows="2" class="textwb" style="width: 430px;
                            height: 90px; margin-top: 4px;" runat="server"></textarea>
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr class="trshowx">
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="Btn_Confirm" runat="server" Text="确认" CssClass="baocbtn" OnClick="Btn_Confirm_Click"
                            OnClientClick="return funCheckButon()" />
                    </td>
                </tr>
            </table>
        </div>
        <%--<div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="1"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none":"display:block" %>'>--%>
        
         <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")==""? "display:block": "display:none"%>'>
            <br />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tabbiao">
                <tr>
                    <td class="tab_r">
                        用户名：
                    </td>
                    <td>
                        <strong style="font-size: 14px;">
                            <asp:Label ID="bvMemLoginID" runat="server" Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="tab_r">
                        当前人民币：
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">￥<asp:Label ID="Score_bv" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr class="trgz">
                    <td class="tab_r">
                        提现金额：
                    </td>
                    <td>
                        <input type="text" class="textwb" id="bvScore_bv" runat="server" value="0" style="width: 100px;"
                            onchange="funbvScore_bv()" onblur="funbvScore_bv()" maxlength="32" />
                        <span class="star1">元</span> <span class="star" id="errbvmoney"></span>
                    </td>
                </tr>
                <tr class="trgz">
                    <td class="tab_r">
                        提现方式：
                    </td>
                    <td>
                        <select name="sel" size="1" class="tselect" id="Select1">
                            <option value="-1">请选择</option>
                            <option value="1">线下打款</option>
                            <%--<option value="2">网银在线</option>
                            <option value="3">支付宝</option>
                            <option value="4">财付通</option>--%>
                        </select><span class="star" id="errSelect">*</span>
                    </td>
                </tr>
                <tr id="tr1" class="trgz">
                    <td class="tab_r">
                        收款人姓名：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="bv_RealName"
                            runat="server" onblur="funbv_RealName()" maxlength="28" /><span class="star" id="errbvname">*</span>
                    </td>
                </tr>
                <tr id="tr2" class="trgz">
                    <td class="tab_r">
                        收款银行名称：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="bv_Bank" runat="server"
                            maxlength="30" onblur="funbv_Bank()" /><span class="star" id="errbvbank">* </span>
                    </td>
                </tr>
                <tr id="tr3" class="trgz">
                    <td class="tab_r">
                        收款人银行账号：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="bv_BankID"
                            runat="server" maxlength="50" onblur="funbv_BankID()" /><span class="star" id="errBankID">*</span>
                    </td>
                </tr>
                <tr id="tr4" style="display: none" class="trgz">
                    <td class="tab_r">
                        收款人账号：
                    </td>
                    <td>
                        <input name="input" type="text" readonly="readonly" class="textwb" id="bv_SID" runat="server"
                            maxlength="30" onblur="funbv_SID()" />
                        <span class="gray1" style="color: Red" id="errMember">*</span>
                    </td>
                </tr>
                <tr class="trgz">
                    <td class="tab_r">
                        商城交易密码：
                    </td>
                    <td>
                        <input name="input" type="password" class="textwb" id="bv_password" runat="server"
                            onblur="funbv_PayPwd()" maxlength="25" /><span class="star" id="errbvPwd">*</span>
                    </td>
                </tr>
                <tr id="tr1221" runat="server">
                    <td class="tab_r">
                        <span class="form_left">绑定手机号码： </span>
                    </td>
                    <td>
                        <asp:Label ID="nextmobile1" runat="server" Text="" CssClass="orm_right f14" runat="server">
                
                        </asp:Label>
                    </td>
                </tr>
                <tr id="tr12221" runat="server">
                    <td class="tab_r">
                        <span class="form_left">验证码： </span>
                    </td>
                    <td>
                        <input type="text" id="txtMCode1" style="border: 1px solid #CCCCCC; height: 20px;
                            width: 80px;" onblur="existcode1()" />
                        <img src="/imagecode.aspx?javascript:Math.random()" id="ImgX1" border="0" onclick="reloadcode21()"
                            alt="看不清?点一下" />
                        <a onclick="reloadcode21()">看不清楚？</a>
                    </td>
                </tr>
                <tr id="tr122221" runat="server">
                    <td class="tab_r">
                        
                    </td>
                    <td>
                        <input type="text" id="M_code1" name="code" data-tip="验证码" maxlength="6" class="intext intext_short nullv tov vfb"
                            autocomplete="off" runat="server" disabled="disabled" runat="server" />
                            <input type="button" id="J_ver_btn1" class="btn btn-white vc_btn mr10 J_ftrack" value="点此免费获取"
                            style="width: 100px; height: 25px; margin-left: 10px" />
                        <a class="grew ml10 l" id="J_cannot_receive1" href="javascript:void(0);">收不到短信验证码？
                        </a><span id="spanConfirm1"></span>
                        <div style="display: none;" class="tooltip cp_tooltip">
                            短信验证码发送后30分钟内均可使用。验证码短信经过网关时，网络通讯异常可能会造成短信丢失或延时，请您耐心等待，或者换一个时间段进行相关操作。
                        </div>
                        <span class="vc vf" id="yzMsg1" style="display: none">请输入验证码 </span>
                         <div class="form_row form_text_row">
                      <span class="form_left"></span><span class="form_right gw" id="spanShowMsg1" state="0" style="color: Red;
                            padding-left: 10px;">
                         
                </div>
                
                    </td>
                    
                </tr>
                <tr class="trgz">
                    <td class="tab_r">
                        会员备注：
                    </td>
                    <td>
                        <textarea id="bv_Rmeal" cols="20" rows="2" class="textwb" style="width: 430px; height: 90px;
                            margin-top: 4px;" runat="server"></textarea>
                        <span class="gray1">&nbsp;</span>
                    </td>
                </tr>
                <tr class="trgz">
                    <td class="tab_r">
                        &nbsp;
                    </td>
                    <td style="padding: 10px 0px 10px 0px;">
                        <asp:Button ID="bv_btn" runat="server" Text="确认" CssClass="baocbtn" OnClick="bv_btn_Click"
                            OnClientClick="return funbv_btn()" />
                    </td>
                </tr>
            </table>
        </div>
        <div style='<%=ShopNum1.Common.Common.ReqStr("type")=="0"||ShopNum1.Common.Common.ReqStr("type")=="2"||ShopNum1.Common.Common.ReqStr("type")==""? "display:none": "display:block"%>'>
            <div class="pad">
                <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                    <tr class="up_spac">
                        <td align="right">
                            提现单号：
                        </td>
                        <td>
                            <input type="text" runat="server" id="txt_OrderNum" class="ss_nr1" />
                        </td>
                        <td align="right" class="ss_nr_spac">
                            操作日期：
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" class="ss_nrduan" runat="server" id="txt_StartTime" onclick="WdatePicker

({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                    <td class="line_spac">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" class="ss_nrduan" runat="server" id="txt_EndTime" onclick="WdatePicker

({dateFmt:'yyyy-MM-dd'})" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Button ID="Btn_Select" runat="server" Text="查询" CssClass="chax btn_spc" />
                        </td>
                    </tr>
                    <tr class="up_spac" style="display: none">
                        <td align="right">
                            提现方式：
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <select id="sel_hidbank" runat="server" class="tselect" style="width: 228px;">
                                            <option value="-1">请选择</option>
                                            <option value="1">线下打款</option>
                                            <%--<option value="2">网银在线</option>
                                            <option value="3">支付宝</option>
                                            <option value="4">财付通</option>--%>
                                        </select>
                                    </td>
                                    <td id="td_bank" style="padding-left: 5px; display: none">
                                        <input type="text" runat="server" id="txt_hidbank" class="ss_nr1" style="width: 120px;" />
                                        <span class="star" id="errBank">线下提现的银行</span>
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
                        &nbsp;&nbsp;&nbsp;交易笔数： <span style="color: Red; font-weight: bold;">
                            <asp:Label ID="lab_PayNum" runat="server" Text="0"></asp:Label>
                        </span>笔 &nbsp;&nbsp;&nbsp; 提现金额： ￥<span style="color: Red; font-weight: bold;"><asp:Label
                            ID="lab_PayDecrease" runat="server" Text="0"></asp:Label>
                        </span>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="1" cellpadding="0" class="biaodhd1" width="100%">
                <tr>
                    <th>
                        提现单号
                    </th>
                    <th>
                        操作日期
                    </th>
                    <th>
                        当前账户
                    </th>
                    <th>
                        提现金额
                    </th>
                    <th>
                        提现方式
                    </th>
                    <th>
                        提现状态
                    </th>
                    <th>
                        管理员备注
                    </th>
                    <th>
                        会员备注
                    </th>
                </tr>
                <asp:Repeater runat="server" ID="Rep_PayDecrease">
                    <ItemTemplate>
                        <tr>
                            <td style="display: none;">
                                <asp:CheckBox ID="checkboxAll" runat="server" /><span runat="server" visible="false"
                                    id="guid"><%# DataBinder.Eval(Container.DataItem, "Guid") %></span>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "OrderNumber")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Date")%>
                            </td>
                            <td class="red">
                                <%# DataBinder.Eval(Container.DataItem, "CurrentAdvancePayment")%>
                            </td>
                            <td style="color: Red">
                                -<%# DataBinder.Eval(Container.DataItem, "OperateMoney")%>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "Bank")%>
                            </td>
                            <td class="blue">
                                <%#ShopNum1.AccountWebControl.A_AdPayDecrease.GetState(Eval("OperateStatus").ToString())%>
                            </td>
                            <td class="picture">
                                <span style="display: none;">
                                    <%#Eval("UserMemo").ToString()%></span>
                                <%#(Eval("UserMemo").ToString().Length > 6 ? Eval("UserMemo").ToString().Substring(0, 6) + "..." : Eval

("UserMemo").ToString())%>
                            </td>
                            <td class="picture">
                                <span style="display: none;">
                                    <%#Eval("Memo").ToString()%></span>
                                <%#(Eval("Memo").ToString().Length > 6? Eval("Memo").ToString().Substring(0, 6) + "..." : Eval

("Memo").ToString())%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater ID="Rep_NoValue" runat="server" Visible="false">
                    <ItemTemplate>
                        <tr>
                            <td style="height: 86px;" colspan="8">
                                <div class="no_data">
                                    <%# DataBinder.Eval(Container.DataItem, "NoValue")%></div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <!--分页-->
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
            <!--分页-->
            <input id="hid_BankType" type="hidden" runat="server" />
            <input id="hid_RealName" type="hidden" runat="server" />
            <input id="Hid_Score_pv_a" type="hidden" runat="server" />
            <input id="Hid_Score_hv" type="hidden" runat="server" />
            <input id="Hid_Score_pv_b" type="hidden" runat="server" />
            <input id="Hid_Score_dv" type="hidden" runat="server" />
            <asp:HiddenField ID="hid_SelectBank" runat="server" Value="-1" />
        </div>
        <input id="HiddenShow" type="hidden" runat="server" value="0" />
        <input id="HiddenPayPwd" type="hidden" runat="server" value="0" />
        <input id="Hiddenbv_Show" type="hidden" runat="server" value="0" />
        <input id="Hiddenbv_Pwd" type="hidden" runat="server" value="0" />
        <input type="hidden" id="hidMemberType" runat="server" />
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
            //         function ontoPage(txtId)
            //         {
            //               location.href='?sort=<%=ShopNum1.Common.Common.ReqStr("sort")%>&typeid=<%=ShopNum1.Common.Common.ReqStr("typeid")%>&pageid='+$("#txtIndex").val();
            //         }
            $(function () {
                if ($("#<%=hidMemberType.ClientID%>").val() == "1") {
                    $(".trshowx").hide();
                }
                //标题提示效果处
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
        <script type="text/javascript" language="javascript">
            //将选择的银行，赋给 放银行信息的隐藏控件
            $(function () {
                $("#Select1").change(function () {
                    if ($("#Select1").find("option:selected").val() == "1") {
                        $("#errSelect").html("*");
                        $("#<%=Hiddenbv_Show.ClientID%>").val(0)
                        //                           $("#tr_RealName").show();
                        //                           $("#tr_Bank").show();
                        //                           $("#tr_ConfirmBankID").show();
                        //                           $("#tr_Account").hide();
                        //                           $("#tr_Account").val("");
                        //                           $("#<%=hid_BankType.ClientID%>").val($("#sel_Bank").find("option:selected").text());
                    }
                    //                       if ($("#sel_Bank").find("option:selected").val() != "1" && $("#sel_Bank").find("option:selected").val() != "-1") {
                    //                           $("#errBank").html("*");
                    //                           $("#<%=HiddenShow.ClientID%>").val(1)
                    //                           $("#tr_Account").show();
                    //                           $("#tr_RealName").hide();
                    //                           $("#tr_Bank").hide();
                    //                           $("#tr_ConfirmBankID").hide();
                    //                           $("#tr_RealName").val();
                    //                           $("#tr_Bank").val();
                    //                           $("#tr_ConfirmBankID").val();
                    //                           $("#<%=hid_BankType.ClientID%>").val($("#sel_Bank").find("option:selected").text());
                    //                       }
                    if ($("#Select1").find("option:selected").val() == "-1") {
                        $("#errSelect").html("请选择一个提现方式！");
                        $("#<%=Hiddenbv_Show.ClientID%>").val(-1)

                    }

                }
                ),
                $("#<%=sel_hidbank.ClientID%>").change(function () {
                    $("#<%=hid_SelectBank.ClientID%>").val($("#<%=sel_hidbank.ClientID%>").find("option:selected").val());
                    //          if($("#<%=hid_SelectBank.ClientID%>").val()=="1")
                    //          {
                    //               $("#td_bank").show();
                    //          }
                    //          else
                    //          {
                    //             $("#td_bank").hide();
                    //          }
                });


            })
        </script>
        <script type="text/javascript" language="javascript">
            //将选择的银行，赋给 放银行信息的隐藏控件
            $(function () {
                $("#sel_Bank").change(function () {
                    if ($("#sel_Bank").find("option:selected").val() == "1") {
                        $("#errBank").html("*");
                        $("#<%=HiddenShow.ClientID%>").val(0)
                        $("#tr_RealName").show();
                        $("#tr_Bank").show();
                        $("#tr_ConfirmBankID").show();
                        $("#tr_Account").hide();
                        $("#tr_Account").val("");
                        $("#<%=hid_BankType.ClientID%>").val($("#sel_Bank").find("option:selected").text());
                    }
                    if ($("#sel_Bank").find("option:selected").val() != "1" && $("#sel_Bank").find("option:selected").val() != "-1") {
                        $("#errBank").html("*");
                        $("#<%=HiddenShow.ClientID%>").val(1)
                        $("#tr_Account").show();
                        $("#tr_RealName").hide();
                        $("#tr_Bank").hide();
                        $("#tr_ConfirmBankID").hide();
                        $("#tr_RealName").val();
                        $("#tr_Bank").val();
                        $("#tr_ConfirmBankID").val();
                        $("#<%=hid_BankType.ClientID%>").val($("#sel_Bank").find("option:selected").text());
                    }
                    if ($("#sel_Bank").find("option:selected").val() == "-1") {
                        $("#errBank").html("请选择一个提现方式！");
                        $("#<%=HiddenShow.ClientID%>").val(-1)

                    }

                }
                ),
                $("#<%=sel_hidbank.ClientID%>").change(function () {
                    $("#<%=hid_SelectBank.ClientID%>").val($("#<%=sel_hidbank.ClientID%>").find("option:selected").val());
                    //          if($("#<%=hid_SelectBank.ClientID%>").val()=="1")
                    //          {
                    //               $("#td_bank").show();
                    //          }
                    //          elsew3
                    //          {
                    //             $("#td_bank").hide();
                    //          }
                });


            })
        </script>
        <script type="text/javascript" language="javascript">

            function funbvScore_bv() {
                var txt_Decrease = $("#<%=bvScore_bv.ClientID%>").val();
                if (txt_Decrease != "") {
                    var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
                    if (!oo.test(txt_Decrease)) {
                        $("#errbvmoney").html("提现金额格式错误！");
                        return false;
                    }
                    else {
                        var allMoney = parseFloat($("#<%=Score_bv.ClientID%>").text())
//                        if (parseFloat(txt_Decrease) >= 100) {
                            if (parseFloat(txt_Decrease) > allMoney) {
                                $("#errbvmoney").html("提现金额不能大于当前人民币金额！");
                                return false;
                            }
//                            else if (parseInt(parseInt(txt_Decrease) / 100) * 100 != parseFloat(txt_Decrease)) {
//                                $("#errbvmoney").html("提现人民币金额必须为100的倍数！");
//                                return false;
//                            }
                            else {
                                var money = "";
                                
                                    money = parseFloat(txt_Decrease) * 0.005;
                                
                                $("#errbvmoney").html("扣取手续费后实际到账额为:" + (parseFloat(txt_Decrease) - money));
                                return true;
                            }
                            
                        }
//                        else {
//                            $("#errbvmoney").html("提现金额不能为小于100！");
//                            return false;
//                        }
//                    }
                }
                else {
                    $("#errbvmoney").html("提现金额不能为空！");
                    return false;
                }
                return false;
            }

        function funChecktxt_Decrease() {
                var txt_Decrease = $("#<%=txt_Decrease.ClientID%>").val();
                if (txt_Decrease != "") {
                    var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
                    if (!oo.test(txt_Decrease)) {
                        $("#errmoney").html("提现金额格式错误！");
                        return false;
                    }
                    else {
                        var allMoney = parseFloat($("#<%=Lab_AdPayment.ClientID%>").text())
                        if (parseFloat(txt_Decrease) >= 100) {
                            if (parseFloat(txt_Decrease) > allMoney) {
                                $("#errmoney").html("提现金额不能大于当前人民币（RV）金额！");
                                return false;
                            }
                            else if (parseInt((parseInt(txt_Decrease) / 100)) * 100 != parseFloat(txt_Decrease)) {
                                $("#errmoney").html("提现人民币（RV）金额必须为100的倍数！");
                                return false;
                            }
                            else {
                                var money = "";
                                if (parseFloat(txt_Decrease) * 0.01 < 10) {
                                    money = 10;
                                }
                                else {
                                    money = parseFloat(txt_Decrease) * 0.005;
                                }
                                $("#errmoney").html("扣取手续费后实际到账额为:" + (parseFloat(txt_Decrease) - money));
                                return true;
                            }
                        }
                        else {
                            $("#errmoney").html("提现金额不能为小于100！");
                            return false;
                        }
                    }
                }
                else {
                    $("#errmoney").html("提现金额不能为空！");
                    return false;
                }


                return false;
            }

            function funbv_RealName() {
                var RealName = $("#<%=bv_RealName.ClientID%>").val();
                if (RealName != "") {
                    $("#errbvname").html("");
                    return true;
                }
                else {
                    $("#errbvname").html("收款人姓名不能为空！");
                    return false;
                }
            }

            function funRealName() {
                var RealName = $("#<%=txt_RealName.ClientID%>").val();
                if (RealName != "") {
                    $("#errname").html("");
                    return true;
                }
                else {
                    $("#errname").html("收款人姓名不能为空！");
                    return false;
                }
            }
            function funbv_Bank() {
                var bank = $("#<%=bv_Bank.ClientID%>").val();
                if (bank != "") {
                    $("#errbvbank").html("");
                    return true;
                }
                else {
                    $("#errbvbank").html("收款银行名称必填！");
                    return false;
                }
            }
            function funtxt_Bank() {
                var bank = $("#<%=txt_Bank.ClientID%>").val();
                if (bank != "") {
                    $("#errrvbank").html("");
                    return true;
                }
                else {
                    $("#errrvbank").html("收款银行名称必填！");
                    return false;
                }
            }
            function funbv_BankID() {
                var ConfirmBankID = $("#<%=bv_BankID.ClientID%>").val();
                if (ConfirmBankID != "") {
                    $("#errBankID").html("");
                    return true;
                }
                else {
                    $("#errBankID").html("收款人银行账号不能为空！");
                    return false;
                }
            }

            function funConfirmBankID() {
                var ConfirmBankID = $("#<%=txt_ConfirmBankID.ClientID%>").val();
                if (ConfirmBankID != "") {
                    $("#errConfirmBankID").html("");
                    return true;
                }
                else {
                    $("#errConfirmBankID").html("收款人银行账号不能为空！");
                    return false;
                }
            }

            //检查交易密码
            function funbv_PayPwd() {
                var payPwd = $("#<%=bv_password.ClientID%>").val();
                if (payPwd != "") {
                    $("#errbvPwd").html("查询中...");
                    $.ajax({
                        type: "get",
                        url: "/Api/ShopAdmin/S_AdminOpt.ashx?date=" + new Date(),
                        async: false,
                        data: "type=paypwd&payPwd=" + payPwd,
                        dataType: "html",
                        success: function (ajaxData) {
                            if (ajaxData != "") {
                                if (ajaxData == "false") {
                                    $("#errbvPwd").html("交易密码错误！")
                                    $("#<%=Hiddenbv_Pwd.ClientID %>").val("0");
                                    return true;
                                }
                                else if (ajaxData == "true") {
                                    $("#errbvPwd").html("")
                                    $("#<%=Hiddenbv_Pwd.ClientID %>").val("1");
                                    return false;
                                }
                            }
                        }
                    });
                }
                else {
                    $("#errbvPwd").html("交易密码不能为空！");
                }

            }
            //检查交易密码
            function funCheckPayPwd() {
                var payPwd = $("#<%=input_PayPwd.ClientID%>").val();
                if (payPwd != "") {
                    $("#errPwd").html("查询中...");
                    $.ajax({
                        type: "get",
                        url: "/Api/ShopAdmin/S_AdminOpt.ashx?date=" + new Date(),
                        async: false,
                        data: "type=paypwd&payPwd=" + payPwd,
                        dataType: "html",
                        success: function (ajaxData) {
                            if (ajaxData != "") {
                                if (ajaxData == "false") {
                                    $("#errPwd").html("交易密码错误！")
                                    $("#<%=HiddenPayPwd.ClientID %>").val("0");
                                    return true;
                                }
                                else if (ajaxData == "true") {
                                    $("#errPwd").html("")
                                    $("#<%=HiddenPayPwd.ClientID %>").val("1");
                                    return false;
                                }
                            }
                        }
                    });
                }
                else {
                    $("#errPwd").html("交易密码不能为空！");
                }

            }

            function funCheckButon() {
                //button事件
                funChecktxt_Decrease();
                if ($("#sel_Bank").find("option:selected").val() == "-1") {
                    $("#errBank").html("请选择一个银行！");
                    return false;
                }
                funRealName();
                funtxt_Bank();
                funConfirmBankID();
                funCheckPayPwd();
                if ($("#<%=HiddenShow.ClientID%>").val() == "0") {
                    if (funChecktxt_Decrease() && funRealName() && funtxt_Bank() && funConfirmBankID() && $("#<%=HiddenPayPwd.ClientID %>").val()
== "1") {
                        return true;
                    }
                    else {
                        return false;
                    }

                }
                else if ($("#<%=HiddenShow.ClientID%>").val() == "1") {
                    if (funChecktxt_Account() && $("#<%=HiddenPayPwd.ClientID %>").val() == "1") {
                        return true;
                    }
                    else {
                        return false;
                    }
                    return false;
                }
                return false;
            }
            function funbv_btn() {
                //button事件
                funbvScore_bv();
                if ($("#Select1").find("option:selected").val() == "-1") {
                    $("#errSelect").html("请选择一个银行！");
                    return false;
                }
                funRealName();
                funtxt_Bank();
                funConfirmBankID();
                funCheckPayPwd();
                if ($("#<%=Hiddenbv_Show.ClientID%>").val() == "0") {
                    if (funbvScore_bv() && funbv_RealName() && funbv_Bank() && funbv_BankID() && $("#<%=Hiddenbv_Pwd.ClientID %>").val()
== "1") {
                        return true;
                    }
                    else {
                        return false;
                    }

                }
                else if ($("#<%=Hiddenbv_Show.ClientID%>").val() == "1") {
                    if (funbv_SID() && $("#<%=Hiddenbv_Pwd.ClientID %>").val() == "1") {
                        return true;
                    }
                    else {
                        return false;
                    }
                    return false;
                }
                return false;
            }

            function funChecktxt_Account() {
                var txt_Account = $("#<%=txt_Account.ClientID%>").val();
                if (txt_Account != "") {
                    $("#errtxt_Account").html("");
                    return true;
                }
                else {
                    $("#errtxt_Account").html("收款人账号不能为空！");
                    return false;
                }
                return false;
            }
            function funbv_SID() {
                var txt_Account = $("#<%=bv_SID.ClientID%>").val();
                if (txt_Account != "") {
                    $("#errMember").html("");
                    return true;
                }
                else {
                    $("#errMember").html("收款人账号不能为空！");
                    return false;
                }
                return false;
            }
            
        </script>
        <script type="text/javascript">
            function reloadcode2() {
                var verify = document.getElementById('ImgX');
                verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
            }
            //验证码
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
                                context.innerHTML = "验证码错误";
                                //context.className="onError1";
                                $("#spanShowMsg").attr("state", "0");
                            }
                        }
                    });
                }
                else {
                    context.innerHTML = "验证码不能为空";
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
                        $("#spanShowMsg").text("验证码不能为空！"); return false;
                    }
                    if ($("#spanShowMsg").attr("state") == "0") {
                        $("#spanShowMsg").text("验证码不正确！"); return false;
                    }
                    $("#J_ver_btn").attr("disabled", "disabled");
                    $("#<%= M_code.ClientID %>").removeAttr("disabled");
                    $("#spanConfirm").get(0).className = "";
                    // $("#spanShowMsg").get(0).className="onCorrect1";
                    $("#spanShowMsg").text("短信已发送，请耐心等待...");
                    $("#spanShowMsg").attr("style", "color:green; padding-left:10px;");
                    $thisid = $(this);
                    timerId = setInterval("goTo()", 1000);
                    $.get("/Api/CheckInfo.ashx?type=2&Mobile=" + $("#<%=nextmobile.ClientID%>").text(), null, function (data) {
                        //alert("手机短信验证码已发送，请耐心等待......");
                        if (data != "1") {
                            $("#spanShowMsg").get(0).className = "onError1";
                            $("#spanShowMsg").text("短信发送出现异常，请重新验证");
                        }
                    });
                });

                $("#<%= M_code.ClientID %>").focus(function () {
                    $("#spanShowMsg").get(0).className = "onTips1";
                    $("#spanShowMsg").text("验证码是6位字符");
                    $("#spanConfirm").get(0).className = "";
                });

                $("#<%= M_code.ClientID %>").blur(function () {
                    if (this.value == "") {
                        $("#spanShowMsg").get(0).className = "onError1";
                        $("#spanShowMsg").text("请输入验证码");
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
                                $("#spanShowMsg").text("验证码错误或已过期，请重新输入!");
                            }
                        });
                    }
                });
            });

            var i = 60;
            function goTo() {
                i--;
                $thisid.val("已发送验证码(" + i + "秒)");
                if (i == 0) {
                    $thisid.val("免费获取验证码");
                    clearInterval(timerId); i = 60;
                    $thisid.removeAttr("disabled");
                }
            }



            function reloadcode21() {
                var verify = document.getElementById('ImgX1');
                verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
            }
            //验证码
            function existcode1() {
                var boolresult = true;
                var inputcontrol = $("#txtMCode1").val();
                var context = document.getElementById("spanShowMsg1");
                if (inputcontrol != "") {
                    $.ajax({
                        url: "/api/CheckMemberLogin.ashx",
                        data: "type=findpwdverifycode&findpwdcode=" + inputcontrol + "",
                        success: function (result) {
                            if (result == "true") {
                                context.innerHTML = "";
                                //context.className="onCorrect1";
                                $("#spanShowMsg1").attr("state", "1");
                                boolresult = true;
                            } else {
                                boolresult = false;
                                context.innerHTML = "验证码错误";
                                //context.className="onError1";
                                $("#spanShowMsg1").attr("state", "0");
                            }
                        }
                    });
                }
                else {
                    context.innerHTML = "验证码不能为空";
                    $("#spanShowMsg1").attr("state", "0");
                    //context.className="onError1";
                    boolresult = false;
                }
                return boolresult;
            }

            var timerId;
            var $thisid;
            $(function () {

                $("#J_cannot_receive1").click(function () {
                    $(".cp_tooltip1").show(); setTimeout(function () { $(".cp_tooltip1").hide(); }, 3000);
                });
                $("#J_ver_btn1").click(function () {
                    if ($("#txtMCode1").val() == "") {
                        $("#spanShowMsg1").text("验证码不能为空！"); return false;
                    }
                    if ($("#spanShowMsg1").attr("state") == "0") {
                        $("#spanShowMsg1").text("验证码不正确！"); return false;
                    }
                    $("#J_ver_btn1").attr("disabled", "disabled");
                    $("#<%= M_code1.ClientID %>").removeAttr("disabled");
                    $("#spanConfirm1").get(0).className = "";
                    // $("#spanShowMsg1").get(0).className="onCorrect1";
                    $("#spanShowMsg1").text("短信已发送，请耐心等待...");
                    $("#spanShowMsg1").attr("style", "color:green; padding-left:10px;");
                    $thisid = $(this);
                    timerId = setInterval("goTo()", 1000);
                    $.get("/Api/CheckInfo.ashx?type=2&Mobile=" + $("#<%=nextmobile1.ClientID%>").text(), null, function (data) {
                        //alert("手机短信验证码已发送，请耐心等待......");
                        if (data != "1") {
                            $("#spanShowMsg1").get(0).className = "onError1";
                            $("#spanShowMsg1").text("短信发送出现异常，请重新验证");
                        }
                    });
                });

                $("#<%= M_code1.ClientID %>").focus(function () {
                    $("#spanShowMsg1").get(0).className = "onTips1";
                    $("#spanShowMsg1").text("验证码是6位字符");
                    $("#spanConfirm1").get(0).className = "";
                });

                $("#<%= M_code1.ClientID %>").blur(function () {
                    if (this.value == "") {
                        $("#spanShowMsg1").get(0).className = "onError1";
                        $("#spanShowMsg1").text("请输入验证码");
                    }
                    else {
                        $.get("/Api/CheckInfo.ashx?type=3&key=" + $("#<%=M_code1.ClientID%>").val() + "&mobile=" + $("#<%=nextmobile1.ClientID%>").text(), null, function (data) {
                            if (data == "1") {
                                $("#spanConfirm1").get(0).className = "onCorrect1";
                                $("#spanConfirm1").text("");
                                $("#spanShowMsg1").get(0).className = "";
                                $("#spanShowMsg1").text("");
                            }
                            else {
                                $("#spanShowMsg1").get(0).className = "onError1";
                                $("#spanShowMsg1").text("验证码错误或已过期，请重新输入!");
                            }
                        });
                    }
                });
            });

            var i = 60;
            function goTo1() {
                i--;
                $thisid.val("已发送验证码(" + i + "秒)");
                if (i == 0) {
                    $thisid.val("免费获取验证码");
                    clearInterval(timerId); i = 60;
                    $thisid.removeAttr("disabled");
                }
            }
        </script>
