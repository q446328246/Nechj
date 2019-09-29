using System;
using System.Data;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberMessage_Action : IShopNum1_MemberMessage_Action
    {
        public int Add_MemberMsg(ShopNum1_MemberMessage shopNum1_MemberMessage)
        {
            string format =
                "insert into ShopNum1_MemberMessage(guid,title,content,sendloginid,reloginid)values('{0}','{1}','{2}','{3}','{4}')";
            return
                DatabaseExcetue.RunNonQuery(string.Format(format,
                    new object[]
                    {
                        Guid.NewGuid(), shopNum1_MemberMessage.Title,
                        shopNum1_MemberMessage.Content,
                        shopNum1_MemberMessage.SendLoginID,
                        shopNum1_MemberMessage.ReLoginID
                    }));
        }

        public int Delete_Msg(string strArray)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strArray";
            parms[0].Value = strArray.Replace("'", "");
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_MemberMessage set isdeleted=1 where guid in (@strArray)",parms);
        }

        public DataTable SelectMsg(ShopNum1_MemberMessage shopNum1_MemberMessage)
        {
            string str = "select * from shopNum1_MemberMessage where IsDeleted=0 ";
            Guid guid = shopNum1_MemberMessage.Guid;
            if (shopNum1_MemberMessage.Guid != new Guid("00000000-0000-0000-0000-000000000000"))
            {
                object obj2 = str;
                str = string.Concat(new[] {obj2, " and Guid='", shopNum1_MemberMessage.Guid, "'"});
            }
            if (shopNum1_MemberMessage.IsRead != 2)
            {
                str = str + " and isread=" + shopNum1_MemberMessage.IsRead;
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by sendtime desc");
        }

        public DataTable SelectMsg_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "Guid,isread,sendtime,title";
            paraName[3] = "@tablename";
            paraValue[3] = "shopNum1_MemberMessage";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "sendtime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update_MsgIsRead(string strGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strGuid";
            parms[0].Value = strGuid;
            return DatabaseExcetue.RunNonQuery("update ShopNum1_MemberMessage set isread=1 where guid=@strGuid",parms);
        }
    }
}