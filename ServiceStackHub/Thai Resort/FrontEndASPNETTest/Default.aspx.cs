using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack;
using ServiceStack.Auth;
using Thai_Resort.HotelInfo;
using Thai_Resort.Services;

namespace FrontEndASPNETTest
{
    public partial class _Default : Page
    {
        public JsonServiceClient client = new JsonServiceClient("http://127.0.0.1:4915/");

        protected void Page_Load(object sender, EventArgs e)
        {
        }

    }
}