/*
1   用法 onkeyup="NumTxt_Int(this)"     限制文本框只能输入数字
2   用法 str.trim()                     去除字符左右空格
3   用法 if(!checkprice(txt)){alert("价格不合法");}  验证价格
4   用法  Template.replaceAll("A","B")   将内容里面包含A的字符全部替换成B
5   用法  compareTime(startTime,endTime) if(!compareTime('2013-09-08','2013-07-30')){alert("开始时间必须小于结束时间！");}
6   用法if(!checkDisCount(txt)){alert("折扣值不合法");}  验证折扣
7   用法  var price=price_format("3.3333333");price格式化后为3.33   用于格式化价格

*/



/*------------------------1------------------------------------*/
//限制文本框只能输入数字  onkeyup="NumTxt_Int(this)"
function NumTxt_Int(o) {
    o.value = o.value.replace(/\D/g, '');
}

/*-----------------------2---------------------------------*/
//删除字符串二边空格
String.prototype.trim = function() {
    return this.replace(/(^[\s]*)|([\s]*$)/g, "");
};
/*-----------------------3----------------------------------------*/
//判断价格是否合法

function checkprice(name) {
    var oo = /^\d{1,10}$|^\d{1,10}\.\d{1,2}\w?$/;
    if (!oo.test(name)) {
        return false;
    } else {
        return true;
    }
}

/*--------------------4-------------------------------------*/
//全部替换
String.prototype.replaceAll = function(reallyDo, replaceWith, ignoreCase) {
    if (!RegExp.prototype.isPrototypeOf(reallyDo)) {
        return this.replace(new RegExp(reallyDo, (ignoreCase ? "gi" : "g")), replaceWith);
    } else {
        return this.replace(reallyDo, replaceWith);
    }
};
/*---------------------5--------------------------------------*/
//时间对比方法

function compareTime(startTime, endTime) {
    var starttimes = startTime.split('-');
    var endtimes = endTime.split('-');
    var starttimeTemp = starttimes[0] + '/' + starttimes[1] + '/' + starttimes[2];
    var endtimesTemp = endtimes[0] + '/' + endtimes[1] + '/' + endtimes[2];

    if (Date.parse(new Date(starttimeTemp)) < Date.parse(new Date(endtimesTemp))) {
        return true;
    } else {
        return false;
    }
}

/*----------------------6---------------------------------------*/
//检查折扣值是否合法

function checkDisCount(name) {
    var oo = /^\d{0.1,1.0}$|^0\.\d{1,10}\w?$/;
    if (!oo.test(name)) {
        return false;
    } else {
        return true;
    }
}

/*--------------------7---------------------------------*/
/* 格式化金额 */

function price_format(price) {
    if (typeof(PRICE_FORMAT) == 'undefined') {
        PRICE_FORMAT = '&yen;%s';
    }
    price = number_format(price, 2);

    return PRICE_FORMAT.replace('%s', price);
}

function number_format(num, ext) {
    if (ext < 0) {
        return num;
    }
    num = Number(num);
    if (isNaN(num)) {
        num = 0;
    }
    var _str = num.toString();
    var _arr = _str.split('.');
    var _int = _arr[0];
    var _flt = _arr[1];
    if (_str.indexOf('.') == -1) {
        /* 找不到小数点，则添加 */
        if (ext == 0) {
            return _str;
        }
        var _tmp = '';
        for (var i = 0; i < ext; i++) {
            _tmp += '0';
        }
        _str = _str + '.' + _tmp;
    } else {
        if (_flt.length == ext) {
            return _str;
        }
        /* 找得到小数点，则截取 */
        if (_flt.length > ext) {
            _str = _str.substr(0, _str.length - (_flt.length - ext));
            if (ext == 0) {
                _str = _int;
            }
        } else {
            for (var i = 0; i < ext - _flt.length; i++) {
                _str += '0';
            }
        }
    }

    return _str;
}

//获取url参数值

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]);
    return null;
}


//空值判断

function CheckNull(i, j) {
    var a = $(i).val();
    if (a == "") {
        //i 的下一个 ，需要 span 标签，用于信息提示
        $(i).next().text(j);
        return false;
    } else {
        $(i).next().text(" *");
        return true;
    }
}

;