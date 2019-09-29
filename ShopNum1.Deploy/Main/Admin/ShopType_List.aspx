<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopType_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopType_List" %>

<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>店铺分类列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
    

     <script src="js/dragbox/Shopnum1.Dialog.min.js" type="text/javascript"></script>
     <link rel="stylesheet" type="text/css" href="js/dragbox/Shopnum1.DragBox.min.css" />
     
     <link rel="stylesheet" type="text/css" href="style/Shopnum1.treelist.css" />
    
     <script type="text/javascript">
         window.onerror = function () { return true; }
         var ajaxurl = "/Api/GetTypeData.ashx";
         function treelist_two_html(id, name, orderid, isshow, issub) {
             var xhtml = '<td align="left" valign="top" colspan="3" style="padding: 0; border: 0;">';
             xhtml += '<table cellpadding="0" cellspacing="0" border="0" width="100%" class="sub_lmf">';
             xhtml += '<tr class="sublmf_huaguo" id="delete_this_' + id + '">';
             xhtml += '<td align="left" valign="top">';
             xhtml += '<div class="sublmf_jia fl" onclick="funthreesub(this,' + id + ')">';
             if (issub != "") {
                 xhtml += '<img style="border-width: 0px;" src="images/lmf_jia.jpg"/>';
             } else { xhtml += '<span style="width:13px; display:block; height:20px;">&nbsp;</span>'; }
             xhtml += '</div><div class="sublmf_xuanze fl"><input type="checkbox" value="' + id + '" onclick="treelist_subcheck(this)"  lang="c_' + id + '" class="c_p vcheck"/></div>';
             xhtml += '<div class="sublmf_paixu fl">';
             xhtml += '<input type="text" name=\"orderby\" ma value="' + orderid + '" lang="' + id + '" maxlength="8"/></div>';
             xhtml += '<div class="sublmf_titlee fl">';
             xhtml += '<input type="text" value="' + name + '" maxlength="20" /></div>';
             xhtml += '</td>';
             xhtml += '<td align="center" valign="top" width="100px">';
             if (isshow == 1) { xhtml += '<img style="border-width: 0px;" src="images/dui.jpg" onclick="treelist_isshow(this)" class="isshow" lang="' + id + '-' + isshow + '">'; }
             else { xhtml += '<img style="border-width: 0px;" src="images/cuo.jpg" onclick="treelist_isshow(this)" class="isshow" lang="' + id + '-' + isshow + '">'; }
             xhtml += '</td>';
             xhtml += '<td align="center" valign="top" width="300px">';
             xhtml += '<a class="saveedit" href="#" lang="' + id + '" style="color: #4482b4;" onclick="treelist_save(this)">保存</a>&nbsp;';
             xhtml += '<a href="#" lang="ShopType_Operate.aspx?op=edit&guid=' + id + '&width=810&height=500" onclick="treelist_edit(this,0)" class="dialog vdr" style="color: #4482b4;">编辑</a>&nbsp;';
             xhtml += '<a href="#" lang="' + id + '" class="delv" style="color: #4482b4;" onclick="treelist_delete(this)">删除</a>&nbsp;';
             xhtml += '<a href="#" lang="ShopType_Operate.aspx?op=add&guid=' + id + '&width=810&height=500" class="dialog vdr" onclick="treelist_edit(this,1)" style="color: #4482b4;">添加子分类</a>';
             xhtml += '</td>';
             xhtml += '</tr>';
             xhtml += '<tr style="display:none;" class="three" id="two_three_' + id + '"></tr>';
             return xhtml;
         }
         function treelist_three_html(id, name, orderid, isshow) {
             var xhtml = "";
             xhtml += '<tr class="subsublmf_huaguo" id="delete_this_' + id + '">';
             xhtml += '<td align="left" valign="top">';
             xhtml += '<div class="subsublmf_xuanze fl">';
             xhtml += '<input type="checkbox" value="' + id + '" class="c_t vcheck" onclick="treelist_subcheck(this)"/></div><div></div>';
             xhtml += '<div class="sublmf_paixu fl">';
             xhtml += '<input type="text" name=\"orderby\" value="' + orderid + '" lang="' + id + '" maxlength="8" /></div>';
             xhtml += '<div class="subsublmf_titlee fl">';
             xhtml += '<input type="text" value="' + name + '" maxlength="20"/></div></td>';
             xhtml += '<td align="center" valign="top" width="100px">';
             if (isshow == "1") { xhtml += '<img style="border-width: 0px;" onclick="treelist_isshow(this)" lang="' + id + '-' + isshow + '" class="isshow" src="images/dui.jpg">'; }
             else { xhtml += '<img style="border-width: 0px;" class="isshow" onclick="treelist_isshow(this)" lang="' + id + '-' + isshow + '" src="images/cuo.jpg">'; }
             xhtml += '</td><td align="center" valign="top" width="300px">';
             xhtml += '<a class="saveedit" href="#" lang="' + id + '" style="color: #4482b4;" onclick="treelist_save(this)">保存</a>&nbsp;';
             xhtml += '<a href="#" lang="ShopType_Operate.aspx?op=edit&guid=' + id + '&width=810&height=500" class="dialog vdr" onclick="treelist_edit(this,0)" style="color: #4482b4;">编辑</a>&nbsp;';
             xhtml += '<a href="#" lang="' + id + '" class="delv" style="color: #4482b4;" onclick="treelist_delete(this)">删除</a>';
             xhtml += '</td></tr>';
             return xhtml;
         }
     </script>
      <script type="text/javascript" language="javascript" src="js/Shopnum1.treelist.js"></script>
