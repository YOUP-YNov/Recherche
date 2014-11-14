using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class Profile
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Pseudo { get; set; }
        public string Activity { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string Town { get; set; }

        public Profile(string _Id, string _Firstname, string _Lastname, string _Pseudo, string _Activity, int _Age, bool _Sex, string _Town)
        {
            this.Id = _Id;
            this.Firstname = _Firstname;
            this.Lastname = _Lastname;
            this.Pseudo = _Pseudo;
            this.Activity = _Activity;
            this.Age = _Age;
            this.Sex = _Sex;
            this.Town = _Town;
        }

    }
}
