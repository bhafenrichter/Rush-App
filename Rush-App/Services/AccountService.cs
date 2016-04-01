using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rush_App.Models.db;
namespace Rush_App.Services
{
    public class AccountService
    {
        public static User Login(string email, string password)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Users
                    .Where(x => x.Email == email && x.Password == password)
                    .FirstOrDefault();
            }
        }

        internal static void createUser(User user)
        {
            using (var entities = new RushAppDBEntities())
            {
                var created = entities.Users.Create();
                created.Email = user.Email;
                created.Password = user.Password;
                created.FirstName = user.FirstName;
                created.LastName = user.LastName;
                created.Major = user.Major;
                created.UniversityID = user.UniversityID;
                created.GPA = user.GPA;
                created.HomeState = user.HomeState;
                created.Hometown = user.Hometown;
                entities.Users.Add(created);
                entities.SaveChanges();
            }
        }

        internal static User getUserById(int userid)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Users
                    .Include("University")
                    .Include("House")
                    .Where(x => x.ID == userid)
                    .FirstOrDefault();
            }
        }

        internal static IEnumerable<User> getRusheesForUniversity(int universityId)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Users.Where(x => x.GreekID == null && x.UniversityID == universityId).ToList();
            }
        }

        public static IEnumerable<User> getUsers()
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Users.ToList();
            };
        }

        public static IEnumerable<User> getUsersForUniversity(int universityID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Users.Where(x => x.UniversityID == universityID).ToList();
            };
        }

        public static IEnumerable<User> getUsersForHouse(int greekID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Users.Where(x => x.GreekID == greekID).ToList();
            };
        }

        internal static void UpdateUser(User u)
        {
            using (var entities = new RushAppDBEntities())
            {
                var user = entities.Users.Where(x => x.ID == u.ID).SingleOrDefault();
                if(user != null)
                {
                    //update the user
                    user.Email = u.Email;
                    user.Password = u.Password;
                    user.FirstName = u.FirstName;
                    user.LastName = u.LastName;
                    user.Year = u.Year;
                    user.Major = u.Major;
                    user.UniversityID = u.UniversityID;
                    user.GPA = u.GPA;
                    user.HomeState = u.HomeState;
                    user.Hometown = u.Hometown;
                    user.Facebook = u.Facebook;
                    user.Twitter = u.Twitter;
                    entities.SaveChanges();
                }
            }
        }
    }
}