function adjustStyle(width) {
    width = parseInt(width);
    if (width < 701) {
        $("#sizestylesheet").attr("href", "style/css.css");
    } else if ((width >= 701) && (width < 1025)) {
        $("#sizestylesheet").attr("href", "style/css1.css");
    } else {
        $("#sizestylesheet").attr("href", "style/css.css");
    }
}

$(function() {
    adjustStyle($(this).width());
    $(window).resize(function() {
        adjustStyle($(this).width());
    });
});