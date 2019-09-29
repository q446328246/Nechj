function   getByte(str)
{
        tempstr=str.replace(/[\x00-\xff]/g,   "a ");
        tempstr=tempstr.replace(/[\uff61-\uff9f]/g,   "a ");//半角片假文
        tempstr=tempstr.replace(/[\u3041-\u309f]/g,   "aa ");//全角平假文
        tempstr=tempstr.replace(/[\u30a0-\u30ff]/g,   "aa ");//全角片假文
        tempstr=tempstr.replace(/[^\x61-\x61]/g,   "aa ");
        return   tempstr.length;
}

function   subbytestring(str,   len)
{
        var   i   =   0;
        var   rtnStr   =   " ";
        var   subStr   =   " ";
        for(i   =   0;   i   <   getByte(str);   i++)
      {
                subStr   =   str.substr(i,   1);
                if(getByte(subStr)   ==   2   &&   len>=2)
{
        rtnStr   =   rtnStr   +   subStr;
        len   =   len   -   2;
}
else  if   (getByte(subStr)==1&&len> =1)
{
        rtnStr   =   rtnStr   +   subStr;
        len   =   len   -   1;
}
else if   (getByte(subStr) ==2&&len< 2)
{
        break;
}  
else if   (getByte(subStr) ==1&&len<1)
{
        break;
}
        }
        return   rtnStr
}