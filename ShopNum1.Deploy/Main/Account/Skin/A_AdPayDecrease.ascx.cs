using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using ShopNum1.Deploy.Api;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_AdPayDecrease : BaseMemberControl
    {
        public string pageid { get; set; }

        public string PageSize { get; set; }

        public string strEndTime { get; set; }

        public string strHidbank { get; set; }

        public string strOrderNum { get; set; }

        public string strSelectBank { get; set; }

        public string strStartTime { get; set; }
        private string Bank;
        private string BankRealName;
        private string BankID;

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Confirm_Click(object sender, EventArgs e)
        {
            var action22 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string modile = action22.GetAdvancePayment(base.MemLoginID).Rows[0]["Mobile"].ToString();
            string IsProtecion = action22.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString();
            if (IsProtecion == "1")
            {
                CheckInfo c = new CheckInfo();
                string cw = c.MemberMobileExec(M_code.Value, modile);
                if (cw != "1")
                {
                    MessageBox.Show("��֤�����");
                }
                else
                {
                    string payPwd =
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(base.MemLoginID);
                    string memberrankguid =
                       ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(base.MemLoginID);

                    if ((payPwd == "") || (payPwd == null))
                    {
                        Page.Response.Redirect("A_PwdSer.aspx");
                    }
                    else
                    {
                        string datemy = Week();
                        Common.Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim());
                        //if (Convert.ToDecimal(txt_Decrease.Value) < 100M)
                        //{
                        //    MessageBox.Show("���׽���С��100��");
                        //}
                         if (Convert.ToDecimal(txt_Decrease.Value) > Convert.ToDecimal(Lab_AdPayment.Text.Trim()))
                        {
                            MessageBox.Show("���ֽ��ܴ�������ң�RV��");
                        }
                        else if (txt_Remark.Value.Length > 300)
                        {
                            MessageBox.Show("��Ա��ע���ܴ���300�ַ�");
                        }
                        else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                        {
                            MessageBox.Show("�˿Ͳ�������");
                        }
                        //else if (Convert.ToInt32(Convert.ToDecimal(txt_Decrease.Value) / 100) * 100 != Convert.ToDecimal(txt_Decrease.Value))
                        //{
                        //    MessageBox.Show("���ֽ������ң�RV������Ϊ����");
                        //}
                        else if (datemy == "������" || datemy == "������")
                        {
                            MessageBox.Show("�ǳ���Ǹ���ǹ����ղ�������Ӵ~");
                        }
                        else
                        {
                            ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            DataTable meminfo = memberaction.GetMemInfo(base.MemLoginID);
                            decimal meminfoRV = Convert.ToDecimal(meminfo.Rows[0]["AdvancePayment"].ToString());
                            var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                            {
                                Guid = Guid.NewGuid(),
                                OperateType = "0", //����
                                CurrentAdvancePayment = meminfoRV,
                                OperateMoney = Convert.ToDecimal(txt_Decrease.Value.Trim()),
                                OperateStatus = 0,
                                Date = DateTime.Now
                            };
                            advancePaymentApplyLog.OrderNumber = "T" + new Order().CreateOrderNumber();
                            advancePaymentApplyLog.Memo = txt_Remark.Value;
                            advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                            advancePaymentApplyLog.PaymentGuid = Guid.Empty;
                            advancePaymentApplyLog.PaymentName = string.Empty;
                            if (hid_BankType.Value == "���´��")
                            {
                                advancePaymentApplyLog.Bank = Bank.Trim();
                                advancePaymentApplyLog.TrueName = BankRealName.Trim();
                                advancePaymentApplyLog.Account = BankID.Trim();
                            }
                            else
                            {
                                advancePaymentApplyLog.Bank = hid_BankType.Value.Trim();
                                advancePaymentApplyLog.TrueName = hid_RealName.Value.Trim();
                                advancePaymentApplyLog.Account = txt_Account.Value.Trim();
                            }
                            advancePaymentApplyLog.IsDeleted = 0;
                            advancePaymentApplyLog.ID = method_2() + 1;

                            RVDecrease(advancePaymentApplyLog);
                        }
                    }
                }
            }
            else
            {

                string payPwd =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(base.MemLoginID);
                string memberrankguid =
                   ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(base.MemLoginID);

                if ((payPwd == "") || (payPwd == null))
                {
                    Page.Response.Redirect("A_PwdSer.aspx");
                }
                else
                {
                    string datemy = Week();
                    Common.Encryption.GetMd5SecondHash(input_PayPwd.Value.Trim());
                    if (Convert.ToDecimal(txt_Decrease.Value) < 100M)
                    {
                        MessageBox.Show("���׽���С��100��");
                    }
                    else if (Convert.ToDecimal(txt_Decrease.Value) > Convert.ToDecimal(Lab_AdPayment.Text.Trim()))
                    {
                        MessageBox.Show("���ֽ��ܴ�������ң�RV��");
                    }
                    else if (txt_Remark.Value.Length > 300)
                    {
                        MessageBox.Show("��Ա��ע���ܴ���300�ַ�");
                    }
                    else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                    {
                        MessageBox.Show("�˿Ͳ�������");
                    }
                    else if (Convert.ToInt32(Convert.ToDecimal(txt_Decrease.Value) / 100) * 100 != Convert.ToDecimal(txt_Decrease.Value))
                    {
                        MessageBox.Show("���ֽ������ң�RV������Ϊ����");
                    }
                    else if (datemy == "������" || datemy == "������")
                    {
                        MessageBox.Show("�ǳ���Ǹ���ǹ����ղ�������Ӵ~");
                    }
                    else
                    {
                        ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable meminfo = memberaction.GetMemInfo(base.MemLoginID);
                        decimal meminfoRV = Convert.ToDecimal(meminfo.Rows[0]["AdvancePayment"].ToString());
                        var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = "0", //����
                            CurrentAdvancePayment = meminfoRV,
                            OperateMoney = Convert.ToDecimal(txt_Decrease.Value.Trim()),
                            OperateStatus = 0,
                            Date = DateTime.Now
                        };
                        advancePaymentApplyLog.OrderNumber = "T" + new Order().CreateOrderNumber();
                        advancePaymentApplyLog.Memo = txt_Remark.Value;
                        advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                        advancePaymentApplyLog.PaymentGuid = Guid.Empty;
                        advancePaymentApplyLog.PaymentName = string.Empty;
                        if (hid_BankType.Value == "���´��")
                        {
                            advancePaymentApplyLog.Bank = Bank.Trim();
                            advancePaymentApplyLog.TrueName = BankRealName.Trim();
                            advancePaymentApplyLog.Account = BankID.Trim();
                        }
                        else
                        {
                            advancePaymentApplyLog.Bank = hid_BankType.Value.Trim();
                            advancePaymentApplyLog.TrueName = hid_RealName.Value.Trim();
                            advancePaymentApplyLog.Account = txt_Account.Value.Trim();
                        }
                        advancePaymentApplyLog.IsDeleted = 0;
                        advancePaymentApplyLog.ID = method_2() + 1;

                        RVDecrease(advancePaymentApplyLog);

                    }
                }
            }

        }

        private void RVDecrease(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog)
        {
            var action3 =
                       (ShopNum1_AdvancePaymentApplyLog_Action)
                           LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            lock (this)
            {
                if (action3.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                {
                    try
                    {
                        var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = 2,
                            CurrentAdvancePayment = advancePaymentApplyLog.CurrentAdvancePayment,
                            OperateMoney = Convert.ToDecimal(txt_Decrease.Value.Trim()),
                            LastOperateMoney =
                                Convert.ToDecimal(advancePaymentApplyLog.CurrentAdvancePayment) -
                                Convert.ToDecimal(txt_Decrease.Value.Trim()),
                            Date = DateTime.Now,
                            Memo = "��Ա���ֿ۳�����ң�RV����" + txt_Decrease.Value.Trim(),
                            MemLoginID = base.MemLoginID,
                            CreateUser = base.MemLoginID,
                            CreateTime = DateTime.Now,
                            IsDeleted = 0,
                            Score_hv = Convert.ToDecimal(Hid_Score_hv.Value.Trim()),
                            Score_pv_a = Convert.ToDecimal(Hid_Score_pv_a.Value.Trim()),
                            Score_dv = Convert.ToDecimal(Hid_Score_dv.Value.Trim()),
                            Score_pv_b = Convert.ToDecimal(Hid_Score_pv_b.Value.Trim()),

                        };

                        ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoneyRV(advancePaymentModifyLog);
                    }
                    catch (Exception)
                    {
                    }
                    GetMemInfo();
                    MessageBox.Show("����ɹ�");
                    Page.Response.Redirect("A_AdPayDecrease.aspx?type=1");
                }
            }
        }


        protected void bv_btn_Click(object sender, EventArgs e)
        {
            var action22 = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string modile = action22.GetAdvancePayment(base.MemLoginID).Rows[0]["Mobile"].ToString();
            string IsProtecion = action22.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString();
            if (IsProtecion == "1")
            {
                CheckInfo c = new CheckInfo();
                string cw = c.MemberMobileExec(M_code1.Value, modile);
                if (cw != "1")
                {
                    MessageBox.Show("��֤�����");
                }
                else
                {
                    string payPwd =
                        ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(base.MemLoginID);
                    string memberrankguid =
                      ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(base.MemLoginID);
                    string MemberType =
                      ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberMemberType(base.MemLoginID);
                    if ((payPwd == "") || (payPwd == null))
                    {
                        Page.Response.Redirect("A_PwdSer.aspx");
                    }
                    else
                    {
                        string datemy = Week();
                        Common.Encryption.GetMd5SecondHash(bv_password.Value.Trim());
                        DataTable txnumtable = action22.selectTXNUM(base.MemLoginID, DateTime.Now.ToShortDateString().ToString(), DateTime.Now.AddDays(1).ToShortDateString().ToString());
                        if (txnumtable.Rows.Count >= 1) 
                        {
                            MessageBox.Show("�Բ����������Ѿ�������Ӵ��ÿ���û�ÿ��ֻ������һ�Σ�");
                        }
                        else if (Convert.ToDecimal(bvScore_bv.Value) < 1M)
                        {
                            MessageBox.Show("���׽���Ϊ����߸�����");
                        }
                         else if (Convert.ToDecimal(bvScore_bv.Value) > Convert.ToDecimal(Score_bv.Text.Trim()))
                        {
                            MessageBox.Show("���ֽ��ܴ��������");
                        }
                        else if (bv_Rmeal.Value.Length > 300)
                        {
                            MessageBox.Show("��Ա��ע���ܴ���300�ַ�");
                        }
                        else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                        {
                            MessageBox.Show("�˿Ͳ�������");
                        }
                        //else if (Convert.ToInt32(Convert.ToDecimal(bvScore_bv.Value) / 100) * 100 != Convert.ToDecimal(bvScore_bv.Value))
                        //{
                        //    MessageBox.Show("���ֽ������ң�RV������Ϊ����");
                        //}
                        else if (datemy == "������" || datemy == "������")
                        {
                            MessageBox.Show("�ǳ���Ǹ���ǹ����ղ�������Ӵ~");
                        }
                        //else if (MemberType != "2")
                        //{
                        //    MessageBox.Show("�ǳ���Ǹ���ǵ����û���������Ӵ~");
                        //}
                        else
                        {
                            ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                            DataTable meminfo = memberaction.GetMemInfo(base.MemLoginID);
                            decimal meminfoBV = Convert.ToDecimal(meminfo.Rows[0]["AdvancePayment"].ToString());
                            var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                            {
                                Guid = Guid.NewGuid(),
                                OperateType = "0", //����
                                CurrentAdvancePayment = meminfoBV,
                                OperateMoney = Convert.ToDecimal(bvScore_bv.Value.Trim()),
                                OperateStatus = 0,
                                Date = DateTime.Now
                            };
                            advancePaymentApplyLog.OrderNumber = "J" + new Order().CreateOrderNumber();
                            advancePaymentApplyLog.Memo = bv_Rmeal.Value;
                            advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                            advancePaymentApplyLog.PaymentGuid = Guid.Empty;
                            advancePaymentApplyLog.PaymentName = string.Empty;
                            #region 20151110
                            //advancePaymentApplyLog.Bank = Bank.Trim();
                            //advancePaymentApplyLog.TrueName = BankRealName.Trim();
                            //advancePaymentApplyLog.Account = BankID.Trim();

                            advancePaymentApplyLog.Bank = bv_Bank.Value.Trim();
                            advancePaymentApplyLog.TrueName = bv_RealName.Value.Trim();
                            advancePaymentApplyLog.Account = bv_BankID.Value.Trim();
                            #endregion







                            advancePaymentApplyLog.IsDeleted = 0;
                            advancePaymentApplyLog.ID = method_2() + 1;



                            //action3.ApplyOperateMoney(advancePaymentApplyLog);
                            BVDecrease(advancePaymentApplyLog);



                        }
                    }
                }
            }
            else
            {

                string payPwd =
                    ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetPayPwd(base.MemLoginID);
                string memberrankguid =
                  ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberRankGuid(base.MemLoginID);
                string MemberType =
                      ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).GetMberMemberType(base.MemLoginID);
                if ((payPwd == "") || (payPwd == null))
                {
                    Page.Response.Redirect("A_PwdSer.aspx");
                }
                else
                {
                    string datemy = Week();
                    Common.Encryption.GetMd5SecondHash(bv_password.Value.Trim());
                    //if (Convert.ToDecimal(bvScore_bv.Value) < 100M)
                    //{
                    //    MessageBox.Show("���׽���Ϊ����߸�����");
                    //    getIsProtecion();
                        
                    //}
                    DataTable txnumtable = action22.selectTXNUM(base.MemLoginID, DateTime.Now.ToShortDateString().ToString(), DateTime.Now.AddDays(1).ToShortDateString().ToString());
                    if (txnumtable.Rows.Count >= 1)
                    {
                        MessageBox.Show("�Բ����������Ѿ�������Ӵ��ÿ���û�ÿ��ֻ������һ�Σ�");
                        getIsProtecion();
                    }
                    else if (Convert.ToDecimal(bvScore_bv.Value) < 1M)
                    {
                        MessageBox.Show("���׽���Ϊ����߸�����");
                        getIsProtecion();

                    }
                     else if (Convert.ToDecimal(bvScore_bv.Value) > Convert.ToDecimal(Score_bv.Text.Trim()))
                    {
                        MessageBox.Show("���ֽ��ܴ��������");
                        getIsProtecion();
                    }
                    else if (bv_Rmeal.Value.Length > 300)
                    {
                        MessageBox.Show("��Ա��ע���ܴ���300�ַ�");
                        getIsProtecion();
                    }
                    else if (memberrankguid.ToUpper() == "197B6B51-3EB3-452E-BD03-D560577A34D2".ToUpper())
                    {
                        MessageBox.Show("�˿Ͳ�������");
                        getIsProtecion();
                    }
                    //else if (Convert.ToInt32(Convert.ToDecimal(bvScore_bv.Value) / 100) * 100 != Convert.ToDecimal(bvScore_bv.Value))
                    //{
                    //    MessageBox.Show("���ֽ������ң�RV������Ϊ����");
                    //    getIsProtecion();
                    //}
                    else if (datemy == "������" || datemy == "������")
                    {
                        MessageBox.Show("�ǳ���Ǹ���ǹ����ղ�������Ӵ~");
                        getIsProtecion();
                    }
                    //else if (MemberType != "2")
                    //{
                    //    MessageBox.Show("�ǳ���Ǹ���ǵ����û���������Ӵ~");
                    //    getIsProtecion();
                    //}
                    else
                    {
                        ShopNum1_Member_Action memberaction = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                        DataTable meminfo = memberaction.GetMemInfo(base.MemLoginID);
                        decimal meminfoBV = Convert.ToDecimal(meminfo.Rows[0]["AdvancePayment"].ToString());
                        var advancePaymentApplyLog = new ShopNum1_AdvancePaymentApplyLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = "0", //����
                            CurrentAdvancePayment = meminfoBV,
                            OperateMoney = Convert.ToDecimal(bvScore_bv.Value.Trim()),
                            OperateStatus = 0,
                            Date = DateTime.Now
                        };
                        advancePaymentApplyLog.OrderNumber = "J" + new Order().CreateOrderNumber();
                        advancePaymentApplyLog.Memo = bv_Rmeal.Value;
                        advancePaymentApplyLog.MemLoginID = base.MemLoginID;
                        advancePaymentApplyLog.PaymentGuid = Guid.Empty;
                        advancePaymentApplyLog.PaymentName = string.Empty;
                        #region 20151110
                        //advancePaymentApplyLog.Bank = Bank.Trim();
                        //advancePaymentApplyLog.TrueName = BankRealName.Trim();
                        //advancePaymentApplyLog.Account = BankID.Trim();

                        advancePaymentApplyLog.Bank = bv_Bank.Value.Trim();
                        advancePaymentApplyLog.TrueName = bv_RealName.Value.Trim();
                        advancePaymentApplyLog.Account = bv_BankID.Value.Trim();
                        #endregion







                        advancePaymentApplyLog.IsDeleted = 0;
                        advancePaymentApplyLog.ID = method_2() + 1;



                        //action3.ApplyOperateMoney(advancePaymentApplyLog);
                        BVDecrease(advancePaymentApplyLog);




                    }
                }
            }

        }

        private void BVDecrease(ShopNum1_AdvancePaymentApplyLog advancePaymentApplyLog)
        {
            var action3 =
                        (ShopNum1_AdvancePaymentApplyLog_Action)
                            LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            lock (this)
            {
                if (action3.ApplyOperateMoney(advancePaymentApplyLog) > 0)
                {
                    try
                    {

                        var advancePaymentModifyLog = new ShopNum1_AdvancePaymentModifyLog
                        {
                            Guid = Guid.NewGuid(),
                            OperateType = 2,
                            CurrentAdvancePayment = advancePaymentApplyLog.CurrentAdvancePayment,
                            OperateMoney = Convert.ToDecimal(bvScore_bv.Value.Trim()),
                            LastOperateMoney =
                                Convert.ToDecimal(advancePaymentApplyLog.CurrentAdvancePayment) -
                                Convert.ToDecimal(bvScore_bv.Value.Trim()),
                            Date = DateTime.Now,
                            Memo = "��Ա���ֿ۳�����ң�" + bvScore_bv.Value.Trim(),
                            MemLoginID = base.MemLoginID,
                            CreateUser = base.MemLoginID,
                            CreateTime = DateTime.Now,
                            IsDeleted = 0,


                        };

                        ((ShopNum1_AdvancePaymentModifyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentModifyLog_Action()).OperateMoneyBV(advancePaymentModifyLog);
                    }

                    catch (Exception)
                    {
                    }
                    GetMemInfo();
                    MessageBox.Show("����ɹ�");
                    Page.Response.Redirect("A_AdPayDecrease.aspx?type=1");
                }
            }
        }

        protected void Btn_Select_Click(object sender, EventArgs e)
        {
            strStartTime = txt_StartTime.Value.Trim();
            strEndTime = txt_EndTime.Value.Trim();
            strOrderNum = txt_OrderNum.Value.Trim();
            method_0();
            Page.Response.Redirect("A_AdPayDecrease.aspx?Type=1&pageid=1&StartTime=" + strStartTime + "&EndTime=" +
                                   strEndTime + "&OrderNum=" + strOrderNum);
        }

        protected void GetMemInfo()
        {
            DataTable table =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchByMemLoginID(
                    base.MemLoginID);
            try
            {
                if (table.Rows.Count > 0)
                {
                    bvMemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
                    Score_bv.Text = table.Rows[0]["AdvancePayment"].ToString();
                    Lab_MemLoginID.Text = table.Rows[0]["MemLoginID"].ToString();
                    Lab_AdPayment.Text = table.Rows[0]["Score_rv"].ToString();
                    hid_RealName.Value = table.Rows[0]["RealName"].ToString();
                    Hid_Score_pv_a.Value = table.Rows[0]["Score_pv_a"].ToString();
                    Hid_Score_hv.Value = table.Rows[0]["Score_hv"].ToString();
                    Hid_Score_pv_b.Value = table.Rows[0]["Score_pv_b"].ToString();
                    Hid_Score_dv.Value = table.Rows[0]["Score_dv"].ToString();
                }
            }
            catch
            {
            }
        }

        protected void GetBank()
        {
            DataTable table =
                ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action()).SearchMembertwo(
                    base.MemLoginID);
            string MemNO = table.Rows[0]["MemLoginNO"].ToString();
            TJAPIzl.MemberServiceSoapClient mms = new TJAPIzl.MemberServiceSoapClient();
            string md5_one = ShopNum1.Common.MD5JiaMi.MyMd5JiaMi;
            string privateKey_two = "Number=" + MemNO.ToUpper() + md5_one;
            string md5Check_two = ShopNum1.Common.MD5JiaMi.Md5JiaMi(privateKey_two);
            //string returnResult = mms.GetMemberInfo(MemNO.ToUpper(), md5Check_two);
            //if (returnResult == "�ܳ���֤ʧ��!" || returnResult == "��Ա��Ų�����!" || returnResult == "��ѯʧ��!")
            //{
            Bank = table.Rows[0]["Bank"].ToString() + "," + table.Rows[0]["BankAddress"].ToString();
            txt_Bank.Value = table.Rows[0]["Bank"].ToString() + "," + table.Rows[0]["BankAddress"].ToString();
            BankRealName = table.Rows[0]["RealName"].ToString();
            txt_RealName.Value = table.Rows[0]["RealName"].ToString();
            BankID = table.Rows[0]["BankNo"].ToString();
            txt_ConfirmBankID.Value = table.Rows[0]["BankNo"].ToString();
            bv_Bank.Value = table.Rows[0]["Bank"].ToString() + "," + table.Rows[0]["BankAddress"].ToString();
            bv_RealName.Value = table.Rows[0]["RealName"].ToString();
            bv_BankID.Value = table.Rows[0]["BankNo"].ToString();



        }

        public static string GetState(string type)
        {
            if (type == "0")
            {
                return "δ����";
            }
            if (type == "1")
            {
                return "�����";
            }
            if (type == "2")
            {
                return "�ܾ�����";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pageid = (Common.Common.ReqStr("PageID") == "") ? "1" : Common.Common.ReqStr("PageID");
            GetMemInfo();
            GetBank();


            if (!Page.IsPostBack)
            {

                strStartTime = (Common.Common.ReqStr("StartTime") == "") ? "" : Common.Common.ReqStr("StartTime");
                strEndTime = (Common.Common.ReqStr("EndTime") == "") ? "" : Common.Common.ReqStr("EndTime");
                strOrderNum = (Common.Common.ReqStr("OrderNum") == "") ? "" : Common.Common.ReqStr("OrderNum");
                txt_StartTime.Value = strStartTime;
                txt_EndTime.Value = strEndTime;
                txt_OrderNum.Value = strOrderNum;
                hidMemberType.Value = Common.Common.GetNameById("membertype", "shopnum1_member",
                    " And MemloginId='" + base.MemLoginID + "'");
                var action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
                nextmobile.Text = action.GetAdvancePayment(base.MemLoginID).Rows[0]["Mobile"].ToString();
                nextmobile1.Text = action.GetAdvancePayment(base.MemLoginID).Rows[0]["Mobile"].ToString();


                string IsProtecion = action.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString();
                if (IsProtecion == "0")
                {
                    tr12211.Visible = false;
                    tr122211.Visible = false;
                    tr122113.Visible = false;
                    tr1221.Visible = false;
                    tr12221.Visible = false;
                    tr122221.Visible = false;
                }
                else
                {
                    tr12211.Visible = true;
                    tr122211.Visible = true;
                    tr122113.Visible = true;
                    tr1221.Visible = true;
                    tr12221.Visible = true;
                    tr122221.Visible = true;
                }

                method_0();
            }
        }

        protected void getIsProtecion() 
        {
            ShopNum1_Member_Action action = (ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action();
            string IsProtecion = action.SelectIsProtecionByMemerberloginID(base.MemLoginID).Rows[0]["IsProtecion"].ToString();
            if (IsProtecion == "0")
            {
                tr12211.Visible = false;
                tr122211.Visible = false;
                tr122113.Visible = false;
                tr1221.Visible = false;
                tr12221.Visible = false;
                tr122221.Visible = false;
            }
            else
            {
                tr12211.Visible = true;
                tr122211.Visible = true;
                tr122113.Visible = true;
                tr1221.Visible = true;
                tr12221.Visible = true;
                tr122221.Visible = true;
            }
        }

        protected void method_0()
        {
            string text1 = hid_SelectBank.Value;
            var action =
                (ShopNum1_AdvancePaymentApplyLog_Action)LogicFactory.CreateShopNum1_AdvancePaymentApplyLog_Action();
            new DataTable();
            try
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(Lab_MemLoginID.Text.Trim()))
                {
                    str = str + "  AND  MemLoginID=  '" + base.MemLoginID + "'  ";
                    str = method_1(str);
                }
                var commonModel = new CommonPageModel
                {
                    Condition = "  AND   1=1   " + str + "     AND  IsDeleted=0      ",
                    Currentpage = pageid,
                    Resultnum = "0",
                    Tablename = "ShopNum1_AdvancePaymentApplyLog",
                    PageSize = PageSize
                };
                DataTable table2 = action.SelectAdvPayment_List(commonModel);
                var pl = new PageList1
                {
                    PageSize = Convert.ToInt32(PageSize),
                    PageID = Convert.ToInt32(pageid)
                };
                if ((table2 != null) && (table2.Rows.Count > 0))
                {
                    pl.RecordCount = Convert.ToInt32(table2.Rows[0][0]);
                }
                else
                {
                    pl.RecordCount = 0;
                }
                pageDiv.InnerHtml =
                    new PageListBll("main/Account/A_AdPayDecrease.aspx", true).GetPageListNew(pl);
                commonModel.Resultnum = "1";
                DataTable table = action.SelectAdvPayment_List(commonModel);
                string str3 = Common.Common.GetNameById("SUM(cast(OperateMoney as float))",
                    "ShopNum1_AdvancePaymentApplyLog", str);
                if (!string.IsNullOrEmpty(str3))
                {
                    lab_PayDecrease.Text = str3;
                }
                else
                {
                    lab_PayDecrease.Text = "0";
                }
                string str2 = Common.Common.GetNameById("COUNT(Guid)", "ShopNum1_AdvancePaymentApplyLog", str);
                if (!string.IsNullOrEmpty(str2))
                {
                    lab_PayNum.Text = str2;
                }
                else
                {
                    lab_PayNum.Text = "0";
                }
                if (table.Rows.Count > 0)
                {
                    Rep_NoValue.Visible = false;
                    Rep_PayDecrease.DataSource = table.DefaultView;
                    Rep_PayDecrease.DataBind();
                }
                else
                {
                    Rep_NoValue.Visible = true;
                    var table3 = new DataTable();
                    table3.Columns.Add("NoValue", typeof(string));
                    DataRow row = table3.NewRow();
                    row["NoValue"] = "������Ϣ";
                    table3.Rows.Add(row);
                    Rep_NoValue.DataSource = table3;
                    Rep_NoValue.DataBind();
                }
            }
            catch
            {
            }
        }

        private string method_1(string string_8)
        {
            if (Operator.FormatToEmpty(strStartTime) != string.Empty)
            {
                string_8 = string_8 + " AND Date>='" + Operator.FilterString(strStartTime) + "' ";
            }
            if (Operator.FormatToEmpty(strEndTime) != string.Empty)
            {
                string_8 = string_8 + " AND Date<(SELECT CONVERT(varchar(11),dateadd(day,1,' " +
                           Operator.FilterString(strEndTime) + "'),120)  as  a)  ";
            }
            if (Operator.FormatToEmpty(strOrderNum) != string.Empty)
            {
                string_8 = string_8 + " AND OrderNumber='" + strOrderNum + "'";
            }
            string_8 = string_8 + "AND  OperateType=0  ";
            return string_8;
        }

        private int method_2()
        {
            try
            {
                return Common.Common.ReturnMaxID("ID", "MemLoginID", base.MemLoginID, "ShopNum1_AdvancePaymentApplyLog");
            }
            catch
            {
                return 0;
            }
        }


        public string Week()
        {
            string[] weekdays = { "������", "����һ", "���ڶ�", "������", "������", "������", "������" };
            string week = weekdays[Convert.ToInt32(DateTime.Now.DayOfWeek)];

            return week;
        }
    }
}

