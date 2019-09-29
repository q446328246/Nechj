//JELY 20130628完成一个基于jquery的区域选择插件
(function($) {
	$.LocationSelect = {
		defaults : {
				data: "areas.json",
				autoDetect : false
		},
		build : function(user_opts) {
			var options = $.extend($.LocationSelect.defaults, user_opts);
			return $(this).each(function() {
				var specs = {
					holder : $(this),
					selectors: {},
					opts : options
				};
				specs.holder.append('<font color="red">*</font><select name="province" class="selectarea"><option value="0">请选择省市</option></select>&nbsp;&nbsp;市：<select name="city" style="width:120px;" class="selectarea"><option value="0">请选择城市</option></select>&nbsp;&nbsp;区：<select name="district" style="width:120px;" class="selectarea"><option value="0">请选择区域</option></select>');
				try{
					$.LocationSelect.init(specs);
				} catch(e) {
					setTimeout(function() {$.LocationSelect.init(specs);},1000);
				}
			});
		},
		data : {
			province : [],
			city: [],
			district: []
		},
		init: function(specs){
		    specs.selectors.province = specs.holder.find("select[name='province']");
		    specs.selectors.city = specs.holder.find("select[name='city']");
		    specs.selectors.district = specs.holder.find("select[name='district']");
		    $.each(Json_vj,function(i){
			    $.LocationSelect.data.province = Json_vj["province"];
			    $.LocationSelect.data.city = Json_vj["city"];
			    $.LocationSelect.data.district= Json_vj["district"];
			    $(specs.selectors.province).change(function(evt){
			        if(evt.target.value=="0"){specs.selectors.city.html('<option value="0">请选择城市</option>');
			        specs.selectors.district.html('<option value="0">请选择区域</option>');}else{fetch(evt.target);}
			    });
			    $.each($.LocationSelect.data.province, function(i, item){
			        var str = "<option value='" + item.code + "'>" + item.name + "</option>";
			        specs.selectors.province.append(str);
			    });
			    $(specs.selectors.city).change(function(evt){
			        if(evt.target.value=="0"){specs.selectors.district.html('<option value="0">请选择区域</option>');}
			        else{ fetch(evt.target);}
			    });
			});
			
		    function fetch(target){
		        var _start, _result = new Array(),  _d, _s,  _o,  n = target.value;
		        if (target.value.length == 3) {
		            _start = n.substring(0, 3);_s = specs.selectors.city;_d = $.LocationSelect.data.city;
		        }
		        else
		        {
		            _s = specs.selectors.district;
		            _start = n.substring(0, 6);
		            _d = $.LocationSelect.data.district;
		        }
		        
		        $(_s).find("option[value!='0']").remove();
		        if (_o) 
		            $(_s).append(_o);
		        $.each(_d, function(i, item){
		            if (item.code.startsWith(_start)) {
		                _result.push(item);
		            }
		        });
		        $.each(_result, function(i, item){
		            var str = "<option value='" + _result[i].code + "'>" + _result[i].name + "</option>";
		            $(_s).append(str);
		        });
		    };
		},
		get: function(){
		    var holder = $(this),
		    	province = holder.find("select[name='province']"),
		    	city = holder.find("select[name='city']"),
		    	district= holder.find("select[name='district']"),
		    	info = {
		        "province": province.val() == 0 ? "" : province[0].options[province[0].selectedIndex].text,
				"pcode": province.val()==""?"":province.val(),
		        "city": city.val() == 0 ? "" : city[0].options[city[0].selectedIndex].text,
				"ccode": city.val()==""?"":city.val(),
				"district": district.val() == 0 ? "" : district[0].options[district[0].selectedIndex].text,
				"dcode": district.val()==""?"":district.val()
		    };
		    return info;
		}
	}
	
	$.fn.LocationSelect = $.LocationSelect.build;
	$.fn.getLocation = $.LocationSelect.get;
	
	if (!String.prototype.startsWith) {
	    String.prototype.startsWith = function(str){
	        if (str) 
	            return this.substring(0, str.length) == str;
	    };
	}
})(jQuery);