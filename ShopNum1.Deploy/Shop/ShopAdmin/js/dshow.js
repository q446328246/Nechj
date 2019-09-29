document.write('<div class="sp_overlay"  style="display:none" id="sp_overlayDiv"></div>');

function funClose() {
    $(".sp_dialog_out").css("display", "none");
    $(".sp_dialog_cont").css("display", "none");
    $(".sp_overlay").css("display", "none");
    $(".showpopone").css("display", "none");
    $(".showpoptwo").css("display", "none");
}

function funOpen() {
    $(".sp_dialog_out").css("display", "block");
    $(".sp_dialog_cont").css("display", "block");
    $(".sp_overlay").css("display", "block");
}

//商品价格格式化方法

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