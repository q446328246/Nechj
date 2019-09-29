using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberEmailExec_Action : IShopNum1_MemberEmailExec_Action
    {
        public int MemberEmailExec(string Emailkey, string Type)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@Emailkey";
            paraValue[0] = Emailkey;
            paraName[1] = "@Type";
            paraValue[1] = Type;
            return DatabaseExcetue.RunProcedure("proc_ShopNum1_MemberEmailExec", paraName, paraValue);
        }

        public int MemberEmailInsert(ShopNum1_MemberEmailExec MemberEmailExec)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@Guid";
            paraValue[0] = MemberEmailExec.Guid.ToString();
            paraName[1] = "@Emailkey";
            paraValue[1] = MemberEmailExec.Emailkey;
            paraName[2] = "@MemberID";
            paraValue[2] = MemberEmailExec.MemberID;
            paraName[3] = "@Email";
            paraValue[3] = MemberEmailExec.Email;
            paraName[4] = "@Phone";
            paraValue[4] = MemberEmailExec.Phone;
            paraName[5] = "@ExtireTime";
            paraValue[5] = MemberEmailExec.ExtireTime.ToString();
            paraName[6] = "@Isinvalid";
            paraValue[6] = MemberEmailExec.Isinvalid.ToString();
            paraName[7] = "@Type";
            paraValue[7] = MemberEmailExec.Type.ToString();
            return DatabaseExcetue.RunProcedure("proc_ShopNum1_MemberEmailInsert", paraName, paraValue);
        }

        public int MemberMobileExec(string Emailkey, string Type)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@Emailkey";
            paraValue[0] = Emailkey;
            paraName[1] = "@Type";
            paraValue[1] = Type;
            return DatabaseExcetue.RunProcedure("proc_ShopNum1_MemberMobileExec", paraName, paraValue);
        }

        public DataTable CheckLink(string Emailkey, string type)
        {
            return
                DatabaseExcetue.ReturnDataTable((((string.Empty + " select * from  ShopNum1_MemberEmailExec ") +
                                                  " where Type=" + type) + "   and Emailkey='" + Emailkey + "'") +
                                                "   and extireTime>'" + DateTime.Now + "'");
        }
    }
}