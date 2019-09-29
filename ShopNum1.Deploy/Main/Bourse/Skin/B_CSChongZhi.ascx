<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="B_CSChongZhi.ascx.cs" Inherits="ShopNum1.Deploy.Main.Bourse.Skin.B_CSChongZhi" %>
<div id="list_main" class="list_main1">
    <ul id="sidebar">
        <li class="TabbedPanelsTab TabbedPanelsTabSelected"
            id="0"><a href="B_CSChongZhi.aspx" style="text-decoration: none;">充值CS积分</a></li>
        
   
    </ul>
    <div id="content">
   
         <div >
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
                        当前金币数：
                    </td>
                    <td>
                        <strong class="red" style="font-size: 14px;">￥<asp:Label ID="Score_bv" runat="server"
                            Text=""></asp:Label>
                        </strong>
                    </td>
                </tr>
                <tr class="trgz">
                    <td class="tab_r">
                        充值CS积分数：
                    </td>
                    <td>
                        <input type="text" class="textwb" id="bvScore_bv" runat="server" value="0" style="width: 100px;"
                            onchange="funbvScore_bv()" onblur="funbvScore_bv()" maxlength="32" />
                        <span class="star1">元</span> <span class="star" id="errbvmoney"></span>
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

            function funbvScore_bv() {
                var txt_Decrease = $("#<%=bvScore_bv.ClientID%>").val();
                if (txt_Decrease != "") {
                    var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
                    if (!oo.test(txt_Decrease)) {
                        $("#errbvmoney").html("充值金额格式错误！");
                        return false;
                    }
                    else {
                        var allMoney = parseFloat($("#<%=Score_bv.ClientID%>").text())

                        if (parseFloat(txt_Decrease) > allMoney) {
                            $("#errbvmoney").html("充值金额不能大于当前人民币金额！");
                            return false;
                        }

                        else {
                            var money = "";

                            $("#errbvmoney").html("正确！");
                            return true;
                        }

                    }
                }
                else {
                    $("#errbvmoney").html("提充值金额不能为空！");
                    return false;
                }
                return false;
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
            
            
            

            
        </script>