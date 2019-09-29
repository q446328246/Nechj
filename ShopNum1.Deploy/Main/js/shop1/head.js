$(function(){
    $("#headtest2").hover
    (
        function()
        {
            $(this).addClass("huaguo2");
          
        },
        function()
        {
            $(this).removeClass("huaguo2");
        }
   );
})
$(function(){
    $("#headtest3").hover
    (
        function()
        {
            $(this).addClass("huaguo3");
          
        },
        function()
        {
            $(this).removeClass("huaguo3");
        }
   );
})

function addFav()
{
if(document.all)
{      
        try
   {
      window.external.addFavorite(sitedomain, document.title);
   }
   catch (e1)
   {
     try
    {
      window.external.addToFavoritesBar(sitedomain,document.title);
     }
    catch (e2)
    {
      alert('请使用按键 Ctrl+D收藏本网站');
    }
    }
}
else if(window.sidebar){
      window.sidebar.addPanel(document.title,sitedomain,"");
}
else 
{
  alert('请使用按键 Ctrl+D收藏本网站');
}
}
function setHomepage(){
   if(document.all){
      document.body.style.behavior='url(#default#homepage)';
      document.body.setHomePage(sitedomain);
   }
   else if(window.sidebar)
   {
        if(window.netscape)
        {
             try{
                 netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
                 var prefs=Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
                 prefs.setCharPref('browser.startup.homepage',sitedomain);
             }
             catch(e){
                 alert("您的浏览器未启用[设为首页]功能，开启方法：先在地址栏内输入about:config,然后将选项 signed.applets.codebase_principal_support 值该为true即可");
             }
        }
     
   }
}

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
})