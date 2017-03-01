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
        public object Any()
        {
            //FIX THIS PLEASE
            return null;
        }

    }
    public class WriteMealServiceEntry : IReturn<WriteMealServiceResponse>
    {
        public string username { get; set; }
        public string userHash { get; set; }
        public HotelInfo.WorkoutInfo workoutInfo { get; set; }
    }
    public class WriteMealServiceResponse
    {

    }
}