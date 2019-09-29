using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;
using ShopNum1.TbLinq.Properties;

namespace ShopNum1.TbLinq
{
    [Database(Name = "ShopNum1_MultiV7.2")]
    public class ShopNum1_TbLinqDataContext : DataContext
    {
        private static readonly MappingSource mappingSource = new AttributeMappingSource();

        public ShopNum1_TbLinqDataContext() : base(Settings.Default.ShopNum1_MultiV7_2ConnectionString2, mappingSource)
        {
        }

        public ShopNum1_TbLinqDataContext(IDbConnection connection) : base(connection, mappingSource)
        {
        }

        public ShopNum1_TbLinqDataContext(string connection) : base(connection, mappingSource)
        {
        }

        public ShopNum1_TbLinqDataContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
        }

        public ShopNum1_TbLinqDataContext(string connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
        }

        public Table<ShopNum1_TbAddress> ShopNum1_TbAddresses
        {
            get { return base.GetTable<ShopNum1_TbAddress>(); }
        }

        public Table<ShopNum1_TbItem> ShopNum1_TbItems
        {
            get { return base.GetTable<ShopNum1_TbItem>(); }
        }

        public Table<ShopNum1_TbSellCat> ShopNum1_TbSellCats
        {
            get { return base.GetTable<ShopNum1_TbSellCat>(); }
        }

        public Table<ShopNum1_TbSystem> ShopNum1_TbSystems
        {
            get { return base.GetTable<ShopNum1_TbSystem>(); }
        }

        public Table<ShopNum1_TbTopKey> ShopNum1_TbTopKeys
        {
            get { return base.GetTable<ShopNum1_TbTopKey>(); }
        }

        [Function(Name = "dbo.Pro_ShopNum1_TbSellCat_Delete")]
        public int Pro_ShopNum1_TbSellCat_Delete([Parameter(DbType = "NVarChar(200)")] string shopname,
                                                 [Parameter(DbType = "NVarChar(50)")] string memlogid,
                                                 [Parameter(DbType = "Decimal")] decimal? cid,
                                                 [Parameter(DbType = "Decimal")] decimal? site_cid)
        {
            return
                (int)
                base.ExecuteMethodCall(this, (MethodInfo) MethodBase.GetCurrentMethod(),
                                       new object[] {shopname, memlogid, cid, site_cid}).ReturnValue;
        }

        [Function(Name = "dbo.Pro_ShopNum1_TbSystem_Insert")]
        public int Pro_ShopNum1_TbSystem_Insert([Parameter(DbType = "NVarChar(100)")] string tbShopName,
                                                [Parameter(Name = "Memlogid", DbType = "NVarChar(100)")] string memlogid)
        {
            return
                (int)
                base.ExecuteMethodCall(this, (MethodInfo) MethodBase.GetCurrentMethod(),
                                       new object[] {tbShopName, memlogid}).ReturnValue;
        }

        [Function(Name = "dbo.Pro_ShopNum1_TbSystemCheckBind")]
        public ISingleResult<Pro_ShopNum1_TbSystemCheckBindResult> Pro_ShopNum1_TbSystemCheckBind(
            [Parameter(DbType = "NVarChar(100)")] string tbShopName,
            [Parameter(Name = "Memlogid", DbType = "NVarChar(100)")] string memlogid)
        {
            return
                (ISingleResult<Pro_ShopNum1_TbSystemCheckBindResult>)
                base.ExecuteMethodCall(this, (MethodInfo) MethodBase.GetCurrentMethod(),
                                       new object[] {tbShopName, memlogid}).ReturnValue;
        }
    }
}