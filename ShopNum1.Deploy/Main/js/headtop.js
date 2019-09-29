/*shopnum1 jely 20130726封装优化js*/
//首页搜索切换JS
  function chang(value)
  {     
	 for (var i=1;i<=4;i++)
	 {
	    document.getElementById("hh" + i).className = "";
	 }                        
	 document.getElementById("HiddenSwitchType").value=value;
	 document.getElementById("hh" + value).className = "cur";
	 //切换搜索自动提示
     showHint($("#textfield").val());
  }
  String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) {  
    if (!RegExp.prototype.isPrototypeOf(reallyDo)) {  
        return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi": "g")), replaceWith);  
    } else {  
        return this.replace(reallyDo, replaceWith);  
    }  
}  
  
//回车触发
function KeyEnter(o)
{
      if(o.keyCode==13){
          document.getElementById("ButtonSearch").focus();
          searchgo(0,'');
      }
}
    function searchgo(c_type,c_name){
        var type=$("#HiddenSwitchType").val();
        var name=escape($("#textfield").val().replaceAll("/","%2F").replaceAll(" ",""));
        var a=nofind+"?search="+name+"&pv="+type;
        location.href=a; 
    }
//搜索自动提示   2013-04-03 Jely优化支持拼音搜索功能 <!--搜索自动提示-->
var i=0;
function showHint(str)
{
     if(str.toString().length=0){return false;}
        var var_tag;//标识
        var var_data;//请求数据
        if($("#mallSearch .switchover #hh1").attr("class")=="cur"){var_tag="0";var_data="type=searchproduct&keyword="+str+"";}
        if($("#mallSearch .switchover #hh2").attr("class")=="cur"){var_tag="1";var_data="type=searchshop&keyword="+str+"";}
        if($("#mallSearch .switchover #hh3").attr("class")=="cur"||$("#mallSearch .switchover #hh4").attr("class")=="cur"||$("#mallSearch .switchover #hh5").attr("class")=="cur"){return false;}
        
        if(str!="")
        {
             var hidv=$("#hidv").val();
             if(getdate(str,var_tag)){
                       $(".ll_all_search").show();$(".checktag p").show(); 
                       $(".ll_all_search p:eq("+var_tag+")").hide();
                       $(".ll_xiala").html($("#s"+getdate(str,var_tag)[1]).html());  return false;
             }
              i++;
              hidv+="|"+str+","+i+","+var_tag;
             //绑定切换搜索的标签
             var changetag="<p class=\"ll_p\" onclick=\"chang(1)\"><a >搜索“"+str+"” <span>商品</span></a></p>";
                $.ajax({           
                type:"POST",
                async:true,
                url: "/api/autosearch.ashx",
                data:""+ var_data+"",
                dataType:"json",
                success: function(result) {
                  if(result!="0")
                  {
                        $("#hidv").val(hidv);
                         $(".ll_all_search").show();
                          var ajaxdata=new Array();
                          if(var_tag=="0")
                             ajaxdata.push("<li> \"" + str + "\" <span>在宝贝分类下搜</span>索</li>");
                          else
                             ajaxdata.push("<li> \"" + str + "\" <span>在店铺分类下搜</span>索</li>");
                          $.each(result ,function(m,n){
                               ajaxdata.push(" <li onclick=\"javascript:searchgo(1,this)\">" +n.name+ "</li>");
                          });
                          $(".ll_xiala").html(ajaxdata.join(""));
                        //切换分类（隐藏当前标签，显示其他）
                        //$(".checktag").html(changetag);
                        $("body").append("<div id=\"s"+i+"\" style=\"display:None\">"+ajaxdata.join("")+"</div>");
                        $(".checktag p").show();
                        $(".ll_all_search p:eq("+var_tag+")").hide();
                   }
                  else
                  {
                     $("#hidv").val(hidv);
                     $(".ll_xiala").html("<div style=\"line-height:2\">没有搜索到["+str+"]符合条件数据</div>");
                     $("body").append("<div id=\"s"+i+"\" style=\"display:None\"><div style=\"line-height:2\">没有搜索到["+str+"]符合条件数据</div></div>");
                  }
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        }
        else{$(".ll_all_search").hide();}
}
function getdate(str,tag)
{
    var $x=$("#hidv").val();
    var arrt=$x.split("|");
    for(var i in arrt)
    {
        if(arrt[i].split(',')[0]==str&&tag==arrt[i].split(',')[2])
        {
             return arrt[i].split(',');
        }
    }
    return false;
}
$(document).ready(function(){
    $(".ll_all_search").hide();
    $("div:not([class='ll_all_search'])").click(function(){ $(".ll_all_search").hide(); });
});
$(function(){
    $("#headtest").hover
    (
        function(){$(this).addClass("huaguo1");},
        function(){$(this).removeClass("huaguo1");}
   );
})
$(function(){
    $("#headtest1").hover
    (
        function(){$(this).addClass("huaguo2"); },
        function(){$(this).removeClass("huaguo2");}
   );
})
$(function(){
    $("#headtest2").hover
    (
        function(){$(this).addClass("huaguo2");},
        function(){$(this).removeClass("huaguo2");}
   );
});
$(function(){
    $("#headtest3").hover
    (
        function(){$(this).addClass("huaguo3");},
        function(){$(this).removeClass("huaguo3");}
   );
});
$(function(){
    //鼠标划入时
    $('#DivShangcheng').hover
    (
            function()
            {
                  $(this).children('div').show();
                  $(this).children('span').css("color","#780002");
            },
            //鼠标移除时
            function()
            {
                  $(this).children('div').hide();
                  $(this).children('span').css("color","");
            }
     );
      //鼠标划入时
    $('#DivGouwuche').hover
    (
            function()
            {
                  $(this).children('div').show();$(this).children('span').css("color","#780002");
            },
            //鼠标移除时
            function()
            {
                  $(this).children('div').hide();$(this).children('span').css("color","");
            }
     );
});