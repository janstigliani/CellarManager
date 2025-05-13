using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Beer : Beverage
    {
        public string Style { get; set; }

        public Beer(string name, double degree, string style) : base(name, degree)
        {
            Style = style;
        }
    }
}
