using Rush_App.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rush_App.Models
{
    public class HomeViewModel
    {
        public IEnumerable<User> Rushees { get; set; }
        public IEnumerable<User> Members { get; set; }
        public University University { get; set; }
        public User User { get; set; }
        public IEnumerable<House> Houses { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}