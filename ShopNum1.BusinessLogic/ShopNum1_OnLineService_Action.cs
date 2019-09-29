using System.Data;
using System.Text;
using System.Web;
using System.Xml;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;
using System.Data.Common;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_OnLineService_Action : IShopNum1_OnLineService_Action
    {
        public XmlDocument xmlDoc;

        public int Add(ShopNum1_OnlineService onlineservice)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "INSERT INTO ShopNum1_OnlineService( Guid, Type, Name, ServiceAccount, Location, IsShow, OrderID, CreateUser, CreateTime, ModifyUser, ModifyTime, IsDeleted  ) VALUES (  '"
                , onlineservice.Guid, "',  '", onlineservice.Type, "',  '",
                Operator.FilterString(onlineservice.Name), "',  '",
                Operator.FilterString(onlineservice.ServiceAccount), "',  '",
                Operator.FilterString(onlineservice.Location), "',  ", onlineservice.IsShow, ",  ",
                onlineservice.OrderID, ",  '", onlineservice.CreateUser,
                "', '", onlineservice.CreateTime, "',  '", onlineservice.ModifyUser, "' , '",
                onlineservice.ModifyTime, "',  ", onlineservice.IsDeleted, " )"
            }));
        }

        public int Delete(string guids)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guids;
            return DatabaseExcetue.RunNonQuery("delete from ShopNum1_OnlineService  WHERE Guid IN (@guids) ",parms);
        }

        public DataTable GetEditInfo(string guid, int isDeleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@guids";
            parms[0].Value = guid;
            return
                DatabaseExcetue.ReturnDataTable(
                    "SELECT Guid,Type, Name,ServiceAccount,Location,IsShow,OrderID,CreateUser,CreateTime,ModifyUser,ModifyTime,IsDeleted FROM ShopNum1_OnlineService where guid=@guids",parms);
        }

        public string GetIsShowByID(string string_0)
        {
            var set = new DataSet();
            set.ReadXml(GetPath());
            if (string_0 != "-1")
            {
                DataRow[] source = set.Tables[0].Select("id=" + string_0);
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

        public DataSet GetOnlineService(string showcountqq, string showcountmsn)
        {
            var paraName = new string[2];
            var paraValue = new string[2];
            paraName[0] = "@showcountqq";
            paraValue[0] = showcountqq;
            paraName[1] = "@showcountmsn";
            paraValue[1] = showcountmsn;
            return DatabaseExcetue.RunProcedureReturnDataSet("Pro_ShopNum1_GetOnlineService", paraName, paraValue);
        }

        public DataTable GetOnlineServiceInfo(int Deleted)
        {
                DbParameter[] parms = DatabaseExcetue.CreateParameter(1);
            parms[0].ParameterName = "@Deleted";
            parms[0].Value = Deleted;
            string str = string.Empty;
            str =
                "SELECT A.Guid, A.Name,A.ServiceAccount,A.Location,A.IsShow,A.OrderID,A.CreateUser,A.CreateTime, A.ModifyUser,A.ModifyTime,A.IsDeleted FROM ShopNum1_OnlineService as A where 0=0";
            if ((Deleted == 0) || (Deleted == 1))
            {
                str = string.Concat(new object[] { str, " AND A.IsDeleted=@Deleted " });
            }
            return DatabaseExcetue.ReturnDataTable(str + "Order By A.OrderID Desc",parms);
        }

        public string GetPath()
        {
            return HttpContext.Current.Server.MapPath("~/Main/Themes/Skin_Default/Xml/OnLineServer.xml");
        }

        public void LoadXml()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(GetPath());
        }

        public DataTable Search(string name, string type)
        {
            DataRow[] rowArray;
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

        public int Update(string guid, ShopNum1_OnlineService onlineservice)
        {
            return DatabaseExcetue.RunNonQuery(string.Concat(new object[]
            {
                "UPDATE  ShopNum1_OnlineService SET  Type='", onlineservice.Type, "', Name='",
                Operator.FilterString(onlineservice.Name), "', ServiceAccount='",
                Operator.FilterString(onlineservice.ServiceAccount), "', Location='",
                Operator.FilterString(onlineservice.Location), "', IsShow='", onlineservice.IsShow, "', orderid='",
                onlineservice.OrderID, "', ModifyUser='", onlineservice.ModifyUser, "', ModifyTime='",
                onlineservice.ModifyTime,
                "' WHERE Guid=", guid
            }));
        }

        public int Update(string[] string_0, string[] isshow)
        {
            LoadXml();
            XmlNodeList childNodes = xmlDoc.SelectSingleNode("Servers").ChildNodes;
            for (int i = 0; i < string_0.Length; i++)
            {
                var element = childNodes[i] as XmlElement;
                if (element.GetAttribute("id") == string_0[i])
                {
                    element.SetAttribute("IsShow", isshow[i]);
                    UpdateIsShow(element.GetAttribute("Name"), element.GetAttribute("IsShow"));
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

        public int UpdateIsShow(string type, string isshow)
        {
            var builder = new StringBuilder();
            builder.Append(" update ShopNum1_OnlineService ");
            builder.Append(" set ISshow='" + isshow + "'");
            builder.Append(" where  Type='" + type + "'");
            return DatabaseExcetue.RunNonQuery(builder.ToString());
        }

        public DataTable SearchTypeInfo(string strType, int isShow)
        {
            string str = string.Empty;
            str = "select name,ServiceAccount from ShopNum1_OnlineService where 1=1";
            if (Operator.FormatToEmpty(strType) != string.Empty)
            {
                str = str + " And Type='" + Operator.FilterString(strType) + "'";
            }
            if ((isShow == 0) || (isShow == 1))
            {
                str = string.Concat(new object[] {str, " And IsShow=", isShow, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by orderid asc");
        }

        public DataTable SearchTypeInfo(string strType, int isShow, int showCount)
        {
            string str = string.Empty;
            str = "select top " + showCount + "  name,ServiceAccount from ShopNum1_OnlineService where 1=1";
            if (Operator.FormatToEmpty(strType) != string.Empty)
            {
                str = str + " And Type='" + Operator.FilterString(strType) + "'";
            }
            if ((isShow == 0) || (isShow == 1))
            {
                str = string.Concat(new object[] {str, " And IsShow=", isShow, " "});
            }
            return DatabaseExcetue.ReturnDataTable(str + " order by orderid asc");
        }
    }
}