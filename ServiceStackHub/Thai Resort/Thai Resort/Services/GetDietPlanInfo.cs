using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.HotelInfo;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetDietPlanInfo : Service
    {
        UserInfoRepository UserInfoRepository { get; set; }

        public object Any(GetDietPlanInfoEntry entry)
        {
            return new GetDietPlanInfoResponse() { plan = UserInfoRepository.getUserDietPlan(entry.username, entry.userHash) };
        }

    }

    [Route("/GetDietPlanInfo")]
    public class GetDietPlanInfoEntry : IReturn<GetDietPlanInfo>
    {
        public string username { get; set; }
        public string userHash { get; set; }
    }
    public class GetDietPlanInfoResponse
    {
        public DietPlans plan { get; set; }
    }
}