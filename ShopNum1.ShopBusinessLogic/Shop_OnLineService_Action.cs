using System.Data;
using System.Text;
using System.Web;
using System.Xml;
using ShopNum1.DataAccess;
using ShopNum1.ShopInterface;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_OnLineService_Action : IShop_OnLineService_Action
    {
        public XmlDocument xmlDoc;

        public string StrPath { get; set; }

        public int AddOnLineService(ShopNum1_Shop_OnlineService onlineService)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@type";
            paraValue[0] = onlineService.Type;
            paraName[1] = "@name";
            paraValue[1] = onlineService.Name;
            paraName[2] = "@serviceaccount";
            paraValue[2] = onlineService.ServiceAccount;
            paraName[3] = "@isshow";
            paraValue[3] = onlineService.IsShow.ToString();
            paraName[4] = "@orderid";
            paraValue[4] = onlineService.OrderID.ToString();
            paraName[5] = "@memloginid";
            paraValue[5] = onlineService.MemLoginID;
            paraName[6] = "@TypeName";
            paraValue[6] = onlineService.TypeName;
            return DatabaseExcetue.RunProcedure("Pro_Shop_AddOnLineService", paraName, paraValue);
        }

        public int DeleteOnLineService(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedure("Pro_Shop_DeleteOnLineService", paraName, paraValue);
        }

        public string GetIsShowByID(string string_1)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if (string_1 != "-1")
            {
                DataRow[] source = set.Tables[0].Select("id=" + string_1);
                if (source.Length > 0)
                {
                    return source.CopyToDataTable().Rows[0]["IsShow"].ToString();
                }
                return "-1";
            }
            if (set.Tables.Count > 0)
            {
                return set.Tables[0].Rows[0]["IsShow"].ToString();
            }
            return "-1";
        }

        public DataTable GetOnLineService(string guid)
        {
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@guid";
            paraValue[0] = guid;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOnLineService", paraName, paraValue);
        }

        public DataTable GetOnLineServiceList(string memloginid, string type, string isshow)
        {
            var paraName = new string[3];
            var paraValue = new string[3];
            paraName[0] = "@memloginid";
            paraValue[0] = memloginid;
            paraName[1] = "@type";
            paraValue[1] = type;
            paraName[2] = "@isshow";
            paraValue[2] = isshow;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_Shop_GetOnLineServiceList", paraName, paraValue);
        }

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath(StrPath);
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }

        public DataTable Search(string name, string type, string strPath)
        {
            DataRow[] rowArray;
            StrPath = strPath;
            var set = new DataSet();
            set.ReadXml(GetPath());
            if ((name != "-1") && (type != "-1"))
            {
                rowArray = set.Tables[0].Select("Name='" + name + "' AND Type=" + type);
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if ((name != "-1") && (type == "-1"))
            {
                rowArray = set.Tables[0].Select("Name='" + name + "'");
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if ((name == "-1") && (type != "-1"))
            {
                rowArray = set.Tables[0].Select("Type=" + type);
                if (rowArray.Length > 0)
                {
                    return rowArray.CopyToDataTable();
                }
                return null;
            }
            if (set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            return null;
        }

        public DataTable SelectOnLineService_List(CommonPageModel commonModel)
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
            paraValue[5] = "OrderID";
            paraName[6] = "@sortvalue";
            paraValue[6] = "desc";
            paraName[7] = "@resultnum";
            paraValue[7] = commonModel.Resultnum;
            return DatabaseExcetue.RunProcedureReturnDataTable("Pro_CommonPager_two", paraName, paraValue);
        }

        public int Update(string[] string_1, string[] isshow, string strPath, string memloginid)
        {
            StrPath = strPath;
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("Servers").ChildNodes;
            for (int i = 0; i < string_1.Length; i++)
            {
                var element = childNodes[i] as XmlElement;
                if (element.GetAttribute("id") == string_1[i])
                {
                    element.SetAttribute("IsShow", isshow[i]);
                    UpdateIsShow(element.GetAttribute("Name"), memloginid, element.GetAttribute("IsShow"));
                }
            }
            try
            {
                xmlDoc.Save(GetPath());
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateIsShow(string type, string shopid, string isshow)
        {
            var builder = new StringBuilder();
            builder.Append(" update ShopNum1_Shop_OnlineService ");
            builder.Append(" set ISshow='" + isshow + "'");
            builder.Append("  where  MemLoginID='" + shopid + "'");
            builder.Append(" and Type='" + type + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public int UpdateOnLineService(ShopNum1_Shop_OnlineService onlineService)
        {
            var paraName = new string[7];
            var paraValue = new string[7];
            paraName[0] = "@guid";
            paraValue[0] = onlineService.Guid.ToString();
            paraName[1] = "@type";
            paraValue[1] = onlineService.Type;
            paraName[2] = "@name";
            paraValue[2] = onlineService.Name;
            paraName[3] = "@serviceaccount";
            paraValue[3] = onlineService.ServiceAccount;
            paraName[4] = "@isshow";
            paraValue[4] = onlineService.IsShow.ToString();
            paraName[5] = "@orderid";
            paraValue[5] = onlineService.OrderID.ToString();
            paraName[6] = "@TypeName";
            paraValue[6] = onlineService.TypeName;
            return DatabaseExcetue.RunProcedure("Pro_Shop_UpdateOnLineService", paraName, paraValue);
        }

        public int UpdateShopOnlinePhone(ShopNum1_Shop_OnlineService onlineService)
        {
            if (onlineService.Guid.ToString() != "")
            {
                return UpdateOnLineService(onlineService);
            }
            return AddOnLineService(onlineService);
        }

        public DataTable GetOnLineServiceList1(string memloginid, string type, string showcount)
        {
            object obj2 = ((string.Empty + " select top " + showcount + "  *  from ShopNum1_Shop_OnlineService") +
                           " where  MemLoginID='" + memloginid + "' ") + "  and  Type='" + type + "' ";
            return
                DatabaseExcetue.ReturnDataTable(string.Concat(new[] {obj2, "  and  IsShow='", 1, "' "}) +
                                                " order by orderid asc");
        }
    }
}