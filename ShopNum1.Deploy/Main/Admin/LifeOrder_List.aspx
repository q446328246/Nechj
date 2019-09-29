<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="LifeOrder_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.LifeOrder_List" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>订单列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <style type="text/css">
        #CalendarExtender1_popupDiv
        {
            height: 200px;
        }
        
        #CalendarExtender2_popupDiv
        {
            height: 200px;
        }
    </style>
    <script language="Javascript" type="text/javascript">
        var check = false;

        function SelectAllCheckboxesNew(o) {
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                inputs[j].checked = o.checked;
            }
        }

        var oldcolor;

        function Num1GridViewShow_mout(rowEl) {
            for (var i = 0; i < rowEl.cells.length; i++) {
                rowEl.cells[i].style.backgroundColor = oldcolor;
            }
        }

        function Num1GridViewShow_mover(rowEl) {
            for (var i = 0; i < rowEl.cells.length; i++) {
                oldcolor = rowEl.cells[i].style.backgroundColor;
                rowEl.cells[i].style.backgroundColor = "#ebeef5";
            }
        }

        function ImportData(flag) {
            if (flag) {
                document.getElementById("CheckGuid").value = "-1";
                return true;
            }
            var checkedBoxValues = GetCheckedBoxValues();
            if (checkedBoxValues == "0") {
                alert("请选择要导出的数据！");
                return false;
            } else {
                document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,', '');
                return true;
            }
        }

        function GetCheckedBoxValues() {
            var checkedBoxValues = "0";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].name == "checkboxorder" && inputs[j].checked == true) {
                    checkedBoxValues += ("," + "'" + inputs[j].value + "'");
                }
            }
            return checkedBoxValues;
        }

        $(function () {
            $("#sk_go").click(function () {
                var orid = $("#txtOrderNumber").val();
                var tradeid = $("#txtTradeId").val();
                var mid = $("#txtMemloginId").val();
                var shopname = $("#txtShopName").val();
                var shopid = $("#txtShopID").val();
                var ct = $("#TextBoxCreateTime1").val();
                var et = $("#TextBoxCreateTime2").val();
                var sp1 = $("#txtSp1").val();
                var sp2 = $("#txtSp2").val();
                location.href = "?trdeid=" + tradeid + "&orid=" + orid + "&mid=" + mid + "&ct=" + ct + "&et=" + et + "&sp1=" + sp1 + "&sp2=" + sp2 + "&shopid=" + shopid + "&sn=" + escape(shopname) + "&pageid=1";
            });
        });
    </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="mhead">
            <div class="ml">
                <div class="mr">
                    <ul class="mul">
                        <li id="current1">
                            <asp:LinkButton ID="LinkButtonAll" runat="server" CssClass="cur" OnClick="LinkButtonAll_Click">全部订单</asp:LinkButton>
                        </li>
                        <li id="current2">
                            <asp:LinkButton ID="LinkButtonNopayment" runat="server" OnClick="LinkButtonNopayment_Click">等待付款</asp:LinkButton>
                        </li>
                        <li id="current3">
                            <asp:LinkButton ID="LinkButtonPayment" runat="server" OnClick="LinkButtonPayment_Click">等待买家消费</asp:LinkButton>
                        </li>
                        <li id="current4" style="display: none;">
                            <asp:LinkButton ID="LinkButtonSend" runat="server" OnClick="LinkButtonSend_Click">已发货</asp:LinkButton>
                        </li>
                        <li id="current5">
                            <asp:LinkButton ID="LinkButtonComplete" runat="server" OnClick="LinkButtonComplete_Click">已完成</asp:LinkButton>
                        </li>
                        <li id="current6">
                            <asp:LinkButton ID="LinkButtonRefund" runat="server" OnClick="LinkButtonRefund_Click">已退款</asp:LinkButton>
                        </li>
                        <li id="current7">
                            <asp:LinkButton ID="LinkButtonReturnGoods" runat="server" OnClick="LinkButtonReturnGoods_Click">已退货</asp:LinkButton>
                        </li>
                        <li id="current8">
                            <asp:LinkButton ID="LinkButtonCancel" runat="server" OnClick="LinkButtonCanel_Click">已作废</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Label ID="LabelOrderNumber" runat="server" Text="订单号："></asp:Label>
                        </td>
                        <td>
                            <input type="text" id="txtOrderNumber" onkeyup=" NumTxt_Int(this) " class="tinput"
                                style="width: 200px;" value='<%= Common.ReqStr("orid") %>' />
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Label ID="LabelMemLoginID" runat="server" Text="购买人："></asp:Label>
                        </td>
                        <td>
                            <input type="text" id="txtMemloginId" class="tinput" style="width: 200px;" value='<%= Common.ReqStr("mid") %>' />
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            店铺名称：
                        </td>
                        <td>
                            <input type="text" id="txtShopName" class="tinput" style="width: 200px;" value='<%= Common.ReqStr("sn") %>' />
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            店铺ID：
                        </td>
                        <td>
                            <input type="text" id="txtShopID" class="tinput" style="width: 200px;" value='<%= Common.ReqStr("shopid") %>' />
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="LabelCreateTime" runat="server" Text="下单日期："></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateTime1" CssClass="tinput_data" runat="server"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 4px; width: 16px;" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </ShopNum1:ToolkitScriptManager>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxCreateTime1"
                                            PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="tinput_data" ID="TextBoxCreateTime2" runat="server"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                            position: relative; top: 4px; width: 16px;" />
                                    </td>
                                    <td>
                                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatorCreateTime2" runat="server"
                                            ControlToValidate="TextBoxCreateTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>--%>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxCreateTime2"
                                            PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Label ID="LabelShouldPayPrice" runat="server" Text="订单金额："></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" id="txtSp1" class="dinput" style="width: 66px;" value='<%= Common.ReqStr("sp1") %>' />
                                    </td>
                                    <td>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" id="txtSp2" class="dinput dp" style="width: 66px;" value='<%= Common.ReqStr("sp2") %>' />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right;">
                            <asp:Label ID="Label3" runat="server" Text="交易号："></asp:Label>
                        </td>
                        <td>
                            <input type="text" id="txtTradeId" class="dinput dp" onkeyup=" NumTxt_Int(this) "
                                style="width: 200px;" value='<%= Common.ReqStr("trdeid") %>' />
                        </td>
                        <td style="text-align: right;">
                            <input type="button" id="sk_go" class="orderbtn" value="搜索" />
                        </td>
                        <td colspan="2">
                            (友情提示：如果多个订单通过支付宝第三方支付一起支付的,在支付宝显示的是交易号。)
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonReport" runat="server" OnClick="ButtonReport_Click" OnClientClick=" return ImportData(false); "
                                    CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出当前订单</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonReportx" runat="server" OnClick="ButtonReportx_Click" OnClientClick=" return ImportData(true); "
                                    CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出全部订单</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClick="ButtonEdit_Click" OnClientClick=" return EditButton() "
                                    CausesValidation="False" CssClass="bt2" Visible="false"><span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" CssClass="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" cssclass="bt2" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <table cellspacing="0" cellpadding="4" border="0" id="Table1" rules="cols" class="gridview_m">
                <thead>
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col" class="select_width">
                            <input type="checkbox" onclick=" javascript:SelectAllCheckboxesNew(this); " id="checkboxAll">
                        </th>
                        <th scope="col">
                            订单号
                        </th>
                        <th scope="col">
                            店铺ID
                        </th>
                        <th scope="col">
                            店铺名称
                        </th>
                        <th scope="col">
                            手机号码
                        </th>
                        <th scope="col">
                            下单时间
                        </th>
                        <th scope="col">
                            订单总额
                        </th>
                        <th scope="col">
                            买家会员名
                        </th>
                        <th scope="col">
                            收货人
                        </th>
                        <th scope="col">
                            状态
                        </th>
                        <th scope="col">
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% if (dt_OrderList != null)
                       {
                           for (int i = 0; i < dt_OrderList.Rows.Count; i++)
                           {
                               DataRow dr = dt_OrderList.Rows[i];
                    %>
                    <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                        <td align="center" style="">
                            <input id="checkboxItem" value='<%= dr["ordernumber"] %>' type="checkbox" name="checkboxorder" />
                            <input type="hidden" value='<%= dr["ordernumber"] %>' name="checkboxorder" type="checkbox" />
                        </td>
                        <td align="center" style="">
                            <span id="Span1"><a href='Order_Operate.aspx?guid=<%= dr["guid"] %>'>
                                <%= dr["ordernumber"] %></a></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span2">
                                <%= dr["shopID"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span3">
                                <%= dr["ShopName"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span5">
                                <%= dr["mobile"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span6">
                                <%= dr["CreateTime"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span7">
                                <%= dr["ShouldpayPrice"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span8">
                                <%= dr["MemLoginID"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span9">
                                <%= dr["Name"] %></span>
                        </td>
                        <td align="center" style="">
                            <span id="Span10">
                                <%= ChangeOderStatus(dr["OderStatus"].ToString()) %></span>
                        </td>
                        <td align="center" style="">
                            <a href="Order_Operate.aspx?guid=<%= dr["guid"] %>&Type=1" style="color: #4482b4;">查看</a>
                            <a style="color: #4482b4; display: none;" href="?orid=<%= dr["ordernumber"] %>&jk"
                                onclick=" return window.confirm('您确定要删除吗?'); ">删除</a>
                        </td>
                    </tr>
                    <% }
                               } %>
                    <tr class="lmf_page" align="right" style="background-color: #F7F7DE; color: Black;">
                        <td style="height: 30px;" colspan="11">
                            <div class="btnlist" style="overflow: auto;" id="showPage" runat="server" visible="false">
                                <div class="fnum">
                                    每页显示数量： <a href="?tradeid=<%= Request.QueryString["tradeid"] %>&orid=<%= Request.QueryString["orid"] %>&mid=<%= Request.QueryString["mid"] %>&ct=<%= Request.QueryString["ct"] %>&et=<%= Request.QueryString["et"] %>&sp1=<%= Request.QueryString["sp1"] %>&sp2=<%= Request.QueryString["sp2"] %>&shopid=<%= Request.QueryString["shopid"] %>&sn=<%= Request.QueryString["sn"] %>&pagesize=10"
                                        id="page10">10</a> <a href="?tradeid=<%= Request.QueryString["tradeid"] %>&orid=<%= Request.QueryString["orid"] %>&mid=<%= Request.QueryString["mid"] %>&ct=<%= Request.QueryString["ct"] %>&et=<%= Request.QueryString["et"] %>&sp1=<%= Request.QueryString["sp1"] %>&sp2=<%= Request.QueryString["sp2"] %>&shopid=<%= Request.QueryString["shopid"] %>&sn=<%= Request.QueryString["sn"] %>&pagesize=20"
                                            id="page20">20</a> <a href="?tradeid=<%= Request.QueryString["tradeid"] %>&orid=<%= Request.QueryString["orid"] %>&mid=<%= Request.QueryString["mid"] %>&ct=<%= Request.QueryString["ct"] %>&et=<%= Request.QueryString["et"] %>&sp1=<%= Request.QueryString["sp1"] %>&sp2=<%= Request.QueryString["sp2"] %>&shopid=<%= Request.QueryString["shopid"] %>&sn=<%= Request.QueryString["sn"] %>&pagesize=50"
                                                id="page50">50</a>
                                </div>
                                <div class="fpage" id="pageDiv" runat="server">
                                </div>
                                <script type="text/javascript" language="javascript">
                                    function NumTxt_Int(o) {
                                        o.value = o.value.replace(/\D/g, '');
                                    }

                                    // 判断是否是数字

                                    function checknum(str) {
                                        var re = /^[0-9]+.?[0-9]*$/;
                                        if (!re.test(str)) {
                                            alert("请输入正确的数字！");
                                            return false;
                                        } else {
                                            return true;
                                        }
                                    }

                                    $(function () {
                                        var pagesize = '<%= Common.ReqStr("pagesize") %>';
                                        $("#page" + pagesize).addClass("cur");
                                        $(".fpage").find(".quedbtn").click(function () {
                                            var pageindex = $("input[name='vjpage']").val();
                                            if (checknum(pageindex)) {
                                                location.href = '?tradeid=<%= Request.QueryString["tradeid"] %>&orid=<%= Request.QueryString["orid"] %>&mid=<%= Request.QueryString["mid"] %>&ct=<%= Request.QueryString["ct"] %>&et=<%= Request.QueryString["et"] %>&sp1=<%= Request.QueryString["sp1"] %>&sp2=<%= Request.QueryString["sp2"] %>&shopid=<%= Request.QueryString["shopid"] %>&sn=<%= Request.QueryString["sn"] %>&pagesize=' + pagesize + '&pageid=' + pageindex;
                                            }
                                        });
                                    });
                                </script>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <%--多余的 不能删的--%>
    <div class="query" style="display: none;">
        <asp:Label ID="LabelOderStatus" runat="server" Text="订单状态："></asp:Label>
        <asp:DropDownList ID="DropDownListOderStatus" runat="server" CssClass="inputselect">
        </asp:DropDownList>
        <table style="width: 100%">
            <tr>
                <td align="right">
                    <asp:Label ID="LabelAddress1" runat="server" Text="详细地址："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAddress" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelPostalcode" runat="server" Text="邮编："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxPostalcode" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelMobile" runat="server" Text="手机号码："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxMobile" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelEmail" runat="server" Text="电子邮件："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelTel" runat="server" Text="联系电话："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTel" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    <asp:Label ID="LabelName" runat="server" Text="收货人："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxName" CssClass="allinput1" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" Width="180px">
                        <asp:ListItem Value="0">普通订单</asp:ListItem>
                        <asp:ListItem Value="-1">全部订单</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelPaymentState" runat="server" Text="付款状态："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListPaymentState" runat="server" CssClass="select1">
                        <asp:ListItem Value="-1" Text="-全部-"></asp:ListItem>
                        <asp:ListItem Value="0" Text="未付款"></asp:ListItem>
                        <asp:ListItem Value="1" Text="已付款"></asp:ListItem>
                        <asp:ListItem Value="2" Text="已退款"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">
                    <asp:Label ID="LabelShipmentState" runat="server" Text="发货状态："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListShipmentState" runat="server" CssClass="select1">
                        <asp:ListItem Value="-1" Text="-全部-"></asp:ListItem>
                        <asp:ListItem Value="0" Text="未发货"></asp:ListItem>
                        <asp:ListItem Value="1" Text="已发货"></asp:ListItem>
                        <asp:ListItem Value="2" Text="已收货"></asp:ListItem>
                        <asp:ListItem Value="3" Text="已退货"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <div class="vote" style="display: none;">
        <asp:Button ID="ButtonHtml" runat="server" Text="导出HTML" CausesValidation="False"
            OnClientClick=" this.form.target = '_blank';window.location.href = window.location.href; "
            CssClass="bt3" OnClick="ButtonHtml_Click" Visible="false" />
        <asp:RadioButtonList ID="RadioButtonListOutPage" runat="server" AutoPostBack="True"
            RepeatDirection="Horizontal" Visible="false">
            <asp:ListItem Selected="True" Value="0">仅导出当前页</asp:ListItem>
            <asp:ListItem Value="1">导出所有查询记录</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
