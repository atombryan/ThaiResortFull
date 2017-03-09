using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class WriteMealService : Service
    {
        UserInfoRepository UserInfoRepository { get; set; }
        public object Any(WriteMealServiceEntry entry)
        {
            return new WriteMealServiceResponse() { returnCode = UserInfoRepository.writeMealInfo(entry.username, entry.userHash, entry.mealInfo) };
        }

    }
    [Route("/WriteMeal")]
    public class WriteMealServiceEntry : IReturn<WriteMealServiceResponse>
    {
        public string username { get; set; }
        public string userHash { get; set; }
        public HotelInfo.MealInfo mealInfo { get; set; }
    }
    public class WriteMealServiceResponse
    {
        public int returnCode { get; set; }
    }
}