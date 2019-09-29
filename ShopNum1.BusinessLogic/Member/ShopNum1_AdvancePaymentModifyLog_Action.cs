using System.Collections.Generic;
using System.Data;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_AdvancePaymentModifyLog_Action : IShopNum1_AdvancePaymentModifyLog_Action
    {
        /// <summary>
        /// 未处理 0、已完成 1、已拒绝 2
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="OperateStatus"></param>
        /// <returns></returns>
        public int ChangeOperateStatus(string ID, int OperateStatus)
        {
            DbParameter[] parms = DatabaseExcetue.CreateParameter(2);

            parms[0].ParameterName = "@ID";
            parms[0].Value = ID;
            parms[1].ParameterName = "@OperateStatus";
            parms[1].Value = OperateStatus;
            return
                DatabaseExcetue.RunNonQuery(
                    string.Concat(new object[]
                    {
                        "   UPDATE  ShopNum1_AdvancePaymentApplyLog  SET  OperateStatus =@OperateStatus WHERE  ID=@ID"
                    }), parms);
        }

        public DataTable GetAdvancePaymentModifyLog(string ID)
        {
            return DatabaseExcetue.ReturnDataTable(("select * from ShopNum1_AdvancePaymentApplyLog where ID=" + ID));
        }

        public DataTable GetAdvancePaymentModifyLog_two(string ID)
        {
            return DatabaseExcetue.ReturnDataTable("select UserMemo from ShopNum1_AdvancePaymentModifyLog where UserMemo='" + ID + "'");
        }
        ///充值购买


        public int OperateMoneyCZGM(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (advancePaymentModifyLog.OperateMoney != 0)
            {
                item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
                sqlList.Add(item);
            }


            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET AdvancePayment=",advancePaymentModifyLog.LastOperateMoney," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
                });
            sqlList.Add(item);

            //item =
            //    string.Concat(new object[]
            //    {
            //        "UPDATE ShopNum1_OrderInfo SET  Offset_pv_b =", advancePaymentModifyLog.Offset_pv_b," WHERE  OrderNumber ='", advancePaymentModifyLog.OrderInfoOrderNumber, "'"
            //    });
            //sqlList.Add(item);



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
        ///  金币（BV）变更日志（充值  2、消费  4、系统 5、转账 6）
        /// </summary>
        /// <param name="advancePaymentModifyLog"></param>
        /// <returns></returns>
        public int OperateMoney(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (advancePaymentModifyLog.OperateMoney != 0)
            {
                item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
                sqlList.Add(item);
            }

            string str1 = ShopNum1_AdvancePaymentHelper.CreateCurrentMemberSql(advancePaymentModifyLog);
            str1 = str1 + "  WHERE  MemLoginID ='" + advancePaymentModifyLog.MemLoginID + "'";
            item =
                string.Concat(new object[]
                {
                    str1
                });
            sqlList.Add(item);

            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_OrderInfo SET  Offset_pv_b =", advancePaymentModifyLog.Offset_pv_b," WHERE  OrderNumber ='", advancePaymentModifyLog.OrderInfoOrderNumber, "'"
                });
            sqlList.Add(item);

            if (advancePaymentModifyLog.TJmemID != null && advancePaymentModifyLog.TJmemID != "")
            {
                item =
                   string.Concat(new object[]
                {
                   "UPDATE ShopNum1_Member SET  Score_pv_a =", advancePaymentModifyLog.Score_pv_a, ",Score_pv_b=",advancePaymentModifyLog.Score_pv_b,
                    ",Score_hv=",advancePaymentModifyLog.TJScore_hv,",Score_pv_cv=",advancePaymentModifyLog.Score_pv_c," WHERE  MemLoginID ='", advancePaymentModifyLog.TJmemID, "'"
                });
                sqlList.Add(item);
            }



            if (advancePaymentModifyLog.XiaoFei_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.YuanYou_hv, ",  ", advancePaymentModifyLog.XiaoFei_hv, ",  ",advancePaymentModifyLog.XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.hv_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
                advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                           "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_a, XiaoFei_pv_a, XiaoFei_Hou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_a, ",  ", advancePaymentModifyLog.XiaoFei_pv_a, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_a, HuoDe_pv_a, Huo_DeHou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_a, ",  ", advancePaymentModifyLog.HuoDe_pv_a, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_pv_b != 0)
            {
                item =
             string.Concat(new object[]
                {
                       "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_b, XiaoFei_pv_b, XiaoFei_Hou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_b, ",  ", advancePaymentModifyLog.XiaoFei_pv_b, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_dv, HuoDe_dv, Huo_DeHou_sdv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_dv, ",  ", advancePaymentModifyLog.HuoDe_dv, ",  ",
                advancePaymentModifyLog.HuoDe_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_cv, DeDao_cv, DeDao_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_cv, ",  ", advancePaymentModifyLog.DeDao_cv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.HuoDe_pv_b != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_b, HuoDe_pv_b, Huo_DeHou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_b, ",  ", advancePaymentModifyLog.HuoDe_pv_b, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_dv, DeDao_dv, DeDao_Hou_dv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_dv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_dv, ",  ", advancePaymentModifyLog.DeDao_dv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.XiaoFei_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_Qian_cv, XiaoFei_cv, XiaoFei_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.XiaoFei_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.XiaoFei_Qian_cv, ",  ", advancePaymentModifyLog.XiaoFei_cv, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
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
        public int OperateMoney_dvrv(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (advancePaymentModifyLog.OperateMoney != 0)
            {
                item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
                sqlList.Add(item);
            }


            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET AdvancePayment=",advancePaymentModifyLog.LastOperateMoney,",Score_hv=",advancePaymentModifyLog.Score_hv,",Score_dv=",advancePaymentModifyLog.Score_dv,",Score_pv_a=",advancePaymentModifyLog.Score_pv_a,",Score_pv_b=",advancePaymentModifyLog.Score_pv_b,",Score_pv_cv=",advancePaymentModifyLog.Score_pv_c,",Score_rv=",advancePaymentModifyLog.Score_rv," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
                });
            sqlList.Add(item);
            if (advancePaymentModifyLog.OrderInfoOrderNumber != null && advancePaymentModifyLog.OrderInfoOrderNumber != "")
            {
                item =
                    string.Concat(new object[]
                {
                    "UPDATE ShopNum1_OrderInfo SET  Offset_pv_b =", advancePaymentModifyLog.Offset_pv_b," WHERE  OrderNumber ='", advancePaymentModifyLog.OrderInfoOrderNumber, "'"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.TJmemID != null && advancePaymentModifyLog.TJmemID != "")
            {
                item =
                   string.Concat(new object[]
                {
                   "UPDATE ShopNum1_Member SET  Score_pv_a =", advancePaymentModifyLog.Score_pv_a, ",Score_pv_b=",advancePaymentModifyLog.Score_pv_b,
                    ",Score_hv=",advancePaymentModifyLog.TJScore_hv,",Score_pv_cv=",advancePaymentModifyLog.Score_pv_c," WHERE  MemLoginID ='", advancePaymentModifyLog.TJmemID, "'"
                });
                sqlList.Add(item);
            }



            if (advancePaymentModifyLog.XiaoFei_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.YuanYou_hv, ",  ", advancePaymentModifyLog.XiaoFei_hv, ",  ",advancePaymentModifyLog.XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.hv_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
                advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                           "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_a, XiaoFei_pv_a, XiaoFei_Hou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_a, ",  ", advancePaymentModifyLog.XiaoFei_pv_a, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_a, HuoDe_pv_a, Huo_DeHou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_a, ",  ", advancePaymentModifyLog.HuoDe_pv_a, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_pv_b != 0)
            {
                item =
             string.Concat(new object[]
                {
                       "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_b, XiaoFei_pv_b, XiaoFei_Hou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_b, ",  ", advancePaymentModifyLog.XiaoFei_pv_b, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_dv, HuoDe_dv, Huo_DeHou_sdv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_dv, ",  ", advancePaymentModifyLog.HuoDe_dv, ",  ",
                advancePaymentModifyLog.HuoDe_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_cv, DeDao_cv, DeDao_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_cv, ",  ", advancePaymentModifyLog.DeDao_cv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.HuoDe_pv_b != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_b, HuoDe_pv_b, Huo_DeHou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_b, ",  ", advancePaymentModifyLog.HuoDe_pv_b, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_dv, DeDao_dv, DeDao_Hou_dv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_dv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_dv, ",  ", advancePaymentModifyLog.DeDao_dv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.XiaoFei_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_Qian_cv, XiaoFei_cv, XiaoFei_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.XiaoFei_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.XiaoFei_Qian_cv, ",  ", advancePaymentModifyLog.XiaoFei_cv, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_rv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_Qian_rv, XiaoFei_rv, XiaoFei_Hou_rv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.XiaoFei_guid_Hou_rv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.XiaoFei_Qian_rv, ",  ", advancePaymentModifyLog.XiaoFei_rv, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_rv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_rv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_rv, DeDao_rv, DeDao_Hou_rv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_rv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.XiaoFei_Qian_rv, ",  ", advancePaymentModifyLog.DeDao_rv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_rv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
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
        public int OperateMoney_TJ(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (advancePaymentModifyLog.OperateMoney != 0)
            {
                item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
                sqlList.Add(item);
            }


            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =", advancePaymentModifyLog.LastOperateMoney,
                    ",Score_hv=",advancePaymentModifyLog.Score_hv,",Score_dv=",advancePaymentModifyLog.Score_dv,",Score_pv_a=",advancePaymentModifyLog.Score_pv_a," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
                });
            sqlList.Add(item);

            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_OrderInfo SET  Offset_pv_b =", advancePaymentModifyLog.Offset_pv_b," WHERE  OrderNumber ='", advancePaymentModifyLog.OrderInfoOrderNumber, "'"
                });
            sqlList.Add(item);

            if (1 == 0)
            {
                item =
                   string.Concat(new object[]
                {
                   "UPDATE ShopNum1_Member SET  Score_pv_a =", advancePaymentModifyLog.Score_pv_a, ",Score_pv_b=",advancePaymentModifyLog.Score_pv_b,
                    ",Score_hv=",advancePaymentModifyLog.TJScore_hv,",Score_pv_cv=",advancePaymentModifyLog.Score_pv_c," WHERE  MemLoginID ='", advancePaymentModifyLog.TJmemID, "'"
                });
                sqlList.Add(item);
            }



            if (advancePaymentModifyLog.TJ_XiaoFei_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.TJ_hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.TJ_YuanYou_hv, ",  ", advancePaymentModifyLog.TJ_XiaoFei_hv, ",  ",advancePaymentModifyLog.TJ_XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.YuanYou_hv, ",  ", advancePaymentModifyLog.XiaoFei_hv, ",  ",advancePaymentModifyLog.XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.hv_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
                advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.TJ_HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.TJ_HuoDe_GUID, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.TJ_HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.TJ_HuoDe_hv, ",  ",
                advancePaymentModifyLog.TJ_Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.XiaoFei_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                           "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_a, XiaoFei_pv_a, XiaoFei_Hou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_a, ",  ", advancePaymentModifyLog.XiaoFei_pv_a, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_a, HuoDe_pv_a, Huo_DeHou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_a, ",  ", advancePaymentModifyLog.HuoDe_pv_a, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_pv_b != 0)
            {
                item =
             string.Concat(new object[]
                {
                       "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_b, XiaoFei_pv_b, XiaoFei_Hou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_b, ",  ", advancePaymentModifyLog.XiaoFei_pv_b, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_dv, HuoDe_dv, Huo_DeHou_sdv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_dv, ",  ", advancePaymentModifyLog.HuoDe_dv, ",  ",
                advancePaymentModifyLog.HuoDe_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_cv, DeDao_cv, DeDao_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_cv, ",  ", advancePaymentModifyLog.DeDao_cv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.HuoDe_pv_b != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_b, HuoDe_pv_b, Huo_DeHou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_b, ",  ", advancePaymentModifyLog.HuoDe_pv_b, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_dv, DeDao_dv, DeDao_Hou_dv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_dv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_dv, ",  ", advancePaymentModifyLog.DeDao_dv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.XiaoFei_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_Qian_cv, XiaoFei_cv, XiaoFei_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.XiaoFei_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.XiaoFei_Qian_cv, ",  ", advancePaymentModifyLog.XiaoFei_cv, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
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
        /// <summary>
        /// 2019郭泽新改的支付方法
        /// </summary>
        /// <param name="advancePaymentModifyLog"></param>
        /// <param name="ordernumber"></param>
        /// <param name="memLoginID"></param>
        /// <param name="shouldPay"></param>
        /// <param name="paytime"></param>
        /// <returns></returns>
        public int OperateMoneyGz2019(decimal myDV, decimal myLNEC, decimal myBV, string ShopCartoryID, string OrderNumber, string memLoginID, decimal shouldPay, decimal shouldPva, System.DateTime paytime)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item =
               string.Concat(new object[]
                {
                    "IF  EXISTS (select * from ShopNum1_OrderInfo where OderStatus=0 and  (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')) UPDATE  ShopNum1_OrderInfo SET OderStatus=1 , PaymentStatus=1, ShipmentStatus= 0,AlreadPayPrice=",shouldPay,",PayTime='",paytime,"' WHERE MemLoginID='",memLoginID,"' and (OrderNumber='",OrderNumber,"' or TradeID='",OrderNumber,"')"
                });
            sqlList.Add(item);

            if (ShopCartoryID == "1" || ShopCartoryID == "3")
            {

                if (shouldPva != 0)
                {
                    item =
                    string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_pv_a =Score_pv_a+", shouldPva,
                    " WHERE  MemLoginID ='", memLoginID, "'"
                });
                    sqlList.Add(item);


                    item =
               string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],HuoDe_YuanYou_pv_a, HuoDe_pv_a, Huo_DeHou_pv_a,[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),1,",myLNEC,",",shouldPva,",",myLNEC+shouldPva,",getdate(),'矿机专区返利','",memLoginID,"','",memLoginID,"',getdate(),0)"
                });
                    sqlList.Add(item);

                }

                item =
                    string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =AdvancePayment-", shouldPay,
                    " WHERE  MemLoginID ='", memLoginID, "'"
                });
                sqlList.Add(item);


                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[CurrentAdvancePayment],[OperateMoney],[LastOperateMoney],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),2,",myBV,",",shouldPay,",",myBV-shouldPay,",getdate(),'购买消费','",memLoginID,"','",memLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);


                
            }
            if (ShopCartoryID == "2")
            {
                item =
                    string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_pv_a =Score_pv_a-", shouldPay,
                    " WHERE  MemLoginID ='", memLoginID, "'"
                    //"UPDATE ShopNum1_Member SET  Score_dv =Score_dv-", shouldPay,
                    //",Score_pv_a=Score_pv_a+",shouldPay," WHERE  MemLoginID ='", memLoginID, "'"
                });
                sqlList.Add(item);

                item =
                string.Concat(new object[]
                {


                    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],XiaoFei_YuanYou_pv_a, XiaoFei_pv_a, XiaoFei_Hou_pv_a,[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),2,",myLNEC,",",shouldPay,",",myLNEC-shouldPay,",getdate(),'购买消费','",memLoginID,"','",memLoginID,"',getdate(),0)"
                });
                sqlList.Add(item);

                //item =
                //string.Concat(new object[]
                //{


                //    "insert into ShopNum1_AdvancePaymentModifyLog([Guid],[OperateType],[HuoDe_YuanYou_dv],[HuoDe_dv],[Huo_DeHou_sdv],[Date],[Memo],[MemLoginID],[CreateUser],[CreateTime],[IsDeleted]) values(Newid(),2,",myDV,",",shouldPay,",",myDV-shouldPay,",getdate(),'购买消费','",memLoginID,"','",memLoginID,"',getdate(),0)"
                //});
                //sqlList.Add(item);
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


        /// <summary>
        /// 记录与状态同步
        /// </summary>
        /// <param name="advancePaymentModifyLog"></param>
        /// <param name="ordernumber"></param>
        /// <param name="memLoginID"></param>
        /// <param name="shouldPay"></param>
        /// <param name="paytime"></param>
        /// <returns></returns>
        public int OperateMoney_TJ20160817(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog, string ordernumber, string memLoginID, decimal shouldPay, System.DateTime paytime)
        {
            string item = string.Empty;
            var sqlList = new List<string>();

            item =
                string.Concat(new object[]
                {
                    "IF  EXISTS (select * from ShopNum1_OrderInfo where OderStatus=0 and  (OrderNumber='",ordernumber,"' or TradeID='",ordernumber,"')) UPDATE  ShopNum1_OrderInfo SET OderStatus=1 , PaymentStatus=1, ShipmentStatus= 0,AlreadPayPrice=",shouldPay,",PayTime='",paytime,"' WHERE MemLoginID='",memLoginID,"' and (OrderNumber='",ordernumber,"' or TradeID='",ordernumber,"')"
                });
            sqlList.Add(item);



            if (advancePaymentModifyLog.OperateMoney != 0)
            {
                item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
                sqlList.Add(item);
            }


            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =", advancePaymentModifyLog.LastOperateMoney,
                    ",Score_hv=",advancePaymentModifyLog.Score_hv,",Score_dv=",advancePaymentModifyLog.Score_dv," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
                });
            sqlList.Add(item);

            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_OrderInfo SET  Offset_pv_b =", advancePaymentModifyLog.Offset_pv_b," WHERE  OrderNumber ='", advancePaymentModifyLog.OrderInfoOrderNumber, "'"
                });
            sqlList.Add(item);

            //if (advancePaymentModifyLog.TJmemID != null && advancePaymentModifyLog.TJmemID != "")
            //{
            //    item =
            //       string.Concat(new object[]
            //    {
            //       "UPDATE ShopNum1_Member SET  Score_pv_a =", advancePaymentModifyLog.Score_pv_a, ",Score_pv_b=",advancePaymentModifyLog.Score_pv_b,
            //        ",Score_hv=",advancePaymentModifyLog.TJScore_hv,",Score_pv_cv=",advancePaymentModifyLog.Score_pv_c," WHERE  MemLoginID ='", advancePaymentModifyLog.TJmemID, "'"
            //    });
            //    sqlList.Add(item);
            //}



            if (advancePaymentModifyLog.TJ_XiaoFei_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.TJ_hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.TJ_YuanYou_hv, ",  ", advancePaymentModifyLog.TJ_XiaoFei_hv, ",  ",advancePaymentModifyLog.TJ_XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                    "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.YuanYou_hv, ",  ", advancePaymentModifyLog.XiaoFei_hv, ",  ",advancePaymentModifyLog.XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.hv_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
                advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.TJ_HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.TJ_HuoDe_GUID, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.TJ_HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.TJ_HuoDe_hv, ",  ",
                advancePaymentModifyLog.TJ_Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.XiaoFei_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                           "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_a, XiaoFei_pv_a, XiaoFei_Hou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_a, ",  ", advancePaymentModifyLog.XiaoFei_pv_a, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_pv_a != 0)
            {
                item =
                  string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_a, HuoDe_pv_a, Huo_DeHou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_a_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_a, ",  ", advancePaymentModifyLog.HuoDe_pv_a, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.XiaoFei_pv_b != 0)
            {
                item =
             string.Concat(new object[]
                {
                       "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_b, XiaoFei_pv_b, XiaoFei_Hou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.YuanYou_pv_b, ",  ", advancePaymentModifyLog.XiaoFei_pv_b, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_dv, HuoDe_dv, Huo_DeHou_sdv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_dv, ",  ", advancePaymentModifyLog.HuoDe_dv, ",  ",
                advancePaymentModifyLog.HuoDe_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.DeDao_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_cv, DeDao_cv, DeDao_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                ,System.Guid.NewGuid(), "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_cv, ",  ", advancePaymentModifyLog.DeDao_cv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.HuoDe_pv_b != 0)
            {
                if (advancePaymentModifyLog.HuoDe_pv_b == 360)
                {
                    item =
                     string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_b, HuoDe_pv_b, Huo_DeHou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_b, ",  ", advancePaymentModifyLog.HuoDe_pv_b, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString("幸福天使积分"), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                    sqlList.Add(item);
                }
                else
                {
                    item =
                     string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_b, HuoDe_pv_b, Huo_DeHou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.pv_b_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_pv_b, ",  ", advancePaymentModifyLog.HuoDe_pv_b, ",  ",
                advancePaymentModifyLog.Huo_DeHou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                    sqlList.Add(item);
                }
            }
            if (advancePaymentModifyLog.DeDao_dv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_dv, DeDao_dv, DeDao_Hou_dv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.DeDao_guid_Hou_dv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.DeDao_Qian_dv, ",  ", advancePaymentModifyLog.DeDao_dv, ",  ",
                advancePaymentModifyLog.DeDao_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
            }

            if (advancePaymentModifyLog.XiaoFei_cv != 0)
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_Qian_cv, XiaoFei_cv, XiaoFei_Hou_cv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.XiaoFei_guid_Hou_cv, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.XiaoFei_Qian_cv, ",  ", advancePaymentModifyLog.XiaoFei_cv, ",  ",
                advancePaymentModifyLog.XiaoFei_Hou_cv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.TJmemID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
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
        public int OperateScore_HV(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();

            if (advancePaymentModifyLog.HuoDe_hv != 0)
            {
                item =
                   string.Concat(new object[]
                {
                            "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.hv_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
                advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
                });
                sqlList.Add(item);
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

        public int OperateMoneytwo(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();

            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
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

        public int OperateMoneyRV_two(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog, string type)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            if (advancePaymentModifyLog.OperateMoney != 0 && type == "AdvancePayment")
            {
                item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted ,UserMemo ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ",  '", advancePaymentModifyLog.LogID, "')"
            });
                sqlList.Add(item);
            }
            if (advancePaymentModifyLog.HuoDe_dv != 0 && type == "Score_dv")
            {
                item =
                 string.Concat(new object[]
                {
                          "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, DeDao_Qian_dv, DeDao_dv, DeDao_Hou_dv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted,UserMemo  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.HuoDe_YuanYou_dv, ",  ", advancePaymentModifyLog.HuoDe_dv, ",  ",
                advancePaymentModifyLog.HuoDe_Hou_dv, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ",  '", advancePaymentModifyLog.LogID, "')"
                });
                sqlList.Add(item);
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
        /// <summary>
        /// 人民币(RV)提现 收入
        /// </summary>
        /// <param name="advancePaymentModifyLog"></param>
        /// <returns></returns>
        public int OperateMoneyRV(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tXiaoFei_YuanYou_rv\t, \tXiaoFei_rv\t, \tXiaoFei_Hou_rv\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_rv =", advancePaymentModifyLog.LastOperateMoney,
                    " ,Score_pv_a=",advancePaymentModifyLog.Score_pv_a,",Score_hv=",advancePaymentModifyLog.Score_hv,",Score_dv=",advancePaymentModifyLog.Score_dv," ,Score_pv_b=",advancePaymentModifyLog.Score_pv_b," ,Score_pv_cv=",advancePaymentModifyLog.Score_pv_c," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
                });
            sqlList.Add(item);
            //item =
            //   string.Concat(new object[]
            //    {
            //        "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_hv, XiaoFei_hv, XiaoFei_Hou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '" , advancePaymentModifyLog.hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",advancePaymentModifyLog.YuanYou_hv, ",  ", advancePaymentModifyLog.XiaoFei_hv, ",  ",advancePaymentModifyLog.XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID, "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",advancePaymentModifyLog.IsDeleted, ")"
            //    });
            //sqlList.Add(item);
            //item =
            //   string.Concat(new object[]
            //    {
            //                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_hv, HuoDe_hv, Huo_DeHou_hv, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
            //    , advancePaymentModifyLog.hv_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
            //    advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
            //    advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
            //    Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
            //    "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
            //    advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
            //    advancePaymentModifyLog.IsDeleted, ")"
            //    });
            //sqlList.Add(item);
            //item =
            //  string.Concat(new object[]
            //    {
            //               "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_a, XiaoFei_pv_a, XiaoFei_Hou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
            //    , advancePaymentModifyLog.pv_a_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
            //    advancePaymentModifyLog.YuanYou_pv_a, ",  ", advancePaymentModifyLog.XiaoFei_pv_a, ",  ",
            //    advancePaymentModifyLog.XiaoFei_Hou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
            //    Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
            //    "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
            //    advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
            //    advancePaymentModifyLog.IsDeleted, ")"
            //    });
            //sqlList.Add(item);
            //item =
            //  string.Concat(new object[]
            //    {
            //              "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, HuoDe_YuanYou_pv_a, HuoDe_pv_a, Huo_DeHou_pv_a, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
            //    , advancePaymentModifyLog.pv_a_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
            //    advancePaymentModifyLog.HuoDe_YuanYou_pv_a, ",  ", advancePaymentModifyLog.HuoDe_pv_a, ",  ",
            //    advancePaymentModifyLog.Huo_DeHou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
            //    Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
            //    "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
            //    advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
            //    advancePaymentModifyLog.IsDeleted, ")"
            //    });
            //sqlList.Add(item);
            //if (advancePaymentModifyLog.XiaoFei_pv_b != 0)
            //{
            //    item =
            // string.Concat(new object[]
            //    {
            //           "INSERT INTO ShopNum1_AdvancePaymentModifyLog( Guid, OperateType, XiaoFei_YuanYou_pv_b, XiaoFei_pv_b, XiaoFei_Hou_pv_b, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
            //    , advancePaymentModifyLog.pv_b_guid_two, "',  ", advancePaymentModifyLog.OperateType, ",  ",
            //    advancePaymentModifyLog.YuanYou_pv_b, ",  ", advancePaymentModifyLog.XiaoFei_pv_b, ",  ",
            //    advancePaymentModifyLog.XiaoFei_Hou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
            //    Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
            //    "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
            //    advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
            //    advancePaymentModifyLog.IsDeleted, ")"
            //    });
            //    sqlList.Add(item);
            //}

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
        /// 冻结资金 收入
        /// </summary>
        /// <param name="advancePaymentModifyLog"></param>
        /// <returns></returns>
        public int OperateMoneyDJ_BV(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =", advancePaymentModifyLog.LastOperateMoney,
                    " WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
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
        /// <summary>
        /// 人民币转账
        /// </summary>
        /// <param name="advancePaymentModifyLog"></param>
        /// <returns></returns>
        public int OperateMoneyRVRVRV(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tXiaoFei_YuanYou_rv\t, \tXiaoFei_rv\t, \tXiaoFei_Hou_rv\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  Score_rv =", advancePaymentModifyLog.LastOperateMoney," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
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
        public int OperateMoneyBV(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        {
            string item = string.Empty;
            var sqlList = new List<string>();
            item = string.Concat(new object[]
            {
                  "INSERT INTO ShopNum1_AdvancePaymentModifyLog( \tGuid\t, \tOperateType\t, \tCurrentAdvancePayment\t, \tOperateMoney\t, \tLastOperateMoney\t, \tDate\t, \tMemo\t, \tMemLoginID\t, \tCreateUser\t, \tCreateTime\t,    OrderNumber ,\tIsDeleted  ) VALUES (  '"
                , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
                advancePaymentModifyLog.CurrentAdvancePayment, ",  ", advancePaymentModifyLog.OperateMoney, ",  ",
                advancePaymentModifyLog.LastOperateMoney, ",  '", advancePaymentModifyLog.Date, "',  '",
                Operator.FilterString(advancePaymentModifyLog.Memo), "',  '", advancePaymentModifyLog.MemLoginID,
                "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
                advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
                advancePaymentModifyLog.IsDeleted, ")"
            });
            sqlList.Add(item);
            item =
                string.Concat(new object[]
                {
                    "UPDATE ShopNum1_Member SET  AdvancePayment =", advancePaymentModifyLog.LastOperateMoney," WHERE  MemLoginID ='", advancePaymentModifyLog.MemLoginID, "'"
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

        //public int OperateKouHv(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        //{
        //    string item = string.Empty;
        //    var sqlList = new List<string>();
        //    item = string.Concat(new object[]
        //    {
        //        "INSERT INTO ShopNum1_AdvancePayment_hv_log( Guid, OperateType, CurrentAdvancePayment, OperateMoney, LastOperateMoney, Date, Memo, MemLoginID, CreateUser, CreateTime,OrderNumber ,IsDeleted  ) VALUES (  '"
        //        , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
        //        advancePaymentModifyLog.YuanYou_hv, ",  ", advancePaymentModifyLog.XiaoFei_hv, ",  ",
        //        advancePaymentModifyLog.XiaoFei_Hou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
        //        Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
        //        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
        //        advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
        //        advancePaymentModifyLog.IsDeleted, ")"
        //    });
        //    sqlList.Add(item);

        //    try
        //    {
        //        DatabaseExcetue.RunTransactionSql(sqlList);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        //public int OperateHuoDeHv(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        //{
        //    string item = string.Empty;
        //    var sqlList = new List<string>();
        //    item = string.Concat(new object[]
        //    {
        //        "INSERT INTO ShopNum1_AdvancePayment_hv_log( Guid, OperateType, CurrentAdvancePayment, OperateMoney, LastOperateMoney, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
        //        , advancePaymentModifyLog.hv_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
        //        advancePaymentModifyLog.HuoDe_YuanYou_hv, ",  ", advancePaymentModifyLog.HuoDe_hv, ",  ",
        //        advancePaymentModifyLog.Huo_DeHou_hv, ",  '", advancePaymentModifyLog.Date, "',  '",
        //        Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
        //        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
        //        advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
        //        advancePaymentModifyLog.IsDeleted, ")"
        //    });
        //    sqlList.Add(item);

        //    try
        //    {
        //        DatabaseExcetue.RunTransactionSql(sqlList);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        //public int OperateKouPv_a(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        //{
        //    string item = string.Empty;
        //    var sqlList = new List<string>();
        //    item = string.Concat(new object[]
        //    {
        //        "INSERT INTO ShopNum1_AdvancePayment_Pv_a_Log( Guid, OperateType, CurrentAdvancePayment, OperateMoney, LastOperateMoney, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
        //        , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
        //        advancePaymentModifyLog.YuanYou_pv_a, ",  ", advancePaymentModifyLog.XiaoFei_pv_a, ",  ",
        //        advancePaymentModifyLog.XiaoFei_Hou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
        //        Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
        //        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
        //        advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
        //        advancePaymentModifyLog.IsDeleted, ")"
        //    });
        //    sqlList.Add(item);

        //    try
        //    {
        //        DatabaseExcetue.RunTransactionSql(sqlList);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        //public int OperateHuoDePv_a(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        //{
        //    string item = string.Empty;
        //    var sqlList = new List<string>();
        //    item = string.Concat(new object[]
        //    {
        //        "INSERT INTO ShopNum1_AdvancePayment_Pv_a_Log( Guid, OperateType, CurrentAdvancePayment, OperateMoney, LastOperateMoney, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
        //        , advancePaymentModifyLog.pv_a_guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
        //        advancePaymentModifyLog.HuoDe_YuanYou_pv_a, ",  ", advancePaymentModifyLog.HuoDe_pv_a, ",  ",
        //        advancePaymentModifyLog.Huo_DeHou_pv_a, ",  '", advancePaymentModifyLog.Date, "',  '",
        //        Operator.FilterString(advancePaymentModifyLog.HuoDe_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
        //        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
        //        advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
        //        advancePaymentModifyLog.IsDeleted, ")"
        //    });
        //    sqlList.Add(item);

        //    try
        //    {
        //        DatabaseExcetue.RunTransactionSql(sqlList);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        //public int OperateKouPv_b(ShopNum1_AdvancePaymentModifyLog advancePaymentModifyLog)
        //{
        //    string item = string.Empty;
        //    var sqlList = new List<string>();
        //    item = string.Concat(new object[]
        //    {
        //        "INSERT INTO ShopNum1_AdvancePayment_pv_b_log( Guid, OperateType, CurrentAdvancePayment, OperateMoney, LastOperateMoney, Date, Memo, MemLoginID, CreateUser, CreateTime,    OrderNumber ,IsDeleted  ) VALUES (  '"
        //        , advancePaymentModifyLog.Guid, "',  ", advancePaymentModifyLog.OperateType, ",  ",
        //        advancePaymentModifyLog.YuanYou_pv_b, ",  ", advancePaymentModifyLog.XiaoFei_pv_b, ",  ",
        //        advancePaymentModifyLog.XiaoFei_Hou_pv_b, ",  '", advancePaymentModifyLog.Date, "',  '",
        //        Operator.FilterString(advancePaymentModifyLog.XiaoFei_Mom), "',  '", advancePaymentModifyLog.MemLoginID,
        //        "',  '", Operator.FilterString(advancePaymentModifyLog.CreateUser), "', '",
        //        advancePaymentModifyLog.CreateTime, "',  '", advancePaymentModifyLog.OrderNumber, "', ",
        //        advancePaymentModifyLog.IsDeleted, ")"
        //    });
        //    sqlList.Add(item);

        //    try
        //    {
        //        DatabaseExcetue.RunTransactionSql(sqlList);
        //        return 1;
        //    }
        //    catch
        //    {
        //        return 0;
        //    }
        //}

        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted)
        {
            string str = string.Empty;
            if (operateType == 1 || operateType == 2 || operateType == 3 || operateType == 4 || operateType == 5 || operateType == 6)
            {
                str =
                "SELECT Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber   FROM ShopNum1_AdvancePaymentModifyLog   WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
            }
            else if (operateType == -1)
            {
                str =
                "SELECT Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber   FROM ShopNum1_AdvancePaymentModifyLog   WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
            }
            else if (operateType == 7)
            {
                str =
                "SELECT  Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
            }
            else if (operateType == 8)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
            }
            else if (operateType == 9)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
            }
            else if (operateType == 10)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
            }
            else if (operateType == 11)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog  WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
            }
            else if (operateType == 12)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
            }
            else if (operateType == 13)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
            }
            else if (operateType == 14)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
            }
            else if (operateType == 15)
            {
                str =
               "SELECT  Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
            }
            else if (operateType == 16)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
            }
            else if (operateType == 17)
            {
                str =
               "SELECT Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
            }

            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID ='" + memLoginID + "'";
            }
            if (operateType == 1 || operateType == 2 || operateType == 3 || operateType == 4 || operateType == 5 || operateType == 6)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, "AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc");
        }

        public DataTable Search(string memLoginID, string date1, string date2, int operateType, int isDeleted, string Memo)
        {
            string str = string.Empty;
            if (operateType == 1 || operateType == 2 || operateType == 3 || operateType == 4 || operateType == 5 || operateType == 6)
            {
                str =
                "SELECT Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber   FROM ShopNum1_AdvancePaymentModifyLog   WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
            }
            else if (operateType == -1)
            {
                str =
                "SELECT Guid,OperateType,CurrentAdvancePayment as money_first,OperateMoney as money_two,LastOperateMoney as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber   FROM ShopNum1_AdvancePaymentModifyLog   WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.OperateMoney <> 0";
            }
            else if (operateType == 7)
            {
                str =
                "SELECT  Guid,OperateType,XiaoFei_YuanYou_pv_a as money_first,XiaoFei_pv_a as money_two,XiaoFei_Hou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_a <> 0";
            }
            else if (operateType == 8)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_pv_a as money_first,HuoDe_pv_a as money_two,Huo_DeHou_pv_a as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_a <> 0";
            }
            else if (operateType == 9)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_YuanYou_hv as money_first,XiaoFei_hv as money_two,XiaoFei_Hou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_hv <> 0";
            }
            else if (operateType == 10)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_hv as money_first,HuoDe_hv as money_two,Huo_DeHou_hv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_hv <> 0";
            }
            else if (operateType == 11)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_YuanYou_pv_b as money_first,XiaoFei_pv_b as money_two,XiaoFei_Hou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog  WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_pv_b <> 0";
            }
            else if (operateType == 12)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_pv_b as money_first,HuoDe_pv_b as money_two,Huo_DeHou_pv_b as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_pv_b <> 0";
            }
            else if (operateType == 13)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_YuanYou_rv as money_first,XiaoFei_rv as money_two,XiaoFei_Hou_rv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_rv <> 0";
            }
            else if (operateType == 14)
            {
                str =
               "SELECT  Guid,OperateType,HuoDe_YuanYou_dv as money_first,HuoDe_dv as money_two,Huo_DeHou_sdv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.HuoDe_dv <> 0";
            }
            else if (operateType == 15)
            {
                str =
               "SELECT  Guid,OperateType,DeDao_Qian_dv as money_first,DeDao_dv as money_two,DeDao_Hou_dv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.DeDao_dv <> 0";
            }
            else if (operateType == 16)
            {
                str =
               "SELECT  Guid,OperateType,XiaoFei_Qian_cv as money_first,XiaoFei_cv as money_two,XiaoFei_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.XiaoFei_cv <> 0";
            }
            else if (operateType == 17)
            {
                str =
               "SELECT Guid,OperateType,DeDao_Qian_cv as money_first,DeDao_cv as money_two,DeDao_Hou_cv as money_free,Date ,Memo,MemLoginID,CreateUser,CreateTime,IsDeleted ,UserMemo ,OrderNumber FROM ShopNum1_AdvancePaymentModifyLog WHERE 0=0 and ShopNum1_AdvancePaymentModifyLog.DeDao_cv <> 0";
            }

            if (Operator.FormatToEmpty(memLoginID) != string.Empty)
            {
                str = str + " AND MemLoginID like '%" + memLoginID + "%'";
            }
            if (Operator.FormatToEmpty(Memo) != string.Empty)
            {
                str = str + " AND Memo like '%" + Memo + "%'";
            }
            if (operateType == 1 || operateType == 2 || operateType == 3 || operateType == 4 || operateType == 5 || operateType == 6)
            {
                str = str + " AND OperateType=" + operateType;
            }
            if (Operator.FormatToEmpty(date1) != string.Empty)
            {
                str = str + " AND Date>='" + Operator.FilterString(date1) + "' ";
            }
            if (Operator.FormatToEmpty(date2) != string.Empty)
            {
                str = str + " AND Date<='" + Operator.FilterString(date2) + "' ";
            }
            if ((isDeleted == 0) || (isDeleted == 1))
            {
                str = string.Concat(new object[] { str, " AND IsDeleted=", isDeleted, " " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "ORDER BY  Date Desc");
        }

        public DataTable SelectAdvPaymentModifyLog_List(CommonPageModel commonModel)
        {
            var paraName = new string[6];
            var paraValue = new string[6];
            paraName[0] = "@columns";
            paraValue[0] = commonModel.Select_YuJu;
            paraName[1] = "@tablename";
            paraValue[1] = commonModel.Tablename;
            paraName[2] = "@condition";
            paraValue[2] = commonModel.Condition;
            paraName[3] = "@ordercolumn";
            paraValue[3] = "Date";
            paraName[4] = "@sortvalue";
            paraValue[4] = "desc";
            paraName[5] = "@resultnum";
            paraValue[5] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public DataTable SelectAdvPaymentModifyLog_ListtWO(CommonPageModel commonModel)
        {
            var paraName = new string[8];
            var paraValue = new string[8];
            paraName[0] = "@columns";
            paraValue[0] = commonModel.Select_YuJu;
            paraName[1] = "@tablename";
            paraValue[1] = commonModel.Tablename;
            paraName[2] = "@condition";
            paraValue[2] = commonModel.Condition;
            paraName[3] = "@ordercolumn";
            paraValue[3] = "Date";
            paraName[4] = "@sortvalue";
            paraValue[4] = "desc";
            paraName[5] = "@resultnum";
            paraValue[5] = commonModel.Resultnum;
            paraName[6] = "@PageSize";
            paraValue[6] = commonModel.PageSize;
            paraName[7] = "@currentpage";
            paraValue[7] = commonModel.Currentpage;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }
        public DataTable SelectOperateMoney(string memberid, string operatetype, string datetime1, string datetime2,
            string ordernumber)
        {
            string strSql = string.Empty;
            strSql = " SELECT * FROM ShopNum1_AdvancePaymentModifyLog ";
            strSql = strSql + " WHERE 1=1 ";
            if (Operator.FormatToEmpty(memberid) != string.Empty)
            {
                strSql = strSql + " AND MemLoginID='" + Operator.FilterString(memberid) + "' ";
            }
            if (Operator.FormatToEmpty(datetime1) != string.Empty)
            {
                strSql = strSql + " AND Date>='" + Operator.FilterString(datetime1) + "' ";
            }
            if (Operator.FormatToEmpty(datetime2) != string.Empty)
            {
                strSql = strSql + " AND Date<='" + Operator.FilterString(datetime2) + "' ";
            }
            if (Operator.FormatToEmpty(ordernumber) != string.Empty)
            {
                strSql = strSql + " AND OrderNumber='" + ordernumber + "'";
            }
            if ((Operator.FormatToEmpty(operatetype) != string.Empty) && (Operator.FormatToEmpty(operatetype) != "-1"))
            {
                strSql = strSql + " AND operatetype='" + operatetype + "'";
            }
            return DatabaseExcetue.ReturnDataTable(strSql);
        }
    }
}