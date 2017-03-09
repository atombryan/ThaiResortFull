using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thai_Resort.Repositories
{
    public class UserInfoRepository
    {

        public IDbConnectionFactory userConnectionFactory { get; set; }

        public UserDatabaseEntryResponse addUser (UserDatabaseEntry entry)
        {
            //Enter user into user database
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                connection.CreateTable<UserDatabaseEntry>();
                connection.Insert(new UserDatabaseEntry()
                {
                    userHash = entry.userHash,
                    registrationDate = entry.registrationDate,
                    email = entry.email,
                    arrival = entry.arrival,
                    dateOfBirth = entry.dateOfBirth,
                    departure = entry.departure,
                    fullName = entry.fullName,
                    phoneNumber = entry.phoneNumber,
                    specialRequests = entry.specialRequests,
                    reservationPlan = entry.reservationPlan
                });
                return new UserDatabaseEntryResponse() { checkIn = DateTime.Now, checkOut = DateTime.Now };
            }
        }
        public void modifyUser(string userHash, UserDatabaseEntry entry)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                UserDatabaseEntry currentInfo = connection.Select<UserDatabaseEntry>(e => e.userHash.Equals(userHash))[1];
                connection.Delete<UserDatabaseEntry>(e => e.userHash.Equals(userHash));
                connection.Insert(new UserDatabaseEntry()
                {
                    userHash = entry.userHash,
                    registrationDate = entry.registrationDate,
                    email = entry.email,
                    arrival = entry.arrival,
                    dateOfBirth = entry.dateOfBirth,
                    departure = entry.departure,
                    fullName = entry.fullName,
                    phoneNumber = entry.phoneNumber,
                    specialRequests = entry.specialRequests,
                    reservationPlan = entry.reservationPlan,
                    fitnessPlan = currentInfo.fitnessPlan,
                    meals = currentInfo.meals,
                    workouts = currentInfo.workouts
                });
            }
        }
        public void deleteUser(string userHash)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                connection.Delete<UserDatabaseEntry>(e => e.userHash.Equals(userHash));
            }
        }
        public HotelInfo.FitnessPlans getUserFitnessPlan (string userHash)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
               return connection.Select<UserDatabaseEntry>(e => e.userHash == userHash)[1].fitnessPlan;
            }
        }
        public int writeMealInfo (string username, string userHash, HotelInfo.MealInfo mealInfo)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                mealInfo.date = DateTime.Now;
                UserDatabaseEntry currentInfo = connection.Select<UserDatabaseEntry>(e => e.userHash.Equals(userHash))[1];
                if (currentInfo.Equals(null)) return 1;
                currentInfo.meals.Add(mealInfo);
                connection.Delete<UserDatabaseEntry>(e => e.userHash.Equals(userHash));
                connection.Insert<UserDatabaseEntry>(currentInfo);
            }
            return 0;
        }
        public int writeWorkoutInfo (string username, string userHash, HotelInfo.WorkoutInfo workoutInfo)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                workoutInfo.date = DateTime.Now;
                UserDatabaseEntry currentInfo = connection.Select<UserDatabaseEntry>(e => e.userHash.Equals(userHash))[1];
                if (currentInfo.Equals(null)) return 1;
                currentInfo.workouts.Add(workoutInfo);
                connection.Delete<UserDatabaseEntry>(e => e.userHash.Equals(userHash));
                connection.Insert<UserDatabaseEntry>(currentInfo);
            }
            return 0;
        }


        public HotelInfo.DietPlans getUserDietPlan (string username, string userHash)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                return connection.Select<UserDatabaseEntry>(e => e.userHash == userHash)[1].dietPlan;
            }
        }
        public List<HotelInfo.WorkoutInfo> getWorkoutInfo (string username, string userHash, DateTime date)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                List<HotelInfo.WorkoutInfo> workouts = connection.Select<UserDatabaseEntry>(e => e.userHash == userHash)[1].workouts;
                List<HotelInfo.WorkoutInfo> workoutsOnDate = new List<HotelInfo.WorkoutInfo>();
                foreach (HotelInfo.WorkoutInfo wkout in workouts)
                {
                    if (wkout.date.Equals(date)) workoutsOnDate.Add(wkout);
                }
                return workoutsOnDate;
            }
        }
        public List<HotelInfo.MealInfo> getMealInfo (string userHash, DateTime date)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                List<HotelInfo.MealInfo> meals = connection.Select<UserDatabaseEntry>(e => e.userHash == userHash)[1].meals;
                List<HotelInfo.MealInfo> mealsOnDate = new List<HotelInfo.MealInfo>();
                foreach (HotelInfo.MealInfo meal in meals)
                {
                    if (meal.date.Equals(date)) mealsOnDate.Add(meal);
                }
                return mealsOnDate;
            }
        }
        public HotelInfo.BillingInfo getBillingInfo (string username, string userHash)
        {
            using (var connection = userConnectionFactory.OpenDbConnection())
            {
                return connection.Select<UserDatabaseEntry>(e => e.userHash == userHash)[1].billingInfo;
            }
        }
    }
    public class UserDatabaseEntry : Services.ReservationServiceEntry
    {
        public string userHash { get; set; }
        public DateTime registrationDate { get; set; }
        public HotelInfo.FitnessPlans fitnessPlan { get; set; }
        public List<HotelInfo.MealInfo> meals { get; set; }
        public List<HotelInfo.WorkoutInfo> workouts { get; set; }
        public HotelInfo.DietPlans dietPlan { get; set; }
        public HotelInfo.BillingInfo billingInfo { get; set; }
    }
    public class UserDatabaseEntryResponse
    {
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
    }
}