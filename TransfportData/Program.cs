using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoufunLab.Framework;
using SoufunLab.Framework.Data;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TransfportData
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string myfang_test = ConfigurationManager.ConnectionStrings["myfang_test"].ConnectionString;
            /*
            string myfang_w = ConfigurationManager.ConnectionStrings["myfang_w"].ConnectionString;
            try 
            {
                List<MySelect> list = HandleData.GetData(myfang_test);
                Console.WriteLine("导入" + list.Count);
                int i = 0;
                list.ForEach(en => { if (HandleData.Insert(myfang_w, en)) { Console.WriteLine(++i); } });
                Console.Write("完成");

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("error:" + e.ToString());
            }*/
            string sql = @"select count(*) from myselect_0
                            where city in (@city1,@city2) and type in (@t1,@t2,@t3)";
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter { ParameterName = "@city1", Value = "北京" });
            param.Add(new SqlParameter { ParameterName = "@city2", Value = "上海" });
            param.Add(new SqlParameter { ParameterName = "@t1", Value = "esf" });
            param.Add(new SqlParameter { ParameterName = "@t2", Value = "new" });
            param.Add(new SqlParameter { ParameterName = "@t3", Value = "rent" });
            var count = SlDatabase.ExecuteScalar(myfang_test, sql, param.ToArray());
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
    public static class HandleData
    {
        public static List<MySelect> GetData(string conn)
        {
            //string tableName = "myselect_0";
            string sql = @"select * from MySelect_9 t 
                            where t.createtime between '2016-02-22 17:10:56' and '2016-02-23 09:43:00'";
            try
            {
                var table = new DataTable();
                SlDatabase.Fill(conn, sql, table);
                if (table.Rows.Count > 0)
                {
                    //Console.WriteLine("query...");
                    return table.AsEnumerable().Select(row => new MySelect
                    {
                        UserID = SlConvert.TryToInt64(row["UserID"], -1),
                        Face = SlConvert.TryToString(row["Face"], string.Empty),
                        Name = SlConvert.TryToString(row["Name"], string.Empty),
                        Address = SlConvert.TryToString(row["Address"], string.Empty),
                        Price = SlConvert.TryToDouble(row["Price"], -1),
                        City = SlConvert.TryToString(row["City"], string.Empty),
                        Linkurl = SlConvert.TryToString(row["Linkurl"], string.Empty),
                        Type = SlConvert.TryToString(row["Type"], string.Empty),
                        Pricetype = SlConvert.TryToString(row["Pricetype"], string.Empty),
                        Createtime = SlConvert.TryToDateTime(row["Createtime"], Convert.ToDateTime("1900-01-01")),
                        HouseID = SlConvert.TryToString(row["HouseID"], string.Empty),
                        Roomnum = SlConvert.TryToString(row["Roomnum"], string.Empty),
                        ID = SlConvert.TryToString(row["ID"], string.Empty),
                        //MySelectID = SlConvert.TryToInt32(row["MySelectID"], -1),
                        PropertyType = SlConvert.TryToInt32(row["PropertyType"], -1),
                        Coordx = SlConvert.TryToString(row["Coordx"], string.Empty),
                        Coordy = SlConvert.TryToString(row["Coordy"], string.Empty),
                        Guapailiang = SlConvert.TryToInt32(row["Guapailiang"], -1),
                        Service = SlConvert.TryToString(row["Service"], string.Empty),
                        EsfSubType = SlConvert.TryToString(row["EsfSubType"], string.Empty),
                        ChannelType = SlConvert.TryToString(row["ChannelType"], string.Empty),
                        FangYuanID = SlConvert.TryToString(row["FangYuanID"], string.Empty),
                        Roomid = SlConvert.TryToString(row["Roomid"], string.Empty),
                        ServiceArea = SlConvert.TryToString(row["servicearea"], string.Empty),
                        Homeid = SlConvert.TryToString(row["homeid"], string.Empty),
                        //HousePrice = SlConvert.TryToDouble(row["HousePrice"], -1),
                        //HouseStatus = SlConvert.TryToInt32(row["HouseStatus"], 0),
                        PriceCategory = SlConvert.TryToString(row["PriceCategory"], string.Empty),
                        //NewHousePrice = SlConvert.TryToDouble(row["NewHousePrice"], -1),
                        //PriceUnit = SlConvert.TryToString(row["PriceUnit"], string.Empty),
                        KnowledgeTag = SlConvert.TryToString(row["knowledgetag"], string.Empty),
                        Area = SlConvert.TryToString(row["area"], string.Empty),
                        UserName = SlConvert.TryToString(row["username"], string.Empty),
                        District = SlConvert.TryToString(row["district"], string.Empty),
                        Huxing = SlConvert.TryToString(row["huxing"], string.Empty),
                        Mianji = SlConvert.TryToString(row["mianji"], string.Empty),
                        CaseCount = SlConvert.TryToInt32(row["casecount"])
                    }).ToList();
                }
                else { return null; }
            }
            catch (Exception e) { 
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static bool Insert(string conn,MySelect entity)
        {
            try
            {
                string sql = @"if not exists(select myselectid from myselect_9 
                                            where userid=@userid and houseid=@houseid and roomid=@roomid and type=@type 
                                                    and fangyuanid=@fangyuanid and homeid=@homeid and city=@city and linkurl=@linkurl and propertytype=@propertytype)
                            begin
                            INSERT INTO myselect_9
                               (
                                [UserID]
                                ,[Face]
                                ,[Name]
                                ,[Address]
                                ,[Price]
                                ,[City]
                                ,[Linkurl]
                                ,[Type]
                                ,[Pricetype]
                                ,[HouseID]
                                ,[Roomnum]
                                ,[PropertyType]
                                ,[Coordx]
                                ,[Coordy]
                                ,[Guapailiang]
                                ,[Service]
                                ,[EsfSubType]
                                ,[ChannelType]
                                ,[FangYuanID]
                                ,[Roomid]
                                ,[UserName]
                                ,[Homeid]
                                ,[ServiceArea]
                                ,[CreateTime]
                                ,[Area]
                                ,[District]
                                ,[Huxing]
                                ,[Mianji]
                                ,[CaseCount]
                                ,[PriceCategory]
                                ,[KnowledgeTag]
                               )
                         VALUES
                               (
                                @UserID
                                ,@Face
                                ,@Name
                                ,@Address
                                ,@Price
                                ,@City
                                ,@Linkurl
                                ,@Type
                                ,@Pricetype
                                ,@HouseID
                                ,@Roomnum
                                ,@PropertyType
                                ,@Coordx
                                ,@Coordy
                                ,@Guapailiang
                                ,@Service
                                ,@EsfSubType
                                ,@ChannelType
                                ,@FangYuanID
                                ,@Roomid
                                ,@UserName
                                ,@Homeid
                                ,@ServiceArea
                                ,@CreateTime
                                ,@Area
                                ,@District
                                ,@Huxing
                                ,@Mianji
                                ,@CaseCount
                                ,@PriceCategory
                                ,@KnowledgeTag
                               )
                            end;";
                var parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "@UserID", Value = entity.UserID });
                parameters.Add(new SqlParameter() { ParameterName = "@Face", Value = entity.Face });
                parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = entity.Name });
                parameters.Add(new SqlParameter() { ParameterName = "@Address", Value = entity.Address });
                parameters.Add(new SqlParameter() { ParameterName = "@Price", Value = entity.Price });
                parameters.Add(new SqlParameter() { ParameterName = "@City", Value = entity.City });
                parameters.Add(new SqlParameter() { ParameterName = "@Linkurl", Value = entity.Linkurl });
                parameters.Add(new SqlParameter() { ParameterName = "@Type", Value = entity.Type });
                parameters.Add(new SqlParameter() { ParameterName = "@Pricetype", Value = entity.Pricetype });
                parameters.Add(new SqlParameter() { ParameterName = "@HouseID", Value = entity.HouseID });
                parameters.Add(new SqlParameter() { ParameterName = "@Roomnum", Value = entity.Roomnum });
                parameters.Add(new SqlParameter() { ParameterName = "@PropertyType", Value = entity.PropertyType });
                parameters.Add(new SqlParameter() { ParameterName = "@Coordx", Value = entity.Coordx });
                parameters.Add(new SqlParameter() { ParameterName = "@Coordy", Value = entity.Coordy });
                parameters.Add(new SqlParameter() { ParameterName = "@Guapailiang", Value = entity.Guapailiang });
                parameters.Add(new SqlParameter() { ParameterName = "@Service", Value = entity.Service });
                parameters.Add(new SqlParameter() { ParameterName = "@EsfSubType", Value = entity.EsfSubType });
                parameters.Add(new SqlParameter() { ParameterName = "@ChannelType", Value = entity.ChannelType });
                parameters.Add(new SqlParameter() { ParameterName = "@FangYuanID", Value = entity.FangYuanID });
                parameters.Add(new SqlParameter() { ParameterName = "@Roomid", Value = entity.Roomid });
                parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = entity.UserName });
                parameters.Add(new SqlParameter() { ParameterName = "@Homeid", Value = entity.Homeid });
                parameters.Add(new SqlParameter() { ParameterName = "@ServiceArea", Value = entity.ServiceArea });
                parameters.Add(new SqlParameter() { ParameterName = "@CreateTime", Value = entity.Createtime });
                parameters.Add(new SqlParameter() { ParameterName = "@Area", Value = entity.Area });
                parameters.Add(new SqlParameter() { ParameterName = "@District", Value = entity.District });
                parameters.Add(new SqlParameter() { ParameterName = "@Huxing", Value = entity.Huxing });
                parameters.Add(new SqlParameter() { ParameterName = "@Mianji", Value = entity.Mianji });
                parameters.Add(new SqlParameter() { ParameterName = "@CaseCount", Value = entity.CaseCount });
                parameters.Add(new SqlParameter() { ParameterName = "@PriceCategory", Value = string.IsNullOrEmpty(entity.PriceCategory) ? "" : entity.PriceCategory });
                parameters.Add(new SqlParameter() { ParameterName = "@KnowledgeTag", Value = string.IsNullOrEmpty(entity.KnowledgeTag) ? "" : entity.KnowledgeTag });

                var obj = SlDatabase.ExecuteNonQuery(conn, sql, parameters.ToArray());
                return obj > 0 ? true : false;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

    }
}
