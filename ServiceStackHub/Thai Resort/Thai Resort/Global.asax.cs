using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Funq;
using ServiceStack;
using ServiceStack.MiniProfiler;
using ServiceStack.Logging;
using ServiceStack.Logging.EventLog;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using ServiceStack.Data;
using ServiceStack.MiniProfiler.Data;
using Thai_Resort.Repositories;
using System.Reflection;
using Thai_Resort.Services;

namespace Thai_Resort
{
    public class Global : System.Web.HttpApplication
    {
        

        public class ThaiResortAppHost : AppHostBase 
        {
            public ThaiResortAppHost() : base("ThaiResort", typeof(GetHotelInfoService).Assembly)
            {

            }
            public override void Configure(Container container)
            {
                Plugins.Add(new AuthFeature(
                     () => new AuthUserSession(),
                     new IAuthProvider[] { new BasicAuthProvider(), }));

                container.Register<ICacheClient>(new MemoryCacheClient());
                var userRepo = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepo);
                string salt;
                string hash;
                string password = "Password";
                new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
                userRepo.CreateUserAuth(new UserAuth
                {
                    Id = 1,
                    PasswordHash = hash,
                    Salt = salt,
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Roles = new List<string> { "Basic", RoleNames.Admin },
                    Permissions = new List<string> { "PingTest" }
                }, password);

                //var hotelConnectionFactory = new OrmLiteConnectionFactory(@"\\\\49.49.49.19\\Databases\\HotelInfo.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                //var userConnectionFactory = new OrmLiteConnectionFactory(@"\\\\49.49.49.19\\Databases\\UserInfo.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                var hotelConnectionFactory = new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/hotel.db"), SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                var userConnectionFactory = new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/user.db"), SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                container.Register<IDbConnectionFactory>(hotelConnectionFactory);
                container.Register<IDbConnectionFactory>(userConnectionFactory);
                container.RegisterAutoWired<UserInfoRepository>();
                container.RegisterAutoWired<HotelInfoRepository>();

            }
        }
        public class ThaiResortAppHostDaemon : AppHostHttpListenerBase
        {
            public ThaiResortAppHostDaemon() : base("ThaiResort", typeof(GetHotelInfoService).Assembly)
            {

            }
            public override void Configure(Container container)
            {
                Plugins.Add(new AuthFeature(
                     () => new AuthUserSession(),
                     new IAuthProvider[] { new BasicAuthProvider(), }));

                container.Register<ICacheClient>(new MemoryCacheClient());
                var userRepo = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepo);
                string salt;
                string hash;
                string password = "Password";
                new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
                userRepo.CreateUserAuth(new UserAuth
                {
                    Id = 1,
                    PasswordHash = hash,
                    Salt = salt,
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Roles = new List<string> { "Basic", RoleNames.Admin },
                    Permissions = new List<string> { "PingTest" }
                }, password);

                //var hotelConnectionFactory = new OrmLiteConnectionFactory(@"\\\\49.49.49.19\\Databases\\HotelInfo.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                //var userConnectionFactory = new OrmLiteConnectionFactory(@"\\\\49.49.49.19\\Databases\\UserInfo.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                var hotelConnectionFactory = new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/hotel.db"), SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                var userConnectionFactory = new OrmLiteConnectionFactory(HttpContext.Current.Server.MapPath("~/App_Data/user.db"), SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                container.Register<IDbConnectionFactory>(hotelConnectionFactory);
                container.Register<IDbConnectionFactory>(userConnectionFactory);
                container.RegisterAutoWired<UserInfoRepository>();
                container.RegisterAutoWired<HotelInfoRepository>();

            }
        }
        public class ThaiResortAppHostSelfHost : AppSelfHostBase
        {
            public ThaiResortAppHostSelfHost() : base("ThaiResort", typeof(GetHotelInfoService).Assembly)
            {

            }
            public override void Configure(Container container)
            {
                Plugins.Add(new AuthFeature(
                      () => new AuthUserSession(),
                      new IAuthProvider[] { new BasicAuthProvider(), }));

                container.Register<ICacheClient>(new MemoryCacheClient());
                var userRepo = new InMemoryAuthRepository();
                container.Register<IUserAuthRepository>(userRepo);
                string salt;
                string hash;
                string password = "Password";
                new SaltedHash().GetHashAndSaltString(password, out hash, out salt);
                userRepo.CreateUserAuth(new UserAuth
                {
                    Id = 1,
                    PasswordHash = hash,
                    Salt = salt,
                    DisplayName = "Admin",
                    UserName = "Admin",
                    Roles = new List<string> { "Basic", RoleNames.Admin },
                    Permissions = new List<string> { "PingTest" }
                }, password);

                //var hotelConnectionFactory = new OrmLiteConnectionFactory(@"\\\\49.49.49.19\\Databases\\HotelInfo.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                //var userConnectionFactory = new OrmLiteConnectionFactory(@"\\\\49.49.49.19\\Databases\\UserInfo.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                var hotelConnectionFactory = new OrmLiteConnectionFactory(@"D:\LocalDB\hotel.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                var userConnectionFactory = new OrmLiteConnectionFactory(@"D:\LocalDB\user.db", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) };
                container.Register<IDbConnectionFactory>(hotelConnectionFactory);
                container.Register<IDbConnectionFactory>(userConnectionFactory);
                container.RegisterAutoWired<UserInfoRepository>();
                container.RegisterAutoWired<HotelInfoRepository>();

            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new ThaiResortAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.IsLocal)
            {
                Profiler.Start();
            }
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            Profiler.Stop();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}