using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thai_Resort.Repositories
{
    public class UserInfoRepository
    {
        public UserDatabaseEntryResponse addUser (UserDatabaseEntry entry)
        {
            //Enter user into user database
           
            UserDatabaseEntryResponse response = new UserDatabaseEntryResponse();
            //TODO setup automated check in and check out assignment

            return response;
            throw new MissingMethodException("Must implement database repository!");

        }
        public void modifyUser()
        {

        }
        public void deleteUser()
        {

        }
        public HotelInfo.FitnessPlans getUserFitnessPlan (string username, string userHash)
        {
            throw new MissingMethodException("Must implement database repository");

            return HotelInfo.FitnessPlans.Aerobic;
        }
        public HotelInfo.DietPlans getUserDietPlan (string username, string userHash)
        {
            throw new MissingMethodException("Must implement database repository");

            return HotelInfo.DietPlans.Standard;
        }
        public List<HotelInfo.WorkoutInfo> getWorkoutInfo (string username, string userHash, DateTime date)
        {
            throw new MissingMethodException("Must implement database repository");
            return new List<HotelInfo.WorkoutInfo>();
        }
        public List<HotelInfo.MealInfo> getMealInfo (string username, string userHash, DateTime date)
        {
            throw new MissingMethodException("Must implement database repository");
            return new List<HotelInfo.MealInfo>();
        }
        public HotelInfo.BillingInfo getBillingInfo (string username, string userHash)
        {
            throw new MissingMethodException("Must implement database repository");
            return new HotelInfo.BillingInfo();
        }
    }
    public class UserDatabaseEntry : Services.ReservationServiceEntry
    {
        public string userHash { get; set; }
        public DateTime registrationDate { get; set; }
    }
    public class UserDatabaseEntryResponse
    {
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
}