document.write('<script type="text/javascript" language="javascript" src="/js/artDialog/artDialog.js"></script>');
document.write('<link type="text/css"  href="/js/artDialog/skins/chrome.css" rel="stylesheet"></link>');
 /*Jely 20130724封装弹出层方法*/
 var lockAlert=true;
 var lockDel=true;
 var lockConfirm=true;
    /*弹出框提示通用方法 相当于微软alert()
    msg       提示信息内容
    isreload  是否重新加载页面*/
    function alert(msg,isreload)
    {
        if(lockAlert){
                art.dialog({
                title: '提示',
                content: msg,
                icon: 'succeed',
                ok: function(){lockAlert=true;if(isreload){ window.location.reload();}else{$(this).hide();}}
            });
            lockAlert=false;
         }
     }
     /*tip 信息确定关闭对话框 比如是否删除  类似于微软confirm()
     ajaxurl 可以为空 是否执行ajax
     successmsg 点击确定后执行某项操作后成功提示
     errormsg 点击确定后执行某项操作后失败提示*/
     function Confirm(tip,ajaxurl,successmsg,errormsg)
     {
         if(lockConfirm){
         art.dialog({
                content: tip,
                ok: function () {$("input[type='checkbox']").removeAttr("checked");lockConfirm=true;
                   if(ajaxurl!=""){
                       $.get(ajaxurl,null,function(data){
                            if(data=="ok"){alert(successmsg,true);return false;}
                            else{alert(errormsg,false);return false;}
                       });
                   }
                },
                cancelVal: '关闭',
                cancel:function(){ lockConfirm=true;return true;}
          });
          }
     }
     /*弹出框删除通用方法 相当于
     val         传过来的ID
     delsysmsg   操作类型*/
     function IsDelete(val,delsysmsg){
        if(!$(".aui_state_focus").is(":visible"))
        {
            lockAlert=true;lockDel=true;lockConfirm=true;
        }
         switch(delsysmsg)
         {
            case "delsysmsg":ajax_delurl+"?type="+delsysmsg+"&delid="+val;break;
         }
         if(lockDel){
                 Confirm("是否删除勾选项？","删除成功！","删除失败！",ajax_delurl);
                 lockDel=false;
        }
     }
    