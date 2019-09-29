<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ProuductSpellBuy_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ProuductSpellBuy_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主平台-商品团购列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript" language="javascript">
        function checkprice(name) {
            var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
            if (!oo.test(name)) {
                return false;
            } else {
                return true;
            }
        }

        $(function () {
            $("#SearchSub").click(function () {
                var bflag = true;
                if ($("#txtSprice").val() != "") {
                    bflag = checkprice($("#txtSprice").val());
                }
                if ($("#txtEprice").val() != "") {
                    bflag = checkprice($("#txtEprice").val());
                }
                if (bflag) {
                    location.href = "ProuductSpellBuy_List.aspx?pname=" + $("#txtName").val() + "&sname=" + $("#txtSname").val() + "&sp=" + $("#txtSprice").val() + "&ep=" + $("#txtEprice").val() + "";
                } else {
                    alert("价格不合法!");
                }
            });
        });
    </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="left: -1000px; position: absolute; top: 377px; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    团购商品列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            商品名称：
                        </td>
                        <td>
                            <input type="text" class="tinput" id="txtName" style="width: 200px" value='<%= Common.ReqStr("pname") %>' />
                        </td>
                        <td class="lmf_padding">
                            店铺名称：
                        </td>
                        <td>
                            <input type="text" class="tinput" id="txtSname" style="width: 200px" value='<%= Common.ReqStr("sname") %>' />
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            价格范围：
                        </td>
                        <td colspan="5">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <input type="text" id="txtSprice" class="tinput" style="width: 58px" value='<%= Common.ReqStr("sp") %>' />
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <input type="text" id="txtEprice" class="tinput" style="width: 58px" value='<%= Common.ReqStr("ep") %>' />
                                    </td>
                                    <td>
                                        <input type="button" class="dele" id="SearchSub" value="查询" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                    OnClientClick=" return DeleteButton() "><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <table cellspacing="0" cellpadding="4" border="0" id="Num1GridViewShow" rules="cols"
                class="gridview_m">
                <thead>
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col" class="select_width">
                            <input type="checkbox" onclick=" javascript:SelectAllCheckboxesNew(this); " id="checkbox1">
                        </th>
                        <th scope="col">
                            商品名称
                        </th>
                        <th scope="col">
                            商品图片
                        </th>
                        <th scope="col">
                            商品价格
                        </th>
                        <th scope="col">
                            店铺名称
                        </th>
                        <th scope="col">
                            开始时间
                        </th>
                        <th scope="col">
                            结束时间
                        </th>
                        <th scope="col">
                            团购数
                        </th>
                        <th scope="col">
                            库存
                        </th>
                        <th scope="col">
                            操作
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% if (dt != null)
                       {
                           for (int i = 0; i < dt.Rows.Count; i++)
                           {
                    %>
                    <!--循环代码-->
                    <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                        <td align="center" style="">
                            <input type="checkbox" value="<%= dt.Rows[i]["id"] %>" name="subcheck">
                        </td>
                        <td align="center">
                            <a href='<%= ShopUrlOperate.shopDetailHrefByShopID(dt.Rows[i]["id"].ToString(), dt.Rows[i]["shopid"].ToString(), "ProductIsSpell_Detail") %>'
                                target="_blank">
                                <%= Utils.GetUnicodeSubString(dt.Rows[i]["pname"].ToString(), 35, "") %>
                            </a>
                        </td>
                        <td align="center">
                            <a href='<%= ShopUrlOperate.shopDetailHrefByShopID(dt.Rows[i]["id"].ToString(), dt.Rows[i]["shopid"].ToString(), "ProductIsSpell_Detail") %>'
                                target="_blank">
                                <img src='<%= dt.Rows[i]["groupsmallimg"] %> ' onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%= dt.Rows[i]["groupimg"] %> >', '#ffffff'); "
                                    onmouseout=" hideddrivetip() " height="20" width="20" />
                            </a>
                        </td>
                        <td align="center">
                            <%= dt.Rows[i]["groupprice"] %>
                        </td>
                        <td align="center">
                            <a href='<%= ShopUrlOperate.GetShopUrl(dt.Rows[i]["shopid"].ToString()) %>' target="_blank">
                                <%= dt.Rows[i]["shopNAME"] %></a>
                        </td>
                        <td align="center">
                            <%= dt.Rows[i]["starttime"] %>
                        </td>
                        <td align="center">
                            <%= dt.Rows[i]["endtime"] %>
                        </td>
                        <td align="center">
                            <%= dt.Rows[i]["groupcount"] %>
                        </td>
                        <td align="center">
                            <%= dt.Rows[i]["groupstock"] %>
                        </td>
                        <td align="center">
                            <span onclick=" if (confirm('是否删除？')) {location.href = '?delete=<%= dt.Rows[i]["id"] %>';
                                                                                                                                                                                                                                                                  } ">
                                删除</span>
                        </td>
                    </tr>
                    <!--循环代码-->
                    <% }
                               }
                       else
                       {
                    %>
                    <tr>
                        <td colspan="10">
                            <center>
                                没有找到相关团购商品！</center>
                        </td>
                    </tr>
                    <% } %>
                    <tr class="lmf_page" align="right" style="background-color: #F7F7DE; color: Black;">
                        <td style="height: 30px;" colspan="10">
                            <div class="btnlist" style="overflow: auto;">
                                <div class="fnum">
                                    每页显示数量： <a href="?pagesize=10">10</a><a href="?pagesize=20">20</a><a href="?pagesize=50">50</a>
                                </div>
                                <div class="page" id="pageDiv" runat="server">
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>
