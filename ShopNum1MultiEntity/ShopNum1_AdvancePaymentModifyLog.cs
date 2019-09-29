using System;

////using System.Data.Linq.Mapping;

namespace ShopNum1MultiEntity
{
    ////[Table(Name = "dbo.ShopNum1_AdvancePaymentModifyLog")]
    public class ShopNum1_AdvancePaymentModifyLog
    {
        public const decimal defaultValue = 0.000001m;
        private DateTime dateTime_0;
        private DateTime? dateTime_1;
        private decimal decimal_0;
        private decimal decimal_1;
        private decimal decimal_2 = defaultValue;
        private Guid? guid_0;
        private int int_0;
        private int? int_1;
        private string string_0;
        private string string_1;
        private string string_2;
        private string string_3;
        private string string_4;
        //2015//07/24
        private string id_TJ;
        private decimal Score_TJScore_hv;
        private decimal Score_Score_hv = defaultValue;
        private decimal Score_Score_pv_a = defaultValue;
        private decimal Score_Score_pv_b = defaultValue;
        private decimal Score_Score_pv_c = defaultValue;
        private decimal Score_Score_dv = defaultValue;
        private decimal Score_Score_cv;
        private decimal Score_Score_max_hv;
        private decimal Score_Score_rv;
        //消费的 积分 红包`
        private decimal Score_XiaoFei_hv;
        private decimal Score_XiaoFei_pv_a;
        private decimal Score_XiaoFei_pv_b;
        //消费原有 积分 红包
        private decimal Score_YuanYou_hv;
        private decimal Score_YuanYou_pv_a;
        private decimal Score_YuanYou_pv_b;
        private string Score_XiaoFei_Mom;

        //最后获得（消费后）
        private decimal Score_XiaoFei_Hou_hv;
        private decimal Score_XiaoFei_Hou_pv_a;
        private decimal Score_XiaoFei_Hou_pv_b;

        //获得原有
        private decimal Score_HuoDe_YuanYou_hv;
        private decimal Score_HuoDe_YuanYou_pv_a;
        private decimal Score_HuoDe_YuanYou_pv_b;
        //获得 积分 红包
        private decimal Score_HuoDe_hv;
        private decimal Score_HuoDe_pv_a;
        private decimal Score_HuoDe_pv_b;
        private string Score_HuoDe_Mom;
        //获得后 积分 红包
        private decimal Score_Huo_DeHou_hv;
        private decimal Score_Huo_DeHou_pv_a;
        private decimal Score_Huo_DeHou_pv_b;

        //他们的guid
        private Guid Score_hv_guid;
        private Guid Score_pv_a_guid;
        private Guid Score_pv_b_guid;
        private Guid Score_hv_guid_two;
        private Guid Score_pv_a_guid_two;
        private Guid Score_pv_b_guid_two;

        //消费重消币
        private decimal Score_HuoDe_YuanYou_dv;
        private decimal Score_HuoDe_dv;
        private decimal Score_HuoDe_Hou_dv;
        private Guid Score_HuoDe_dv_Guid;
        private decimal Score_Offset_pv_b;
        private string Score_OrderInfoOrderNumber;

        private decimal Score_GetScore_dv;
        private decimal Score_GetScore_pv_b;
        private decimal Score_GetScore_hv;
        private decimal Score_GetScore_pv_a;
        private decimal Score_GetPaymentPrice;
        private decimal Score_Getcore_pv_cv;


        //获得重消币
        private decimal Score_DeDao_Qian_dv;
        private decimal Score_DeDao_dv;
        private decimal Score_DeDao_Hou_dv;
        private Guid Score_DeDao_guid_Hou_dv;
       
        //获得CV
        private decimal Score_DeDao_Qian_cv;
        private decimal Score_DeDao_cv;
        private decimal Score_DeDao_Hou_cv;
        private Guid Score_DeDao_guid_Hou_cv;


        //消费CV
        private decimal Score_XiaoFei_Qian_cv;
        private decimal Score_XiaoFei_cv;
        private decimal Score_XiaoFei_Hou_cv;
        private Guid Score_XiaoFei_guid_Hou_cv;
        private string Score_logID;  



        //推荐人消费pvb
        private decimal Score_TJ_HuoDe_hv;
        private decimal Score_TJ_Huo_DeHou_hv;
        private decimal Score_TJ_HuoDe_YuanYou_hv;
        private Guid Score_TJ_HuoDe_GUID;


