using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShopNum1.BusinessLogic
{

    public class ShopNum1_Member_Action : IShopNum1_Member_Action
    {
        public int AgreeSave(string savecode)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@savecode";
            paraValue[0] = savecode;
 
            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set issave=1 where savecode=@savecode", paraName, paraValue);
        }
        public int ApplySave(string MemLoginID, string saveid, string savecode)
        {
            int res = 0;
            if (AnySave(saveid) == 1)
            {
                res = -1;
            }
            else {
                var paraName = new string[3];
                var paraValue = new string[3];
                paraName[0] = "@MemLoginID";
                paraValue[0] = MemLoginID;
                paraName[1] = "@saveid";
                paraValue[1] = saveid;
                paraName[2] = "@savecode";
                paraValue[2] = savecode;
                return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set saveid=@saveid,savecode=@savecode where MemLoginId=@MemLoginID", paraName, paraValue);
            }
       
            return res;
        }

        public int AnySave(string saveid) {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@saveid";
            parms[0].Value = saveid;
            string strSql = string.Empty;
            strSql ="SELECT count(1) FROM ShopNum1_Member where (saveid=@saveid)";
            string res = DatabaseExcetue.ReturnDataTable(strSql, parms).Rows[0][0].ToString();
            if (res == "1")
            {
                return 1;
            }
            else {
                return 0;
            }
        }


    public DataTable GetSaveInfo(string memLoginID)
    {
        DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

        parms[0].ParameterName = "@memLoginID";
        parms[0].Value = memLoginID;
        string strSql = string.Empty;
        strSql =
            "SELECT * FROM ShopNum1_Member where (MemLoginID=@memLoginID or Mobile=@memLoginID)";

        return DatabaseExcetue.ReturnDataTable(strSql, parms);
    }



    public bool SelectInShouYi(string MemLoginID)
        {
            try
            {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
                parms[0].ParameterName = "@MemLoginID";
                parms[0].Value = MemLoginID;
                DataTable dt = DatabaseExcetue.ReturnDataTable("select top 1 count(*) from V_Newyili where MemLoginID=@MemLoginID ;", parms);
                if (int.Parse(dt.Rows[0][0].ToString()) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        public DataTable TiBiZQList(string MemLoginID, string RenType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@RenType";
            parms[1].Value = RenType;
            return DatabaseExcetue.ReturnDataTable("select * from TibiZQ where MemLoginID=@MemLoginID and RenType=@RenType and DateDiff(dd,AddTime,getdate())<=7 ORDER BY AddTime desc;", parms);
        }


        public int Add_TibiZQ(string MemLoginID, decimal NEC, string NECAddress, int Status, string RenType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@NEC";
            parms[1].Value = NEC;
            parms[2].ParameterName = "@NECAddress";
            parms[2].Value = NECAddress;
            parms[3].ParameterName = "@Status";
            parms[3].Value = Status;
            parms[4].ParameterName = "@RenType";
            parms[4].Value = RenType;
            return DatabaseExcetue.RunNonQuery(" insert into TibiZQ(MemLoginID,NEC,NECAddress,Status,AddTime,RenType) values(@MemLoginID,@NEC,@NECAddress,@Status,GETDATE(),@RenType)", parms);
        }

        public int Add_Nec_RenRenZZ(string MemLoginID, decimal NEC, string ChongZhiID, int Status, string RenType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@NEC";
            parms[1].Value = NEC;
            parms[2].ParameterName = "@ChongZhiID";
            parms[2].Value = ChongZhiID;
            parms[3].ParameterName = "@Status";
            parms[3].Value = Status;
            parms[4].ParameterName = "@RenType";
            parms[4].Value = RenType;
            return DatabaseExcetue.RunNonQuery(" insert into Nec_RenRenZZ(MemLoginID,NEC,ChongZhiID,Status,AddTime,RenType) values(@MemLoginID,@NEC,@ChongZhiID,@Status,GETDATE(),@RenType)", parms);
        }

        public DataTable RenRenZZList(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return DatabaseExcetue.ReturnDataTable("select * from Nec_RenRenZZ where MemLoginID=@MemLoginID and DateDiff(dd,AddTime,getdate())<=7 ORDER BY AddTime desc;", parms);
        }











        public int AddWHJ_BlackList(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return DatabaseExcetue.RunNonQuery("  insert into WHJ_BlackList(BLID) values(@MemLoginID)", parms);
        }


        public int DelWHJ_BlackList(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return DatabaseExcetue.RunNonQuery("  DELETE from WHJ_BlackList where BLID=@MemLoginID", parms);
        }


        /// <summary>
        /// 黑名单
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable SelectWHJ_BlackList(string kkkk = "")
        {

            string strSql = string.Empty;
            if (kkkk == "" || kkkk == null)
            {
                strSql = "select * from WHJ_BlackList";
            }
            else
            {
                strSql = "select * from WHJ_BlackList where BLID like '%" + kkkk + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }


        /// <summary>
        /// 查询用户交易所NEC充值记录
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable SelectNecChongZhi(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT  MemLoginID,[Texthash],[Toaddr],[Fromaddr],Time,[Addtime],[Counts],a.[Status] FROM Nec_ChongZhi as a left join Shopnum1_Member as b on b.NECAddress=a.Toaddr where b.MemLoginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }


        /// <summary>
        /// 查询用户申请商家状态
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable Select_All_ShenQingStatus(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT top 1 Status  FROM [Nec_ShenQinShangJia] where MemloginID=@memLoginID order by ID desc";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }


        /// <summary>
        /// 查询旷工费
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public string SelectKGFPrice()

        {



            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@1";
            parms[0].Value = "1";
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM Nec_KGF where 1=@1", parms).Rows[0]["KuangGongFei"].ToString();

        }


        /// <summary>
        /// 查询币种表
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable SelectBiZongPrice()
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@1";
            parms[0].Value = "1";
            string strSql = string.Empty;
            strSql =
                "SELECT * FROM Nec_BiBi where 1=@1";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        /// <summary>
        /// 添加申请商家申请列表
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="Name"></param>
        /// <param name="CardID"></param>
        /// <param name="shopName"></param>
        /// <param name="CardAndPeopleImage"></param>
        /// <param name="LicenseImage"></param>
        /// <returns></returns>
        public int AddApplyBusiness(string MemLoginID, string Name, string CardID, string shopName, string CardAndPeopleImage, string LicenseImage, string FanCardImage)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(7);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Name";
            parms[1].Value = Name;
            parms[2].ParameterName = "@CardID";
            parms[2].Value = CardID;
            parms[3].ParameterName = "@shopName";
            parms[3].Value = shopName;
            parms[4].ParameterName = "@CardAndPeopleImage";
            parms[4].Value = CardAndPeopleImage;
            parms[5].ParameterName = "@LicenseImage";
            parms[5].Value = LicenseImage;
            parms[6].ParameterName = "@FanCardImage";
            parms[6].Value = FanCardImage;
            return DatabaseExcetue.RunNonQuery("  insert into Nec_ShenQinShangJia(Status,MemloginID,RealName,CardID,ShopName,CardAndPeopleImage,LicenseImage,FanCardImage) values(0,@MemLoginID,@Name,@CardID,@shopName,@CardAndPeopleImage,@LicenseImage,@FanCardImage)", parms);
        }


        /// <summary>
        /// 查询用户有没有在申请商家的申请列表
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable Select_All_ShenQing(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT top 1 * FROM [Nec_ShenQinShangJia] where Status=0 and MemloginID=@memLoginID order by ID desc";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }


        /// <summary>
        /// 通过ID查询这个人所有租赁订单总额
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable Select_All_ZuLinPrice(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT SUM(ShouldPayPrice) as zongPrice FROM [ShopNum1_OrderInfo] where OderStatus=1 and MemloginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable ETH_TxTable(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT * FROM Nec_TiXian where IsDeleted=0 and MemloginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public int AddNEC_Tx(string OrderID, string memloginid, string NECaddress, decimal NEC, DateTime txtime, string shopNECaddress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(6);
            parms[0].ParameterName = "@OrderID";
            parms[0].Value = OrderID;
            parms[1].ParameterName = "@memloginid";
            parms[1].Value = memloginid;
            parms[2].ParameterName = "@NECaddress";
            parms[2].Value = NECaddress;
            parms[3].ParameterName = "@NEC";
            parms[3].Value = NEC;
            parms[4].ParameterName = "@txtime";
            parms[4].Value = txtime;
            parms[5].ParameterName = "@shopNECaddress";
            parms[5].Value = shopNECaddress;

            return DatabaseExcetue.RunNonQuery("insert into Nec_TiXianNEC(OrderID,MemloginID,NECAddress,NEC,Status,TxTime,Shop_NECAddress) values(@OrderID,@memloginid,@NECaddress,@NEC,0,@txtime,@shopNECaddress)", parms);
        }

        public int AddETH_Tx(string OrderID, string memloginid, string ETHaddress, decimal ETH, DateTime txtime, string shopETHaddress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(6);
            parms[0].ParameterName = "@OrderID";
            parms[0].Value = OrderID;
            parms[1].ParameterName = "@memloginid";
            parms[1].Value = memloginid;
            parms[2].ParameterName = "@ETHaddress";
            parms[2].Value = ETHaddress;
            parms[3].ParameterName = "@ETH";
            parms[3].Value = ETH;
            parms[4].ParameterName = "@txtime";
            parms[4].Value = txtime;
            parms[5].ParameterName = "@shopETHaddress";
            parms[5].Value = shopETHaddress;

            return DatabaseExcetue.RunNonQuery("insert into Nec_TiXian(OrderID,MemloginID,ETHAddress,ETH,Status,TxTime,Shop_ETHAddress) values(@OrderID,@memloginid,@ETHaddress,@ETH,0,@txtime,@shopETHaddress)", parms);
        }
        public DataTable SearchSuperior(string memLoginID, bool isadmin = false)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = "SELECT RecoCode FROM ShopNum1_Member where MemLoginID=@memLoginID";
            if (!isadmin)
            {
                strSql = strSql + " and MemLoginID not in(SELECT BLID from WHJ_BlackList) ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SearchSuperiorMemloginID(string RecoCode, bool isadmin = false)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@RecoCode";
            parms[0].Value = RecoCode;
            string strSql = string.Empty;
            strSql =
                "SELECT MemLoginID FROM ShopNum1_Member where ID=@RecoCode";
            if (!isadmin)
            {
                strSql = strSql + " and MemLoginID not in(SELECT BLID from WHJ_BlackList) ";
            }

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public int AddETHAddress(string memloginid, string ethaddress)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@ethaddress";
            paraValue[1] = ethaddress;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set ETHAddress=@ethaddress where MemLoginId=@memloginid", paraName, paraValue);
        }



        public DataTable QueryKtTHv(string MemLoginID, string type, string GatheringOrTransferAccountsType, int top, int number)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            if (type == "1")
            {
                return
                    DatabaseExcetue.ReturnDataTable("  select * from ( select * from ( select [OperateMoney],[Date],[Memo] as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID='55667788' and MemLoginID=@MemLoginID  and type in(3))as a where RowNumber BETWEEN @top and @number  )as a where RowNumber BETWEEN @top and @number ", parms);
            }
            else
            {
                if (GatheringOrTransferAccountsType == "2")
                {
                    return
                       DatabaseExcetue.ReturnDataTable("  select * from (   select * from ( select [OperateMoney],[Date],[Memo] as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and  type in(3))as a where RowNumber BETWEEN @top and @number  )as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else
                {
                    return
                      DatabaseExcetue.ReturnDataTable("  select * from (   select * from ( select [OperateMoney],[Date],[Memo] as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID!='55667788' and MemLoginID=@MemLoginID and  type in(3))as a where RowNumber BETWEEN @top and @number  )as a where RowNumber BETWEEN @top and @number ", parms);
                }

            }

        }
        public DataTable QueryKtTHvCount(string MemLoginID, string type, int top, int number)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("  select * from ( select MemLoginID,IdentityCard,RealName,Superior,Mobile,RegeDate,Photo,membership_Level,Name, ROW_NUMBER() OVER( Order by RegeDate DESC ) AS RowNumber from [ShopNum1_Member] where Superior =@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

        }
        public DataTable SearchMemverCountByRecod(string memLoginID, string Recod)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = "SELECT * FROM   [ShopNum1_Member] WHERE [RecoCode] LIKE '" + Recod + "%' AND MemLoginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SearchPeiZhi()
        {

            string strSql = string.Empty;
            strSql =
                "SELECT * FROM ShopNum_PeiZhi";

            return DatabaseExcetue.ReturnDataTable(strSql);
        }
        public DataTable SelectOrderInfoShipmentStatus(string MemLoginID, string ShipmentStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@ShipmentStatus";
            parms[1].Value = ShipmentStatus;


            string strSql = string.Empty;
            strSql = "SELECT * FROM [ShopNum1_OrderInfoTwo] WHERE OderStatus=1 AND ShipmentStatus=@ShipmentStatus AND MemLoginID=@MemLoginID";


            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public int AdminBili(string memloginid, decimal ZaiBi)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@ZaiBi";
            paraValue[1] = ZaiBi.ToString(); ;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set ZaiBi=@ZaiBi where MemLoginId=@memloginid", paraName, paraValue);
        }
        public int ShopBili(string memloginid, decimal bili)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@bili";
            paraValue[1] = bili.ToString();


            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set ShopBili=@bili where MemLoginId=@memloginid", paraName, paraValue);
        }
        public int updateRecoMember(string memloginid, string RecoMember)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@RecoMember";
            paraValue[1] = RecoMember;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set RecoMember=@RecoMember where MemLoginId=@memloginid", paraName, paraValue);
        }
        public int updateRecoCode(string memloginid, string RecoCode)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@RecoCode";
            paraValue[1] = RecoCode;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set RecoCode=@RecoCode where MemLoginId=@memloginid", paraName, paraValue);
        }


        //闲时游接口用
        public int PreTransfer_GZ(string OrderNumber, string CNY, string Memo, string MemLoginID, string Type)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;
            parms[1].ParameterName = "@HV";
            parms[1].Value = CNY;
            parms[2].ParameterName = "@Memo";
            parms[2].Value = Memo;
            parms[3].ParameterName = "@MemLoginID";
            parms[3].Value = MemLoginID;
            parms[4].ParameterName = "@Type";
            parms[4].Value = Type;

            string sqlQuery = string.Concat(new object[]
                {
                "INSERT INTO [ShopNum1_PreTransfer] ([Guid],[OrderNumber],[OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID],[OperateStatus],[IsDeleted],[type]) VALUES(NEWID(),@OrderNumber,@HV,GETDATE(),@Memo,@MemLoginID,@MemLoginID,1,0,@Type)"

                });

            return DatabaseExcetue.RunNonQuery(sqlQuery, parms);
        }
        //KT转账用
        public int PreTransfer_GZ(string OrderNumber, string CNY, string Memo, string MemLoginID, string ReMemLoginID, string Type)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(6);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;
            parms[1].ParameterName = "@HV";
            parms[1].Value = CNY;
            parms[2].ParameterName = "@Memo";
            parms[2].Value = Memo;
            parms[3].ParameterName = "@MemLoginID";
            parms[3].Value = MemLoginID;
            parms[4].ParameterName = "@Type";
            parms[4].Value = Type;
            parms[5].ParameterName = "@ReMemLoginID";
            parms[5].Value = ReMemLoginID;

            string sqlQuery = string.Concat(new object[]
                {
                "INSERT INTO [ShopNum1_PreTransfer] ([Guid],[OrderNumber],[OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID],[OperateStatus],[IsDeleted],[type]) VALUES(NEWID(),@OrderNumber,@HV,GETDATE(),@Memo,@MemLoginID,@ReMemLoginID,1,0,@Type)"

                });

            return DatabaseExcetue.RunNonQuery(sqlQuery, parms);
        }





        //验证推荐人是否存在
        public DataTable KceYzMember(string memloginid)
        {



            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memloginid;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  *  FROM ShopNum1_Member  WHERE (MemLoginID=@memLoginID or Mobile=@memLoginID)", parms);

        }

        public DataTable TJLBGZYONG(string memloginid)
        {



            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            return
                DatabaseExcetue.ReturnDataTable("select count(*) from ShopNum1_Member  WHERE Superior=@memloginid", parms);

        }
        //验证推荐人是否存在
        public DataTable KceYzReferee(string mobile)
        {



            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginIDorMobile";
            parms[0].Value = mobile;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  MemLoginID  FROM ShopNum1_Member  WHERE (MemLoginID=@memLoginIDorMobile or Mobile=@memLoginIDorMobile)", parms);

        }


        //闲时游接口用
        public int AddGZ_XSY_OrderInfo(GZ_XSY_OrderInfo xsyjk)
        {
            string sqlQuery = string.Concat(new object[]
                {
                "INSERT INTO Gz_XSY_OrderInfo(OrderNumber,MemloginID,Date,bv)VALUES( '", xsyjk.OrderNumber, "','", xsyjk.MemloginID, "','", xsyjk.Date,"',", xsyjk.bv,")"

                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        //添加销售额度明细
        public int AddGZ_XiaoShouE(GZ_XiaoShouE_mingxi xiaoshou)
        {
            string sqlQuery = string.Concat(new object[]
                {
                "INSERT INTO GZ_XiaoShouE(OrderNumber,MemloginID,DateTime,Y_xiaoshoue,ZJ_xiaoshoue,ZJH_xiaoshoue)VALUES( '", xiaoshou.OrderNumber, "','", xiaoshou.MemloginID, "','", xiaoshou.DateTime, "','", xiaoshou.Y_xiaoshoue, "','", xiaoshou.ZJ_xiaoshoue, "', ",xiaoshou.ZJH_xiaoshoue,")"

                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        //添加新销售额度明细
        public int AddGZ_XinEDU(GZ_XinXiaoShouE xiaoshou)
        {
            string sqlQuery = string.Concat(new object[]
                {
                "INSERT INTO GZ_XinXiaoShouE(OrderNumber,MemloginID,DateTime,Y_EDU,ZJ_EDU,ZJH_EDU)VALUES( '", xiaoshou.OrderNumber, "','", xiaoshou.MemloginID, "','", xiaoshou.DateTime, "','", xiaoshou.Y_EDU, "','", xiaoshou.ZJ_EDU, "', ",xiaoshou.ZJH_EDU,")"

                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }
        //A转账B DV
        public int AZhuanB_DV(string taba, string tabb, decimal tabdv, string memo)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@memloginnoA";
            paraName[1] = "@memloginnoB";
            paraName[2] = "@dv";
            paraName[3] = "@mome";
            paraValue[0] = taba;
            paraValue[1] = tabb;
            paraValue[2] = tabdv.ToString();
            paraValue[3] = memo;

            return DatabaseExcetue.RunProcedure("shopnum1_A_zhuan_B_GetDV", paraName, paraValue);
        }
        //验证手机号
        public DataTable YzMemberMobile(string mobile)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@mobile";
            paraValue[0] = mobile;
            return DatabaseExcetue.ReturnDataTable("  select * from [ShopNum1_Member] where Mobile=@mobile", paraName, paraValue);
        }

        //2018-02-09 用户每天只能提现一次
        public DataTable selectTXNUM(string memloginid, string Qday, string Hday)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@Qday";
            paraValue[1] = Qday;
            paraName[2] = "@Hday";
            paraValue[2] = Hday;


            return DatabaseExcetue.ReturnDataTable("  select * from [ShopNum1].[dbo].[ShopNum1_AdvancePaymentApplyLog] where memloginid=@memloginid and date>@Qday and date<@Hday and OrderNumber like '%J%'", paraName, paraValue);
        }

        //6月1号新逻辑  根据用户ID改变店铺状态
        public int UpdatememberZGX1(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [Score_record _pv_a]=[Score_record _pv_a]+1 where MemLoginId=@memloginid", paraName, paraValue);
        }
        //6月1号新逻辑  根据用户ID改变店铺状态
        public int UpdateShopIsDelete(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_ShopInfo set IsDeleted=0 where MemLoginId=@memloginid", paraName, paraValue);
        }
        public int UpdateShop_IsDelete(string memloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;


            return DatabaseExcetue.RunNonQuery("update ShopNum1_ShopInfo set IsDeleted=1 where MemLoginId=@memloginid", paraName, paraValue);
        }
        //6月1号新逻辑  根据用户ID查询他所开店铺
        public DataTable SelectShopOfMemloginid(string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;

            return
                DatabaseExcetue.ReturnDataTable(" select * from  ShopNum1_ShopInfo where MemLoginId= @memloginid", parms);
        }
        //6月1号新逻辑  购买专区5添加最大销售额  20181009修改为新的额度
        public int Update5XSV(string memloginno, decimal sv)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginno;
            decimal score_sv = sv * 4;
            paraName[1] = "@sv";
            paraValue[1] = score_sv.ToString();



            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [FuwuzhanEdu] =[FuwuzhanEdu]+@sv where MemLoginNO=@memloginno", paraName, paraValue);
        }

        public int Update_5XSV(string memloginno, decimal sv)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginno;
            decimal score_sv = sv * 4;
            paraName[1] = "@sv";
            paraValue[1] = score_sv.ToString();



            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [FuwuzhanEdu] =[FuwuzhanEdu]-@sv where MemLoginNO=@memloginno", paraName, paraValue);
        }


        public int UpdateJianXinEDU(string memloginid, decimal cv)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@cv";
            paraValue[1] = cv.ToString();



            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [FuwuzhanEdu] =FuwuzhanEdu-@cv where MemLoginId=@memloginid", paraName, paraValue);
        }


        public int Update5XCV(string memloginid, decimal cv)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@cv";
            paraValue[1] = cv.ToString();



            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [Score_cvv] =Score_cvv+@cv where MemLoginId=@memloginid", paraName, paraValue);
        }

        public int Update_5XCV(string memloginid, decimal cv)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@cv";
            paraValue[1] = cv.ToString();



            return DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [Score_cvv] =Score_cvv-@cv where MemLoginId=@memloginid", paraName, paraValue);
        }

        public int Update3GMobile(string Cardno, string Mobile)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@Cardno";
            paraValue[0] = Cardno;
            paraName[1] = "@Mobile";
            paraValue[1] = Mobile;



            return DatabaseExcetue.RunProcedure("[47.52.115.221].[TJPS].[dbo].[UpdateMObile]", paraName, paraValue);
        }



        public int UpdateAdressIsDefault(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;

            return
               DatabaseExcetue.RunNonQuery("update  ShopNum1_Address set IsDefault=1 where guid=@guid", parms);
        }
        public int UpdateAdressIsDefaultAndTwo(string guid, string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            parms[1].ParameterName = "@memloginid";
            parms[1].Value = memloginid;
            return
               DatabaseExcetue.RunNonQuery("update  ShopNum1_Address set IsDefault=0 where guid <>@guid and MemLoginID=@memloginid", parms);
        }
        public int SelectMyAdvancePaymentModifyLogConut(string MemLoginID, decimal Money, string Style, string DateTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Money";
            parms[1].Value = Money;
            parms[2].ParameterName = "@DateTime";
            parms[2].Value = DateTime;
            string sqlQuery = "";
            if (Style == "Score_dv")
            {
                sqlQuery = @"select Guid from ShopNum1_AdvancePaymentModifyLog where DeDao_dv =@Money and MemLoginID= @MemLoginID and Date>=@DateTime ";
            }
            else
            {
                sqlQuery = @"select Guid from ShopNum1_AdvancePaymentModifyLog where OperateMoney =@Money  and MemLoginID= @MemLoginID  and Date>=@DateTime ";
            }


            DataTable table = DatabaseExcetue.ReturnDataTable(sqlQuery, parms);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }

            return table.Rows.Count;
        }
        public int DelteAdressByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;

            return
               DatabaseExcetue.RunNonQuery("delete ShopNum1_Address where guid=@guid", parms);
        }
        public int updateMemberAdvancePayment(string memloginid, decimal lastbv)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@lastbv";
            parms[1].Value = lastbv.ToString();
            return
                 DatabaseExcetue.RunNonQuery("update ShopNum1_Member set [AdvancePayment] =@lastbv where MemLoginID=@memloginid", parms);
        }
        public int INsertAdvancePaymentModifyLogRecord(string memloginid, decimal satartbv, decimal bv, decimal lastbv)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@satartbv";
            parms[1].Value = satartbv.ToString();
            parms[2].ParameterName = "@bv";
            parms[2].Value = bv.ToString();
            parms[3].ParameterName = "@lastbv";
            parms[3].Value = lastbv.ToString();
            return
                 DatabaseExcetue.RunNonQuery("insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,@satartbv,@bv,@lastbv,getdate(),'TJ转出',@memloginid,@memloginid,getdate(),0)", parms);
        }

        public int InsertAdvancePaymentModifyLogRecord1(string Mobile, decimal satartpvb, decimal pvb, decimal lastpvb, string orderId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@HuoDe_YuanYou_pv_b";
            parms[1].Value = satartpvb.ToString();
            parms[2].ParameterName = "@HuoDe_pv_b";
            parms[2].Value = pvb.ToString();
            parms[3].ParameterName = "@Huo_DeHou_pv_b";
            parms[3].Value = lastpvb.ToString();
            parms[4].ParameterName = "@Memo";
            parms[4].Value = orderId;
            return
                 DatabaseExcetue.RunNonQuery("insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_pv_b],[HuoDe_pv_b],[Huo_DeHou_pv_b],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,@HuoDe_YuanYou_pv_b,@HuoDe_pv_b,@Huo_DeHou_pv_b,getdate(),@Memo,@Mobile,@Mobile,getdate(),0)", parms);
        }

        public int InsertAdvancePaymentModifyLogRecord2(string Mobile, decimal satartpvb, decimal pvb, decimal lastpvb, string orderId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@XiaoFei_YuanYou_pv_b";
            parms[1].Value = satartpvb.ToString();
            parms[2].ParameterName = "@XiaoFei_pv_b";
            parms[2].Value = pvb.ToString();
            parms[3].ParameterName = "@XiaoFei_Hou_pv_b";
            parms[3].Value = lastpvb.ToString();
            parms[4].ParameterName = "@Memo";
            parms[4].Value = orderId;
            return
                 DatabaseExcetue.RunNonQuery("insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[XiaoFei_YuanYou_pv_b],[XiaoFei_pv_b],[XiaoFei_Hou_pv_b],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,@XiaoFei_YuanYou_pv_b,@XiaoFei_pv_b,@XiaoFei_Hou_pv_b,getdate(),@Memo,@Mobile,@Mobile,getdate(),0)", parms);
        }

        public int InsertAdvancePaymentModifyLogRecord22(string MemLoginID, decimal ScorePVB, string orderId)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = ScorePVB.ToString();
            parName[2] = "@mome";


            paraValue[2] = orderId;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_XiaoFei_pv_b", parName, paraValue);
        }

        public int InsertAdvancePaymentModifyLog_Gz_XSY_hv(string MemLoginID, decimal hv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = hv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_HuoDe_hv", parName, paraValue);
        }

        public int InsertAdvancePaymentModifyLog_Gz_XSY_DDDDV(string MemLoginID, decimal hv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = hv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_addDV", parName, paraValue);
        }
        public int InsertAdvancePaymentModifyLog_Gz_XSY_hvXiaoFei(string MemLoginID, decimal hv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = hv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_XiaoFei_hv", parName, paraValue);
        }
        public int INsertAdvancePaymentModifyLog_Gz_XSY(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@bv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_XiaoFeiAdvancePayment", parName, paraValue);
        }
        public int ZhuanZhangNECKou(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_XiaoFei_DV", parName, paraValue);
        }
        public int ZhuanZhangNECJia(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_addDV", parName, paraValue);
        }
        public int INsertAdvancePaymentModifyLog_Gz_XSYAdd(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@bv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_addAdvancePayment", parName, paraValue);
        }
        public int INsertAdvancePaymentModifyLog_Gz_ADDZB(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].[shopnum1_HuoDe_pv_a]", parName, paraValue);
        }
        public int ADDKT(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@bv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].[shopnum1_addAdvancePayment]", parName, paraValue);
        }
        public int ReduceKT(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@bv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].[shopnum1_XiaoFeiAdvancePayment]", parName, paraValue);
        }


        public DataTable SelcteMoeneyBypwd(string memloginid, string paypwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@paypwd";
            parms[1].Value = paypwd;
            return
                DatabaseExcetue.ReturnDataTable("select AdvancePayment from shopnum1_member where memloginid=@memloginid and PayPwd=@paypwd", parms);
        }
        public DataTable SelectAllShopCarBymemberloginID(string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;

            return
                DatabaseExcetue.ReturnDataTable(" select * from  ShopNum1_Shop_Cart where MemLoginId= @memloginid", parms);
        }
        public DataTable SelectOrderByMemberloginIDAndGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);


            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;

            return
                DatabaseExcetue.ReturnDataTable(" select Guid,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,ProductPrice,ProductPv_b,ProductLastPrice,DispatchPrice,PaymentPrice,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchType,IsLogistics,LogisticsCompany,LogisticsCompanyCode,ShipmentNumber,BuyType,ActivityGuid,PayMemo,ShopID,CancelReason,EndTime,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,InvoiceType,InvoiceTax,Discount,Deposit,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,DispatchTime,ShopName,FeeType,IsBuyComment,IsSellComment,BuyIsDeleted,SellIsDeleted,IsDeleted,OrderType,ReceiptTime,PayMentMemLoginID,IsMinus,ReceivedDays,IsMemdelay,RecommendCommision,AlipayTradeId,identifycode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,agentId,Score_cv,Score_max_hv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,score_reduce_pv_cv,score_pv_cv,Offset_pv_b,IsRefundStatus,remark,Deduction_hv,SuperiorRank , ROW_NUMBER() OVER(Order by CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfo as c where  Guid=@guid and BuyIsDeleted=0 and TradeID is not null", parms);
        }
        /// <summary>
        /// 首页三个推荐产品  郭泽写
        /// </summary>
        /// <param name="MemberloginGuid"></param>
        /// <param name="IsReadOrBuy"></param>
        /// <param name="Category_ID"></param>
        /// <returns></returns>
        public DataTable SelectProdctThreeG(string Guid)
        {

            return
                DatabaseExcetue.ReturnDataTable(string.Format("select top 3 * from ( select a.*,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by a.id DESC ) AS RowNumber from ShopNum1_Shop_Product as a left join  ShopNum1_Shop_ProductPrice as e on e.productId=a.id where  a.[Guid] in ({0}) and e.shop_category_id=2 and  a.IsAudit=1 and  a.IsDeleted=0) as b  left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID='C0000001'", Guid));
        }
        public DataTable GetALLMemberAll(string memloginID, string pwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@pwd";
            parms[1].Value = pwd;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  a.IsNoSell,IsBusiness,IsBusiness,a.MemberCate,b.Name as RankName,a.[Guid],[MemLoginID],[MemLoginNO],[Email],[Score],[RegeDate],[LastLoginIP],[LoginTime],PayPwd,[AdvancePayment],[LockAdvancePayment],ETHAddress,case PersonCate when 0 then '普通社区'  when 1 then '节点社区'  when 2 then '集群社区' when 3 then '超级社区' when 4 then '特级社区' else '错误' end as PersonCate,[LockSocre],[CostMoney],a.[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],[IdentityCardBackImg],[IdentityCardImg],[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],[IsMailActivation],[IsMobileActivation],[Sex],a.[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],[PromotionMemLoginID],YesterdayAllBonus,[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile],a.[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],a.[CreateTime],a.[ModifyUser],a.[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[Score_dv],[Score_pv_b],ZaiBi,[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],ShopBili,RecoMember,[ShopNames],[ETHAddress],[NECAddress],membership_Level,IsMobileRegister,ErrorNum,ErrorTime,IsProtecion,Is520Member,Superior FROM ShopNum1_Member as a left join ShopNum1_MemberRank as b on a.MemberRankGuid=b.Guid WHERE ( MemLoginID=@memloginID or  Mobile=@memloginID) and Pwd=@pwd", parms);
        }

        public DataTable GetALLMemberAllEnglish(string memloginID, string pwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@pwd";
            parms[1].Value = pwd;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  a.IsNoSell,IsBusiness,IsBusiness,a.MemberCate,b.Name as RankName,a.[Guid],[MemLoginID],[MemLoginNO],[Email],[Score],[RegeDate],[LastLoginIP],[LoginTime],PayPwd,[AdvancePayment],[LockAdvancePayment],ETHAddress,case PersonCate when 0 then 'Ordinary community'  when 1 then 'Nodes in the community'  when 2 then 'Cluster community' when 3 then 'Super community' when 4 then 'Super community' else 'error ' end as PersonCate,[LockSocre],[CostMoney],a.[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],[IdentityCardBackImg],[IdentityCardImg],[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],[IsMailActivation],[IsMobileActivation],[Sex],a.[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],[PromotionMemLoginID],YesterdayAllBonus,[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile],a.[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],a.[CreateTime],a.[ModifyUser],a.[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[Score_dv],[Score_pv_b],ZaiBi,[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],ShopBili,RecoMember,[ShopNames],[ETHAddress],[NECAddress],membership_Level,IsMobileRegister,ErrorNum,ErrorTime,IsProtecion,Is520Member,Superior FROM ShopNum1_Member as a left join ShopNum1_MemberRank as b on a.MemberRankGuid=b.Guid WHERE ( MemLoginID=@memloginID or  Mobile=@memloginID) and Pwd=@pwd", parms);
        }


        public DataTable GetALLMemberAllGZ(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT case device_no when ''  then 0 when null then 0 else 1 end isdevice_no, a.MemberCate,b.Name as RankName,a.[Guid],[MemLoginID],[MemLoginNO],[Email],[Score],[RegeDate],[LastLoginIP],[LoginTime],PayPwd,[AdvancePayment],[LockAdvancePayment],[LockSocre],[CostMoney],a.[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],[IdentityCardBackImg],[IdentityCardImg],case PersonCate  when 0 then '普通社区'    when 1 then '节点社区'  when 2 then '集群社区' when 3 then '超级社区' when 4 then '特级社区' else '错误' end as PersonCate,YesterdayAllBonus,[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],[IsMailActivation],[IsMobileActivation],[Sex],a.[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],ETHAddress,[PromotionMemLoginID],[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile] ,[ETHAddress],[NECAddress],a.[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],a.[CreateTime],a.[ModifyUser],a.[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[Score_dv],[Score_pv_b],ZaiBi,[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],ShopBili,RecoMember,[ShopNames],membership_Level,IsMobileRegister,ErrorNum,ErrorTime,IsProtecion,Is520Member,Superior FROM ShopNum1_Member as a left join ShopNum1_MemberRank as b on a.MemberRankGuid=b.Guid WHERE ( MemLoginID=@memloginID or  Mobile=@memloginID)", parms);
        }



        public DataTable GetALLMemberAll1(string Mobile, string pwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@pwd";
            parms[1].Value = pwd;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  [Guid],[MemLoginID],[MemLoginNO],[Email],[Score],[RegeDate],[LastLoginIP],[LoginTime],[AdvancePayment],[LockAdvancePayment],[LockSocre],[CostMoney],[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],[IdentityCardBackImg],[IdentityCardImg],[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],[IsMailActivation],[IsMobileActivation],[Sex],[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],[PromotionMemLoginID],[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile],[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],[CreateTime],[ModifyUser],[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[Score_dv],[Score_pv_b],[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],[ShopNames],IsMobileRegister,ErrorNum,ErrorTime,IsProtecion,Is520Member FROM ShopNum1_Member WHERE Mobile=@Mobile and Pwd=@pwd", parms);
        }
        public DataTable Mjc_Getcdatatime(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = memLoginID;

            return
                DatabaseExcetue.ReturnDataTable("select cdatatime FROM [ShopNum1_Member] where MemLoginID=@MemLoginID ", parms);
        }
        public DataTable Mjc_GetcdatatimeMyAllBonus(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = memLoginID;

            return
                DatabaseExcetue.ReturnDataTable("select MyAllBonus FROM [ShopNum1_Member] where MemLoginID=@MemLoginID ", parms);
        }
        public DataTable SignIn_Getcdatatime(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = memLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  [Sid]  ,[MemLoginID] ,[SignInCreate] ,[memo] ,[Bonus] FROM  [QLXSignIn] where MemLoginID=@MemLoginID ", parms);
        }



        public int Mjc_GetInformetion(string memloginno)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginno;
            return DatabaseExcetue.RunProcedure("[dbo].[shopnum1_SignIn1]", paraName, paraValue);
        }

        public int Mjc_GetInformetionBonus(string memloginno, string bonus, string memo)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginno;
            paraName[1] = "@dv";
            paraValue[1] = bonus;
            paraName[2] = "@mome";
            paraValue[2] = memo;

            return DatabaseExcetue.RunProcedure("[dbo].[shopnum1_addDVSign]", paraName, paraValue);
        }



        public DataTable GetMemberScorePVB(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  RealName ,[Mobile],[Score_pv_b],[Superior] FROM ShopNum1_Member WHERE Mobile=@Mobile", parms);
        }

        public DataTable GetMemberBv(string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  RealName ,[Mobile],[AdvancePayment],[Superior] FROM ShopNum1_Member WHERE MemLoginID=@memloginid", parms);
        }
        //查MemLoginID
        public DataTable Getrmobile(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  [MemLoginID] FROM ShopNum1_Member WHERE Mobile=@Mobile", parms);
        }
        //查pvb
        public DataTable GetPVB(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  [Score_pv_b] FROM ShopNum1_Member WHERE MemLoginID=@MemLoginID", parms);
        }

        public DataTable GetMemberMobile(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  [Mobile] FROM ShopNum1_Member WHERE memloginID=@memloginID", parms);
        }

        public int JianScoreBV(string memloginID, decimal bv)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@bv";
            parms[1].Value = bv;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET AdvancePayment= AdvancePayment-@bv  WHERE memloginID=@memloginID", parms);
        }

        public int AddScorePVB(string Mobile, decimal ScorePVB)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@Score_pv_b";
            parms[1].Value = ScorePVB;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET Score_pv_b= Score_pv_b + @Score_pv_b  WHERE Mobile=@Mobile", parms);
        }

        public int JianScorePVB(string Mobile, decimal ScorePVB)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@Score_pv_b";
            parms[1].Value = ScorePVB;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET Score_pv_b= Score_pv_b - @Score_pv_b  WHERE Mobile=@Mobile", parms);
        }

        public DataTable GetALLMemberAllByIdentityCard(string memloginID, string pwd, string IdentityCard)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@pwd";
            parms[1].Value = pwd;
            parms[2].ParameterName = "@IdentityCard";
            parms[2].Value = IdentityCard;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  * FROM ShopNum1_Member WHERE MemLoginID=@memloginID and Pwd=@pwd and IdentityCard =@IdentityCard and MemberRankGuid !='197B6B51-3EB3-452E-BD03-D560577A34D2'", parms);
        }
        public DataTable SelectProdctByguid_two(string guid, int shop_category_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            parms[1].ParameterName = "@shop_category_id";
            parms[1].Value = shop_category_id;
            return
                DatabaseExcetue.ReturnDataTable("SELECT d.*,c.*,ShopNum1_ShopInfo.ShopUrl FROM ShopNum1_Shop_Product as c left join ShopNum1_Shop_ProductPrice as d on d.productId=c.id left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=c.MemLoginID  WHERE c.guid=@guid and d.shop_category_id=@shop_category_id and c.IsAudit=1 and  c.IsDeleted=0 and c.IsSell=1    and c.IsSaled=1  ", parms);
        }
        public DataTable SelectProductByProductCategoryCodeAndShop_category_idAndName(string shop_category_id, int top, int number, string ProductCategoryCode, string name)
        {

            return
                DatabaseExcetue.ReturnDataTable("select * from ( select a.*,ShopNum1_ShopInfo.ShopUrl,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by a.SaleNumber DESC ) AS RowNumber from ShopNum1_Shop_Product as a left join  ShopNum1_Shop_ProductPrice as e on e.productId=a.id  left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=a.MemLoginID  where e.shop_category_id='" + shop_category_id + "' and a.ProductCategoryCode like '" + ProductCategoryCode + "%' and  a.IsAudit=1 and  a.IsDeleted=0 and a.IsSell=1  and a.IsSaled=1  and a.Name like '%" + name + "%') as b  left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=b.MemLoginID where RowNumber BETWEEN " + top + " and " + number + " ");
        }
        public DataTable SelectOrderByMemberloginIDAndOrderStyle(string memloginID, int startnum, int ordernumber, string OrderStyle)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@startnum";
            parms[1].Value = startnum;
            parms[2].ParameterName = "@ordernumber";
            parms[2].Value = ordernumber;

            return
                DatabaseExcetue.ReturnDataTable("  select * from (select Guid,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,ProductPrice,ProductPv_b,ProductLastPrice,DispatchPrice,PaymentPrice,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchType,IsLogistics,LogisticsCompany,LogisticsCompanyCode,ShipmentNumber,BuyType,ActivityGuid,PayMemo,ShopID,CancelReason,EndTime,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,InvoiceType,InvoiceTax,Discount,Deposit,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,DispatchTime,ShopName,FeeType,IsBuyComment,IsSellComment,BuyIsDeleted,SellIsDeleted,IsDeleted,OrderType,ReceiptTime,PayMentMemLoginID,IsMinus,ReceivedDays,IsMemdelay,RecommendCommision,AlipayTradeId,identifycode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,agentId,Score_cv,Score_max_hv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,score_reduce_pv_cv,score_pv_cv,Offset_pv_b,IsRefundStatus,remark,Deduction_hv,SuperiorRank , ROW_NUMBER() OVER(Order by paytime DESC,createtime DESC ) AS RowNumber from ShopNum1_OrderInfo as c where  MemLoginID=@memloginID and BuyIsDeleted=0 and OderStatus in (" + OrderStyle + ") and TradeID is not null) as cd where RowNumber  BETWEEN @startnum and @ordernumber", parms);
        }
        public int AddMobileToken(string MemberlongNO, string MemberlongID, string token)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@MemberlongNO";
            paraValue[0] = MemberlongNO;
            paraName[1] = "@MemberlongID";
            paraValue[1] = MemberlongID;
            paraName[2] = "@token";
            paraValue[2] = token;
            return DatabaseExcetue.RunNonQuery("INSERT INTO ShopNum1_MobileToken( MemberlongNO,MemberlongID,Token) VALUES (@MemberlongNO,@MemberlongID,@token )", paraName, paraValue);
        }

        public int SignAddMobileToken(string MemLoginID, string bonus, string memo)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@bonus";
            paraValue[1] = bonus;
            paraName[2] = "@memo";
            paraValue[2] = memo;
            return DatabaseExcetue.RunNonQuery("INSERT INTO [QLXSignIn]( [MemLoginID],[Bonus],[memo]) VALUES (@MemLoginID,@bonus,@memo)", paraName, paraValue);
        }


        public int UpdateMobileToken(string MemberlongNO, string token)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemberlongNO";
            parms[0].Value = MemberlongNO;
            parms[1].ParameterName = "@token";
            parms[1].Value = token;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_MobileToken SET Token=@token  WHERE MemberlongNO=@MemberlongNO", parms);
        }
        public DataTable SelectMobileToken(string MemberlongNO)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemberlongNO";
            paraValue[0] = MemberlongNO;

            string strSql = string.Empty;
            strSql = "SELECT MemberlongNO  FROM ShopNum1_MobileToken  WHERE MemberlongNO=@MemberlongNO ";

            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }
        public int UpdateMembeErrorTime(string MemLoginID, DateTime ErrorTime)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ErrorTime";
            paraValue[0] = ErrorTime.ToString();
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;
            return
                DatabaseExcetue.RunNonQuery("update  ShopNum1_Member set ErrorTime=@ErrorTime where MemLoginID=@MemLoginID", paraName, paraValue);
        }
        public int UpdateMemberErrorNum(string MemLoginID, int ErrorNum)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ErrorNum";
            paraValue[0] = ErrorNum.ToString();
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;
            return
                DatabaseExcetue.RunNonQuery("update  ShopNum1_Member set ErrorNum=ErrorNum+@ErrorNum where MemLoginID=@MemLoginID", paraName, paraValue);
        }
        public int UpdateMemberErrorNumGetNull(string MemLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];

            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            return
                DatabaseExcetue.RunNonQuery("update  ShopNum1_Member set ErrorNum=0 where MemLoginID=@MemLoginID", paraName, paraValue);
        }

        public int UpdateMemberErrorNumGetNull1(string Mobile)
        {
            var paraName = new string[1];
            var paraValue = new string[1];

            paraName[0] = "@Mobile";
            paraValue[0] = Mobile;
            return
                DatabaseExcetue.RunNonQuery("update  ShopNum1_Member set ErrorNum=0 where Mobile=@Mobile", paraName, paraValue);
        }

        public DataTable GetALLMemberByShopid(string shopid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@shopid";
            parms[0].Value = shopid;

            return
                DatabaseExcetue.ReturnDataTable("select guid,memloginid,email,realname,addressvalue,mobile from shopnum1_member where memloginid=@shopid", parms);
        }

        public int INsertWeixin_Angel(string MemberloginID, DateTime CreateTime, int ReferenceNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemberloginID";
            parms[0].Value = MemberloginID;
            parms[1].ParameterName = "@CreateTime";
            parms[1].Value = CreateTime.ToString();
            parms[2].ParameterName = "@ReferenceNumber";
            parms[2].Value = ReferenceNumber.ToString();

            return
                 DatabaseExcetue.RunNonQuery("  insert into ShopNum1_Weixin_Angel(MemberloginID,CreateTime,ReferenceNumber) values(@MemberloginID,@CreateTime,@ReferenceNumber)", parms);
        }
        public int updateWeixin_Angel(string ReferenceNumber, DateTime CreateTime, string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@ReferenceNumber";
            parms[0].Value = ReferenceNumber;
            parms[1].ParameterName = "@CreateTime";
            parms[1].Value = CreateTime.ToString();
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID.ToString();
            return
                 DatabaseExcetue.RunNonQuery("update ShopNum1_Weixin_Angel set ReferenceNumber =@ReferenceNumber,CreateTime=@CreateTime where MemberloginID=@MemLoginID", parms);
        }
        public DataTable GetALLWeixin_Angel(string MemberloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemberloginID";
            parms[0].Value = MemberloginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT *  FROM ShopNum1_Weixin_Angel WHERE MemberloginID=@MemberloginID ", parms);
        }

        public DataTable selectGETmemBySuperiorGetCount(string WinMemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@WinMemLoginID";
            parms[0].Value = WinMemLoginID;


            string strSql = string.Empty;
            strSql =
                "  select c.MemLoginNO,'A会员' as taba,RealName,Mobile,Is520Member from ShopNum1_Member as c  where  [Superior]=(select  MemLoginNO FROM ShopNum1_Weixin_Member where  WinMemLoginID=@WinMemLoginID) UNION select MemLoginNO,'B会员' as taba,RealName,Mobile,Is520Member from ShopNum1_Member where  [Superior] in ( select c.MemLoginNO from ShopNum1_Member as c  where  [Superior]=(select  MemLoginNO FROM ShopNum1_Weixin_Member where  WinMemLoginID=@WinMemLoginID))  union select MemLoginNO,'C会员' as taba,RealName,Mobile,Is520Member from ShopNum1_Member where  [Superior] in (select MemLoginNO from ShopNum1_Member where  [Superior] in ( select c.MemLoginNO from ShopNum1_Member as c  where  [Superior]=(select  MemLoginNO FROM ShopNum1_Weixin_Member where  WinMemLoginID=@WinMemLoginID)))";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable selectGETmemBySuperiorGet_free(string WinMemLoginID, string state)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@WinMemLoginID";
            parms[0].Value = WinMemLoginID;

            string strSql = string.Empty;

            if (state == "1")
            {
                strSql = "select c.MemLoginNO,'A会员' as taba,RealName,Mobile,d.IS520MemberName,'' as Score_pv_b from ShopNum1_Member as c  left join ShopNum1_Is520Member as d on c.Is520Member=d.Is520MemberNo  where  [Superior]=(select  MemLoginNO FROM ShopNum1_Weixin_Member where WinMemLoginID=@WinMemLoginID ) order by c.MemLoginNO DESC";
            }
            if (state == "2")
            {
                strSql = "select MemLoginNO,'B会员' as taba,RealName,Mobile,d.IS520MemberName, ' ' as Score_pv_b from ShopNum1_Member as c  left join ShopNum1_Is520Member as d on c.Is520Member=d.Is520MemberNo where  [Superior] in ( select c.MemLoginNO from ShopNum1_Member as c  where  [Superior]=(select  MemLoginNO FROM ShopNum1_Weixin_Member where  WinMemLoginID=@WinMemLoginID))  order by MemLoginNO DESC";
            }
            if (state == "3")
            {
                strSql = "select MemLoginNO,'C会员' as taba,RealName,Mobile,d.IS520MemberName, ' ' as Score_pv_b from ShopNum1_Member as c  left join ShopNum1_Is520Member as d on c.Is520Member=d.Is520MemberNo where  [Superior] in (select MemLoginNO from ShopNum1_Member where  [Superior] in ( select c.MemLoginNO from ShopNum1_Member as c  where  [Superior]=(select  MemLoginNO FROM ShopNum1_Weixin_Member where  WinMemLoginID=@WinMemLoginID))) order by MemLoginNO DESC";
            }

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable selectGETMemberBank(string WinMemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@WinMemLoginID";
            parms[0].Value = WinMemLoginID;
            string strSql = string.Empty;
            strSql =
                "select RealName,Bank,BankName,BankNo,BankAddress FROM ShopNum1_Member where MemLoginNO=(select  MemLoginNO FROM ShopNum1_Weixin_Member where  WinMemLoginID=@WinMemLoginID)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable selectGETHVByMemberloingNO(string WinMemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@WinMemLoginID";
            parms[0].Value = WinMemLoginID;
            string strSql = string.Empty;
            strSql =
                "  select Score_hv from ShopNum1_Member where MemLoginNO=(SELECT MemLoginNO FROM ShopNum1_Weixin_Member where WinMemLoginID=@WinMemLoginID)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable selectGETWinMemLoginIDByMemberloingNO(string WinMemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@WinMemLoginID";
            parms[0].Value = WinMemLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT MemLoginNO FROM ShopNum1_Weixin_Member where WinMemLoginID=@WinMemLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public int InsertWeixinMember(string MemLoginNO, string WinMemLoginID, DateTime creatTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);



            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            parms[1].ParameterName = "@creatTime";
            parms[1].Value = creatTime.ToString();
            parms[2].ParameterName = "@WinMemLoginID";
            parms[2].Value = WinMemLoginID;
            return
                DatabaseExcetue.RunNonQuery("  insert into  ShopNum1_Weixin_Member (MemLoginNO,WinMemLoginID,CreateTime) values(@MemLoginNO,@WinMemLoginID,@creatTime)", parms);
        }
        public DataTable GetALLMemberNOAllguiddd(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;

            return
                DatabaseExcetue.ReturnDataTable("SELECT MemLoginNO,MemberRankGuid  FROM ShopNum1_Member WHERE MemLoginNO=@MemLoginNO ", parms);
        }
        public DataTable SelectWeiXinMemLoginNO(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT MemLoginNO FROM ShopNum1_Weixin_Member WHERE MemLoginNO=@MemLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SelectWinMemLoginID(string WinMemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@WinMemLoginID";
            parms[0].Value = WinMemLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT WinMemLoginID FROM ShopNum1_Weixin_Member WHERE WinMemLoginID=@WinMemLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable GetALLMemberNOAll(string MemLoginNO, string pwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            parms[1].ParameterName = "@pwd";
            parms[1].Value = pwd;
            return
                DatabaseExcetue.ReturnDataTable("SELECT MemLoginNO  FROM ShopNum1_Member WHERE MemLoginNO=@MemLoginNO and Pwd=@pwd and IsForbid=0", parms);
        }
        public DataTable GetALLMobileALLl(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;

            return
                DatabaseExcetue.ReturnDataTable("SELECT MemLoginNO  FROM ShopNum1_Member WHERE [Mobile]=@Mobile and IsForbid=0", parms);
        }

        public DataTable SelectSuperiorGetMemLoginID(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT MemLoginNO,MemLoginID FROM ShopNum1_Member where Superior=@MemLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SelectidByMemLoginNO(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return DatabaseExcetue.ReturnDataTable("select  MemLoginNO  from ShopNum1_Member  where   MemLoginID=@MemLoginID", parms);
        }
        public DataTable SelectMemberByOpenId(string OpenId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OpenId";
            parms[0].Value = OpenId;
            string strSql = string.Empty;
            strSql =
                "SELECT  MemLoginID FROM ShopNum1_Member as a left join ShopNum1_Weixin_Member as b  on b.MemLoginNO=a.MemLoginNO  WHERE b.WinMemLoginID=@OpenId";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        /// <summary>
        /// 绑定会员的身份证和真实姓名
        /// </summary>
        /// <param name="memloginid"></param>
        /// <param name="Name"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateRealNameAndID(string memloginid, string Name, string ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@memloginid";
            parms[0].Value = memloginid;
            parms[1].ParameterName = "@Name";
            parms[1].Value = Name;
            parms[2].ParameterName = "@ID";
            parms[2].Value = ID;

            return
               DatabaseExcetue.RunNonQuery("update  ShopNum1_Member set RealName=@Name,IdentityCard=@ID where MemLoginID=@memloginid", parms);


        }


        /// <summary>
        /// 修改银行信息
        /// </summary>
        /// <param name="Bank"></param>
        /// <param name="BankName"></param>
        /// <param name="BankNo"></param>
        /// <param name="BankAddress"></param>
        /// <param name="memloginid"></param>
        /// <returns></returns>
        public int UpdateMemberBank(string Bank, string BankName, string BankNo, string BankAddress, string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(5);

            parms[0].ParameterName = "@Bank";
            parms[0].Value = Bank;
            parms[1].ParameterName = "@BankName";
            parms[1].Value = BankName;
            parms[2].ParameterName = "@BankNo";
            parms[2].Value = BankNo;
            parms[3].ParameterName = "@BankAddress";
            parms[3].Value = BankAddress;
            parms[4].ParameterName = "@memloginid";
            parms[4].Value = memloginid;
            return
               DatabaseExcetue.RunNonQuery("update  ShopNum1_Member set Bank=@Bank,BankName=@BankName,BankNo=@BankNo,BankAddress=@BankAddress where MemLoginID=@memloginid", parms);
        }

        public int AddMemberRecommand(ShopNum1_Member member)
        {
            string sqlQuery = string.Concat(new object[]
                {
                "INSERT INTO Shopnum1_MemberRecommand([memloginNo],[super],[deep])VALUES( '", member.MemLoginNO, "','", member.Superior, "', ",member.Deep,")"

                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }
        public DataTable SelectGetDeep(string memloginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginNO";
            parms[0].Value = memloginNO;


            string strSql = string.Empty;
            strSql =
                " select deep from  Shopnum1_MemberRecommand where memloginNo=@memloginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }


        public DataTable YZmobile(string mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;


            string strSql = string.Empty;
            strSql =
                " select Mobile from  Shopnum1_Member where Mobile=@mobile and IsDeleted=0";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        /// <summary>
        /// 检测手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public DataTable JCmobile(string mobile, string Memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;
            parms[1].ParameterName = "@Memloginid";
            parms[1].Value = Memloginid;


            string strSql = string.Empty;
            strSql =
                "select Mobile from ShopNum1_Member where mobile=@mobile and [MemLoginID]!=@Memloginid and IsDeleted=0 and IsForbid!=1";


            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SelctOderInfoAll(string OrderNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderNumber";
            parms[0].Value = OrderNumber;



            string strSql = string.Empty;
            strSql =
                "  SELECT * FROM .[ShopNum1_OrderInfoTwo] WHERE OrderNumber=@OrderNumber";


            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        /// <summary>
        /// 检测手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public DataTable JCIDCard(string IDCARD, string Memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@IDCARD";
            parms[0].Value = IDCARD;
            parms[1].ParameterName = "@Memloginid";
            parms[1].Value = Memloginid;


            string strSql = string.Empty;
            strSql =
                "select IdentityCard from ShopNum1_Member where IdentityCard=@IDCARD and [MemLoginID]!=@Memloginid and IsDeleted=0 and IsForbid!=1";


            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public int HVExchangeDV(string MemberID, string HV, string Memo, string OrderNumber, string JieHv, string Superior, string JieHvTwo)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@MemberID";
            paraValue[0] = MemberID;
            paraName[1] = "@HV";
            paraValue[1] = HV;
            paraName[2] = "@Memo";
            paraValue[2] = Memo;
            paraName[3] = "@OrderNumber";
            paraValue[3] = OrderNumber;
            paraName[4] = "@JieHv";
            paraValue[4] = JieHv;
            paraName[5] = "@Superior";
            paraValue[5] = Superior;
            paraName[6] = "@JieHvTwo";
            paraValue[6] = JieHvTwo;
            return DatabaseExcetue.RunProcedureGetInt("HVExchangeDV", paraName, paraValue);
        }
        public int KTB_ZhuanZhang(string MemberID, string HV, string Memo, string OrderNumber, string RMemberID)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@MemberID";
            paraValue[0] = MemberID;
            paraName[1] = "@RMemberID";
            paraValue[1] = RMemberID;
            paraName[2] = "@HV";
            paraValue[2] = HV;
            paraName[3] = "@Memo";
            paraValue[3] = Memo;
            paraName[4] = "@OrderNumber";
            paraValue[4] = OrderNumber;
            return DatabaseExcetue.RunProcedureGetInt("KTB_ZhuanZhang", paraName, paraValue);
        }

        public int SaoMa_ZhuanZhang(string MemberID, string HV, string Memo, string OrderNumber, string RMemberID)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@MemberID";
            paraValue[0] = MemberID;
            paraName[1] = "@RMemberID";
            paraValue[1] = RMemberID;
            paraName[2] = "@HV";
            paraValue[2] = HV;
            paraName[3] = "@Memo";
            paraValue[3] = Memo;
            paraName[4] = "@OrderNumber";
            paraValue[4] = OrderNumber;
            return DatabaseExcetue.RunProcedureGetInt("SaoMa_ZhuanZhang", paraName, paraValue);
        }
        public int AddCTCMaiDan(string MemLoginID, string OrderNumber, string ShouldPayPrice, string Score_pv_b)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@OrderNumber";
            paraValue[1] = OrderNumber;
            paraName[2] = "@ShouldPayPrice";
            paraValue[2] = ShouldPayPrice;
            paraName[3] = "@Score_pv_b";
            paraValue[3] = Score_pv_b;

            return DatabaseExcetue.RunProcedureGetInt("AddCTCMaiDan", paraName, paraValue);
        }
        public int UpdateOderInfoOderStatus(string OrderNumber)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@OrderNumber";
            paraValue[0] = OrderNumber;


            return DatabaseExcetue.RunProcedureGetInt("UpdateOderInfoOderStatus", paraName, paraValue);
        }

        public int UpdateOderInfoOderStatusTwo(string OrderNumber)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@OrderNumber";
            paraValue[0] = OrderNumber;


            return DatabaseExcetue.RunProcedureGetInt("UpdateOderInfoOderStatusTwo", paraName, paraValue);
        }

        public int AddCTCGetDan(string MemLoginID, string OrderNumber, string ShouldPayPrice, string Score_pv_b)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@OrderNumber";
            paraValue[1] = OrderNumber;
            paraName[2] = "@ShouldPayPrice";
            paraValue[2] = ShouldPayPrice;
            paraName[3] = "@Score_pv_b";
            paraValue[3] = Score_pv_b;

            return DatabaseExcetue.RunProcedureGetInt("AddCTCGetDan", paraName, paraValue);
        }
        public int BTK_ZhuanZhang(string MemberID, string HV, string Memo, string OrderNumber, string JieHv, string RMemberID, string JieHvTwo, string Superior)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@MemberID";
            paraValue[0] = MemberID;
            paraName[1] = "@RMemberID";
            paraValue[1] = RMemberID;
            paraName[2] = "@HV";
            paraValue[2] = HV;
            paraName[3] = "@Memo";
            paraValue[3] = Memo;
            paraName[4] = "@OrderNumber";
            paraValue[4] = OrderNumber;
            paraName[5] = "@JieHv";
            paraValue[5] = JieHv;
            paraName[6] = "@JieHvTwo";
            paraValue[6] = JieHvTwo;
            paraName[7] = "@Superior";
            paraValue[7] = Superior;
            return DatabaseExcetue.RunProcedureGetInt("BTK_ZhuanZhang", paraName, paraValue);
        }
        public int BTS_ZhuanZhang(string MemberID, string HV, string Memo, string OrderNumber, string RMemberID)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@MemberID";
            paraValue[0] = MemberID;
            paraName[1] = "@RMemberID";
            paraValue[1] = RMemberID;
            paraName[2] = "@HV";
            paraValue[2] = HV;
            paraName[3] = "@Memo";
            paraValue[3] = Memo;
            paraName[4] = "@OrderNumber";
            paraValue[4] = OrderNumber;
            return DatabaseExcetue.RunProcedureGetInt("BTS_ZhuanZhang", paraName, paraValue);
        }
        /// <summary>
        /// 推荐C会员
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public DataTable Select_ListC(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] =
                "a.Mobile,a.MemLoginNO,a.MemLoginID,a.RealName,a.RegeDate,a.IsDeleted,b.Name ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Member as a left join ShopNum1_MemberRank as b on b.Guid=a.MemberRankGuid ";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "MemLoginNO";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
        public int UpdateMemberShopName(string MemLoginID, string ShopName)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@ShopName";
            parms[1].Value = ShopName;
            return
               DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET ShopNames=@ShopName  WHERE MemLoginID=@MemLoginID", parms);
        }

        public int UpdateRankbyMemLoginID(string Rank, string MemLoginID)
        {
            var paraName = new string[2];
            var paraValue = new string[2];

            paraName[0] = "@Rank";
            paraValue[0] = Rank.Replace("'", "");
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;

            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Member SET MemberRankGuid=@Rank where MemLoginID=@MemLoginID"
                    }), paraName, paraValue);
        }
        /// <summary>
        /// 修改会员等级
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public int UpdateMemberRankGuid(string memLoginID, string memRankGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@memRankGuid";
            parms[1].Value = memRankGuid.Replace("'", "");
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET MemberRankGuid=@memRankGuid  WHERE MemLoginID=@memLoginID", parms);
        }


        /// <summary>
        /// 绑定车辆
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public int UpdateMemberCarBand(string memLoginID, string shebei, string chepai, string leixing)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@shebei";
            parms[1].Value = shebei;
            parms[2].ParameterName = "@chepai";
            parms[2].Value = chepai;
            parms[3].ParameterName = "@leixing";
            parms[3].Value = leixing;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET deviceType=1,device_no=@shebei,CarType=@leixing,CarNo=@chepai  WHERE MemLoginID=@memLoginID", parms);
        }


        public int UpdateMemberRankGuid_NO(string memLoginID, string memRankGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@memRankGuid";
            parms[1].Value = memRankGuid.Replace("'", "");
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET MemberRankGuid=@memRankGuid  WHERE MemLoginNO=@memLoginID", parms);
        }
        /// <summary>
        /// 修改会员等级接口用
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="ShopName"></param>
        /// <returns></returns>
        public int UpdateMemberRankGuidGZ(string memLoginID, string memRankGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@memRankGuid";
            parms[1].Value = memRankGuid.Replace("'", "");
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET MemberRankGuid=@memRankGuid  WHERE MemLoginNO=@memLoginID", parms);
        }

        /// <summary>
        /// 给升级的会员价格时间记录
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="memRankGuid"></param>
        /// <returns></returns>
        public int InsertLogUpdateTime(string memLoginID, DateTime creatTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@creatTime";
            parms[1].Value = creatTime.ToString();
            return
                DatabaseExcetue.RunNonQuery("insert into ShopNum1_LogUpdateTime  values(@memLoginID,@creatTime)", parms);
        }


        public int UpdateMemberShipAdress(string SatrtMemLoginID, string LastMemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@SatrtMemLoginID";
            parms[0].Value = SatrtMemLoginID;
            parms[1].ParameterName = "@LastMemLoginID";
            parms[1].Value = LastMemLoginID;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_MemberShipAdress SET MemLoginID=@LastMemLoginID  WHERE MemLoginID=@SatrtMemLoginID", parms);
        }
        public int UpdateShopNum1_MemberShip(string SatrtMemLoginID, string LastMemLoginID, string LastMemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@SatrtMemLoginID";
            parms[0].Value = SatrtMemLoginID;
            parms[1].ParameterName = "@LastMemLoginID";
            parms[1].Value = LastMemLoginID;
            parms[2].ParameterName = "@LastMemLoginNO";
            parms[2].Value = LastMemLoginNO;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_MemberShip SET MemLoginID=@LastMemLoginID,MemLoginNO=@LastMemLoginNO  WHERE MemLoginID=@SatrtMemLoginID", parms);
        }

        public int InsertUpdateRecordCommunity(string memLoginID, string UpdateStart, string UpdateName, DateTime DataTime, string datatime_one, string datatime_two, string Belongs)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(7);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@UpdateStart";
            parms[1].Value = UpdateStart;
            parms[2].ParameterName = "@UpdateName";
            parms[2].Value = UpdateName;
            parms[3].ParameterName = "@datatime_one";
            parms[3].Value = datatime_one.ToString();
            parms[4].ParameterName = "@DataTime";
            parms[4].Value = DataTime;
            parms[5].ParameterName = "@datatime_two";
            parms[5].Value = datatime_two.ToString();
            parms[6].ParameterName = "@Belongs";
            parms[6].Value = Belongs;
            return
                DatabaseExcetue.RunNonQuery("insert into ShopNum1_UpdateRecordCommunity  values(@memLoginID,@UpdateStart,@UpdateName,@DataTime,@datatime_one,@datatime_two,1,@Belongs)", parms);
        }

        public int InsertLogUpdateTime_two(string memLoginID, DateTime creatTime, string gaizhiqian, string gaizhihou)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@creatTime";
            parms[1].Value = creatTime.ToString();
            parms[2].ParameterName = "@gaizhiqian";
            parms[2].Value = gaizhiqian.ToString();
            parms[3].ParameterName = "@gaizhihou";
            parms[3].Value = gaizhihou.ToString();
            return
                DatabaseExcetue.RunNonQuery("insert into ShopNum1_LogUpdateTime_two  values(@memLoginID,@creatTime,@gaizhiqian,@gaizhihou)", parms);
        }

        /// <summary>
        /// 修改推荐人
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="memRankGuid"></param>
        /// <returns></returns>
        public int UpdateMemberSuperior(string memLoginID, string cmember)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@cmember";
            parms[1].Value = cmember;

            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET Superior=@cmember  WHERE MemLoginID=@memLoginID", parms);
        }

        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="memRankGuid"></param>
        /// <returns></returns>
        public int UpdateMemberRealName(string memLoginNO, string name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginNO";
            parms[0].Value = memLoginNO;
            parms[1].ParameterName = "@name";
            parms[1].Value = name;

            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET RealName=@name  WHERE MemLoginNO=@MemLoginNO", parms);
        }
        public DataTable SelectAllMemberShip()
        {
            return DatabaseExcetue.ReturnDataTable("  select m.[MemLoginNO],ms.[ExamineTime],ms.[Upgrade_two_datatime],(select Name from ShopNum1_MemberRank where [Guid]= m.[MemberRankGuid]) as MemberRankGuid,0 as IsUpdate,ms.[Belongs]  from ShopNum1_Member as m left join ShopNum1_MemberShip as ms on ms.MemLoginID=m.MemLoginID where m.MemberRankguid='2FCF4209-7971-41D2-8FDD-419AAA4CF771' or m.MemberRankguid='D33DE7AD-D020-42CC-93CE-6E75F9025015' or m.MemberRankguid='49844669-3893-413E-951E-77B2EBE4FE28' or m.MemberRankguid='2B1D8354-F929-42A7-8C8C-7A0F68C28EBA'");
        }

        public DataTable SelectUpdateRecordCommunity(string StartTime, string LastTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@StartTime";
            parms[0].Value = StartTime;
            parms[1].ParameterName = "@LastTime";
            parms[1].Value = LastTime;
            string strSql = string.Empty;
            strSql =
                "SELECT [MemLoginNO],[datatime_one] as Upgrade_two_datatime,[datatime_two] as ExamineTime,[UpdateName] as MemberRankGuid,[IsUpdate],[Belongs] FROM [ShopNum1].[dbo].[ShopNum1_UpdateRecordCommunity]   where DataTime between @StartTime  and @LastTime";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public int UpdateMemberIdentityCard(string memLoginNO, string IdentityCard)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginNO";
            parms[0].Value = memLoginNO;
            parms[1].ParameterName = "@IdentityCard";
            parms[1].Value = IdentityCard;

            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET IdentityCard=@IdentityCard  WHERE MemLoginNO=@MemLoginNO", parms);
        }
        /// <summary>
        /// 查询C会员是否存在
        /// </summary>
        /// <param name="MemLoginNO"></param>
        /// <returns></returns>
        public DataTable SearchCMember(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT ShopNames, MemLoginNO FROM ShopNum1_Member WHERE MemberRankGuid!='197B6B51-3EB3-452E-BD03-D560577A34D2' and MemLoginNO=@MemLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SelectMemberloginid_By_NO(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT  MemLoginID FROM ShopNum1_Member WHERE MemLoginNO=@MemLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        //根据编号查询电话
        public string SelectMemberNObyMobile(string MemLoginNO)
        {



            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginNO";
            parms[0].Value = MemLoginNO;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  Mobile  FROM ShopNum1_Member  WHERE MemLoginNO=@memLoginNO", parms).Rows[0]["Mobile"].ToString();

        }

        public DataTable SelectMemberShipBelongs(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT  Belongs FROM ShopNum1_MemberShip WHERE MemLoginNO=@MemLoginNO and ShipStatus !=0";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SelectMemberShip(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT  *  FROM ShopNum1_MemberShip WHERE MemLoginNO=@MemLoginNO and ShipStatus !=0";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SelectMemberShipAdress(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT  *  FROM ShopNum1_MemberShipAdress WHERE MemLoginID=@MemLoginID ";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }



        public DataTable SearchCMember(DateTime StartTime, DateTime LastTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@StartTime";
            parms[0].Value = StartTime;
            parms[1].ParameterName = "@LastTime";
            parms[1].Value = LastTime;
            string strSql = string.Empty;
            strSql =
                "SELECT ShopNames, MemLoginNO FROM ShopNum1_Member WHERE MemberRankGuid!='197B6B51-3EB3-452E-BD03-D560577A34D2' and MemLoginNO=@MemLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public int UpdateShopNum1_MemberShipAll(string MemLoginNO, string Adress, string Area, string Belongs)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;

            parms[1].ParameterName = "@Adress";
            parms[1].Value = Adress;
            parms[2].ParameterName = "@Area";
            parms[2].Value = Area;
            parms[3].ParameterName = "@Belongs";
            parms[3].Value = Belongs;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_MemberShip SET Adress=@Adress,Area=@Area,Belongs=@Belongs  WHERE MemLoginNO=@MemLoginNO and ShipStatus !=0", parms);
        }
        public int UpdateMemberShipAdressAll(string MemLoginID, string Province, string City, string District)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Province";
            parms[1].Value = Province;
            parms[2].ParameterName = "@City";
            parms[2].Value = City;
            parms[3].ParameterName = "@District";
            parms[3].Value = District;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_MemberShipAdress SET Province=@Province,City=@City,District=@District  WHERE MemLoginID=@MemLoginID ", parms);
        }

        public int UpdateRetailersState(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;

            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET RetailersState=1  WHERE MemLoginNO=@memLoginID", parms);
        }

        public DataTable NewSearchAreaAgent(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT MemberType,IsFuwuzhan,ShopNames,MemberRankGuid, MemLoginNO FROM ShopNum1_Member WHERE (MemLoginNO=@MemLoginNO or MemLoginID=@MemLoginNO)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SearchAreaAgentExist(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT ShopNames, MemLoginNO FROM ShopNum1_Member WHERE (MemberRankGuid IN ('D33DE7AD-D020-42CC-93CE-6E75F9025015','2FCF4209-7971-41D2-8FDD-419AAA4CF771','49844669-3893-413E-951E-77B2EBE4FE28', '2B1D8354-F929-42A7-8C8C-7A0F68C28EBA')) and MemLoginNO=@MemLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SearchAreaAgent()
        {
            string strSql = string.Empty;
            strSql =
                "SELECT ShopName, MemLoginNO FROM ShopNum1_Member WHERE (MemberRankGuid IN ('49844669-3893-413E-951E-77B2EBE4FE28', '2B1D8354-F929-42A7-8C8C-7A0F68C28EBA'))";

            return DatabaseExcetue.ReturnDataTable(strSql);
        }


        public DataTable SearchMembertwoOrMobile(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT * FROM ShopNum1_Member where (MemLoginID=@memLoginID or Mobile=@memLoginID)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchMemberByNECAddress(string NECAddress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@NECAddress";
            parms[0].Value = NECAddress;
            string strSql = string.Empty;
            strSql =
                "SELECT * FROM ShopNum1_Member where (NECAddress=@NECAddress)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }



        public DataTable SearchMembertwoWHJ(string memLoginID, bool isadmin = false)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = "SELECT * FROM ShopNum1_Member where MemLoginID=@memLoginID";
            strSql += (isadmin ? " " : " and MemLoginID not in(select BLID from WHJ_BlackList)");

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchMembertwo(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = "SELECT * FROM ShopNum1_Member where MemLoginID=@memLoginID";
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SearchMembertwoMJC(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = "SELECT * FROM ShopNum1_Member where Superior=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchMemberGz(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT  case device_no when ''  then 0 when null then 0 else 1 end isdevice_no, ZaiBi, ShopBili, a.MemberCate,b.Name as RankName,Score_dv,Superior,membership_Level,a.[Guid],[MemLoginID],CheckInNumber,[MemLoginNO],[Email],[Score],YesterdayAllBonus,[RegeDate],[LastLoginIP],[LoginTime],PayPwd,[AdvancePayment],[LockAdvancePayment],[LockSocre],[CostMoney],a.[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],ETHAddress,[IdentityCardBackImg],[IdentityCardImg],[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],case PersonCate  when 0 then '普通社区'  when 1 then '节点社区'  when 2 then '集群社区' when 3 then '超级社区' when 4 then '超级特级' else '错误' end as PersonCate,[IsMailActivation],[IsMobileActivation],[Sex],a.[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],[PromotionMemLoginID],[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile],a.[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],a.[CreateTime],a.[ModifyUser],a.[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[ETHAddress],[NECAddress],[Score_dv],[Score_pv_b],[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],RecoMember,[ShopNames],IsMobileRegister,ErrorNum,ErrorTime,IsProtecion,ZaiBi,Is520Member FROM ShopNum1_Member as a left join ShopNum1_MemberRank as b on a.MemberRankGuid=b.Guid WHERE ( MemLoginID=@memloginID or  Mobile=@memloginID)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SearchMemberGzEnglish(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT  case device_no when ''  then 0 when null then 0 else 1 end isdevice_no, ZaiBi, ShopBili, a.MemberCate,b.Name as RankName,Score_dv,Superior,membership_Level,a.[Guid],[MemLoginID],CheckInNumber,[MemLoginNO],[Email],[Score],YesterdayAllBonus,[RegeDate],[LastLoginIP],[LoginTime],PayPwd,[AdvancePayment],[LockAdvancePayment],[LockSocre],[CostMoney],a.[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],ETHAddress,[IdentityCardBackImg],[IdentityCardImg],[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],case PersonCate  when 0 then 'Ordinary community'  when 1 then 'Nodes in the community'  when 2 then 'Cluster community' when 3 then 'Super community' when 4 then 'Super super' else 'error' end as PersonCate,[IsMailActivation],[IsMobileActivation],[Sex],a.[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],[PromotionMemLoginID],[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile],a.[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],a.[CreateTime],a.[ModifyUser],a.[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[ETHAddress],[NECAddress],[Score_dv],[Score_pv_b],[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],RecoMember,[ShopNames],IsMobileRegister,ErrorNum,ErrorTime,IsProtecion,ZaiBi,Is520Member FROM ShopNum1_Member as a left join ShopNum1_MemberRank as b on a.MemberRankGuid=b.Guid WHERE ( MemLoginID=@memloginID or  Mobile=@memloginID)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable QLXNECBiLiAPP(string TypeNumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@TypeNumber";
            parms[0].Value = TypeNumber;
            string strSql = string.Empty;
            strSql =
                "select *   FROM [QLX_NECBiLiAPP] where TypeNumber=@TypeNumber";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchMemberMjc(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = "select BonusID,Bonus1,Bonus2,Bonus3,Proportion,IsDelete from Bonus where MemLoginID=@memLoginID  and createtime= (select convert(char(10),GetDate(),120) as Date)";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SignInSearchMemberMjc(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = " SELECT  [Sid]  ,[MemLoginID] ,[SignInCreate] ,[memo] ,[Bonus] ,[zengjia] FROM  [QLXSignIn] where MemLoginID=@memLoginID and QLXtime=(select convert(char(10),GetDate(),120))";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SignInSearchMemberMj(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = " SELECT  [Sid]  ,[MemLoginID] ,[SignInCreate] ,[memo] ,[Bonus] ,[zengjia] FROM  [QLXSignIn] where MemLoginID=@memLoginID order by SignInCreate desc";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SignInSearchMemberMjEnglish(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = " SELECT  [Sid]  ,[MemLoginID] ,[SignInCreate] ,[momeEnglish] as memo,[Bonus] ,[zengjia] FROM  [QLXSignIn] where MemLoginID=@memLoginID order by SignInCreate desc";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SignInSearchMemberSeven(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = " SELECT  [Sid]  ,[MemLoginID] ,[SignInCreate] ,[memo] ,[Bonus] ,[zengjia] FROM  [QLXSignIn] where MemLoginID=@memLoginID order by SignInCreate desc";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable SignInSearchMemberSevenEnglish(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql = " SELECT  [Sid]  ,[MemLoginID] ,[SignInCreate] ,[momeEnglish] as memo,  ,[Bonus] ,[zengjia] FROM  [QLXSignIn] where MemLoginID=@memLoginID order by SignInCreate desc";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SelectFristDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,0,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectFristMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,0,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }

        public DataTable SelectSecondtDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-1,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID= @MemLoginID", parms);
        }
        public DataTable SelectSecondMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-1,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }

        public DataTable SelectThreetDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-2,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectThreeMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-2,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }


        public DataTable SelectfourtDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-3,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectfourMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-3,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }

        public DataTable SelectFivetDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-4,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectFiveMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-4,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectSixtDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-5,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectSixMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-5,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }

        public DataTable SelectSevenDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  count(Bonus5) as bonus FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-6,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SelectSevenMoneyDay(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT  Bonus5  FROM [Bonus] where (select convert(varchar(10),CreateTime,20))=(select convert(DATE,dateadd(dd,-6,GETDATE()))  as Date) and  Bonus5>0 and MemLoginID=  @MemLoginID", parms);
        }
        public DataTable SearchBonusAll(string BonusID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@BonusID";
            parms[0].Value = BonusID;
            string strSql = string.Empty;
            strSql = "select BonusAll from Bonus where BonusID=@BonusID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public int UpdateSignIn1(string MemLoginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];

            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;

            string cc = "";
            cc = "  update [Bonus] set [IsDelete]=1 where  MemLoginID= @MemLoginID";

            try
            {
                return DatabaseExcetue.RunNonQuery(cc, paraName, paraValue);
            }
            catch (Exception c)
            {

                throw c;
            }
        }
        public DataTable selectGETMemberloginID_MemberloingNO(string memLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginNO";
            parms[0].Value = memLoginNO;
            string strSql = string.Empty;
            strSql =
                "SELECT MemLoginID,MemberRankGuid FROM ShopNum1_Member where MemLoginNO=@memLoginNO";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }


        public int Add3G(string CardNo, string Superior, string name, string IDcary, string Mobile)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@CardNo";
            paraValue[0] = CardNo;
            paraName[1] = "@Superior";
            paraValue[1] = Superior;
            paraName[2] = "@name";
            paraValue[2] = name;
            paraName[3] = "@IDcary";
            paraValue[3] = IDcary;
            paraName[4] = "@Mobile";
            paraValue[4] = Mobile;



            return DatabaseExcetue.RunProcedureGetInt("[47.52.115.221].[TJPS].[dbo].[pro_3GRegist]", paraName, paraValue);
        }
        /// <summary>
        /// 注册cs
        /// </summary>
        /// <param name="memberid">工号</param>
        /// <param name="pwd">登陆密码</param>
        /// <param name="name">昵称</param>
        /// <param name="IDcary">身份证</param>
        /// <param name="Mobile">手机</param>
        /// <param name="ip">IP地址</param>
        /// <param name="regtime">注册时间戳</param>
        /// <returns></returns>
        public int AddCS(string memberid, string pwd, string name, string IDcary, string Mobile, string ip, string regtime)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@value_email";
            paraValue[0] = memberid;
            paraName[1] = "@value_pwd";
            paraValue[1] = pwd;
            paraName[2] = "@value_pwdtrade";
            paraValue[2] = pwd;
            paraName[3] = "@value_nick";
            paraValue[3] = name;
            paraName[4] = "@value_idcard";
            paraValue[4] = IDcary;
            paraName[5] = "@value_phone";
            paraValue[5] = Mobile;
            paraName[6] = "@value_ip";
            paraValue[6] = ip;
            paraName[7] = "@value_regtime";
            paraValue[7] = regtime;



            return DatabaseExcetue.RunProcedureGetInt("[dbo].[ZhuCe]", paraName, paraValue);
        }

        public int AddCSjifen(string MasterID, string Name, string Gold, string ip)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@CardNo";
            paraValue[0] = MasterID;
            paraName[1] = "@member_name";
            paraValue[1] = Name;
            paraName[2] = "@money";
            paraValue[2] = Gold;
            paraName[3] = "@ip";
            paraValue[3] = ip;




            return DatabaseExcetue.RunProcedureGetInt("[dbo].[MYSQLChongZhi]", paraName, paraValue);
        }
        public int AddCSjifenTwo(string MasterID, string OderNumber, string ip)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@member_id";
            paraValue[0] = MasterID;

            paraName[1] = "@OderNumber";
            paraValue[1] = OderNumber;
            paraName[2] = "@ip";
            paraValue[2] = ip;




            return DatabaseExcetue.RunProcedureGetIntttwo("[dbo].[MYSQLChongZhiTwo]", paraName, paraValue);
        }

        public int AddCsJiLu(string MasterID, string Name, string Gold, string OderNumber)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@member_id";
            paraValue[0] = MasterID;
            paraName[1] = "@member_name";
            paraValue[1] = Name;
            paraName[2] = "@money";
            paraValue[2] = Gold;
            paraName[3] = "@OderNumber";
            paraValue[3] = OderNumber;


            return DatabaseExcetue.RunProcedureGetInt("[dbo].[MYSQLChongZhiJiLu]", paraName, paraValue);
        }


        public int AddDVGetXianShiYou(string MasterID, string ClientIP, string Accounts, string AddGold, string Reason)
        {
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@MasterID";
            paraValue[0] = MasterID;
            paraName[1] = "@ClientIP";
            paraValue[1] = ClientIP;
            paraName[2] = "@Accounts";
            paraValue[2] = Accounts;
            paraName[3] = "@AddGold";
            paraValue[3] = AddGold;
            paraName[4] = "@Reason";
            paraValue[4] = Reason;



            return DatabaseExcetue.RunProcedureGetInt("[116.62.163.117].[QPTreasureDB].[dbo].[NET_PM_GrantTreasureByAccounts]", paraName, paraValue);
        }

        public int NET_PM_SelectPersonCount(string Accounts)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Accounts";
            paraValue[0] = Accounts;




            return DatabaseExcetue.RunProcedureGetInt("[116.62.163.117].[QPAccountsDB].[dbo].[NET_PM_SelectPersonCount]", paraName, paraValue);
        }

        public int CXCSmember(string memberID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@value_email";
            paraValue[0] = memberID;




            return DatabaseExcetue.RunProcedureGetInt("[dbo].[ChaxunGongHaotwo]", paraName, paraValue);
        }



        public int Delete3G(string CardNo)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@CardNo";
            paraValue[0] = CardNo;


            return DatabaseExcetue.RunProcedure("pro_Delete3GRegist", paraName, paraValue);
        }


        public int AddMJC(ShopNum1_Member member)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Member( \tGuid\t, \tRealName\t, IdentityCard, \tMemLoginID\t,\tMemLoginNO\t, \tEmail\t, \tMobile\t, \tPwd\t, \tIsForbid\t, \tMemberType\t, \tAddressCode\t, \tAddressValue\t, \tRegeDate\t, \tLoginDate\t, \tMemberRank\t, \tScore\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tLockAdvancePayment\t, \tLockSocre\t, \tCostMoney\t,\tIsMailActivation\t,  IsMobileActivation ,   IsEmailActivation ,  MemberRankGuid ,  PromotionMemLoginID,Superior,Score_hv,PayPwd,Name,mobiletype,RecoMember,ETHAddress,NECAddress ) VALUES (  '"
                    , member.Guid, "',  '", Operator.FilterString(member.RealName), "',  '", Operator.FilterString(member.IdentityCard), "',  '", member.MemLoginID, "', '", member.MemLoginNO, "',  '",
                    Operator.FilterString(member.Email), "',  '", Operator.FilterString(member.Mobile), "',  '",
                    Operator.FilterString(member.Pwd), "',  ", member.IsForbid, ", '", member.MemberType,
                    "',  '", Operator.FilterString(member.AddressCode), "',  '",
                    Operator.FilterString(member.AddressValue), "',  '", member.RegeDate, "',  '", member.LoginDate,
                    "',  '", member.MemberRank, "',  '", member.Score, "',  '", member.LastLoginIP, "',  '",
                    member.LoginTime,
                    "',  '", member.AdvancePayment, "',  '", member.LockAdvancePayment, "',  '", member.LockSocre,
                    "',  '", member.CostMoney, "',  '", member.IsMailActivation, "',  '", member.IsMobileActivation,
                    "', '", member.IsEmailActivation, "', '", member.MemberRankGuid,
                    "', '", member.PromotionMemLoginID, "', '", member.Superior, "', ", member.Score_hv, ",'",member.PayPwd,"','",member.Name,"','",member.mobiletype,"','",member.RecoMember,"','",member.ETHAddress,"','",member.NECAddress,"')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        public int Add(ShopNum1_Member member)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Member( \tGuid\t, \tRealName\t, IdentityCard, \tMemLoginID\t,\tMemLoginNO\t, \tEmail\t, \tMobile\t, \tPwd\t, \tIsForbid\t, \tMemberType\t, \tAddressCode\t, \tAddressValue\t, \tRegeDate\t, \tLoginDate\t, \tMemberRank\t, \tScore\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tLockAdvancePayment\t, \tLockSocre\t, \tCostMoney\t,\tIsMailActivation\t,  IsMobileActivation ,   IsEmailActivation ,  MemberRankGuid ,  PromotionMemLoginID,Superior,Score_hv,PayPwd,Name,RecoMember ) VALUES (  '"
                    , member.Guid, "',  '", Operator.FilterString(member.RealName), "',  '", Operator.FilterString(member.IdentityCard), "',  '", member.MemLoginID, "', '", member.MemLoginNO, "',  '",
                    Operator.FilterString(member.Email), "',  '", Operator.FilterString(member.Mobile), "',  '",
                    Operator.FilterString(member.Pwd), "',  ", member.IsForbid, ", '", member.MemberType,
                    "',  '", Operator.FilterString(member.AddressCode), "',  '",
                    Operator.FilterString(member.AddressValue), "',  '", member.RegeDate, "',  '", member.LoginDate,
                    "',  '", member.MemberRank, "',  '", member.Score, "',  '", member.LastLoginIP, "',  '",
                    member.LoginTime,
                    "',  '", member.AdvancePayment, "',  '", member.LockAdvancePayment, "',  '", member.LockSocre,
                    "',  '", member.CostMoney, "',  '", member.IsMailActivation, "',  '", member.IsMobileActivation,
                    "', '", member.IsEmailActivation, "', '", member.MemberRankGuid,
                    "', '", member.PromotionMemLoginID, "', '", member.Superior, "', ", member.Score_hv, ",'",member.PayPwd,"','",member.Name,"','",member.RecoMember,"')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        public int AddMobileResigter(ShopNum1_Member member)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_Member( \tGuid\t, \tRealName\t, IdentityCard, \tMemLoginID\t,\tMemLoginNO\t, \tEmail\t, \tMobile\t, \tPwd\t, \tIsForbid\t, \tMemberType\t, \tAddressCode\t, \tAddressValue\t, \tRegeDate\t, \tLoginDate\t, \tMemberRank\t, \tScore\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tLockAdvancePayment\t, \tLockSocre\t, \tCostMoney\t,\tIsMailActivation\t,  IsMobileActivation ,   IsEmailActivation ,  MemberRankGuid ,  PromotionMemLoginID,IsMobileRegister,PayPwd ) VALUES (  '"
                    , member.Guid, "',  '", Operator.FilterString(member.RealName), "',  '", Operator.FilterString(member.IdentityCard), "',  '", member.MemLoginID, "', '", member.MemLoginNO, "',  '",
                    Operator.FilterString(member.Email), "',  '", Operator.FilterString(member.Mobile), "',  '",
                    Operator.FilterString(member.Pwd), "',  ", member.IsForbid, ", '", member.MemberType,
                    "',  '", Operator.FilterString(member.AddressCode), "',  '",
                    Operator.FilterString(member.AddressValue), "',  '", member.RegeDate, "',  '", member.LoginDate,
                    "',  '", member.MemberRank, "',  '", member.Score, "',  '", member.LastLoginIP, "',  '",
                    member.LoginTime,
                    "',  '", member.AdvancePayment, "',  '", member.LockAdvancePayment, "',  '", member.LockSocre,
                    "',  '", member.CostMoney, "',  '", member.IsMailActivation, "',  '", member.IsMobileActivation,
                    "', '", member.IsEmailActivation, "', '", member.MemberRankGuid,
                    "', '", member.PromotionMemLoginID, "','",member.IsMobileRegister,"','",Operator.FilterString(member.PayPwd),"')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        public int UpdateMoneyByDateTimeAndID(Decimal money, String ID, String Type)
        {
            var paraName = new string[2];
            var paraValue = new string[2];

            paraName[0] = "@money";
            paraValue[0] = money.ToString();
            paraName[1] = "@MemLoginID";
            paraValue[1] = ID;
            string cc = "";
            if (Type == "AdvancePayment")
            {
                cc = "update ShopNum1_Member set AdvancePayment=(select AdvancePayment from ShopNum1_Member where MemLoginID=@MemLoginID)+ @money where MemLoginID= @MemLoginID";
            }
            if (Type == "Score_dv")
            {
                cc = "update ShopNum1_Member set Score_dv=(select Score_dv from ShopNum1_Member where MemLoginID=@MemLoginID)+ @money where MemLoginID= @MemLoginID";
            }

            try
            {
                return DatabaseExcetue.RunNonQuery(cc, paraName, paraValue);
            }
            catch (Exception c)
            {

                throw c;
            }


        }


        public int Add(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_MemberGroup(   Guid,  Name,  Description,  CreateUser,  CreateTime,  ModifyUser,  ModifyTime,  IsDeleted ) VALUES (  '"
                , memberGroup.Guid, "', '", memberGroup.Name, "', '", memberGroup.Description, "', '",
                memberGroup.CreateUser, "', '", memberGroup.CreateTime, "', '", memberGroup.ModifyUser, "', '",
                memberGroup.ModifyTime, "', ", memberGroup.IsDeleted,
                ")"
            });
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '"
                            , Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '",
                            memberGroup.CreateUser, "', '", memberGroup.CreateTime, "')"
                        });
                    sqlList.Add(item);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int AddByAdmin(ShopNum1_Member Member)
        {
            var paraName = new string[0x20];
            var paraValue = new string[0x20];
            paraName[0] = "@Name";
            paraValue[0] = Member.Name;
            paraName[1] = "@Sex";
            paraValue[1] = Member.Sex.ToString();
            paraName[2] = "@Photo";
            paraValue[2] = Member.Photo;
            paraName[3] = "@QQ";
            paraValue[3] = Member.QQ;
            paraName[4] = "@AddressValue";
            paraValue[4] = Member.AddressValue;
            paraName[5] = "@Fax";
            paraValue[5] = Member.Fax;
            paraName[6] = "@WebSite";
            paraValue[6] = Member.WebSite;
            paraName[7] = "@Mobile";
            paraValue[7] = Member.Mobile;
            paraName[8] = "@modifyUser";
            paraValue[8] = Member.ModifyUser;
            paraName[9] = "@modifyTime";
            paraValue[9] = Member.ModifyTime.ToString();
            paraName[10] = "@MemLoginID";
            paraValue[10] = Member.MemLoginID;
            paraName[11] = "@AddressCode";
            paraValue[11] = Member.AddressCode;
            paraName[12] = "@Vocation";
            paraValue[12] = Member.Vocation;
            paraName[13] = "@Postalcode";
            paraValue[13] = Member.Postalcode;
            paraName[14] = "@CostMoney";
            paraValue[14] = Member.CostMoney.ToString();
            paraName[15] = "@Birthday";
            paraValue[15] = Member.Birthday.ToString();
            paraName[0x10] = "@MemberRank";
            paraValue[0x10] = Member.MemberRank.ToString();
            paraName[0x11] = "@IsMailActivation";
            paraValue[0x11] = Member.IsMailActivation.ToString();
            paraName[0x12] = "@RegeDate";
            paraValue[0x12] = Member.RegeDate.ToString();
            paraName[0x13] = "@LoginTime";
            paraValue[0x13] = Member.LoginTime.ToString();
            paraName[20] = "@Tel";
            paraValue[20] = Member.Tel;
            paraName[0x15] = "@LockAdvancePayment";
            paraValue[0x15] = Member.LockAdvancePayment.ToString();
            paraName[0x16] = "@IsForbid";
            paraValue[0x16] = Member.IsForbid.ToString();
            paraName[0x17] = "@email";
            paraValue[0x17] = Member.Email;
            paraName[0x18] = "@IdentityCard";
            paraValue[0x18] = Member.IdentityCard;
            paraName[0x19] = "@AdvancePayment";
            paraValue[0x19] = Member.AdvancePayment.ToString();
            paraName[0x1a] = "@LockSocre";
            paraValue[0x1a] = Member.LockSocre.ToString();
            paraName[0x1b] = "@Pwd";
            paraValue[0x1b] = Member.Pwd;
            paraName[0x1c] = "@PayPwd";
            paraValue[0x1c] = Member.PayPwd;
            paraName[0x1d] = "@Area";
            paraValue[0x1d] = Member.Area;
            paraName[30] = "@MemberType";
            paraValue[30] = Member.MemberType.ToString();
            paraName[0x1f] = "@MemberRankGuid";
            paraValue[0x1f] = Member.MemberRankGuid.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_AddMemberInfoByAdmin", paraName, paraValue);
        }

        public int CategoryAdPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_CategoryAdPayMent SET IsPayMent=", 1, ", IsEffective=", 1, ", PayMentTime='",
                    DateTime.Now, "'  WHERE TradeID='", tradeID, "' AND  MemLoginID='", memLoginID, "'"
                });
            sqlList.Add(item);
            decimal num = advancePayment - shouldPay;
            if (num < 0M)
            {
                return 0;
            }
            item =
                string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=", num, " WHERE MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            UpdateCostMoney(memLoginID, shouldPay);
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int CheckBindMobile(string Mobile, string memloginid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@memloginid";
            parms[1].Value = memloginid;
            string strSql = string.Empty;
            strSql = "SELECT Mobile FROM ShopNum1_Member WHERE Mobile =@Mobile";
            if (memloginid != "")
            {
                object obj2 = strSql + " AND MemLoginID=@memloginid";
                strSql = string.Concat(new[] { obj2, " AND IsMobileActivation='", 0, "'" });
            }
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql, parms);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public int CheckEmail(string email, string memloginid)
        {
            string str = string.Empty + "   SELECT  Email,Mobile  FROM  ShopNum1_Member  WHERE  1=1    ";
            if (memloginid != "")
            {
                object obj2 = str + "    AND  MemLoginID='" + memloginid + "'    ";
                str = string.Concat(new[] { obj2, "    AND  IsEmailActivation='", 0, "'    " });
            }
            if (DatabaseExcetue.ReturnDataTable(str + "    AND  Email='" + email + "'    ").Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public DataTable CheckIsForbid(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("select IsForbid from ShopNum1_Member  where MemLoginID=@MemLoginID AND IsDeleted =0", parms);
        }

        public int CheckmemEmail(string Email)
        {
            string strProcedureName = "Pro_ShopNum1_CheckMemEmail";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Email";
            paraValue[0] = Email;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public int CheckIdentityCard(string identifycard)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@identifycard";
            parms[0].Value = identifycard;
            string sqlQuery = @"select * from ShopNum1_Member where IdentityCard =@identifycard ";

            DataTable table = DatabaseExcetue.ReturnDataTable(sqlQuery, parms);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }

            return table.Rows.Count;
        }

        public int CheckIdentityCard2(string identifycard)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@identifycard";
            parms[0].Value = identifycard;
            string sqlQuery = @"select * from ShopNum1_Member where IdentityCard =@identifycard ";

            DataTable table = DatabaseExcetue.ReturnDataTable(sqlQuery, parms);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }

            return table.Rows.Count;
        }



        public DataTable CheckMemEmailByEmail(string Email)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Email";
            parms[0].Value = Email;
            string strSql = string.Empty;
            strSql = "SELECT Email,MemLoginID FROM ShopNum1_Member WHERE  1=1 ";
            if (Email != "")
            {
                strSql = strSql + "  and Email =@Email";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable CheckMemEmailByEmail_two(string Email, string User)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Email";
            parms[0].Value = Email;
            parms[1].ParameterName = "@User";
            parms[1].Value = User;
            string strSql = string.Empty;
            strSql = "SELECT * FROM ShopNum1_Member WHERE  1=1 ";
            if (Email != "" && User != "")
            {
                strSql = strSql + "  and Email =@Emai and MemLoginID=@Use or MemLoginNO=@User";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public int CheckmemLoginIDtwo(string memLoginID, string realname)
        {
            string strProcedureName = "Pro_ShopNum1_CheckmemLoginIDtwo";
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memLoginID";
            paraValue[0] = memLoginID;
            paraName[1] = "@realname";
            paraValue[1] = realname;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }
        public int CheckmemLoginID(string memLoginID)
        {
            string strProcedureName = "Pro_ShopNum1_CheckmemLoginID";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memLoginID";
            paraValue[0] = memLoginID;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public DataTable CheckMemMobileByMobile(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            string strSql = string.Empty;
            strSql = " SELECT Mobile,MemLoginID FROM ShopNum1_Member  where 1=1";
            if (Mobile != "")
            {
                strSql = strSql + "  and  Mobile =@Mobile";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable CheckMemMobileByMobile(string Mobile, string User)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@User";
            parms[1].Value = User;
            string strSql = string.Empty;
            strSql = " SELECT Mobile,MemLoginID FROM ShopNum1_Member  where 1=1";
            if (Mobile != "")
            {
                strSql = strSql + "  and  Mobile =@Mobile and (MemLoginID=@User or MemLoginNO=@User)";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }
        public DataTable CheckMemMobileByMobile_two(string Mobile, string User)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            parms[1].ParameterName = "@User";
            parms[1].Value = User;
            string strSql = string.Empty;
            strSql = " SELECT Mobile,MemLoginID FROM ShopNum1_Member  where 1=1";
            if (Mobile != "" && User != "")
            {
                strSql = strSql + "  and  Mobile =@Mobile and (MemLoginID=@User or MemLoginNO=@User)";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public int CheckMemMobileByMobile1(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            string strSql = string.Empty;
            strSql = "SELECT MemLoginID, Pwd,Mobile FROM ShopNum1_Member  WHERE  1=1 ";
            if (Mobile != "")
            {
                strSql = strSql + "  and Mobile =@Mobile";
            }
            if (DatabaseExcetue.ReturnDataTable(strSql, parms).Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public int CheckMobile(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;
            DataTable table =
                DatabaseExcetue.ReturnDataTable("select Mobile from ShopNum1_Member where Mobile =@Mobile", parms);
            if ((table == null) || (table.Rows.Count <= 0))
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public int CheckPassword(string memLoginID, string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@string_0";
            parms[1].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  Guid, MemLoginID,  Pwd  FROM ShopNum1_Member  WHERE MemLoginID =@memLoginID AND Pwd=@string_0", parms).Rows.Count;
        }
        public int CheckPayPassword(string memLoginID, string string_0)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@string_0";
            parms[1].Value = string_0;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  Guid, MemLoginID,  PayPwd  FROM ShopNum1_Member  WHERE MemLoginID =@memLoginID AND PayPwd=@string_0", parms).Rows.Count;
        }


        public DataTable CheckSafeRank(string MemLoginID, string where)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT MemLoginID,IsMobileActivation,IsEmailActivation FROM ShopNum1_Member WHERE MemLoginID =@MemLoginID AND        ( IsMobileActivation =1  " + where + "    IsEmailActivation=1 )", parms);
        }


        public string CompareMemberRankGuid(string memberRankGuid1, string memberRankGuid2)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid, \tScore    FROM ShopNum1_MemberRank ORDER BY Score ASC ";
            DataTable table = DatabaseExcetue.ReturnDataTable(strSql);
            int num = -1;
            int num2 = -1;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (memberRankGuid1 == table.Rows[i]["Guid"].ToString())
                {
                    num = i;
                }
                if (memberRankGuid2 == table.Rows[i]["Guid"].ToString())
                {
                    num2 = i;
                }
            }
            if (num >= num2)
            {
                return memberRankGuid1;
            }
            return memberRankGuid2;
        }

        public int Delete(string guids)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = "DELETE ShopNum1_Member WHERE guid IN (" + guids + ")";
            sqlList.Add(item);
            string str2 = string.Empty;
            string[] strArray = guids.Split(new[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str2 == string.Empty)
                {
                    str2 = "'" + GetMemLoginIDByGuid(strArray[i]) + "'";
                }
                else
                {
                    str2 = str2 + ",'" + GetMemLoginIDByGuid(strArray[i]) + "'";
                }
            }
            sqlList.Add("DELETE ShopNum1_SecondUser where MemLogID in (" + str2 + ")");
            item = "DELETE ShopNum1_MemberProductCollect  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MemberShopCollect  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Address WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_ProductComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_SupplyDemandComment  WHERE CreateMerber IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_ProductComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_SupplyDemand  WHERE MemberID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_CategoryInfo  WHERE AssociatedMemberID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_VideoComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ArticleComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_NewsComment  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_MessageBoard  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_AdvancePaymentModifyLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_AdvancePaymentFreezeLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ScoreModifyLog  WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ScoreFreezeLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_RankScoreModifyLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_AdvancePaymentApplyLog WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MemberAssignGroup WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_ArticleComment WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MessageInfo WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_UserMessage WHERE SendID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_OrderInfo WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_OrderComplaint WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_MemberReport WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_ProductBooking WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            item = "DELETE ShopNum1_Shop_Cart WHERE MemLoginID IN (" + str2 + ")";
            item = "DELETE ShopNum1_ShopProduct_Browse WHERE MemLoginID IN (" + str2 + ")";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteMemberActivate(string strMobile)
        {
            return
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MemberActivate WHERE Phone = '" +
                                            Operator.FilterString(strMobile) + "' AND Isinvalid=0 AND type=1");
        }

        /// <summary>
        /// 东风注册失败连删3G
        /// </summary>
        /// <param name="strMobile"></param>
        /// <returns></returns>
        public int DeleteLian3G(string MemloginNO)
        {
            return
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_Member WHERE MemLoginNO='" + MemloginNO + "'");
        }

        public int DeleteRealName(string strGuId)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Format("update ShopNum1_Member set IdentificationIsAudit=Null where guid=" + strGuId,
                        new object[0]));
        }

        public DataTable FindPwdEamil(string MemLoginID, string Email)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Email";
            parms[1].Value = Email;
            return
                DatabaseExcetue.ReturnDataTable("select MemLoginID,Pwd  from ShopNum1_Member where MemLoginID =@MemLoginID and Email =@Email", parms);
        }

        public DataTable GetAllShopInfoByGuid(string guids)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            return DatabaseExcetue.ReturnDataTable("select *  from ShopNum1_Member  where  Guid" + andSql, parms.ToArray());
        }

        public DataTable SelectMemberByMemLoginID(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return DatabaseExcetue.ReturnDataTable("select AdvancePayment,Score_dv  from ShopNum1_Member  where  MemLoginID =@MemLoginID", parms);
        }
        public DataTable SelectMemberByMemLoginIDAndName(string MemLoginID, string name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@name";
            parms[1].Value = name;
            return DatabaseExcetue.ReturnDataTable("select AdvancePayment,Score_dv  from ShopNum1_Member  where  MemLoginID =@MemLoginID and RealName=@name and MemberRankGuid='197B6B51-3EB3-452E-BD03-D560577A34D2'", parms);
        }
        public DataTable SelectnoByMemLoginID(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginNO;
            return DatabaseExcetue.ReturnDataTable("select  MemLoginID  from ShopNum1_Member  where  MemLoginNO =@MemLoginID", parms);
        }

        public DataTable SelectOrderByTime(DateTime startTim, DateTime orderTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@startTim";
            parms[0].Value = startTim;
            parms[1].ParameterName = "@orderTime";
            parms[1].Value = orderTime;
            return DatabaseExcetue.ReturnDataTable("select *  from ShopNum1_OrderInfo  left join ShopNum1_OrderProduct  on ShopNum1_OrderProduct.OrderInfoGuid=ShopNum1_OrderInfo.Guid  where ShopNum1_OrderInfo.PaymentStatus=1 and ShopNum1_OrderInfo.PayTime between @startTim and @orderTime", parms);
        }


        public DataTable SelectOrderByTimeAndcarghid(DateTime startTim, DateTime orderTime, int carghid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@startTim";
            parms[0].Value = startTim;
            parms[1].ParameterName = "@orderTime";
            parms[1].Value = orderTime;
            parms[2].ParameterName = "@carghid";
            parms[2].Value = carghid;
            return DatabaseExcetue.ReturnDataTable("select *  from ShopNum1_OrderInfo  left join ShopNum1_OrderProduct  on ShopNum1_OrderProduct.OrderInfoGuid=ShopNum1_OrderInfo.Guid  where ShopNum1_OrderInfo.shop_category_id =@carghid and ShopNum1_OrderInfo.PaymentStatus=1 and ShopNum1_OrderInfo.PayTime between @startTim and @orderTime", parms);
        }

        public DataTable SelecetImgByGoods_id(int goods_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@goods_id";
            parms[0].Value = goods_id;
            return DatabaseExcetue.ReturnDataTable("select MultiImages from ShopNum1_Shop_Product where Id =@goods_id", parms);
        }
        public DataTable SelectAllByGoods_id(int goods_id, int cate_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@goods_id";
            parms[0].Value = goods_id;
            parms[1].ParameterName = "@cate_id";
            parms[1].Value = cate_id;
            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id where ShopNum1_Shop_Product.Id =@goods_id and shop_category_id=@cate_id", parms);
        }

        public DataTable SelectGoodsByNum(int startNum, int overNum, int cate_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@startNum";
            parms[0].Value = startNum;
            parms[1].ParameterName = "@overNum";
            parms[1].Value = overNum;
            parms[2].ParameterName = "@cate_id";
            parms[2].Value = cate_id;
            return DatabaseExcetue.ReturnDataTable("select   top   @overNum  [Guid],ShopNum1_Shop_Product.Id as shopidtwo,Name,ProductNum,RepertoryCount,UnitName,Detail,Instruction,BrandGuid,BrandName,ProductSeriesCode,ProductSeriesName,ProductCategoryCode,ProductCategoryName,OriginalImage,ThumbImage,SmallImage,MultiImages,ClickCount,CollectCount,BuyCount,CommentCount,SaleNumber,MonthSale,[Description],Keywords,AddressCode,AddressValue,MemLoginID,ShopName,IsAudit,IsNew,IsHot,IsPromotion,IsRecommend,IsBest,FeeType,Post_fee,Express_fee,Ems_fee,IsReal,IsSell,IsShopNew,IsShopHot,IsShopPromotion,IsShopRecommend,IsShopGood,FeeTemplateID,FeeTemplateName,MinusFee,Wap_desc,Wap_detail_url,ModifyUser,ModifyTime,CreateTime,CreateUser,SaleTime,DeSaleTime,StartTime,EndTime,ProductState,Score,Ctype,IsDeleted,IsSaled,OrderID,SetStock,PulishType,RepertoryAlertCount,ShopNum1_Shop_Product.agentId,Color,Size,ShopNum1_Shop_ProductPrice.id as idfree,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark   from   ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id where   ShopNum1_Shop_Product.id > ( select  max(id)  from  (select top @startNum ShopNum1_Shop_Product.id  from  ShopNum1_Shop_Product left join ShopNum1_Shop_ProductPrice on ShopNum1_Shop_ProductPrice.productId=ShopNum1_Shop_Product.id  where ShopNum1_Shop_ProductPrice.shop_category_id=" + cate_id + " order by ShopNum1_Shop_Product.id ) as t)   and ShopNum1_Shop_ProductPrice.shop_category_id=@cate_id order by ShopNum1_Shop_Product.id", parms);
        }

        public decimal GetCostMoney(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;

            return
                Convert.ToDecimal(
                    DatabaseExcetue.ReturnDataTable(" SELECT  CostMoney  FROM ShopNum1_Member  WHERE MemLoginID=@memLoginID", parms).Rows[0]["CostMoney"].ToString());
        }

        public DataTable GetMemberAccount(string MemberLogin)
        {
            var builder = new StringBuilder();
            builder.Append(" SELECT * from ShopNum1_Member ");
            builder.Append(" WHERE MemLoginID ='" + MemberLogin + "'");
            DataTable table = DatabaseExcetue.ReturnDataTable(builder.ToString());
            table.Columns.Add("buyOrder", typeof(int));
            table.Columns.Add("shopOrder", typeof(int));
            if (table.Rows.Count > 0)
            {
                var builder2 = new StringBuilder();
                builder2.Append(
                    string.Concat(new object[]
                    {
                        " SELECT Count(*) buyOrder FROM  ShopNum1_OrderInfo WHERE MemLoginID='", MemberLogin,
                        "' and confirmtime>='", DateTime.Now.AddMonths(-1), "' "
                    }));
                int num = 0;
                num = Convert.ToInt32(DatabaseExcetue.ReturnDataTable(builder2.ToString()).Rows[0][0].ToString());
                var builder3 = new StringBuilder();
                builder3.Append(
                    string.Concat(new object[]
                    {
                        " SELECT Count(*) shopOrder FROM  ShopNum1_OrderInfo WHERE ShopID='", MemberLogin,
                        "' and confirmtime>='", DateTime.Now.AddMonths(-1), "' "
                    }));
                int num2 = 0;
                num2 = Convert.ToInt32(DatabaseExcetue.ReturnDataTable(builder3.ToString()).Rows[0][0].ToString());
                table.Rows[0]["buyOrder"] = num;
                table.Rows[0]["shopOrder"] = num2;
                return table;
            }
            return table;
        }

        public int GetMemberCountByCode(string code, string isother)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@code";
            paraValue[0] = code;
            paraName[1] = "@isother";
            paraValue[1] = isother;
            return
                Convert.ToInt32(DatabaseExcetue.ReturnProcedureString("Pro_ShopNum1_MemberGetMemberCountByCode",
                    paraName, paraValue));
        }

        public DataTable GetMemberIdentificationInfo(string member)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memloginid";
            paraValue[0] = member;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberIdentificationInfo", paraName,
                paraValue);
        }

        public DataTable GetMemberInfoByGuID(string strGuId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strGuId";
            parms[0].Value = strGuId;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select A.MemLoginID,A.Email,B.ShopID,B.IsAudit,b.tel,a.tel as mobile FROM ShopNum1_ShopInfo AS B,ShopNum1_Member AS A WHERE A.MemLoginID=B.MemLoginID AND B.guid=@strGuId", parms);
        }

        public DataTable GetMemberInfoByMemLoginID(string memLoignID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoignID";
            parms[0].Value = memLoignID;
            return
                DatabaseExcetue.ReturnDataTable(
                    "select A.MemLoginID,A.Email,B.ShopID,B.IsAudit FROM ShopNum1_ShopInfo AS B,ShopNum1_Member AS A WHERE A.MemLoginID=B.MemLoginID AND A.MemLoginID=@memLoignID", parms);
        }

        public DataTable GetMemberPassWord(string loginID, string string_0)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memLoginID";
            paraName[1] = "@pwd";
            paraValue[0] = loginID;
            paraValue[1] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberPassWord", paraName, paraValue);
        }


        public DataTable GetMemberWord(string loginID)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memLoginID";

            paraValue[0] = loginID;

            return DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Member where MemLoginID=@memLoginID or MemLoginNO=@memLoginID", paraName, paraValue);
        }

        public decimal GetMemberPriceByGuid(string ProudctGuid, string MemLoginID)
        {
            string strSql = string.Empty;
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@ProudctGuid";
            paraValue[0] = ProudctGuid;
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;
            strSql =
                "select price from ShopNum1_ProductMemberRankPrice where MemberRankGuid=(select guid from ShopNum1_MemberRank where minScore<(select MemberRank from ShopNum1_Member where MemLoginID=@MemLoginID) and maxScore>= (select MemberRank from ShopNum1_Member where MemLoginID=@MemLoginID)) and ProudctGuid=@ProudctGuid";
            object obj2 = DatabaseExcetue.ReturnObject(strSql, paraName, paraValue);
            decimal num = 0.0M;
            if ((obj2 != null) && (obj2 != DBNull.Value))
            {
                num = (decimal)obj2;
            }
            return num;
        }

        public DataTable GetMemberQuery(string memLoginID)
        {
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_GetMemberQuery", "@memLoginID", memLoginID);
        }
        public string GetMemberRankGuid(string strMemberId)
        {
            return
                DatabaseExcetue.ReturnString("  SELECT MemberRankGuid FROM  ShopNum1_Member WHERE memLoginID='" + strMemberId +
                                                "'");
        }
        public DataTable GetMemInfo(string strMemberId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strMemberId";
            parms[0].Value = strMemberId;
            return
                DatabaseExcetue.ReturnDataTable("  SELECT * FROM  ShopNum1_Member WHERE memLoginID=@strMemberId", parms);
        }
        /// <summary>
        /// 根据编号查询会员所有信息
        /// </summary>
        /// <param name="memberloginid"></param>
        /// <returns></returns>
        public DataTable GetMemInfoByNO(string strMemberId)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@strMemberId";
            parms[0].Value = strMemberId;
            return
                DatabaseExcetue.ReturnDataTable("  SELECT * FROM  ShopNum1_Member WHERE memLoginNO=@strMemberId", parms);
        }
        public DataTable GetMemInfoByMemberloginId(string memberloginid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetMemInfoByMemLoginId", paraName, paraValue);
        }

        public string GetMemLoginIDByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            DataTable table =
                DatabaseExcetue.ReturnDataTable("SELECT MemLoginID FROM ShopNum1_Member WHERE Guid=@guid", parms);
            if ((table != null) && (table.Rows.Count > 0))
            {
                return table.Rows[0]["MemLoginID"].ToString();
            }
            return "";
        }

        public DataTable GetMemTypeByGuid(string guids)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guids";
            parms[0].Value = guids.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable("SELECT MemberType FROM ShopNum1_Member WHERE guid IN (@guids)", parms);
        }

        public DataTable GetALLMemberAll(string MemLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;

            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_Member WHERE MemLoginNO=@MemLoginNO ", parms);
        }

        public DataTable GetALLMemberAll3(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT [MemLoginID],name,Photo,Score_dv,Score_hv,Mobile,AdvancePayment FROM ShopNum1_Member WHERE MemLoginID=@MemLoginID ", parms);
        }
        public DataTable GetALLMemberAll1(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT mobiletype,Score_dv,Score_hv,Mobile,AdvancePayment FROM ShopNum1_Member WHERE MemLoginID=@MemLoginID ", parms);
        }


        public DataTable GetMobileOrMemLoginID(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginIDOrMobile";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("SELECT mobiletype,Score_dv,Score_hv,Mobile,AdvancePayment FROM ShopNum1_Member WHERE (MemLoginID=@MemLoginIDOrMobile or Mobile=@MemLoginIDOrMobile)", parms);
        }

        public DataTable GetALLMobileAll1(string Mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Mobile";
            parms[0].Value = Mobile;

            return
                DatabaseExcetue.ReturnDataTable("  SELECT mobiletype,Score_dv,Score_hv,Mobile,AdvancePayment FROM ShopNum1_Member WHERE Mobile=@Mobile or MemLoginID= @Mobile", parms);
        }

        public DataTable GetALLMemberAll2(string mobile)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@mobile";
            parms[0].Value = mobile;

            return
                DatabaseExcetue.ReturnDataTable("SELECT Score_dv,Score_hv,Mobile,AdvancePayment,MemLoginID FROM ShopNum1_Member WHERE Mobile=@mobile ", parms);
        }

        public DataTable GetmemebierEthUSDTCount(string MemLoginID, string type)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            if (type == "15")
            {
                return
                    DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(15)", parms);
            }
            else
            {
                return
                    DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(16)", parms);
            }
        }

        public DataTable Getmemebier1Eth_Usdt(string MemLoginID, string type, int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            parms[2].ParameterName = "@top";
            parms[2].Value = top;
            parms[3].ParameterName = "@number";
            parms[3].Value = number;
            if (type == "15")//15 Eth转usdt
            {
                return
                    DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],Memo as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(15))as a where RowNumber BETWEEN @top and @number ", parms);
            }
            else
            {
                return
                    DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],Memo as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in(16))as a where RowNumber BETWEEN @top and @number ", parms);
            }

        }
        public DataTable Getmemebier1(string MemLoginID, string type, string type1, int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            parms[2].ParameterName = "@top";
            parms[2].Value = top;
            parms[3].ParameterName = "@number";
            parms[3].Value = number;
            if (type1 == "1")//1收款人
            {
                if (type == "2")
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo]+[RMemberID] as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(2,4))as a where RowNumber BETWEEN @top and @number ", parms);
                }
                if (type == "12")
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],('转出'+RMemberID) as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(@type))as a where RowNumber BETWEEN @top and @number ", parms);
                }
                if (type == "22")
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],('转出'+RMemberID) as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(@type))as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type=@type)as a where RowNumber BETWEEN @top and @number ", parms);
                }
            }
            else //2转账人
            {
                if (type == "2")
                {
                    return
                           DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[MemLoginID]+[Memo] as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in (2,4))as a where RowNumber BETWEEN @top and @number ", parms);
                }
                if (type == "12")
                {
                    return
                           DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date], (MemLoginID+'转入') as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in (@type))as a where RowNumber BETWEEN @top and @number ", parms);
                }
                if (type == "22")
                {
                    return
                           DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date], (MemLoginID+'转入') as Memo,[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in (@type))as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else
                {
                    return
                          DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type=@type)as a where RowNumber BETWEEN @top and @number ", parms);
                }
            }
        }

        public DataTable NewestEarningsSingleSQl(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
               DatabaseExcetue.ReturnDataTable(" select top 1 Bonus1,(bonus2+Bonus3) as Bonus2,Bonus5 as Bonus3,Bonus4,CreateTime from [Bonus] where [MemLoginID]=@MemLoginID   order by [CreateTime] desc", parms);
        }
        public DataTable QLCNewestEarnings(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return DatabaseExcetue.ReturnDataTable("select Score_pv_a ,Score_dv,Score_hv,(Score_pv_a+Score_dv) as AllNEC , Score_pv_b, AdvancePayment from [ShopNum1_Member]where [MemLoginID]=@MemLoginID ", parms);

        }

        public DataTable QLCNewestEarningsNCE(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return DatabaseExcetue.ReturnDataTable("select NECBiLi  from  QLX_NECBiLiAPP where [TypeNumber]=2 ", parms);

        }
        public DataTable QLCNewestEarningsRMBNCE(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return DatabaseExcetue.ReturnDataTable("select NECBiLi  from  QLX_NECBiLiAPP where [TypeNumber]=3 ", parms);

        }
        public DataTable NewestEarnings(string MemLoginID, string earningsType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@earningsType";
            parms[1].Value = earningsType;

            if (earningsType == "1")
            {
                return
                    DatabaseExcetue.ReturnDataTable("   select top 1 Bonus1 as bounsEarnings,CreateTime from [Bonus] where [MemLoginID]=@MemLoginID   order by [CreateTime] desc", parms);
            }
            else if (earningsType == "2")
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select top 1 (Bonus2+Bonus3) as bounsEarnings,CreateTime from [Bonus] where [MemLoginID]=@MemLoginID  order by [CreateTime] desc ", parms);
            }
            else if (earningsType == "3")//签到收益
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select top 1 Bonus5 as bounsEarnings,CreateTime from [Bonus] where [MemLoginID]=@MemLoginID   order by [CreateTime] desc ", parms);
            }
            else//赠送收益
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select top 1 Bonus4 as bounsEarnings,CreateTime from [Bonus] where [MemLoginID]=@MemLoginID  order by [CreateTime] desc ", parms);
            }
        }

        public DataTable MyEarningsDetails(string MemLoginID, string top, string number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            string sql = "";

            sql = "select  * from ( select  MemLoginID,Bonus1 as hashrateEarnings ,(Bonus2+Bonus3) as linkEarnings ,Bonus5 as signinEarnings ,Bonus4 as presenterEarnings , (Bonus1+Bonus2+Bonus3+Bonus4+Bonus5) as EveryDayAllEarnings,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID ) as a where  RowNumber BETWEEN  @top and @number ";

            return
                DatabaseExcetue.ReturnDataTable(sql, parms);
        }
        public DataTable MyEarningsDetailsNew(string MemLoginID, string type, string top, string number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            string sql = "";
            if (type == "1")
            {
                sql = "select  * from ( select  MemLoginID,Bonus1 as Bonus  ,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and Bonus1>0 ) as a where  RowNumber BETWEEN  @top and @number ";
            }
            if (type == "2")
            {
                sql = "select  * from ( select  MemLoginID,(Bonus3+Bonus2) as Bonus,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and (Bonus3+Bonus2)>0 ) as a where  RowNumber BETWEEN  @top and @number ";
            }

            if (type == "3")
            {
                sql = "select  * from ( select  MemLoginID,Bonus5 as Bonus,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and Bonus5>0 ) as a where  RowNumber BETWEEN  @top and @number ";
            }

            if (type == "4")
            {
                sql = "  select  * from ( select  MemLoginID,Bonus4 as Bonus,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and Bonus4>0 ) as a where  RowNumber BETWEEN  @top and @number ";
            }
            if (type == "6")
            {
                sql = "  select  * from ( select  MemLoginID,Bonus6 as Bonus,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and Bonus6>0 ) as a where  RowNumber BETWEEN  @top and @number ";
            }
            return
                DatabaseExcetue.ReturnDataTable(sql, parms);
        }
        public DataTable MyEarningsDetailsNewSheQu(string MemLoginID, string type, string top, string number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            string sql = "";

            sql = "select  * from ( select  MemLoginID,Bonus3,Bonus2,'分享收益' as fenxiang, '链接收益' as lianjie ,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and (Bonus3+Bonus2)>0 ) as a where  RowNumber BETWEEN  @top and @number ";

            return
                DatabaseExcetue.ReturnDataTable(sql, parms);
        }

        public DataTable MyEarningsDetailsNewSheQuEnglish(string MemLoginID, string type, string top, string number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            string sql = "";

            sql = "select  * from ( select  MemLoginID,Bonus3,Bonus2,'Affiliate Programme' as fenxiang, 'Direct commission plan' as lianjie ,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC) AS RowNumber from Bonus where MemLoginID=@MemLoginID and (Bonus3+Bonus2)>0 ) as a where  RowNumber BETWEEN  @top and @number ";

            return
                DatabaseExcetue.ReturnDataTable(sql, parms);
        }

        public DataTable AccountEarningsSingleSQL(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return DatabaseExcetue.ReturnDataTable(" select  sum(Bonus1) as Bonus1,sum(Bonus2+Bonus3) as Bonus2,sum(Bonus5) as Bonus3,sum(Bonus1+Bonus2+Bonus3+Bonus5) as Bonus4 from bonus where [MemLoginID]=@MemLoginID  ", parms);

        }


        public DataTable AccountEarnings(string MemLoginID, string earningsType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@earningsType";
            parms[1].Value = earningsType;
            //hashrate 算力收益1 link链接收益2 signin签到收益3 presenter赠送收益4 
            if (earningsType == "1")//算力收益
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select  sum(Bonus1) as SingleEarnings from bonus where [MemLoginID]=@MemLoginID   ", parms);
            }
            else if (earningsType == "2")//链接收益
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select  sum(Bonus2+Bonus3) as SingleEarnings from bonus where [MemLoginID]=@MemLoginID   ", parms);
            }
            else if (earningsType == "3")//签到收益
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select  sum(Bonus5) as SingleEarnings from [bonus] where [MemLoginID]=@MemLoginID  ", parms);
            }
            else if (earningsType == "11")
            {
                return
                   DatabaseExcetue.ReturnDataTable("  select MyAllBonus,(select  sum(Bonus1) as SingleEarnings   from bonus where [MemLoginID]=@MemLoginID) as SingleEarnings from [ShopNum1_Member] where [MemLoginID]=@MemLoginID", parms);
            }

            else if (earningsType == "22")
            {
                return
                   DatabaseExcetue.ReturnDataTable("select SUM(ShouldPayPrice) as MyAllBonus, SUM(ShouldPayPrice*SuanLiUnitPrice) as SingleEarnings FROM [ShopNum1_OrderInfo] where shop_category_id=4 and OderStatus!=0 and  MemLoginID=@MemLoginID", parms);

            }



            else//赠送收益
            {
                return
                    DatabaseExcetue.ReturnDataTable(" select  sum(Bonus4) as SingleEarnings from bonus where [MemLoginID]=@MemLoginID   ", parms);
            }
        }

        public DataTable Cotice(int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;

            return
                DatabaseExcetue.ReturnDataTable("select * from ( select [Guid],convert(varchar(11),CreateTime,120) as CreateTime, [Title], ROW_NUMBER() OVER( Order by CreateTime DESC ) AS RowNumber from ShopNum1_Announcement where  IsDeleted=0 )as a where RowNumber BETWEEN @top and @number ", parms);

        }

        public DataTable WeekState(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;


            return
                DatabaseExcetue.ReturnDataTable("      select [Bonus],(SELECT DATEDIFF(S,'1970-01-01 00:00:00', [QLXtime]) - 8 * 3600) as Createtime  from [QLXSignIn] where MemLoginID=@MemLoginID and QLXtime >=(SELECT   CONVERT(nvarchar(10), DATEADD(wk, DATEDIFF(wk,0,DATEADD(dd, -1, getdate()) ), -1),121) ) and QLXtime <=(SELECT   CONVERT(nvarchar(10), DATEADD(wk, DATEDIFF(wk,0,DATEADD(dd, -1, getdate()) ), 5),121)) order by QLXtime desc ", parms);

        }

        public DataTable BounsKCE(string MemLoginID, string Type, string top, string number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            string sql = "";
            if (Type == "1")
            {
                sql = "  select * from ( select [MemLoginID],[Bonus1],[CreateTime],standardfactor,[Bonus2],[membership_Level],isdelete,BonusAll=case when standardfactor=0 and IsDelete!=2 then (Bonus1*Proportion) when standardfactor=1 and IsDelete!=2 then (Bonus1+Bonus2)* Proportion when IsDelete=2 then 0 end, ROW_NUMBER() OVER( Order by CreateTime DESC ) AS RowNumber from [Bonus] where [MemLoginID]=@MemLoginID)as a where RowNumber BETWEEN @top and @number";
            }
            if (Type == "2")
            {
                sql = "   select * from ( select [MemLoginID],[CreateTime],standardfactor,[Bonus3],[membership_Level],isdelete, ROW_NUMBER() OVER( Order by CreateTime DESC ) AS RowNumber from [Bonus] where [MemLoginID]=@MemLoginID)as a where RowNumber BETWEEN @top and @number";
            }
            if (Type == "3")
            {
                sql = " select * from ( select MemLoginID,[num1] as Allnum,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC ) AS RowNumber from [KCEBonusRecord] where  [MemLoginID]=@MemLoginID )as a where RowNumber BETWEEN @top and @number";
            }
            if (Type == "4")
            {
                sql = " select * from ( select MemLoginID, Allnum*0.1 as Allnum,CreateTime, ROW_NUMBER() OVER( Order by CreateTime DESC ) AS RowNumber from [KCEBonusRecord] where  [MemLoginID]=@MemLoginID )as a where RowNumber BETWEEN @top and @number";
            }
            return
                DatabaseExcetue.ReturnDataTable(sql, parms);

        }

        public DataTable QueryReference1(string MemLoginID, int top, int number)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("  select * from ( select MemLoginID,IdentityCard,YesterdayAllBonus,case PersonCate when 0 then '普通社区'  when 1 then '节点社区'  when 2 then '集群社区' when 3 then '超级社区' when 4 then '特级社区' else '错误' end as PersonCate,RealName,Superior,Mobile,RegeDate,Photo,membership_Level,Name, ROW_NUMBER() OVER( Order by RegeDate DESC ) AS RowNumber from [ShopNum1_Member] where Superior =@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

        }
        public DataTable QueryReferenceEnglish(string MemLoginID, int top, int number)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("  select * from ( select MemLoginID,IdentityCard,YesterdayAllBonus,case PersonCate when 0 then 'Ordinary community'  when 1 then 'Nodes in the community'  when 2 then 'Cluster community' when 3 then 'Super community' when 4 then 'Super community' else 'error' end as PersonCate,RealName,Superior,Mobile,RegeDate,Photo,membership_Level,Name, ROW_NUMBER() OVER( Order by RegeDate DESC ) AS RowNumber from [ShopNum1_Member] where Superior =@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

        }

        public DataTable Select_NEC_TiXian(string MemLoginID, string type, string top, string number)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            if (type == "1")//提现ETH
            {
                return
                    DatabaseExcetue.ReturnDataTable("  select * from ( select [MemloginID],[ETHAddress],[ETH] as MoneyNumber,case [Status]    when 0 then '未审核' when 1 then '已审核' when 2 then '已拒绝' end as [Status],[TxTime],[Shop_ETHAddress],[IsDeleted],[TxHash] , ROW_NUMBER() OVER( Order by TxTime DESC ) AS RowNumber from [Nec_TiXian] where MemLoginID =@MemLoginID and IsDeleted=0 )as a where RowNumber BETWEEN @top and @number ", parms);
            }
            else//提现NEC
            {
                return
                DatabaseExcetue.ReturnDataTable("  select * from ( select [MemloginID],[NECAddress] as ETHAddress,[NEC] as MoneyNumber,case [Status]    when 0 then '未审核' when 1 then '已审核' when 2 then '已拒绝' end as [Status],[TxTime],[IsDeleted],[TxHash], ROW_NUMBER() OVER( Order by TxTime DESC ) AS RowNumber from [Nec_TiXianNEC] where MemLoginID =@MemLoginID and IsDeleted=0 )as a where RowNumber BETWEEN @top and @number ", parms);
            }

        }


        public DataTable Select_NEC_TiXianEnglish(string MemLoginID, string type, string top, string number)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);
            parms[0].ParameterName = "@top";
            parms[0].Value = top;
            parms[1].ParameterName = "@number";
            parms[1].Value = number;
            parms[2].ParameterName = "@MemLoginID";
            parms[2].Value = MemLoginID;
            if (type == "1")//提现ETH
            {
                return
                    DatabaseExcetue.ReturnDataTable("  select * from ( select [MemloginID],[ETHAddress],[ETH] as MoneyNumber,case [Status]    when 0 then '未审核' when 1 then '已审核' when 2 then '已拒绝' end as [Status],[TxTime],[Shop_ETHAddress],[IsDeleted],[TxHash] , ROW_NUMBER() OVER( Order by TxTime DESC ) AS RowNumber from [Nec_TiXian] where MemLoginID =@MemLoginID and IsDeleted=0 )as a where RowNumber BETWEEN @top and @number ", parms);
            }
            else//提现NEC
            {
                return
                DatabaseExcetue.ReturnDataTable("  select * from ( select [MemloginID],[NECAddress] as ETHAddress,[NEC] as MoneyNumber,case [Status]    when 0 then '未审核' when 1 then '已审核' when 2 then '已拒绝' end as [Status],[TxTime],[IsDeleted],[TxHash], ROW_NUMBER() OVER( Order by TxTime DESC ) AS RowNumber from [Nec_TiXianNEC] where MemLoginID =@MemLoginID and IsDeleted=0 )as a where RowNumber BETWEEN @top and @number ", parms);
            }

        }

        public DataTable Select_NEC_TiXian_Count(string MemLoginID, string type)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            if (type == "1")
            {
                return
                    DatabaseExcetue.ReturnDataTable("  select Count(MemLoginID)as meml   from [Nec_TiXian] where MemLoginID =@MemLoginID", parms);
            }
            else
            {
                return
                    DatabaseExcetue.ReturnDataTable("  select Count(MemLoginID)as meml   from [Nec_TiXianNEC] where MemLoginID =@MemLoginID", parms);
            }

        }
        public DataTable QueryReference1QXL(string MemLoginID)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("  select Count(MemLoginID)as meml   from [ShopNum1_Member] where Superior =@MemLoginID", parms);

        }



        public DataTable QueryReference1Bonus(string MemLoginID)
        {

            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable("select isnull(sum(YesterdayAllBonus) ,0) as YesterdayAllBonus from [ShopNum1_Member] where Superior =@MemLoginID ", parms);

        }


        public DataTable Accountrecords(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("select PayPwd from ShopNum1_Member where MemLoginID=@MemLoginID ", parms);
        }
        public DataTable AccountrecordsBonus3(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("  select Trends2+Trends1 as Trends ,Static from (select isnull(SUM(Bonus3),0) as Static,isnull(SUM(Bonus1),0) as Trends1,isnull(SUM(Bonus2),0) as Trends2  from Bonus where MemLoginID=@MemLoginID ) as sss ", parms);
        }
        //public DataTable AccountrecordsBonusAll(string MemLoginID)
        //{
        //    DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
        //    parms[0].ParameterName = "@MemLoginID";
        //    parms[0].Value = MemLoginID;

        //    return
        //        DatabaseExcetue.ReturnDataTable("select isnull(SUM(BonusAll),0) as b from Bonus where MemLoginID=@MemLoginID  ", parms);
        //}
        public DataTable AccountrecordsThree(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("  select isnull(SUM(num1),0) as ExchangeAmount,isnull(SUM(Allnum*0.1),0) as Allnum from [KCEBonusRecord] where [MemLoginID]=@MemLoginID ", parms);
        }
        public DataTable CoticeContent(string Guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid;

            return DatabaseExcetue.ReturnDataTable("select [Title],[Remark],[CreateUser],[CreateTime] from ShopNum1_Announcement where Guid=@Guid  and IsDeleted=0", parms);

        }

        public int KCEMessage(string MemLoginID, string talk, string QuestionType)
        {
            return
                DatabaseExcetue.RunNonQuery("   insert into KCEMessage([Mname],[MMessage],QuestionType,[MCreate]) values('" + MemLoginID + "','" + talk + "','" + QuestionType + "' ,GETDATE())");

        }
        public int Bindingaddress(string MemLoginID, string talk)
        {
            return
                DatabaseExcetue.RunNonQuery("   update ShopNum1_Member set BindingAddress='" + talk + "' where MemLoginID= '" + MemLoginID + "'");

        }

        public int BindingDevice_no(string MemLoginID, string shebeihao, string photo, string CarType, string CarTypeName, string CarNumber)
        {

            string sqlQuery = string.Concat(new object[]{ "INSERT INTO ShopNum1_MemberShip( MemLoginNO,RealName,\tShopNames, \tBelongs, \tMemLoginID, \tLastRankID, \tNewRankID, \tShipStatus, \tBirthdayTime, \tOrganizationImage, \tREAddTime) VALUES (  '','','" , CarNumber, "','" ,shebeihao, "','" ,MemLoginID , "','" ,CarType, "','" , CarTypeName , "'," , 1, ",'" ,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "','" ,photo , "','",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") , "')"
                });
            return DatabaseExcetue.RunNonQuery(sqlQuery);

        }

        public DataTable SearchGPS_device(string deviceno)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@deviceno";
            parms[0].Value = deviceno;

            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT * FROM GPS_device WHERE device_no =@deviceno"
                    }), parms);
        }
        public DataTable SearchMEM_device(string deviceno)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@deviceno";
            parms[0].Value = deviceno;

            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT * FROM ShopNum1_Member WHERE device_no =@deviceno and deviceType=1"
                    }), parms);
        }

        public DataTable GetmemebierCount(string MemLoginID, string type, string type1)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;

            if (type1 == "1")
            {
                if (type == "2")
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(2,4)", parms);
                }
                else if (type == "12")
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(@type)", parms);
                }
                else if (type == "22")
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type in(@type)", parms);
                }
                else
                {
                    return
                        DatabaseExcetue.ReturnDataTable("select OrderNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID and type =@type", parms);
                }
            }
            else
            {
                if (type == "2")
                {
                    return
                           DatabaseExcetue.ReturnDataTable(" select OrderNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in(2,4) ", parms);
                }
                else if (type == "12")
                {
                    return
                           DatabaseExcetue.ReturnDataTable(" select OrderNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in(@type) ", parms);
                }
                else if (type == "22")
                {
                    return
                           DatabaseExcetue.ReturnDataTable(" select OrderNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type in(@type) ", parms);
                }
                else
                {
                    return
                           DatabaseExcetue.ReturnDataTable(" select OrderNumber from ShopNum1_PreTransfer where   RMemberID=@MemLoginID and type=@type ", parms);
                }

            }
        }

        public DataTable Querydv(string MemLoginID, int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            return
                     DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

        }
        public DataTable QueryCNY(string MemLoginID, int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            return
                     DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

        }
        public DataTable Query_hv_dv_cny(string MemLoginID, int top, string type, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@top";
            parms[1].Value = top;
            parms[2].ParameterName = "@number";
            parms[2].Value = number;
            if (type == "1")
            {
                return
                         DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

            }
            else if (type == "2")
            {
                return
                         DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

            }
            else
            {
                return
                         DatabaseExcetue.ReturnDataTable("select * from ( select [OperateMoney],[Date],[Memo],[MemLoginID],[RMemberID], ROW_NUMBER() OVER( Order by [Date] DESC ) AS RowNumber from ShopNum1_PreTransfer where   MemLoginID=@MemLoginID )as a where RowNumber BETWEEN @top and @number ", parms);

            }

        }


        public int UpdatePassword(string MemLoginID, string pwd)
        {

            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set Pwd='" + pwd + "' where MemLoginID ='" + MemLoginID + "'");
        }
        public int UpdateMemLoginIDPassword(string mobile, string pwd)
        {

            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set Pwd='" + pwd + "' where Mobile ='" + mobile + "'");
        }
        public int UpdateMemLoginIDPasswordII(string MemLoginID, string pwd)
        {

            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set Pwd='" + pwd + "' where MemLoginID ='" + MemLoginID + "'");
        }

        public int UpdateIIPassword(string MemLoginID, string pwd)
        {

            return
               DatabaseExcetue.RunNonQuery("update ShopNum1_Member set PayPwd='" + pwd + "' where MemLoginID ='" + MemLoginID + "'");
        }
        public int UpdateLider(string MemLoginID, string RecoCode)
        {

            return
               DatabaseExcetue.RunNonQuery("update ShopNum1_Member set RecoMember='" + MemLoginID + "' where RecoCode!= '" + RecoCode + "' and  RecoCode LIKE '%" + RecoCode + "%'");
        }

        public int UpdateNick(string MemLoginID, string name)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set Name='" + name + "' where MemLoginID ='" + MemLoginID + "'");
        }

        public int UpdateOldPwd(string MemLoginID, string OldPwd, string NewPwd)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set Pwd='" + NewPwd + "' where Pwd ='" + OldPwd + "' and  MemLoginID ='" + MemLoginID + "'");
        }
        public int UpdateOldIIPwd(string MemLoginID, string OldPwd, string NewPwd)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set PayPwd='" + NewPwd + "' where PayPwd ='" + OldPwd + "' and  MemLoginID ='" + MemLoginID + "'");
        }

        public DataTable SelectOldPwd(string MemLoginID, string OldPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@OldPwd";
            parms[1].Value = OldPwd;
            return
                DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Member  where PayPwd =@OldPwd and  MemLoginID =@MemLoginID", parms);
        }
        public DataTable SelectOldPwdTwo(string MemLoginID, string OldPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@OldPwd";
            parms[1].Value = OldPwd;
            return
                DatabaseExcetue.ReturnDataTable("select * from ShopNum1_Member  where Pwd =@OldPwd and  MemLoginID =@MemLoginID", parms);
        }
        public DataTable SelectOldPwdTwoNCE(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable("select Mobile from ShopNum1_Member  where MemLoginID =@MemLoginID", parms);
        }
        public DataTable QueryCTCOrderInfoCount(string MemLoginID, string type, string type1)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;


            if (type1 == "1")
            {
                if (Convert.ToInt32(type) == 1 || Convert.ToInt32(type) == 2 || Convert.ToInt32(type) == 3)
                {
                    return
                    DatabaseExcetue.ReturnDataTable("select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] from ShopNum1_OrderInfoTwo where   MemLoginID =@MemLoginID and OderStatus=@type", parms);

                }
                else
                {
                    return
                    DatabaseExcetue.ReturnDataTable("select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus]  from ShopNum1_OrderInfoTwo where   MemLoginID =@MemLoginID  ", parms);
                }
            }
            else
            {
                if (Convert.ToInt32(type) == 1 || Convert.ToInt32(type) == 2 || Convert.ToInt32(type) == 3)
                {
                    return
                   DatabaseExcetue.ReturnDataTable(" select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus]  from ShopNum1_OrderInfoTwo where   ServiceAgent=@MemLoginID and OderStatus=@type", parms);
                }
                else
                {
                    return
                   DatabaseExcetue.ReturnDataTable(" select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] from ShopNum1_OrderInfoTwo  where  ServiceAgent=@MemLoginID  ", parms);
                }
            }

        }

        public DataTable QueryCTCOrderInfo(string MemLoginID, string type, string type1, int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            parms[2].ParameterName = "@top";
            parms[2].Value = top;
            parms[3].ParameterName = "@number";
            parms[3].Value = number;

            if (type1 == "1")//本人去买
            {
                if (Convert.ToInt32(type) == 1)
                {
                    return
                    DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [PayTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where   MemLoginID =@MemLoginID and OderStatus=@type and ShipmentStatus=1 and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);

                }
                else if (Convert.ToInt32(type) == 3)
                {
                    return
                     DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [ConfirmTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where   MemLoginID =@MemLoginID and OderStatus=@type and ShipmentStatus=1 and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else if (Convert.ToInt32(type) == 2)
                {
                    return
                    DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [PayTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where    ((MemLoginID=@MemLoginID and ShipmentStatus=1) or (ServiceAgent=@MemLoginID and ShipmentStatus=2) )and OderStatus=@type and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else
                {
                    return
                    DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [PayTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where   ServiceAgent =@MemLoginID  and ShipmentStatus=1 and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);
                }
            }
            else//本人去卖
            {
                if (Convert.ToInt32(type) == 1)
                {
                    return
                   DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [CreateTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where   MemLoginID =@MemLoginID and OderStatus=@type and ShipmentStatus=2 and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else if (Convert.ToInt32(type) == 3)
                {
                    return
                   DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [ConfirmTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where   MemLoginID =@MemLoginID and OderStatus=@type and ShipmentStatus=2 and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else if (Convert.ToInt32(type) == 2)
                {
                    return
                  DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [PayTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where    ((ServiceAgent=@MemLoginID and ShipmentStatus=1) or(MemLoginID=@MemLoginID and ShipmentStatus=2) and TradeID is  null) and OderStatus=@type  )as a where RowNumber BETWEEN @top and @number ", parms);
                }
                else
                {
                    return
                   DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [PayTime] DESC )AS RowNumber from ShopNum1_OrderInfoTwo where   MemLoginID=@MemLoginID and ShipmentStatus=2 and TradeID is  null)as a where RowNumber BETWEEN @top and @number ", parms);
                }
            }

        }

        public DataTable QueryCTCOrderInfo1(string MemLoginID, string type, int top, int number)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@type";
            parms[1].Value = type;
            parms[2].ParameterName = "@top";
            parms[2].Value = top;
            parms[3].ParameterName = "@number";
            parms[3].Value = number;
            return
                DatabaseExcetue.ReturnDataTable("select * from ( select  [Guid],[MemLoginID] ,[OrderNumber] ,[OderStatus] ,[ShipmentStatus] ,[ShouldPayPrice] ,[CreateTime]  ,[ConfirmTime]  ,[PayTime],[Score_pv_b] , ROW_NUMBER() OVER( Order by [CreateTime] DESC )AS RowNumber from ShopNum1_OrderInfo where   ServiceAgent=@MemLoginID and OderStatus=@type)as a where RowNumber BETWEEN @top and @number ", parms);
        }

        public DataTable GetALLMemberInfoByMemloginID(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT  [Guid],[MemLoginID],[MemLoginNO],[Email],[Score],[RegeDate],[LastLoginIP],[LoginTime],[AdvancePayment],[LockAdvancePayment],[LockSocre],[CostMoney],[IsDeleted],[LastLoginDate],[IdentityCard],[RealName],[AlipayNumber],[IdentityCardBackImg],[IdentityCardImg],[IdentificationIsAudit],[IdentificationTime],[AuditFailedReason],[IsMailActivation],[IsMobileActivation],[Sex],[CreateUser],[Status],[TradeCount],[RankScore],[CreditMoney],[PromotionMemLoginID],[WebSite],[Msn],[QQ],[Fax],[Postalcode],[Address],[Vocation],[Area],[Photo],[Birthday],[RegDate],[Answer],[Question],[Mobile],[Name],[MemberType],[IsForbid],[LoginDate],[Tel],[AddressCode],[AddressValue],[MemberRank],[CreateTime],[ModifyUser],[ModifyTime],[TActiveTime],[MActiveTime],[IsEmailActivation],[MemberRankGuid],[DistributorId],[Score_bv],[Score_dv],[Score_pv_b],[Score_pv_a],[Score_hv],[Score_sv],[Score_rv],[Score_cv],[Score_max_hv],[Score_pv_cv],[Score_record _pv_a],[ShopNames] FROM ShopNum1_Member WHERE MemLoginID=@memloginID", parms);
        }

        public DataTable GetPhone(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT [Mobile] from ShopNum1_Member WHERE MemLoginID=@memloginID", parms);
        }

        public DataTable GetIsMobile(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT [IsMobileActivation] from ShopNum1_Member WHERE MemLoginID=@memloginID", parms);
        }

        public DataTable SelectOrderByMemberloginID(string memloginID, int startnum, int ordernumber)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@startnum";
            parms[1].Value = startnum;
            parms[2].ParameterName = "@ordernumber";
            parms[2].Value = ordernumber;
            return
                DatabaseExcetue.ReturnDataTable("  select * from (select Guid,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,ProductPrice,ProductPv_b,ProductLastPrice,DispatchPrice,PaymentPrice,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchType,IsLogistics,LogisticsCompany,LogisticsCompanyCode,ShipmentNumber,BuyType,ActivityGuid,PayMemo,ShopID,CancelReason,EndTime,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,InvoiceType,InvoiceTax,Discount,Deposit,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,DispatchTime,ShopName,FeeType,IsBuyComment,IsSellComment,BuyIsDeleted,SellIsDeleted,IsDeleted,OrderType,ReceiptTime,PayMentMemLoginID,IsMinus,ReceivedDays,IsMemdelay,RecommendCommision,AlipayTradeId,identifycode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,agentId,Score_cv,Score_max_hv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,score_reduce_pv_cv,score_pv_cv,Offset_pv_b,IsRefundStatus,remark,Deduction_hv,SuperiorRank , ROW_NUMBER() OVER(Order by CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfo as c where  MemLoginID=@memloginID and BuyIsDeleted=0  and TradeID is not null) as cd where RowNumber  BETWEEN @startnum and @ordernumber", parms);
        }
        /// <summary>
        /// 申请中退款订单
        /// </summary>
        /// <param name="memloginID"></param>
        /// <param name="startnum"></param>
        /// <param name="ordernumber"></param>
        /// <returns></returns>
        public DataTable SelectOrderRefundMobileOne(string memloginID, int startnum, int endnum)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@startnum";
            parms[1].Value = startnum;
            parms[2].ParameterName = "@endnum";
            parms[2].Value = endnum;
            return
                DatabaseExcetue.ReturnDataTable("  select * from (select Guid,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,ProductPrice,ProductPv_b,ProductLastPrice,DispatchPrice,PaymentPrice,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchType,IsLogistics,LogisticsCompany,LogisticsCompanyCode,ShipmentNumber,BuyType,ActivityGuid,PayMemo,ShopID,CancelReason,EndTime,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,InvoiceType,InvoiceTax,Discount,Deposit,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,DispatchTime,ShopName,FeeType,IsBuyComment,IsSellComment,BuyIsDeleted,SellIsDeleted,IsDeleted,OrderType,ReceiptTime,PayMentMemLoginID,IsMinus,ReceivedDays,IsMemdelay,RecommendCommision,AlipayTradeId,identifycode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,agentId,Score_cv,Score_max_hv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,score_reduce_pv_cv,score_pv_cv,Offset_pv_b,IsRefundStatus,remark,Deduction_hv,SuperiorRank , ROW_NUMBER() OVER(Order by CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfo as c where  MemLoginID=@memloginID and OderStatus in(1,2) and refundStatus=1  and BuyIsDeleted=0 and TradeID is not null) as cd where RowNumber  BETWEEN @startnum and @endnum", parms);
        }
        /// <summary>
        /// 已拒绝退款订单
        /// </summary>
        /// <param name="memloginID"></param>
        /// <param name="startnum"></param>
        /// <param name="endnum"></param>
        /// <returns></returns>
        public DataTable SelectOrderRefundMobileTwo(string memloginID, int startnum, int endnum)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@startnum";
            parms[1].Value = startnum;
            parms[2].ParameterName = "@endnum";
            parms[2].Value = endnum;
            return
                DatabaseExcetue.ReturnDataTable("  select * from (select Guid,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,ProductPrice,ProductPv_b,ProductLastPrice,DispatchPrice,PaymentPrice,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchType,IsLogistics,LogisticsCompany,LogisticsCompanyCode,ShipmentNumber,BuyType,ActivityGuid,PayMemo,ShopID,CancelReason,EndTime,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,InvoiceType,InvoiceTax,Discount,Deposit,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,DispatchTime,ShopName,FeeType,IsBuyComment,IsSellComment,BuyIsDeleted,SellIsDeleted,IsDeleted,OrderType,ReceiptTime,PayMentMemLoginID,IsMinus,ReceivedDays,IsMemdelay,RecommendCommision,AlipayTradeId,identifycode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,agentId,Score_cv,Score_max_hv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,score_reduce_pv_cv,score_pv_cv,Offset_pv_b,IsRefundStatus,remark,Deduction_hv,SuperiorRank , ROW_NUMBER() OVER(Order by CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfo as c where  MemLoginID=@memloginID and OderStatus in(1,2) and refundStatus=2 and BuyIsDeleted=0) as cd where RowNumber  BETWEEN @startnum and @endnum", parms);
        }
        /// <summary>
        /// 已退款订单
        /// </summary>
        /// <param name="memloginID"></param>
        /// <param name="startnum"></param>
        /// <param name="endnum"></param>
        /// <returns></returns>
        public DataTable SelectOrderRefundMobileThree(string memloginID, int startnum, int endnum)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            parms[1].ParameterName = "@startnum";
            parms[1].Value = startnum;
            parms[2].ParameterName = "@endnum";
            parms[2].Value = endnum;
            return
                DatabaseExcetue.ReturnDataTable("  select * from (select Guid,MemLoginID,OrderNumber,TradeID,OderStatus,ShipmentStatus,PaymentStatus,refundStatus,Name,Email,Address,Postalcode,Tel,Mobile,ClientToSellerMsg,SellerToClientMsg,PaymentGuid,PaymentName,ProductPrice,ProductPv_b,ProductLastPrice,DispatchPrice,PaymentPrice,ScorePrice,ShouldPayPrice,FromAd,FromUrl,CreateTime,ConfirmTime,PayTime,DispatchType,IsLogistics,LogisticsCompany,LogisticsCompanyCode,ShipmentNumber,BuyType,ActivityGuid,PayMemo,ShopID,CancelReason,EndTime,OutOfStockOperate,PackGuid,PackName,BlessCardGuid,BlessCardName,BlessCardContent,InvoiceTitle,InvoiceContent,PackPrice,BlessCardPrice,AlreadPayPrice,SurplusPrice,UseScore,InvoiceType,InvoiceTax,Discount,Deposit,RegionCode,JoinActiveType,ActvieContent,UsedFavourTicket,DispatchTime,ShopName,FeeType,IsBuyComment,IsSellComment,BuyIsDeleted,SellIsDeleted,IsDeleted,OrderType,ReceiptTime,PayMentMemLoginID,IsMinus,ReceivedDays,IsMemdelay,RecommendCommision,AlipayTradeId,identifycode,Score_pv_b,Score_hv,Score_dv,Score_pv_a,agentId,Score_cv,Score_max_hv,score_reduce_pv_b,score_reduce_hv,score_reduce_dv,score_reduce_pv_a,shop_category_id,ServiceAgent,score_reduce_pv_cv,score_pv_cv,Offset_pv_b,IsRefundStatus,remark,Deduction_hv,SuperiorRank , ROW_NUMBER() OVER(Order by CreateTime DESC ) AS RowNumber from ShopNum1_OrderInfo as c where  MemLoginID=@memloginID and OderStatus in(4,5,6) and refundStatus=2 and BuyIsDeleted=0) as cd where RowNumber  BETWEEN @startnum and @endnum", parms);
        }


        public DataTable SelectOrderProductByOrderInfoGuid(string OrderInfoGuid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderInfoGuid";
            parms[0].Value = OrderInfoGuid;

            return
                DatabaseExcetue.ReturnDataTable(" select * from  ShopNum1_OrderProduct where OrderInfoGuid=@OrderInfoGuid and TradeID is not null", parms);
        }

        public DataTable SelectAllShopCategory()
        {


            return
                DatabaseExcetue.ReturnDataTable(" select * from  ShopNum1_ShopCategory ");
        }

        public DataTable SelectProductByNameAndShop_category_id(string Shop_category_id, string Name, int satar, int end)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Shop_category_id";
            parms[0].Value = Shop_category_id;

            return
                DatabaseExcetue.ReturnDataTable(" select * from ( select sp.*,ShopNum1_ShopInfo.ShopUrl,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv ,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by productId DESC ) AS RowNumber  from ShopNum1_Shop_Product as sp left join  ShopNum1_Shop_ProductPrice spp on  sp.id=spp.productId  left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=sp.MemLoginID where sp.name like '%" + Name + "%' and  shop_category_id=@Shop_category_id and  sp.IsAudit=1 and  sp.IsDeleted=0   and sp.IsSaled=1  and sp.IsSell=1 ) AS RowNumber  where RowNumber BETWEEN " + satar + " and " + end + "", parms);
        }


        public DataTable SelectOrderByMemberloginID_GetCount(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;

            return
                DatabaseExcetue.ReturnDataTable("select count(OrderNumber) as OrderCount from ShopNum1_OrderInfo where MemLoginID=@memloginID and TradeID is not null", parms);
        }



        public DataTable SelectProductByProductCategoryCodeAndShop_category_id(string shop_category_id, int top, int number, string ProductCategoryCode)
        {

            return
                DatabaseExcetue.ReturnDataTable("select * from ( select a.*,ShopNum1_ShopInfo.ShopUrl,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by a.SaleNumber DESC ) AS RowNumber from ShopNum1_Shop_Product as a left join  ShopNum1_Shop_ProductPrice as e on e.productId=a.id  left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=a.MemLoginID  where e.shop_category_id='" + shop_category_id + "' and a.ProductCategoryCode like '" + ProductCategoryCode + "%' and  a.IsAudit=1 and  a.IsDeleted=0 and a.IsSell=1  and a.IsSaled=1) as b  left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=b.MemLoginID where RowNumber BETWEEN " + top + " and " + number + " ");
        }

        /// <summary>
        /// NEC 2.0查询理财产品列表
        /// </summary>
        /// <param name="shop_category_id"></param>
        /// <param name="top"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable SelectFinancialProdct(int top, int number)
        {


            return
               DatabaseExcetue.ReturnDataTable("select * from ( select*,((Total-SurplusTotal)/Total) as BFB, ROW_NUMBER() OVER(Order by ProductId asc ) AS RowNumber from Nec_LiCaiJiJin ) as b  where RowNumber BETWEEN " + top + " and " + number + "");




        }
        public DataTable SelectFinancialProdctFromTable(int top, int number, string tablename)
        {


            return
               DatabaseExcetue.ReturnDataTable("select * from ( select*,((Total-SurplusTotal)/Total) as BFB, ROW_NUMBER() OVER(Order by ProductId asc ) AS RowNumber from " + tablename + " ) as b  where RowNumber BETWEEN " + top + " and " + number + "");




        }
        /// <summary>
        /// NEC 2.0查询理财产品详细
        /// </summary>
        /// <param name="shop_category_id"></param>
        /// <param name="top"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable SelectFinancialProdctDetail(string id)
        {


            return
               DatabaseExcetue.ReturnDataTable("select *,((Total-SurplusTotal)/Total) as BFB from Nec_LiCaiJiJin where ProductId=" + id);




        }
        /// <summary>
        /// NEC 2.0查询理财产品详细
        /// </summary>
        /// <param name="shop_category_id"></param>
        /// <param name="top"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable SelectFinancialProdctDetailFromTable(string id, string tablename)
        {


            return
               DatabaseExcetue.ReturnDataTable("select *,((Total-SurplusTotal)/Total) as BFB from " + tablename + " where ProductId=" + id);




        }




        public DataTable SelectProdctShop_category_id(string shop_category_id, int top, int number)
        {

            return
                DatabaseExcetue.ReturnDataTable("select * from ( select a.*,ShopUrl,productId,SuanLiDaySum,SuanLiUnitPrice,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by a.id asc ) AS RowNumber from ShopNum1_Shop_Product as a left join  ShopNum1_Shop_ProductPrice as e on e.productId=a.id left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=a.MemLoginID where e.shop_category_id='" + shop_category_id + "'  and  a.IsAudit=1 and  a.IsDeleted=0 and a.IsSell=1   and a.IsSaled=1 AND ShopNum1_ShopInfo.IsDeleted=0) as b  where RowNumber BETWEEN " + top + " and " + number + " and  b.IsAudit=1 and  b.IsDeleted=0 AND b.IsSell=1   and b.IsSaled=1 ");
        }


        public DataTable SelectProdctShop_category_id_and_Code(string Code, string shop_category_id, int StartNumber, int EndNumber)
        {

            return
                DatabaseExcetue.ReturnDataTable("select * from ( select a.*,ShopUrl,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by a.id DESC ) AS RowNumber from ShopNum1_Shop_Product as a left join  ShopNum1_Shop_ProductPrice as e on e.productId=a.id left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=a.MemLoginID where e.shop_category_id='" + shop_category_id + "' and a.ProductCategoryCode LIKE '" + Code + "%'   and  a.IsAudit=1 and  a.IsDeleted=0 and a.IsSell=1   and a.IsSaled=1 AND ShopNum1_ShopInfo.IsDeleted=0) as b  where RowNumber BETWEEN " + StartNumber + " and " + EndNumber + " and  b.IsAudit=1 and  b.IsDeleted=0 AND b.IsSell=1   and b.IsSaled=1 ");
        }


        public DataTable SelectProdctShop_category_idddd(string shop_category_id, int top, int number, string memlongid)
        {

            return
                DatabaseExcetue.ReturnDataTable("SELECT * from ( select a.*,ShopUrl,productId,ShopPrice,MarketPrice,Score_dv,Score_bv,Score_pv_a,Score_pv_b,Score_hv,Score_max_hv,Score_sv,Score_cv,Score_rv,shop_category_id,remark,Score_pv_cv,Score_reduce_pv_cv,MaxNumber, ROW_NUMBER() OVER(Order by a.id DESC ) AS RowNumber from ShopNum1_Shop_Product as a left join  ShopNum1_Shop_ProductPrice as e on e.productId=a.id left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=a.MemLoginID  where e.shop_category_id='" + shop_category_id + "'  and  a.IsAudit=1 AND a.IsSell=1  and  a.IsDeleted=0   and a.IsSaled=1  AND  a.MemLoginID='" + memlongid + "' AND ShopNum1_ShopInfo.IsDeleted=0) as b  where RowNumber BETWEEN " + top + " and " + number + " and  b.IsAudit=1 and  b.IsDeleted=0   and b.IsSaled=1  AND b.IsSell=1  AND b.MemLoginID='" + memlongid + "'");
        }

        public DataTable SelectMemberRank_LinkCategory(string MemberloginGuid, int IsReadOrBuy, int Category_ID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemberloginGuid";
            parms[0].Value = MemberloginGuid;
            parms[1].ParameterName = "@IsReadOrBuy";
            parms[1].Value = IsReadOrBuy;

            return
                DatabaseExcetue.ReturnDataTable("select * from ShopNum1_MemberRank_LinkCategory  where Rank_ID=@MemberloginGuid and  IsReadOrBuy=@IsReadOrBuy and Category_ID like '%" + Category_ID + "%'", parms);
        }


        public DataTable SelectUserMessageByMemberloginID(string MemberloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemberloginID";
            parms[0].Value = MemberloginID;
            return
                DatabaseExcetue.ReturnDataTable("select * from ShopNum1_UserMessage as c left join ShopNum1_MessageInfo as d on c.[MessageInfoGuid]=d.guid where ReceiveID=@MemberloginID", parms);
        }


        public DataTable SelectAddressByMemberloginID(string MemberloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemberloginID";
            parms[0].Value = MemberloginID;
            return
                DatabaseExcetue.ReturnDataTable(" select * from ShopNum1_Address where MemLoginID=@MemberloginID", parms);
        }


        public DataTable SelectProdctByID_two(int id, int shop_category_id)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@id";
            parms[0].Value = id;
            parms[1].ParameterName = "@shop_category_id";
            parms[1].Value = shop_category_id;
            return
                DatabaseExcetue.ReturnDataTable("SELECT d.*,c.*,ShopNum1_ShopInfo.ShopUrl FROM ShopNum1_Shop_Product as c left join ShopNum1_Shop_ProductPrice as d on d.productId=c.id left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=c.MemLoginID  WHERE c.id=@id and d.shop_category_id=@shop_category_id and c.IsAudit=1 and  c.IsDeleted=0    and c.IsSaled=1  and c.IsSell=1 ", parms);
        }


        public DataTable SelectProdctByShopID(string shopid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@shopid";
            parms[0].Value = shopid;
            return
                DatabaseExcetue.ReturnDataTable("SELECT d.*,c.*,ShopNum1_ShopInfo.ShopUrl FROM ShopNum1_Shop_Product as c left join ShopNum1_Shop_ProductPrice as d on d.productId=c.id left join ShopNum1_ShopInfo on ShopNum1_ShopInfo.MemLoginID=c.MemLoginID  WHERE c.MemLoginID=@shopid and d.shop_category_id=9 and c.IsAudit=1 and  c.IsDeleted=0    and c.IsSaled=1  and c.IsSell=1 ", parms);
        }

        public string GetMemTypeByMemberId(string strMemberId)
        {
            return
                DatabaseExcetue.ReturnString("SELECT MemberType FROM ShopNum1_Member WHERE memloginID='" + strMemberId +
                                             "'");
        }

        public string GetMemTypeByMemLoginID(string memloginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginID";
            parms[0].Value = memloginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT MemberType FROM ShopNum1_Member WHERE MemLoginID=@memloginID", parms).Rows[0][0].ToString();
        }
        public DataTable GetMemberShip(string memloginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memloginNO";
            parms[0].Value = memloginNO;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_MemberShip where MemLoginNO=@memloginNO", parms);
        }

        public DataTable GetAllShop_Product(string guid, string category)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid;
            parms[1].ParameterName = "@category";
            parms[1].Value = category;
            return
                DatabaseExcetue.ReturnDataTable("SELECT c.*,[productId],[ShopPrice],[MarketPrice],[Score_dv],[Score_bv],[Score_pv_a],[Score_pv_b],[Score_hv],[Score_max_hv],[Score_sv],[Score_cv],[Score_rv],[shop_category_id],[remark],[Score_pv_cv],[Score_reduce_pv_cv],[MaxNumber] FROM ShopNum1_Shop_Product as c left join ShopNum1_Shop_ProductPrice as d on c.id= d.productId where c.Guid=@guid and d.shop_category_id=@category", parms);
        }

        /// <summary>
        /// 交易密码
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public string GetPayPwd(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT Guid, PayPwd\t  FROM ShopNum1_Member   WHERE  MemLoginID =@MemLoginID";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue).Rows[0]["PayPwd"].ToString();
        }

        public string GetMberRankGuid(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT MemberRankGuid  FROM ShopNum1_Member   WHERE  MemLoginID =@MemLoginID";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue).Rows[0]["MemberRankGuid"].ToString();
        }


        public string GetMberMemberType(string memLoginID)
        {
            string strSql = string.Empty;
            strSql = "SELECT MemberType  FROM ShopNum1_Member   WHERE  MemLoginID =@MemLoginID";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLoginID;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue).Rows[0]["MemberType"].ToString();
        }

        public string GetMemLoginIDONNO(string memLogin)
        {
            string strSql = string.Empty;
            strSql = "select MemLoginID from ShopNum1_Member where ([MemLoginID]=@MemLoginID OR [MemLoginNO]=@MemLoginID) And IsDeleted =0";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memLogin;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue).Rows[0]["MemLoginID"].ToString();
        }

        public DataTable LoginByEmail(string email, string string_0)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@email";
            paraName[1] = "@pwd";
            paraValue[0] = email;
            paraValue[1] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_LoginByEmail", paraName, paraValue);
        }

        public DataTable LoginByMobile(string mobile, string string_0)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@mobile";
            paraName[1] = "@pwd";
            paraValue[0] = mobile;
            paraValue[1] = string_0;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_LoginByMobile", paraName, paraValue);
        }

        public DataTable MemberCreditRankSearch(string memberrank)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@memberrank";
            paraValue[0] = memberrank;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberCreditRankSearch", paraName,
                paraValue);
        }

        public DataTable MemberFindPwdPro(string email)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@email";
            paraValue[0] = email;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberFindPwd", paraName, paraValue);
        }


        /// <summary>
        /// 金币（BV）支付
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="shouldPay"></param>
        /// <param name="advancePayment"></param>
        /// <param name="tradeID"></param>
        /// <returns></returns>
        public int OtherOrderIDPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_Shop_OtherOrderInfo SET OrderStatus=", 1, ", PaymentStatus=", 1,
                    ", PaymentTime='", DateTime.Now, "', ModifyTime='", DateTime.Now, "' WHERE TradeID='", tradeID,
                    "' AND  MemLoginID='", memLoginID, "'"
                });
            sqlList.Add(item);
            decimal num = advancePayment - shouldPay;
            if (num < 0M)
            {
                return 0;
            }
            item =
                string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=", num, " WHERE MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            UpdateCostMoney(memLoginID, shouldPay);
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 金币（BV）支付
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="shouldPay"></param>
        /// <param name="advancePayment"></param>
        /// <param name="tradeID"></param>
        /// <param name="IsAllPay"></param>
        /// <returns></returns>
        public int PreDepositsPay(string memLoginID, decimal shouldPay, decimal advancePayment, string tradeID,
            string IsAllPay)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_OrderInfo SET OderStatus=", 1, ", PaymentStatus=", 1, ", ShipmentStatus=", 0,
                    ",AlreadPayPrice=", shouldPay, ",PayTime='", DateTime.Now, "' WHERE MemLoginID='", memLoginID,
                    "'"
                });
            if (IsAllPay == "1")
            {
                item = item + " AND TradeID='" + tradeID + "'";
            }
            if (IsAllPay == "0")
            {
                item = item + " AND OrderNumber='" + tradeID + "'";
            }
            sqlList.Add(item);
            decimal num = advancePayment - shouldPay;
            if (num < 0M)
            {
                return 0;
            }
            item =
                string.Concat(new object[] { "UPDATE  ShopNum1_Member SET AdvancePayment\t=", num, " WHERE MemLoginID='", memLoginID, "'" });
            sqlList.Add(item);
            UpdateCostMoney(memLoginID, shouldPay);
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 金币（BV）退款
        /// </summary>
        /// <param name="memloginid"></param>
        /// <param name="shopid"></param>
        /// <param name="payprice"></param>
        /// <param name="shopAdvancePayment"></param>
        /// <param name="orderguid"></param>
        /// <param name="productguid"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int RefundUpdateAdvancePayment(string memloginid, string shopid, decimal payprice,
            decimal shopAdvancePayment, string orderguid, string productguid,
            int status)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment+", payprice, " WHERE MemLoginID='",
                    memloginid, "'"
                });
            sqlList.Add(item);
            decimal num = shopAdvancePayment - payprice;
            if (num < 0M)
            {
                return 0;
            }
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment-", payprice, " WHERE MemLoginID='",
                    shopid, "'"
                });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Refund SET RefundStatus=", status, " WHERE OrderID='", orderguid,
                    "' AND ProductGuid='", productguid, "' AND ShopID='", shopid, "'"
                });
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int RefundUpdateAdvancePaymentMem(string memloginid, decimal payprice)
        {
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Member SET AdvancePayment\t=AdvancePayment+", payprice, " WHERE MemLoginID='"
                        , memloginid, "'"
                    }));
        }

        public DataTable SearchMembertwoone(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT * FROM ShopNum1_Member where MemLoginID=@memLoginID";

            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable Search(string memLoginID)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tGuid\t, \tMemLoginID\t, \tName\t, \tEmail\t, \tSex\t, \tBirthday\t, \tCreditMoney\t, \tPhoto\t, \tRealName\t, \tArea\t, \tVocation\t, \tAddress\t, \tPostalcode\t, \tMobile\t, \tFax\t, \tQQ\t, \tWebSite\t, \tQuestion\t, \tAnswer\t, \tRegDate\t, \tLastLoginDate\t, \tLastLoginIP\t, \tLoginTime\t, \tAdvancePayment\t, \tIsForbid\t, \tCreateTime  , \tModifyUser , \tModifyTime\t, \tIsDeleted    FROM ShopNum1_Member  WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
        public DataTable SearchMemberGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_Member   WHERE Guid =@guid"
                    }), parms);
        }
        public DataTable Search(string guid, int isDeleted)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            parms[1].ParameterName = "@isDeleted";
            parms[1].Value = isDeleted;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT \tGuid\t, \tMemLoginID\t,    MemberType,\tEmail\t, \tPwd\t, \tPayPwd\t, \tSex\t, \tAge\t, \tBirthday\t, \tCreditMoney\t, \tPhoto\t, \tRealName\t, \tArea\t, \tVocation\t, \tAddress\t, \tPostalcode\t, \tOfficeTel\t, \tHomeTel\t, \tMobile\t, \tFax\t, \tQQ\t, \tMsn\t, \tCardType\t, \tCardNum\t, \tWebSite\t, \tQuestion\t, \tAnswer\t, \tRegDate\t, \tLastLoginDate\t, \tLastLoginIP\t, \tLoginTime\t, \tIsForbid\t, \tCreateTime\t, \tModifyUser, \tModifyTime\t, \tIsDeleted IsAudit  FROM ShopNum1_Member   WHERE IsDeleted =@isDeleted AND Guid =@guid"
                    }), parms);
        }

        public DataTable Search(string MemLoginID, string ZfbCode, string RealName, string IdentityCard,
            string ApplyDate1, string ApplyDate2, string IsAudit)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tMemLoginID\t,    MemberType,\tRealName\t, \tLastLoginDate\t, \tAdvancePayment\t, \tScore , \tMemberRank , \tAlipayNumber , \tIdentificationTime , \tIdentityCard   FROM ShopNum1_Member   WHERE IsDeleted 0=0 ";
            if (MemLoginID != string.Empty)
            {
                str = str + " AND MemLoginID='" + MemLoginID + "' ";
            }
            if (Operator.FormatToEmpty(ZfbCode) != string.Empty)
            {
                str = str + " AND AlipayNumber='" + ZfbCode + "' ";
            }
            if (Operator.FormatToEmpty(RealName) != string.Empty)
            {
                str = str + " AND RealName='" + RealName + "' ";
            }
            if (Operator.FormatToEmpty(IdentityCard) != string.Empty)
            {
                str = str + " AND IdentityCard='" + IdentityCard + "' ";
            }
            if (Operator.FormatToEmpty(ApplyDate1) != string.Empty)
            {
                str = str + " AND IdentificationTime >='" + ApplyDate1 + "' ";
            }
            if (Operator.FormatToEmpty(ApplyDate2) != string.Empty)
            {
                str = str + " AND IdentificationTime <='" + ApplyDate2 + "' ";
            }
            if (Operator.FormatToEmpty(IsAudit) != string.Empty)
            {
                str = str + " AND IsAudit=" + IsAudit + " ";
            }
            return DatabaseExcetue.ReturnDataTable(str + " ORDER BY IdentificationTime");
        }

        public DataTable Search1(string memLoginID, string name, string MyAllBonus, string regDate1, string regDate2,
            int int_0, int isForbid, string AreaCode, string MemberType, string MemberRank, string MemberRankGuid,
            string CreditMoney, string Mobile, string isadmin)
        {
            string str = string.Empty;
            str =
                "SELECT \tGuid\t, \tMemberType, \tMemLoginID, \tMemLoginNo,Email,  MyAllBonus,  Score_dv,  MemberRank,   Score,  RealName,\tSex ,\tAddressValue\t, \tAddressCode\t, \tAddress\t, \tAdvancePayment\t, \tIdentityCard\t,    Mobile,\tCreditMoney\t, \tRegeDate\t, \tMemberRank\t, \tMemberRankGuid\t, \tLoginDate\t, \tPromotionMemLoginID\t,\tSuperior\t ,\tIsForbid\t   FROM ShopNum1_Member  where 1=1 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND (MemLoginID LIKE '%" + memLoginID + "%' ";
                str = str + " or MemLoginNO LIKE '%" + memLoginID + "%') ";
            }
            if (Operator.FormatToEmpty(name) != string.Empty)
            {
                str = str + " AND Name LIKE '%" + Operator.FilterString(name) + "%'";
            }

            if ((isForbid == 0) || (isForbid == 1))
            {
                str = string.Concat(new object[] { str, " AND IsForbid=", isForbid, " " });
            }
            if (((int_0 == 0) || (int_0 == 1)) || (int_0 == 2))
            {
                str = string.Concat(new object[] { str, " AND Sex='", int_0, "', " });
            }
            if ((Operator.FormatToEmpty(AreaCode) != string.Empty) && (Operator.FormatToEmpty(AreaCode) != "0"))
            {
                str = str + " AND AddressCode like '" + Operator.FilterString(AreaCode) + "%'";
            }
            if (Operator.FormatToEmpty(regDate1) != string.Empty)
            {
                str = str + " AND RegeDate>='" + Operator.FilterString(regDate1) + "' ";
            }
            if (Operator.FormatToEmpty(regDate2) != string.Empty)
            {
                str = str + " AND RegeDate<='" + Operator.FilterString(regDate2) + "' ";
            }
            if (Operator.FormatToEmpty(MemberType) != "-1")
            {
                str = str + " AND MemberType =" + MemberType + " ";
            }
            if (Operator.FormatToEmpty(MemberRank) != "-1")
            {
                str = str + " AND MemberRank  BETWEEN " + MemberRank.Split(new[] { '/' })[0] + " AND " +
                      MemberRank.Split(new[] { '/' })[1] + " ";
            }
            if (Operator.FormatToEmpty(MemberRankGuid) != "-1")
            {
                str = str + " AND PersonCate  = '" + MemberRankGuid + "' ";
            }
            if (Operator.FormatToEmpty(CreditMoney) != string.Empty)
            {
                str = str + " AND CreditMoney = " + CreditMoney + " ";
            }
            if (Operator.FormatToEmpty(Mobile) != string.Empty)
            {
                str = str + " AND Mobile  like  '%" + Mobile + "%' ";
            }


            if (isadmin != "1")
            {
                str = str + " AND MemLoginID not in(SELECT BLID from WHJ_BlackList) ";
            }

            return DatabaseExcetue.ReturnDataTable(str + " Order by RegeDate Desc");
        }

        public DataTable SearchAgentByAreacode(string areacode, string showcount)
        {
            string str = "";
            if (!(string.IsNullOrEmpty(showcount) || !(showcount != "-1")))
            {
                str = " top " + showcount;
            }
            var builder = new StringBuilder();
            builder.Append("select " + str + " * from  ");
            builder.Append("( ");
            builder.Append(
                "select '' MemLoginID,'' RealName,Code as areacodet,name ,'0' as shopid from shopnum1_region where code='" +
                Operator.FilterString(areacode) + "' ");
            builder.Append("union all ");
            builder.Append("select * from ");
            builder.Append("( ");
            builder.Append(
                "select MemLoginID,ShopName,AddressCode as areacodet,a.addressvalue AS name,shopid  from dbo.ShopNum1_ShopInfo A ");
            builder.Append("left join dbo.shopnum1_region b on a.AddressCode=b.code ");
            builder.Append(
                "where a.IsAudit=1 And A.IsShowMap=1  And dbo.fun_ShopMap_AddressCode(a.AddressCode) like '" +
                Operator.FilterString(areacode) + "%' ");
            builder.Append(")aa ");
            builder.Append(")aa ");
            builder.Append("order by areacodet asc ");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchAgentByAreacodeProp(string areacode, string showcount)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@topShow";
            if (showcount == null)
            {
                showcount = "500";
            }
            paraValue[0] = showcount;
            paraName[1] = "@AreaCode";
            paraValue[1] = areacode;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_GetAddressCodeShow", paraName, paraValue);
        }

        public DataTable SearchAgentCountOfAreacode()
        {
            var builder = new StringBuilder();
            builder.Append("select count(*)agentcount,Level1code from(");
            builder.Append(
                "select substring(AddressCode,0,4)Level1code from dbo.ShopNum1_ShopInfo where IsAudit=1 And IsShowMap=1 ");
            builder.Append(
                ")a  where Level1code is not null and Level1code!='-1' and Level1code!=''   group by  Level1code");
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            string strSql = string.Empty;
            strSql =
                "SELECT Guid\t, MemLoginID\t,MemLoginNO\t, MemberType ,[Score_record _pv_a], Photo,AdvancePayment,Email,LoginTime,LockAdvancePayment,Name ,RealName,Score_hv,Score_pv_a,Score_pv_cv,Score_rv,Score_pv_b,Score_dv,Score_rv  FROM ShopNum1_Member    WHERE 0=0 ";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " and (MemLoginID =@memLoginID or MemLoginNO=@memLoginID)";
            }
            return DatabaseExcetue.ReturnDataTable(strSql, parms);
        }

        public DataTable SearchInfoByGuid(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  MemLoginID, Name, AdvancePayment, LockAdvancePayment  FROM ShopNum1_Member  WHERE Guid =@guid", parms);
        }

        public DataTable SearchIsAudit(string MemLoginID, string RealName, string IdentityCard, string StartTime,
            string EndTime, string IdentificationIsAudit)
        {
            var builder = new StringBuilder();
            builder.Append("select ");
            builder.Append("Guid,IdentificationIsAudit,IdentityCard,MemLoginID,RealName,IdentificationTime ");
            builder.Append("from ");
            builder.Append("ShopNum1_Member");
            builder.Append(" where 1=1");
            if (Operator.FormatToEmpty(IdentityCard) != string.Empty)
            {
                builder.Append(" AND IdentityCard LIKE '%" + Operator.FilterString(IdentityCard) + "%'");
            }
            if (Operator.FormatToEmpty(RealName) != string.Empty)
            {
                builder.Append(" AND RealName LIKE '%" + Operator.FilterString(RealName) + "%'");
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND MemLoginID = '" + Operator.FilterString(MemLoginID) + "'");
            }
            if (Operator.FormatToEmpty(IdentificationIsAudit) == "-2")
            {
                builder.Append(" AND IdentificationIsAudit in (0,2)");
            }
            else
            {
                builder.Append(" AND IdentificationIsAudit = " + IdentificationIsAudit);
            }
            if (Operator.FormatToEmpty(StartTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime>='" + StartTime + "' ");
            }
            if (Operator.FormatToEmpty(EndTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime<='" + EndTime + "' ");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchMember(int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tMemLoginID\t, \tEmail\t ,   Tel     FROM ShopNum1_Member  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberAssignGroup(string guid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@guid";
            parms[0].Value = guid.Replace("'", "");
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT  A.Guid, A.MemLoginID,  B.Name, B.Email, A.MemberGroupGuid  FROM ShopNum1_MemberAssignGroup as A,  ShopNum1_Member as B WHERE  A.MemLoginID=B.MemLoginID and  A.MemberGroupGuid =@guid", parms);
        }

        public DataTable SearchMemberByMemberRank(string guid)
        {
            string strSql = string.Empty;
            strSql =
                "SELECT \tA.Guid\t, \tA.Name, \tA.MemLoginID, \tA.Email   FROM ShopNum1_Member A where IsDeleted=0 AND IsForbid=0";
            if (Operator.FormatToEmpty(guid) != string.Empty)
            {
                strSql = strSql + " AND A.MemberRank BETWEEN " + guid.Split(new[] { '/' })[0] + " AND " +
                         guid.Split(new[] { '/' })[1] + " ";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberCookieInfo(string memLoginID)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    " SELECT  MemLoginID,IdentificationIsAudit,IdentityCard,AuditFailedReason,RealName FROM ShopNum1_Member  WHERE MemLoginID='" +
                    Operator.FilterString(memLoginID) + "'");
        }

        public DataTable SearchMemberGetPromentionMembers(string memberloginid, string ispromentiontop)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memberloginid";
            paraValue[0] = memberloginid;
            paraName[1] = "@strwhere";
            paraValue[1] = "1=1";
            paraName[2] = "@ispromentiontop";
            paraValue[2] = ispromentiontop;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberGetPromentionMembers", paraName,
                paraValue);
        }

        public DataTable SearchMemberGroup(string guid)
        {
            string strSql = string.Empty;
            string str2 = guid.Replace("'", "");
            strSql = "SELECT  Guid, Name,  Description\t FROM ShopNum1_MemberGroup  where 1=1";
            if ((Operator.FormatToEmpty(guid) != string.Empty) && (Operator.FormatToEmpty(guid) != "-1"))
            {
                strSql = strSql + " AND Guid = '" + str2 + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberInfoByGuid(string Guid)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select MemLoginID,RealName,IdentityCard,IdentificationTime,IdentityCardImg,IdentityCardBackImg,IdentificationIsAudit,auditfailedreason from ShopNum1_Member  where Guid='" +
                    Operator.FilterString(Guid) + "'");
        }

        public DataTable SearchMemberName(string memLoginID, string realName, int Type)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, Email,  RealName,tel FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                strSql = strSql + " AND RealName LIKE '%" + Operator.FilterString(realName) + "%'";
            }
            if (Type != -1)
            {
                strSql = strSql + " AND MemberType = " + Type;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberName(string memLoginID, string realName, string memberRankGuid)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, Name,tel,email FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memberRankGuid) != "-1")
            {
                strSql = strSql + " AND MemberType = '" + Operator.FilterString(memberRankGuid) + "'";
            }
            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID LIKE '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(realName) != string.Empty)
            {
                strSql = strSql + " AND realname LIKE '%" + Operator.FilterString(realName) + "%'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchPassMemberInfo(string MemLoginID, string RealName, string IdentityCard, string StartTime,
            string EndTime)
        {
            var builder = new StringBuilder();
            builder.Append("select ");
            builder.Append("Guid,IdentificationIsAudit,IdentityCard,MemLoginID,RealName,IdentificationTime ");
            builder.Append("from ");
            builder.Append("ShopNum1_Member");
            builder.Append(" where IdentificationIsAudit is not null");
            if (Operator.FormatToEmpty(IdentityCard) != string.Empty)
            {
                builder.Append(" AND IdentityCard LIKE '%" + Operator.FilterString(IdentityCard) + "%'");
            }
            if (Operator.FormatToEmpty(RealName) != string.Empty)
            {
                builder.Append(" AND RealName LIKE '%" + Operator.FilterString(RealName) + "%'");
            }
            if (Operator.FormatToEmpty(MemLoginID) != string.Empty)
            {
                builder.Append(" AND MemLoginID LIKE '%" + Operator.FilterString(MemLoginID) + "%'");
            }
            if (Operator.FormatToEmpty(StartTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime>='" + StartTime + "' ");
            }
            if (Operator.FormatToEmpty(EndTime) != string.Empty)
            {
                builder.Append(" AND IdentificationTime<='" + EndTime + "' ");
            }
            return DatabaseExcetue.ReturnDataTable(builder.ToString());
        }

        public DataTable SearchPasswordByInfo(string question, string answer, string email, int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "select  MemLoginID,Pwd  from ShopNum1_Member where 1=1";
            if ((((Operator.FormatToEmpty(question) != string.Empty) && (Operator.FormatToEmpty(answer) != string.Empty)) &&
                 (Operator.FormatToEmpty(email) != string.Empty)) && ((isDeleted == 0) || (isDeleted == 1)))
            {
                strSql =
                    string.Concat(new object[]
                    {
                        strSql, " And Question= '", question, "' and Answer= '", answer, "' and  Email= '", email,
                        "' and IsDeleted= ", isDeleted, " "
                    });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchWelcomeBaseInfo(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable("SELECT * FROM ShopNum1_Member  WHERE MemLoginID=@memLoginID", parms);
        }

        /// <summary>
        /// 金币（BV）转帐
        /// </summary>
        /// <param name="transferMember"></param>
        /// <param name="toTransferMember"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int Transfer(string transferMember, string toTransferMember, string money)
        {
            DataTable table = SearchByMemLoginID(transferMember);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (Convert.ToDecimal(table.Rows[0]["AdvancePayment"].ToString()) >= Convert.ToDecimal(money))
                {
                    var sqlList = new List<string>();
                    string item = "UPDATE ShopNum1_Member SET AdvancePayment=AdvancePayment-" + money +
                                  " WHERE MemLoginID='" + transferMember + "'";
                    sqlList.Add(item);
                    item = "UPDATE ShopNum1_Member SET AdvancePayment=AdvancePayment+" + money + " WHERE MemLoginID='" +
                           toTransferMember + "'";
                    sqlList.Add(item);
                    try
                    {
                        DatabaseExcetue.RunTransactionSql(sqlList);
                        return 1;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 重销币（DV）转帐
        /// </summary>
        /// <param name="transferMember"></param>
        /// <param name="toTransferMember"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int Transfer_Dv(string transferMember, string toTransferMember, string money)
        {
            DataTable table = SearchByMemLoginID(transferMember);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (Convert.ToDecimal(table.Rows[0]["Score_dv"].ToString()) >= Convert.ToDecimal(money))
                {
                    var sqlList = new List<string>();
                    string item = "UPDATE ShopNum1_Member SET Score_dv=Score_dv-" + money +
                                  " WHERE MemLoginID='" + transferMember + "'";
                    sqlList.Add(item);
                    item = "UPDATE ShopNum1_Member SET Score_dv=Score_dv+" + money + " WHERE MemLoginID='" +
                           toTransferMember + "'";
                    sqlList.Add(item);
                    try
                    {
                        DatabaseExcetue.RunTransactionSql(sqlList);
                        return 1;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 人民币（RV）转帐
        /// </summary>
        /// <param name="transferMember"></param>
        /// <param name="toTransferMember"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int Transfer_Rv(string transferMember, string toTransferMember, string money)
        {
            DataTable table = SearchByMemLoginID(transferMember);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (Convert.ToDecimal(table.Rows[0]["Score_rv"].ToString()) >= Convert.ToDecimal(money))
                {
                    var sqlList = new List<string>();
                    string item = "UPDATE ShopNum1_Member SET Score_rv=Score_rv-" + money +
                                  " WHERE MemLoginID='" + transferMember + "'";
                    sqlList.Add(item);
                    item = "UPDATE ShopNum1_Member SET Score_rv=Score_rv+" + money + " WHERE MemLoginID='" +
                           toTransferMember + "'";
                    sqlList.Add(item);
                    try
                    {
                        DatabaseExcetue.RunTransactionSql(sqlList);
                        return 1;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return -1;
            }
            return 0;
        }
        /// <summary>
        /// 人民币（RV）转金币（BV）
        /// </summary>
        /// <param name="transferMember"></param>
        /// <param name="toTransferMember"></param>
        /// <param name="money"></param>
        /// <returns></returns>
        public int Transfer_Rv_Bv(string transferMember, string toTransferMember, string money)
        {
            DataTable table = SearchByMemLoginID(transferMember);
            if ((table != null) && (table.Rows.Count > 0))
            {
                if (Convert.ToDecimal(table.Rows[0]["Score_rv"].ToString()) >= Convert.ToDecimal(money))
                {
                    var sqlList = new List<string>();
                    string item = "UPDATE ShopNum1_Member SET Score_rv=Score_rv-" + money +
                                  " WHERE MemLoginID='" + transferMember + "'";
                    sqlList.Add(item);
                    item = "UPDATE ShopNum1_Member SET AdvancePayment=AdvancePayment+" + money + " WHERE MemLoginID='" +
                           toTransferMember + "'";
                    sqlList.Add(item);
                    try
                    {
                        DatabaseExcetue.RunTransactionSql(sqlList);
                        return 1;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return -1;
            }
            return 0;
        }

        public int UpdataIsMobileActivation(string MemLoginID, string Mobile)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@Mobile";
            paraValue[1] = Mobile;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_IsMobileActivation", paraName, paraValue);
        }

        public int UpdataMemberIdentificationInfo(ShopNum1_Member shopNum1_Member)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@memloginid";
            paraValue[0] = shopNum1_Member.MemLoginID;
            paraName[1] = "@realname";
            paraValue[1] = shopNum1_Member.RealName;
            paraName[2] = "@identitycard";
            paraValue[2] = shopNum1_Member.IdentityCard;
            paraName[3] = "@identitycardimg";
            paraValue[3] = shopNum1_Member.IdentityCardImg;
            paraName[4] = "@identificationisaudit";
            paraValue[4] = shopNum1_Member.IdentificationIsAudit.ToString();
            paraName[5] = "@identificationtime";
            paraValue[5] = shopNum1_Member.IdentificationTime.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdataMemberIdentificationInfo", paraName, paraValue);
        }

        /// <summary>
        /// 会员个人信息更新
        /// </summary>
        /// <param name="Member"></param>
        /// <returns></returns>
        public int Update(ShopNum1_Member Member)
        {
            var paraName = new string[27];
            var paraValue = new string[27];
            paraName[0] = "@Name";
            paraValue[0] = Member.Name;
            paraName[1] = "@Sex";
            paraValue[1] = Member.Sex.ToString();
            paraName[2] = "@Photo";
            paraValue[2] = Member.Photo;
            paraName[3] = "@QQ";
            paraValue[3] = Member.QQ;
            paraName[4] = "@AddressValue";
            paraValue[4] = Member.AddressValue;
            paraName[5] = "@Fax";
            paraValue[5] = Member.Fax;
            paraName[6] = "@WebSite";
            paraValue[6] = Member.WebSite;
            paraName[7] = "@Mobile";
            paraValue[7] = Member.Mobile;
            paraName[8] = "@modifyUser";
            paraValue[8] = Member.ModifyUser;
            paraName[9] = "@modifyTime";
            paraValue[9] = Convert.ToDateTime(Member.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss");
            paraName[10] = "@MemLoginID";
            paraValue[10] = Member.MemLoginID;
            paraName[11] = "@AddressCode";
            paraValue[11] = Member.AddressCode;
            paraName[12] = "@Vocation";
            paraValue[12] = Member.Vocation;
            paraName[13] = "@Postalcode";
            paraValue[13] = Member.Postalcode;
            paraName[14] = "@LastLoginIP";
            paraValue[14] = Member.LastLoginIP;
            paraName[15] = "@Birthday";
            paraValue[15] = Member.Birthday.ToString();
            paraName[0x10] = "@Address";
            paraValue[0x10] = Member.Address;
            paraName[0x11] = "@Area";
            paraValue[0x11] = Member.Area;
            paraName[0x12] = "@Pwd";
            paraValue[0x12] = Member.Pwd;
            paraName[0x13] = "@PayPwd";
            paraValue[0x13] = Member.PayPwd;
            paraName[20] = "@Tel";
            paraValue[20] = Member.Tel;
            paraName[0x15] = "@RealName";
            paraValue[0x15] = Member.RealName;
            paraName[22] = "@Superior";
            paraValue[22] = Member.Superior;
            paraName[23] = "@MemberRankGuid";
            paraValue[23] = Member.MemberRankGuid.ToString();
            paraName[24] = "@ShopNames";
            paraValue[24] = Member.ShopNames.ToString();
            paraName[25] = "@IdentityCard";
            paraValue[25] = Member.IdentityCard.ToString();
            paraName[26] = "@RetailersState";
            paraValue[26] = Member.RetailersStates.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMember", paraName, paraValue);
        }
        /// <summary>
        /// type =1,金币（BV）支付;type=0,金币（BV）收款
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberloginid"></param>
        /// <param name="payprice"></param>
        /// <returns></returns>
        public int UpdateAdvancePayment(int type, string memberloginid, decimal payprice)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@type";
            paraValue[0] = type.ToString();
            paraName[1] = "@memberloginid";
            paraValue[1] = memberloginid;
            paraName[2] = "@payprice";
            paraValue[2] = payprice.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_PayAdvancePayment", paraName, paraValue);
        }
        /// <summary>
        /// type =1,人民币（RV）支付;type=0,人民币（RV）收款
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberloginid"></param>
        /// <param name="payprice"></param>
        /// <returns></returns>
        public int UpdateAdvancePayment_RV(int type, string memberloginid, decimal payprice)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@type";
            paraValue[0] = type.ToString();
            paraName[1] = "@memberloginid";
            paraValue[1] = memberloginid;
            paraName[2] = "@payprice";
            paraValue[2] = payprice.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_PayAdvancePayment_two", paraName, paraValue);
        }

        /// <summary>
        /// 支付累计
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="costMoney"></param>
        /// <returns></returns>
        public int UpdateCostMoney(string memLoginID, decimal costMoney)
        {
            string strSql = string.Empty;
            strSql = "UPDATE  ShopNum1_Member SET CostMoney=CostMoney+@CostMoney WHERE MemLoginID=@MemLoginID";
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@CostMoney";
            paraValue[0] = costMoney.ToString();
            paraName[1] = "@MemLoginID";
            paraValue[1] = memLoginID;
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UpdateIdentificationIsAudit(string Guid, string IdentificationIsAudit, string strAuditFailedReason)
        {
            return
                DatabaseExcetue.RunNonQuery("update ShopNum1_Member set IdentificationIsAudit=" +
                                            Operator.FilterString(IdentificationIsAudit) + ",AuditFailedReason='" +
                                            Operator.FilterString(strAuditFailedReason) + "' where Guid in('" + Guid +
                                            "')");
        }

        public int UpdateIdentificationIsAudit(string Guid, string IdentificationIsAudit, string strAuditFailedReason,
            string memLoginID)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "update ShopNum1_Member set IdentificationIsAudit=" + IdentificationIsAudit + ",AuditFailedReason='" +
                   strAuditFailedReason + "' where Guid in('" + Guid + "')";
            sqlList.Add(item);
            item = "update ShopNum1_ShopInfo set IdentityIsAudit=" + IdentificationIsAudit + " where MemLoginID in ('" +
                   memLoginID + "')";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateLoginTime(string memloginid, string lastloginip)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@lastloginip";
            paraValue[1] = lastloginip;
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateLoginTime", paraName, paraValue);
        }

        public int UpdateMemberRecordPva(string memLoginID, int Score_pv_a, DateTime record_time)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@memLoginID";

            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@Score_pv_a";
            parms[1].Value = Score_pv_a;
            parms[2].ParameterName = "@record_time";
            parms[2].Value = record_time;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET [Score_record _pv_a]=@Score_pv_a,[Score_record _time]=@record_time  WHERE MemLoginID=@memLoginID", parms);
        }

        public int UpdateMember(string RealName, string Name, string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@RealName";
            parms[0].Value = RealName;
            parms[1].ParameterName = "@Name";
            parms[1].Value = Name;
            parms[2].ParameterName = "@memLoginID";
            parms[2].Value = memLoginID;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET RealName\t=@RealName, \tName=@Name WHERE MemLoginID=@memLoginID", parms);
        }

        public int UpdateMemberAssignGroup(ShopNum1_MemberGroup memberGroup, List<string> memberAssignGroup)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item =
                string.Concat(new object[]
                {
                    "UPDATE  ShopNum1_MemberGroup SET  Name ='", memberGroup.Name, "', Description ='",
                    memberGroup.Description, "', CreateUser ='", memberGroup.ModifyUser, "', CreateTime ='",
                    memberGroup.ModifyTime, "'WHERE Guid='", memberGroup.Guid, "'"
                });
            sqlList.Add(item);
            item = "Delete from ShopNum1_MemberAssignGroup where MemberGroupGuid='" + memberGroup.Guid + "'";
            sqlList.Add(item);
            if (memberAssignGroup.Count > 0)
            {
                for (int i = 0; i < memberAssignGroup.Count; i++)
                {
                    item =
                        string.Concat(new object[]
                        {
                            "INSERT INTO ShopNum1_MemberAssignGroup(   Guid,  MemLoginID,  MemberGroupGuid,  CreateUser,  CreateTime ) VALUES (  '"
                            , Guid.NewGuid(), "', '", memberAssignGroup[i], "', '", memberGroup.Guid, "', '",
                            memberGroup.ModifyUser, "', '", memberGroup.ModifyTime, "')"
                        });
                    sqlList.Add(item);
                }
            }
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateMemberRealNameByMemberLoginID(string RealName, string MemLoginID)
        {
            string strSql = string.Empty;
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@RealName";
            paraValue[0] = RealName;
            paraName[1] = "@MemLoginID";
            paraValue[1] = MemLoginID;
            strSql = "UPDATE ShopNum1_Member  SET RealName=@RealName where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UpdateMemberScore(string memloginID, int rankscore, int score)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginID;
            paraName[1] = "@rankscore";
            paraValue[1] = rankscore.ToString();
            paraName[2] = "@score";
            paraValue[2] = score.ToString();
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemberScore", paraName, paraValue);
        }

        public int UpdateMemberType(string guids, int memberType)
        {
            List<DbParameter> parms = new List<DbParameter>();

            string andSql = string.Format(" in ({0})", DatabaseExcetue.GetGuidsSql(guids, parms));

            DbParameter parm = new SqlParameter();
            parm.ParameterName = "@memberType";
            parm.Value = memberType;
            parms.Add(parm);
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE ShopNum1_Member SET MemberType=@memberType WHERE MemLoginID in(select MemLoginID from dbo.ShopNum1_ShopInfo where Guid"+andSql+")"
                    }), parms.ToArray());
        }

        public int UpdateMemInfo(string strMemberId, ShopNum1_Member Member)
        {
            var paraName = new string[10];
            var paraValue = new string[10];
            paraName[0] = "@RealName";
            paraValue[0] = Member.RealName;
            paraName[1] = "@Sex";
            paraValue[1] = Member.Sex.ToString();
            paraName[2] = "@Email";
            paraValue[2] = Member.Email;
            paraName[3] = "@QQ";
            paraValue[3] = Member.QQ;
            paraName[4] = "@MemLoginID";
            paraValue[4] = strMemberId;
            paraName[5] = "@Tel";
            paraValue[5] = Member.Tel;
            paraName[6] = "@Name";
            paraValue[6] = Member.Name;
            paraName[7] = "@Mobile";
            paraValue[7] = Member.Mobile;
            paraName[8] = "@modifyUser";
            paraValue[8] = Member.ModifyUser;
            paraName[9] = "@modifyTime";
            paraValue[9] = Convert.ToDateTime(Member.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss");
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemInfo", paraName, paraValue);
        }

        public int UpdateMemInfoDetail(string strMemberId, ShopNum1_Member Member)
        {
            var paraName = new string[12];
            var paraValue = new string[12];
            paraName[0] = "@Postalcode";
            paraValue[0] = Member.Postalcode;
            paraName[1] = "@Area";
            paraValue[1] = Member.Area;
            paraName[2] = "@Vocation";
            paraValue[2] = Member.Vocation;
            paraName[3] = "@Address";
            paraValue[3] = Member.Address;
            paraName[4] = "@Birthday";
            paraValue[4] = Member.Birthday.ToString();
            paraName[5] = "@MemLoginID";
            paraValue[5] = strMemberId;
            paraName[6] = "@AddressCode";
            paraValue[6] = Member.AddressCode;
            paraName[7] = "@AddressValue";
            paraValue[7] = Member.AddressValue;
            paraName[8] = "@Fax";
            paraValue[8] = Member.Fax;
            paraName[9] = "@WebSite";
            paraValue[9] = Member.WebSite;
            paraName[10] = "@modifyUser";
            paraValue[10] = Member.ModifyUser;
            paraName[11] = "@modifyTime";
            paraValue[11] = Convert.ToDateTime(Member.ModifyTime).ToString("yyyy-MM-dd HH:mm:ss");
            return DatabaseExcetue.RunProcedure("Pro_ShopNum1_UpdateMemInfoDetil", paraName, paraValue);
        }

        /// <summary>
        /// 修改交易密码
        /// </summary>
        /// <param name="MemberLogin"></param>
        /// <param name="PayPwd"></param>
        /// <returns></returns>
        public int UpdatePayPwd(string MemberLogin, string PayPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemberLogin";
            parms[0].Value = MemberLogin;
            parms[1].ParameterName = "@PayPwd";
            parms[1].Value = PayPwd;
            var builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Member ");
            builder.Append(" SET PayPwd =@PayPwd");
            builder.Append(" WHERE MemLoginID =@MemberLogin");
            return DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
        }

        /// <summary>
        /// 修改交易密码
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="oldPayPwd"></param>
        /// <param name="newPayPwd"></param>
        /// <returns></returns>
        public int UpdatePayPwd(string memLoginID, string oldPayPwd, string newPayPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@newPayPwd";
            parms[1].Value = newPayPwd;

            if (
                DatabaseExcetue.ReturnDataTable("SELECT Guid, PayPwd\t  FROM ShopNum1_Member   WHERE  MemLoginID =@memLoginID", parms).Rows[0]["PayPwd"].ToString() == oldPayPwd)
            {
                return
                    DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPayPwd\t=@newPayPwd WHERE MemLoginID=@memLoginID", parms);
            }
            return -2;
        }

        public int UpdatePhoto(string MemLoginID, string Photo)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Photo";
            parms[1].Value = Photo;
            var builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Member ");
            builder.Append(" SET Photo =@Photo");
            builder.Append(" WHERE MemLoginID =@MemLoginID");
            return DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
        }

        public int UpdatePhotoGZZ(string MemLoginID, string Photo)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Name";
            parms[1].Value = Photo;
            var builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Member ");
            builder.Append(" SET Name =@Name");
            builder.Append(" WHERE MemLoginID =@MemLoginID");
            return DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
        }

        public int UpdatePhotoGZ(string MemLoginID, string Photo, string Name)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@Photo";
            parms[1].Value = Photo;
            parms[2].ParameterName = "@Name";
            parms[2].Value = Name;
            var builder = new StringBuilder();
            builder.Append(" UPDATE ShopNum1_Member ");
            builder.Append(" SET Photo =@Photo,Name=@Name");
            builder.Append(" WHERE MemLoginID =@MemLoginID");
            return DatabaseExcetue.RunNonQuery(builder.ToString(), parms);
        }

        /// <summary>
        /// 修改会员密码
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string memLoginID, string oldPwd, string newPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@newPwd";
            parms[1].Value = newPwd;
            if (
                DatabaseExcetue.ReturnDataTable("SELECT Guid, Pwd  FROM ShopNum1_Member   WHERE  MemLoginID =@memLoginID", parms).Rows[0]["Pwd"].ToString() == oldPwd)
            {
                return
                    DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPwd\t=@newPwd  WHERE MemLoginID=@memLoginID", parms);
            }
            return -2;
        }

        /// <summary>
        /// 更新会员积分、级别
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public int UpdateScore(ShopNum1_Member member)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Member SET Score\t=", member.Score, ", \tMemberRank\t=", member.MemberRank,
                        " WHERE MemLoginID='", member.MemLoginID, "'"
                    }));
        }

        /// <summary>
        /// 更新会员积分、级别、信用积分
        /// </summary>
        /// <param name="Score"></param>
        /// <param name="MemberRank"></param>
        /// <param name="CreditScore"></param>
        /// <param name="MemLoginID"></param>
        /// <returns></returns>
        public int UpdateScore(string Score, string MemberRank, string CreditScore, string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@Score";
            parms[0].Value = Score;
            parms[1].ParameterName = "@MemberRank";
            parms[1].Value = MemberRank;
            parms[2].ParameterName = "@CreditScore";
            parms[2].Value = CreditScore;
            parms[3].ParameterName = "@MemLoginID";
            parms[3].Value = MemLoginID;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET Score\t=Score+ @Score, \tMemberRank\t=MemberRank+@MemberRank,\tCreditScore\t=CreditScore+@CreditScore  WHERE MemLoginID=@MemLoginID", parms);
        }

        /// <summary>
        /// 金币（BV）充值
        /// </summary>
        /// <param name="memloginid"></param>
        /// <param name="ChangeAdvancPayment"></param>
        /// <returns></returns>
        public int UpdtateMemberAdvancePayment(string memloginid, string ChangeAdvancPayment)
        {
            string strSql = string.Empty;
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memloginid;
            paraName[1] = "@advancepayment";
            paraValue[1] = ChangeAdvancPayment;
            strSql = "UPDATE ShopNum1_Member SET   AdvancePayment+=@advancepayment where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }


        public int UpdtateMemberIsProtecionStyle(string memloginid, int IsProtecionStyle)
        {
            string strSql = string.Empty;
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@MemLoginID";
            paraValue[0] = memloginid;
            paraName[1] = "@IsProtecionStyle";
            paraValue[1] = IsProtecionStyle.ToString();
            strSql = "UPDATE ShopNum1_Member SET   IsProtecion=@IsProtecionStyle where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }


        public int AddHv(string memloginNO, decimal bv, string mome, string EnterName)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginNO;
            paraName[1] = "@dv";
            paraValue[1] = bv.ToString();
            paraName[2] = "@mome";
            paraValue[2] = mome;
            paraName[3] = "@EnterName";
            paraValue[3] = EnterName;

            return DatabaseExcetue.RunProcedure("shopnum1_StoreAdd_hv", paraName, paraValue);
        }

        public DataTable isCardno(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable(
                    "select * from ShopNum1_Member where MemLoginID =@MemLoginID", parms);
        }

        public int UploadingCardPic(string MemLoginID, string IdentityCardImg, string IdentityCard, string RealName,
            string IdentificationTime)
        {
            string strSql = string.Empty;
            var paraName = new string[5];
            var paraValue = new string[5];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@IdentityCardImg";
            paraValue[1] = IdentityCardImg;
            paraName[2] = "@IdentityCard";
            paraValue[2] = IdentityCard;
            paraName[3] = "@RealName";
            paraValue[3] = RealName;
            paraName[4] = "@IdentificationTime";
            paraValue[4] = IdentificationTime;
            strSql =
                "update ShopNum1_Member SET IdentityCardImg=@IdentityCardImg,IdentificationIsAudit=2,IdentityCard=@IdentityCard,RealName=@RealName,IdentificationTime=@IdentificationTime where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int UploadingCardPic(string MemLoginID, string IdentityCardImg, string IdentityCardBackImg,
            string IdentityCard, string RealName, string IdentificationTime)
        {
            string strSql = string.Empty;
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@MemLoginID";
            paraValue[0] = MemLoginID;
            paraName[1] = "@IdentityCardImg";
            paraValue[1] = IdentityCardImg;
            paraName[2] = "@IdentityCardBackImg";
            paraValue[2] = IdentityCardBackImg;
            paraName[3] = "@IdentityCard";
            paraValue[3] = IdentityCard;
            paraName[4] = "@RealName";
            paraValue[4] = RealName;
            paraName[5] = "@IdentificationTime";
            paraValue[5] = IdentificationTime;
            strSql =
                "update ShopNum1_Member SET IdentityCardImg=@IdentityCardImg,IdentityCardBackImg=@IdentityCardBackImg,IdentificationIsAudit=0,IdentityCard=@IdentityCard,RealName=@RealName,IdentificationTime=@IdentificationTime where MemLoginID=@MemLoginID";
            return DatabaseExcetue.RunNonQuery(strSql, paraName, paraValue);
        }

        public int AddSignin(ShopNum1_SignIn signIn)
        {
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "Insert into ShopNum1_SignIn values('", signIn.guid, "','", signIn.CreateTime, "','",
                        signIn.MemLoginID, "')"
                    }));
        }

        public int CheckMemEmail(string Email)
        {
            string strProcedureName = "Pro_ShopNum1_CheckMemEmail";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@Email";
            paraValue[0] = Email;
            DataTable table = DatabaseExcetue.RunProcedureReturnDataTable(strProcedureName, paraName, paraValue);
            if (table == null)
            {
                return 0;
            }
            return table.Rows.Count;
        }

        public DataTable CheckSignin(string strMemLoginID, string dayTime)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    "select count(1) as count from ShopNum1_SignIn where convert(varchar,createTime,120)  like '" +
                    dayTime + "%' and MemLoginID ='" + strMemLoginID + "'");
        }

        public int DeleteMemberGroup(string guids)
        {
            var sqlList = new List<string>();
            string item = string.Empty;
            item = "DELETE FROM ShopNum1_MemberAssignGroup  WHERE  MemberGroupGuid IN (" + guids + ")";
            sqlList.Add(item);
            item = "DELETE FROM ShopNum1_MemberGroup  WHERE  Guid IN (" + guids + ")";
            sqlList.Add(item);
            try
            {
                DatabaseExcetue.RunTransactionSql(sqlList);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <returns></returns>
        public DataTable GetAdvancePayment(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable((string.Empty +
                                                 "   SELECT AdvancePayment,Email,Mobile  FROM  ShopNum1_Member  WHERE 1=1        ") +
                                                "    AND  MemLoginID=@MemLoginID", parms);
        }


        public DataTable SelectIsProtecionByMemerberloginID(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
               DatabaseExcetue.ReturnDataTable("   SELECT IsProtecion  FROM  ShopNum1_Member  WHERE 1=1  AND  MemLoginID=@MemLoginID", parms);
        }
        public DataTable SelectMyDv(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            return
               DatabaseExcetue.ReturnDataTable("SELECT AdvancePayment,MemLoginID,PayPwd,MemLoginNO,RealName,IsFuwuzhan    FROM [Shopnum1].[dbo].[ShopNum1_Member] WHERE MemLoginID=@MemLoginID", parms);
        }


        /// <summary>
        /// 金币（BV）合计
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetAllAdvancePayment(int type, int operateType)
        {
            string strSql = string.Empty;
            switch (type)
            {
                case -1:
                    if (operateType == 1)
                    {
                        strSql = "   SELECT   SUM(AdvancePayment)    FROM ShopNum1_Member    ";
                    }
                    else if (operateType == 2)
                    {
                        strSql = "   SELECT   SUM(Score_rv)    FROM ShopNum1_Member    ";
                    }
                    else if (operateType == 3)
                    {
                        strSql = "   SELECT   SUM(Score_dv)    FROM ShopNum1_Member    ";
                    }
                    break;

                case 0:
                    strSql = "   SELECT   SUM(AdvancePayment)    FROM ShopNum1_Member WHERE MemberType=1   ";
                    break;

                case 1:
                    strSql = "   SELECT   SUM(AdvancePayment)    FROM ShopNum1_Member WHERE MemberType=2      ";
                    break;
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public string GetCurrentMemberRankGuid(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  MemberRankGuid  FROM ShopNum1_Member  WHERE MemLoginID=@memLoginID", parms).Rows[0]["MemberRankGuid"].ToString();
        }

        public string GetCurrentMemberType(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  MemberType  FROM ShopNum1_Member  WHERE MemLoginID=@memLoginID", parms).Rows[0]["MemberType"].ToString();
        }

        public string GetIsShopActivate(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  IsShopActivate  FROM ShopNum1_Member  WHERE MemLoginID=@memLoginID", parms).Rows[0]["IsShopActivate"].ToString();
        }

        public DataTable GetCurrentMemberRankGuid_two(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  MemberRankGuid  FROM ShopNum1_Member  WHERE  MemLoginNO=@memLoginID", parms);
        }


        public string GetGuidByMemLoginID(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  Guid  FROM ShopNum1_Member  WHERE MemLoginID=@memLoginID", parms).Rows[0]["Guid"].ToString();
        }

        public string GetGuidByMemLoginNO(string memLoginNO)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginNO";
            parms[0].Value = memLoginNO;
            return
                DatabaseExcetue.ReturnDataTable(" SELECT  Guid  FROM ShopNum1_Member  WHERE MemLoginNO=@memLoginNO", parms).Rows[0]["Guid"].ToString();
        }

        /// <summary>
        /// 支付方式
        /// </summary>
        /// <param name="IsShopUse"></param>
        /// <returns></returns>
        public DataTable GetPaymentType(int IsShopUse)
        {
            string str = string.Empty;
            str = "   SELECT * FROM  ShopNum1_PaymentType  WHERE 1=1        ";
            if (IsShopUse != -1)
            {
                object obj2 = str;
                str = string.Concat(new[] { obj2, "   AND  IsShopUse=", IsShopUse, "   " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER  BY  OrderID  ASC     ");
        }

        public DataTable MemberFindPwdPro(string email, string question)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@email";
            paraValue[0] = email;
            paraName[1] = "@question";
            paraValue[1] = question;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_ShopNum1_MemberFindPwd", paraName, paraValue);
        }

        public DataTable SearchAdvancePayment(string MemLoginID, int operateType)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string str = string.Empty;
            if (operateType == 1)
            {
                str = "   SELECT   MemLoginID,AdvancePayment as Frist_Money,LockAdvancePayment,Name FROM ShopNum1_Member   ";
            }
            else if (operateType == 2)
            {
                str = "   SELECT   MemLoginID,LockAdvancePayment,Name,Score_rv as Frist_Money FROM ShopNum1_Member   ";
            }
            else if (operateType == 3)
            {
                str = "   SELECT   MemLoginID,LockAdvancePayment,Name,Score_dv as Frist_Money FROM ShopNum1_Member   ";
            }
            if (!string.IsNullOrEmpty(MemLoginID))
            {
                str = str + "    WHERE  MemLoginID=@MemLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER BY   AdvancePayment    DESC      ", parms);
        }
        public DataTable SearchPV(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            string str = string.Empty;
            str = "   SELECT  [Kid],[MemLoginID],[num1] ,([num2]+[num3]+[num4] +[num5])*0.1 as num2345,[Allnum] ,[CreateTime],[isDelete] FROM [KCEBonusRecord]  ";
            if (!string.IsNullOrEmpty(MemLoginID))
            {
                str = str + "    WHERE  MemLoginID=@MemLoginID";
            }
            return DatabaseExcetue.ReturnDataTable(str + "    ORDER BY   CreateTime    DESC      ", parms);
        }

        public DataTable SearchMemberGroup(int isDeleted)
        {
            string str = string.Empty;
            str = "SELECT \tGuid\t, \tName,  Description   FROM ShopNum1_MemberGroup  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                str = string.Concat(new object[] { str, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By CreateTime Desc");
        }

        public DataTable SearchMemberNameEmail(string memLoginID, string Type)
        {
            string strSql = string.Empty;
            strSql = "SELECT  Guid,  MemLoginID, Email,  RealName FROM ShopNum1_Member   WHERE  1=1";
            if (Operator.FormatToEmpty(memLoginID) != "-1")
            {
                strSql = strSql + " AND MemLoginID =" + memLoginID;
            }
            if (Operator.FormatToEmpty(Type) != "-1")
            {
                strSql = strSql + " AND MemberType = " + Operator.FilterString(Type);
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SearchMemberRank(int isDeleted)
        {
            string strSql = string.Empty;
            strSql = "SELECT \tGuid\t, \tName ,  minScore, maxScore  FROM ShopNum1_MemberRank  WHERE 0=0 ";
            if (isDeleted == 0)
            {
                strSql = string.Concat(new object[] { strSql, " AND IsDeleted =", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }

        public DataTable SelectMember_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = "ShopNum1_Member";
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "RegDate";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectRecommendCommision_List(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@pagesize";
            paraValue[0] = commonModel.PageSize;
            paraName[1] = "@currentpage";
            paraValue[1] = commonModel.Currentpage;
            paraName[2] = "@columns";
            paraValue[2] = " * ";
            paraName[3] = "@tablename";
            paraValue[3] = commonModel.Tablename;
            paraName[4] = "@condition";
            paraValue[4] = commonModel.Condition;
            paraName[5] = "@ordercolumn";
            paraValue[5] = "ReceiptTime";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
        public int proaddAdvancePayment(string memloginNO, decimal bv)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginNO;
            paraName[1] = "@bv";
            paraValue[1] = bv.ToString();
            paraName[2] = "@mome";
            paraValue[2] = " TJ转入";

            return DatabaseExcetue.RunProcedure("shopnum1_addAdvancePayment", paraName, paraValue);
        }

        public int XiaoFeiDV(string memloginNO, decimal bv)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginNO;
            paraName[1] = "@bv";
            paraValue[1] = bv.ToString();
            paraName[2] = "@mome";
            paraValue[2] = "转到闲时游";

            return DatabaseExcetue.RunProcedure("shopnum1_XiaoFeiAdvancePayment", paraName, paraValue);
        }

        public int XiaoFeiCSBV(string memloginNO, decimal bv)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginNO;
            paraName[1] = "@bv";
            paraValue[1] = bv.ToString();
            paraName[2] = "@mome";
            paraValue[2] = "兑换原料包";

            return DatabaseExcetue.RunProcedure("shopnum1_XiaoFeiAdvancePayment", paraName, paraValue);
        }
        public int XiaoFeiCSBVTwo(string memloginNO, decimal bv, string OrderNumber)
        {
            var paraName = new string[4];
            var paraValue = new string[4];
            paraName[0] = "@memloginno";
            paraValue[0] = memloginNO;
            paraName[1] = "@bv";
            paraValue[1] = bv.ToString();
            paraName[2] = "@mome";
            paraValue[2] = "兑换原料包";
            paraName[3] = "@OrderNumber";
            paraValue[3] = OrderNumber;
            return DatabaseExcetue.RunProcedure("shopnum1_XiaoFeiAdvancePaymentTWO", paraName, paraValue);
        }

        public int UpdateemLoginTypeByMemLoginID(string Guid, int IsForbid)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@Guid";
            parms[0].Value = Guid.Replace("'", "");
            parms[1].ParameterName = "@IsForbid";
            parms[1].Value = IsForbid;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[] { "UPDATE  ShopNum1_Member SET IsForbid=@IsForbid where Guid=@Guid" }), parms);
        }

        /// <summary>
        /// 修改会员密码
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int UpdatePwd(string memLoginID, string newPwd)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@newPwd";
            parms[1].Value = newPwd;
            return
                DatabaseExcetue.RunNonQuery("UPDATE  ShopNum1_Member SET \tPwd\t=@newPwd  WHERE MemLoginID=@memLoginID", parms);
        }

        public int UpdateIsShopActivate(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;

            return
                DatabaseExcetue.RunNonQuery("UPDATE [Shopnum1].[dbo].[ShopNum1_Member] SET [IsShopActivate]=1 WHERE MemLoginID=@memLoginID", parms);
        }

        /// <summary>
        /// 生成会员编号
        /// </summary>
        /// <returns></returns>
        public string GetMemberNumber()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                random.Next(Convert.ToInt32(DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()));
            }
            while (true)
            {
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < 7; i++)
                {
                    bool flag;
                    int num2 = 0;
                    goto Label_0094;
                    Label_007C:
                    num2 = random.Next(0, 9);
                    if (num2 != 4)
                    {
                        goto Label_0099;
                    }
                    Label_0094:
                    flag = true;
                    goto Label_007C;
                    Label_0099:
                    builder.Append(num2);
                }

                if ((builder.ToString().IndexOf("0") != 0) && (getNumber(builder.ToString()) == 0))
                {
                    return "C" + builder.ToString();
                }
            }
        }

        /// <summary>
        /// 生成会员编号K
        /// </summary>
        /// <returns></returns>
        public string GetGZMemberNumber()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                random.Next(Convert.ToInt32(DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()));
            }

            while (true)
            {
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < 8; i++)
                {
                    bool flag;
                    int num2 = 0;
                    goto Label_0094;
                    Label_007C:
                    num2 = random.Next(0, 9);
                    if (num2 != 4)
                    {
                        goto Label_0099;
                    }
                    Label_0094:
                    flag = true;
                    goto Label_007C;
                    Label_0099:
                    builder.Append(num2);
                }

                if ((builder.ToString().IndexOf("0") != 0) && (getNumber(builder.ToString()) == 0))
                {
                    return builder.ToString();
                }
            }
        }


        /// <summary>
        /// 生成会员编号S
        /// </summary>
        /// <returns></returns>
        public string GetMemberNumberRegister()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                random.Next(Convert.ToInt32(DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()));
            }
            while (true)
            {
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < 7; i++)
                {
                    bool flag;
                    int num2 = 0;
                    goto Label_0094;
                    Label_007C:
                    num2 = random.Next(0, 9);
                    if (num2 != 4)
                    {
                        goto Label_0099;
                    }
                    Label_0094:
                    flag = true;
                    goto Label_007C;
                    Label_0099:
                    builder.Append(num2);
                }

                if ((builder.ToString().IndexOf("0") != 0) && (getNumber_two(builder.ToString()) == 0))
                {
                    return "S" + builder.ToString();
                }
            }
        }

        /// <summary>
        /// 检查会员编号是否存在
        /// </summary>
        /// <param name="distributorId"></param>
        /// <returns></returns>
        public int getNumber(string distributorId)
        {
            string cmdText = "select count(MemLoginNO) from ShopNum1_Member where  MemLoginNO = @DistributorId";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@DistributorId";
            paraValue[0] = "C" + distributorId;
            int i = Convert.ToInt32(DatabaseExcetue.ReturnObject(cmdText, paraName, paraValue));
            return i;
        }
        public int getNumber_two(string distributorId)
        {
            string cmdText = "select count(MemLoginNO) from ShopNum1_Member where  MemLoginNO =@DistributorId";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@DistributorId";
            paraValue[0] = "S" + distributorId;
            int i = Convert.ToInt32(DatabaseExcetue.ReturnObject(cmdText, paraName, paraValue));
            return i;
        }
        /// <summary>
        /// 验证手机号码和账号是否一致
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="memloginid"></param>
        /// <returns></returns>
        public int mobileYZ(string mobile, string memloginid)
        {
            string cmdText = "select count(MemLoginID) from ShopNum1_Member where  MemLoginID = @memloginid and Mobile= @mobile";
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@Mobile";
            paraValue[0] = mobile;
            paraName[1] = "@MemLoginID";
            paraValue[1] = memloginid;
            int i = Convert.ToInt32(DatabaseExcetue.ReturnObject(cmdText, paraName, paraValue));
            return i;
        }


    }
 


}