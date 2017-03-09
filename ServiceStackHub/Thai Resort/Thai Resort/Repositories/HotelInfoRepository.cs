using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Thai_Resort.Repositories
{
    public class HotelInfoRepository
    {
        public IDbConnectionFactory userConnectionFactory { get; set; }

        public HotelInfo.HotelInfo getHotelInfo()
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                return connection.Select<HotelInfo.HotelInfo>(e => true)[1];
            }
        }
        public HotelInfo.Menu getMenu (DateTime date)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                return connection.Select<HotelInfo.Menu>(e => true)[1];
            }
        }

        public void writeHotelInfo(HotelInfo.HotelInfo hotelInfo)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                connection.CreateTable<HotelInfo.HotelInfo>();
                connection.DeleteAll<HotelInfo.HotelInfo>();
                connection.Insert(hotelInfo);
            }
        }
        public void writeMenu (HotelInfo.Menu menu)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                connection.CreateTable<HotelInfo.Menu>();
                connection.DeleteAll<HotelInfo.Menu>();
                connection.Insert(menu);
            }
        }

    }
}