        //推荐人消费pvb
        private decimal Score_TJ_YuanYou_hv;
        private decimal Score_TJ_XiaoFei_hv;
        private decimal Score_TJ_XiaoFei_Hou_hv;
        private Guid Score_TJ_hv_guid;
        //消费RV
        private decimal Score_XiaoFei_Qian_rv;
        private decimal Score_XiaoFei_rv;
        private decimal Score_XiaoFei_Hou_rv;
        private Guid Score_XiaoFei_guid_Hou_rv;

        //获得RV
        private decimal Score_DeDao_Qian_rv;
        private decimal Score_DeDao_rv;
        private decimal Score_DeDao_Hou_rv;
        private Guid Score_DeDao_guid_Hou_rv;


        //获得DJ_BV
        private decimal Score_HuoDe_YuanYou_DJ_BV;
        private decimal Score_HuoDe_DJ_BV;
        private decimal Score_Huo_DeHou_DJ_BV;
        private Guid Score_HuoDe_DJ_BV_guid;


        public decimal Huo_DeHou_DJ_BV
        {
            get { return Score_Huo_DeHou_DJ_BV; }
            set
            {
                if (Score_Huo_DeHou_DJ_BV != value)
                {
                    Score_Huo_DeHou_DJ_BV = value;
                }
            }
        }

        public decimal HuoDe_DJ_BV
        {
            get { return Score_HuoDe_DJ_BV; }
            set
            {
                if (Score_HuoDe_DJ_BV != value)
                {
                    Score_HuoDe_DJ_BV = value;
                }
            }
        }

        public decimal HuoDe_YuanYou_DJ_BV
        {
            get { return Score_HuoDe_YuanYou_DJ_BV; }
            set
            {
                if (Score_HuoDe_YuanYou_DJ_BV != value)
                {
                    Score_HuoDe_YuanYou_DJ_BV = value;
                }
            }
        }

        public Guid HuoDe_DJ_BV_guid
        {
            get { return Score_HuoDe_DJ_BV_guid; }
            set
            {
                if (Score_HuoDe_DJ_BV_guid != value)
                {
                    Score_HuoDe_DJ_BV_guid = value;
                }
            }
        }

        public Guid DeDao_guid_Hou_rv
        {
            get { return Score_DeDao_guid_Hou_rv; }
            set
            {
                if (Score_DeDao_guid_Hou_rv != value)
                {
                    Score_DeDao_guid_Hou_rv = value;
                }
            }
        }
        public Guid XiaoFei_guid_Hou_rv
        {
            get { return Score_XiaoFei_guid_Hou_rv; }
            set
            {
                if (Score_XiaoFei_guid_Hou_rv != value)
                {
                    Score_XiaoFei_guid_Hou_rv = value;
                }
            }
        }

        public decimal XiaoFei_Qian_rv
        {
            get { return Score_XiaoFei_Qian_rv; }
            set
            {
                if (Score_XiaoFei_Qian_rv != value)
                {
                    Score_XiaoFei_Qian_rv = value;
                }
            }
        }
        public decimal XiaoFei_rv
        {
            get { return Score_XiaoFei_rv; }
            set
            {
                if (Score_XiaoFei_rv != value)
                {
                    Score_XiaoFei_rv = value;
                }
            }
        }
        public decimal XiaoFei_Hou_rv
        {
            get { return Score_XiaoFei_Hou_rv; }
            set
            {
                if (Score_XiaoFei_Hou_rv != value)
                {
                    Score_XiaoFei_Hou_rv = value;
                }
            }
        }
        public decimal DeDao_Qian_rv
        {
            get { return Score_DeDao_Qian_rv; }
            set
            {
                if (Score_DeDao_Qian_rv != value)
                {
                    Score_DeDao_Qian_rv = value;
                }
            }
        }
        public decimal DeDao_rv
        {
            get { return Score_DeDao_rv; }
            set
            {
                if (Score_DeDao_rv != value)
                {
                    Score_DeDao_rv = value;
                }
            }
        }
        public decimal DeDao_Hou_rv
        {
            get { return Score_DeDao_Hou_rv; }
            set
            {
                if (Score_DeDao_Hou_rv != value)
                {
                    Score_DeDao_Hou_rv = value;
                }
            }
        }

