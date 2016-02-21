using Rush_App.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rush_App.Models
{
    public class ProfileViewModel
    {
        public IEnumerable<University> Universities { get; set; }
        public IEnumerable<House> Houses { get; set; }
        public IEnumerable<State> States { get; set; }

        public User User { get; set; }
    }
}