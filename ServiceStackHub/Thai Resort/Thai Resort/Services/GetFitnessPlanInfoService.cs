using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.HotelInfo;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetFitnessPlanInfoService : Service
    {
        public UserInfoRepository UserInfoRepository { get; set; }

        public object Any(GetPlanInfoServiceEntry entry)
        { 
            return new GetPlanInfoServiceResponse() { plan = UserInfoRepository.getUserFitnessPlan(entry.userHash) };
        }
    }
    [Route("/GetFitPlanInfo")]
    public class GetPlanInfoServiceEntry : IReturn<GetPlanInfoServiceResponse>
    {
        public string userHash { get; set; }
    }
    public class GetPlanInfoServiceResponse
    {
        public FitnessPlans plan { get; set; }
    }
}