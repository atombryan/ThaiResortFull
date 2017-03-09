using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;

namespace Thai_Resort.Services
{
    public class GetBillingInfoService : Service
    {
        UserInfoRepository UserInfoRepository { get; set; }
        public object Any(GetBillingInfoEntry entry)
        {
            return new GetBillingInfoResponse() { info = UserInfoRepository.getBillingInfo(entry.username, entry.userHash) };
        }
    }
    [Route("/GetBillingInfo")]
    public class GetBillingInfoEntry : IReturn<GetBillingInfoResponse>
    {
        public string username { get; set; }
        public string userHash { get; set; }
    }
    public class GetBillingInfoResponse
    {
        public HotelInfo.BillingInfo info { get; set; }
    }
}