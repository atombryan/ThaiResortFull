using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class WriteWorkoutService : Service
    {
        public UserInfoRepository UserInfoRepository { get; set; }
        public object Any(WriteWorkoutServiceEntry entry)
        {
            return new WriteWorkoutServiceResponse() { returnCode = UserInfoRepository.writeWorkoutInfo(entry.userHash, entry.workoutInfo) };
        }
        
    }
    [Route("/WriteWork")]
    public class WriteWorkoutServiceEntry : IReturn<WriteWorkoutServiceResponse>
    {
        public string userHash { get; set; }
        public HotelInfo.WorkoutInfo workoutInfo { get; set; }
    }
    public class WriteWorkoutServiceResponse
    {
        public int returnCode { get; set; }
    }
}