<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    //提交方法
    function funsub() {
        /*提交时候操作规格相关方法*/
        var spec_check = new Array();
        $('span[spec_check="this_check"] > input[type="checkbox"]:checked').each(function () {
            spec_check.push($(this).attr("lang") + "," + $(this).attr("spec_type") + "," + $(this).parent().parent().find("input[sepc_value='this_name']").val().replace("|", "").replace(",", "") + "," + $(this).parent().parent().parent().parent().next().find("input[sepc_pic='filePath_" + $(this).attr("spec_type") + "']").val());
        });
        $("#S_OpGoods3_ctl00_hidSpec_Check").val(spec_check.join("|")); //取得规格选中值  4,黑色,blob:a518296c-d429-425a-abb2-8704742ce1a7|39,160/80(XS),undefined
        //alert($("#S_OpGoods3_ctl00_hidSpec_Check").val());return false;
        var spec_stock = new Array();
        var spec_stock_value = new Array();
        var bflag = true, bflag2 = true, bflag3 = true;
        ;
        ;
        var baseid = null, strV = null;
        var objthis;
        $('#Spec_body tr').find("input").each(function () {
            if ($(this).attr("name") == "spec[sp_value]") {
                strV = null;
                bflag2 = true;
                spec_stock.push($(this).attr("value") + "," + $(this).attr("sp_id"));
                if (bflag) {
                    baseid = $(this).attr("spec_bunch");
                    bflag = false;
                }
            } else {
                if (bflag2) {
                    strV = baseid;
                    baseid = null;
                    strV = spec_stock.join("|")  + "*" + strV;
                    spec_stock = new Array();
                    bflag = true;
                    bflag2 = false;
                }
                if ($(this).attr("data_type") == "goods_price") {
                    if ($(this).val() == "") {
                        alert("价格不能为空！");
                        objthis = $(this);
                        bflag3 = false;
                        return false;
                    }
                    strV += "," + $(this).val();
                }
                if ($(this).attr("data_type") == "goods_stock") {
                    if ($(this).val() == "") {
                        alert("库存不能为空！");
                        objthis = $(this);
                        bflag3 = false;
                        return false;
                    }
                    strV += "," + $(this).val();
                }
                if ($(this).attr("data_type") == "goods_no") {
                    strV += "," + $(this).val();
                    spec_stock_value.push(strV);
                }
            }
        });
        if (!bflag3) {
            objthis.focus();
            objthis.addClass("errortxt");
            return bflag3;
        }
        $("#S_OpGoods3_ctl00_hidBaseStock").val(spec_stock_value.join("&")); //取得库存值 
        /*提交时候操作规格相关方法*/

        /*提交时候操作属性相关方法*/
        var baseprop = new Array();
        $("#S_OpGoods1_ctl00_Prop_show .prop_handinput_text").each(function () {
            baseprop.push($(this).attr("prop_type") + "," + $(this).val());
        });
        $("#S_OpGoods1_ctl00_Prop_show .prop_txtinput_text").each(function () {
            baseprop.push($(this).attr("prop_type") + "," + $(this).val());
        });
        //文字输入 
        $("#S_OpGoods1_ctl00_Prop_show .prop_radio_text").each(function () {
            if ($(this).is(":checked")) {
                baseprop.push($(this).attr("prop_type"));
            }
        });
        $("#S_OpGoods1_ctl00_Prop_show .prop_select_text").each(function () {
            baseprop.push($(this).attr("prop_type") + "," + $(this).find("option:selected").val() + ",");
        });
        //下拉框选择
        $("#S_OpGoods1_ctl00_Prop_show .prop_list_check").each(function () {
            if ($(this).is(":checked")) {
                baseprop.push($(this).attr("prop_type") + ",");
            }
        }); //列表多选  
        /*提交时候操作属性相关方法*/
        $("#S_OpGoods3_ctl00_hidBaseProp").val(baseprop.join("|"));

        var pro_imgap = new Array();
        $("img[name='pro_img']").each(function () {
            pro_imgap.push($(this).attr("src"));
        });
        $("#S_OpGoods3_ctl00_hidpro_img").val(pro_imgap.join(","));
        return true;
    }
