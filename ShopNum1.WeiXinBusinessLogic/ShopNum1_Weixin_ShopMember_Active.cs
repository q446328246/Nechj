using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.WeiXinCommon.model;
using ShopNum1.WeiXinInterface;

namespace ShopNum1.WeiXinBusinessLogic
{
    public class ShopNum1_Weixin_ShopMember_Active : IShopNum1_Weixin_ShopMember_Active
    {
        public bool AddWeiXinMember(string ShopMemLoginID, string UsrWeiXinID, string ShopWeiXinId, UserModel usermdl)
        {
            return
                (DatabaseExcetue.RunNonQuery(
                    string.Format(
                        "if(select ShopWeiXinId from dbo.ShopNum1_Weixin_ShopWeiXinConfig where ShopMemLoginID = '{0}')=''\r\n                                            begin\r\n\t                                            update dbo.ShopNum1_Weixin_ShopWeiXinConfig set ShopWeiXinId ='{2}' where ShopMemLoginID = '{0}'\r\n                                            end\r\n                                            if\t(select count(1) from dbo.ShopNum1_Member where MemLoginID = '{1}')=0\r\n                                            begin\r\n                                                INSERT INTO dbo.ShopNum1_Member\r\n                                                        ( Guid ,\r\n                                                          Name ,\r\n                                                          MemLoginID ,\r\n                                                          Email ,\r\n                                                          Tel ,\r\n                                                          Pwd ,\r\n                                                          PayPwd ,\r\n                                                          IsForbid ,\r\n                                                          MemberType ,\r\n                                                          AddressCode ,\r\n                                                          AddressValue ,\r\n                                                          Score ,\r\n                                                          RegeDate ,\r\n                                                          LoginDate ,\r\n                                                          MemberRank ,\r\n                                                          LastLoginIP ,\r\n                                                          LoginTime ,\r\n                                                          AdvancePayment ,\r\n                                                          LockAdvancePayment ,\r\n                                                          LockSocre ,\r\n                                                          CostMoney ,\r\n                                                          IsDeleted ,\r\n                                                          LastLoginDate ,\r\n                                                          IdentityCard ,\r\n                                                          RealName ,\r\n                                                          AlipayNumber ,\r\n                                                          IdentityCardBackImg ,\r\n                                                          IdentityCardImg ,\r\n                                                          IdentificationIsAudit ,\r\n                                                          IdentificationTime ,\r\n                                                          AuditFailedReason ,\r\n                                                          IsMailActivation,\r\n                                                          MemberRankGuid\r\n                                                        )\r\n                                                VALUES  (\r\n                                                       \r\n                                                         NEWID() , -- Guid - uniqueidentifier\r\n                                                          N'' , -- Name - nvarchar(50)\r\n                                                          '{1}' , -- MemLoginID - nvarchar(50)\r\n                                                          N'', -- Email - nvarchar(100)\r\n                                                          N'' , -- Tel - nvarchar(25)\r\n                                                          '{12}', -- Pwd - nvarchar(250)\r\n                                                          '{13}' , -- PayPwd - nvarchar(250)\r\n                                                          0 , -- IsForbid - int\r\n                                                          1 , -- MemberType - int\r\n                                                          '' , -- AddressCode - varchar(9)\r\n                                                          N'' , -- AddressValue - nvarchar(50)\r\n                                                          10 , -- Score - int\r\n                                                          getdate() , -- RegeDate - datetime\r\n                                                          getdate() , -- LoginDate - datetime\r\n                                                          0 , -- MemberRank - int\r\n                                                          N'' , -- LastLoginIP - nvarchar(25)\r\n                                                          0 , -- LoginTime - int\r\n                                                          0 , -- AdvancePayment - decimal\r\n                                                          0 , -- LockAdvancePayment - decimal\r\n                                                          0 , -- LockSocre - int\r\n                                                          0 , -- CostMoney - decimal\r\n                                                          0 , -- IsDeleted - tinyint\r\n                                                          getdate() , -- LastLoginDate - datetime\r\n                                                          N'' , -- IdentityCard - nvarchar(50)\r\n                                                          N'' , -- RealName - nvarchar(50)\r\n                                                          N'' , -- AlipayNumber - nvarchar(100)\r\n                                                          N'' , -- IdentityCardBackImg - nvarchar(250)\r\n                                                          N'' , -- IdentityCardImg - nvarchar(250)\r\n                                                          0 , -- IdentificationIsAudit - int\r\n                                                          getdate() , -- IdentificationTime - datetime\r\n                                                          N'' , -- AuditFailedReason - nvarchar(500)\r\n                                                          0,  -- IsMailActivation - int\r\n                                                          'a6da75ad-e1ac-4df8-99ad-980294a16581'\r\n                                                        )\r\n                                            end\r\n                                            else\r\n                                            begin\r\n                                                update dbo.ShopNum1_Member set IsDeleted = 0 , IsForbid = 0 where MemLoginID = '{1}'\r\n                                            end\r\n                                            if (select count(1) from dbo.ShopNum1_Weixin_ShopMember where ShopMemLoginId='{0}' and MemLoginId = '{1}')=0\r\n                                            begin\r\n\t                                            insert dbo.ShopNum1_Weixin_ShopMember(ShopMemLoginId,MemLoginId,[Group],[nickname],[sex],[language],[city],[province],[country],[headimgurl],[subscribe_time])\r\n                                                values('{0}','{1}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')\r\n                                            end\r\n                                            else\r\n                                            begin\r\n\t                                            UPDATE [dbo].[ShopNum1_Weixin_ShopMember]\r\n                                                SET [Group] ='{3}',[nickname] = '{4}',[sex] = '{5}',[language] = '{6}',[city] = '{7}',[province] = '{8}',[country] = '{9}',[headimgurl] = '{10}',[subscribe_time] = '{11}'\r\n                                                WHERE [MemLoginId] ='{1}'\r\n                                            end",
                        new object[]
                        {
                            ShopMemLoginID, UsrWeiXinID, ShopWeiXinId, 0, usermdl.nickname, usermdl.sex,
                            usermdl.language, usermdl.city, usermdl.province, usermdl.country, usermdl.headimgurl,
                            usermdl.subscribe_time, Encryption.GetMd5Hash("123456"),
                            Encryption.GetMd5SecondHash("123456")
                        })) > 0);
        }

        public bool ChangeVipGroup(string shopowner, string vips, int group)
        {
            return
                (DatabaseExcetue.RunNonQuery(
                    string.Format(
                        "update ShopNum1_Weixin_ShopMember set [group] = '{2}'  where ShopMemLoginId = '{0}' and MemLoginId in({1})",
                        shopowner, vips, group)) > 0);
        }

        public DataTable GetShopMemByShopOwner(string shopowner)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format(
                        "select ShopMemLoginId,MemLoginId,Group,[nickname],[sex],[language],[city],[province],[country],[headimgurl],[subscribe_time] from ShopNum1_Weixin_ShopMember where ShopMemLoginId = '{0}'",
                        shopowner));
        }

        public DataTable SelectActivity(string pagesize, string currentpage, string condition, string resultnum)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = pagesize;
            paraName[1] = "@currentpage";
            paraValue[1] = currentpage;
            paraName[2] = "@columns";
            paraValue[2] = "*";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Weixin_ShopMember";
            paraName[4] = "@condition";
            paraValue[4] = condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "id,[Group]";
            paraName[6] = "@sortvalue";
            paraValue[6] = "asc";
            paraName[7] = "@resultnum";
            paraValue[7] = resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager", paraName, paraValue);
        }
    }
}