        public decimal TJ_XiaoFei_Hou_hv
        {
            get { return Score_TJ_XiaoFei_Hou_hv; }
            set
            {
                if (Score_TJ_XiaoFei_Hou_hv != value)
                {
                    Score_TJ_XiaoFei_Hou_hv = value;
                }
            }
        }

        public decimal TJ_XiaoFei_hv
        {
            get { return Score_TJ_XiaoFei_hv; }
            set
            {
                if (Score_TJ_XiaoFei_hv != value)
                {
                    Score_TJ_XiaoFei_hv = value;
                }
            }
        }

        public decimal TJ_YuanYou_hv
        {
            get { return Score_TJ_YuanYou_hv; }
            set
            {
                if (Score_TJ_YuanYou_hv != value)
                {
                    Score_TJ_YuanYou_hv = value;
                }
            }
        }

        public Guid TJ_hv_guid
        {
            get { return Score_TJ_hv_guid; }
            set
            {
                if (Score_TJ_hv_guid != value)
                {
                    Score_TJ_hv_guid = value;
                }
            }
        }

        public Guid TJ_HuoDe_GUID
        {
            get { return Score_TJ_HuoDe_GUID; }
            set
            {
                if (Score_TJ_HuoDe_GUID != value)
                {
                    Score_TJ_HuoDe_GUID = value;
                }
            }
        }

        public decimal TJ_HuoDe_YuanYou_hv
        {
            get { return Score_TJ_HuoDe_YuanYou_hv; }
            set
            {
                if (Score_TJ_HuoDe_YuanYou_hv != value)
                {
                    Score_TJ_HuoDe_YuanYou_hv = value;
                }
            }
        }

        public decimal TJ_Huo_DeHou_hv
        {
            get { return Score_TJ_Huo_DeHou_hv; }
            set
            {
                if (Score_TJ_Huo_DeHou_hv != value)
                {
                    Score_TJ_Huo_DeHou_hv = value;
                }
            }
        }

        public decimal TJ_HuoDe_hv
        {
            get { return Score_TJ_HuoDe_hv; }
            set
            {
                if (Score_TJ_HuoDe_hv != value)
                {
                    Score_TJ_HuoDe_hv = value;
                }
            }
        }

        public Guid DeDao_guid_Hou_cv
        {
            get { return Score_DeDao_guid_Hou_cv; }
            set
            {
                if (Score_DeDao_guid_Hou_cv != value)
                {
                    Score_DeDao_guid_Hou_cv = value;
                }
            }
        }

        public decimal TJScore_hv
        {
            get { return Score_TJScore_hv; }
            set
            {
                if (Score_TJScore_hv != value)
                {
                    Score_TJScore_hv = value;
                }
            }
        }

        public string TJmemID
        {
            get { return id_TJ; }
            set
            {
                if (id_TJ != value)
                {
                    id_TJ = value;
                }
            }
        }

        public decimal DeDao_Hou_cv
        {
            get { return Score_DeDao_Hou_cv; }
            set
            {
                if (Score_DeDao_Hou_cv != value)
                {
                    Score_DeDao_Hou_cv = value;
                }
            }
        }

        public decimal DeDao_cv
        {
            get { return Score_DeDao_cv; }
            set
            {
                if (Score_DeDao_cv != value)
                {
                    Score_DeDao_cv = value;
                }
            }
        }

        public Guid XiaoFei_guid_Hou_cv
        {
            get { return Score_XiaoFei_guid_Hou_cv; }
            set
            {
                if (Score_XiaoFei_guid_Hou_cv != value)
                {
                    Score_XiaoFei_guid_Hou_cv = value;
                }
            }
        }

        public decimal XiaoFei_Hou_cv
        {
            get { return Score_XiaoFei_Hou_cv; }
            set
            {
                if (Score_XiaoFei_Hou_cv != value)
                {
                    Score_XiaoFei_Hou_cv = value;
                }
            }
        }

        public decimal XiaoFei_cv
        {
            get { return Score_XiaoFei_cv; }
            set
            {
                if (Score_XiaoFei_cv != value)
                {
                    Score_XiaoFei_cv = value;
                }
            }
        }

