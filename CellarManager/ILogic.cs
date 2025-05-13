﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal interface ILogic
    {
        public void AddBeer(string name, double degree, string style);
        public void AddWine(string name, double degree, string vite, string type );
        public List<Beverage> GetAllBeverages();
    }
}
