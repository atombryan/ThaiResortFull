using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetHotelInfoService : Service
    {
        HotelInfoRepository HotelInfoRepository { get; set; } 
        public object Any(bool get)
        {
            if (get)
            {
                return new GetHotelInfoServiceResponse() { info = HotelInfoRepository.getHotelInfo() };
            }
            return new GetHotelInfoServiceResponse();            
        } 
    }
    public class GetHotelInfoServiceResponse
    {
        public HotelInfo.HotelInfo info { get; set; }
    }
}