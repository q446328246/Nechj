<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopChartArea.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopChartArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">

        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type='text/javascript' src='js/resolution-test.js'> </script>
     
   
        <title>店铺分布图</title>
        <style type="text/css">
            .navigator {
                border-bottom: 1px solid #e1e1e1;
                color: #000000;
                font-size: 12px;
                font-weight: bold;
                height: 28px;
                line-height: 20px;
                margin: 10px 0;
                padding-left: 10px;
            }
        </style>
    </head>
    <body class="widthah">
        <form id="form1" runat="server">
            <div id="right"  >
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            店铺分布图</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix"  style="height: 500px;">

                    <TABLE cellSpacing=0 cellPadding=0 width=800 align=center border=0 style="padding-left: 30px;">
                        <TBODY>
                            <TR> 
                                <TD  align="center" bgColor=#ffffff>  <OBJECT classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"  codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" WIDTH="750" HEIGHT="400" ALIGN="middle">
                                                                          <PARAM NAME="FlashVars" value="&dataXML=<graph caption='店铺在各大地区分布图' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' showValues='1' showPercentageInLabel='0' pieYScale='45' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='15' pieRadius='100' outCnvBaseFontSize='13' baseFontSize='12'">
<%

    int j = AreaTable.Rows.Count;
    for (int i = 0; i < j; ++i)
    {
        int id = i;
        string color = "";
        if (id%4 == 0)
            color = "FFCC33";
        else if (id%4 == 1)
            color = "33FF66";
        else if (id%4 == 2)
            color = "FF6600";
        else if (id%4 == 3)
            color = "CC3399";
%>
<set value='<%= AreaTable.Rows[i]["shopcount"].ToString() %>' name='<%= AreaTable.Rows[i]["regionname"].ToString() %>' color='<%= color %>' />
<%
    }
%></graph>">
                                                                          <PARAM NAME="movie" VALUE="flash/column3d.swf?chartWidth=800&chartHeight=400">
                                                                          <PARAM NAME="quality" VALUE="high">
                                                                          <param name="wmode" value="opaque" />
                                                                          <PARAM NAME="bgcolor" VALUE="#FFFFFF">
                                                                          <EMBED src="flash/column3d.swf?chartWidth=800&chartHeight=400" FlashVars="&dataXML=<graph caption='店铺在各大地区分布图' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' showValues='0' showPercentageInLabel='0' pieYScale='45' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='15' pieRadius='100' outCnvBaseFontSize='13' baseFontSize='12'>
          <%

              int k = AreaTable.Rows.Count;
              for (int i = 0; i < k; ++i)
              {
                  int id = i;
                  string color = "";
                  if (id%4 == 0)
                      color = "FFCC33";
                  else if (id%4 == 1)
                      color = "33FF66";
                  else if (id%4 == 2)
                      color = "FF6600";
                  else if (id%4 == 3)
                      color = "CC3399";
          %>
                <set value='<%= AreaTable.Rows[i]["shopcount"].ToString() %>' name='<%= AreaTable.Rows[i]["regionname"].ToString() %>' color='<%= color %>' /><% } %></graph>" quality="high" bgcolor="#FFFFFF" WIDTH="750" HEIGHT="400" ALIGN="middle" TYPE="application/x-shockwave-flash" PLUGINSPAGE="http://www.macromedia.com/go/getflashplayer" wmode="opaque"></EMBED></OBJECT>
                                </TD>
                            </TR>
                        </TBODY>
                    </TABLE>

                </div>
            </div>
        
        

        </form>
    </body>
</html>