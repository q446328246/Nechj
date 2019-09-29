/**
 * Ansel 自定义select插件
 * v0.1
 * 3126620990
 */
(function($) {
    $.fn.extend({
        anselcfg:function(obj){
            var cssHtm='.ansel_select {position: fixed;top:15%;left:10%;display:none;background:#fff;width:80%;height:70%;overflow: hidden;z-index: 19951024;border-radius: 4px;box-shadow: 0px 3px 14px 3px #ccc;}  .ansel_search {margin:10px;border-bottom:1px solid #f2f2f2;overflow:hidden;height:35px;line-height: 35px;}  .ansel_search .ansel_search_input {border:none;height:35px;line-height: 35px;width:100%;}  .ansel_ul {overflow: hidden;margin:10px;border-top:1px solid #f2f2f2;overflow-y: auto;}  .ansel_ul .ansel_li {border-bottom:1px solid #f2f2f2;height:35px;line-height: 35px;overflow:hidden;text-overflow:ellipsis; white-space: nowrap;}  .ansel_ul .ansel_li:active{background:#f2f2f2;}  .ansel_btns {position: absolute;bottom:0;border-top:1px solid #f2f2f2;background:#fff;width:100%;height:50px;line-height: 50px;z-index: 19951024;}  .ansel_btns .ansel_btnss {width:220px;margin:10px auto;overflow:hidden}  .ansel_btns .ansel_btnss .ansel_btn {height:30px;line-height: 30px;width:100px;text-align: center;font-size:14px;float:left;}  .ansel_btns .ansel_btnss .ansel_ok {background:#09f;color:#fff;margin-right:10px;}  .ansel_btns .ansel_btnss .ansel_no {background:#ccc;color:#222;margin-left:10px;}  .ansel_ul .ansel_li .ansel_check {height:14px;width:14px;display: block;float:left;border-radius: 100%;border:1px solid #ccc;margin:10px 5px 10px 0;box-shadow: 0 0 2px 0 #ccc inset;}  .ansel_ul .ansel_li .ansel_cur {box-shadow: 0 0px 1px 3px #09f inset;border: 1px solid #09f; }';
            var cssEle = document.createElement("style");
            cssEle.type = "text/css";
            cssEle.appendChild(document.createTextNode(cssHtm));
            document.getElementsByTagName("head")[0].appendChild(cssEle);
            if($(this).length <= 0){
                return false;
            }
            return $(this).each(function(){
                var _this=$(this),_val,_txt,isval=_this.attr('isval') || 'false', msg=_this.attr('msg') || '选择数据';
                _this.hide().before('<div class="ansel_input"><input class="ansel_inputval" placeholder="'+msg+'" readonly></div>')
                _this.before('<div class="ansel_select">' +
                    '<div class="ansel_search"><input class="ansel_search_input" placeholder="搜索"></div>' +
                    '<div class="ansel_ul">' +
                    '</div>' +
                    '<div class="ansel_btns">' +
                    '<div class="ansel_btnss">' +
                    '<div class="ansel_btn ansel_ok">确定</div>' +
                    '<div class="ansel_btn ansel_no">关闭</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>');
                var ansel_select= _this.prev(".ansel_select"),
                    ansel_ul=_this.prev(".ansel_select").children(".ansel_ul"),
                    ansel_inputval=ansel_select.prev(".ansel_input").children(".ansel_inputval"),
                    ansel_btns=ansel_select.find('.ansel_btns > .ansel_btnss'),
                    ansel_btn_ok=ansel_btns.children('.ansel_ok'),
                    ansel_btn_no=ansel_btns.children('.ansel_no'),
                    ansel_search_input=ansel_select.find('.ansel_search > input');
                ansel_ul.empty();
                _this.find("option").each(function (index, el) {
                    var _li = $('<div class="ansel_li" val="'+$(el).val()+'"><span class="ansel_check"></span>'+$(el).text()+'</div>');
                    if ($(el).prop("selected")) {
                        _li.children('.ansel_check').addClass("ansel_cur");
                        ansel_inputval.val($(el).text());
                    }
                    ansel_ul.append(_li);
                });
                ansel_ul.children(".ansel_li").click(function(){
                    $(this).parent().find('.ansel_check').removeClass('ansel_cur');
                    $(this).children('.ansel_check').addClass('ansel_cur');
                    _val=$(this).attr('val');
                    _txt=$(this).text();
                });
                ansel_btn_no.click(function(){
                    ansel_select.hide();
                });
                ansel_btn_ok.click(function(){
                    if(isval=='true'){
                        _val=ansel_ul.children('.ansel_li').find('.ansel_cur').parent('.ansel_li').attr('val');
                        if(!_val){
                            return false;
                        }
                    }
                    _txt=ansel_ul.children('.ansel_li').find('.ansel_cur').parent('.ansel_li').text();
                    _this.val(_val);
                    ansel_inputval.val(_txt);
                    ansel_select.hide(100);
                });
                ansel_select.prev(".ansel_input").click(function(){
                    $('.ansel_select').hide();
                    ansel_search_input.val('');
                    $(this).next().show();
                    ansel_ul.children(".ansel_li").show();
                    var m_height=ansel_select.height();
                    var h_height=55;
                    var b_height=49;
                    var c_height=ansel_select.height()-h_height-b_height;
                    ansel_ul.css("height",c_height+"px");
                });
                ansel_search_input.on('input propertychange',function(){
                    var result = $.trim($(this).val());
                    if(result){
                        ansel_ul.children(".ansel_li").hide().filter(":contains('"+result+"')").show();
                    }else{
                        ansel_ul.children(".ansel_li").show();
                    }
                });
            });
        }
    })
})(jQuery);

