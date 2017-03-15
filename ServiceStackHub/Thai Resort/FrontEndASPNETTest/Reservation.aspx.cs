using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEndASPNETTest
{
    public partial class Reservation : System.Web.UI.Page
    {
        public JsonServiceClient client = new JsonServiceClient("http://192.168.1.125:4915/");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ReservationServiceResponse info = client.Send<ReservationServiceResponse>(new ReservationServiceEntry
            {
                email = EmailBox.Text,
                arrival = ArriveBox.SelectedDate,
                departure = DepartBox.SelectedDate,
                dateOfBirth = DOBBox.SelectedDate,
                fullName = NameBox.Text,
                specialRequests = RequestBox.Text,
                reservationPlan = Thai_Resort.HotelInfo.ReservationPlans.FullPackage,
                phoneNumber = PhoneBox.Text,
                username = userBox.Text,
                password = passBox.Text
            });

            userh.Text = info.userHash;

        }
    }
}