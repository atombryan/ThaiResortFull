using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetWorkoutInfoService : Service
    {
        public UserInfoRepository UserInfoRepository { get; set; }

        public object Any(GetWorkoutInfoServiceEntry entry)
        {
            return new GetWorkoutInfoServiceResponse() { workoutInfo = UserInfoRepository.getWorkoutInfo(entry.userhash, entry.date) };
        }
    }

    [Route("/GetWorkInfo")]
    public class GetWorkoutInfoServiceEntry : IReturn<GetWorkoutInfoServiceResponse>
    {
        public string userhash { get; set; }
        public DateTime date { get; set; }
    }
    public class GetWorkoutInfoServiceResponse
    {
        public List<HotelInfo.WorkoutInfo> workoutInfo { get; set; }

    }
}