        public decimal XiaoFei_Qian_cv
        {
            get { return Score_XiaoFei_Qian_cv; }
            set
            {
                if (Score_XiaoFei_Qian_cv != value)
                {
                    Score_XiaoFei_Qian_cv = value;
                }
            }
        }

        //public decimal DeDao_guid_Hou_dv
        //{
        //    get { return Score_DeDao_guid_Hou_dv; }
        //    set
        //    {
        //        if (Score_DeDao_guid_Hou_dv != value)
        //        {
        //            Score_DeDao_guid_Hou_dv = value;
        //        }
        //    }
        //}

        //public decimal DeDao_Hou_dv
        //{
        //    get { return Score_DeDao_Hou_dv; }
        //    set
        //    {
        //        if (Score_DeDao_Hou_dv != value)
        //        {
        //            Score_DeDao_Hou_dv = value;
        //        }
        //    }
        //}


        //public decimal DeDao_dv
        //{
        //    get { return Score_DeDao_dv; }
        //    set
        //    {
        //        if (Score_DeDao_dv != value)
        //        {
        //            Score_DeDao_dv = value;
        //        }
        //    }
        //}


        public decimal DeDao_Qian_cv
        {
            get { return Score_DeDao_Qian_cv; }
            set
            {
                if (Score_DeDao_Qian_cv != value)
                {
                    Score_DeDao_Qian_cv = value;
                }
            }
        }


        public decimal DeDao_dv
        {
            get { return Score_DeDao_dv; }
            set
            {
                if (Score_DeDao_dv != value)
                {
                    Score_DeDao_dv = value;
                }
            }
        }
        public decimal DeDao_Hou_dv
        {
            get { return Score_DeDao_Hou_dv; }
            set
            {
                if (Score_DeDao_Hou_dv != value)
                {
                    Score_DeDao_Hou_dv = value;
                }
            }
        }
        public Guid DeDao_guid_Hou_dv
        {
            get { return Score_DeDao_guid_Hou_dv; }
            set
            {
                if (Score_DeDao_guid_Hou_dv != value)
                {
                    Score_DeDao_guid_Hou_dv = value;
                }
            }
        }

        public decimal DeDao_Qian_dv
        {
            get { return Score_DeDao_Qian_dv; }
            set
            {
                if (Score_DeDao_Qian_dv != value)
                {
                    Score_DeDao_Qian_dv = value;
                }
            }
        }

        public Decimal Getcore_pv_cv
        {
            get { return Score_Getcore_pv_cv; }
            set
            {
                if (Score_Getcore_pv_cv != value)
                {
                    Score_Getcore_pv_cv = value;
                }
            }
        }

        public Decimal GetPaymentPrice
        {
            get { return Score_GetPaymentPrice; }
            set
            {
                if (Score_GetPaymentPrice != value)
                {
                    Score_GetPaymentPrice = value;
                }
            }
        }


        public Decimal GetScore_pv_a
        {
            get { return Score_GetScore_pv_a; }
            set
            {
                if (Score_GetScore_pv_a != value)
                {
                    Score_GetScore_pv_a = value;
                }
            }
        }


        public Decimal GetScore_hv
        {
            get { return Score_GetScore_hv; }
            set
            {
                if (Score_GetScore_hv != value)
                {
                    Score_GetScore_hv = value;
                }
            }
        }

        public Decimal GetScore_pv_b
        {
            get { return Score_GetScore_pv_b; }
            set
            {
                if (Score_GetScore_pv_b != value)
                {
                    Score_GetScore_pv_b = value;
                }
            }
        }

        public Decimal GetScore_dv
        {
            get { return Score_GetScore_dv; }
            set
            {
                if (Score_GetScore_dv != value)
                {
                    Score_GetScore_dv = value;
                }
            }
        }


        public string OrderInfoOrderNumber
        {
            get { return Score_OrderInfoOrderNumber; }
            set
            {
                if (Score_OrderInfoOrderNumber != value)
                {
                    Score_OrderInfoOrderNumber = value;
                }
            }
        }

        public Decimal Offset_pv_b
        {
            get { return Score_Offset_pv_b; }
            set
            {
                if (Score_Offset_pv_b != value)
                {
                    Score_Offset_pv_b = value;
                }
            }
        }
        public Decimal Score_pv_c
        {
            get { return Score_Score_pv_c; }
            set
            {
                if (Score_Score_pv_c != value)
                {
                    Score_Score_pv_c = value;
                }
            }
        }
        public Decimal Score_rv
        {
            get { return Score_Score_rv; }
            set
            {
                if (Score_Score_rv != value)
                {
                    Score_Score_rv = value;
                }
            }
        }

