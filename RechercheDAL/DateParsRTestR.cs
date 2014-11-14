using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    class DateParsRTestR
    {
        DateTime? StrDate {get; set; }

        public DateParsRTestR(string _a)
        {
            //Test parameters FROM & SET if null
            if (_a == null) { this.StrDate = null; }
            //Else SET parameter From
            else
            {
                try
                { this.StrDate = DateTime.Parse(_a); }
                catch (Exception e) { }
            }
        }
    }
}
