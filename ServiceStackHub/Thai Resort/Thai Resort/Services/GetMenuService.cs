using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetMenuService : Service
    {
        HotelInfoRepository HotelInfoRepository { get; set; }
        public object Any(DateTime date)
        {
            return new GetMenuServiceResponse() { menu = HotelInfoRepository.getMenu(date) };
        }
    }
    public class GetMenuServiceResponse
    {
        public HotelInfo.Menu menu { get; set; }
    }
}