<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<script src="../../../Main/js/jquery-1.3.1.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    var BrandAjaxUrl = "/Api/S_OpGoods1.ashx?type=0&brand_cid=<%= Request.QueryString["ctype"] %>";

     
                  
                   
                   
        
</script>
<style type="text/css">
    .editbox
    {
        display: inline;
        height: 25px;
        line-height: 25px;
        padding: 0px;
        width: 35px;
    }
    
    .hint
    {
        color: #BBBBBB;
        line-height: 20px;
    }
    
    input.spec_txt
    {
        border: 1px solid #A7A6AA;
        height: auto;
        margin: 0;
        width: 100px;
    }
</style>

<%
    //这里是判断规格属性品牌如果没有绑定商品类型则更改显示方式
     //if (ShopNum1.Common.Common.ReqStr("pid").Length < 30 || Spec_show.InnerHtml.Length<50) { Spec_show.Visible = false; Prop_show.Visible = false; } %>
<asp:HiddenField ID="hidSetsp" runat="server" />
<input type="hidden" id="hidCategoryName" runat="server" />
<input type="hidden" id="hidEditBind" runat="server" />
<dl class="tibxxbg" style="display: none">
    <dt>宝贝类型：</dt>
    <dd>
        <input name="gType" type="radio" value="0" checked="checked" />全新
        <input name="gType" type="radio" value="1" />二手
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>物品类型：</dt>
    <dd>
        <input name="IsReal" type="radio" value="1" checked="checked" />实际物品
        <input name="IsReal" type="radio" value="0" />生活服务
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>主站商品分类：</dt>
    <dd>
        <div class="fudong" id="productCategoryName">
            &nbsp;</div>
        <div class="fudong">
            <a href='S_SellGoods_One.aspx?op=add&step=one&cid=<%= Request.QueryString["cid"] %>&pid=<%= Request.QueryString["pid"] %>'
                class="selpic"><span>编辑</span></a>
        </div>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品类别：</dt>
    <dd>
        <input name="pType" type="checkbox" id="isnew" value="0" />新品
        <input name="pType" type="checkbox" id="ishot" value="1" />热卖
        <input name="pType" type="checkbox" id="ispromotion" value="2" />促销
        <input name="pType" type="checkbox" id="Isrecommend" value="3" />推荐</dd>
</dl>
<dl class="tibxxbg">
    <dt>商品名称：</dt>
    <dd>
        <input name="input" type="text" id="txtGoodsName" class="textwb" style="width: 300px;"
            maxlength="50" /><span check="errorMsg" style="color: Red; display: none">商品标题名称长度至少3个字符，最长50个汉字！</span><span
                style="color: Red;">*</span>
        <br />
        <span class="gray1">商品标题名称长度至少3个字符，最长50个汉字</span>
    </dd>
</dl>

<dl class="tibxxbg">
    <dt>商品库存：</dt>
    <dd>
        <input name="input" id="txtStock" type="text" class="textwb" onkeyup=" NumTxt_Int(this) "
            maxlength="5" value="1" /><span check="errorMsg" style="color: Red; display: none">商铺库存数量必须为1~1000000000之间的整数！</span><span
                style="color: Red;">*</span><br />
        <span class="gray1">商铺库存数量必须为0~100000之间的整数</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>库存警告数量：</dt>
    <dd>
        <input name="input" id="txtRepertoryAlertCount" type="text" class="textwb" onkeyup=" NumTxt_Int(this) "
            maxlength="5" value="1" /><span check="errorMsg" style="color: Red; display: none">商铺库存警告数量必须为1~1000000000之间的整数！</span><span
                style="color: Red;">*</span><br />
        <span class="gray1">商铺库存警告数量必须为1~100000之间的整数</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>设置颜色信息: &nbsp;</dt>
    <input id="txtColor" type="text"  class="textwb" name="Color_My"/><br />
    <span style="color:Red;"> 多种颜色请用“，”隔开</span><br />
    </dl>
    <dl class="tibxxbg">
    <dt>设置尺寸信息: &nbsp;</dt>
    <input id="txtSize" type="text"   class="textwb" name="Color_My"/><br />
    <span style="color:Red;"> 多种尺寸请用“，”隔开</span><br />
    </dl>


    <div id="div000" style="color:Red;"  >
    发布商品价格的规则是：价格必须比积分和红包高
   </div>

    <div id="div11" >
           <dl class="tibxxbg"  style=" display:none">
    <dt>可得B积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_a_CTC" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00"/><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_CTC_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg"  style=" display:none">
    <dt>零售价：</dt>
    <dd>
        <input name="input" id="txtMyPrice" type="text" onblur=" checkpriceTxt(this) "
            maxlength="9" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_MyPrice" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg" style="display:none;">
    <dt>可得红包：</dt>
    <dd>
        <input name="input" id="txtScore_hv_CTC" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_hv_CTC_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品价格：</dt>
    <dd>
        <input name="input" id="txtShopPrice_one_CTC" onblur=" checkpriceTxt(this) " type="text"
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">商品价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_price_CTC_sum" value="" type="hidden" />
        <span class="gray1">商品价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>市场价格：</dt>
    <dd>
        <input name="input" id="txtMarketPrice_one_CTC" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.01~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_mprice_CTC_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.01~1000000之间的数字</span>
    </dd>
