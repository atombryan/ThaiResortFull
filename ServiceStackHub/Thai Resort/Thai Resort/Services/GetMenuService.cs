using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetMenuService
    {
        HotelInfoRepository HotelInfoRepository { get; set; }
        public object Any(GetMenuServiceEntry entry)
        {
            return new GetMenuServiceResponse() { menu = HotelInfoRepository.getMenu(entry.date) };
        }
    }

    [Route("/GetMenu")]
    public class GetMenuServiceEntry
    {
        public DateTime date { get; set; }
    }

    public class GetMenuServiceResponse
    {
        public HotelInfo.Menu menu { get; set; }
    }
}