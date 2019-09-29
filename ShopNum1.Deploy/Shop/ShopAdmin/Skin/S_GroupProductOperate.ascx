<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
        <tr>
            <th colspan="2" scope="col">
                <% if (ShopNum1.Common.Common.ReqStr("id") == "")
                   { %>
                新增团购商品<% }
                   else
                   { %>
                编辑团购商品
                <% } %>
            </th>
        </tr>
        <tr>
            <td class="bordleft" width="130">
                团购活动：
            </td>
            <td class="bordrig">
                <select name="GroupActivityName" class="op_select" style="width: 300px;">
                </select><span class="star">*</span>
                <div class="gray">
                    选择要参加的团购活动及时间段</div>
            </td>
        </tr>
        <tr>
            <td class="bordleft" width="130">
                团购名称：
            </td>
            <td class="bordrig">
                <input type="text" id="txtGroupName" runat="server" class="op_text" /><span class="star">*</span>
                <div class="gray">
                    团购标题名称长度最多可输入50个字符</div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                团购商品：
            </td>
            <td class="bordrig">
                <input type="text" id="txtPname" runat="server" class="op_text" /><span class="star">*</span>
                <div class="gray">
                    点击上方输入框从已发布商品中选择要参加的商品 如没有找到您想要参加团购的商品，请重新发布该商品后再选择。</div>
            </td>
        </tr>
        <tr style="display: none" id="trprice">
            <td class="bordleft">
                店铺价格：
            </td>
            <td class="bordrig">
                <span id="spanprice"></span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                团购价格：
            </td>
            <td class="bordrig">
                <input type="text" id="txtGroupPrice" runat="server" class="op_text" maxlength="8" /><span
                    class="star">*</span>
                <div class="gray">
                    团购价格为该商品参加活动时的促销价格 必须是0.01~10000.00之间的数字(单位：元)</div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                团购图片：
            </td>
            <td class="bordrig">
                <img width="200" id="GroupPic" runat="server" alt="" /><span id="spanshow" style="display: none;"></span>
                <asp:FileUpload ID="fileUpload" runat="server" onchange="getFullPath(this)" /><br />
                <span class="star">*</span><span id="span1" style="color: #bbbbbb;">上传图片不超过1M，上传图片支持gif、jpg、png、bmp格式。</span>
            </td>
        </tr>
        <tr style="display: none" id="trstock">
            <td class="bordleft">
                商品库存数：
            </td>
            <td class="bordrig">
                <span id="spanstock" runat="server"></span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                商品总数：
            </td>
            <td class="bordrig">
                <input type="text" maxlength="5" value="1" id="txtGroupStock" runat="server" onkeyup="NumTxt_Int(this)"
                    class="op_text" /><span class="star">*</span>
                <div class="gray">
                团购商品总数应等于或小于该商品库存数量并且大于0 请提前确认要参与活动的商品库存数量足够充足
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: solid 1px #c6dfff;">
                本团介绍：
            </td>
            <td class="bordrig" style="border-bottom: solid 1px #c6dfff; padding-right: 20px;">
                <textarea id="txtGroupIntroduce" runat="server" class="textwebedit op_word"></textarea>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="btnSub" runat="server" Text="提交" CssClass="baocbtn" OnClientClick=" return subcheck(); " />
        <span id="showmsg" style="display: none;">平台没有发布团购活动!</span> <span id="spanImg" style="display: none;">
            <img src='/Images/load.gif' /></span> <span class="gray1"></span>
    </div>
</div>
<!-----弹出层------>
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
                <input type="text" id="txtKeyWord" runat="server" class="sp_input" style="width: 300px;" />
            </p>
            <p style="color: #bbbbbb; line-height: 18px; padding-bottom: 6px;">
                <span class="sp_lable"></span>提示：搜索只显示最新的50条数据，如果结果中没有你想要的商品，请输入详细的商品名称进行搜索。</p>
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
            <div class="sp_general">
                <span class="sp_lable"></span><span>
                    <input type="button" class="sp_annoe" value="查询" onclick=" GetData() " /></span>
                <span style="color: Red; display: none; float: left; font-size: 12px;" id="showLoading">
                    <img src="/Images/ajax_loading.gif" /></span>
            </div>
            <p class="sp_general" style="height: 160px;">
                <label class="sp_lable">
                    选择商品：</label>
                <select id="selectproduct" style="height: 150px; width: 300px;" class="textwb" size="10">
                </select>
            </p>
            <p class="sp_general">
                <span class="sp_lable"></span>
                <input type="button" class="sp_annoe" value="提交" onclick=" SelectClick() " /><span
                    id="errormsg" style="color: Red; display: none;">请选择商品！</span>
            </p>
        </div>
    </div>
</div>
<!-----弹出层------>
<input type="hidden" id="hidGuid" runat="server" />
<input type="hidden" id="hidAid" runat="server" value="0" />
<input type="hidden" id="hidAname" runat="server" />