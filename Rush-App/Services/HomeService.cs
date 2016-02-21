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
    }
}