</script>
<asp:HiddenField ID="hidSetsp" runat="server" />
<input type="hidden" id="hidGType" runat="server" value="0" />
<input type="hidden" id="hidPType" runat="server" value="0" />
<input type="hidden" id="hidSpec_Check" runat="server" />
<input type="hidden" id="hidBaseStock" runat="server" />
<input type="hidden" id="hidBaseProp" runat="server" />
<input type="hidden" id="hidpro_img" runat="server" />
<dl class="tibxxbg">
    <dt>店铺分类：</dt>
    <dd>
        <table width="90%" border="0" cellspacing="0" cellpadding="0" class="xiangxsp_nr">
            <tr>
                <td width="28%">
                    <ul id="J_form">
                        <li id="nav_shop_cat"><span>
                            <!-- shop-cat-list -->
                            <div class="shop-cat-list">
                                <!-- feilv 2012-03-02 店铺分类新加钩子J_ShopCatList -->
                                <ul class="J_ShopCatList">
                                    <li>
                                        <input type="checkbox" value="420697339" name="shopCat" id="shopCatId420697339" class="checkbox">
                                        <label for="shopCatId420697339">
                                            test</label>
                                    </li>
                                    <li>品牌
                                        <ul>
                                            <li>
                                                <input type="checkbox" value="276460712" name="shopCat" id="shopCatId276460712" class="checkbox"><label
                                                    for="shopCatId276460712">Tommy</label></li>
                                            <li>
                                                <input type="checkbox" value="276460713" name="shopCat" id="shopCatId276460713" class="checkbox"><label
                                                    for="shopCatId276460713">CK</label></li>
                                        </ul>
                                    </li>
                                    <li>女装
                                        <ul>
                                            <li>
                                                <input type="checkbox" value="276460958" name="shopCat" id="shopCatId276460958" class="checkbox"><label
                                                    for="shopCatId276460958">毛衣</label></li>
                                            <li>
                                                <input type="checkbox" value="276460959" name="shopCat" id="shopCatId276460959" class="checkbox"><label
                                                    for="shopCatId276460959">牛仔裤</label></li>
                                        </ul>
                                    </li>
                                    <li>手机通讯
                                        <ul>
                                            <li>
                                                <input type="checkbox" value="721961060" name="shopCat" id="shopCatId721961060" class="checkbox"><label
                                                    for="shopCatId721961060">双模手机</label></li>
                                        </ul>
                                    </li>
                                </ul>
                            </div>
                            <!-- shop-cat-list -->
                        </span></li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span class="gray1">商品可以从属于店铺的多个分类之下</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span class="gray1">店铺分类可以由 "用户中心 -> 卖家 -> 商品管理 -> 分类管理" 中自定义</span>
                </td>
            </tr>
        </table>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品发布：</dt>
    <dd>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="xiangxsp_nr">
            <tr>
                <td width="15%">
                    <input name="5" type="radio" value="" checked="checked" />
                    立即发布
                </td>
                <td rowspan="3">
                    <div class="fudong">
                        <select name="sel" size="1" class="tselect" style="width: 120px;">
                            <option value="1">--请选择--</option>
                            <option value="2">卖家</option>
                            <option value="3">卖家</option>
                        </select>
                        &nbsp;
                    </div>
                    <div class="fudong">
                        <select name="sel" size="1" class="tselect" style="width: 120px;">
                            <option value="1">--请选择--</option>
                            <option value="2">卖家</option>
                            <option value="3">卖家</option>
                        </select>
                        &nbsp;
                    </div>
                    <div class="fudong">
                        时&nbsp;
                    </div>
                    <div class="fudong">
                        <select name="sel" size="1" class="tselect" style="width: 120px;">
                            <option value="1">--请选择--</option>
                            <option value="2">卖家</option>
                            <option value="3">卖家</option>
                        </select>
                        &nbsp;
                    </div>
                    <div class="fudong">
                        分
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <input name="5" type="radio" value="" checked="checked" />
                    发布时间
                </td>
            </tr>
            <tr>
                <td>
                    <input name="5" type="radio" value="" checked="checked" />
                    放入仓库
                </td>
            </tr>
        </table>
    </dd>
</dl>
<dl class="tibxxbg" style="display: none;">
    <dt>是否抢购：</dt>
    <dd>
        <input name="6" type="radio" value="" checked="checked" />
        是
        <input name="6" type="radio" value="" />
        否
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>关键字：</dt>
    <dd>
        <input name="input" type="text" class="textwb" />
        <span class="gray1">&nbsp;</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>描述：</dt>
    <dd>
        <textarea name="textarea" cols="" rows="" class="textwb" style="height: 120px; width: 450px;"></textarea>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt></dt>
    <dd>
        <input name="input" type="checkbox" value="" />
        同意接受<a href="#" class="alink_blue">《产品发布规则》</a>
    </dd>
</dl>
<dl class="tibxxbg" style="margin: 10px 0px 30px 0px; text-align: center;">
    <dt></dt>
    <dd>
        <asp:Button ID="butSub" runat="server" CssClass="baocbtn" Text="提交" OnClientClick=" return funsub(); " />
    </dd>
</dl>
