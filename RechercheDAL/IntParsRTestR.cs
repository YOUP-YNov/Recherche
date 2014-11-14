using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class IntParsRTestR
    {
        public int Intfrom { get; set; }
        public int Inttake { get; set; }

        public IntParsRTestR(string _a, string _b)
        {
            //Test parameters FROM & SET if null
            if (_a == null) { this.Intfrom = 0; }
            //Else SET parameter From
            else { }
            {
                try
                { this.Intfrom = Int32.Parse(_a); }
                catch (Exception e) { }
            }
            
            //Test parameters TAKE & SET if null
            if ((_b == null) || (Int32.Parse(_b) == 0)) { this.Inttake = 20; }
            //Else SET parameters From && TAKE from URL
            if (_b != null) { this.Inttake = Int32.Parse(_b); }
            else
            {
                try
                { this.Intfrom = Int32.Parse(_a); }
                catch (Exception e) { }
            }
        }

    }
}
