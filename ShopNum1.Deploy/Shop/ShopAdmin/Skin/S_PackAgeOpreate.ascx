<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<input type="hidden" id="hidPackage" />
<input type="hidden" id="hidPageCount" />
<input type="hidden" id="hidCheckIsOpen" runat="server" />
<input type="hidden" id="hidProductGuId" runat="server" />
<input type="hidden" id="hidPrice" runat="server" />
<input type="hidden" id="hidPic" runat="server" />
<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
        <tr>
            <th colspan="2">
                新增套餐
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                活动名称：
            </td>
            <td class="bordrig">
                <input type="text" id="txtName" runat="server" maxlength="16" class="op_text" /><span
                    class="star">*</span>
                <div class="gray">
                    活动名称最多为16个字符且不能为空</div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                搭配商品：
            </td>
            <td class="bordrig">
                <table width="98%" border="0" cellspacing="1" cellpadding="0" class="biaod1" style="margin-top: 15px;">
                    <thead>
                        <tr>
                            <th style="width: 400px;">
                                搭配商品
                            </th>
                            <th>
                                原价
                            </th>
                            <th>
                                库存
                            </th>
                            <th>
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody id="tbProduct">
                        <asp:Repeater ID="repSp" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <input type="hidden" name="hid_pic" value='<%#Eval("SmallImage") %>'>
                                        <img style="height: 20px; width: 20px;" src='<%#Eval("SmallImage") %>'>
                                        <%#Utils.GetUnicodeSubString(Eval("name").ToString(), 20, "..") %>
                                    </td>
                                    <td>
                                        <input type="hidden" name="hid_price" value="<%#Eval("ShopPrice") %>"><%#Eval("ShopPrice") %>
                                    </td>
                                    <td>
                                        <%#Eval("repertorycount") %>
                                    </td>
                                    <td>
                                        <input type="hidden" value="<%#Eval("guid") %>" name="hidguid">
                                        <input type="hidden" value="<%#Eval("ID") %>" name="hidId" />
                                        <input id="btnAdd" class="packremove addpack_<%#Eval("ID") %> addpack_3081 tjdp"
                                            type="button" lang="2" value="移除">
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" id="search_Pro" style="display: none;
                    margin-top: 15px;">
                    <tr>
                        <td style="border: none; text-align: center;">
                            商品分类：<select id="ProSelect" class="tselect" style="width: 120px;"></select>
                        </td>
                        <td style="border: none; padding-left: 20px;">
                            商品名称：<input type="text" id="txtProductName" class="ss_nr1" style="width: 150px;" />
                        </td>
                        <td style="border: none; text-align: left;">
                            <input type="button" value="搜索" id="search_sub" class="chax btn_spc" />
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="border-left: 1px solid #e3e3e3;
                    display: none; margin-top: 15px;" id="showProuct">
                    <thead>
                        <tr>
                            <th style="border-left: none; text-align: center; width: 450px;">
                                商品名称
                            </th>
                            <th style="border-left: none; text-align: center; width: 20%;">
                                价格
                            </th>
                            <th style="border-left: none; text-align: center; width: 10%;">
                                库存
                            </th>
                            <th style="border-left: none; text-align: center; width: 20%;">
                                操作
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
                <br />
                <input type="button" id="addProduct" value="添加商品" class="btn_add" /><span class="red">*</span>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                组合销售价格：
            </td>
            <td class="bordrig">
                <input type="text" id="txtSalePrice" onblur="checkpriceTxt(this)" runat="server"
                    class="op_text" />元<span class="star">*</span>
                <div class="gray">
                    原价<asp:Label ID="lblShopPrice" runat="server" Text="0"></asp:Label>元
                </div>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                活动描述：
            </td>
            <td class="bordrig" style="padding-right: 20px;">
                <textarea id="txtDesc" runat="server" class="textwebedit"></textarea>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                活动状态：
            </td>
            <td class="bordrig">
                <p>
                    <label for="pack_status_1">
                        <input type="radio" id="pack_status_1" checked="checked" name="opencheck" value="1" />
                        开启</label>
                    <label for="pack_status_0">
                        <input type="radio" id="pack_status_0" name="opencheck" value="0" />
                        关闭</label>
                </p>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="btnSub" runat="server" Text="提交" OnClientClick=" return checksub() "
            CssClass="baocbtn" />
    </div>
</div>
