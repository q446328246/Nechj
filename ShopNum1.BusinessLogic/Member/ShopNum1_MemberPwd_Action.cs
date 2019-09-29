using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberPwd_Action : IShopNum1_MemberPwd_Action
    {
        public DataTable CheckLink(string pwdkey, string type)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@pwdkey";
            parms[0].Value = pwdkey;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            parms[2].ParameterName = "@now";
            parms[2].Value = DateTime.Now;
            return
                DatabaseExcetue.ReturnDataTable((((string.Empty + " select * from  ShopNum1_MemberPwd ") +
                                                  " where type=@type") + "   and pwdkey=@pwdkey") +
                                                "   and extireTime>@DateTime.Now",parms);
        }

        public int MemberPwdInsert(ShopNum1_MemberPwd MemberPwd)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@pwdkey";
            paraValue[0] = MemberPwd.pwdkey;
            paraName[1] = "@memberid";
            paraValue[1] = MemberPwd.MemberID;
            paraName[2] = "@pwd";
            paraValue[2] = MemberPwd.Pwd;
            paraName[3] = "@email";
            paraValue[3] = MemberPwd.Email;
            paraName[4] = "@extiretime";
            paraValue[4] = MemberPwd.extireTime.ToString();
            paraName[5] = "@type";
            paraValue[5] = MemberPwd.type.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_MemberPwdInsert", paraName, paraValue);
        }

        public DataTable ShopNum1MemberPwdExec(string pwdkey, string type)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@pwdkey";
            paraValue[0] = pwdkey;
            paraName[1] = "@type";
            paraValue[1] = type;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberPwdExec", paraName, paraValue);
        }

        public int UpdatePwd(string pwdkey, string type, string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@pwdkey";
            parms[0].Value = pwdkey;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            parms[2].ParameterName = "@string_0";
            parms[2].Value = string_0;
            return
                DatabaseExcetue.RunNonQuery(((string.Empty + " update ShopNum1_MemberPwd set pwd=@string_0") +
                                             " where type=@type") + "   and pwdkey=@pwdkey",parms);
        }
    }
}