using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransfportData
{
    public class MySelect
    {
        /// <summary>
        /// UserID
        /// </summary>
        public long UserID { get; set; }


        /// <summary>
        /// Face
        /// </summary>
        public string Face { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// PriceCategory
        /// </summary>
        public string PriceCategory { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }


        /// <summary>
        /// Linkurl
        /// </summary>
        public string Linkurl { get; set; }


        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }


        /// <summary>
        /// Pricetype
        /// </summary>
        public string Pricetype { get; set; }


        /// <summary>
        /// 创建时间（我的灵感专辑接口必传）
        /// </summary>
        public DateTime Createtime { get; set; }


        /// <summary>
        /// HouseID
        /// </summary>
        public string HouseID { get; set; }


        /// <summary>
        /// Roomnum
        /// </summary>
        public string Roomnum { get; set; }


        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }


        /// <summary>
        /// MySelectID
        /// </summary>
        public int MySelectID { get; set; }


        /// <summary>
        /// PropertyType
        /// </summary>
        public int PropertyType { get; set; }


        /// <summary>
        /// Coordx
        /// </summary>
        public string Coordx { get; set; }


        /// <summary>
        /// Coordy
        /// </summary>
        public string Coordy { get; set; }


        /// <summary>
        /// Guapailiang
        /// </summary>
        public int Guapailiang { get; set; }


        /// <summary>
        /// Service
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// 二手房房源类型（委托房源/非委托房源）
        /// </summary>
        public string EsfSubType { get; set; }

        /// <summary>
        /// 电商房源类型
        /// </summary>
        public string ChannelType { get; set; }

        /// <summary>
        /// 房源ID
        /// </summary>
        public string FangYuanID { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public string Roomid { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 设计师ID/工长ID/灵感专辑ID/我的灵感专辑ID
        /// </summary>
        public string Homeid { get; set; }

        /// <summary>
        /// 服务区域（关注设计师/工长时的参数，收藏灵感专辑不需要该参数）
        /// </summary>
        public string ServiceArea { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 商圈
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 户型
        /// </summary>
        public string Huxing { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public string Mianji { get; set; }

        /// <summary>
        /// 施工案例/设计作品个数
        /// </summary>
        public int CaseCount { get; set; }

        /// <summary>
        /// 当前价格
        /// </summary>
        public double HousePrice { get; set; }

        /// <summary>
        /// 当前状态
        /// </summary>
        public int HouseStatus { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime PriceUpdateTime { get; set; }

        /// <summary>
        /// 知识收藏标签 --蒋杰 2015-11-02
        /// </summary>
        public string KnowledgeTag { get; set; }

        #region 新房价格（均价、最高价或最低价） --蒋杰 2015-11-02
        /// <summary>
        /// NewHousePrice
        /// </summary>
        public double NewHousePrice { get; set; }

        /// <summary>
        /// PriceUnit
        /// </summary>
        public string PriceUnit { get; set; }
        #endregion
    }
}
