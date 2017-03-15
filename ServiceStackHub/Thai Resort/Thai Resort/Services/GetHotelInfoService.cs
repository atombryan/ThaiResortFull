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
        public object Any(GetHotelInfoServiceEntry entry)
        {
            if (entry.value)
            {
                return new GetHotelInfoServiceResponse { info = new HotelInfo.HotelInfo { activities = new List<string> { "Swimming", "Golf", "Yay" }, description = "bigOlHotel", name = "The Thai Resort", services = new List<string>() { "Workout", "Eat", "Have Fun" } } };
                //return new GetHotelInfoServiceResponse() { info = HotelInfoRepository.getHotelInfo() };
            }
            return new GetHotelInfoServiceResponse();            
        } 
    }

    [Route("/GetHotelInfo")]
    public class GetHotelInfoServiceEntry
    {
        public bool value { get; set; }
    }

    public class GetHotelInfoServiceResponse
    {
        public HotelInfo.HotelInfo info { get; set; }
    }
}