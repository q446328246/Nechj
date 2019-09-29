<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Limit_Product.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Limit_Product" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>限时折扣商品</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    限时折扣商品</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table cellspacing="0" cellpadding="4" border="0" id="Num1GridViewShow" rules="cols"
                class="gridview_m">
                <thead>
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col">
                            商品名称
                        </th>
                        <th scope="col">
                            商品价格
                        </th>
                        <th scope="col">
                            商品折扣
                        </th>
                        <th scope="col" style="display: none;">
                            商品状态
                        </th>
                </thead>
                <tbody>
                    <%if (dt_Lp != null)
                      {
                          for (int i = 0; i < dt_Lp.Rows.Count; i++)
                          {
                              string strId = dt_Lp.Rows[i]["id"].ToString();
                              string strName = dt_Lp.Rows[i]["name"].ToString();
                              string strDiscount = dt_Lp.Rows[i]["discount"].ToString();
                              string strPrice = dt_Lp.Rows[i]["shopprice"].ToString();
                              string stroriginalImage = dt_Lp.Rows[i]["originalImage"].ToString();
                              string strImg = dt_Lp.Rows[i]["smallimage"].ToString();
                              string strState = dt_Lp.Rows[i]["state"].ToString();
                              string strGuid = dt_Lp.Rows[i]["guid"].ToString();
                              string strMemloginId = dt_Lp.Rows[i]["memloginid"].ToString();
                              if (strState == "1")
                                  strState = "正常";
                              else
                                  strState = "取消";
                    %>
                    <tr style="cursor: default;" onmouseout="Num1GridViewShow_mout(this)" onmouseover="Num1GridViewShow_mover(this)">
                        <td align="center">
                            <a rel="<%=stroriginalImage%>" target="_blank" href="<%=ShopUrlOperate.shopHref(strGuid,strMemloginId)%>"
                                title="<%=strName %>">
                                <img src="<%=strImg %>" style="width: 50px; height: 50px;" /><%=strName%></a>
                        </td>
                        <td align="center">
                            <%=strPrice%>
                        </td>
                        <td style="width: 100px; padding: 0px;" align="center">
                            <%=strDiscount%>
                        </td>
                        <td align="center" style="display: none;">
                            <%=strState%>
                        </td>
                    </tr>
                    <%}
                      }
                      else
                      {%>
                    <tr>
                        <td colspan="5">
                            <center>
                                您还没有添加活动商品!</center>
                        </td>
                    </tr>
                    <%}%>
                    <tr class="lmf_page" align="right" style="color: Black; background-color: #F7F7DE;">
                        <td style="height: 30px;" colspan="8">
                            <div class="btnlist" style="overflow: auto;" id="pageShow" visible="false" runat="server">
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
    <input type="hidden" id="CheckGuid" runat="server" />
    </form>
</body>
</html>
