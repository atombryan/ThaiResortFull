using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetMealInfoService : Service
    {

        UserInfoRepository UserInfoRepository { get; set; }
        public object Any (GetMealInfoServiceEntry entry)
        {
            return new GetMealInfoServiceResonse() { mealInfo = UserInfoRepository.getMealInfo(entry.username, entry.userHash, entry.date) };
        }

    }
    public class GetMealInfoServiceEntry : IReturn<GetMealInfoServiceResonse>
    {
        public string username { get; set; }
        public string userHash { get; set; }
        public DateTime date { get; set; }
    }
    public class GetMealInfoServiceResonse
    {
        public List<HotelInfo.MealInfo> mealInfo { get; set; }
    }
}