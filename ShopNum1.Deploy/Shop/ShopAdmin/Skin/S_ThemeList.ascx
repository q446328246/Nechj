<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<link rel='stylesheet' type='text/css' href='style/dshow.css' />
<script type="text/javascript" language="javascript" src="js/dshow.js"> </script>
<% DataTable dt = S_ThemeList.dt_GroupProduct; %>
<div class="ordmain1" id="content">
    <div class="biaogenr">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tb2">
            <tr>
                <th width="35%" class="th_le">
                    活动名称
                </th>
                <th width="30%">
                    活动说明
                </th>
                <th width="10%">
                    已参与个数
                </th>
                <th width="10%">
                    活动状态
                </th>
                <th width="15%" class="th_ri">
                    操作
                </th>
            </tr>
            <!--循环代码-->
            <% if (dt != null)
               {
                   for (int i = 0; i < dt.Rows.Count; i++)
                   {
                       string strId = dt.Rows[i]["guid"].ToString();
                       string strName = dt.Rows[i]["ThemeTitle"].ToString();
                       string strDescription = dt.Rows[i]["ThemeDescription"].ToString();
                       string strStartTime = dt.Rows[i]["StartDate"].ToString();
                       string strEndTime = dt.Rows[i]["EndDate"].ToString();
                       string strState = dt.Rows[i]["ThemeStatus"].ToString();
                       string strCount = dt.Rows[i]["ct"].ToString();
                       if (Convert.ToDateTime(strStartTime) <= DateTime.Now)
                           strState = "1";
                       string strUrlEnd = "";
                       switch (strState)
                       {
                           case "0":
                               strState = "未开始";
                               break;
                           case "1":
                               strState = "进行中";
                               if (Convert.ToDateTime(strEndTime) <= DateTime.Now)
                               {
                                   strState = "已结束";
                                   strUrlEnd = "&close=true";
                               }
                               break;
                           case "2":
                               strState = "已关闭";
                               break;
                       }
                       //string strProductUrl = ShopUrlOperate.RedirectProductDetailByMemloginID(dt.Rows[i]["id"].ToString(), dt.Rows[i]["MemloginId"].ToString(), "1", "1");
            %>
            <tr>
                <td style="text-align: left;">
                    <%--<a href="<%=strProductUrl %>" target="_blank" style="float: left; display: block;">
                            <img src="<%=strGroupSmallImg %>" width="60" height="60" onerror="javascript:this,src='/ImgUpload/noImg.jpg_60x60.jpg'" /></a>--%>
                    <a href="S_ThemeProductList.aspx?ThemeGuid=<%= strId %>" style="display: block; float: left;
                        padding-left: 10px; width: 210px;">
                        <%= strName %></a>
                </td>
                <td>
                    <p mode="wrap" style="text-align: left; white-space: normal; width: 220px;">
                        <%= strDescription.Length > 100 ? strDescription.Substring(1, 100) : strDescription %></p>
                </td>
                <td>
                    <%= strCount %>
                </td>
                <td>
                    <%= strState %>
                </td>
                <td>
                    <% if (strState == "进行中")
                       { %>
                    <a style="color: #015FA7;" class="join">参与活动</a> <span style="display: none;">
                        <%= strId %></span>
                    <% } %>
                    <a href="S_ThemeProductList.aspx?ThemeGuid=<%= strId %>" style="color: #015FA7;">查看</a>
                </td>
            </tr>
            <% }
               } %>
            <!--循环代码-->
        </table>
        <% if (dt == null)
           { %>
        <div class="no_datas">
            <div class="no_data">
                暂无主题活动商品数据</div>
        </div>
        <% } %>
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    $(function () {
        $(".join").click(function () {
            $("#loadProduct").html("");
            $("#S_ThemeList_ctl00_txtKeyWord").val("");
            $("#checkAll").attr("checked", false);
            $("#ShopType").get(0).selectedIndex = 0;
            $("#pageshow").html("");
            $(this).next().text();
            $("#ThemeGuid").val($(this).next().text());
            funOpen();
        });
    })
</script>
<!-----弹出层------>
<input type="hidden" id="ThemeGuid" />
<div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
    <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
        <div class="sp_tan">
            <h4>
                选择商品</h4>
            <div class="sp_close">
                <a onclick=" funClose() " href="javascript:void(0)"></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="sp_dialog_info" style="padding-bottom: 18px;">
            <br />
            <p class="sp_general">
                <label class="sp_lable">
                    商品名称：</label>
                <input type="text" id="txtKeyWord" runat="server" class="sp_input" style="width: 200px;" />
                <span style="padding-left: 20px;">
                    <input type="button" class="sp_annoe" value="查询" onclick=" GetData(1) " /></span>
                <span style="color: Red; display: none; float: left; font-size: 12px;" id="showLoading">
                    <img src="/Images/ajax_loading.gif" /></span>
            </p>
            <%--<p style="line-height: 18px; color: #bbbbbb; padding-bottom: 6px;">
                <span class="sp_lable"></span>提示：搜索只显示最新的50条数据，如果结果中没有你想要的商品，请输入详细的商品名称进行搜索。</p>--%>
            <div class="sp_general">
                <label class="sp_lable" style="line-height: 22px;">
                    本店分类 ：</label>
                <p class="sp_general fl" style="line-height: 30px;">
                    <select id="ShopType" class="tselect">
                        <option value="0">全部分类</option>
                    </select>
                    <select id="ShopType2" style="display: none;">
                        <option value="0">全部分类</option>
                    </select>
                </p>
                <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="0" />
                <span id="SpanAdressErr"></span><span id="SpanAdressRight" style="display: none">
                    <img src="/ImgUpload/shopNum1Admin-right.gif" />
                </span>
            </div>
            <div class="sp_general" style="display: none">
                <span class="sp_lable"></span>
            </div>
            <p class="sp_general" style="display: none; height: 160px;">
                <label class="sp_lable">
                    选择商品：</label>
                <select id="selectproduct" style="display: none; height: 150px; width: 300px;" class="textwb"
                    size="10">
                </select>
            </p>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod biaod1"
                style="margin-left: 20px; margin-top: 15px;" id="showProuct">
                <thead>
                    <tr>
                        <th align="center" style="width: 30px;">
                            <input type="checkbox" id="checkAll" />
                        </th>
                        <th style="border-left: none; text-align: center; width: 450px;">
                            商品名称
                        </th>
                        <th style="border-left: none; text-align: center; width: 20%;">
                            价格
                        </th>
                        <th style="border-left: none; text-align: center; width: 10%;">
                            库存
                        </th>
                    </tr>
                </thead>
                <tbody id="loadProduct">
                </tbody>
                <tfoot>
                    <tr>
                        <td colspan="4">
                            <div class="fy" id="pageshow">
                            </div>
                        </td>
                    </tr>
                </tfoot>
            </table>
            <p class="sp_general" style="margin-top: 10px; text-align: center;">
                <span class="sp_lable"></span>
                <input type="button" class="sp_annoe" value="提交" onclick=" SelectSubmit() " /><span
                    id="errormsg" style="color: Red; display: none;">请选择商品！</span>
            </p>
        </div>
    </div>
</div>
<!-----弹出层------>
