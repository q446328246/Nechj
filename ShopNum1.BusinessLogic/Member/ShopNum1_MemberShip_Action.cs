using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;


namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_MemberShip_Action : IShopNum1_MemberShip_Action
    {
        /// <summary>
        /// 添加区代申请
        /// </summary>
        /// <param name="membership"></param>
        /// <returns></returns>
        public int Add(ShopNum1_MemberShip membership)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_MemberShip( \tMemLoginID, \tLastRankID, \tNewRankID, \tRealName, \tMemLoginNO, \tShipStatus, \tAddTime, \tBirthdayTime, \tIdentityCard, \tSex, \tPhone, \tMobile, \tAdress, \tBusinessArea, \tArea, \tOccupation, \tIdentityCardImage, \tRERealName, \tREMemLoginNO, \tREAddTime, \tREBirthdayTime, \tREIdentityCard, \tRESex, \tREPhone ,\tREMobile, \tREAdress, \tBelongs, \tShopNames, \tLicenseImage, \tOrganizationImage, \tRegistrationImage, \tExamineTime, \tShopImageone, \tShopImagetwo, \tOpeningImage) VALUES (  '"
                    , membership.MemLoginID, "','" , membership.LastRankID, "','" , membership.NewRankID, "','" , membership.RealName, "','" , membership.MemLoginNO, "'," , membership.ShipStatus, ",'" , membership.AddDate, "','" , membership.BirthdayTime, "','" , membership.IdentityCard, "','" , membership.Sex, "','" , membership.Phone, "','" , membership.Mobile, "','" , membership.Adress, "','" , membership.BusinessArea, "','" , membership.Area, "','" , membership.Occupation, "','" , membership.IdentityCardImage, "','" , membership.RERealName, "','" , membership.REMemLoginNO, "','" , membership.REAddTime, "','" , membership.REBirthdayTime, "','" , membership.REIdentityCard, "','" , membership.RESex, "','" , membership.REPhone, "','" , membership.REMobile, "','" , membership.REAdress, "','" , membership.Belongs, "','" , membership.ShopNames, "','" , membership.LicenseImage, "','" , membership.OrganizationImage, "','" , membership.RegistrationImage, "','" , membership.ExamineTime, "','" , membership.ShopImageone, "','" , membership.ShopImagetwo, "','" , membership.OpeningImage, "')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }
        /// <summary>
        /// 添加区代申请地址
        /// </summary>
        /// <param name="membershipAdress"></param>
        /// <returns></returns>
        public int AddShipAdress(ShopNum1_MemberShipAdress membershipAdress)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_MemberShipAdress( \tMemLoginID, \tProvince, \tCity, \tDistrict) VALUES (  '"
                    , membershipAdress.MemLoginID, "','" , membershipAdress.Province, "','" , membershipAdress.City, "','" , membershipAdress.District, "')"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }

        /// <summary>
        /// 修改区代申请地址
        /// </summary>
        /// <param name="membershipAdress"></param>
        /// <returns></returns>
        public int UpdateShipAdress(ShopNum1_MemberShipAdress membershipAdress)
        {
            string sqlQuery = string.Concat(new object[]
                {
                    "Update ShopNum1_MemberShipAdress set  Province='"+membershipAdress.Province+"', City='"+membershipAdress.City+"', District='"+membershipAdress.District+"' where MemLoginID='"+membershipAdress.MemLoginID+"'"
                });

            return DatabaseExcetue.RunNonQuery(sqlQuery);
        }


        /// <summary>
        /// 提交区代I→区代II的申请
        /// </summary>
        /// <param name="ShipID"></param>
        /// <returns></returns>
        public int UpdateUpgradetwo(string LastRank, string NewRank, string LicenseImage, string OrganizationImage, string RegistrationImage, string ShopImageone, string ShopImagetwo, string OpeningImage, string IdentityCardImage, string memLoginID)
        {
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MemberShip SET ShipStatus=3,LastRankID='",LastRank,"',NewRankID='",NewRank,"',LicenseImage='",LicenseImage,"',OrganizationImage='",OrganizationImage,"',RegistrationImage='",RegistrationImage,"',ShopImageone='",ShopImageone,"',ShopImagetwo='",ShopImagetwo,"',OpeningImage='",OpeningImage,"',IdentityCardImage='",IdentityCardImage,"' where MemLoginID='",memLoginID,"' and ShipStatus=2"
                    }));
        }
        /// <summary>
        /// 删除申请记录
        /// </summary>
        /// <param name="ShipID"></param>
        /// <returns></returns>
        public int DeleteMemberShipOfMemLoginID(string MemberLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemberLoginID";
            parms[0].Value = MemberLoginID;

            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MemberShip SET ShipStatus=0 where MemLoginID=@MemberLoginID and ShipStatus in (1,2)"
                    }), parms);
        }
        /// <summary>
        /// 拒绝申请
        /// </summary>
        /// <param name="ShipID"></param>
        /// <returns></returns>
        public int UpdateRefuseStatus(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;
            
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MemberShip SET ShipStatus\t=0 where MembershipID=@ShipID"
                    }),parms);
        }
        public int UpdateRefuseStatusNEC_Status(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;

            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  [Nec_ShenQinShangJia] SET Status=1 where id=@ShipID"
                    }), parms);
        }
        public int UpdateRefuseStatusNEC_Status2(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;

            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  [Nec_ShenQinShangJia] SET Status=2 where id=@ShipID"
                    }), parms);
        }
        public int UpdateRefuseStatusNEC_member(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;

            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Member SET IsBusiness=1 where MemLoginID=@ShipID"
                    }), parms);
        }


        /// 拒绝申请
        /// </summary>
        /// <param name="ShipID"></param>
        /// <returns></returns>
        public int UpdateRefuseweixinOpenid(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;

            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Member SET wx_open_id='' where MemLoginID=@ShipID"
                    }), parms);
        }

        public int UpdatePassStatus(string ShipID,DateTime ExamineTime)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;
            parms[1].ParameterName = "@ExamineTime";
            parms[1].Value = ExamineTime;
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MemberShip SET ShipStatus\t=2,ExamineTime=@ExamineTime where MembershipID=@ShipID"
                    }),parms);
        }
        public int UpdateOrderInfoStustes(string orderID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@orderID";
            parms[0].Value = orderID;
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_OrderInfo SET IsRefundStatus=1 where OrderNumber=@orderID"
                    }),parms);
        }
        /// <summary>
        /// 添加成为区代1的时间
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public int UpdateShipsTime(DateTime Upgrade_two_datatime, string MemLoginID, int shipStatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@Upgrade_two_datatime";
            parms[0].Value = Upgrade_two_datatime;
            parms[1].ParameterName = "@MemLoginID";
            parms[1].Value = MemLoginID;
            parms[2].ParameterName = "@shipStatu";
            parms[2].Value = shipStatu;
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_MemberShip SET Upgrade_two_datatime=@Upgrade_two_datatime where MemLoginID =@MemLoginID and ShipStatus=@shipStatu"
                    }), parms);
        }


        public int INsertAdvancePaymentModifyLog_Gz_BandPVA(string MemLoginID, decimal bv, string memo)
        {
            var parName = new string[3];
            var paraValue = new string[3];
            parName[0] = "@memloginno";
            paraValue[0] = MemLoginID;
            parName[1] = "@dv";
            paraValue[1] = bv.ToString();
            parName[2] = "@mome";
            paraValue[2] = memo;
            return DatabaseExcetue.RunProcedure("[dbo].shopnum1_HuoDe_pv_a", parName, paraValue);
        }

        
        public int UpdateGPSBandStatus(string deviceno)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@deviceno";
            parms[0].Value = deviceno;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  GPS_device SET BandStatus=1 where device_no =@deviceno"
                    }), parms);
        }

        /// <summary>
        /// 根据会员ID查询所有信息
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable SearchGPSBand(string deviceno)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@deviceno";
            parms[0].Value = deviceno;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM GPS_device  WHERE device_no =@deviceno"
                    }), parms);
        }


        /// <summary>
        /// 根据会员ID查询所有信息
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <returns></returns>
        public DataTable SearchShipMem(string memLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_MemberShip   WHERE MemLoginID =@memLoginID"
                    }),parms); 
        }
        public DataTable SearchShipAdress(string Province, string City, string District)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(3);

            parms[0].ParameterName = "@Province";
            parms[0].Value = Province;
            parms[1].ParameterName = "@City";
            parms[1].Value = City;
            parms[2].ParameterName = "@District";
            parms[2].Value = District;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_MemberShipAdress   WHERE Province =@Province and City=@City and District=@District"
                    }),parms);
        }

        public DataTable SearchShipAdressID(ShopNum1_MemberShipAdress memberShipAdress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = memberShipAdress.MemLoginID;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_MemberShipAdress   WHERE MemLoginID=@MemLoginID"
                    }), parms);
        }

        /// <summary>
        /// 判断会员id和地址是否同时存在
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="Shipstatu"></param>
        /// <returns></returns>

        public DataTable SearchShipAdressAndID(ShopNum1_MemberShipAdress memberShipAdress)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(4);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = memberShipAdress.MemLoginID;
            parms[1].ParameterName = "@Province";
            parms[1].Value = memberShipAdress.Province;
            parms[2].ParameterName = "@City";
            parms[2].Value = memberShipAdress.City;
            parms[3].ParameterName = "@District";
            parms[3].Value = memberShipAdress.District;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_MemberShipAdress   WHERE MemLoginID=@MemLoginID and Province =@Province and City=@City and District=@District"
                    }), parms);
        }

        /// <summary>
        /// 根据会员ID查询某个状态存在的条数
        /// </summary>
        /// <param name="memLoginID"></param>
        /// <param name="Shipstatu"></param>
        /// <returns></returns>
        public object SearchHaveShip(string memLoginID, int Shipstatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@memLoginID";
            parms[0].Value = memLoginID;
            parms[1].ParameterName = "@Shipstatu";
            parms[1].Value = Shipstatu;
            return
                DatabaseExcetue.ReturnObject(
                    string.Concat(new object[]
                    {
                        "SELECT count(*)  FROM ShopNum1_MemberShip   WHERE MemLoginID =@memLoginID AND ShipStatus =@Shipstatu"
                    }),parms);
        }

        public DataTable SearchShipID(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_MemberShip   WHERE MembershipID=@ShipID"
                    }),parms);
        }
        public DataTable SearchShipIDNEC(string ShipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@ShipID";
            parms[0].Value = ShipID;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "  select * from [Nec_ShenQinShangJia]  where [ID]=@ShipID"
                    }), parms);
        }
        public DataTable selectAllOrder_Refuse(string text)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@text";
            parms[0].Value = text;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_Order_Refuse where Status=@text order by ID desc"
                    }),parms);
        }

        public DataTable selectAllOrderbypaymentstatus()
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_OrderInfo where PaymentStatus=2 and refundstatus=1 and IsRefundStatus=0 "
                    }));
        }

        public DataTable selectAllOrderinfoBYOderID( string OrderID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderID";
            parms[0].Value = OrderID; 
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_OrderInfo where PaymentStatus=2 and refundstatus=1 and IsRefundStatus=0 and OrderNumber=@OrderID"
                    }),parms);
        }


        public DataTable selectOrderByOrder_Refuse(string OrderID, string MemloginID, string Mome)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@OrderID";
            parms[0].Value = OrderID;
            
            string sql = "";
            sql = "SELECT *  FROM ShopNum1_Order_Refuse where 0=0 ";
            if (OrderID!=""&&OrderID!=null)
            {
                sql = sql + " and OrderID=@OrderID";
            }
            if (MemloginID != "" && MemloginID != null)
            {
                sql = sql + " and MemberloginID like '%" + MemloginID + "%'";
            }
            if (Mome != "" && Mome != null)
            {
                sql = sql + " and Remark like '%"+Mome+"%'";
            }
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                       sql
                    }),parms);
        }


        public int UpdateRefuseStatus_two(string OrderID, string AdminID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@OrderID";
            parms[0].Value = OrderID;
            parms[1].ParameterName = "@AdminID";
            parms[1].Value = AdminID;
            new List<string>();
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "UPDATE  ShopNum1_Order_Refuse SET Status=1 ,AdminID=@AdminID where OrderID=@OrderID"
                    }),parms);
        }


        public DataTable SearchShip(int Shipstatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Shipstatu";
            parms[0].Value = Shipstatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM ShopNum1_MemberShip WHERE ShipStatus =@Shipstatu"
                    }),parms);
        }
        public DataTable SearchShipNEC(int Shipstatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@Shipstatu";
            parms[0].Value = Shipstatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *  FROM [Nec_ShenQinShangJia] WHERE Status =@Shipstatu"
                    }), parms);
        }

        /// <summary>
        /// 根据用户编号查询
        /// </summary>
        /// <param name="MemLoginNO"></param>
        /// <param name="shipStatu"></param>
        /// <returns></returns>
        public DataTable SearchShipMemLoginNO(string MemLoginNO, int shipStatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            parms[1].ParameterName = "@shipStatu";
            parms[1].Value = shipStatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *,(select Name from ShopNum1_MemberRank where LastRankID=Guid)LastRankName,(select Name from ShopNum1_MemberRank where NewRankID=Guid)NewRankName  FROM ShopNum1_MemberShip WHERE MemLoginNO =@MemLoginNO and ShipStatus=@shipStatu"
                    }),parms);
        }
        public DataTable SearchShipMemLoginNONEC(string MemLoginNO, int shipStatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginNO";
            parms[0].Value = MemLoginNO;
            parms[1].ParameterName = "@shipStatu";
            parms[1].Value = shipStatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        " select * from [Nec_ShenQinShangJia]  where MemloginID =@MemLoginNO and Status=@shipStatu"
                    }), parms);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="shipStatu"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 检查重复
        /// </summary>
        /// <param name="MemLoginID"></param>
        /// <param name="shipStatu"></param>
        /// <returns></returns>
        public DataTable SearchShipRepeatMemLoginID(string MemLoginID, int shipStatu)
        {  
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@shipStatu";
            parms[1].Value = shipStatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT * FROM ShopNum1_MemberShip WHERE MemLoginID =@MemLoginID and ShipStatus=@shipStatu"
                    }),parms);
        }


        public DataTable Check_Device(string MemLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;

            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT device_no FROM ShopNum1_Member  WHERE MemLoginID =@MemLoginID "
                    }), parms);
        }

        public DataTable IsTwoSearchShipRepeatMemLoginID(string MemLoginID, int shipStatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@MemLoginID";
            parms[0].Value = MemLoginID;
            parms[1].ParameterName = "@shipStatu";
            parms[1].Value = shipStatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT * FROM ShopNum1_MemberShip WHERE MemLoginID =@MemLoginID and ShipStatus in(1,2)"
                    }), parms);
        }


        public DataTable SearchShipStatu( int shipStatu)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@shipStatu";
            parms[0].Value = shipStatu;
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Concat(new object[]
                    {
                        "SELECT *,(select Name from ShopNum1_MemberRank where LastRankID=Guid)LastRankName,(select Name from ShopNum1_MemberRank where NewRankID=Guid)NewRankName  FROM ShopNum1_MemberShip WHERE  ShipStatus=@shipStatu"
                    }),parms);
        }
        /// <summary>
        /// 删除区代申请
        /// </summary>
        /// <param name="MembershipID"></param>
        /// <returns></returns>
        public int Delete(string MembershipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MembershipID";
            parms[0].Value = MembershipID.Replace("'","");
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM ShopNum1_MemberShip WHERE  MembershipID =@MembershipID", parms);
            int Row = Convert.ToInt32(table.Rows[0][0]);  
            if (Row > 0 )
            {
                DataTable table2 =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  MemLoginID FROM ShopNum1_MemberShip WHERE  MembershipID =@MembershipID", parms);
                DbParameter[] parms2 = DatabaseExcetue.CreateParameter(1);
                parms2[0].ParameterName = "@MemLoginID";
                parms2[0].Value = table2.Rows[0]["MemLoginID"].ToString();
                 DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MemberShip  WHERE  MembershipID =@MembershipID",parms);
                 DatabaseExcetue.RunNonQuery("update ShopNum1_Member set deviceType=0,wx_open_id='',device_no='',CarType='',CarNo=''  WHERE  MemLoginID =@MemLoginID", parms2);
                 return 1;
                
                
            }
            return -1;
        }
        /// <summary>
        ///删除商家申请列表
        /// </summary>
        /// <param name="MembershipID"></param>
        /// <returns></returns>
        public int DeleteNEC(string MembershipID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MembershipID";
            parms[0].Value = MembershipID.Replace("'", "");
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM Nec_ShenQinShangJia WHERE  ID =@MembershipID", parms);
            int Row = Convert.ToInt32(table.Rows[0][0]);
            if (Row > 0)
            {

                DatabaseExcetue.RunNonQuery(" update  Nec_ShenQinShangJia set Status=3 WHERE  ID =@MembershipID", parms); //状态为3是删除
                return 1;


            }
            return -1;
        }
        /// <summary>
        /// 删除区代申请地址
        /// </summary>
        /// <param name="MembershipID"></param>
        /// <returns></returns>
        public int DeleteShipAdress(string MemberLoginID)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(1);

            parms[0].ParameterName = "@MembershipID";
            parms[0].Value = MemberLoginID;
            DataTable table =
               DatabaseExcetue.ReturnDataTable(
                   "SELECT  COUNT(*) AS NUM FROM ShopNum1_MemberShipAdress WHERE  MemLoginID =@MembershipID", parms);
           
            if (table.Rows.Count > 0)
            {
                DatabaseExcetue.RunNonQuery("DELETE FROM ShopNum1_MemberShipAdress  WHERE  MemLoginID =@MembershipID", parms);
                return 1;


            }
            return -1;
        }
    }
}
