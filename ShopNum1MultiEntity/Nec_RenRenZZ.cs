using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using ShopNum1.Common;
namespace ShopNum1MultiEntity
{
    public class Nec_RenRenZZ
    {
        public int ID { get; set; }
        public decimal? NEC { get; set; }

        public string ChongZhiID { get; set; }

        private DateTime? AddTime { get; set; }

        public int Status { get; set; }
    }
}