        //负值
        public Guid HuoDe_dv_Guid
        {
            get { return Score_HuoDe_dv_Guid; }
            set
            {
                if (Score_HuoDe_dv_Guid != value)
                {
                    Score_HuoDe_dv_Guid = value;
                }
            }
        }

        //负值
        public decimal HuoDe_Hou_dv
        {
            get { return Score_HuoDe_Hou_dv; }
            set
            {
                if (Score_HuoDe_Hou_dv != value)
                {
                    Score_HuoDe_Hou_dv = value;
                }
            }
        }


        //负值
        public decimal HuoDe_dv
        {
            get { return Score_HuoDe_dv; }
            set
            {
                if (Score_HuoDe_dv != value)
                {
                    Score_HuoDe_dv = value;
                }
            }
        }


        //负值
        public decimal HuoDe_YuanYou_dv
        {
            get { return Score_HuoDe_YuanYou_dv; }
            set
            {
                if (Score_HuoDe_YuanYou_dv != value)
                {
                    Score_HuoDe_YuanYou_dv = value;
                }
            }
        }



        //负值
        public Guid hv_guid_two
        {
            get { return Score_hv_guid_two; }
            set
            {
                if (Score_hv_guid_two != value)
                {
                    Score_hv_guid_two = value;
                }
            }
        }

        //负值
        public Guid pv_a_guid_two
        {
            get { return Score_pv_a_guid_two; }
            set
            {
                if (Score_pv_a_guid_two != value)
                {
                    Score_pv_a_guid_two = value;
                }
            }
        }

        //负值
        public Guid pv_b_guid_two
        {
            get { return Score_pv_b_guid_two; }
            set
            {
                if (Score_pv_b_guid_two != value)
                {
                    Score_pv_b_guid_two = value;
                }
            }
        }

         //负值
        public Guid pv_b_guid
         {
             get { return Score_pv_b_guid; }
             set
             {
                 if (Score_pv_b_guid != value)
                 {
                     Score_pv_b_guid = value;
                 }
             }
         }

         //负值
        public Guid pv_a_guid
         {
             get { return Score_pv_a_guid; }
             set
             {
                 if (Score_pv_a_guid != value)
                 {
                     Score_pv_a_guid = value;
                 }
             }
         }

         //负值
        public Guid hv_guid
         {
             get { return Score_hv_guid; }
             set
             {
                 if (Score_hv_guid != value)
                 {
                     Score_hv_guid = value;
                 }
             }
         }

        //负值
        public decimal Huo_DeHou_pv_b
        {
            get { return Score_Huo_DeHou_pv_b; }
            set
            {
                if (Score_Huo_DeHou_pv_b != value)
                {
                    Score_Huo_DeHou_pv_b = value;
                }
            }
        }

        //负值
        public decimal Huo_DeHou_pv_a
        {
            get { return Score_Huo_DeHou_pv_a; }
            set
            {
                if (Score_Huo_DeHou_pv_a != value)
                {
                    Score_Huo_DeHou_pv_a = value;
                }
            }
        }

        //负值
        public decimal Huo_DeHou_hv
        {
            get { return Score_Huo_DeHou_hv; }
            set
            {
                if (Score_Huo_DeHou_hv != value)
                {
                    Score_Huo_DeHou_hv = value;
                }
            }
        }

        //负值
        public decimal XiaoFei_Hou_pv_b
        {
            get { return Score_XiaoFei_Hou_pv_b; }
            set
            {
                if (Score_XiaoFei_Hou_pv_b != value)
                {
                    Score_XiaoFei_Hou_pv_b = value;
                }
            }
        }

        //负值
        public decimal XiaoFei_Hou_pv_a
        {
            get { return Score_XiaoFei_Hou_pv_a; }
            set
            {
                if (Score_XiaoFei_Hou_pv_a != value)
                {
                    Score_XiaoFei_Hou_pv_a = value;
                }
            }
        }

