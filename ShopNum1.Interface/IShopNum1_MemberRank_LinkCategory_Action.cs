using ShopNum1MultiEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ShopNum1.Interface
{
    public interface IShopNum1_MemberRank_LinkCategory_Action
    {
        int Add(ShopNum1_MemberRank_LinkCategory shopNum1_MemberRank_LinkCategory);
        int Delete(int id);
        int Update(int id, ShopNum1_MemberRank_LinkCategory shopNum1_MemberRank_LinkCategory);
        DataTable GetRankLinkCategoryByID(string rank_ID, string isReadorBuy);
    }
}
