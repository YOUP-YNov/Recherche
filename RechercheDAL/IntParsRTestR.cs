using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RechercheDal
{
    public class IntParsRTestR
    {
        public string a { get; set; }
        public string b { get; set; }
        public int Intfrom { get; set; }
        public int Inttake { get; set; }

        public void ParsRTestR()
        {
            //Test parameters FROM & SET if null
            if (this.a == null) { this.Intfrom = 0; }
            //Else GET parameter From
            else { this.Intfrom = Int32.Parse(this.a); }
            //Test parameters TAKE & SET if null
            if ((this.b == null) || (Int32.Parse(this.b) == 0)) { this.Inttake = 20; }
            //Else GET parameters From && TAKE from URL
            else { this.Inttake = Int32.Parse(this.b); }
        }

        public IntParsRTestR(string _a, string _b)
        {
            this.a = _a;
            this.b = _b;
        }

    }
}
