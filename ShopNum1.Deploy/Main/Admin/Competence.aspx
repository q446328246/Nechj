<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Competence.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Competence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>权限列表</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" class="checksub" />
    <style type="text/css">
        .ordertable th, .ordertable td
        {
            border: none;
            text-align: left;
        }
        
        .welcon p
        {
            color: #666666;
            height: 24px;
            line-height: 24px;
        }
        
        .gridview_m tr.lmf_hover td
        {
            background: #ebeef5;
        }
    </style>
    <script src="js/jquery-1.9.1.js" type="text/javascript"> </script>
    <script type="text/javascript">
        $(function () {
            //滑过效果
            $(".lmf_huaguo").hover(function () {
                $(this).addClass("lmf_hover");

            },
                    function () {
                        $(this).removeClass("lmf_hover");
                    });
            var bflag = "false";
            //      

            $(".checksub input[type='checkbox']").click(function () {
                $(this).parent().parent().parent().parent().parent().parent().prev().find(".checktop input[type='checkbox']").attr("checked", $(this).attr("checked"));
            });

        });

        function funcheck(str, o) {
            var arry = str.split("-");
            if (o) {
                for (var i in arry) {
                    document.getElementById("check_sub_" + arry[i]).checked = true;
                }
            } else {
                for (var i in arry) {
                    document.getElementById("check_sub_" + arry[i]).checked = false;
                }
            }
        }

        function cancelcheck(p, o, x) {
            var bflag = true;
            var arry = x.split("-");
            if (o) {
                for (var i in arry) {
                    if (!document.getElementById("check_sub_" + arry[i]).checked) {
                        bflag = false;
                    }
                }
                if (bflag) {
                    document.getElementById("parent_" + p).checked = true;
                }
            } else {
                document.getElementById("parent_" + p).checked = false;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    权限列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table cellpadding="0" cellspacing="0" border="0" width="98%" class="gridview_m"
                style="margin: 0 auto;">
                <tr class="list_header">
                    <th>
                        模块名称
                    </th>
                    <th>
                        页面名称
                    </th>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                        padding-left: 30px; width: 180px;">
                        网站设置
                    </td>
                    <td align="left" valign="top" style="background: #ebeef4;">
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="background: #ebeef4;">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_1" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('1-2-1000',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    基本设置
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1" name="p_check_sub_1" Checked="false" Text="" runat="server"
                                        ToolTip="FD984F4C-4061-47C4-BE07-B203FDE3CF51" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    增加KT
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_2" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="A09B13DC-0C5E-4DE5-AD99-52FA5C9CD903" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    增加债贝
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="CheckBox4" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="6A35D2A8-BB23-41DC-A8BD-12AFDD39C0AD" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    CTC团队领导
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1"  >
                                    <asp:CheckBox ID="CheckBox10" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="5D581299-7250-457F-BD56-4C1A0D9D66E2" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1"  >
                                    会员推荐图
                                </td>

                                <td align="left" valign="top" class="lmf_xzk1"  >
                                    <asp:CheckBox ID="CheckBox11" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="744C2E42-0040-418B-A85F-1FFFCB34FC96" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1"  >
                                    商家申请
                                </td>

                                 <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="CheckBox9" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="353F92F0-6A27-40F9-8137-540D15937A34" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    查找推荐上级所有
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1" style="display: none">
                                    <asp:CheckBox ID="check_sub_300" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="54772755-91C0-4ABF-B218-E19FD83ED5E5" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1" style="display: none">
                                    添加图片
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1000" name="p_check_sub_1" Checked="false" runat="server"
                                        ToolTip="9BB47017-1221-47C5-B64D-8C5D83F08CF6s" class="checksub" onclick="cancelcheck('1',this.checked,'1-2-1000')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    分类提成设置
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_2" Checked="false" runat="server" ToolTip="" class="checktop"
                                        onclick="funcheck('3-4-5',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    客服管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_3" Checked="false" runat="server" ToolTip="730E05B3-42D8-4264-BF57-449F7D1D9980"
                                        class="checksub" onclick="cancelcheck('2',this.checked,'3-4-5')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    客服管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_4" Checked="false" runat="server" ToolTip="411176DB-5DE5-4075-BCEF-2C8DA15AFE28"
                                        class="checksub" onclick="cancelcheck('2',this.checked,'3-4-5')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    在线客服
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_5" Checked="false" runat="server" ToolTip="9FA68565-2064-43FC-88AA-2260F2E96509"
                                        class="checksub" onclick="cancelcheck('2',this.checked,'3-4-5')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    在线客服添加
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_3" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('6-7-10001',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    支付方式
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_6" Checked="false" runat="server" ToolTip="819AE960-E0BF-4B5A-A1BC-EF57A68D5C93"
                                        class="checksub" onclick="cancelcheck('3',this.checked,'6-7-10002-10001')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    支付方式
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_7" Checked="false" runat="server" ToolTip="D4C4BE09-9BAE-4EB4-A2BF-9C5F5DA2B765"
                                        class="checksub" onclick="cancelcheck('3',this.checked,'6-7-10002-10001')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    新增支付方式
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_10002" Checked="false" runat="server" ToolTip="C7F446DF-3105-40AC-831F-2BD3951B6A60"
                                        class="checksub" onclick="cancelcheck('3',this.checked,'6-7-10002-10001')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    手机支付方式
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_10001" Checked="false" runat="server" ToolTip="74434213-1401-413C-815F-49E4A2212693"
                                        class="checksub" onclick="cancelcheck('3',this.checked,'6-7-10002-10001')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    支付方式类型
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_4" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('8-9',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    物流公司
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_8" Checked="false" runat="server" ToolTip="EB1C0339-433F-42C0-9812-84ED76C38DE9"
                                        class="checksub" onclick="cancelcheck('4',this.checked,'8-9')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    物流公司
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_9" Checked="false" runat="server" ToolTip="9B4F0D8B-2481-434A-B682-448B66CD7829"
                                        class="checksub" onclick="cancelcheck('4',this.checked,'8-9')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    物流公司操作页
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_5" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('10-11',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    地区列表
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_10" Checked="false" runat="server" ToolTip="8A10825D-6501-4730-AC8A-3C4A57FE7E1D"
                                        class="checksub" onclick="cancelcheck('5',this.checked,'10-11')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    地区列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_11" Checked="false" runat="server" ToolTip="7ED5BD3F-43C7-4047-AE99-4E83D258525D"
                                        class="checksub" onclick="cancelcheck('5',this.checked,'10-11')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    地区操作
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_6" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('12-13-15-16-17',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    图片列表
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_12" Checked="false" runat="server" ToolTip="DBF47133-6210-4D2D-913B-F29EE1D900E1"
                                        class="checksub" onclick="cancelcheck('6',this.checked,'12-13-15-16-17')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    图片分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_13" Checked="false" runat="server" ToolTip="20FE30F6-22FB-43D9-8053-C59FCCE9A34D"
                                        class="checksub" onclick="cancelcheck('6',this.checked,'12-13-15-16-17')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    图片分类操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_15" Checked="false" runat="server" ToolTip="D3836828-ED5A-4959-9787-874E1F8D73E7"
                                        class="checksub" onclick="cancelcheck('6',this.checked,'12-13-15-16-17')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    图片列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_17" Checked="false" runat="server" ToolTip="B3755438-C38A-4ACD-BBBD-906F57CBEF4A"
                                        class="checksub" onclick="cancelcheck('6',this.checked,'12-13-15-16-17')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    图片水印
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_16" Checked="false" runat="server" ToolTip="50A9C15F-5C2B-4F22-A67A-47484730F14A"
                                        class="checksub" onclick="cancelcheck('6',this.checked,'12-13-15-16-17')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    添加图片操作
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_7" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('18-1002-19-20-21-22',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    系统集成
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_18" Checked="false" runat="server" ToolTip="F8737A2F-25A0-449F-883C-3057E831C067"
                                        class="checksub" onclick="cancelcheck('7',this.checked,'18-1002-19-20-21-22')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    第三方登录集成
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1002" Checked="false" runat="server" ToolTip="ABC1663F-F4F4-48D4-A51C-238F20C1ECAA"
                                        class="checksub" onclick="cancelcheck('7',this.checked,'18-1002-19-20-21-22')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    第三方登录集成
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_19" Checked="false" runat="server" ToolTip="490FD5AD-3B7B-4056-9433-16152B84B103"
                                        class="checksub" onclick="cancelcheck('7',this.checked,'18-1002-19-20-21-22')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    集成Discuz!NT
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_20" Checked="false" runat="server" ToolTip="3A2424D7-649F-4D01-A341-67E9442663CD"
                                        class="checksub" onclick="cancelcheck('7',this.checked,'18-1002-19-20-21-22')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    集成UCenter
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_21" Checked="false" runat="server" ToolTip="8B8B6629-C4B0-42F5-91D3-2FFA5856DAEE"
                                        class="checksub" onclick="cancelcheck('7',this.checked,'18-1002-19-20-21-22')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    集成团购系统
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_22" Checked="false" runat="server" ToolTip="8519C2CA-2810-4BDF-93F7-262B142CD346"
                                        class="checksub" onclick="cancelcheck('7',this.checked,'18-1002-19-20-21-22')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    集成联盟系统
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="background: #ebeef4;">
                    <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                        padding-left: 30px; width: 180px;">
                        商品管理
                    </td>
                    <td align="left" valign="top" style="background: #ebeef4;">
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_8" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('23-24-25-26-27-28-29-30-1003-1004',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品基础设置
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_23" Checked="false" runat="server" ToolTip="23DD789D-5992-406C-8101-102B12157CD3"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品品牌
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_24" Checked="false" runat="server" ToolTip="8F901B55-FB04-4315-A297-D4DED942748C"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品品牌操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_25" Checked="false" runat="server" ToolTip="D1A63555-165F-48A6-93A8-1032C1E619AC"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    规格管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_26" Checked="false" runat="server" ToolTip="B2B7BBB1-4929-42AE-BD42-0545C1ED6773"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    规格操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_27" Checked="false" runat="server" ToolTip="67077555-B57E-4526-97A5-8E1666B8D1F7"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    属性管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_28" Checked="false" runat="server" ToolTip="0EE2116F-9AA3-4778-9DAA-41B725A48E11"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    属性操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_29" Checked="false" runat="server" ToolTip="4BCB622C-E58A-40CD-8BF9-554B2AF49186"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_30" Checked="false" runat="server" ToolTip="43DF77B6-2B7A-4D48-9FAB-98BAB2572696"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品分类操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1003" Checked="false" runat="server" ToolTip="52782BC0-61D0-419D-A2F2-0DA6116DB43B"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品类型
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1004" Checked="false" runat="server" ToolTip="0A035B6C-2DAD-4ED3-AB86-1BB99A912784"
                                        class="checksub" onclick="cancelcheck('8',this.checked,'23-24-25-26-27-28-29-30-1003-1004')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品类型操作
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_9" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('31-32-33-34-302',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_31" Checked="false" runat="server" ToolTip="EB74A093-F587-4C8A-AA58-6DAC415CD97C"
                                        class="checksub" onclick="cancelcheck('9',this.checked,'31-32-33-34-302-3022')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_32" Checked="false" runat="server" ToolTip="8CE0DA2F-3A5E-4D4D-B443-E579B6C2DE62"
                                        class="checksub" onclick="cancelcheck('9',this.checked,'31-32-33-34-302-3022')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    抢购商品列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_33" Checked="false" runat="server" ToolTip="12BF53E3-3ACF-49E9-AED4-0E70FE07ADC9"
                                        class="checksub" onclick="cancelcheck('9',this.checked,'31-32-33-34-302-3022')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    团购商品列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_34" Checked="false" runat="server" ToolTip="AC669956-5449-46D3-ACF7-F28EEBDCBC63"
                                        class="checksub" onclick="cancelcheck('9',this.checked,'31-32-33-34-302-3022')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品评论列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_302" Checked="false" runat="server" ToolTip="A0426CDF-A602-4C7E-8DAA-DC20D900AE96"
                                        class="checksub" onclick="cancelcheck('9',this.checked,'31-32-33-34-302-3022')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品评论查看
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_3022" Checked="false" runat="server" ToolTip="727D10EA-A845-4384-B48A-6F8FB4A73748"
                                        class="checksub" onclick="cancelcheck('9',this.checked,'31-32-33-34-302-3022')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    首页推荐BTC商品
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_10" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('35-303-36-38',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品信息审核
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_35" Checked="false" runat="server" ToolTip="CA0F6DB7-BD58-45B0-B3A9-A01CED14A423"
                                        class="checksub" onclick="cancelcheck('10',this.checked,'35-303-36-38')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品信息审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_303" Checked="false" runat="server" ToolTip="1F770CBB-818C-45BB-B5C5-7164E13464A7"
                                        class="checksub" onclick="cancelcheck('10',this.checked,'35-303-36-38')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品查看页
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_36" Checked="false" runat="server" ToolTip="3D05C2D5-AD12-4FDD-85C4-AF68FAD16DE6"
                                        class="checksub" onclick="cancelcheck('10',this.checked,'35-303-36-38')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    抢购信息审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_38" Checked="false" runat="server" ToolTip="F4C36A2D-1DEA-4D8E-BEFD-F1FA3286F02D"
                                        class="checksub" onclick="cancelcheck('10',this.checked,'35-303-36-38')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    商品评论审核
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="background: #ebeef4;">
                    <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                        padding-left: 30px; width: 180px;">
                        订单管理
                    </td>
                    <td align="left" valign="top" style="background: #ebeef4;">
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_11" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('39-40-41-4100-4174-41745',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    订单管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_39" Checked="false" runat="server" ToolTip="2A85E27B-2483-42A2-9833-8D0444F7F815"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    团购订单列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_40" Checked="false" runat="server" ToolTip="ABE44419-DA37-440F-9C06-1AA2F1A05960"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    抢购订单列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_41" Checked="false" runat="server" ToolTip="AB8CC5B6-FDFA-41D4-9825-D8CCDBB17DD8"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    订单列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_422" Checked="false" runat="server" ToolTip="D65F1082-3503-48F8-BE1D-41C28E8DDF70"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    CTC交易明细
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_4100" Checked="false" runat="server" ToolTip="F1FB89CA-A9FE-40E2-BE69-5CE94816ACBB"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    生活服务订单列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_4174" Checked="false" runat="server" ToolTip="FB54985C-70D6-4D50-9C36-C7821D2549E2"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    被A网拒绝的订单审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_41745" Checked="false" runat="server" ToolTip="18948A02-6832-4FE8-AAB9-7FCCF7440822"
                                        class="checksub" onclick="cancelcheck('11',this.checked,'39-40-41-4100-4174-41745')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    申请退款的列表
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_12" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('42-1005-43-1006',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    举报||投诉
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_42" Checked="false" runat="server" ToolTip="46637723-CD57-4B69-BCE2-81E4FA78DDE9"
                                        class="checksub" onclick="cancelcheck('12',this.checked,'42-1005-43-1006')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    举报管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1005" Checked="false" runat="server" ToolTip="207AB8C8-FED6-4021-874E-6E4CD1141D87"
                                        class="checksub" onclick="cancelcheck('12',this.checked,'42-1005-43-1006')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    举报查看回复
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_43" Checked="false" runat="server" ToolTip="85A15C29-B292-4EE6-908F-B9E5C98E66E4"
                                        class="checksub" onclick="cancelcheck('12',this.checked,'42-1005-43-1006')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    投诉管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1006" Checked="false" runat="server" ToolTip="7986EF47-B599-4B80-8D27-4A32AF3998DC"
                                        class="checksub" onclick="cancelcheck('12',this.checked,'42-1005-43-1006')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    投诉管理评论
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="background: #ebeef4;">
                    <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                        padding-left: 30px; width: 180px;">
                        会员管理
                    </td>
                    <td align="left" valign="top" style="background: #ebeef4;">
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_13" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('44-45-1600-1601-47-48-1007-1008-1607',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_44" Checked="false" runat="server" ToolTip="307638CF-5BED-43D2-BF57-3D5D3992EA94"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="CheckBox3" Checked="false" runat="server" ToolTip="60E24EE5-E006-47F7-B3EB-959E6DF2EC0D"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员等级
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1607" Checked="false" runat="server" ToolTip="341740EF-A4D1-48A7-B181-CA9D780AF5CC"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员留言
                                </td>

                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_45" Checked="false" runat="server" ToolTip="C9E1F17E-243F-4A6F-A0C1-6753C1D173D2"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    添加会员
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1600" Checked="false" runat="server" ToolTip="D6FBF561-BBF4-4692-83C3-FFE8B65AB7A7"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    变更金币（BV）
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1601" Checked="false" runat="server" ToolTip="2FF3E5FA-D124-4511-937E-3DF4EC6A9823"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    冻结金币（BV）
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_47" Checked="false" runat="server" ToolTip="60E24EE5-E006-47F7-B3EB-959E6DF2EC0D"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员等级
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_48" Checked="false" runat="server" ToolTip="1CCDC363-0BD5-460C-A885-AF5AC010DF56"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员等级操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1007" Checked="false" runat="server" ToolTip="943976F8-4B40-4DBC-834B-193D740F2AB6"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    消费红包操作日志
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1008" Checked="false" runat="server" ToolTip="90CF73F6-D695-4977-9543-4EEA0E5F40B1"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    等级红包操作日志
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_2021" Checked="false" runat="server" ToolTip="D6B9CFAE-4C1B-48F3-9BBA-73FE1C528E4D"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员推荐商品列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_2022" Checked="false" runat="server" ToolTip="44B6A753-3B91-4AA3-863F-D59CF1FD97B5"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    专区绑定
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_2023" Checked="false" runat="server" ToolTip="B5306A1A-D9E2-4A70-960E-740B7ED317AA"
                                        class="checksub" onclick="cancelcheck('13',this.checked,'44-45-1600-1601-47-48-1007-1008-1607-2021-2022-2023')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    区代、社区调换
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_144" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('500-501',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    站内消息
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_500" Checked="false" runat="server" ToolTip="75A06554-89B0-4A65-97DA-A58E187188C3"
                                        class="checksub" onclick="cancelcheck('144',this.checked,'500-501')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    消息发件箱
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_501" Checked="false" runat="server" ToolTip="CD5BF11C-3DBF-40CE-9221-90F05D8EA6A6"
                                        class="checksub" onclick="cancelcheck('144',this.checked,'500-501')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    发送消息
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_14" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('49-800',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    建议管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_49" Checked="false" runat="server" ToolTip="EB1C46BE-7958-461F-BFB3-870CC1500323"
                                        class="checksub" onclick="cancelcheck('14',this.checked,'49-800')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    建议管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_800" Checked="false" runat="server" ToolTip="EE89F0CB-D726-415E-B891-3C39855D1C96"
                                        class="checksub" onclick="cancelcheck('14',this.checked,'49-800')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    建议查看
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="display: none">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_15" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('50-505',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员信息审核
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_505" Checked="false" runat="server" ToolTip="B6A44813-167B-44EA-919E-DE35F699CFF6"
                                        class="checksub" onclick="cancelcheck('15',this.checked,'50-505')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员信息审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_50" Checked="false" runat="server" ToolTip="11CB7BD4-6578-464D-9E3C-955D40EB471C"
                                        class="checksub" onclick="cancelcheck('15',this.checked,'50-505')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员购买广告审核
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="background: #ebeef4;">
                    <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                        padding-left: 30px; width: 180px;">
                        店铺管理
                    </td>
                    <td align="left" valign="top" style="background: #ebeef4;">
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_16" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('51-52-53-54-55-56-57-58-59-60-61-62',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺基础设置
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_51" Checked="false" runat="server" ToolTip="D671A030-DBB2-4239-8634-C7216F261E57"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_52" Checked="false" runat="server" ToolTip="A412E483-C664-47C9-B8F3-99A3A3FB22C0"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺分类操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_53" Checked="false" runat="server" ToolTip="F54B1C1C-B6F7-4D9A-8682-63A17DEBA1CD"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺等级列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_54" Checked="false" runat="server" ToolTip="5C052248-A4E8-44AD-90C8-7ED94416B792"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺等级操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_55" Checked="false" runat="server" ToolTip="25216A38-8F36-40B1-B817-1CD6671C7796"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺模板列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_56" Checked="false" runat="server" ToolTip="17EFE9DC-21AF-4069-A294-9ABA27AD8AD3"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    模板操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_57" Checked="false" runat="server" ToolTip="6E5DD338-B42D-4E7C-9ECB-28F7E1765462"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    优惠券分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_58" Checked="false" runat="server" ToolTip="6B5066D9-92B9-4E53-B880-D4C15F021044"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    优惠券分类操作
                                </td>
                            </tr>
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_59" Checked="false" runat="server" ToolTip="892C38A1-424B-49AE-8CE9-BB9C793A30D9"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺信誉列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_60" Checked="false" runat="server" ToolTip="4EE44EB5-AF3D-4DC1-BAD0-C2DC743F2F9F"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺信誉操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_61" Checked="false" runat="server" ToolTip="5FA8D1C3-0C32-4466-B030-78F9DBA73710"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺担保列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_62" Checked="false" runat="server" ToolTip="9448F0FA-4278-4B31-B33F-7C4F8C179CAF"
                                        class="checksub" onclick="cancelcheck('16',this.checked,'51-52-53-54-55-56-57-58-59-60-61-62')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    担保操作
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_17" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('63-64-65-66-1009-306-307-1010',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_63" Checked="false" runat="server" ToolTip="7C36C02D-E5DA-4B18-8F60-0E081F073E59"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1" style="display: none">
                                    <asp:CheckBox ID="check_sub_305" Checked="false" runat="server" ToolTip="8460586B-3351-4413-9F4B-31CD1070EEDA"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1" style="display: none">
                                    修改店铺等级
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1009" Checked="false" runat="server" ToolTip="8114B5E6-C254-4195-A0B4-85A83CBC7FB1"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺支付方式
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_306" Checked="false" runat="server" ToolTip="5BBF56A0-CF39-49C7-B60B-B2634C7F0A99"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_64" Checked="false" runat="server" ToolTip="D2AB7C76-68AD-444C-BB62-32A7F6C48900"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    已申请担保列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_65" Checked="false" runat="server" ToolTip="3C763C0D-058F-4543-A3F5-95F8353C1079"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺域名列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_66" Checked="false" runat="server" ToolTip="772E181E-D7A1-421E-B8C1-5EE87324C873"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺优惠券列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_307" Checked="false" runat="server" ToolTip="77C32B62-D2E8-474A-8282-71707549EAF1"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺优惠券查看页
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1010" Checked="false" runat="server" ToolTip="12893F35-1BEC-449E-9B28-C16AC8E934F0"
                                        class="checksub" onclick="cancelcheck('17',this.checked,'63-64-65-66-1009-306-307-1010')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺图库列表
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_18" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('67-1011-68-1012',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_67" Checked="false" runat="server" ToolTip="AA5AA24C-15C2-4F4B-AD61-4CF74543D54A"
                                        class="checksub" onclick="cancelcheck('18',this.checked,'67-1011-68-1012')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1011" Checked="false" runat="server" ToolTip="83F1FF55-93FC-419C-805E-85B124175EEE"
                                        class="checksub" onclick="cancelcheck('18',this.checked,'67-1011-68-1012')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章详细
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_68" Checked="false" runat="server" ToolTip="F9815CF1-F680-44F5-892F-82D04D29D578"
                                        class="checksub" onclick="cancelcheck('18',this.checked,'67-1011-68-1012')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章评论
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1012" Checked="false" runat="server" ToolTip="76F3ABAF-54AA-4D3F-92D1-E02851128CD5"
                                        class="checksub" onclick="cancelcheck('18',this.checked,'67-1011-68-1012')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    资讯评论详细
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_19" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('69-70',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺视频
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_69" Checked="false" runat="server" ToolTip="9525E573-8B0E-4ADD-84B0-E7CEDE57BD25"
                                        class="checksub" onclick="cancelcheck('19',this.checked,'69-70')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺视频列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_70" Checked="false" runat="server" ToolTip="57CF5E51-5722-4B47-BE45-E306BD5B3F32"
                                        class="checksub" onclick="cancelcheck('19',this.checked,'69-70')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺视频评论列表
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_20" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('72-73-1013-76-77-1014-370-371-372',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺信息审核
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_72" Checked="false" runat="server" ToolTip="2B33782A-6022-4D3E-9DB9-FD1841867D28"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺域名审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_73" Checked="false" runat="server" ToolTip="3911A466-E22F-4DD9-B5CD-D618CB889168"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺审核列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1013" Checked="false" runat="server" ToolTip="9E2598E2-4C48-4E73-9905-5118B37B548C"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺审核未通过列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_76" Checked="false" runat="server" ToolTip="80BEA6C6-6742-4E5C-8B82-86E8E085476C"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_77" Checked="false" runat="server" ToolTip="274E07A3-8F58-476A-A2EB-1D8DC1E928F0"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺优惠券审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1014" Checked="false" runat="server" ToolTip="9C6AD4E4-69E3-4158-8883-6DC702E0A82E"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章评论审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_370" Checked="false" runat="server" ToolTip="CA37C91D-CD0A-4D7C-AD74-B1982131E128"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺视频审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_371" Checked="false" runat="server" ToolTip="FFFE4C07-08F9-41F1-B235-62C52E44AC12"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺视频评论审核
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_372" Checked="false" runat="server" ToolTip="7874EC9E-FFDC-4D21-B3B7-242DEC9A3E06"
                                        class="checksub" onclick="cancelcheck('20',this.checked,'72-73-1013-76-77-1014-370-371-372')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺视频评论详细
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo" style="background: #ebeef4;">
                    <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                        padding-left: 30px; width: 180px;">
                        营销推广
                    </td>
                    <td align="left" valign="top" style="background: #ebeef4;">
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_25" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('91-310-98-99-1015-92-93-97',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件系统
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_91" Checked="false" runat="server" ToolTip="41986BC1-30D3-41DA-BEC3-C9D2E4112F30"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件模板
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_310" Checked="false" runat="server" ToolTip="B5F27DBF-7161-4C7E-887B-B4A6799DF184"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件模版详细
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_98" Checked="false" runat="server" ToolTip="E58C5345-8A28-40B0-A409-67A367BAC62D"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件接口设置
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_99" Checked="false" runat="server" ToolTip="FEF95D17-6182-4ADB-90C7-23AA3AA37C72"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员组管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1015" Checked="false" runat="server" ToolTip="E4CC2D1D-EB85-4F0A-A92F-00AB81AE3CA0"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员组操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_92" Checked="false" runat="server" ToolTip="85881C92-4756-4EC1-8C29-EA880D1BBFA1"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件群发
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_93" Checked="false" runat="server" ToolTip="8CE507B8-A53F-4469-965D-D76485EFEEBF"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件发送历史
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_97" Checked="false" runat="server" ToolTip="833648EC-1A41-4C13-AE39-6DABD7F69E3B"
                                        class="checksub" onclick="cancelcheck('25',this.checked,'91-310-98-99-1015-92-93-97')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    邮件发送设置
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_26" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('102-103-104-105-106-107-108-109-110-111-311',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信系统
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1" style="display: none">
                                    <asp:CheckBox ID="check_sub_102" Checked="false" runat="server" ToolTip="38C864C5-BA71-4C77-8974-1E578F8C53B8"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1" style="display: none">
                                    短信分类列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1" style="display: none">
                                    <asp:CheckBox ID="check_sub_103" Checked="false" runat="server" ToolTip="AA6884FF-1548-451F-84E8-C4F6A35F83F2"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1" style="display: none">
                                    短信分类操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_104" Checked="false" runat="server" ToolTip="940DF37C-372C-417D-A313-663151175F1A"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信模板
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_105" Checked="false" runat="server" ToolTip="2D203753-7510-43C9-99C5-12137B17B0A1"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_106" Checked="false" runat="server" ToolTip="E27D78F7-75D1-4A4E-90DF-4F4218A40DF8"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    会员组管理
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_107" Checked="false" runat="server" ToolTip="4F0470A6-B750-4CC5-AAFF-75C7F5D98847"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信会员组操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_108" Checked="false" runat="server" ToolTip="DBDE0CDA-1055-4108-B792-33DA3997646E"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信群发
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_109" Checked="false" runat="server" ToolTip="8274E123-04F7-41C7-B1A4-9AA0ACC39223"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信发送历史
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_110" Checked="false" runat="server" ToolTip="AB0B72FA-CAD3-4280-835C-74E2796C16C3"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信接口设置
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_111" Checked="false" runat="server" ToolTip="4DEF0AAA-5A9C-4E42-B873-5E879FFC68C4"
                                        class="checksub" onclick="cancelcheck('26',this.checked,'102-103-104-105-106-107-108-109-110-111-311')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    短信发送设置
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_27" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('112-113-1016',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    搜索引擎优化
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_112" Checked="false" runat="server" ToolTip="8C4F57F4-FAAD-4649-9005-3119A626C1C4"
                                        class="checksub" onclick="cancelcheck('27',this.checked,'112-113-1016')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    SEO设置
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_113" Checked="false" runat="server" ToolTip="B13DD025-0D22-4616-BF32-DB5BB8848CDC"
                                        class="checksub" onclick="cancelcheck('27',this.checked,'112-113-1016')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    SEO操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1016" Checked="false" runat="server" ToolTip="C81D9C03-9FE4-4874-8E2A-D1A3DD97CEFB"
                                        class="checksub" onclick="cancelcheck('27',this.checked,'112-113-1016')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    Robots设置
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_28" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('114',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    站点地图
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_114" Checked="false" runat="server" ToolTip="A7E7CF92-F5AB-4E6B-B197-E222FB2D1FF5"
                                        class="checksub" onclick="cancelcheck('28',this.checked,'114')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    站点地图
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_29" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('115-116-1017',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    调查列表
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_115" Checked="false" runat="server" ToolTip="63CA32A2-F6D0-451E-989F-4C4F3207A7AE"
                                        class="checksub" onclick="cancelcheck('29',this.checked,'115-116-1017')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    调查列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_116" Checked="false" runat="server" ToolTip="156C3804-EA10-4DCA-9EDA-950227C27DF0"
                                        class="checksub" onclick="cancelcheck('29',this.checked,'115-116-1017')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    添加和编辑
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1017" Checked="false" runat="server" ToolTip="861CB534-D080-4139-A6C9-63793D370C96"
                                        class="checksub" onclick="cancelcheck('29',this.checked,'115-116-1017')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    新增调查项
                                </td>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_30" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('117-118-119-120-121-308',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    文章管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_117" Checked="false" runat="server" ToolTip="DC823C51-51C9-4842-91A6-1C9461F798CF"
                                        class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-308')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    平台文章分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_118" Checked="false" runat="server" ToolTip="CEFE3B24-0E06-44FB-BF34-DC006725866D"
                                        class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-308')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    文章分类操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_119" Checked="false" runat="server" ToolTip="50264A2D-2085-4A08-A07D-F03871D90D6C"
                                        class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-308')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    平台文章列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_120" Checked="false" runat="server" ToolTip="04C589BE-F879-4450-A32E-0F3D34794D5B"
                                        class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-308')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    文章操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_121" Checked="false" runat="server" ToolTip="4569E861-2DDB-49FA-ADFE-3A51FB93D24A"
                                        class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-308')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    平台文章评论列表
                                </td>
                                <%--<td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_122" Checked="false"  runat="server" ToolTip="F9815CF1-F680-44F5-892F-82D04D29D578" class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-122-308')"/>
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    店铺文章评论列表
                                </td>--%>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_308" Checked="false" runat="server" ToolTip="76F3ABAF-54AA-4D3F-92D1-E02851128CD5"
                                        class="checksub" onclick="cancelcheck('30',this.checked,'117-118-119-120-121-308')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    资讯评论详细
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_58" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('203-204-205-206-207',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    视频管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_203" Checked="false" runat="server" ToolTip="0317C4B2-17F9-453C-B409-D12F13C2D5E0"
                                        class="checksub" onclick="cancelcheck('58',this.checked,'203-204-205-206-207')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    视频分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_204" Checked="false" runat="server" ToolTip="D226284E-24A6-47F4-BA1B-C0AE7D973B07"
                                        class="checksub" onclick="cancelcheck('58',this.checked,'203-204-205-206-207')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    视频分类增加编辑
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_205" Checked="false" runat="server" ToolTip="55E918B4-9E3D-46E7-8340-67491782FD56"
                                        class="checksub" onclick="cancelcheck('58',this.checked,'203-204-205-206-207')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    视频列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_206" Checked="false" runat="server" ToolTip="EC33732E-7652-4467-B8AE-DDFAD5E0A0DE"
                                        class="checksub" onclick="cancelcheck('58',this.checked,'203-204-205-206-207')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    视频增加编辑
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_207" Checked="false" runat="server" ToolTip="187C5AE3-FE6C-431C-98FE-0BECE89636C0"
                                        class="checksub" onclick="cancelcheck('58',this.checked,'203-204-205-206-207')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    视频评论列表
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_31" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('123-124-125-126',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    附件管理
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_123" Checked="false" runat="server" ToolTip="A34605B4-B420-4FF9-B024-6FB26B3D5D17"
                                        class="checksub" onclick="cancelcheck('31',this.checked,'123-124-125-126')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    附件列表
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_124" Checked="false" runat="server" ToolTip="C38377E5-BE58-4A9E-A2F6-E4C8C5BE3C8F"
                                        class="checksub" onclick="cancelcheck('31',this.checked,'123-124-125-126')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    附件操作
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_125" Checked="false" runat="server" ToolTip="785F3AC4-5C3E-46C8-8F9D-9A402760DF31"
                                        class="checksub" onclick="cancelcheck('31',this.checked,'123-124-125-126')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    附件分类
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_126" Checked="false" runat="server" ToolTip="E072E781-95DD-4382-94D5-54186C562FCC"
                                        class="checksub" onclick="cancelcheck('31',this.checked,'123-124-125-126')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    附件分类操作
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_32" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('127-128',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    友情链接
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_127" Checked="false" runat="server" ToolTip="D724331E-7FFC-4765-8E4E-1DBBAE5739E0"
                                        class="checksub" onclick="cancelcheck('32',this.checked,'127-128')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    友情链接
                                </td>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_128" Checked="false" runat="server" ToolTip="33371F92-BE32-481A-966E-B2CF9024224C"
                                        class="checksub" onclick="cancelcheck('32',this.checked,'127-128')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    友情链接操作
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="lmf_huaguo">
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="parent_33" Checked="false" Text="" runat="server" class="checktop"
                                        onclick="funcheck('1928',this.checked)" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    网站推广
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="left" valign="top">
                        <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                            <tr>
                                <td align="left" valign="top" class="lmf_xzk1">
                                    <asp:CheckBox ID="check_sub_1928" Checked="false" runat="server" ToolTip="18492EB7-9D52-442C-9EDC-A4C78F01B8AD"
                                        class="checksub" onclick="cancelcheck('33',this.checked,'129')" />
                                </td>
                                <td align="left" valign="top" class="lmf_txt1">
                                    网站推广
                                </td>
                            </tr>
                        </table>
                    </td>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_1000" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1018-1019-1020-1021-1022-1023',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包商城
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1018" Checked="false" runat="server" ToolTip="CD355F47-7AEC-4823-A9D1-69324BB03E11"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1018-1019-1020-1021-1022-1023')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包商品分类
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1019" Checked="false" runat="server" ToolTip="5EB108A5-D598-4495-A389-69768B3FC79D"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1018-1019-1020-1021-1022-1023')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包商品分类操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1020" Checked="false" runat="server" ToolTip="E360DAF7-98D9-42B7-A291-47308CFA94AA"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1018-1019-1020-1021-1022-1023')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包商品列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1021" Checked="false" runat="server" ToolTip="89E75D95-8CA3-48EF-B316-B46E0368CF34"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1018-1019-1020-1021-1022-1023')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包订单列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1022" Checked="false" runat="server" ToolTip="AC6EAFD9-243A-4427-BDB2-4224EE21D98B"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1018-1019-1020-1021-1022-1023')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包商品审核
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1023" Checked="false" runat="server" ToolTip="8CE3B08B-6662-45CF-969F-36859BB9C828"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1018-1019-1020-1021-1022-1023')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        红包商品审核详细和红包商品详细
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_1001" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1024-1025-1026-1027-1028-1029-1030-1031',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        促销活动
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1024" Checked="false" runat="server" ToolTip="F78594C2-0036-4DC3-9E6E-B99847AF9E7C"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        团购活动
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1025" Checked="false" runat="server" ToolTip="625A252B-0127-47D6-B15A-08C7A9AE3559"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        团购添加
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1026" Checked="false" runat="server" ToolTip="00C36503-DA0C-4913-AEEB-4E3C821C4189"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        团购管理
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1027" Checked="false" runat="server" ToolTip="7B76F02E-DCD8-4678-A42C-31E9E7FBF225"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        限时折扣
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1028" Checked="false" runat="server" ToolTip="4036B6CD-51C1-4327-8998-ACF7DE92963B"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        限时折扣查看
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1029" Checked="false" runat="server" ToolTip="32F79FEC-A277-4F18-8071-DA8F5B5DC2CA"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        直通车商品列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1030" Checked="false" runat="server" ToolTip="171F2D2F-B983-49CB-A906-07E110AE0F9C"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        直通车审核列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1031" Checked="false" runat="server" ToolTip="8F682E7B-09E4-467C-9367-7F837DE9DA66"
                                            class="checksub" onclick="cancelcheck('1000',this.checked,'1024-1025-1026-1027-1028-1029-1030-1031')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        直通车审核查看
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            财务管理
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_34" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('130-1032',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        会员充值
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_130" Checked="false" runat="server" ToolTip="46748A4D-DE75-48C4-8F53-96450FB5DBD4"
                                            class="checksub" onclick="cancelcheck('34',this.checked,'130-1032')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        会员充值
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox5" Checked="false" runat="server" ToolTip="9DB416F8-4E80-42C2-9545-F6B987230E97"
                                            class="checksub" onclick="cancelcheck('34',this.checked,'130-1032')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        ETH充值列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1032" Checked="false" runat="server" ToolTip="62EFBD27-067F-4EF6-9815-FCC850EDF727"
                                            class="checksub" onclick="cancelcheck('34',this.checked,'130-1032')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        会员充值操作
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_35" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('131-1700',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        提现管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_131" Checked="false" runat="server" ToolTip="A884921D-71A2-4CB7-AE52-7FD2A535F96B"
                                            class="checksub" onclick="cancelcheck('35',this.checked,'131-1700')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        提现管理
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox6" Checked="false" runat="server" ToolTip="1B6D9650-A452-4621-810A-E1147178C7B8"
                                            class="checksub" onclick="cancelcheck('35',this.checked,'131-1700')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        财务提现
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1700" Checked="false" runat="server" ToolTip="B75D198F-ADCB-4722-91AB-E20813548AAC"
                                            class="checksub" onclick="cancelcheck('35',this.checked,'131-1700')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        提现操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox7" Checked="false" runat="server" ToolTip="9DB416F8-4E80-42C2-9545-F6B987230E98"
                                            class="checksub" onclick="cancelcheck('35',this.checked,'131-1800')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        提现NEC币管理
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox8" Checked="false" runat="server" ToolTip="9DB416F8-4E80-42C2-9545-F6B987230E90"
                                            class="checksub" onclick="cancelcheck('35',this.checked,'131-1900')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        财务NEC币提现
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_1002" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1033',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        转账管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1033" Checked="false" runat="server" ToolTip="16A3736C-6561-44E1-807F-2E5286375C48"
                                            class="checksub" onclick="cancelcheck('1002',this.checked,'1033')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        会员转账列表
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_36" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1050-1051-132-133-2016-2017',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        金币（BV）管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1050" Checked="false" runat="server" ToolTip="D007820D-FCC8-4B8E-B27E-EE86E058F1C7"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        兑换额（PV）统计列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1051" Checked="false" runat="server" ToolTip="FD048DCB-E64C-4A5D-992F-65C0921C277D"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        金币（BV）统计列表导出
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_132" Checked="false" runat="server" ToolTip="2B1B9C06-2554-4CFD-BC1E-931D58AE8BE6"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        金币（BV）操作日志
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_133" Checked="false" runat="server" ToolTip="57441460-1365-4E72-8C2A-99F33360C82F"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        金币（BV）解/冻日志
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox1" Checked="false" runat="server" ToolTip="555B494D-7E52-4798-932D-FC439BA4FD72"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        结算列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox2" Checked="false" runat="server" ToolTip="A7211D88-415F-4C9D-9C13-8A00935FD42D"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        结算操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox_1332" Checked="false" runat="server" ToolTip="0C8FFE48-3C95-4328-B824-8F7D996E062B"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        每日资金统计
                                    </td>
                                     <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox4444" Checked="false" runat="server" ToolTip="0C8FFE48-3C95-4444-B824-8F7D996E062B"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        黑名单
                                    </td>
                                      <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="CheckBox4455" Checked="false" runat="server" ToolTip="0C8FFE48-3C95-4455-B824-8F7D996E062B"
                                            class="checksub" onclick="cancelcheck('36',this.checked,'1050-1051-132-133-2016-2017-1332')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        新每日资金统计
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <%--<tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_2015" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('2016-2017',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        结算管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_2016" Checked="false" runat="server" ToolTip="555B494D-7E52-4798-932D-FC439BA4FD72"
                                            class="checksub" onclick="cancelcheck('2015',this.checked,'2016-2017')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        结算列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_2017" Checked="false" runat="server" ToolTip="A7211D88-415F-4C9D-9C13-8A00935FD42D"
                                            class="checksub" onclick="cancelcheck('2015',this.checked,'2016-2017')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        结算操作
                                    </td>
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>--%>

                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            供求系统
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_37" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('134-1034-135-136-137-1035',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_134" Checked="false" runat="server" ToolTip="8573B1A1-14C9-4444-A591-CBBACAEF57C6"
                                            class="checksub" onclick="cancelcheck('37',this.checked,'134-1034-135-136-137-1035')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求信息
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1034" Checked="false" runat="server" ToolTip="5AA848FA-607D-4D66-8AE1-555245FED6FD"
                                            class="checksub" onclick="cancelcheck('37',this.checked,'134-1034-135-136-137-1035')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求信息查看
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_135" Checked="false" runat="server" ToolTip="142A7334-36FC-47C0-BCCD-6249811F4FB3"
                                            class="checksub" onclick="cancelcheck('37',this.checked,'134-1034-135-136-137-1035')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求分类
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_136" Checked="false" runat="server" ToolTip="62A6A817-FAA0-4593-8686-A69E1E686B44"
                                            class="checksub" onclick="cancelcheck('37',this.checked,'134-1034-135-136-137-1035')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求分类操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_137" Checked="false" runat="server" ToolTip="50C9DD9D-8106-4255-9FD5-29DC37111EB5"
                                            class="checksub" onclick="cancelcheck('37',this.checked,'134-1034-135-136-137-1035')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求评论列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1035" Checked="false" runat="server" ToolTip="320DFB4F-9FB7-4AFE-B8D7-B013DCC3AA24"
                                            class="checksub" onclick="cancelcheck('37',this.checked,'134-1034-135-136-137-1035')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求评论查看
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_38" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('138-139-1037',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求审核
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_138" Checked="false" runat="server" ToolTip="3AC50792-3F64-4992-9605-4C8DBBFCCDCE"
                                            class="checksub" onclick="cancelcheck('38',this.checked,'138-139-1037')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求信息审核
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_139" Checked="false" runat="server" ToolTip="3822DD0E-E5FD-4326-B311-6D9BAE6D82C2"
                                            class="checksub" onclick="cancelcheck('38',this.checked,'138-139-1037')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求评论审核
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1037" Checked="false" runat="server" ToolTip="320DFB4F-9FB7-4AFE-B8D7-B013DCC3AA24"
                                            class="checksub" onclick="cancelcheck('38',this.checked,'138-139-1037')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        供求评论审核查看
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            网站装修
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_100" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('315-316',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        模版管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_315" Checked="false" runat="server" ToolTip="7320D85F-0054-4795-81B2-DD059FA733CF"
                                            class="checksub" onclick="cancelcheck('100',this.checked,'315-316')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        模版备份
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_316" Checked="false" runat="server" ToolTip="6FE31AC5-7371-4441-9C44-E2CB899A4B0C"
                                            class="checksub" onclick="cancelcheck('100',this.checked,'315-316')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        模块选择
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_499" Checked="false" runat="server" class="checktop" onclick="funcheck('1830-350-1832-1038-1831-1839',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        广告管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1830" Checked="false" runat="server" ToolTip="3D059C41-93D2-48CF-B69B-566164E58C4F"
                                            class="checksub" onclick="cancelcheck('499',this.checked,'1830-350-1832-1038-1831-1839')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        广告位列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_350" Checked="false" runat="server" ToolTip="5212519A-5F83-4D91-9C16-B8475C919A00"
                                            class="checksub" onclick="cancelcheck('499',this.checked,'1830-350-1832-1038-1831-1839')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        广告位列表编辑
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1832" Checked="false" runat="server" ToolTip="6E0F91F0-A09E-4967-BD03-7BEA6BD76FB0"
                                            class="checksub" onclick="cancelcheck('499',this.checked,'1830-350-1832-1038-1831-1839')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        广告列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1038" Checked="false" runat="server" ToolTip="5880887D-46F7-44CE-8232-E1D7ACE0C523"
                                            class="checksub" onclick="cancelcheck('499',this.checked,'1830-350-1832-1038-1831-1839')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        广告列表编辑
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1831" Checked="false" runat="server" ToolTip="678E4A6D-E4E9-4A55-A793-EC01F63A4E8C"
                                            class="checksub" onclick="cancelcheck('499',this.checked,'1830-350-1832-1038-1831-1839')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        图片广告列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1839" Checked="false" runat="server" ToolTip="BEBF05E3-6841-49F2-9442-A53C93D4CD6E"
                                            class="checksub" onclick="cancelcheck('499',this.checked,'1830-350-1832-1038-1831-1839')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        图片广告列表编辑
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_49" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('182-183-1800-1801',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        模块管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_182" Checked="false" runat="server" ToolTip="4D84392B-F163-4F54-B1B6-DBEC2B703E7B"
                                            class="checksub" onclick="cancelcheck('49',this.checked,'182-183-1800-1801')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        模块列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_183" Checked="false" runat="server" ToolTip="DE123B63-9C60-43E0-A31F-3185C9C2837D"
                                            class="checksub" onclick="cancelcheck('49',this.checked,'182-183-1800-1801')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        模块列表编辑
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1800" Checked="false" runat="server" ToolTip="E28D291C-4D1F-4818-9812-ECEB5C62673A"
                                            class="checksub" onclick="cancelcheck('49',this.checked,'182-183-1800-1801')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        管理控件
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1801" Checked="false" runat="server" ToolTip="DFB6A260-F8DC-47CC-9E50-75C7E2061A24"
                                            class="checksub" onclick="cancelcheck('49',this.checked,'182-183-1800-1801')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        管理控件模块添加
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_50" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('184-185',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        栏目列表
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_184" Checked="false" runat="server" ToolTip="601D997A-43BE-4D46-B464-E04F01E533E7"
                                            class="checksub" onclick="cancelcheck('50',this.checked,'184-185')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        栏目列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_185" Checked="false" runat="server" ToolTip="36362023-0524-4BAA-8CB8-03B5A4910D6D"
                                            class="checksub" onclick="cancelcheck('50',this.checked,'184-185')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        栏目操作
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_51" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('186-187-188-189',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        帮助管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_186" Checked="false" runat="server" ToolTip="86BC19F3-F401-4351-AA33-9FB98FAC55AC"
                                            class="checksub" onclick="cancelcheck('51',this.checked,'186-187-188-189')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        帮助列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_187" Checked="false" runat="server" ToolTip="6A1A827E-34A5-4837-BC4E-4179A9B2F56B"
                                            class="checksub" onclick="cancelcheck('51',this.checked,'186-187-188-189')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        帮助操作页
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_188" Checked="false" runat="server" ToolTip="7EDEF0DA-CC09-41CF-8EA1-6B417CA33CEF"
                                            class="checksub" onclick="cancelcheck('51',this.checked,'186-187-188-189')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        帮助分类
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_189" Checked="false" runat="server" ToolTip="37628FA3-71F3-411B-A1CB-BB7D6CA08789"
                                            class="checksub" onclick="cancelcheck('51',this.checked,'186-187-188-189')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        帮助类别操作
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_52" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('190-191-192-193',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        公告管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_190" Checked="false" runat="server" ToolTip="928D9AAF-4439-4717-8228-9E183F5CF74B"
                                            class="checksub" onclick="cancelcheck('52',this.checked,'190-191-192-193')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        公告列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_191" Checked="false" runat="server" ToolTip="4C6C7B1C-3690-4655-B385-3A8C242D6549"
                                            class="checksub" onclick="cancelcheck('52',this.checked,'190-191-192-193')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        公告操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_192" Checked="false" runat="server" ToolTip="B43AED38-DC61-4034-A405-2B379403707B"
                                            class="checksub" onclick="cancelcheck('52',this.checked,'190-191-192-193')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        公告分类
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_193" Checked="false" runat="server" ToolTip="F0D4FD58-CEDE-4854-A361-28FDFFAD7215"
                                            class="checksub" onclick="cancelcheck('52',this.checked,'190-191-192-193')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        公告分类操作
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_1004" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1840-1841',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        关键字管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1840" Checked="false" runat="server" ToolTip="B73E250C-DE64-45F6-98B5-5D45FD1982DF"
                                            class="checksub" onclick="cancelcheck('1004',this.checked,'1840-1841')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        关键字列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1841" Checked="false" runat="server" ToolTip="FB631DF7-B4E4-48DB-822B-0F99A374B325"
                                            class="checksub" onclick="cancelcheck('1004',this.checked,'1840-1841')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        关键字操作
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_5200" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1900',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        招商管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1900" Checked="false" runat="server" ToolTip="4EB2936C-072E-4771-BC1D-DAA0F8986CE6"
                                            class="checksub" onclick="cancelcheck('5200',this.checked,'1900')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        招商管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            运营统计
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                    <tr class="lmf_huaguo" style="display: none">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_53" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('194',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        访问统计
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_194" Checked="false" runat="server" ToolTip="" class="checksub"
                                            onclick="cancelcheck('53',this.checked,'194')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        访问统计
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_55" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('195-196-197-198-351-352-353-354',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        销售统计
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_195" Checked="false" runat="server" ToolTip="76BABC7F-26C3-495D-8BDA-C78F5C5FED5A"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        访问购买率报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_351" Checked="false" runat="server" ToolTip="17D8BF80-711C-4CE2-9C9F-F5F98365F5E6"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        访问购买率报表导出EXCEL和导出html
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_196" Checked="false" runat="server" ToolTip="C2657733-F23D-4058-8CF9-E08692746A19"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        商品销售排行报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_352" Checked="false" runat="server" ToolTip="62A3799D-ECD3-4439-BF49-E6FFA0E56BD7"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        商品销售排行报表导出EXCEL和导出html
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_197" Checked="false" runat="server" ToolTip="BCDBC6CB-788E-4F14-A604-B858B8F0E0C0"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        商品销售明细报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_353" Checked="false" runat="server" ToolTip="F3F503F6-FD53-4961-A910-03060F7990CD"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        商品销售明细报表导出EXCEL和导出html
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_198" Checked="false" runat="server" ToolTip="953AD5C9-E649-4CA6-9957-D86B31C9D18A"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        支付方式统计报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_354" Checked="false" runat="server" ToolTip="D431BDDE-6372-42B1-89B5-E439C19B587D"
                                            class="checksub" onclick="cancelcheck('55',this.checked,'195-196-197-198-351-352')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        支付方式统计报表导出EXCEL和导出html
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_56" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('199-200-355-1843-1844',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        店铺统计
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_199" Checked="false" runat="server" ToolTip="E81CACE4-A542-414E-853D-E442542BF3EA"
                                            class="checksub" onclick="cancelcheck('56',this.checked,'199-200-355-1843-1844')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        店铺访问排行报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_355" Checked="false" runat="server" ToolTip="EF4DCB09-99F9-43D1-A9ED-9200EFD611E3"
                                            class="checksub" onclick="cancelcheck('56',this.checked,'199-200-355-1843-1844')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        店铺访问排行报表导出EXCEL和导出html
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_200" Checked="false" runat="server" ToolTip="B390DA9B-503F-4C6D-9E1B-572DC7D634F4"
                                            class="checksub" onclick="cancelcheck('56',this.checked,'199-200-355-1843-1844')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        店铺区域分布
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1843" Checked="false" runat="server" ToolTip="67F9A00E-041C-4E33-B7FA-BE8461E85B1A"
                                            class="checksub" onclick="cancelcheck('56',this.checked,'199-200-355-1843-1844')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        店铺销售额统计
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1844" Checked="false" runat="server" ToolTip="6999C969-EE1E-4049-BAC2-2E31FC9AF0C9"
                                            class="checksub" onclick="cancelcheck('56',this.checked,'199-200-355-1843-1844')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        店铺销售额统计导出EXCEL和导出html
                                    </td>
                                </tr>
                            </table>
                            <tr class="lmf_huaguo">
                                <td align="left" valign="top">
                                    <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                        <tr>
                                            <td align="left" valign="top" class="lmf_xzk1">
                                                <asp:CheckBox ID="parent_1005" Checked="false" Text="" runat="server" class="checktop"
                                                    onclick="funcheck('1845',this.checked)" />
                                            </td>
                                            <td align="left" valign="top" class="lmf_txt1">
                                                会员统计
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top">
                                    <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                        <tr>
                                            <td align="left" valign="top" class="lmf_xzk1">
                                                <asp:CheckBox ID="check_sub_1845" Checked="false" runat="server" ToolTip="7CC2A92B-4CC6-480A-BCB4-F027AF8D1EDB"
                                                    class="checksub" onclick="cancelcheck('1005',this.checked,'1845')" />
                                            </td>
                                            <td align="left" valign="top" class="lmf_txt1">
                                                会员区域分布图
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            系统集群
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_57" Checked="false" runat="server" ToolTip="" class="checktop"
                                            onclick="funcheck('201-202',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        站群管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_201" Checked="false" runat="server" ToolTip="4DE4458E-A0A1-4A18-B554-D6846FC8654E"
                                            class="checksub" onclick="cancelcheck('57',this.checked,'201-202')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        站群列表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_202" Checked="false" runat="server" ToolTip="FE7D0F2E-C494-43E8-9A6B-8E1ED0BACCC5"
                                            class="checksub" onclick="cancelcheck('57',this.checked,'201-202')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        站点添加
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            系统配置
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_21" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('80-801-82-83-851-84-85',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        权限管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_80" Checked="false" runat="server" ToolTip="ABCA1129-D2CB-4A76-BFAF-6139B7DA4BB9"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        用户管理
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_801" Checked="false" runat="server" ToolTip="B4307848-725D-47BF-8FC9-321341683C69"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        用户管理操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_82" Checked="false" runat="server" ToolTip="0DA35471-E977-4764-88D2-96C8F791FE2A"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        角色组管理
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_83" Checked="false" runat="server" ToolTip="B2243B93-8A60-471C-8383-AFF9DC43119E"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        角色组管理操作
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_851" Checked="false" runat="server" ToolTip="A71D4E2B-A6C0-4821-AEA5-6F5555496360"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        权限设置
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_84" Checked="false" runat="server" ToolTip="83E944FC-FC1C-4D98-9177-E03D2D142F98"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        系统操作日志
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_85" Checked="false" runat="server" ToolTip="B58CBB16-DC00-4A27-9748-60DD68A3B69A"
                                            class="checksub" onclick="cancelcheck('21',this.checked,'80-801-82-83-851-84-85')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        修改密码
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_22" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('86-87',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        数据管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_86" Checked="false" runat="server" ToolTip="14995C97-1626-472D-8B7E-6ADF58707829"
                                            class="checksub" onclick="cancelcheck('22',this.checked,'86-87')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        数据备份/恢复
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_87" Checked="false" runat="server" ToolTip="E706FBAD-F99A-4358-ABDF-3D8C98D2AD64"
                                            class="checksub" onclick="cancelcheck('22',this.checked,'86-87')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        清除体验数据
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_23" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('88-89',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        敏感字设置
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_88" Checked="false" runat="server" ToolTip="4EE3E423-F4F1-45D6-B34C-CE23ADBB694B"
                                            class="checksub" onclick="cancelcheck('23',this.checked,'88-89')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        敏感字设置
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_89" Checked="false" runat="server" ToolTip="6B1C90DE-08BB-4C99-B8AA-2E0B8686B727"
                                            class="checksub" onclick="cancelcheck('23',this.checked,'88-89')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        敏感字操作页
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_24" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('9099',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        网站优化
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_9099" Checked="false" runat="server" ToolTip="6EE89DE3-FE99-4B6B-BFB4-65985489441A"
                                            class="checksub" onclick="cancelcheck('24',this.checked,'9099')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        更新缓存
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr class="lmf_huaguo" style="background: #ebeef4;">
                        <td align="left" valign="top" style="background: #ebeef4; color: #4482B4; font-weight: bold;
                            padding-left: 30px; width: 180px;">
                            生成报表
                        </td>
                        <td align="left" valign="top" style="background: #ebeef4;">
                        </td>
                    </tr>
                   <tr class="lmf_huaguo">
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk1">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="parent_1234" Checked="false" Text="" runat="server" class="checktop"
                                            onclick="funcheck('1824-1625-1726-1327-1028-1729-1230-1191',this.checked)" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        生成管理
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="left" valign="top">
                            <table cellpadding="0" cellspacing="0" border="0" class="lmf_zmk">
                                <tr>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1235" Checked="false" runat="server" ToolTip="D0C91D6A-9BDB-4086-BB2D-3541ED9CB2BE"
                                            class="checksub" onclick="cancelcheck('1234',this.checked,'1235-1236-1237')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        订单报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1236" Checked="false" runat="server" ToolTip="5BBDD204-58E9-4F6F-A29C-B35EF9AA2B93"
                                            class="checksub" onclick="cancelcheck('1234',this.checked,'1235-1236-1237')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                        发货报表
                                    </td>
                                    <td align="left" valign="top" class="lmf_xzk1">
                                        <asp:CheckBox ID="check_sub_1237" Checked="false" runat="server" ToolTip="3659EE7D-CAB6-4951-B5A5-7AE9BA727892"
                                            class="checksub" onclick="cancelcheck('1234',this.checked,'1235-1236-1237')" />
                                    </td>
                                    <td align="left" valign="top" class="lmf_txt1">
                                      销量报表
                                    </td>
                                    
                                    
                                </tr>
                            </table>
                        </td>
                    </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="Button2" runat="server" Text="确定" CssClass="fanh" OnClick="Button2_Click"
                    ToolTip="Submit" />
                <asp:Button ID="Button1" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/Group_List.aspx" Text="返回列表" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
