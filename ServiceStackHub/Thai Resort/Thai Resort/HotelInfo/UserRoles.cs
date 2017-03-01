using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Configuration;

namespace Thai_Resort.HotelInfo
{
    public class UserRoles
    {
        public static readonly string BASIC = "basic";
        public static readonly string ADMIN = RoleNames.Admin;
        public static readonly string EMPLOYEE = "employee";
        public static readonly string MANAGER = "manager";
    }
}