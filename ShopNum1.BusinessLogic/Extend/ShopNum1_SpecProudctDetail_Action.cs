using System.Collections.Generic;
using System.Data;
using System.Text;
using ShopNum1.DataAccess;
using ShopNum1.Interface;
using ShopNum1MultiEntity;

namespace ShopNum1.BusinessLogic
{
    public class ShopNum1_SpecProudctDetail_Action : IShopNum1_SpecProudctDetail_Action
    {
        public DataTable GetDetailByDGuid(string strGuids)
        {
            return
                DatabaseExcetue.ReturnDataTable(
                    string.Format("select * from ShopNum1_SpecProudctDetails where [ID] in ({0}) order by id asc",
                        strGuids));
        }

        public DataTable GetDetailByDGuid(string guids, string productguid)
        {
            string strSql = string.Empty;
            strSql =
                "select distinct CAST(c.specname AS VARCHAR(50))+':'+replace(specvaluename,'*','x') AS SpecDetailName,CAST(a.specvalueid AS VARCHAR(50))+':'+CAST(specvalueid AS VARCHAR(5)) AS SpecDetail ,CAST(replace(specvaluename,'*','x') AS VARCHAR(50))+':'+CAST(specvalueid AS VARCHAR(5)) AS SpecDetailv,replace(specvaluename,'*','x') as specvaluename,b.imagepath,a.ProductImage,B.orderid from ShopNum1_SpecProudctDetails A left join ShopNum1_SpecValue B ON B.id=A.specvalueid left join ShopNum1_Spec C on C.id=b.specid where productguid=@productguid and [specvalueid] in (" +
                guids + ") order by B.orderid asc";
            var paraName = new string[1];
            var paraValue = new string[1];
            paraName[0] = "@productguid";
            paraValue[0] = productguid;
            return DatabaseExcetue.ReturnDataTable(strSql, paraName, paraValue);
        }

        public string GetSpecImageBySpecId(string strProductGuId, string strSpecId)
        {
            return
                DatabaseExcetue.ReturnString(
                    "select top 1 productimage from ShopNum1_SpecProudctDetails where productguid='" + strProductGuId +
                    "' and specvaluename='" + strSpecId.Split(new[] {':'})[0] + "' and specvalueid='" +
                    strSpecId.Split(new[] {':'})[1] + "' and productimage!=''");
        }

        public string SearchName(string strId)
        {
            return
                DatabaseExcetue.ReturnString("select specvaluename from ShopNum1_SpecProudctDetails where id='" + strId +
                                             "'");
        }

        public int AddListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials)
        {
            var sqlList = new List<string>();
            if (SpecDetials != null)
            {
                var builder = new StringBuilder();
                for (int i = 0; i < SpecDetials.Count; i++)
                {
                    if (SpecDetials[i].SpecId != 0)
                    {
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "   INSERT INTO dbo.ShopNum1_SpecProudctDetails \r\n        ( ProductGuid ,\r\n          typeid ,\r\n          specid ,\r\n          specvalueid,\r\n          specvaluename ,\r\n          ProductImage \r\n        ) Values('"
                                , SpecDetials[i].ProductGuid, "','", SpecDetials[i].TypeId, "','",
                                SpecDetials[i].SpecId, "','", SpecDetials[i].SpecValueId, "','",
                                SpecDetials[i].SpecValueName, "','", SpecDetials[i].ProductImage, "')"
                            }));
                        sqlList.Add(builder.ToString());
                    }
                }
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

        public int UpdateListSpecProudctDetail(List<ShopNum1_SpecProudctDetail> SpecDetials, string strDelSpecId,
            string strNewSpec)
        {
            var sqlList = new List<string>();
            if (strDelSpecId != "")
            {
                string[] strArray = (strDelSpecId + ",0").Split(new[] {','});
                for (int i = 0; i < strArray.Length; i++)
                {
                    sqlList.Add("delete from ShopNum1_SpecProudct where ProductGuId='" + SpecDetials[0].ProductGuid +
                                "';");
                    sqlList.Add(
                        string.Concat(new object[]
                        {
                            "delete from ShopNum1_SpecProudctDetails where specvalueid='", strArray[i],
                            "' and productguid='", SpecDetials[0].ProductGuid, "';"
                        }));
                }
            }
            if ((SpecDetials != null) && (SpecDetials.Count != 1))
            {
                for (int j = 0; j < SpecDetials.Count; j++)
                {
                    var builder = new StringBuilder();
                    builder.Append("declare @id varchar(20)\r\n");
                    if (strNewSpec != "")
                    {
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "delete from ShopNum1_SpecProudctDetails where SpecId not in(", strNewSpec,
                                ") and ProductGuId='", SpecDetials[j].ProductGuid, "';"
                            }));
                    }
                    builder.Append("set @id=''\r\n");
                    builder.Append(
                        string.Concat(new object[]
                        {
                            "select @id=max(id) from ShopNum1_SpecProudctDetails where typeid='",
                            SpecDetials[j].TypeId
                            , "' and specid='", SpecDetials[j].SpecId, "' and specvalueid='",
                            SpecDetials[j].SpecValueId, "' and productguid='", SpecDetials[j].ProductGuid, "'"
                        }));
                    builder.Append("\r\nbegin\r\n");
                    builder.Append("if(isnull(@id,'')!='')\r\n");
                    builder.Append(
                        string.Format(
                            "  update ShopNum1_SpecProudctDetails set typeid='{0}',specvaluename='{3}',ProductImage='{4}' where ProductGuid='{5}' and specid='{1}' and specvalueid='{2}' and id=@id",
                            new object[]
                            {
                                SpecDetials[j].TypeId, SpecDetials[j].SpecId, SpecDetials[j].SpecValueId,
                                SpecDetials[j].SpecValueName, SpecDetials[j].ProductImage,
                                SpecDetials[j].ProductGuid
                            }));
                    if (SpecDetials[j].SpecId != 0)
                    {
                        builder.Append("\r\nelse\r\n");
                        builder.Append(
                            string.Concat(new object[]
                            {
                                "   INSERT INTO dbo.ShopNum1_SpecProudctDetails \r\n        ( ProductGuid ,\r\n          typeid ,\r\n          specid ,\r\n          specvalueid,\r\n          specvaluename ,\r\n          ProductImage \r\n        ) Values('"
                                , SpecDetials[j].ProductGuid, "','", SpecDetials[j].TypeId, "','",
                                SpecDetials[j].SpecId, "','", SpecDetials[j].SpecValueId, "','",
                                SpecDetials[j].SpecValueName, "','", SpecDetials[j].ProductImage, "')\r\n"
                            }));
                    }
                    builder.Append("\r\nend\r\n");
                    sqlList.Add(builder.ToString());
                }
            }
            else
            {
                sqlList.Add("Delete from ShopNum1_SpecProudctDetails where ProductGuId='" + SpecDetials[0].ProductGuid +
                            "'");
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
    }
}