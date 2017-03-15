using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using Thai_Resort.Repositories;
using Thai_Resort.HotelInfo;
using ServiceStack.Auth;

namespace Thai_Resort.Services
{
    public class ReservationService : Service
    {
        public UserInfoRepository UserInfoRepository { get; set; }
        public IUserAuthRepository userRepo { get; set; }

        public object Any(ReservationServiceEntry entry)
        {
            ReservationServiceResponse response = new ReservationServiceResponse() { checkIn = new DateTime(2016, 2, 5), checkOut = new DateTime(2017, 2, 5), returnCode = 0 };
            UserDatabaseEntry databaseEntry = new UserDatabaseEntry()
            {
                email = entry.email,
                phoneNumber = entry.phoneNumber,
                arrival = entry.arrival,
                dateOfBirth = entry.dateOfBirth,
                departure = entry.departure,
                fullName = entry.fullName,
                reservationPlan = entry.reservationPlan,
                specialRequests = entry.specialRequests,
                password = "",
                fitnessPlan = FitnessPlans.Flexibility,
                dietPlan = DietPlans.HighProtein,
                billingInfo = new BillingInfo { totalHotel = 0, totalMeal = 0, totalRoomService = 0 }
            };
            databaseEntry.registrationDate = DateTime.Now;
            string salt;
            string hash;
            new SaltedHash().GetHashAndSaltString(entry.fullName, out hash, out salt);
            databaseEntry.userHash = salt + hash;
            response.userHash = salt + hash;
          //  if (entry.arrival >= entry.departure || entry.arrival <= DateTime.Now) response.returnCode = 1;
          //  else if (entry.reservationPlan >= ReservationPlans.END) response.returnCode = 2;
          //  else if (entry.dateOfBirth.Add(new TimeSpan(6574, 0, 0, 0, 0)) > DateTime.Now) response.returnCode = 3;
          //  else if (!entry.email.Contains("@")) response.returnCode = 4;
            
            {
                if (UserInfoRepository.Equals(null))
                {
                    throw new Exception ("IT'S NULL");
                }
                UserDatabaseEntryResponse entryResponse =  UserInfoRepository.addUser(databaseEntry);
                response.checkIn = new DateTime();
                response.checkOut = new DateTime();
                string userSalt;
                string passHash;
                new SaltedHash().GetHashAndSaltString(entry.password, out passHash, out userSalt);
                userRepo.CreateUserAuth(new UserAuth()
                {
                    Email = entry.email,
                    PhoneNumber = entry.phoneNumber,
                    BirthDate = entry.dateOfBirth,
                    FullName = entry.fullName,
                    UserName = entry.username,
                    Salt = userSalt,
                    PasswordHash = passHash,
                    Roles = new List<string>() { HotelInfo.UserRoles.BASIC }
                },
                entry.password);
            }

            return response;
        }

    }
    
    public class ReservationServiceEntry : IReturn<ReservationServiceResponse>
    {
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public ReservationPlans reservationPlan { get; set; }
        public DateTime arrival { get; set; }
        public DateTime departure { get; set;}
        public string fullName { get; set; }
        public string specialRequests { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    }


    /// <summary>
    /// Error Codes:
    /// 0 = Successfully Written
    /// 1 = Invalid arrival or departure time
    /// 2 = Invalid reservation plan
    /// 3 = Cannot register as a minor
    /// 4 = Invalid email address
    /// </summary>
    public class ReservationServiceResponse
    {
        public int returnCode { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
        public string userHash { get; set; }
    }
}