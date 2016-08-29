using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoufunLab.Framework.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace CollectionStatistic
{
    internal class NewHouse
    {
        static string connection = ConfigurationManager.ConnectionStrings["myfang_r"].ConnectionString;

        /// <summary>
        /// 新房楼盘收藏
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string Project(string fromDate, string endDate)
        {
            string sql = "with v_t as({0}) select count(myselectid) from v_t";
            var sqlBuilder = new StringBuilder();
            
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT MySelectID FROM [mysoufun].[dbo].[MySelect_" + i + @"]
                                    WHERE type='new' AND houseid!='' AND (FangYuanID='' OR FangYuanID IS NULL) AND (roomid ='' OR roomid IS NULL)
	                                AND (createtime BETWEEN @fromDate AND @endDate)
	                                 )
                                UNION ALL ");
            }
            var chars = "UNION ALL".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter(){ParameterName="@fromDate",Value=fromDate});
            sqlparam.Add(new SqlParameter(){ParameterName="@endDate",Value=endDate});

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }

        /// <summary>
        /// 新房房源收藏
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string HouseResource(string fromDate, string endDate)
        {
            string sql = "with v_t as({0}) select count(myselectid) from v_t";
            var sqlBuilder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT MySelectID FROM [mysoufun].[dbo].[MySelect_" + i + @"]
                                    WHERE type='new' AND FangYuanID!='' 
	                                AND (createtime BETWEEN @fromDate AND @endDate)
	                                 )
                                UNION ALL ");
            }
            var chars = "UNION ALL".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }

        /// <summary>
        /// 新房户型
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string DwellingType(string fromDate, string endDate)
        {
            string sql = "with v_t as({0}) select count(myselectid) from v_t";
            var sqlBuilder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT MySelectID FROM [mysoufun].[dbo].[MySelect_" + i + @"]
                                    WHERE type='new' AND roomid !='' 
	                                AND (createtime BETWEEN @fromDate AND @endDate)
	                                 )
                                UNION ALL ");
            }
            var chars = "UNION ALL".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }
        
        /// <summary>
        /// 新房楼盘用户
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_Pro(string fromDate, string endDate)
        {
            string sql = @"declare @date datetime
                            declare @sum int
                            set @sum=0
                            set @date=@fromDate
                            while @date<@endDate
                            begin
                            with v_b as({0})
                            select @sum=@sum+COUNT(userid) from v_b
                            set @date=@date+1
                            end
                            select @sum/7";
            var sqlBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT  userid FROM [mysoufun].[dbo].[MySelect_"+i+@"]
		                                with (nolock) where type='new' AND houseid!='' AND (FangYuanID='' OR FangYuanID IS NULL) AND (roomid ='' OR roomid IS NULL)
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ");
            }
            var chars = "UNION ".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }

        /// <summary>
        /// 新房房源用户
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_Hou(string fromDate, string endDate)
        {
            string sql = @"declare @date datetime
                            declare @sum int
                            set @sum=0
                            set @date=@fromDate
                            while @date<@endDate
                            begin
                            with v_b as({0})
                            select @sum=@sum+COUNT(userid) from v_b
                            set @date=@date+1
                            end
                            select @sum/7";
            var sqlBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='new' AND FangYuanID!=''
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ");
            }
            var chars = "UNION ".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }

        /// <summary>
        /// 新房户型用户
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_Dw(string fromDate, string endDate)
        {
            string sql = @"declare @date datetime
                            declare @sum int
                            set @sum=0
                            set @date=@fromDate
                            while @date<@endDate
                            begin
                            with v_b as({0})
                            select @sum=@sum+COUNT(userid) from v_b
                            set @date=@date+1
                            end
                            select @sum/7";
            var sqlBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='new' AND roomid !=''
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ");
            }
            var chars = "UNION ".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }

        internal static string Total(string fromDate, string endDate)
        {
            string sql = @"declare @date datetime
                            declare @sum int
                            set @sum=0
                            set @date=@fromDate
                            while @date<@endDate
                            begin
                            with v_b as(({0}) union ({1}) union ({2}))
                            select @sum=@sum+COUNT(userid) from v_b
                            set @date=@date+1
                            end
                            select @sum/7";
            var sqlBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='new' AND roomid !=''
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ALL ");
            }
            var sqlBuilder1 = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder1.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='new' AND FangYuanID!=''
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ALL ");
            }
            var sqlBuilder2 = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder2.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='new' AND houseid!='' AND (FangYuanID='' OR FangYuanID IS NULL) AND (roomid ='' OR roomid IS NULL)
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ALL ");
            }
            var chars = "UNION ALL".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars), sqlBuilder1.ToString().TrimEnd(chars), sqlBuilder2.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }
    }
}
