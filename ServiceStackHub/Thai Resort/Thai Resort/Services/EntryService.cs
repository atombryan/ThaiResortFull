using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using System.Net;

namespace Thai_Resort
{
    public class EntryService : Service
    {
        public object Any(EntryServiceEntry entry)
        {
            //Write ipAddress and macAddress to log
            return new EntryServiceResponse() { responseTimeUTC = DateTime.UtcNow };
        }
    }

    [Route("/connect/{ipAddress}/{macAddress}")]
    public class EntryServiceEntry
    {
        public string ipAddress { get; set; }
        public string macAddress { get; set; }
    }
    public class EntryServiceResponse
    {
        public DateTime responseTimeUTC { get; set; }
    }

}
