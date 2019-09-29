<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.ShopNewWebControl" %>
<%@ Import Namespace="System.Data" %>
<% DataTable dt_Prop = ProductProp_V82.dt_Prop;
    DataTable dt_SubProp = null; %>
<script type="text/javascript" language="javascript">
        $(function(){
                if($(".ProductProp").text().trim().length<5)
                {
                      $("#ProductProp_V82 .aBox11").hide();
                }
        });
</script>
<div class="aBox11 clearfix" style="border-top:1px solid #D3D3D3;">
    <div class="content">
        <div class="ProductProp clearfix">
        <%if (dt_Prop != null)
          {
              for (int i = 0; i < dt_Prop.Rows.Count; i++)
              {
                  string strId=dt_Prop.Rows[i]["id"].ToString();
                  string strName=dt_Prop.Rows[i]["PropName"].ToString();
                  string strSt = dt_Prop.Rows[i]["showtype"].ToString();
                  %>
                      <%--  <li class="li1">
                        <%
                  if (strSt != "4" & strSt != "0")
                          { %>
                        <%=strName%>：<%} %></li>--%>
                                <%
                                    dt_SubProp = ProductProp_V82.dt_SubPropv(strId);
                                  for (int j = 0; j < dt_SubProp.Rows.Count; j++)
                                  {
                                      string strShowType = dt_SubProp.Rows[j]["showtype"].ToString();
                                      string strsubId = dt_SubProp.Rows[j]["propvalueid"].ToString();
                                      string strV = dt_SubProp.Rows[j]["InputValue"].ToString();
                                      if (strShowType == "2")//多选
                                   { %>  
                                        <div> <span class="propName"><%=strName%>:</span> <span class="propValue"><%=ProductProp_V82.GetPropValue(strsubId)%> </span></div>  
                                 <%}
                                      if (strV != "")
                                      {
                                %>
                                <!--根据不同的类型显示不同的布局-->   
                                 <%if (strShowType == "3")//多选
                                   { %>  
                                        
                                      <%=ProductProp_V82.GetPropValue(strsubId)%>
                                 <%}
                                   else if (strShowType == "1" || strShowType == "2")//单选或下拉
                                   { %>
                                        <%=ProductProp_V82.GetPropValue(strsubId)%> 
                                 <%}
                                   else if (strShowType == "0") //文本框输入
                                   { %>  
                                      <div> <span class="propName"><%=ProductProp_V82.GetPropValue(strsubId)%>：</span> <span class="propValue"><%=strV + ""%></span></div>
                                 <%}
                                   else if (strShowType == "4") //自定义属性
                                   {
                                       if (strV.IndexOf("*") != -1)
                                       {%> 
                                           <%for (int m = 0; m < strV.Split('*').Length; m++)
                                             {
                                                 if (strV.Split('*')[m].IndexOf('%') != -1)
                                                 {
                                                     if (strV.Split('*')[m].Split('%').Length > 1)
                                                     {%>
                                              <div> <span class="propName"> <%=" " + strV.Split('*')[m].Split('%')[0]%>:</span> <span class="propValue"><%=strV.Split('*')[m].Split('%')[1]%></span></div>
                                           <%}
                                                 }
                                             }%>
                                           
                                       <%}
                                       else if (strV.IndexOf("%") != -1)
                                       {
                                           if (strV.Split('%').Length > 1)
                                           {%>
                                        <div>    <span class="propName"><%=strV.Split('%')[0]%>:</span> <span class="propValue"><%=strV.Split('%')[1]%> </span></div>
                                       <%}
                                       }%>
                                 <%} %>       
                                <!--根据不同的类型显示不同的布局-->          
                                  <%}
                                  } %>
			<%}
          } %>
        </div>
    </div>
</div>
<div id="divInstrunction" runat="server"></div>
<div id="divDetials" runat="server"></div>
