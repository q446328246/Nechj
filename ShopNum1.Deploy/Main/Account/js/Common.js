//Jely 2013-07-30 新添加common.js

/*
1   用法 onkeyup="NumTxt_Int(this)"     限制文本框只能输入数字
2   用法 str.trim()                     去除字符左右空格
3   用法 if(!checkprice(txt)){alert("价格不合法");}  验证价格
4   用法  Template.replaceAll("A","B")   将内容里面包含A的字符全部替换成B
5   用法  compareTime(startTime,endTime) if(!compareTime('2013-09-08','2013-07-30')){alert("开始时间必须小于结束时间！");}
6   用法  var price=price_format("3.3333333");price格式化后为3.33   用于格式化价格
7   用法   CheckCN(str)   用于验证中文
8   用法   CheckEmailCommon() 用于验证邮箱
9   用法   CheckMobileCommon() 用于验证手机号码
10  用法   CheckIDCommon()  用于验证身份证
11  用法   CheckPostCodeCommon() 用于验证邮编
12  用法   CheckCompare(i,j,k) 密码，账号等重复信息的核对
13  用法   CheckNull(i,j) 检查文本值是否是空值，i,为文本值id,j 为提示信息 
14  用法   CheckMoney(i,j,k) 提现，充值时，金额的比较，不能大于预付款
*/



/*------------------------1------------------------------------*/
//限制文本框只能输入数字  onkeyup="NumTxt_Int(this)"
function NumTxt_Int(o)
{
   o.value=o.value.replace(/\D/g,'');
}

/*-----------------------2---------------------------------*/
//删除字符串二边空格
String.prototype.trim = function()
{
    return this.replace(/(^[\s]*)|([\s]*$)/g, "");
};
/*-----------------------3----------------------------------------*/
//判断价格是否合法
function checkprice(name)
{
    var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
    if(!oo.test(name)){  return false;}else{return true;}
}
/*--------------------4-------------------------------------*/
//全部替换
 String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) {  
            if (!RegExp.prototype.isPrototypeOf(reallyDo)) {  
                return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi": "g")), replaceWith);  
            } else {  
                return this.replace(reallyDo, replaceWith);  
            }  
    } 
/*---------------------5--------------------------------------*/   
//时间对比方法
function compareTime(startTime,endTime) {  
        var starttimes = startTime.split('-');
        var endtimes = endTime.split('-');
        var starttimeTemp = starttimes[0] + '/' + starttimes[1] + '/' + starttimes[2];
        var endtimesTemp = endtimes[0] + '/' + endtimes[1] + '/' + endtimes[2];
        
        if(Date.parse(new Date(starttimeTemp))<Date.parse(new Date(endtimesTemp)))
        {  return true; }
        else{ return false;}
} 
/*--------------------6---------------------------------*/
/* 格式化金额 */
function price_format(price){
    if(typeof(PRICE_FORMAT) == 'undefined'){
        PRICE_FORMAT = '%s';
    }
    price = number_format(price, 2);

    return PRICE_FORMAT.replace('%s', price);
}
function number_format(num, ext){
    if(ext < 0){
        return num;
    }
    num = Number(num);
    if(isNaN(num)){
        num = 0;
    }
    var _str = num.toString();
    var _arr = _str.split('.');
    var _int = _arr[0];
    var _flt = _arr[1];
    if(_str.indexOf('.') == -1){
        /* 找不到小数点，则添加 */
        if(ext == 0){
            return _str;
        }
        var _tmp = '';
        for(var i = 0; i < ext; i++){
            _tmp += '0';
        }
        _str = _str + '.' + _tmp;
    }else{
        if(_flt.length == ext){
            return _str;
        }
        /* 找得到小数点，则截取 */
        if(_flt.length > ext){
            _str = _str.substr(0, _str.length - (_flt.length - ext));
            if(ext == 0){
                _str = _int;
            }
        }else{
            for(var i = 0; i < ext - _flt.length; i++){
                _str += '0';
            }
        }
    }

    return _str;
}
/*----------------------7---------------------------------*/
//验证中文   字符串 
function CheckCN(str)
{
   if(str!="")
   {
     if(/^[a-zA-Z ]{1,20}$/.test(str)||/^[\u4e00-\u9fa5]{1,10}$/.test(str))
   {
       return true;
   }
   else
   {
       return false;
   }
   }
   else
   {
   return false;
   }
 
}



/*----------------------8---------------------------------*/
//验证邮箱
function CheckEmailCommon(str)
{  

    if(str!="")
    {
     if(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/.test(str))
  {
   return true;
  }
  else
  {
   return false;
  }
    }
   else
   {
    return false;
   }
 
 
 
}


/*------------------------9--------------------------------*/
//验证手机
function CheckMobileCommon(str)
{
 if(str!="")
 {
     if (/^1[2|3|4|5|6|7|8|9][0-9]\d{8,8}$/.test(str))
  {
   return true;
  }
  else
  {
   return false;
  }
 }
 else
 {
  return false;
 }
 
}

/*-----------------------10-------------------------------*/
//验证身份证
function CheckIDCommon(str)
{
 if(str!="")
 {
  if(/^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$/.test(str)||/^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/.test(str))
  {
   return true;
  }
  else
  {
   return false;
  }
 }
 else
 {
   return false;
 }


}


/*--------------------------11------------------------------*/
//验证邮编
function CheckPostCodeCommon(str) ///^[1-9][0-9]{5}$/
{
if(str!="")
{
 if(/^[0-9][0-9]{5}$/.test(str))
  {
   return true;
  }
  else
  {
   return false;
  }
}
else
{

 return false;
}

}

/*----------------------------12-------------------------------*/
//密码，账号等重复信息的核对
function CheckCompare(i,j,k,q)
{
if($(i).val()!=$(j).val())
{
  $(i).next().text(k);
 return false;
}
else
{
 $(i).next().text(q);
 return true;
}
}

/*-----------------------------13---------------------------------*/
//空值判断
 function CheckNull(i,j)
{
   var a=$(i).val();
   if(a=="")
   {
     //i 的下一个 ，需要 span 标签，用于信息提示
     $(i).next().text(j);
     return false;
   }
   else
   {
   $(i).next().text(" *");
     return true;
   }
};



/*----------------------------14-------------------------------*/
//提现，转账时，金额的大小比较
function CheckMoney(i,j,k)
{
  if($(i).val()=="")
  {
    $(i).next().text("*");
   return false;
  }
  else
  {
    if(parseInt($(i).val())>parseInt($(j).text()))
    {
     alert(k);
     $(i).next().text(k);
     return false;
    }
    else
    {
      $(i).next().text("*");
    return true;
    }
  }

}
$(function(){
       $(".lmf_btnss").click(function(){
             if($(".lmf_nr").val()=="请输入关键字"){alert("请输入关键字");return false;}
             location.href="/Search_productlist.aspx?search="+escape($(".lmf_nr").val());
       });
      //一句话全选通用js
      $("input[name='checktop']").click(function(){ $("input[name='checksub']").attr("checked",$(this).is(":checked")); });//全选反选一句话
      $("#selectall").click(function(){$("input[type='checkbox']").attr("checked","true");});//全选
      $("#cancelall").click(function(){$("input[type='checkbox']").removeAttr("checked");});//取消全选
});
