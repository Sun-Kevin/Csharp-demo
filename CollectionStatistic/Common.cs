using SoufunLab.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStatistic
{
    internal class Common
    {
        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["myfang_r"].ConnectionString;

        internal static string Collections(string fromDate, string endDate, string wherePart)
        {
            string sql = "with v_t as({0}) select count(myselectid) from v_t";
            var sqlBuilder = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                sqlBuilder.Append("(SELECT MySelectID FROM [mysoufun].[dbo].[MySelect_" + i + @"]
                                    WHERE " + wherePart + @" 
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

        internal static string NewUser(string fromDate, string endDate, string wherePart)
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
                sqlBuilder.Append("(SELECT  userid FROM [mysoufun].[dbo].[MySelect_" + i + @"]
		                                with (nolock) where "+wherePart+@" 
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
    }
}
