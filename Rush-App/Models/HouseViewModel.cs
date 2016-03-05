using Rush_App.Models.db;
using System.Collections.Generic;

namespace Rush_App.Models
{
    public class HouseViewModel
    {
        public House House { get; set; }
        public User User { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}