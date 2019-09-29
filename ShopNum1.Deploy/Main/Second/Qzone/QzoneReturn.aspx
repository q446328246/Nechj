<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title></title>
        <script type="text/javascript">
            window.setTimeout(function() {
                var url = window.location.href;
                var access_token = url.substring(url.indexOf('#access_token=') + 14, url.indexOf('&'));
                window.location.href = '/threelogin.aspx?type=1&access_token=' + access_token;
            }, 1);
        </script>
    </head>
    <body>
    </body>
</html>