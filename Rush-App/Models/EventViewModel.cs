using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rush_App.Models.db;

namespace Rush_App.Models
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<User> UsersAttending { get; set; }
        public UserEvent UserEvent { get; set; }
        public User User { get; set; }
    }
}