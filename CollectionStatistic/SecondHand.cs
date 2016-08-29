using SoufunLab.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    internal class SecondHand
    {
        /// <summary>
        /// 二手房电商房源
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string EHouseResource(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND esfsubtype='ds' AND(roomid='' OR roomid IS NULL)";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 二手房普通房源
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string RegHouseResource(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND esfsubtype!='ds' AND(roomid='' OR roomid IS NULL)";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 二手房电商+普通房源
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string HouseResource(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND(roomid='' OR roomid IS NULL)";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 二手房小区
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string Neighborhood(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND PropertyType=3 AND(roomid='' OR roomid IS NULL)";

            return Common.Collections(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 电商
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_E(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND esfsubtype='ds' AND(roomid='' OR roomid IS NULL)";

            return Common.NewUser(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 普通
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_R(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND esfsubtype!='ds' AND(roomid='' OR roomid IS NULL)";

            return Common.NewUser(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 电商+普通
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_H(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND(roomid='' OR roomid IS NULL)";

            return Common.NewUser(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 小区用户
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string NewUser_N(string fromDate, string endDate)
        {
            string wherePart = "type='esf' AND PropertyType=3 AND(roomid='' OR roomid IS NULL)";

            return Common.NewUser(fromDate, endDate, wherePart);
        }

        /// <summary>
        /// 小区和房源排重
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        internal static string Total(string fromDate, string endDate)
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["myfang_r"].ConnectionString;
            string sql = @"declare @date datetime
                            declare @sum int
                            set @sum=0
                            set @date=@fromDate
                            while @date<@endDate
                            begin
                            with v_b as(({0}) union ({1}))
                            select @sum=@sum+COUNT(userid) from v_b
                            set @date=@date+1
                            end
                            select @sum/7";
            var sqlBuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='esf' AND PropertyType=3 AND(roomid='' OR roomid IS NULL)
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ALL ");
            }
            var sqlBuilder1 = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sqlBuilder1.Append("(SELECT userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where type='esf' AND(roomid='' OR roomid IS NULL)
		                                AND (createtime BETWEEN @date and @date+1)
		                                 )
	                                UNION ALL ");
            }
            
            var chars = "UNION ALL".ToCharArray();
            sql = string.Format(sql, sqlBuilder.ToString().TrimEnd(chars), sqlBuilder1.ToString().TrimEnd(chars));
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter() { ParameterName = "@fromDate", Value = fromDate });
            sqlparam.Add(new SqlParameter() { ParameterName = "@endDate", Value = endDate });

            return SlDatabase.ExecuteScalar(connection, sql, sqlparam.ToArray()).ToString();
        }
    }
}