</dl>
  </div>
   
    


<dl class="tibxxbg"  style="display:none;">
    <dt>可得积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_b" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_b_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

<dl class="tibxxbg"  style="display:none;">
    <dt>可得赠送币：</dt>
    <dd>
        <input name="input" id="txtScore_dv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_dv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>


<dl class="tibxxbg" style="display:none;">
    <dt>慈善金额：</dt>
    <dd>
        <input name="input" id="txtScore_sv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_sv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>


<dl class="tibxxbg">
    <dt>商品货号：</dt>
    <dd>
        <input name="input" id="txtNumber" type="text" class="textwb" maxlength="20" />
        <span class="gray1">最多可输入20个字符，支持输入中文、字母、数字、_、/、-和小数点</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品单位：</dt>
    <dd>
        <input name="input" id="txtUnitname" type="text" class="textwb" />
        <span class="gray1">&nbsp;</span>
    </dd>
</dl>

<dl class="tibxxbg">
    <dt>商品品牌：</dt>
    <dd>
        <select name="sel" size="1" class="select_Brand" id="selectbrand">
            <option value="00000000-0000-0000-0000-000000000000">其它</option>
        </select>
        <span style="display: none;" id="OtherBrand">
            <input type="text" id="txtPersonBrand" class="textwb" /></span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品图片：</dt>
    <dd>
        <div class="shappic">
            <ul>
                <li class="chali1" id="tabpic1" onclick=" changTabPic('#tabpic2', this) ">商品图片</li>
                <li class="chali2" id="tabpic2" onclick=" changTabPic('#tabpic1', this) ">从用户相册中选择</li>
            </ul>
            <div style="clear: both;">
            </div>
            <div class="shappic_nr">
                <div id="TabAlbum" style="display: none">
                    <table width="100%" border="0" cellspacing="3" cellpadding="0">
                        <tr>
                            <td>
                                &nbsp;用户相册 > 全部图片
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right">
                                <input type="hidden" id="albumtype" value="0" />
                                <select name="select_album" class="tselect">
                                    <option value="0">-请选择-</option>
                                    <option value="1">默认相册</option>
                                </select>
                            </td>
                        </tr>
                    </table>
                    <div id="albumlist">
                        <ul style="width: 100%">
                        </ul>
                    </div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td width="465">
                                <div class="fy">
                                    <span id="currentPage" style="width: 150px;">当前页<label id="lblpageIndex" style="width: 20px;">1</label>/<label
                                        id="lblpageCount"></label>页</span> <span id="OtherPageNum" class="num"></span>
                                    <span id="droplist"></span>一共<span class="lblNumCount"></span>条记录
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_1" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " />
                    </li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_0_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_0_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_1') " id="file_0" name="file_0" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            name="pro_img" id="imgvj_2" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_1_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_1_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_2') " id="file_1" name="file_1" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_3" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_2_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_2_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_3') " id="file_2" name="file_2" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_4" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_3_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_3_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_4') " id="file_3" name="file_3" />
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li style="padding-top: 10px;">
                        <img src="/ImgUpload/noimg.jpg_100x100.jpg" name="pro_img" width="114" height="114"
                            id="imgvj_5" onerror=" javascript:this.src = '/ImgUpload/noimg.jpg_100x100.jpg'; " /></li>
                    <li style="display: none; padding-left: 20px; padding-top: 5px;" id="file_4_del">
                        <input type="button" value="删除图片" name="file_btn" class="selpic" /></li>
                    <li style="padding-top: 40px; position: relative;" id="file_4_upload">
                        <div class="upload-btn">
                            <span>
                                <input type="file" onchange=" changfile(this, '#imgvj_5') " id="file_4" name="file_4">
                            </span>
                            <div class="selpic">
                                图片上传</div>
                        </div>
                    </li>
                </ul>
                <div style="clear: both;">
                </div>
                <h2 class="spth2">
                    此处为您的商品图片，将显示在店铺图库里，图片大小不能超过1M。<span id="errpicmsg" style="color: Red; display: none"></span></h2>
                <h3 class="spth3">
                    建议使用宽300像素-高300像素内的Jpg图片</h3>
                <h3 class="spth3">
                    <span class="red" style="display: none;" id="showpic">至少上传一张图片！</span></h3>
            </div>
        </div>
    </dd>
</dl>
