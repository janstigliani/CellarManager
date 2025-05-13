using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellarManager.model
{
    internal class Wine: Beverage
    {
        public string Vite {  get; set; }
        public string Type { get; set; }

        public Wine(string name, double degree, string vite, string type) : base(name, degree)
        {
            Vite = vite;
            Type = type;
        }
    }
}