        //负值
        public decimal XiaoFei_Hou_hv
        {
            get { return Score_XiaoFei_Hou_hv; }
            set
            {
                if (Score_XiaoFei_Hou_hv != value)
                {
                    Score_XiaoFei_Hou_hv = value;
                }
            }
        }


        //负值
        public string XiaoFei_Mom
        {
            get { return Score_XiaoFei_Mom; }
            set
            {
                if (Score_XiaoFei_Mom != value)
                {
                    Score_XiaoFei_Mom = value;
                }
            }
        }


        //负值
        public string HuoDe_Mom
        {
            get { return Score_HuoDe_Mom; }
            set
            {
                if (Score_HuoDe_Mom != value)
                {
                    Score_HuoDe_Mom = value;
                }
            }
        }

        //负值
        public Decimal HuoDe_pv_b
        {
            get { return Score_HuoDe_pv_b; }
            set
            {
                if (Score_HuoDe_pv_b != value)
                {
                    Score_HuoDe_pv_b = value;
                }
            }
        }

        //负值
        public Decimal HuoDe_pv_a
        {
            get { return Score_HuoDe_pv_a; }
            set
            {
                if (Score_HuoDe_pv_a != value)
                {
                    Score_HuoDe_pv_a = value;
                }
            }
        }

        //负值
        public Decimal HuoDe_hv
        {
            get { return Score_HuoDe_hv; }
            set
            {
                if (Score_HuoDe_hv != value)
                {
                    Score_HuoDe_hv = value;
                }
            }
        }

        //负值
        public Decimal HuoDe_YuanYou_pv_b
        {
            get { return Score_HuoDe_YuanYou_pv_b; }
            set
            {
                if (Score_HuoDe_YuanYou_pv_b != value)
                {
                    Score_HuoDe_YuanYou_pv_b = value;
                }
            }
        }

        //负值
        public Decimal HuoDe_YuanYou_pv_a
        {
            get { return Score_HuoDe_YuanYou_pv_a; }
            set
            {
                if (Score_HuoDe_YuanYou_pv_a != value)
                {
                    Score_HuoDe_YuanYou_pv_a = value;
                }
            }
        }

        //负值
        public Decimal HuoDe_YuanYou_hv
        {
            get { return Score_HuoDe_YuanYou_hv; }
            set
            {
                if (Score_HuoDe_YuanYou_hv != value)
                {
                    Score_HuoDe_YuanYou_hv = value;
                }
            }
        }

        //负值
        public Decimal YuanYou_pv_b
        {
            get { return Score_YuanYou_pv_b; }
            set
            {
                if (Score_YuanYou_pv_b != value)
                {
                    Score_YuanYou_pv_b = value;
                }
            }
        }


        //负值
        public Decimal YuanYou_pv_a
        {
            get { return Score_YuanYou_pv_a; }
            set
            {
                if (Score_YuanYou_pv_a != value)
                {
                    Score_YuanYou_pv_a = value;
                }
            }
        }


        //负值
        public Decimal YuanYou_hv
        {
            get { return Score_YuanYou_hv; }
            set
            {
                if (Score_YuanYou_hv != value)
                {
                    Score_YuanYou_hv = value;
                }
            }
        }


        //负值
        public Decimal XiaoFei_pv_b
        {
            get { return Score_XiaoFei_pv_b; }
            set
            {
                if (Score_XiaoFei_pv_b != value)
                {
                    Score_XiaoFei_pv_b = value;
                }
            }
        }

        //负值
        public Decimal XiaoFei_pv_a
        {
            get { return Score_XiaoFei_pv_a; }
            set
            {
                if (Score_XiaoFei_pv_a != value)
                {
                    Score_XiaoFei_pv_a = value;
                }
            }
        }

        //负值
        public Decimal XiaoFei_hv
        {
            get { return Score_XiaoFei_hv; }
            set
            {
                if (Score_XiaoFei_hv != value)
                {
                    Score_XiaoFei_hv = value;
                }
            }
        }

        //负值
        public Decimal Score_cv
        {
            get { return Score_Score_cv; }
            set
            {
                if (Score_Score_cv != value)
                {
                    Score_Score_cv = value;
                }
            }
        }
        //负值
        public Decimal Score_max_hv
        {
            get { return Score_Score_max_hv; }
            set
            {
                if (Score_Score_max_hv != value)
                {
                    Score_Score_max_hv = value;
                }
            }
        }


