<%@ Control Language="C#" %>
    <div class="FlowCat_cont">
        <div class="warp_site">
            首页 》<a href="/SupplyDemandListSearch.aspx?search=" id="psearch">供求搜索</a>
        </div>
<div class="nofind">
    <div class="nohead">
        <span class="nopic"></span>抱歉，没有找到与“<asp:Label ID="LabelProtectSearch" runat="server" Text=""></asp:Label>”相关的<span id="changetxt"></span>信息哦，要不您换个关键词再找找看</div>
    <div class="nocont">
        <p class="nostrong">
            建议您：</p>
        <p>
            1、看看输入的文字是否有误</p>
        <p>
            2、调整关键字，如：“nokian97”改成“nokia n97”</p>
        <p>
            3、重新搜索</p>
        <div class="nosearch">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <input id="TextBoxProtectName" type="text" class="noinput" />
                    </td>
                    <td>
                        <input id="Button1" type="button" value="" class="nobtn" onclick="Btnclickx()" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
 </div>
<script type="text/javascript" language="javascript">
$(function(){
    var localid=getParamValue("pv");
    var vurl="";
    switch(localid)
    {
       case "1":$("#psearch").html("商品搜索");$("#psearch").attr("href","/Search_productlist.aspx");$("#changetxt").text("商品");break;
       case "2": $("#psearch").html("店铺搜索"); $("#psearch").attr("href", "/ShopListSearch.aspx"); $("#changetxt").text("店铺"); break;
       case "3": $("#psearch").html("资讯搜索"); $("#psearch").attr("href", "/ArticleListSearch.aspx"); $("#changetxt").text("资讯"); break;
       case "4": $("#psearch").html("供求搜索"); $("#psearch").attr("href", "/SupplyDemandListSearch.aspx"); $("#changetxt").text("供求"); break;
       case "5": $("#psearch").html("供求搜索"); $("#psearch").attr("href", "/SupplyDemandListSearch.aspx"); $("#changetxt").text("供求"); break;
    }
});
function  Btnclickx()
{
    var strProductName=document.getElementById("TextBoxProtectName").value.toLowerCase();
    if(strProductName.toLowerCase()=="search")
    {
        strProductName="";
    }
    var localid=getParamValue("pv");
    var vurl="";
    switch(localid)
    {
       case "1":vurl="/nofindsearch.aspx?pv="+localid+"&search="+escape(strProductName);break;
       case "2": vurl = "/nofindsearch.aspx?pv=" + localid + "&search=" + escape(strProductName); break;
       case "3": vurl = "/nofindsearch.aspx?pv=" + localid + "&search=" + escape(strProductName); break;
       case "4": vurl = "/nofindsearch.aspx?pv=" + localid + "&search=" + escape(strProductName); break;
       case "5": vurl = "/nofindsearch.aspx?pv=" + localid + "&search=" + escape(strProductName); break;
    }
    window.location.href=vurl;
}
// 获取地址栏的参数数组
function getUrlParams()
{
    var search = window.location.search ; 
    // 写入数据字典
    var tmparray = search.substr(1,search.length).split("&");
    var paramsArray = new Array; 
    if( tmparray != null)
    {
        for(var i = 0;i<tmparray.length;i++)
        {
            var reg = /[=|^==]/; var set1 = tmparray[i].replace(reg,'&'); var tmpStr2 = set1.split('&');
            var array = new Array ; array[tmpStr2[0]] = tmpStr2[1] ; paramsArray.push(array);
        }
    }
    // 将参数数组进行返回
    return paramsArray ;     
}

// 根据参数名称获取参数值
function getParamValue(name)
{
    var paramsArray = getUrlParams();
    if(paramsArray != null)
    {
        for(var i = 0 ; i < paramsArray.length ; i ++ )
        {
            for(var  j in paramsArray[i] ){if( j == name ){return paramsArray[i][j] ; }}
        }
    }
    return null ; 
}
</script>