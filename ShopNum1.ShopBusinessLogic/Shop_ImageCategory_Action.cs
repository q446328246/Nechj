using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.Common;
using ShopNum1.DataAccess;
using ShopNum1.Interface;

namespace ShopNum1.ShopBusinessLogic
{
    public class Shop_ImageCategory_Action : IShop_ImageCategory_Action
    {
        public int Delete(string string_0)
        {
            var list = new List<string>();
            string text = string.Empty;
            text = "Select * from ShopNum1_Shop_Image where ImageCategoryID =" + string_0;
            DataTable dataTable = DatabaseExcetue.ReturnDataTable(text);
            int result;
            if (dataTable.Rows.Count > 0)
            {
                result = -1;
            }
            else
            {
                string item = "Delete from ShopNum1_Shop_ImageCategory where ID in (" + string_0 + ")";
                list.Add(item);
                try
                {
                    DatabaseExcetue.RunTransactionSql(list);
                    result = 1;
                }
                catch
                {
                    result = 0;
                }
            }
            return result;
        }

        public int Update(string strid, string name, string description, string sort)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("UPDATE ShopNum1_Shop_ImageCategory");
            stringBuilder.Append(" SET ");
            stringBuilder.Append("Name = '" + Operator.FilterString(name) + "',");
            stringBuilder.Append("Description = '" + Operator.FilterString(description) + "',");
            stringBuilder.Append("Sort='" + sort + "'");
            stringBuilder.Append(" WHERE ");
            stringBuilder.Append(" ID = '" + strid + "'");
            return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
        }

        public int Insert(string CreateUser, string name, string description, string sort)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO ShopNum1_Shop_ImageCategory(");
            stringBuilder.Append("CreateUser,");
            stringBuilder.Append("Name,");
            stringBuilder.Append("Description,Sort)");
            stringBuilder.Append(" VALUES(");
            stringBuilder.Append("'" + Operator.FilterString(CreateUser) + "',");
            stringBuilder.Append("'" + Operator.FilterString(name) + "',");
            stringBuilder.Append("'" + Operator.FilterString(description) + "',");
            stringBuilder.Append("'" + sort + "')");
            return DatabaseExcetue.RunNonQuery(stringBuilder.ToString());
        }

        public DataTable Select(string strType, string strMemloginId)
        {
            string text =
                "select * from (select 0 as Sort,0 as id,'未分类' name,'/ImgUpload/noImg.jpg_100x100.jpg'Face,'0'IsDefault,count(*) imagecount,sum(imagesize)as  TotalImageSize,getdate() as Createtime from ShopNum1_Shop_Image t where 1=1 and createuser='" +
                strMemloginId + "'";
            text = text + " and imagecategoryid not in(select id from ShopNum1_Shop_ImageCategory where createuser='" +
                   strMemloginId + "')";
            text = text +
                   "union all select Sort,ID,Name,Face,IsDefault,(SELECT COUNT(*) FROM ShopNum1_Shop_Image WHERE ImageCategoryID=t.id And createuser='" +
                   strMemloginId + "')imagecount ";
            text = text + ",(select sum(imagesize) from ShopNum1_Shop_Image where imagecategoryid=t.id And createuser='" +
                   strMemloginId + "')TotalImageSize,Createtime from ShopNum1_Shop_ImageCategory t ";
            text = text + " where 1=1 and createuser='" + strMemloginId + "')as tab ";
            switch (strType)
            {
                case "0":
                    text += " order by TotalImageSize desc";
                    goto IL_150;
                case "1":
                    text += " order by TotalImageSize asc";
                    goto IL_150;
                case "2":
                    text += " order by Createtime desc";
                    goto IL_150;
                case "3":
                    text += " order by Createtime asc";
                    goto IL_150;
                case "4":
                    text += " order by Sort desc";
                    goto IL_150;
                case "5":
                    text += " order by Sort asc";
                    goto IL_150;
            }
            text += " order by Sort asc";
            IL_150:
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public DataTable Select_AllType(string strMemloginId)
        {
            string text = "select ID,Name from ShopNum1_Shop_ImageCategory where isdefault=1 and createuser='" +
                          strMemloginId + "' order by sort asc";
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public string Get_TypeName(string strId)
        {
            string text = "select Name from ShopNum1_Shop_ImageCategory where id='" + strId + "' ";
            return DatabaseExcetue.ReturnString(text);
        }

        public DataTable dt_Album_Import(string strMemloginId)
        {
            string text =
                "select Id,id as code,name from ShopNum1_Shop_ImageCategory  where id=1 union all   select id,id as Code,name from ShopNum1_Shop_ImageCategory  where id!=1 and createuser='" +
                strMemloginId + "'";
            return DatabaseExcetue.ReturnDataTable(text);
        }

        public int UpdateAlbumImg(string strTypeId, string strImgPath)
        {
            string text = string.Concat(new[]
            {
                "UPDATE ShopNum1_Shop_ImageCategory  SET Face='",
                strImgPath,
                "' WHERE ID='",
                strTypeId,
                "'"
            });
            return DatabaseExcetue.RunNonQuery(text);
        }
    }
}