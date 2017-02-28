using Funq;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.Logging.EventLog;
using ServiceStack.MiniProfiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;


namespace Thai_Resort
{
    public class Global : System.Web.HttpApplication
    {
        public class ThaiResortAppHost : AppHostBase 
        {
            public ThaiResortAppHost() : base("ThaiResort", typeof(EntryService).Assembly)
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