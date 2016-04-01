using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rush_App.Models.db;

namespace Rush_App.Services
{
    public class HomeService
    {
        public static IEnumerable<University> getUniversities()
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Universities.ToList();
            };
        }

        public static IEnumerable<House> getHouses()
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Houses
                    .Include("University")
                    .ToList();
            };
        }

        public static IEnumerable<House> getHousesForUniversity(int universityID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Houses
                    .Where(x => x.UniversityID == universityID)
                    .ToList();
            };
        }

        public static IEnumerable<State> getStates()
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.States.ToList();
            }
        }

        internal static House getHouseById(int houseID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Houses.Where(x => x.ID == houseID).FirstOrDefault();
            }
        }

        internal static IEnumerable<Event> getEventsByHouse(int houseID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Events.Where(x => x.GreekId == houseID).ToList();
            }
        }

        internal static IEnumerable<Event> getEventsByUniversity(int universityID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Events
                    .Include("House")
                    .Where(x => x.UniversityId == universityID && x.Date > DateTime.Now)
                    .ToList();
            }
        }

        internal static void createEvent(Event e)
        {
            using (var entities = new RushAppDBEntities())
            {
                var evt = entities.Events.Create();
                evt.Name = e.Name;
                evt.Description = e.Description;
                evt.GreekId = e.GreekId;
                evt.Date = e.Date;
                evt.StartTime = e.StartTime;
                evt.EndTime = e.EndTime;
                evt.Address = e.Address;
                evt.City = e.City;
                evt.State = e.State;
                evt.Zip = e.Zip;
                entities.Events.Add(evt);
                entities.SaveChanges();
            }
        }

        internal static UserEvent getUserEventByIDs(int userID, int eventID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.UserEvents.Where(x => x.ID == userID && x.EventId == eventID).FirstOrDefault();
            }
                
        }

        internal static Event getEventById(int eventID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.Events.Where(x => x.ID == eventID).FirstOrDefault();
            }
        }

        public static IEnumerable<User> getUsersAttendingEvent(int eventID)
        {
            using (var entities = new RushAppDBEntities())
            {
                return entities.UserEvents.Where(x => x.EventId == eventID).Select(x => x.User1).ToList();
            }
        }

        internal static string setAttendance(int userID, int eventID, string status)
        {
            using (var entities = new RushAppDBEntities())
            {
                if (entities.UserEvents.Where(x => x.UserId == userID && x.EventId == eventID).Count() == 0)
                {
                    //create a new entry
                    try
                    {
                        var ue = entities.UserEvents.Create();
                        ue.UserId = userID;
                        ue.EventId = eventID;
                        ue.Status = status;
                        entities.UserEvents.Add(ue);
                        entities.SaveChanges();
                        return ue.Status;
                    }
                    catch (Exception e)
                    {
                        return "";
                    }
                }
                else
                {
                    try
                    {
                        //update the current entry
                        var current = entities.UserEvents.Where(x => x.UserId == userID && x.EventId == eventID).FirstOrDefault();
                        current.Status = status;
                        entities.SaveChanges();
                        return current.Status;
                    }
                    catch (Exception e)
                    {
                        return "";
                    }
                }
            }
        }
    }
}