        //负值
        public Decimal Score_dv
        {
            get { return Score_Score_dv; }
            set
            {
                if (Score_Score_dv != value)
                {
                    Score_Score_dv = value;
                }
            }
        }


        //负值
        public Decimal Score_pv_b
        {
            get { return Score_Score_pv_b; }
            set
            {
                if (Score_Score_pv_b != value)
                {
                    Score_Score_pv_b = value;
                }
            }
        }


        //负值
        public Decimal Score_pv_a
        {
            get { return Score_Score_pv_a; }
            set
            {
                if (Score_Score_pv_a != value)
                {
                    Score_Score_pv_a = value;
                }
            }
        }

        //负值
        public Decimal Score_hv
        {
            get { return Score_Score_hv; }
            set
            {
                if (Score_Score_hv != value)
                {
                    Score_Score_hv = value;
                }
            }
        }


        //  //[Column(Storage = "_CreateTime", DbType = "DateTime")]
        public DateTime? CreateTime
        {
            get { return dateTime_1; }
            set
            {
                if (dateTime_1 != value)
                {
                    dateTime_1 = value;
                }
            }
        }

        // //[Column(Storage = "_CreateUser", DbType = "NVarChar(50)")]
        public string CreateUser
        {
            get { return string_2; }
            set
            {
                if (string_2 != value)
                {
                    string_2 = value;
                }
            }
        }

        // //[Column(Storage = "_CurrentAdvancePayment", DbType = "Decimal(18,2) NOT NULL")]
        public decimal CurrentAdvancePayment
        {
            get { return decimal_0; }
            set
            {
                if (decimal_0 != value)
                {
                    decimal_0 = value;
                }
            }
        }

        ////[Column(Storage = "_Date", DbType = "DateTime NOT NULL")]
        public DateTime Date
        {
            get { return dateTime_0; }
            set
            {
                if (dateTime_0 != value)
                {
                    dateTime_0 = value;
                }
            }
        }

        // //[Column(Storage = "_Guid", DbType = "UniqueIdentifier")]
        public Guid? Guid
        {
            get { return guid_0; }
            set
            {
                if (guid_0 != value)
                {
                    guid_0 = value;
                }
            }
        }

        // //[Column(Storage = "_IsDeleted", DbType = "Int")]
        public int? IsDeleted
        {
            get { return int_1; }
            set
            {
                if (int_1 != value)
                {
                    int_1 = value;
                }
            }
        }

        // //[Column(Storage = "_LastOperateMoney", DbType = "Decimal(18,2) NOT NULL")]
        public decimal LastOperateMoney
        {
            get { return decimal_2; }
            set
            {
                if (decimal_2 != value)
                {
                    decimal_2 = value;
                }
            }
        }

        // //[Column(Storage = "_MemLoginID", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string MemLoginID
        {
            get { return string_1; }
            set
            {
                if (string_1 != value)
                {
                    string_1 = value;
                }
            }
        }

        // //[Column(Storage = "_Memo", DbType = "NVarChar(250)")]
        public string Memo
        {
            get { return string_0; }
            set
            {
                if (string_0 != value)
                {
                    string_0 = value;
                }
            }
        }

        //  //[Column(Storage = "_OperateMoney", DbType = "Decimal(18,2) NOT NULL")]
        public decimal OperateMoney
        {
            get { return decimal_1; }
            set
            {
                if (decimal_1 != value)
                {
                    decimal_1 = value;
                }
            }
        }

        // //[Column(Storage = "_OperateType", DbType = "Int NOT NULL")]
        public int OperateType
        {
            get { return int_0; }
            set
            {
                if (int_0 != value)
                {
                    int_0 = value;
                }
            }
        }

        // //[Column(Storage = "_OrderNumber", CanBeNull = false)]
        public string OrderNumber
        {
            get { return string_4; }
            set
            {
                if (string_4 != value)
                {
                    string_4 = value;
                }
            }
        }

        // //[Column(Storage = "_UserMemo", CanBeNull = false)]
        public string UserMemo
        {
            get { return string_3; }
            set
            {
                if (string_3 != value)
                {
                    string_3 = value;
                }
            }
        }
        public string LogID
        {
            get { return Score_logID; }
            set
            {
                if (Score_logID != value)
                {
                    Score_logID = value;
                }
            }
        }
    }
}