<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Theme_ActivityOperate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Theme_ActivityOperate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主题活动</title>
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"></script>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <span id="LabelTitle">主题活动</span></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellspacing="1" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <th align="right" style="width: 100px;">
                                <span id="LabelName">活动名称：</span>
                            </th>
                            <td>
                                <input type="text" id="txtName" runat="server" class="tinput" maxlength="100" />
                                <span style="color: Red;">*</span><span check="errormsg">活动名称不能为空！</span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <span id="LabelMemo">开始时间：</span>
                            </th>
                            <td>
                                <script type="text/javascript" language="javascript" src="/JS/DatePicker/WdatePicker.js"
                                    defer="defer"></script>
                                <input type="text" id="txtStartTime" class="datetinput ss_nrduan" runat="server"
                                    onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" />
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <span id="Span1">结束时间：</span>
                            </th>
                            <td>
                                <input type="text" id="txtEndTime" class="datetinput ss_nrduan" runat="server" onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" />
                                <span style="color: Red;">*</span><span check="errormsg">活动结束时间不能小于开始时间！</span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <span id="Span3">横幅图片：</span>
                            </th>
                            <td>
                                <input type="hidden" id="hidpicTheme" runat="server" />
                                <img src="" runat="server" id="picTheme" width="690" height="158" />
                                <input type="button" value="设置横幅图片" onclick="openSingleChild()" />
                                &nbsp;<span check="errormsg" style="color: Red;"></span>
                                <br />
                                <span style="color: Red;">*</span><span id="imgCheck" check="errormsg">横幅图片不能为空！</span>
                                图片建议尺寸：宽1190 * 高458
                            </td>
                        </tr>
                        <tr>
                            <th align="right" style="width: 100px;">
                                <span id="Span4">活动说明：</span>
                            </th>
                            <td>
                                <%--<input type=""  maxlength="100"/>--%>
                                <textarea id="txtThemeDescription" runat="server" class="tinput" style="height: 100px;"></textarea>
                                <span style="color: Red;">*</span><span check="errormsg">活动说明不能为空！</span>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th align="right" style="width: 100px;">
                                <span id="Span5">排序：</span>
                            </th>
                            <td>
                                <input type="text" id="txtOrderID" runat="server" class="tinput" maxlength="100"
                                    value="0" />
                                <span style="color: Red;">*</span><span check="errormsg">数字越小越靠前！</span>
                            </td>
                        </tr>
                        <tr style="display: none;">
                            <th align="right">
                                <span id="Span2">报名截止时间：</span>
                            </th>
                            <td>
                                <input type="text" id="txtFinalTime" class="datetinput ss_nrduan" runat="server"
                                    onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" />
                                <span style="color: Red;">*</span><span check="errormsg">报名截止时间不能大于结束时间！</span>
                                <link rel="stylesheet" type="text/css" href="style/css.css" />
                                <script type="text/javascript" language="javascript" defer="defer">
                                    var lock = 0;
                                    //选择单图
                                    function openSingleChild() {
                                        if (lock == 0) {
                                            lock = 1
                                            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                                            if (k == undefined) { k = window.returnValue; }
                                            if (k != null) {
                                                var imgvalue = new Array();
                                                imgvalue = k.split(",");
                                                document.getElementById("picTheme").src = imgvalue[0];
                                                document.getElementById("hidpicTheme").value = imgvalue[1];
                                            }
                                            lock = 0
                                        }
                                    }



                                    function funCheck() {
                                        $("span[check='errormsg']").css("color", "black");
                                        if ($("#txtName").val() == "") {
                                            $("#txtName").focus().next().next().css("color", "red"); return false;
                                        }
                                        if (!compareTimex($("#txtStartTime").val(), $("#txtEndTime").val())) {
                                            $("#txtEndTime").focus().next().next().css("color", "red"); return false;
                                        }
                                        if ($("#txtThemeDescription").val() == "") {
                                            $("#txtThemeDescription").focus().next().next().css("color", "red"); return false;
                                        }
                                        if ($("#txtOrderID").val() == "") {
                                            $("#txtOrderID").focus().next().next().css("color", "red"); return false;
                                        }
                                        if ($("#fileCategory").val() == "") {
                                            $("#imgCheck").css("color", "red"); return false;
                                        }
                                        //             if(!compareTimex($("#txtStartTime").val(),$("#txtFinalTime").val()))
                                        //             {
                                        //                 $("#txtFinalTime").focus().next().show().text("报名截止时间不能小于等于开始时间！");return false;
                                        //             }
                                        return true;
                                    }
                                    function compareTimex(startTime, endTime) {
                                        var substartTime = startTime.toString().split(' ')[1];
                                        var subendTime = endTime.toString().split(' ')[1];
                                        startTime = startTime.toString().split(' ')[0];
                                        endTime = endTime.toString().split(' ')[0];


                                        var substartTime2 = substartTime.split(':')[1];
                                        var subendTime2 = subendTime.split(':')[1];
                                        substartTime = substartTime.split(':')[0];
                                        subendTime = subendTime.split(':')[0];
                                        var starttimes = startTime.split('-');
                                        var endtimes = endTime.split('-');
                                        var starttimeTemp = starttimes[0] + '/' + starttimes[1] + '/' + starttimes[2];
                                        var endtimesTemp = endtimes[0] + '/' + endtimes[1] + '/' + endtimes[2];
                                        if (Date.parse(new Date(starttimeTemp)) < Date.parse(new Date(endtimesTemp))) {
                                            return true;
                                        } else {
                                            if (parseInt(substartTime2) < parseInt(subendTime2)) { return true; } else if (parseInt(substartTime) < parseInt(subendTime)) { return true; } else { return false; }
                                        }
                                    } 
                                </script>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="btnSub" CssClass="fanh" runat="server" OnClientClick="return funCheck()"
                    Text="提交" OnClick="btnSub_Click" />
                <input type="button" onclick="location.href='Theme_ActivityList.aspx';" class="fanh"
                    value="返回" /><asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
