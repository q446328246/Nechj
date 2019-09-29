<%@ Page Language="C#" %>

<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>恭喜您，商品发布成功！</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="containe_bg">
        <!--头部Top-->
        <ShopNum1ShopAdmin:S_Head ID="S_Head" runat="server" SkinFilename="Skin/S_Head.ascx" />
        <!--内容部分Content-->
        <div id="content_bg">
            <div class="con_order">
                <!--步骤-->
                <div class="buzho">
                    <ul>
                        <li>
                            <img src="images/buzho01.jpg" width="317" height="51" /></li>
                        <li>
                            <img src="images/buzho02.jpg" width="388" height="51" /></li>
                        <li>
                            <img src="images/buzho03_1.jpg" width="295" height="51" /></li>
                    </ul>
                </div>
                <div class="tiscg">
                    <h1>
                        恭喜您，商品<% if (ShopNum1.Common.Common.ReqStr("op") == "edit")
                                 { %>编辑<% }
                                 else
                                 { %>发布<% } %>成功!</h1>
                    <h2>
                        <%
                            bool bflag = true;
                            if (ShopSettings.GetValue("AddProductIsAudit") != "0" && ShopNum1.Common.Common.ReqStr("pstate") == "0")
                            {
                                bflag = false; %>
                        <% }
                            else if (ShopSettings.GetValue("AddPanicBuyProductIsAudit") != "0" && ShopNum1.Common.Common.ReqStr("pstate") == "1")
                            {
                                bflag = false;
                            } %>
                        <% if (bflag)
                           { %>
                           <%
                               HttpCookie cookie = Page.Request.Cookies["MemberLoginCookie"];
                               HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
                               string MemberLoginID = cookie2.Values["MemLoginID"];

                               if (MemberLoginID== ShopNum1MultiEntity.TJShopInfo.shopId)
                               { %>
                                  <a href="<%= ShopUrlOperate.shopHref(ShopNum1.Common.Common.ReqStr("pid"), ShopNum1.Common.Common.ReqStr("shopid")) %>?category=1"
                            class="blue_xq">去店铺查看商品详情</a> >>&nbsp;&nbsp;
                              <% }
                              else{ %>
                              <a href="<%= ShopUrlOperate.shopHref_two(ShopNum1.Common.Common.ReqStr("pid"), ShopNum1.Common.Common.ReqStr("shopid"),9) %>"
                            class="blue_xq">去店铺查看商品详情</a> >>&nbsp;&nbsp;
                             <%} %> 
                              
                             
                               
                               
                        
                        <% }
                           else
                           { %>
                        <a href="S_Index.aspx?tosurl=S_UnAuditProduct.aspx" class="blue_xq">未审核商品列表</a>
                        >>&nbsp;&nbsp;
                        <% } %>
                        <a href="<%= Request.Url.ToString().Replace("_Three", "_two") %>" class="blue_xq">编辑商品</a>
                        >>
                    </h2>
                </div>
                <div class="tiscg2">
                    <p>
                        您还可以:</p>
                    <ul>
                        <li>1.继续 " <a href="S_SellGoods_One.aspx?op=add&step=one" class="blue_xq">发布新商品</a>"</li>
                        <li>2.进入 " <a href="S_Index.aspx" class="blue_xq">我是卖家</a>" 管理 "<a href="S_Index.aspx?tosurl=S_SellProduct.aspx"
                            class="blue_xq">商品列表</a>"</li>
                        <li>3.进入 " <a href="S_Index.aspx?tosurl=S_ZtcGoods_List.aspx" class="blue_xq">直通车管理</a>
                            " 选择商品添加申请</li>
                        <li>4.选择商品参加 " <a href="S_Index.aspx?tosurl=S_GroupProduct.aspx" class="blue_xq">团购活动</a>
                            "</li>
                        <%-- <li>5.参与商城的 " <a href="S_Index.aspx" class="blue_xq" >专题活动</a> "</li>--%>
                    </ul>
                </div>
            </div>
            <!--页面底部Bottom-->
            <div style="clear: both;">
            </div>
            <!--页面底部Bottom-->
            <ShopNum1ShopAdmin:S_Bottom ID="S_Bottom" runat="server" SkinFilename="Skin/S_Bottom.ascx"
                class="foot_bg" />
        </div>
    </div>
    </form>
</body>
</html>
