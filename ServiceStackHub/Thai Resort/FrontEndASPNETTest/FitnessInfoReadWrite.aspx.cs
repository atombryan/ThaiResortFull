using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceStack;
using Thai_Resort.Services;
using Thai_Resort.HotelInfo;

namespace FrontEndASPNETTest
{
    public partial class FitnessInfoReadWrite : System.Web.UI.Page
    {
        public JsonServiceClient client = new JsonServiceClient("http://192.168.1.125:4915/");

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetPlanInfoServiceResponse info = client.Send<GetPlanInfoServiceResponse>(new GetPlanInfoServiceEntry { userHash = hashBox.Text });
            if (info.plan == FitnessPlans.Aerobic) fitPlanLabel.Text = "Aerobic";
            if (info.plan == FitnessPlans.BulkBuilding) fitPlanLabel.Text = "Bulk Building";
            if (info.plan == FitnessPlans.Flexibility) fitPlanLabel.Text = "Flexibility";
            if (info.plan == FitnessPlans.StrengthTraining) fitPlanLabel.Text = "Strength Training";
        }

        protected void writeWorkoutButton_Click(object sender, EventArgs e)
        {
            WriteWorkoutServiceResponse info = client.Send<WriteWorkoutServiceResponse>(new WriteWorkoutServiceEntry
            {
                userHash = hashBox.Text,
                workoutInfo = new WorkoutInfo { caloriesBurned = Convert.ToInt32(calBox.Text),
                    date = writeDateCal.SelectedDate,
                    reps = RepBox.Text,
                    workoutType = workoutTypeBox.Text }
            });
        }

        protected void readWorkoutButton_Click(object sender, EventArgs e)
        {
            GetWorkoutInfoServiceResponse info = client.Send<GetWorkoutInfoServiceResponse>(new GetWorkoutInfoServiceEntry
            {
                userhash = hashBox.Text,
                date = readDateCal.SelectedDate
            });
            string reps = "";
            string types = "";
            int cals = 0;
            foreach (WorkoutInfo work in info.workoutInfo)
            {
                reps += work.reps + ", ";
                types += work.workoutType + ", ";
                cals += work.caloriesBurned;
            }
            repsLabel.Text = reps;
            typesLabel.Text = types;
            calsLabel.Text = info.workoutInfo.Count.ToString();
        }
    }
}