</head>

<body  class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>店铺分类列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>

        <div class="welcon clearfix">
        <div class="order_edit">
        <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td style=" border:none;"><a  href="ShopType_Operate.aspx?guid=0&width=810&height=500" class="tianjiafl lmf_btn dialog"><span>添加目录
</span></a></td>
                <td style="border:none;padding-left:10px;"><a href="#" class="guanlikj lmf_btn cporder"><span>批量保存</span></a></td>
                <td class="lmf_padding">友情提示:批量保存操作针对于勾选的商品生效</td>
                </tr>
                </table>
        </div>
           <table cellpadding="0" cellspacing="0" border="0" width="98%" class="gridview_m"
                style="margin: 0 auto; border:none;">

                <tr class="list_header">
                    <th style="text-align:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类排序&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类名称</th>
                    <th>是否在前台显示</th>
                    <th>操作</th>
                </tr>
                <%if (dataTable != null)
                  {
                      foreach (System.Data.DataRow dataRow in dataTable.Rows)
                      {%>
                           <tr class="one lmf_huaguo" id='parent_<%=dataRow["ID"]%>'>
                              <td align="left" valign="top">
                                <div class="lmf_jia fl">
                                <%  if (dataRow["v"].ToString() != ""){%>
                                    <img style="border-width: 0px;" src="images/lmf_jia.jpg" onclick='funsub(this,<%=dataRow["ID"]%>)'>
                                <%}else{%>
                                    <span style="width:13px; display:block; height:20px;">&nbsp;</span>
                                <%} %>
                                </div><div class="lmf_xuanze fl"><input type="checkbox" class="checkboxsn vcheck" onclick="checksub(this,'<%=dataRow["ID"]%>')" value='<%=dataRow["ID"]%>'/></div>
                                <div class="lmf_paixu fl"><input type="text" name="orderby" lang='<%=dataRow["orderid"]%>' value='<%=dataRow["orderid"]%>' maxlength="8" /></div>
                                <div class="lmf_titlee fl"><input type="text" value='<%=dataRow["Name"]%>' maxlength="20"/></div>
                            </td>
                            <td align="center" valign="top" width="100px">
                            <% if (dataRow["isshow"].ToString() == "1"){ %>
                                <img style="border-width: 0px;" src="images/dui.jpg" class="isshow" lang='<%=dataRow["ID"]+"-"%><%=dataRow["isshow"]%>'/>
                            <%}else{%>
                                <img style="border-width: 0px;" src="images/cuo.jpg" class="isshow" lang='<%=dataRow["ID"]+"-"%><%=dataRow["isshow"]%>'/>
                            <%} %>
                            </td>
                            <td align="center" valign="top" width="300px">
                                <a href="#" class="saveedit" style="color: #4482b4;" lang='<%=dataRow["ID"]%>' onclick="treelist_save(this)">保存</a>&nbsp;
                                <a href="ShopType_Operate.aspx?op=edit&guid=<%=dataRow["ID"]%>&width=810&height=500" class="dialog" style="color: #4482b4;">编辑</a>&nbsp;
                                <%if (dataRow["m"].ToString() == "")
                                  { %>
                                <a href="#" style="color: #4482b4;" lang='<%=dataRow["ID"]%>' class="delv" onclick="treelist_delete(this)">删除</a>&nbsp;
                                <%}%>
                                <a href='ShopType_Operate.aspx?op=add&guid=<%=dataRow["ID"]%>&width=810&height=500' class="dialog" style="color: #4482b4;">添加子分类</a>
                            </td>
                          </tr>
                           <tr style="display:none;" class="two" id='sub_two_<%=dataRow["ID"]%>'></tr>
                		<%}
                  } %>
                <tr class="lmf_page" style="background:#e8e8e8; display:none;">
                <td valign="top" align="left" style="background:#e8e8e8; padding:0 20px;" colspan="3">
                <div class="fl">
                <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td style="background:#e8e8e8; border:none;padding-left:10px;">                <a  href="ShopType_Operate.aspx?guid=0&width=810&height=500" class="tianjiafl lmf_btn dialog"><span>添加目录</span></a></td>
                <td style="background:#e8e8e8; border:none;padding-left:10px;"><a href="#" class="tianjiafl lmf_btn cporder"><span>保存排序</span></a></td>
                </tr>
                </table>
                </div>
                </td>
                </tr>
            </table>
        </div>
    </div>

   </form>
</body>
</html>
