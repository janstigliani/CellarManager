using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellarManager.model;

namespace CellarManager
{
    internal class CsvStorage : IStorage
    {
        private readonly string _filePath = "beverages.csv";
        public List<Beverage> LoadAllBeverages()
        {
            var beverages = new List<Beverage>();

            if (!File.Exists(_filePath)) return beverages;

            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var type = parts[0];
                var name = parts[1];
                if (!double.TryParse(parts[2], out double degree))
                    continue;

                if (type == "Beer")
                {
                    var style = parts[3];
                    beverages.Add(new Beer(name, degree, style));
                }
                else if (type == "Wine")
                {
                    var vite = parts[3];
                    var wineType = parts[4];
                    beverages.Add(new Wine(name, degree, vite, wineType));
                }
            }

            return beverages;
        }
                

        public void SaveAllBeverages(List<Beverage> beverages)
        {
            var lines = new List<string>();

            foreach (var beverage in beverages)
            {
                if (beverage is Beer beer)
                {
                    lines.Add($"Beer,{beer.Name},{beer.Degree},{beer.Style}");
                }
                else if (beverage is Wine wine)
                {
                    lines.Add($"Wine,{wine.Name},{wine.Degree},{wine.Vite},{wine.Type}");
                }
            }

            File.WriteAllLines(_filePath, lines);
        }
    }
}
